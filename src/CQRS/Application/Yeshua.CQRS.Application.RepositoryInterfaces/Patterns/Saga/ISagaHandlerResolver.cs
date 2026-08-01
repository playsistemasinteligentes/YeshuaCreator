using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Patterns.Saga
{
    public interface ISagaHandlerResolver
    {
        Dictionary<string, ISagaStepHandler> GetHandlers();
    }
}
