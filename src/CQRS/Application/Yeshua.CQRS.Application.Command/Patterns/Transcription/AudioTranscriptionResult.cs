using Dominio.Patterns.Saga;
using System.Text.Json;

namespace Command.Patterns.Transcription;

public static class AudioTranscriptionResult
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
            return root.Clone();
        }
        catch (SagaStepExecutionException) { throw; }
        catch (Exception) { throw new SagaStepExecutionException("Retorno da IA invalido.", retryable: false); }
    }

    public static string ReadText(string payload)
    {
        var result = ReadResult(payload, "audio.transcription.completed");
        if (!result.TryGetProperty("text", out var text) || text.ValueKind != JsonValueKind.String
            || string.IsNullOrWhiteSpace(text.GetString()) || text.GetString()!.Length > 300000)
            throw new SagaStepExecutionException("Transcricao ausente no retorno da IA.", retryable: false);
        return text.GetString()!;
    }
}
