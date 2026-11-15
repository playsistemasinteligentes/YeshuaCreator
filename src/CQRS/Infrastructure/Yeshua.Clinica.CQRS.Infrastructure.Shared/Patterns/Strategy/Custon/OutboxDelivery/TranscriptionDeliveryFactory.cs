using Command.Patterns.OutBox;

namespace Clinica.Infrastructure.OutboxDelivery;

public enum TranscriptionDeliveryProvider { OpenAI, Queue, Groq }

public sealed class ClinicaTranscriptionOptions
{
    public TranscriptionDeliveryProvider Provider { get; init; } = TranscriptionDeliveryProvider.OpenAI;
    public string ApiKey { get; init; } = "";
    public string Model { get; init; } = "gpt-transcribe";
    public string BaseUrl { get; init; } = "https://api.openai.com/v1";
    public string GroqApiKey { get; init; } = "";
    public string GroqModel { get; init; } = "whisper-large-v3-turbo";
    public string GroqBaseUrl { get; init; } = "https://api.groq.com/openai/v1";
    public string StorageRoot { get; init; } = "/storage";
    public string FFmpegExecutable { get; init; } = "ffmpeg";
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
