using System.Net.Http.Headers;
using Central.BusinessMcp;

namespace Central.AgentOAuth;

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

// No identity/grant repository, cache, session exchange or introspection exists
// in this path. The only outbound call delivers the actual business Command.
public sealed class AgentApplicationSender(HttpClient client, AgentApplicationCredentials credentials) : IApplicationDelegationSender
{
    public Task<HttpResponseMessage> SendAsync(DelegatedIdentity identity, string application, string grant,
        HttpRequestMessage request, CancellationToken ct)
    {
        var origin = request.RequestUri!.GetLeftPart(UriPartial.Authority);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", credentials.Select(identity, application, origin));
        return client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);
    }
}
