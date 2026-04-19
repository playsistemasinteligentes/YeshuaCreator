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

            if (saga.IsNew)
            {
                if (!sagaEntity.isValidInsert())
                    throw new Exception(string.Join(", ", sagaEntity.getErroMensagens()));
                Insert(sagaEntity);
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
                var stepEntity = MapStep(step, step.Id);
                
                if (step.IsNew)
                {
                    if (!stepEntity.isValidInsert())
                        throw new Exception(string.Join(", ", stepEntity.getErroMensagens()));
                    _stepWriteRepository.Insert(stepEntity);
                    continue;
                }

                if (!step.IsDirty)
                    continue;

                if (!stepEntity.isValidUpdate())
                    throw new Exception(string.Join(", ", stepEntity.getErroMensagens()));
                _stepWriteRepository.Update(stepEntity);
            }

            // =========================================
            // OUTBOX (continua regra de estado)
            // =========================================

            foreach (var step in saga.Steps)
            {
                if (step.Status == SagaStepStatus.WaitingResponse)
                    CreateOutbox(MapStep(step, step.Id));
            }
        }
        // =========================================
        // HELPERS
        // =========================================

        private IySagaEntity MapSaga(SagaBase saga)
        {
            return new ySagaFactory(_logger).Create(saga.Id, saga.SagaId.ToString(), saga.Type, (int)saga.Status, saga.KeyCurrentStep, saga.CreatedAt, saga.CompletedAt, saga.EntityType, saga.EntityId);
        }

        private ySagaStepEntity MapStep(SagaStepBase step, int sagaId)
        {
            var entity = new ySagaStepFactory(_logger).Create(step.Id, sagaId, step.Key, step.Order, (int)step.Status, step.ExecutionCount, step.LastExecutionAt, step.CompletedAt, step.ErrorMessage, step.Payload, step.RetryCount); 

            if (step.Status == SagaStepStatus.InProgress)
            {
                entity.ExecutionCount += 1;
            }

            if (step.Status == SagaStepStatus.Completed)
            {
                entity.CompletedAt = DateTime.UtcNow;
            }

            if (step.Status == SagaStepStatus.Failed)
            {
                entity.ErrorMessage = "Erro na execução do step";
            }

            return entity as ySagaStepEntity;
        }

        private void CreateOutbox(ySagaStepEntity step)
        {
            // placeholder
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration