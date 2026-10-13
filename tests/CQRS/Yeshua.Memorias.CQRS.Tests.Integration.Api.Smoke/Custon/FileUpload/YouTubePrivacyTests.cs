using System.Reflection;
using Command.Receivers;

namespace Yeshua.Memorias.Tests;

public class YouTubePrivacyTests
{
    [Theory]
    [InlineData(1, "private")]
    [InlineData(2, "unlisted")]
    [InlineData(3, "public")]
    [InlineData(0, "private")]
    public void MapsAlbumPrivacyToYouTube(int albumPrivacy, string expected)
    {
        var mapping = typeof(EnviarVideoParaYouTubeHandler).GetMethod(
            "ResolvePrivacyStatus", BindingFlags.Static | BindingFlags.NonPublic)!;

        Assert.Equal(expected, mapping.Invoke(null, [albumPrivacy]));
    }
}
