// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

// pendencia: mover esta infraestrutura interna de saga para geracao padrao da Engine.
using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using IQuery.Write;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System;
using System.Linq;

namespace Input.Repository.ySaga
{
    public partial class ySagaWriteRepository : IySagaWriteRepository
    {
        private readonly IySagaStepWriteRepository _stepWriteRepository;
        private readonly ILogger _logger;

        public ySagaWriteRepository(
            IUnitOfWork unitOfWork,
            IySagaQueryWrite query,
            IySagaStepWriteRepository stepWriteRepository,
            ILogger logger)
        {
            _UnitOfWork = unitOfWork;
            _query = query;
            _stepWriteRepository = stepWriteRepository;
            _logger = logger;
        }

        public void Save(SagaBase saga)
        {
            if (saga == null)
                throw new ArgumentNullException(nameof(saga));

            var sagaEntity = MapSaga(saga);
            if (saga.Id == 0)
            {
                if (!sagaEntity.isValidInsert())
                    throw new Exception(string.Join(", ", sagaEntity.getErroMensagens()));

                Insert(sagaEntity);
                saga.Id = sagaEntity.Id.GetValueOrDefault();
            }
            else if (saga.IsDirty)
            {
                if (!sagaEntity.isValidUpdate())
                    throw new Exception(string.Join(", ", sagaEntity.getErroMensagens()));

                Update(sagaEntity);
            }

            foreach (var step in saga.Steps.OrderBy(step => step.Order))
            {
                step.SagaId = saga.Id;
                var stepEntity = MapStep(step, saga.Id);

                if (step.IsNew)
                {
                    if (!stepEntity.isValidInsert())
                        throw new Exception(string.Join(", ", stepEntity.getErroMensagens()));

                    _stepWriteRepository.Insert(stepEntity);
                    step.Id = stepEntity.Id.GetValueOrDefault();
                    continue;
                }

                if (!step.IsDirty)
                    continue;

                if (!stepEntity.isValidUpdate())
                    throw new Exception(string.Join(", ", stepEntity.getErroMensagens()));

                _stepWriteRepository.Update(stepEntity);
            }

            saga.MarkPersisted();
        }

        private IySagaEntity MapSaga(SagaBase saga)
        {
            DateTime? completedAt = saga.Status == SagaStatus.Completed ? saga.CompletedAt : null;
            DateTime? nextExecutionAt = saga.NextExecutionAt >= new DateTime(1800, 1, 1)
                ? saga.NextExecutionAt
                : DateTime.UtcNow;
            DateTime? lockedAt = !string.IsNullOrWhiteSpace(saga.LockedBy)
                ? saga.LockedAt
                : null;

            return new ySagaFactory(_logger).Create(
                saga.Id == 0 ? null : saga.Id,
                saga.CorrelationId.ToString(),
                saga.Type,
                (int)saga.Status,
                saga.KeyCurrentStep,
                saga.CreatedAt >= new DateTime(1800, 1, 1) ? saga.CreatedAt : DateTime.UtcNow,
                completedAt,
                saga.EntityType,
                saga.EntityId,
                nextExecutionAt,
                lockedAt,
                saga.LockedBy);
        }

        private IySagaStepEntity MapStep(SagaStepBase step, int sagaId)
        {
            var lastExecutionAt = step.LastExecutionAt >= new DateTime(1800, 1, 1)
                ? step.LastExecutionAt
                : null;
            var completedAt = step.CompletedAt >= new DateTime(1800, 1, 1)
                ? step.CompletedAt
                : null;

            return new ySagaStepFactory(_logger).Create(
                step.Id == 0 ? null : step.Id,
                sagaId,
                step.Key,
                step.Order,
                step.CorrelationId,
                (int)step.Status,
                step.ExecutionCount,
                lastExecutionAt,
                completedAt,
                step.ErrorMessage,
                step.Payload,
                step.RetryCount);
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
