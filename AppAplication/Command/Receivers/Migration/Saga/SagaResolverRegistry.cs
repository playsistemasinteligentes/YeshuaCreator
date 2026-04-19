using Command.Receivers.Migration.Saga.PsychologySessionInsight;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using RepositoryInterfaces.Patterns.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Migration.Saga
{
    public class SagaResolverRegistry : ISagaResolverRegistry
    {
        private readonly Dictionary<Type, ISagaHandlerResolver> _map;

        public SagaResolverRegistry()
        {
            _map = new Dictionary<Type, ISagaHandlerResolver>
        {
            { typeof(PsychologySessionInsightSaga), new PsychologySessionInsightSagaHandlerResolver() }

            // 👉 quando criar novas sagas:
            // { typeof(OutraSaga), new OutraSagaResolver() }
        };
        }

        public ISagaHandlerResolver Resolve(SagaBase saga)
        {
            var type = saga.GetType();

            if (!_map.ContainsKey(type))
                throw new Exception($"Resolver não encontrado para {type.Name}");

            return _map[type];
        }
    }
}
