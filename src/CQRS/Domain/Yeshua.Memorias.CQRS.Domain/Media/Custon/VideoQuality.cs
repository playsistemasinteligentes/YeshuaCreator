namespace Dominio.Media;

public enum VideoQuality
{
    Economica = 1,
    Padrao = 2,
    Alta = 3
}

public readonly record struct VideoQualityProfile(VideoQuality Quality, int Width, int Height, int Crf);

public static class VideoQualityProfiles
{
    public const VideoQuality Default = VideoQuality.Padrao;

    public static bool TryResolve(int? quality, out VideoQualityProfile profile)
    {
        // NULL/zero identifica dados antigos, criados quando o unico perfil era 1080p.
        profile = quality switch
        {
            null or 0 or (int)VideoQuality.Padrao => new(VideoQuality.Padrao, 1920, 1080, 18),
            (int)VideoQuality.Economica => new(VideoQuality.Economica, 1280, 720, 23),
            (int)VideoQuality.Alta => new(VideoQuality.Alta, 3840, 2160, 18),
            _ => default
        };
        return profile.Width > 0;
    }
}
