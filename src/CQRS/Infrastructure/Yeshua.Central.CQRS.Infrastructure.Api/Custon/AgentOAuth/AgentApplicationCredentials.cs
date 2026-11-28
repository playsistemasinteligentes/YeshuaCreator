using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Central.BusinessMcp;
using Microsoft.IdentityModel.Tokens;

namespace Central.AgentOAuth;

public sealed record PreparedApplicationCredential(string Application, string Origin, string Token, DateTimeOffset ExpiresAt, string BasePath = "/");
public sealed record PreparedApplicationCredentials(string ProtectedValue, DateTimeOffset ExpiresAt);

// Self-contained part of the signed MCP access token. Destination bearer tokens
// are encrypted so the external client cannot extract/replay them. Unsealing and
// selecting a previously issued credential require only local cryptography.
public sealed class AgentApplicationCredentials
{
    public const string ClaimType = "application_credentials";
    private const string EntriesClaim = "applications";
    private const string TokenType = "yeshua-agent-applications+jwt";
    private readonly AgentOAuthOptions options;
    private readonly TimeProvider clock;
    private readonly SigningCredentials signing;
    private readonly EncryptingCredentials encryption;
    private readonly TokenValidationParameters validation;

    public AgentApplicationCredentials(AgentOAuthOptions options, JwtSettings jwt, TimeProvider clock)
    {
        this.options = options; this.clock = clock;
        var signingKey = AgentOAuthOptions.Key(jwt.SecretKey, "ApplicationCredentials.Signing");
        var encryptionKey = AgentOAuthOptions.Key(jwt.SecretKey, "ApplicationCredentials.Encryption");
        signing = new(signingKey, SecurityAlgorithms.HmacSha256);
        encryption = new(encryptionKey, SecurityAlgorithms.Aes256KW, SecurityAlgorithms.Aes128CbcHmacSha256);
        validation = new()
        {
            ValidateIssuer = true, ValidIssuer = options.Issuer, ValidateAudience = true, ValidAudience = options.Resource,
            ValidateLifetime = true, ClockSkew = TimeSpan.Zero, RequireExpirationTime = true, RequireSignedTokens = true,
            ValidateIssuerSigningKey = true, IssuerSigningKey = signingKey, TokenDecryptionKey = encryptionKey,
            ValidTypes = [TokenType], ValidAlgorithms = [SecurityAlgorithms.HmacSha256, SecurityAlgorithms.Aes256KW, SecurityAlgorithms.Aes128CbcHmacSha256],
            LifetimeValidator = (notBefore, expires, _, _) => expires is not null
                && expires.Value > clock.GetUtcNow().UtcDateTime
                && (notBefore is null || notBefore.Value <= clock.GetUtcNow().UtcDateTime)
        };
    }
    public PreparedApplicationCredentials Protect(string owner, int tenant, string client, string grant,
        IReadOnlyList<PreparedApplicationCredential> entries, DateTimeOffset expiration)
    {
        var claims = new Claim[] { new("sub", owner), new("tenantId", tenant.ToString()), new("client_id", client),
            new("delegation_id", grant), new(EntriesClaim, JsonSerializer.Serialize(entries)) };
        var value = new JwtSecurityTokenHandler().CreateEncodedJwt(new SecurityTokenDescriptor
        {
            Issuer = options.Issuer, Audience = options.Resource, Subject = new ClaimsIdentity(claims),
            IssuedAt = clock.GetUtcNow().UtcDateTime, NotBefore = clock.GetUtcNow().UtcDateTime, Expires = expiration.UtcDateTime,
            SigningCredentials = signing, EncryptingCredentials = encryption, TokenType = TokenType
        });
        // Bound the new self-contained material, rather than falling back to a
        // database/cache lookup when a client requests too many applications.
        if (value.Length > 12288) throw new BusinessAccessException("delegation_snapshot_too_large");
        return new(value, expiration);
    }
    public string Select(DelegatedIdentity identity, string application, string origin, string requestPath = "/yapi/")
    {
        var outer = identity.Principal;
        if (outer is null || !identity.Scopes.Contains(AgentOAuthOptions.ApplicationScope(application)))
            throw new BusinessAccessException("insufficient_scope");
        if (!long.TryParse(outer.FindFirst("exp")?.Value, out var expiration)
            || DateTimeOffset.FromUnixTimeSeconds(expiration) <= clock.GetUtcNow())
            throw new BusinessAccessException("invalid_token");
        var value = outer.FindFirst(ClaimType)?.Value;
        if (string.IsNullOrEmpty(value) || value.Length > 12288) throw new BusinessAccessException("destination_not_prepared");
        try
        {
            var handler = new JwtSecurityTokenHandler { MapInboundClaims = false };
            var snapshot = handler.ValidateToken(value, validation, out _);
            if (snapshot.FindFirst("sub")?.Value != identity.Subject
                || snapshot.FindFirst("tenantId")?.Value != identity.TenantId.ToString()
                || snapshot.FindFirst("client_id")?.Value != identity.ClientId
                || snapshot.FindFirst("delegation_id")?.Value != identity.DelegationId)
                throw new BusinessAccessException("invalid_token");
            var entries = JsonSerializer.Deserialize<PreparedApplicationCredential[]>(snapshot.FindFirst(EntriesClaim)!.Value)!;
            var entry = entries.SingleOrDefault(e => e.Application == application && e.Origin == origin
                && requestPath.StartsWith(e.BasePath + "yapi/", StringComparison.Ordinal));
            if (entry is null || entry.ExpiresAt <= clock.GetUtcNow()) throw new BusinessAccessException("destination_not_prepared");
            return entry.Token;
        }
        catch (Exception error) when (error is SecurityTokenException or ArgumentException or JsonException or InvalidOperationException or NullReferenceException)
        { throw new BusinessAccessException("invalid_token"); }
    }
}
