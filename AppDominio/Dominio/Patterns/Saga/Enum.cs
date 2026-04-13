using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Patterns.Saga
{
    public enum SagaStatus
    {
        NotStarted,
        InProgress,
        Completed,
        Failed
    }

    public enum SagaStepStatus
    {
        Pending,
        InProgress,
        Completed,
        Failed
    }
}
