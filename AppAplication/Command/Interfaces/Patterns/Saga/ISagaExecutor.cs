using Dominio.Patterns.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryInterfaces.Patterns.Saga;

namespace Command.Interfaces
{
    public interface ISagaExecutor
    {
        void Execute(SagaBase saga, ISagaHandlerResolver resolver);
        //void ApplyResponsee(SagaBase saga, ISagaHandlerResolver resolver, string payload);
    }
}
