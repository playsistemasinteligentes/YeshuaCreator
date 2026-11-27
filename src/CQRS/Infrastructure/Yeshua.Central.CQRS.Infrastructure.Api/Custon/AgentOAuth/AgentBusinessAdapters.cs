using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Central.BusinessMcp;
using Dominio.Commercial;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;

namespace Central.AgentOAuth;

public sealed class AgentGrantReader(IOpenIddictAuthorizationManager grants, IOpenIddictApplicationManager clients) : IDelegationRepository
{
    public async Task<Delegation?> FindAsync(string id, CancellationToken ct)
    {
        var grant = await grants.FindByIdAsync(id, ct); if (grant is null) return null;
        var properties = await grants.GetPropertiesAsync(grant, ct);
        var client = await clients.FindByIdAsync((await grants.GetApplicationIdAsync(grant, ct))!, ct);
        return new(id, (await grants.GetSubjectAsync(grant, ct))!, properties["tenantId"].GetInt32(),
            (await clients.GetClientIdAsync(client!, ct))!, DateTimeOffset.MaxValue,
            await grants.GetStatusAsync(grant, ct) != OpenIddictConstants.Statuses.Valid,
            (await grants.GetScopesAsync(grant, ct)).ToHashSet(StringComparer.Ordinal));
    }
}
// Existing policies/domain checks remain authoritative for operations. This is
// only the OAuth app restriction over the SAME conventional catalogue snapshot.
public sealed class AgentBusinessPermissionReader : IBusinessPermissionReader
{
    public Task<bool> AllowsAsync(DelegatedIdentity identity, string application, string grant, CancellationToken ct) =>
        Task.FromResult(identity.Principal?.FindFirst("userCatalogs")?.Value.Split(',').Contains(application, StringComparer.OrdinalIgnoreCase) == true
            && identity.Scopes.Contains(AgentOAuthOptions.ApplicationScope(application)));
}
public sealed class AgentBusinessAudit(Microsoft.Extensions.Logging.ILogger<AgentBusinessAudit> logger) : IBusinessAuditWriter
{
    public Task WriteAsync(BusinessAudit record, CancellationToken ct)
    {
        logger.LogInformation("AgentCommand Owner={OwnerId} Tenant={TenantId} Client={ClientId} Application={Application} Operation={Operation} Outcome={Outcome} Status={Status} Correlation={CorrelationId}",
            record.Subject, record.TenantId, record.ClientId, record.Application, record.Operation, record.Outcome, record.HttpStatus, record.CorrelationId);
        return Task.CompletedTask;
    }
}

// The existing getMenu exchange maps Central identity to the application's local
// identity and opens the existing session. No artificial user or new login exists.
public sealed class AgentApplicationSender(HttpClient client, ICentralAgentIdentity identities,
    IMemoryCache cache, JwtSettings jwt) : IApplicationDelegationSender
{
    public async Task<HttpResponseMessage> SendAsync(DelegatedIdentity identity, string application, string grant,
        HttpRequestMessage request, CancellationToken ct)
    {
        if (identity.Principal is null || !identity.Scopes.Contains(AgentOAuthOptions.ApplicationScope(application)))
            throw new BusinessAccessException("insufficient_scope");
        var origin = request.RequestUri!.GetLeftPart(UriPartial.Authority);
        var expiry = DateTimeOffset.FromUnixTimeSeconds(long.Parse(identity.Principal.FindFirst("exp")!.Value));
        var cacheKey = ("agent-application-session", identity.DelegationId, identity.Subject, identity.TenantId, identity.ClientId,
            application, origin, identity.Principal.FindFirst("jti")?.Value);
        if (!cache.TryGetValue<string>(cacheKey, out var token))
        {
            var owner = await identities.ResolveAsync(int.Parse(identity.Subject), identity.TenantId, ct);
            if (owner is null || !owner.catalogos.Contains(application, StringComparer.OrdinalIgnoreCase))
                throw new BusinessAccessException("operation_not_allowed");
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, owner.UserId.ToString()), new(ClaimTypes.Email, owner.email),
                new("tenantId", owner.tenantId.ToString()), new("userCatalogs", application), new("userModules", string.Join(',', owner.modulos)),
                new("tokenOrigin", "Central"), new("application", "Central"), new("tenantDocument", owner.tenantDocument),
                new("tenantName", owner.tenantName), new("userName", owner.userName)
            };
            UsageRightClaims.AddTo(claims, UsageRightClaims.Read(owner.UsageRights));
            if (application != "Central")
            {
                using var session = new HttpRequestMessage(HttpMethod.Get, origin + "/yapi/getMenu");
                session.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Issue(claims, origin + "/yapi/getMenu", expiry));
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
                if (principal.FindFirst("tenantId")?.Value != identity.TenantId.ToString()
                    || principal.FindFirst("application")?.Value != application) throw new BusinessAccessException("destination_denied");
                // Returned getMenu tokens contain the application's local identity. Add
                // causal owner/client metadata; never carry the legacy Admin fallback.
                claims = principal.Claims.Where(c => c.Type is not ("aud" or "iss" or "exp" or "iat" or "nbf" or "role")
                    && c.Type != ClaimTypes.Role && !c.Type.StartsWith("oi_", StringComparison.Ordinal)).ToList();
                expiry = new[] { expiry, new DateTimeOffset(DateTime.SpecifyKind(validated.ValidTo, DateTimeKind.Utc)) }.Min();
            }
            claims.AddRange([new("owner_sub", identity.Subject), new("client_id", identity.ClientId),
                new("delegation_id", identity.DelegationId), new("token_kind", "delegated"), new("delegation_kind", "external_agent")]);
            token = Issue(claims, origin, expiry);
            cache.Set(cacheKey, token, expiry);
        }
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);
    }
    private string Issue(IEnumerable<Claim> claims, string audience, DateTimeOffset expiration) => new JwtSecurityTokenHandler().WriteToken(
        new JwtSecurityToken(audience: audience, claims: claims, expires: expiration.UtcDateTime,
            signingCredentials: new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey)), SecurityAlgorithms.HmacSha256)));
}
