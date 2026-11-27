using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Central.BusinessMcp;
using Command.UseCase;
using Dominio.Commercial;
using Microsoft.IdentityModel.Tokens;

namespace Central.AgentOAuth;

// Runs exclusively in the code exchange/refresh path, after current Central
// permissions and revocation have been resolved. Reuses the existing getMenu
// mapping; it is never injected into a business request sender or policy.
public sealed class AgentApplicationPreparation(HttpClient client, TrustedBusinessCatalog catalog,
    AgentApplicationCredentials credentials, JwtSettings jwt, TimeProvider clock)
{
    public async Task<PreparedApplicationCredentials> PrepareAsync(LoginOutputCommand owner, string clientId,
        string grantId, IReadOnlySet<string> scopes, CancellationToken ct)
    {
        var expiration = clock.GetUtcNow().AddMinutes(5);
        var entries = new List<PreparedApplicationCredential>();
        var targets = catalog.Entries.Select(e => (e.Contract.Application, Origin: e.Target.GetLeftPart(UriPartial.Authority)))
            .Distinct().Where(e => scopes.Contains(AgentOAuthOptions.ApplicationScope(e.Application))).ToArray();
        if (targets.Length > 8) throw new BusinessAccessException("delegation_snapshot_too_large");
        foreach (var (application, origin) in targets)
        {
            if (!owner.catalogos.Contains(application, StringComparer.OrdinalIgnoreCase)) throw new BusinessAccessException("operation_not_allowed");
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, owner.UserId.ToString()), new(ClaimTypes.Email, owner.email),
                new("tenantId", owner.tenantId.ToString()), new("userCatalogs", application), new("userModules", string.Join(',', owner.modulos)),
                new("tokenOrigin", "Central"), new("application", "Central"), new("tenantDocument", owner.tenantDocument),
                new("tenantName", owner.tenantName), new("userName", owner.userName)
            };
            UsageRightClaims.AddTo(claims, UsageRightClaims.Read(owner.UsageRights));
            var delegationClaims = new Claim[] { new("owner_sub", owner.UserId.ToString()), new("client_id", clientId),
                new("delegation_id", grantId), new("token_kind", "delegated"), new("delegation_kind", "external_agent") };
            var entryExpiry = expiration;
            if (application != "Central")
            {
                using var session = new HttpRequestMessage(HttpMethod.Get, origin + "/yapi/getMenu");
                session.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Issue(claims.Concat(delegationClaims), origin + "/yapi/getMenu", expiration));
                using var response = await client.SendAsync(session, HttpCompletionOption.ResponseHeadersRead, ct);
                if (!response.IsSuccessStatusCode || !response.Headers.TryGetValues("X-Yeshua-Application-Token", out var values))
                    throw new BusinessAccessException("destination_denied");
                var handler = new JwtSecurityTokenHandler { MapInboundClaims = false };
                var principal = handler.ValidateToken(values.Single(), new TokenValidationParameters
                {
                    ValidateIssuer = false, ValidateAudience = false, ValidateLifetime = true, ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey)),
                    RequireSignedTokens = true, ValidateIssuerSigningKey = true
                }, out var validated);
                var localUser = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? principal.FindFirst("nameid")?.Value;
                if (!int.TryParse(localUser, out var localId) || localId <= 0
                    || principal.FindFirst("tenantId")?.Value != owner.tenantId.ToString()
                    || principal.FindFirst("application")?.Value != application
                    || principal.FindFirst("tokenOrigin")?.Value != "Application")
                    throw new BusinessAccessException("destination_denied");
                claims = principal.Claims.Where(c => c.Type is not ("aud" or "iss" or "exp" or "iat" or "nbf" or "role"
                    or "owner_sub" or "client_id" or "delegation_id" or "token_kind" or "delegation_kind")
                    && c.Type != ClaimTypes.Role && !c.Type.StartsWith("oi_", StringComparison.Ordinal)).ToList();
                entryExpiry = new[] { expiration, new DateTimeOffset(DateTime.SpecifyKind(validated.ValidTo, DateTimeKind.Utc)) }.Min();
            }
            claims.AddRange(delegationClaims);
            entries.Add(new(application, origin, Issue(claims, origin, entryExpiry), entryExpiry));
        }
        return credentials.Protect(owner.UserId.ToString(), owner.tenantId, clientId, grantId, entries, expiration);
    }
    private string Issue(IEnumerable<Claim> claims, string audience, DateTimeOffset expiration) => new JwtSecurityTokenHandler().WriteToken(
        new JwtSecurityToken(audience: audience, claims: claims, expires: expiration.UtcDateTime,
            signingCredentials: new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey)), SecurityAlgorithms.HmacSha256)));
}
