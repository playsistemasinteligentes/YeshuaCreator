using System.Threading;
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
using System.Threading.Tasks;

namespace Comandos.Receivers.AgenteFinanceiroDePaciente
{
    public partial class AgenteFinanceiroDePacienteHubAgentReceiver : ReciverBase<ICommand,AgenteFinanceiroDePacienteHubAgentReceiver>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        public AgenteFinanceiroDePacienteHubAgentReceiver(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
        }


        protected override async Task<State<AgenteFinanceiroDePacienteHubAgentReceiver>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                return Success("OK", null);
            }
            catch (ReceiverException<AgenteFinanceiroDePacienteHubAgentReceiver> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
           private List<string> MenuFinanceiro()
            {
                 return new List<string>() {
"VerificarSaldo","HistóricoDeTransações","RealizarPagamentoDeServiço"
                
                 };
            }
    }
public enum MenuFinanceiro
{
    VerificarSaldo = 0,
    HistóricoDeTransações = 1,
    RealizarPagamentoDeServiço = 2,
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHubAgents