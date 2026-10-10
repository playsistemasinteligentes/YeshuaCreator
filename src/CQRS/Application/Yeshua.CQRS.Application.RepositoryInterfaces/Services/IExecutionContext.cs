using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Dominio.Operational;

namespace Aplication.Interfaces.Services
{
    public interface IExecutionContext
    {
        // Identidade
        int UserId { get; }
        int TenantID { get; }
        IEnumerable<Claim> Claims { get; }

        // Rastreio
        string TraceId { get; }
        ExecutionOrigin Origem { get; }
        string ProcessingScope { get; }
        OperationalExecutionIdentity OperationalIdentity =>
            OperationalExecutionIdentity.FromTrace(TraceId);
        bool TryGetOperationalIdentity(out OperationalExecutionIdentity identity)
        {
            identity = OperationalIdentity;
            return true;
        }

        // Mutação de contexto
        void SetTenantId(int id);
        void SetUserId(int id);
        void SetTraceId(string traceId);
        void SetOrigem(ExecutionOrigin origem);
        IDisposable BeginOperationalExecution(
            string operation,
            string? operationId = null,
            string? causationId = null) =>
            EmptyOperationalExecutionScope.Instance;
        IDisposable BeginOperationalExecution(
            OperationalExecutionIdentity parentIdentity,
            string operation,
            bool continueOperation = true) =>
            EmptyOperationalExecutionScope.Instance;
        void SetOperationalIdentity(
            string rootOperationId,
            string? causationId = null)
        {
        }
    }

    internal sealed class EmptyOperationalExecutionScope : IDisposable
    {
        public static readonly EmptyOperationalExecutionScope Instance = new();

        private EmptyOperationalExecutionScope()
        {
        }

        public void Dispose()
        {
        }
    }

    public enum ExecutionOrigin
    {
        Http,
        Worker,
        Scheduler
    }
}


