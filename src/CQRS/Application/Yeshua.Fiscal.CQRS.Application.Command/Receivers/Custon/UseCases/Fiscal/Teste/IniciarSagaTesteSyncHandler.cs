// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

//scope;
using Aplication.Interfaces.Services;
using Command.Interfaces;
using Command.Receivers.Migration.Saga;
using Command.UseCase;
using Dominio.Interfaces;
using Dominio.Saga;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Write;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class IniciarSagaTesteSyncHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IySagaWriteRepository _sagaWriteRepository;
        private readonly ISagaExecutor _sagaExecutor;
        private readonly SagaResolverRegistry _sagaResolverRegistry;

        public IniciarSagaTesteSyncHandler(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IExecutionContext executionContext,
            IySagaWriteRepository sagaWriteRepository,
            ISagaExecutor sagaExecutor,
            SagaResolverRegistry sagaResolverRegistry)
            : base(logger, executionContext)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _executionContext = executionContext;
            _sagaWriteRepository = sagaWriteRepository;
            _sagaExecutor = sagaExecutor;
            _sagaResolverRegistry = sagaResolverRegistry;
        }

        protected partial Task<State<IniciarSagaTesteSyncOutputCommand>> CustomActionHookAsync(
            State<IniciarSagaTesteSyncOutputCommand> state,
            IniciarSagaTesteSyncInputCommand comand,
            CancellationToken cancellationToken)
        {
            var correlationId = string.IsNullOrWhiteSpace(comand.CorrelationId)
                ? Guid.NewGuid().ToString()
                : comand.CorrelationId;
            var entityId = string.IsNullOrWhiteSpace(comand.EntityId)
                ? "TESTE-SYNC-" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff")
                : comand.EntityId;

            if (comand.TenantId > 0)
                _executionContext.SetTenantId(comand.TenantId);
            _executionContext.SetTraceId(correlationId);

            var saga = new TesteSyncSaga
            {
                CreatedAt = DateTime.UtcNow,
                NextExecutionAt = DateTime.UtcNow,
                LockedAt = DateTime.MinValue,
                LockedBy = null
            };

            saga.SetCorrelationId(correlationId);
            saga.Start(entityId, "TesteSync");

            var resolver = _sagaResolverRegistry.Resolve(saga);
            _sagaExecutor.ExecuteUntilWait(saga, resolver);

            _unitOfWork.BeginTran();
            try
            {
                _sagaWriteRepository.Save(saga);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }

            return Task.FromResult(Success("OK", new IniciarSagaTesteSyncOutputCommand
            {
                CorrelationId = correlationId,
                SagaId = saga.Id,
                EntityId = entityId,
                Status = "Executada",
                Mensagem = "Saga TesteSync executada ate o fim ou ate o primeiro wait."
            }));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
