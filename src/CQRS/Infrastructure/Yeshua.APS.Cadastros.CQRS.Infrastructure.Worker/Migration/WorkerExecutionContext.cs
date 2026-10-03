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
    private readonly string _processingScope;

    public WorkerExecutionContext(IConfiguration configuration)
    {
        _tenantId = GetWorkerTenantId(configuration);
        _userId = GetWorkerUserId(configuration);
        _processingScope = GetRequiredProcessingScope(configuration);
    }

    public int UserId => _userId;
    public int TenantID => _tenantId;
    public string TraceId => _traceId;
    public string ProcessingScope => _processingScope;
    public ExecutionOrigin Origem => _origin;
    public IEnumerable<Claim> Claims => Enumerable.Empty<Claim>();

    public void SetTenantId(int id) => _tenantId = id;
    public void SetUserId(int id) => _userId = id;
    public void SetTraceId(string traceId) => _traceId = traceId;
    public void SetOrigem(ExecutionOrigin origem) => _origin = origem;

    private static int GetWorkerTenantId(IConfiguration configuration)
    {
        return configuration.GetValue("WorkerExecutionContext:TenantID", 1);
    }

    private static int GetWorkerUserId(IConfiguration configuration)
    {
        return configuration.GetValue("WorkerExecutionContext:UserId", 1);
    }

    private static string GetRequiredProcessingScope(IConfiguration configuration)
    {
        var scope = configuration["YeshuaProcessing:Scope"]?.Trim();
        return !string.IsNullOrWhiteSpace(scope)
            ? scope
            : throw new InvalidOperationException("YeshuaProcessing:Scope nao foi configurado.");
    }
}
