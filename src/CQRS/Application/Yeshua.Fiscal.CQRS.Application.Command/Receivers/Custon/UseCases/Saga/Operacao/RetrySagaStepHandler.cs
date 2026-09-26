// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// </yeshua>

using Command.UseCase;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class RetrySagaStepHandler
    {
        private const int SagaInProgress = 1;
        private const int StepPending = 1;
        private const int StepFailed = 6;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IySagaReadRepository _sagaReadRepository;
        private readonly IySagaStepReadRepository _sagaStepReadRepository;
        private readonly IySagaWriteRepository _sagaWriteRepository;
        private readonly IySagaStepWriteRepository _sagaStepWriteRepository;

        public RetrySagaStepHandler(
            IUnitOfWork unitOfWork,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext executionContext,
            IySagaReadRepository sagaReadRepository,
            IySagaStepReadRepository sagaStepReadRepository,
            IySagaWriteRepository sagaWriteRepository,
            IySagaStepWriteRepository sagaStepWriteRepository)
            : base(logger, executionContext)
        {
            _unitOfWork = unitOfWork;
            _sagaReadRepository = sagaReadRepository;
            _sagaStepReadRepository = sagaStepReadRepository;
            _sagaWriteRepository = sagaWriteRepository;
            _sagaStepWriteRepository = sagaStepWriteRepository;
        }

        protected partial Task<State<RetrySagaStepOutputCommand>> CustomActionHookAsync(
            State<RetrySagaStepOutputCommand> state,
            RetrySagaStepInputCommand command,
            CancellationToken cancellationToken)
        {
            if (command.SagaId <= 0 || command.SagaStepId <= 0)
                return Task.FromResult(ValidationError("Informe a saga e o step que sera repetido."));

            var saga = _sagaReadRepository.FirstById(command.SagaId);
            var step = _sagaStepReadRepository.FirstById(command.SagaStepId);

            if (saga == null || saga.id <= 0 || step == null || step.id <= 0 || step.sagaid != saga.id)
                return Task.FromResult(ValidationError("Saga ou step nao encontrado."));

            if (step.status != StepFailed)
                return Task.FromResult(ValidationError("Somente um step falho pode ser executado novamente."));

            _unitOfWork.BeginTran();
            try
            {
                _sagaStepWriteRepository.UpdateStatus(step.id, StepPending);
                _sagaStepWriteRepository.UpdateRetryCount(step.id, 0);
                _sagaStepWriteRepository.UpdateErrorMessage(step.id, string.Empty);
                _sagaWriteRepository.UpdateStatus(saga.id, SagaInProgress);
                _sagaWriteRepository.UpdateKeyCurrentStep(saga.id, step.stepkey);
                _sagaWriteRepository.UpdateNextExecutionAt(saga.id, DateTime.UtcNow);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }

            return Task.FromResult(Success("Step liberado para nova tentativa.", new RetrySagaStepOutputCommand
            {
                SagaId = saga.id,
                SagaStepId = step.id,
                StepKey = step.stepkey,
                Status = "Pendente"
            }));
        }
    }
}
