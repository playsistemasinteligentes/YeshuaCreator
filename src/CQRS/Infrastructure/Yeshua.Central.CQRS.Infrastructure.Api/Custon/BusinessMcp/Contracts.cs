using System.Security.Claims;
using System.Text.Json;

namespace Central.BusinessMcp;

// This module is intentionally opt-in. Production adapters must use the existing
// Central identity/catalogue repositories; a token claim is never a permission store.
public sealed record DelegatedIdentity(string Subject, int TenantId, string ClientId,
    string DelegationId, IReadOnlySet<string> Scopes)
{
    public ClaimsPrincipal? Principal { get; init; }
}
public sealed record DelegationValidationOptions(bool UseShortLivedTokenSnapshot = false);
public sealed record Delegation(string Id, string Subject, int TenantId, string ClientId,
    DateTimeOffset ExpiresAt, bool Revoked, IReadOnlySet<string> Scopes);
public interface IDelegationRepository
{
    Task<Delegation?> FindAsync(string id, CancellationToken cancellationToken);
}
public interface IBusinessPermissionReader
{
    Task<bool> AllowsAsync(DelegatedIdentity identity, string application, string grant,
        CancellationToken cancellationToken);
}
// Exposure is a trusted, reviewed projection of DSL authorization definitions, never
// client input or inference from Swagger visibility, menu presence, or the Admin role.
public sealed record BusinessExposure(string OperationId, string Grant, string Scope);
public sealed record BusinessOperation(string Application, string Id, string Description,
    JsonElement InputSchema, JsonElement OutputSchema);
public sealed record BusinessApplication(string Id);
public sealed record ExecuteBusinessOperation(string Application, string Operation, JsonElement Parameters);
public sealed record BusinessResult(string Outcome, string CorrelationId, int? HttpStatus = null,
    JsonElement? Data = null);
public sealed record BusinessAudit(string Subject, int TenantId, string ClientId, string Application,
    string Operation, string CorrelationId, string Outcome, int? HttpStatus);
public interface IBusinessAuditWriter
{
    Task WriteAsync(BusinessAudit audit, CancellationToken cancellationToken);
}
// Must obtain a *different*, audience-restricted credential through the approved
// delegation mechanism. The MCP bearer token must never cross this boundary.
public interface IApplicationDelegationSender
{
    Task<HttpResponseMessage> SendAsync(DelegatedIdentity identity, string application,
        string grant, HttpRequestMessage request, CancellationToken cancellationToken);
}
public sealed class BusinessAccessException(string code) : Exception(code);
