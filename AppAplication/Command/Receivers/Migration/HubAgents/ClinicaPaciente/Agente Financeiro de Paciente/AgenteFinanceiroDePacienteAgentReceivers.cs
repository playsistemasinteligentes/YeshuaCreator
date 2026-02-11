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

        private readonly object _menssage;

        public AgenteFinanceiroDePacienteHubAgentReceiver(object menssage)
        {
            _menssage = menssage;
        }

        protected override State<AgenteFinanceiroDePacienteHubAgentReceiver> Action(ICommand comand)
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