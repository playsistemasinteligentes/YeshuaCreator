using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.CreateConta
{
    public partial class CreateContaHubAgentReceiver : ReciverBase
    {

        private readonly object _menssage;

        public CreateContaHubAgentReceiver(object menssage)
        {
            _menssage = menssage;
        }

        protected override State Action(ICommand comand)
        {
            try
            {
                return Success("OK", comand);
            }
            catch (ReceiverException e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHubAgents