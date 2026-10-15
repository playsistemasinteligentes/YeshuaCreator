using System.Text.Json.Serialization;
using RepositoryInterfaces.Patterns.Command;

namespace Command.Receivers
{
    internal static class MemoriasPublicationStatus
    {
        public const int Solicitada = 10;
        public const int ManifestoPreparado = 20;
        public const int RenderizacaoSolicitada = 30;
        public const int VideoRenderizado = 40;
        public const int YouTubePendenteConfiguracao = 45;
        public const int PublicadaNoYouTube = 50;
        public const int Finalizada = 60;
        public const int Falhou = 90;
    }

    internal sealed record AlbumRenderManifest(
        int Version,
        string OutputStorageKey,
        int Width,
        int Height,
        int Fps,
        int SecondsPerPhoto,
        IReadOnlyCollection<AlbumRenderPhoto> Photos,
        int QualityClass,
        int Crf,
        string Motion,
        string Transition,
        double TransitionSeconds,
        double Zoom,
        string? AudioStorageKey,
        double AudioVolume);

    internal sealed record AlbumRenderPhoto(
        string StorageKey,
        int DurationSeconds,
        string Caption,
        int RotationDegrees = 0);

    public sealed class RenderAlbumResultMessage : ICommand
    {
        [JsonPropertyName("messageId")]
        public string? MessageId { get; set; }

        [JsonPropertyName("correlationId")]
        public string? CorrelationId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("result")]
        public RenderAlbumResultPayload? Result { get; set; }

        [JsonPropertyName("error")]
        public RenderAlbumErrorPayload? Error { get; set; }
    }

    public sealed class RenderAlbumResultPayload
    {
        [JsonPropertyName("outputStorageKey")]
        public string OutputStorageKey { get; set; } = string.Empty;

        [JsonPropertyName("durationSeconds")]
        public decimal DurationSeconds { get; set; }

        [JsonPropertyName("photoCount")]
        public int PhotoCount { get; set; }

        [JsonPropertyName("fileSizeBytes")]
        public long FileSizeBytes { get; set; }

        [JsonPropertyName("sha256")]
        public string Sha256 { get; set; } = string.Empty;
    }

    public sealed class RenderAlbumErrorPayload
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
    }
}
