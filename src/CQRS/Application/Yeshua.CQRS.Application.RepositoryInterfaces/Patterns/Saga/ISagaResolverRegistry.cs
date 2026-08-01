using Dominio.Patterns.Saga;
using Repositorio.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Patterns.Saga
{
    public interface ISagaResolverRegistry
    {
        ISagaHandlerResolver Resolve(SagaBase saga);
        SagaBase Map(ySagaDTO dto);

    }
}
