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

namespace Comandos.Receivers.AgenteDeAgendamentoDePaciente
{
    public partial class AgenteDeAgendamentoDePacienteHubAgentReceiver : ReciverBase<ICommand,AgenteDeAgendamentoDePacienteHubAgentReceiver>
    {

		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;
        public AgenteDeAgendamentoDePacienteHubAgentReceiver(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
        }


        protected override async Task<State<AgenteDeAgendamentoDePacienteHubAgentReceiver>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
            try
            {
                return Success("OK", null);
            }
            catch (ReceiverException<AgenteDeAgendamentoDePacienteHubAgentReceiver> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
           private List<string> MenuDeAgendamento()
            {
                 return new List<string>() {
"AgendarNovoAtendimento","ConsultarAgendamentosExistentes","CancelarAgendamento"
                
                 };
            }
    }
public enum MenuDeAgendamento
{
    AgendarNovoAtendimento = 0,
    ConsultarAgendamentosExistentes = 1,
    CancelarAgendamento = 2,
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHubAgents