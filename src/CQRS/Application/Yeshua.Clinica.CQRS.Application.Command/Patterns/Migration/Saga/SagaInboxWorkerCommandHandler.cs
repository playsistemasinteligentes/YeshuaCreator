using System.Threading.Tasks;
using System.Threading;
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
using RepositoryInterfaces.Patterns.Worker;

namespace Command.Patterns
{
    public class SagaInboxWorkerCommandHandler : ReciverBase<InputCommand, InboxOutputCommand>
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

        protected override async Task<State<InboxOutputCommand>> ActionAsync(InputCommand command, CancellationToken cancellationToken = default)
        {
            try
            {
                var processed = _sagaStepReadRepository.SetPendingApply();
                return Success("OK", new InboxOutputCommand
                {
                    Claimed = processed,
                    Processed = processed
                });
            }
            catch (ReceiverException<InboxOutputCommand> ex)
            {
                return ex.State;
            }
            catch (Exception ex)
            {
                return Error(ex, default);
            }
        }
    }

    public partial record InboxOutputCommand : ICommand, IWorkerCycleResult
    {
        public int BatchLimit => 0;
        public int Claimed { get; init; }
        public int Processed { get; init; }
        public int Failed { get; init; }
    }

}//Dominio.Schemas.CQRS.SourceCodeApplicationSagaWorker