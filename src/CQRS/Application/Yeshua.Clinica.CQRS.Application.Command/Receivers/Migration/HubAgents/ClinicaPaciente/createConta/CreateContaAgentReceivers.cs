// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHubAgents
// </yeshua>

using Command.Write;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Comandos.Receivers.CreateConta
{
    public partial class CreateContaHubAgentReceiver : ReciverBase<ICommand,CreateContaHubAgentReceiver>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        public CreateContaHubAgentReceiver(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
        }


        protected override Task<State<CreateContaHubAgentReceiver>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                return Task.FromResult(Success("OK"));
            }
            catch (ReceiverException<CreateContaHubAgentReceiver> e)
            {
                return Task.FromResult(e.State);
            }
            catch (Exception e)
            {
                return Task.FromResult(Error(e));
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHubAgents