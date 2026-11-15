using Command.Interfaces.Patterns.FileStore;

namespace Clinica.Infrastructure.OutboxDelivery;

public sealed class GroqTranscriptionDeliveryStrategy(
    HttpClient client, IFileStorage storage, ClinicaTranscriptionOptions options)
    : OpenAICompatibleTranscriptionDeliveryStrategy(client, storage, options,
        options.Groq.ApiKey, options.Groq.Model, options.Groq.BaseUrl, "language", "groq");
