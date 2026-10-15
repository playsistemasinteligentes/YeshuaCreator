namespace Dominio.Media;

public sealed record VideoModel(int Id, string Name, string Motion, string Transition, double TransitionSeconds, double Zoom, int SuggestedMusicId);
public sealed record MusicTrack(int Id, string Title, string Category, string StorageKey)
{
    public string Artist => "Kevin MacLeod";
    public string License => "CC BY 4.0";
    public string SourceUrl => "https://incompetech.com/music/royalty-free/";
    public string LicenseUrl => "https://creativecommons.org/licenses/by/4.0/";
    public string Credits => $"Musica: {Title} - Kevin MacLeod (incompetech.com).\nLicenca CC BY 4.0: {LicenseUrl}\nFonte: {SourceUrl}\nTrecho adaptado com ajuste de volume, repeticao e fades.";
}

public static class VideoPresentation
{
    public const int DefaultModel = 1;
    public const int DefaultVolume = 35;
    public static IReadOnlyList<VideoModel> Models { get; } = Array.AsReadOnly(new[]
    {
        new VideoModel(1, "Classico", "none", "none", 0, 1, 0),
        new VideoModel(2, "Romantico", "zoom-in", "fade", .7, 1.06, 1),
        new VideoModel(3, "Aventura", "pan", "fade", .5, 1.08, 2),
        new VideoModel(4, "Celebracao", "zoom-out", "fade", .45, 1.07, 3)
    });
    public static IReadOnlyList<MusicTrack> Music { get; } = Array.AsReadOnly(new[]
    {
        new MusicTrack(1, "Air Prelude", "Romantico", "persistent/memorias/music/air-prelude-v1.mp3"),
        new MusicTrack(2, "Adventure Meme", "Aventura", "persistent/memorias/music/adventure-meme-v1.mp3"),
        new MusicTrack(3, "Carefree", "Celebracao", "persistent/memorias/music/carefree-v1.mp3")
    });

    public static bool TryModel(int? id, out VideoModel model)
    {
        model = (id ?? 0) switch { 0 or 1 => Models[0], 2 => Models[1], 3 => Models[2], 4 => Models[3], _ => null! };
        return model != null;
    }
    public static MusicTrack? FindMusic(int? id) => id switch { 1 => Music[0], 2 => Music[1], 3 => Music[2], _ => null };
    public static bool ValidMusic(int? id) => id is null or 0 or 1 or 2 or 3;
    public static bool ValidVolume(int? volume) => volume is null or >= 0 and <= 100;
}
