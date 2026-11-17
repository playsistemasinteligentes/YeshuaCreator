using System.Text.Json;
using Dominio.Patterns.Saga;
namespace Command.Receivers;

public static class SessionInsightContract
{
    public static JsonElement ReadResult(string payload, string expectedStatus)
        => Command.Patterns.Transcription.AudioTranscriptionResult.ReadResult(payload, expectedStatus);
    public static string ReadTranscript(string payload)
        => Command.Patterns.Transcription.AudioTranscriptionResult.ReadText(payload);
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
