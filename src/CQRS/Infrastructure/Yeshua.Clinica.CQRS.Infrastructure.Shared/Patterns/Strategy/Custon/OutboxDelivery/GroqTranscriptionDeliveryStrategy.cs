using Command.Interfaces.Patterns.FileStore;
using Command.Patterns.OutBox;

namespace Clinica.Infrastructure.OutboxDelivery;

// Groq implements the same multipart contract. Reuse preparation, validation and
// error handling; separate credentials keep already-bound OpenAI deliveries valid.
public sealed class GroqTranscriptionDeliveryStrategy(
    HttpClient client, IFileStorage storage, ClinicaTranscriptionOptions options) : IOutboxDeliveryStrategy
{
    private readonly OpenAITranscriptionDeliveryStrategy _delivery = new(client, storage, new ClinicaTranscriptionOptions
    {
        ApiKey = options.GroqApiKey,
        Model = options.GroqModel,
        BaseUrl = options.GroqBaseUrl,
        StorageRoot = options.StorageRoot,
        FFmpegExecutable = options.FFmpegExecutable
    }, prepareAllAudio: true); // 600s / ~4.8MB parts even for long compressed inputs.

    public int TransportType => _delivery.TransportType;

    public Task<ExternalExecutionResult?> DeliverAsync(OutboxDeliveryRequest request, CancellationToken cancellationToken)
        => _delivery.DeliverAsync(request, cancellationToken);
}
