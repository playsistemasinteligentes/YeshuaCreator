using Command.Write;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.AgenteDeAgendamentoParaAdministrador
{
    public partial class AgenteDeAgendamentoParaAdministradorHubAgentReceiver : ReciverBase<ICommand,AgenteDeAgendamentoParaAdministradorHubAgentReceiver>
    {

        private readonly object _menssage;

        public AgenteDeAgendamentoParaAdministradorHubAgentReceiver(object menssage)
        {
            _menssage = menssage;
        }

        protected override State<AgenteDeAgendamentoParaAdministradorHubAgentReceiver> Action(ICommand comand)
        {
            try
            {
                return Success("OK", null);
            }
            catch (ReceiverException<AgenteDeAgendamentoParaAdministradorHubAgentReceiver> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
           private List<string> MenuAdministrativoDeAgendamentos()
            {
                 return new List<string>() {
"VerificarAgendamentosDoDia","AgendarAtendimentoParaPaciente","CancelarAgendamentoDePaciente"
                
                 };
            }
    }
public enum MenuAdministrativoDeAgendamentos
{
    VerificarAgendamentosDoDia = 0,
    AgendarAtendimentoParaPaciente = 1,
    CancelarAgendamentoDePaciente = 2,
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHubAgents