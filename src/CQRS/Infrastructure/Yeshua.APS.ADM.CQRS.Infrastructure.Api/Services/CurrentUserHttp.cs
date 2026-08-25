using Aplication.Interfaces.Services;
using System.Security.Claims;

namespace Shered.Services;

public sealed class executionContextHttp : IExecutionContext
{
    private readonly IHttpContextAccessor _http;
    private readonly string _fallbackTraceId = Guid.NewGuid().ToString("N");
    private int? _manualTenantId;
    private int? _manualUserId;
    private string? _manualTraceId;
    private ExecutionOrigin? _manualOrigin;

    public executionContextHttp(IHttpContextAccessor http) => _http = http;

    public int TenantID => _manualTenantId ?? GetTenantId();
    public int UserId => _manualUserId ?? GetUserId();
    public IEnumerable<Claim> Claims => _http.HttpContext?.User?.Claims ?? Enumerable.Empty<Claim>();
    public string TraceId => _manualTraceId ?? _http.HttpContext?.TraceIdentifier ?? _fallbackTraceId;
    public ExecutionOrigin Origem =>
        _manualOrigin ?? (_http.HttpContext is null ? ExecutionOrigin.Worker : ExecutionOrigin.Http);

    public void SetTenantId(int id) => _manualTenantId = id;
    public void SetUserId(int id) => _manualUserId = id;
    public void SetTraceId(string traceId) => _manualTraceId = traceId;
    public void SetOrigem(ExecutionOrigin origem) => _manualOrigin = origem;

    private int GetTenantId() => GetIntClaim("tenantId");
    private int GetUserId() => GetIntClaim(ClaimTypes.NameIdentifier);

    private int GetIntClaim(string claimType)
    {
        var value = _http.HttpContext?.User?.FindFirst(claimType)?.Value;
        return int.TryParse(value, out var id) ? id : 0;
    }
}