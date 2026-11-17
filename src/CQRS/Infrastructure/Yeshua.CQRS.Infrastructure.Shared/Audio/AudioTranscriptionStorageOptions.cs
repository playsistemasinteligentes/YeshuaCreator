namespace Shared.Audio;

public sealed class AudioTranscriptionStorageOptions
{
    public string StorageRoot { get; init; } = "/storage";
    public string FFmpegExecutable { get; init; } = "ffmpeg";
    public string InputNamespace { get; init; } = "";
}
