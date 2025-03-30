using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.AgenteFinanceiroDePaciente
{
    public partial class AgenteFinanceiroDePacienteHubAgentReceiver : ReciverBase
    {

        private readonly object _menssage;

        public AgenteFinanceiroDePacienteHubAgentReceiver(object menssage)
        {
            _menssage = menssage;
        }

        protected override State Action(ICommand comand)
        {
            try
            {
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, e, comand);
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