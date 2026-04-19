using Dominio.Patterns.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Patterns.Saga
{
    public interface ISagaStepHandler
    {
        string Key { get; }     // 🔑 casa com o step.Key
        bool IsAsync { get; }

        void Execute(SagaBase saga, SagaStepBase step);
    }
}
