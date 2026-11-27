using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Central.AgentOAuth;

public sealed class AgentOAuthOptions
{
    public bool Enabled { get; set; }
    public string Issuer { get; set; } = "";
    public string Resource { get; set; } = "";
    public string SigningPrivateKeyPem { get; set; } = "";
    public RsaSecurityKey SigningKey()
    {
        try
        {
            var rsa = RSA.Create(); rsa.ImportFromPem(SigningPrivateKeyPem);
            if (rsa.KeySize < 2048 || !SigningPrivateKeyPem.Contains("PRIVATE KEY", StringComparison.Ordinal))
                throw new InvalidOperationException("Invalid signing key.");
            return new RsaSecurityKey(rsa) { KeyId = Convert.ToHexString(SHA256.HashData(rsa.ExportSubjectPublicKeyInfo()))[..24] };
        }
        catch (Exception error) when (error is ArgumentException or CryptographicException)
        { throw new InvalidOperationException("Agent OAuth requires a configured RSA private key of at least 2048 bits."); }
    }
    public List<string> KnownProxies { get; set; } = [];
    public List<AgentOAuthClient> Clients { get; set; } = [];
    public const string ResourceScheme = "CentralAgentOAuth";
    public const string ResourcePolicy = "CentralAgentOAuth";
    public IEnumerable<string> SupportedScopes => new[] { "business:discover", "offline_access" }
        .Concat(Clients.SelectMany(c => c.Applications).Distinct(StringComparer.Ordinal).Select(ApplicationScope));
    public static string ApplicationScope(string app) => "application:" + app;
    public void Validate()
    {
        _ = SigningKey();
        if (KnownProxies.Any(value => !System.Net.IPAddress.TryParse(value, out var address)
            || address.Equals(System.Net.IPAddress.Any) || address.Equals(System.Net.IPAddress.IPv6Any)))
            throw new InvalidOperationException("Known OAuth proxies must be explicit IP addresses.");
        foreach (var value in new[] { Issuer, Resource })
            if (!Uri.TryCreate(value, UriKind.Absolute, out var uri) || uri.Scheme != "https" || uri.UserInfo != ""
                || uri.Query != "" || uri.Fragment != "") throw new InvalidOperationException("Agent OAuth requires fixed HTTPS issuer/resource URIs.");
        Issuer = new Uri(Issuer).AbsoluteUri;
        Resource = new Uri(Resource).AbsoluteUri;
        if (new Uri(Resource).AbsolutePath != "/business/mcp" || new Uri(Resource).GetLeftPart(UriPartial.Authority) != new Uri(Issuer).GetLeftPart(UriPartial.Authority))
            throw new InvalidOperationException("The agent resource must be /business/mcp on the configured Central issuer origin.");
        if (new Uri(Issuer).AbsolutePath != "/") throw new InvalidOperationException("Agent OAuth issuer must be an origin ending in '/'.");
        if (Clients.Count == 0 || Clients.Select(c => c.ClientId).Distinct(StringComparer.Ordinal).Count() != Clients.Count)
            throw new InvalidOperationException("Pre-registered agent clients are required.");
        foreach (var client in Clients)
        {
            if (string.IsNullOrWhiteSpace(client.ClientId) || client.ClientId.Length > 100 || string.IsNullOrWhiteSpace(client.DisplayName)
                || client.RedirectUris.Count == 0 || client.Applications.Count == 0)
                throw new InvalidOperationException("Invalid agent client registration.");
            foreach (var callback in client.RedirectUris)
                if (!Uri.TryCreate(callback, UriKind.Absolute, out var uri) || uri.Scheme != "https" || uri.UserInfo != "" || uri.Fragment != "")
                    throw new InvalidOperationException("Agent callback must be an exact pre-registered HTTPS URI.");
            if (client.Applications.Any(app => app.Length > 100 || app.Length == 0 || app.Any(c => !char.IsAsciiLetterOrDigit(c) && c is not ('.' or '_' or '-'))))
                throw new InvalidOperationException("Invalid application identifier.");
        }
    }
    // Encryption derives from the existing private JWT root. The RSA signing key
    // is configured in the SAME credentials.json, never a second secret provider.
    public static SymmetricSecurityKey Key(string root, string purpose)
    {
        if (Encoding.UTF8.GetByteCount(root) < 32) throw new InvalidOperationException("Central JWT root must contain at least 32 bytes for Agent OAuth.");
        return new(HMACSHA256.HashData(Encoding.UTF8.GetBytes(root), Encoding.UTF8.GetBytes("Yeshua.Central.AgentOAuth.v1." + purpose)));
    }
}
public sealed class AgentOAuthClient
{
    public string ClientId { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public List<string> RedirectUris { get; set; } = [];
    public List<string> Applications { get; set; } = [];
}
