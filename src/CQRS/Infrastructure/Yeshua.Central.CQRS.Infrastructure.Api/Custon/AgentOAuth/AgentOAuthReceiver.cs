using System.Collections.Immutable;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;
using Command.UseCase;
using Dominio.Commercial;
using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Central.AgentOAuth;

public sealed record RevokeAgentGrant(string AuthorizationId);

// Protocol orchestration only; no SQL and no independent permission resolver.
public sealed class AgentOAuthReceiver(AgentOAuthOptions options, ICentralAgentIdentity identities,
    IOpenIddictApplicationManager clients, IOpenIddictAuthorizationManager grants,
    AgentApplicationPreparation applications, TimeProvider clock,
    Microsoft.Extensions.Logging.ILogger<AgentOAuthReceiver> logger)
{
    public async Task<ClaimsPrincipal?> AuthorizeAsync(string clientId, IEnumerable<string> requestedScopes,
        string username, string password, CancellationToken ct)
    {
        var owner = await identities.LoginAsync(username, password, ct);
        if (owner is null) return null;
        var scopes = requestedScopes.ToImmutableArray();
        if (!Allowed(owner, clientId, scopes)) return null;
        var client = await clients.FindByClientIdAsync(clientId, ct) ?? throw new InvalidOperationException("Unknown registered client.");
        var principal = Principal(owner, clientId, scopes);
        var descriptor = new OpenIddictAuthorizationDescriptor
        {
            ApplicationId = await clients.GetIdAsync(client, ct), Subject = owner.UserId.ToString(),
            Status = Statuses.Valid, Type = AuthorizationTypes.Permanent, CreationDate = DateTimeOffset.UtcNow
        };
        descriptor.Scopes.UnionWith(scopes);
        descriptor.Properties["tenantId"] = JsonSerializer.SerializeToElement(owner.tenantId);
        descriptor.Properties["kind"] = JsonSerializer.SerializeToElement("external_agent");
        var grant = await grants.CreateAsync(descriptor, ct);
        principal.SetAuthorizationId(await grants.GetIdAsync(grant, ct));
        principal.SetClaim("delegation_id", principal.GetAuthorizationId());
        SetDestinations(principal);
        Audit("consent_created", principal);
        return principal;
    }
    public async Task<ClaimsPrincipal?> RenewAsync(ClaimsPrincipal ticket, string clientId, CancellationToken ct)
    {
        if (!int.TryParse(ticket.GetClaim(Claims.Subject), out var ownerId)
            || !int.TryParse(ticket.GetClaim("tenantId"), out var tenantId)
            || ticket.GetClaim("client_id") != clientId || ticket.GetAuthorizationId() is not string id) return null;
        var grant = await grants.FindByIdAsync(id, ct);
        if (grant is null || await grants.GetStatusAsync(grant, ct) != Statuses.Valid
            || !await Owned(grant, ownerId, tenantId, ct)) return null;
        var owner = await identities.ResolveAsync(ownerId, tenantId, ct);
        if (owner is null || !Allowed(owner, clientId, ticket.GetScopes())) return null;
        // Rebuild from CURRENT conventional login data, not stale token grants.
        var fresh = Principal(owner, clientId, ticket.GetScopes());
        var principal = ticket.Clone();
        var identity = (ClaimsIdentity)principal.Identity!;
        foreach (var claim in identity.Claims.Where(c => !c.Type.StartsWith("oi_", StringComparison.Ordinal)).ToArray()) identity.RemoveClaim(claim);
        identity.AddClaims(fresh.Claims.Where(c => !c.Type.StartsWith("oi_", StringComparison.Ordinal)));
        principal.SetAuthorizationId(id);
        principal.SetClaim("delegation_id", id);
        try
        {
            var prepared = await applications.PrepareAsync(owner, clientId, id, principal.GetScopes().ToHashSet(StringComparer.Ordinal), ct);
            principal.SetClaim(AgentApplicationCredentials.ClaimType, prepared.ProtectedValue);
            var remaining = prepared.ExpiresAt - clock.GetUtcNow();
            if (remaining <= TimeSpan.Zero) return null;
            principal.SetAccessTokenLifetime(remaining);
        }
        catch (BusinessMcp.BusinessAccessException) { return null; }
        catch (HttpRequestException) { return null; }
        SetDestinations(principal);
        Audit("token_issued", principal);
        return principal;
    }
    public async Task<bool> RevokeAsync(RevokeAgentGrant command, int owner, int tenant, CancellationToken ct)
    {
        if (owner <= 0 || tenant <= 0 || command.AuthorizationId.Length > 100) return false;
        var grant = await grants.FindByIdAsync(command.AuthorizationId, ct);
        if (grant is null || !await Owned(grant, owner, tenant, ct)) return false;
        if (await grants.GetStatusAsync(grant, ct) == Statuses.Revoked) return true;
        if (!await grants.TryRevokeAsync(grant, ct)) return false;
        logger.LogInformation("AgentOAuth {Outcome} Owner={OwnerId} Tenant={TenantId} Delegation={DelegationId} Correlation={CorrelationId}",
            "consent_revoked", owner, tenant, command.AuthorizationId, Activity.Current?.TraceId.ToString());
        return true;
    }
    public async Task<IReadOnlyList<object>> ListAsync(int owner, int tenant, CancellationToken ct)
    {
        var result = new List<object>();
        await foreach (var grant in grants.FindBySubjectAsync(owner.ToString(), ct))
        {
            if (!await Owned(grant, owner, tenant, ct)) continue;
            var client = await clients.FindByIdAsync((await grants.GetApplicationIdAsync(grant, ct))!, ct);
            result.Add(new { id = await grants.GetIdAsync(grant, ct), clientId = client is null ? null : await clients.GetClientIdAsync(client, ct),
                scopes = await grants.GetScopesAsync(grant, ct), status = await grants.GetStatusAsync(grant, ct) });
            if (result.Count == 50) break;
        }
        return result;
    }
    private async Task<bool> Owned(object grant, int owner, int tenant, CancellationToken ct)
    {
        var properties = await grants.GetPropertiesAsync(grant, ct);
        return await grants.GetSubjectAsync(grant, ct) == owner.ToString()
            && properties.TryGetValue("tenantId", out var value) && value.GetInt32() == tenant
            && properties.TryGetValue("kind", out var kind) && kind.GetString() == "external_agent";
    }
    private bool Allowed(LoginOutputCommand owner, string clientId, IEnumerable<string> scopes)
    {
        var client = options.Clients.SingleOrDefault(c => c.ClientId == clientId);
        if (client is null || owner.UserId <= 0 || owner.tenantId <= 0) return false;
        var requested = scopes.ToArray();
        return requested.Contains("business:discover", StringComparer.Ordinal)
            && requested.All(scope => scope is "business:discover" or "offline_access" ||
                client.Applications.Any(app => AgentOAuthOptions.ApplicationScope(app) == scope
                    && owner.catalogos.Contains(app, StringComparer.OrdinalIgnoreCase)));
    }
    private ClaimsPrincipal Principal(LoginOutputCommand owner, string clientId, IEnumerable<string> scopes)
    {
        var identity = new ClaimsIdentity("AgentOAuth", Claims.Name, Claims.Role);
        identity.SetClaim(Claims.Subject, owner.UserId.ToString());
        identity.SetClaim(ClaimTypes.NameIdentifier, owner.UserId.ToString());
        identity.SetClaim("tenantId", owner.tenantId.ToString());
        identity.SetClaim("client_id", clientId);
        identity.SetClaim("owner_sub", owner.UserId.ToString());
        identity.SetClaim("token_kind", "delegated");
        identity.SetClaim("delegation_kind", "external_agent");
        // OAuth protocol constraints only narrow the existing application catalogue.
        var catalogs = owner.catalogos.Where(app => scopes.Contains(AgentOAuthOptions.ApplicationScope(app), StringComparer.Ordinal)).ToArray();
        identity.SetClaim("userCatalogs", string.Join(',', catalogs));
        identity.SetClaim("userModules", string.Join(',', owner.modulos));
        // Internal exchange data stays in encrypted code/refresh tickets, never in the access token.
        identity.SetClaim("email", owner.email); identity.SetClaim("userName", owner.userName);
        identity.SetClaim("tenantDocument", owner.tenantDocument); identity.SetClaim("tenantName", owner.tenantName);
        var rights = UsageRightClaims.Read(owner.UsageRights);
        var claims = new List<Claim>(); UsageRightClaims.AddTo(claims, rights); identity.AddClaims(claims);
        var principal = new ClaimsPrincipal(identity);
        principal.SetScopes(scopes); principal.SetResources(options.Resource); principal.SetPresenters(clientId);
        return principal;
    }
    private static void SetDestinations(ClaimsPrincipal principal) => principal.SetDestinations(claim =>
        claim.Type is "email" or "userName" or "tenantDocument" or "tenantName" ? [] : [Destinations.AccessToken]);
    private void Audit(string outcome, ClaimsPrincipal principal) => logger.LogInformation(
        "AgentOAuth {Outcome} Owner={OwnerId} Tenant={TenantId} Client={ClientId} Delegation={DelegationId} Correlation={CorrelationId}",
        outcome, principal.GetClaim(Claims.Subject), principal.GetClaim("tenantId"), principal.GetClaim("client_id"),
        principal.GetAuthorizationId(), Activity.Current?.TraceId.ToString());
}
