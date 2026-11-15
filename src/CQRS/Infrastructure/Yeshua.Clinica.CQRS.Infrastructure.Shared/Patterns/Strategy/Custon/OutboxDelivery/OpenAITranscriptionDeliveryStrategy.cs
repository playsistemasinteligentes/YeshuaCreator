using Command.Interfaces.Patterns.FileStore;

namespace Clinica.Infrastructure.OutboxDelivery;

public sealed class OpenAITranscriptionDeliveryStrategy(
    HttpClient client, IFileStorage storage, ClinicaTranscriptionOptions options)
    : OpenAICompatibleTranscriptionDeliveryStrategy(client, storage, options,
        options.ApiKey, options.Model, options.BaseUrl,
        options.Model == "gpt-transcribe" ? "languages[]" : "language", "openai");
