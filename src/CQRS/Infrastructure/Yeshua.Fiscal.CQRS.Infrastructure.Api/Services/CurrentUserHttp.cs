using Aplication.Interfaces.Services;
using Dominio.Operational;
using System.Security.Claims;

namespace Shered.Services;

public sealed class executionContextHttp : IExecutionContext
{
    private readonly IHttpContextAccessor _http;
    private readonly string _processingScope;
    private OperationalExecutionIdentityState? _operationalIdentity;
    private readonly string _fallbackTraceId = Guid.NewGuid().ToString("N");
    private int? _manualTenantId;
    private int? _manualUserId;
    private string? _manualTraceId;
    private ExecutionOrigin? _manualOrigin;

    public executionContextHttp(IHttpContextAccessor http, IConfiguration configuration)
    {
        _http = http;
        _processingScope = GetRequiredProcessingScope(configuration);
    }

    public int TenantID => _manualTenantId ?? GetTenantId();
    public int UserId => _manualUserId ?? GetUserId();
    public IEnumerable<Claim> Claims => _http.HttpContext?.User?.Claims ?? Enumerable.Empty<Claim>();
    public string TraceId => _manualTraceId ?? _http.HttpContext?.TraceIdentifier ?? _fallbackTraceId;
    public OperationalExecutionIdentity OperationalIdentity => GetOperationalIdentityState().Current;
    public bool TryGetOperationalIdentity(out OperationalExecutionIdentity identity)
    {
        var state = System.Threading.Volatile.Read(ref _operationalIdentity);
        if (state is null)
        {
            identity = default;
            return false;
        }

        return state.TryGetCurrent(out identity);
    }
    public string ProcessingScope => _processingScope;
    public ExecutionOrigin Origem =>
        _manualOrigin ?? (_http.HttpContext is null ? ExecutionOrigin.Worker : ExecutionOrigin.Http);

    public void SetTenantId(int id) => _manualTenantId = id;
    public void SetUserId(int id) => _manualUserId = id;
    public void SetTraceId(string traceId) => _manualTraceId = traceId;
    public void SetOrigem(ExecutionOrigin origem) => _manualOrigin = origem;
    public IDisposable BeginOperationalExecution(
        string operation,
        string? operationId = null,
        string? causationId = null)
    {
        var scope = GetOperationalIdentityState().Begin(operation, operationId, causationId);
        PublishOperationalIdentity();
        return scope;
    }
    public IDisposable BeginOperationalExecution(
        OperationalExecutionIdentity parentIdentity,
        string operation,
        bool continueOperation = true)
    {
        var scope = GetOperationalIdentityState().BeginFrom(
            parentIdentity,
            operation,
            continueOperation);
        PublishOperationalIdentity();
        return scope;
    }

    public void SetOperationalIdentity(
        string rootOperationId,
        string? causationId = null) =>
        GetOperationalIdentityState().Set(rootOperationId, causationId);

    private OperationalExecutionIdentityState GetOperationalIdentityState()
    {
        var current = System.Threading.Volatile.Read(ref _operationalIdentity);
        if (current is not null)
            return current;

        var created = new OperationalExecutionIdentityState(
            _http.HttpContext?.Request.Headers[OperationalExecutionHeaders.RootOperationId].ToString(),
            _http.HttpContext?.Request.Headers[OperationalExecutionHeaders.CausationId].ToString(),
            _http.HttpContext?.Request.Headers[OperationalExecutionHeaders.OperationId].ToString(),
            _http.HttpContext?.Request.Headers[OperationalExecutionHeaders.ExecutionId].ToString());
        return System.Threading.Interlocked.CompareExchange(
            ref _operationalIdentity,
            created,
            null) ?? created;
    }

    private int GetTenantId() => GetIntClaim("tenantId");
    private int GetUserId() => GetIntClaim(ClaimTypes.NameIdentifier);

    private void PublishOperationalIdentity()
    {
        var response = _http.HttpContext?.Response;
        if (response is null || response.HasStarted)
            return;

        var identity = OperationalIdentity;
        response.Headers[OperationalExecutionHeaders.RootOperationId] = identity.RootOperationId;
        response.Headers[OperationalExecutionHeaders.OperationId] = identity.OperationId;
        response.Headers[OperationalExecutionHeaders.ExecutionId] = identity.ExecutionId;
        if (!string.IsNullOrWhiteSpace(identity.CausationId))
            response.Headers[OperationalExecutionHeaders.CausationId] = identity.CausationId;
    }

    private int GetIntClaim(string claimType)
    {
        var value = _http.HttpContext?.User?.FindFirst(claimType)?.Value;
        return int.TryParse(value, out var id) ? id : 0;
    }

    private static string GetRequiredProcessingScope(IConfiguration configuration)
    {
        var scope = configuration["YeshuaProcessing:Scope"]?.Trim();
        return !string.IsNullOrWhiteSpace(scope)
            ? scope
            : throw new InvalidOperationException("YeshuaProcessing:Scope nao foi configurado.");
    }
}
