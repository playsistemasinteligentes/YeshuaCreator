using Aplication.Interfaces.Services;
using System.Security.Claims;

namespace Shered.Services
{
    public class executionContextHttp : IExecutionContext
    {
        private int? _manualTenantId;

        private readonly IHttpContextAccessor _http;
        private readonly string _processingScope;

        public executionContextHttp(IHttpContextAccessor http, IConfiguration configuration)
        {
            _http = http;
            _processingScope = GetRequiredProcessingScope(configuration);
        }

        public int TenantID => _manualTenantId ?? GetTenantId();

        public int UserId => int.Parse(_http.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        public IEnumerable<Claim> Claims => _http.HttpContext?.User?.Claims ?? Enumerable.Empty<Claim>();

        public int GetTenantId()
        {

            var claim = _http.HttpContext?.User?.FindFirst("tenantId");
            if (claim == null) return 0;
            return int.TryParse(claim.Value, out var id) ? id : 0;
        }

        // =========================
        // NOVOS CAMPOS
        // =========================
        private int? _manualUserId;
        private string? _manualTraceId;
        private ExecutionOrigin? _manualOrigem;

        // =========================
        // NOVAS PROPRIEDADES
        // =========================
        public string TraceId =>
            _manualTraceId ??
            _http.HttpContext?.TraceIdentifier ??
            Guid.NewGuid().ToString("N");

        public ExecutionOrigin Origem =>
            _manualOrigem ??
            (_http.HttpContext != null ? ExecutionOrigin.Http : ExecutionOrigin.Worker);

        public string ProcessingScope => _processingScope;

        /// <summary>
        /// ⚠️ Método temporário para setar o TenantID manualmente.
        /// Use com extrema cautela e remova assim que possível.
        /// </summary>
        public void SetTenantId(int id)
        {
            _manualTenantId = id;
        }

        // =========================
        // NOVOS MÉTODOS
        // =========================
        public void SetUserId(int id)
        {
            _manualUserId = id;
        }

        public void SetTraceId(string traceId)
        {
            _manualTraceId = traceId;
        }

        public void SetOrigem(ExecutionOrigin origem)
        {
            _manualOrigem = origem;
        }

        private static string GetRequiredProcessingScope(IConfiguration configuration)
        {
            var scope = configuration["YeshuaProcessing:Scope"]?.Trim();
            return !string.IsNullOrWhiteSpace(scope)
                ? scope
                : throw new InvalidOperationException("YeshuaProcessing:Scope nao foi configurado.");
        }
    }
}
