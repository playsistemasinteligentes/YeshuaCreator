// pendencia: definir a geracao compartilhada deste repository interno para todos os aplicativos do Studio.
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
        private readonly IySagaReadRepository _sagaReadRepository;
        private readonly ILogger _logger;

        public ySagaWriteRepository(
            IUnitOfWork unitOfWork,
            IySagaQueryWrite query,
            IySagaStepWriteRepository stepRepository,
            IySagaReadRepository readRepository,
            ILogger logger)
        {
            _UnitOfWork = unitOfWork;
            _query = query;
            _stepWriteRepository = stepRepository;
            _sagaReadRepository = readRepository;
            _logger = logger;
        }

        public void Save(SagaBase saga)
        {
            if (saga == null)
                throw new ArgumentNullException(nameof(saga));

            var sagaEntity = MapSaga(saga);
            // =========================================
            // SAGA
            // =========================================

            if (saga.Id == 0)
            {
                if (!sagaEntity.isValidInsert())
                    throw new Exception(string.Join(", ", sagaEntity.getErroMensagens()));
                Insert(sagaEntity);
                saga.Id = (int) sagaEntity.Id;
            }
            else if (saga.IsDirty)
            {
                if (!sagaEntity.isValidUpdate())
                    throw new Exception(string.Join(", ", sagaEntity.getErroMensagens()));

                Update(sagaEntity);
            }
            // =========================================
            // STEPS
            // =========================================

            foreach (var step in saga.Steps)
            {
                step.SagaId = (int) sagaEntity.Id;
                var stepEntity = MapStep(step, step.SagaId);
                
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
        // =========================================
        // HELPERS
        // =========================================

        private IySagaEntity MapSaga(SagaBase saga)
        {
            var entity = new ySagaFactory(_logger).Create(saga.Id == 0 ? null : saga.Id,
                saga.CorrelationId.ToString(), saga.Type, (int)saga.Status, saga.KeyCurrentStep,
                saga.CreatedAt.Year < 1800 ? DateTime.UtcNow : saga.CreatedAt,
                saga.Status == SagaStatus.Completed ? saga.CompletedAt : null,
                saga.EntityType, saga.EntityId,
                saga.NextExecutionAt.Year < 1800 ? DateTime.UtcNow : saga.NextExecutionAt,
                string.IsNullOrWhiteSpace(saga.LockedBy) ? null : saga.LockedAt, saga.LockedBy);
            entity.RootOperationId = saga.RootOperationId;
            entity.OperationId = saga.OperationId;
            entity.ExecutionId = saga.ExecutionId;
            entity.CausationId = saga.CausationId;
            return entity;
        }

        private IySagaStepEntity MapStep(SagaStepBase step , int sagaId)
        {
            var entity = new ySagaStepFactory(_logger).Create(step.Id, sagaId, step.Key, step.Order, step.CorrelationId, (int)step.Status, step.ExecutionCount, step.LastExecutionAt, step.CompletedAt, step.ErrorMessage, step.Payload, step.RetryCount);
            entity.RootOperationId = step.RootOperationId;
            entity.OperationId = step.OperationId;
            entity.ExecutionId = step.ExecutionId;
            entity.CausationId = step.CausationId;
            return entity;
        }

    }
}
