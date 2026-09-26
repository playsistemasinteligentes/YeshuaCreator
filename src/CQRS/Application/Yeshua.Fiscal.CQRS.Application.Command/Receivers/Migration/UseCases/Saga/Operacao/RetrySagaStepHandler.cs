// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// </yeshua>

using Aplication.Interfaces.Services;
using Command.Patterns.Command;
using Command.UseCase;
using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class RetrySagaStepHandler : ReciverBase<RetrySagaStepInputCommand, RetrySagaStepOutputCommand>
    {
        public RetrySagaStepHandler(ILogger logger, IExecutionContext context)
            : base(logger, context)
        {
        }

        protected override async Task<State<RetrySagaStepOutputCommand>> ActionAsync(
            RetrySagaStepInputCommand command,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await CustomActionHookAsync(Success("OK"), command, cancellationToken);
            }
            catch (ReceiverException<RetrySagaStepOutputCommand> exception)
            {
                return exception.State;
            }
            catch (System.Exception exception)
            {
                return Error(exception);
            }
        }

        protected partial Task<State<RetrySagaStepOutputCommand>> CustomActionHookAsync(
            State<RetrySagaStepOutputCommand> state,
            RetrySagaStepInputCommand command,
            CancellationToken cancellationToken);
    }
}
