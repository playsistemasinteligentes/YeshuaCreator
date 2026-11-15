using Command.Patterns.OutBox;

namespace Clinica.Infrastructure.OutboxDelivery;

public enum TranscriptionDeliveryProvider { OpenAI, Queue, Groq }

public sealed class ClinicaTranscriptionOptions
{
    public TranscriptionDeliveryProvider Provider { get; init; } = TranscriptionDeliveryProvider.OpenAI;
    public string ApiKey { get; init; } = "";
    public string Model { get; init; } = "gpt-transcribe";
    public string BaseUrl { get; init; } = "https://api.openai.com/v1";
    public GroqTranscriptionOptions Groq { get; init; } = new();
    public string StorageRoot { get; init; } = "/storage";
    public string FFmpegExecutable { get; init; } = "ffmpeg";
}

public sealed class GroqTranscriptionOptions
{
    public string ApiKey { get; init; } = "";
    public string Model { get; init; } = "whisper-large-v3-turbo";
    public string BaseUrl { get; init; } = "https://api.groq.com/openai/v1";
}

// Same Strategy + explicit factory selection used by NotificationFactory.
// This factory is consumed only at the Outbox delivery boundary, never by a saga.
public sealed class TranscriptionDeliveryFactory(
    QueueOutboxDeliveryStrategy queue, OpenAITranscriptionDeliveryStrategy openAI,
    GroqTranscriptionDeliveryStrategy groq, ClinicaTranscriptionOptions options) : IOutboxDeliveryFactory
{
    public string SelectProvider(OutboxDeliveryRequest request) => request.Message.Type == "audio.transcribe"
        ? options.Provider switch
        {
            TranscriptionDeliveryProvider.OpenAI => "OpenAI",
            TranscriptionDeliveryProvider.Queue => "Queue",
            TranscriptionDeliveryProvider.Groq => "Groq",
            _ => throw new OutboxDeliveryException("provider_invalid", "Destino de entrega invalido.", false)
        } : "Queue";

    public IOutboxDeliveryStrategy GetType(string provider) => provider switch
    {
        "Queue" => queue,
        "OpenAI" => openAI,
        "Groq" => groq,
        _ => throw new OutboxDeliveryException("provider_invalid", "Destino de entrega invalido.", false)
    };
}
