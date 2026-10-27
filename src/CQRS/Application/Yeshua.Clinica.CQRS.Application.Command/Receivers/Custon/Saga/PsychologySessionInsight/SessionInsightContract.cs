using System.Text.Json;
using Dominio.Patterns.Saga;
namespace Command.Receivers;

public static class SessionInsightContract
{
    public static JsonElement ReadResult(string payload, string expectedStatus)
    {
        try
        {
            using var doc = JsonDocument.Parse(payload);
            var root = doc.RootElement;
            if (root.TryGetProperty("status", out var status))
            {
                if (status.GetString() != expectedStatus)
                {
                    var retryable = status.GetString()?.EndsWith(".failed", StringComparison.Ordinal) == true
                        && root.TryGetProperty("error", out var error) && error.ValueKind == JsonValueKind.Object
                        && error.TryGetProperty("retryable", out var retry) && retry.ValueKind == JsonValueKind.True;
                    throw new SagaStepExecutionException("O executor de IA nao concluiu a tarefa solicitada.", retryable);
                }
                return root.GetProperty("result").Clone();
            }
            return root.Clone(); // Compatibility with results already persisted by the original listener.
        }
        catch (SagaStepExecutionException) { throw; }
        catch (Exception) { throw new SagaStepExecutionException("Retorno da IA invalido.", retryable: false); }
    }
    public static string ReadTranscript(string payload)
    {
        var result = ReadResult(payload, "audio.transcription.completed");
        if (!result.TryGetProperty("text", out var text) || text.ValueKind != JsonValueKind.String || string.IsNullOrWhiteSpace(text.GetString()) || text.GetString()!.Length > 300000)
            throw new SagaStepExecutionException("Transcricao ausente no retorno da IA.", retryable: false);
        return text.GetString()!;
    }
    public static IReadOnlyDictionary<string, string> ReadSummary(string payload)
    {
        try
        {
            var result = ReadResult(payload, "text.summarize.completed");
            var values = new Dictionary<string, string>(StringComparer.Ordinal);
            foreach (var field in result.GetProperty("fields").EnumerateArray())
            {
                var key = field.GetProperty("key").GetString() ?? "";
                var value = field.GetProperty("value").GetString();
                var limit = key switch { "Prontuario" => 8000, "QueixaPrincipal" => 1000, "RegistroDocumental" => 8000, _ => 0 };
                if (limit == 0 || value is null || value.Length > limit || !values.TryAdd(key, value))
                    throw new SagaStepExecutionException("Campos inesperados, repetidos ou extensos no resumo.", retryable: false);
            }
            if (values.Count != 3 || string.IsNullOrWhiteSpace(values["Prontuario"]) || string.IsNullOrWhiteSpace(values["RegistroDocumental"]))
                throw new SagaStepExecutionException("Resumo incompleto.", retryable: false);
            return values;
        }
        catch (SagaStepExecutionException) { throw; }
        catch (Exception) { throw new SagaStepExecutionException("Resumo invalido.", retryable: false); }
    }
}
