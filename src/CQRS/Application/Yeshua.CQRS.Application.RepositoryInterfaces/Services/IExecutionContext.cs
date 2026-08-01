using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

        // Mutação de contexto
        void SetTenantId(int id);
        void SetUserId(int id);
        void SetTraceId(string traceId);
        void SetOrigem(ExecutionOrigin origem);
    }

    public enum ExecutionOrigin
    {
        Http,
        Worker,
        Scheduler
    }
}


