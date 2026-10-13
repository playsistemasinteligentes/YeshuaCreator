namespace Memorias.YouTube;

public sealed class YouTubeOptions
{
    public string ClientId { get; set; } = "";
    public string ClientSecret { get; set; } = "";
    public string RedirectUri { get; set; } = "";
    public string EncryptionKey { get; set; } = "";
    public string CredentialsDirectory { get; set; } = "";
    public string ProcessingScope { get; set; } = "";

    public bool Configured => !string.IsNullOrWhiteSpace(ClientId)
        && !string.IsNullOrWhiteSpace(ClientSecret)
        && Path.IsPathFullyQualified(CredentialsDirectory)
        && !string.IsNullOrWhiteSpace(ProcessingScope)
        && ValidRedirectUri() && ValidEncryptionKey();

    private bool ValidRedirectUri() => Uri.TryCreate(RedirectUri, UriKind.Absolute, out var uri)
        && (uri.Scheme == Uri.UriSchemeHttps || (uri.IsLoopback && uri.Scheme == Uri.UriSchemeHttp))
        && string.IsNullOrEmpty(uri.Fragment) && string.IsNullOrEmpty(uri.Query)
        && string.IsNullOrEmpty(uri.UserInfo);

    private bool ValidEncryptionKey()
    {
        try { return Convert.FromBase64String(EncryptionKey).Length == 32; }
        catch (FormatException) { return false; }
    }
}
