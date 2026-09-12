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
using Command.UseCase;
using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class AcordarSagaTesteSyncPasso3Handler
    {
        private const int StepStatusWaiting = 3;
        private const string InboxType = "fiscal.teste-sync.step3-input.v1";

        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IySagaReadRepository _sagaReadRepository = default!;
        private readonly IySagaStepReadRepository _sagaStepReadRepository = default!;
        private readonly IyInboxWriteRepository _inboxWriteRepository = default!;

        public AcordarSagaTesteSyncPasso3Handler(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IExecutionContext executionContext,
            Command.Interfaces.ISagaStepInvoker sagaStepInvoker,
            IySagaReadRepository sagaReadRepository,
            IySagaStepReadRepository sagaStepReadRepository,
            IyInboxWriteRepository inboxWriteRepository)
            : base(logger, executionContext)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _executionContext = executionContext;
            _sagaStepInvoker = sagaStepInvoker;
            _sagaReadRepository = sagaReadRepository;
            _sagaStepReadRepository = sagaStepReadRepository;
            _inboxWriteRepository = inboxWriteRepository;
        }

        protected partial Task<State<AcordarSagaTesteSyncPasso3OutputCommand>> CustomActionHookAsync(State<AcordarSagaTesteSyncPasso3OutputCommand> state, AcordarSagaTesteSyncPasso3InputCommand comand, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var correlationId = (comand.CorrelationId ?? string.Empty).Trim();
            var entityId = (comand.EntityId ?? string.Empty).Trim();

            if (comand.TenantId > 0)
                _executionContext.SetTenantId(comand.TenantId);
            if (!string.IsNullOrWhiteSpace(correlationId))
                _executionContext.SetTraceId(correlationId);

            var saga = comand.SagaId > 0
                ? _sagaReadRepository.GetByIdWithSteps(comand.SagaId)
                : _sagaReadRepository.GetLatestByTypeEntity(nameof(TesteSyncSaga), "TesteSync", entityId, correlationId);

            if (saga == null || saga.id <= 0)
            {
                var output = BuildOutput(correlationId, entityId, 0, 0, 0, false, "Saga TesteSync nao encontrada.");
                return Task.FromResult(ValidationError(output.Mensagem, output));
            }

            var waitingStep = _sagaStepReadRepository.GetFirstBySagaStepKeyAndStatuses(
                saga.id,
                TesteSyncSaga.STEP_3,
                new[] { StepStatusWaiting });

            if (waitingStep == null || waitingStep.id <= 0)
            {
                var output = BuildOutput(
                    string.IsNullOrWhiteSpace(correlationId) ? saga.correlationid : correlationId,
                    string.IsNullOrWhiteSpace(entityId) ? saga.entityid : entityId,
                    saga.id,
                    0,
                    0,
                    false,
                    "Passo 3 da saga TesteSync nao esta aguardando estimulo.");

                return Task.FromResult(ValidationError(output.Mensagem, output));
            }

            var payload = JsonSerializer.Serialize(new
            {
                type = InboxType,
                correlationId = string.IsNullOrWhiteSpace(correlationId) ? saga.correlationid : correlationId,
                entityId = string.IsNullOrWhiteSpace(entityId) ? saga.entityid : entityId,
                stepKey = TesteSyncSaga.STEP_3,
                mensagem = comand.Mensagem ?? string.Empty,
                occurredAtUtc = DateTime.UtcNow
            });

            var inbox = new yInboxFactory(_logger).Create(
                null,
                Guid.NewGuid().ToString(),
                InboxType,
                "TesteSync",
                string.IsNullOrWhiteSpace(entityId) ? saga.entityid : entityId,
                waitingStep.correlationid,
                payload,
                0,
                DateTime.UtcNow,
                0,
                string.Empty,
                null,
                null,
                saga.id,
                waitingStep.id);

            _unitOfWork.BeginTran();
            try
            {
                _inboxWriteRepository.Insert(inbox);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }

            var accepted = BuildOutput(
                string.IsNullOrWhiteSpace(correlationId) ? saga.correlationid : correlationId,
                string.IsNullOrWhiteSpace(entityId) ? saga.entityid : entityId,
                saga.id,
                waitingStep.id,
                inbox.Id.GetValueOrDefault(),
                true,
                "Passo 3 acordado.");

            return Task.FromResult(Success("OK", accepted));
        }

        private static AcordarSagaTesteSyncPasso3OutputCommand BuildOutput(
            string correlationId,
            string entityId,
            int sagaId,
            int sagaStepId,
            int inboxId,
            bool accepted,
            string mensagem)
        {
            return new AcordarSagaTesteSyncPasso3OutputCommand
            {
                CorrelationId = correlationId,
                EntityId = entityId,
                StepKey = TesteSyncSaga.STEP_3,
                SagaId = sagaId,
                SagaStepId = sagaStepId,
                InboxId = inboxId,
                Accepted = accepted,
                Mensagem = mensagem
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
