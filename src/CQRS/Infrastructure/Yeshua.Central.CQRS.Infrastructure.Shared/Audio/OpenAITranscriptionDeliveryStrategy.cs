using Command.Interfaces.Patterns.FileStore;

namespace Central.Infrastructure.OutboxDelivery;

public sealed class OpenAITranscriptionDeliveryStrategy(
    HttpClient client, IFileStorage storage, CentralTranscriptionOptions options)
    : Shared.Audio.OpenAICompatibleTranscriptionDeliveryStrategy(client, storage, new Shared.Audio.AudioTranscriptionStorageOptions { StorageRoot = options.StorageRoot, FFmpegExecutable = options.FFmpegExecutable, InputNamespace = "central" },
        options.ApiKey, options.Model, options.BaseUrl,
        options.Model == "gpt-transcribe" ? "languages[]" : "language", "central-openai", "central.audio.transcribed");
