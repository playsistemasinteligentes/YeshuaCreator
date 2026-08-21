// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeApplicationSagaWorker
// </yeshua>

using Command.Patterns.Command;
using IRepository.Read;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Patterns
{
    public class SagaInboxWorkerCommandHandler : ReciverBase<InputCommand, OutputCommand>
    {
        private readonly IySagaStepReadRepository _sagaStepReadRepository;

        public SagaInboxWorkerCommandHandler(
            IySagaStepReadRepository sagaStepReadRepository,
            IUnitOfWork unitOfWork,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _sagaStepReadRepository = sagaStepReadRepository;
        }

        protected override State<OutputCommand> Action(InputCommand command)
        {
            try
            {
                _sagaStepReadRepository.SetPendingApply();
                return Success("OK", null);
            }
            catch (ReceiverException<OutputCommand> ex)
            {
                return ex.State;
            }
            catch (Exception ex)
            {
                return Error(ex, default);
            }
        }
    }
}//Dominio.Schemas.CQRS.SourceCodeApplicationSagaWorker