using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Central.BusinessMcp;

public sealed class DelegatedAccess(IDelegationRepository? repository, TimeProvider clock, DelegationValidationOptions? options = null)
{
    // Signature, issuer, audience and lifetime are checked by the dedicated bearer
    // scheme before this method. Agent OAuth uses only the signed snapshot.
    // The optional repository branch is retained for the standalone legacy module.
    public async Task<DelegatedIdentity> RequireAsync(ClaimsPrincipal principal, CancellationToken ct)
    {
        string? Claim(string name) => principal.FindFirst(name)?.Value;
        if (principal.Identity?.IsAuthenticated != true || Claim("token_kind") != "delegated"
            || string.IsNullOrWhiteSpace(Claim("sub")) || string.IsNullOrWhiteSpace(Claim("client_id"))
            || string.IsNullOrWhiteSpace(Claim("delegation_id"))
            || !int.TryParse(Claim("tenantId"), out var tenant) || tenant <= 0)
            throw new BusinessAccessException("invalid_token");
        if (options?.UseShortLivedTokenSnapshot == true)
        {
            if (!long.TryParse(Claim("exp"), out var expiration) || DateTimeOffset.FromUnixTimeSeconds(expiration) <= clock.GetUtcNow())
                throw new BusinessAccessException("invalid_token");
            return new(Claim("sub")!, tenant, Claim("client_id")!, Claim("delegation_id")!,
                (Claim("scope") ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries).ToHashSet(StringComparer.Ordinal)) { Principal = principal };
        }
        var delegation = repository is null ? null : await repository.FindAsync(Claim("delegation_id")!, ct);
        var scopes = (Claim("scope") ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries).ToHashSet(StringComparer.Ordinal);
        if (delegation is null || delegation.Revoked || delegation.ExpiresAt <= clock.GetUtcNow()
            || delegation.Subject != Claim("sub") || delegation.TenantId != tenant
            || delegation.ClientId != Claim("client_id") || !scopes.IsSubsetOf(delegation.Scopes))
            throw new BusinessAccessException("invalid_token");
        return new(delegation.Subject, tenant, delegation.ClientId, delegation.Id, scopes) { Principal = principal };
    }
}

public sealed record BusinessOAuthResource(Uri Resource, Uri Issuer)
{
    public const string Scheme = "CentralBusinessDelegation";
    public const string Policy = "CentralBusinessDelegation";
    public void Validate()
    {
        foreach (var uri in new[] { Resource, Issuer })
            if (!uri.IsAbsoluteUri || uri.Scheme != "https" || !string.IsNullOrEmpty(uri.UserInfo)
                || !string.IsNullOrEmpty(uri.Query) || !string.IsNullOrEmpty(uri.Fragment))
                throw new ArgumentException("OAuth resource and issuer must be fixed HTTPS URIs.");
    }
    public object Metadata() => new
    {
        resource = Resource.AbsoluteUri,
        authorization_servers = new[] { Issuer.AbsoluteUri },
        bearer_methods_supported = new[] { "header" },
        scopes_supported = new[] { "business:discover" }
    };
}
