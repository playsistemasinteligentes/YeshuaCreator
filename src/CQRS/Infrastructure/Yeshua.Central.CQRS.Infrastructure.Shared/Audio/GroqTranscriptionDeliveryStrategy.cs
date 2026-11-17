using Command.Interfaces.Patterns.FileStore;

namespace Central.Infrastructure.OutboxDelivery;

public sealed class GroqTranscriptionDeliveryStrategy(
    HttpClient client, IFileStorage storage, CentralTranscriptionOptions options)
    : Shared.Audio.OpenAICompatibleTranscriptionDeliveryStrategy(client, storage, new Shared.Audio.AudioTranscriptionStorageOptions { StorageRoot = options.StorageRoot, FFmpegExecutable = options.FFmpegExecutable, InputNamespace = "central" },
        options.Groq.ApiKey, options.Groq.Model, options.Groq.BaseUrl, "language", "central-groq", "central.audio.transcribed");
