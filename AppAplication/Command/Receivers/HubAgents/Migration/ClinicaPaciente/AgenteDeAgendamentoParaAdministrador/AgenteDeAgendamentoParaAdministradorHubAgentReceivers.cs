using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.AgenteDeAgendamentoParaAdministrador
{
    public partial class AgenteDeAgendamentoParaAdministradorHubAgentReceiver : ReciverBase
    {

        private readonly object _menssage;

        public AgenteDeAgendamentoParaAdministradorHubAgentReceiver(object menssage)
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
                return new State(500, "Erro", comand);
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
