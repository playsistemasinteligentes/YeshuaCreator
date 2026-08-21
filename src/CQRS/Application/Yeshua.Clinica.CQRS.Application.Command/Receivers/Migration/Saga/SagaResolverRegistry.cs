// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Saga;
using RepositoryInterfaces.Patterns.Saga;
using Dominio.Patterns.Saga;
using Repositorio.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Command.Receivers.Migration.Saga
{
    public class SagaResolverRegistry : ISagaResolverRegistry
    {
        private readonly Dictionary<string, ISagaHandlerResolver> _resolverMap;
        private readonly Dictionary<string, Func<SagaBase>> _factoryMap;

        public SagaResolverRegistry(PsychologySessionInsightSagaHandlerResolver PsychologySessionInsightResolver)
        {
            _resolverMap = new Dictionary<string, ISagaHandlerResolver>
            {
                { nameof(PsychologySessionInsightSaga), PsychologySessionInsightResolver },
            };

            _factoryMap = new Dictionary<string, Func<SagaBase>>
            {
                { nameof(PsychologySessionInsightSaga), () => new PsychologySessionInsightSaga() },
            };
        }

        public ISagaHandlerResolver Resolve(SagaBase saga)
        {
            var key = saga.Type;

            if (!_resolverMap.TryGetValue(key, out var resolver))
                throw new Exception($"Resolver não encontrado para {key}");

            return resolver;
        }

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
            saga.SetCorrelationId(dto.correlationid);
            saga.SetStatus(dto.status);
            saga.Type = dto.type;
            saga.KeyCurrentStep = dto.keycurrentstep;
            saga.CreatedAt = dto.createdat;
            saga.CompletedAt = dto.completedat;
            saga.EntityType = dto.entitytype;
            saga.EntityId = dto.entityid;

            if (dto.Steps != null && dto.Steps.Any())
            {
                foreach (var step in saga.Steps)
                {
                    var dtoStep = dto.Steps.FirstOrDefault(s => s.stepkey == step.Key);

                    if (dtoStep == null)
                        continue;

                    step.Hydrate(dtoStep.id, dtoStep.status, dtoStep.correlationid, dtoStep.completedat, dtoStep.retrycount, dtoStep.payload);
                }
            }

            return saga;
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers