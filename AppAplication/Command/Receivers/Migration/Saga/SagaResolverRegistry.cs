using Command.Receivers.Migration.Saga.PsychologySessionInsight;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Saga;

namespace Command.Receivers.Migration.Saga
{
    public class SagaResolverRegistry : ISagaResolverRegistry
    {
        // 🔥 agora tudo por string
        private readonly Dictionary<string, ISagaHandlerResolver> _resolverMap;
        private readonly Dictionary<string, Func<SagaBase>> _factoryMap;

        public SagaResolverRegistry()
        {
            _resolverMap = new Dictionary<string, ISagaHandlerResolver>
            {
                { nameof(PsychologySessionInsightSaga), new PsychologySessionInsightSagaHandlerResolver() }
            };

            _factoryMap = new Dictionary<string, Func<SagaBase>>
            {
                { nameof(PsychologySessionInsightSaga), () => new PsychologySessionInsightSaga() }
            };
        }

        // 🔥 resolve handler
        public ISagaHandlerResolver Resolve(SagaBase saga)
        {
            var key = saga.Type; // 👈 usa o Type salvo

            if (!_resolverMap.TryGetValue(key, out var resolver))
                throw new Exception($"Resolver não encontrado para {key}");

            return resolver;
        }
        // 🔥 cria saga
        public SagaBase Create(string type)
        {
            if (!_factoryMap.TryGetValue(type, out var factory))
                throw new Exception($"Saga não registrada: {type}");

            return factory();
        }

        public SagaBase Map(ySagaDTO dto)
        {
            var saga = Create(dto.type);

            saga.Id = dto.id;
            saga.SetSagaId(dto.sagaid);
            saga.SetStatus(dto.status);
            saga.Type = dto.type;
            saga.KeyCurrentStep = dto.keycurrentstep;
            saga.CreatedAt = dto.createdat;
            saga.CompletedAt = dto.completedat;
            saga.EntityType = dto.entitytype;
            saga.EntityId = dto.entityid;

            // 🔥 hidrata steps
            if (dto.Steps != null && dto.Steps.Any())
            {
                foreach (var step in saga.Steps)
                {
                    var dtoStep = dto.Steps.FirstOrDefault(s => s.stepkey == step.Key);

                    if (dtoStep == null)
                        continue;

                    step.Hydrate(dtoStep.id,dtoStep.status,dtoStep.correlationid,dtoStep.completedat,dtoStep.retrycount);
                }
            }

            return saga;
        }
    }
}