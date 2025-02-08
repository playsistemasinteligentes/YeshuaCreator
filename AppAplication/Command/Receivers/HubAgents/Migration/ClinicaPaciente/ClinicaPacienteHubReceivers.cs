using Comandos.Pateners.Command;
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

        private readonly object _menssage;

        public ClinicaPacienteHubReceiver(object menssage)
        {
            _menssage = menssage;
        }

        protected override State Action(ICommand comand)
        {
            try
            {
                Agent = getAgent(comand);
                comand = Agent.getMenu(comand);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
    }
}
