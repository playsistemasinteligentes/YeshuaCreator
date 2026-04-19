using Dominio.Patterns.Saga;
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
    }
}
