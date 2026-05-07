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

        public AgenteDeAgendamentoDePacienteHubAgentReceiver(
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
        }


        protected override State<AgenteDeAgendamentoDePacienteHubAgentReceiver> Action(ICommand comand)
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