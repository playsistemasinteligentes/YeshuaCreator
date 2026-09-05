using Aplication.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Worker.Custon;

public sealed class WorkerExecutionContext : IExecutionContext
{
    private int _tenantId;
    private int _userId;
    private string _traceId = Guid.NewGuid().ToString("N");
    private ExecutionOrigin _origin = ExecutionOrigin.Worker;

    public WorkerExecutionContext(IConfiguration configuration)
    {
        _tenantId = configuration.GetValue("WorkerExecutionContext:TenantID", 1);
        _userId = configuration.GetValue("WorkerExecutionContext:UserId", 1);
    }

    public int UserId => _userId;
    public int TenantID => _tenantId;
    public string TraceId => _traceId;
    public ExecutionOrigin Origem => _origin;
    public IEnumerable<Claim> Claims => Enumerable.Empty<Claim>();

    public void SetTenantId(int id) => _tenantId = id;
    public void SetUserId(int id) => _userId = id;
    public void SetTraceId(string traceId) => _traceId = traceId;
    public void SetOrigem(ExecutionOrigin origem) => _origin = origem;
}
