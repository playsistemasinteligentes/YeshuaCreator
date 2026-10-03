using Aplication.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Worker.Custon
{
    public class WorkerExecutionContext : IExecutionContext
    {
        private int _tenantId = 1;
        private int _userId = 1;
        private string _traceId = Guid.NewGuid().ToString("N");
        private ExecutionOrigin _origem = ExecutionOrigin.Http;
        private readonly string _processingScope;

        public WorkerExecutionContext(IConfiguration configuration)
        {
            _processingScope = GetRequiredProcessingScope(configuration);
        }

        public int UserId => _userId;
        public int TenantID => _tenantId;
        public string TraceId => _traceId;
        public string ProcessingScope => _processingScope;
        public ExecutionOrigin Origem => _origem;
        public IEnumerable<Claim> Claims => Enumerable.Empty<Claim>();

        public void SetTenantId(int id) => _tenantId = id;
        public void SetUserId(int id) => _userId = id;
        public void SetTraceId(string traceId) => _traceId = traceId;
        public void SetOrigem(ExecutionOrigin origem) => _origem = origem;

        private static string GetRequiredProcessingScope(IConfiguration configuration)
        {
            var scope = configuration["YeshuaProcessing:Scope"]?.Trim();
            return !string.IsNullOrWhiteSpace(scope)
                ? scope
                : throw new InvalidOperationException("YeshuaProcessing:Scope nao foi configurado.");
        }
    }
}
