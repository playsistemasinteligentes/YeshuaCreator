using Command.Interfaces.Patterns.FileStore;
namespace Clinica.Infrastructure.OutboxDelivery;

// The existing provider contract delegates multipart, limits and FFmpeg to the shared audio core.
public abstract class OpenAICompatibleTranscriptionDeliveryStrategy(
    HttpClient client, IFileStorage storage, ClinicaTranscriptionOptions options,
    string apiKey, string model, string baseUrl, string languageField, string temporaryPrefix)
    : Shared.Audio.OpenAICompatibleTranscriptionDeliveryStrategy(client, storage,
        new Shared.Audio.AudioTranscriptionStorageOptions { StorageRoot = options.StorageRoot, FFmpegExecutable = options.FFmpegExecutable },
        apiKey, model, baseUrl, languageField, temporaryPrefix);
