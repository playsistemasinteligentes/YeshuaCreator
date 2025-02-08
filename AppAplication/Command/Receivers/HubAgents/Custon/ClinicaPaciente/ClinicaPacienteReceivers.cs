using Comandos.Pateners.Command;
using Comandos.Receivers.AgenteFinanceiroParaAdministrador;
using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.ClinicaPaciente
{
    public partial class ClinicaPacienteHubReceiver : ReciverBase
    {
        private ReciverBase GetAgent(ICommand comand)
        {
            return new AgenteFinanceiroParaAdministradorHubAgentReceiver(comand);
        }
    }
}
