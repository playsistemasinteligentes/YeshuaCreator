using Command.Commands;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.CreateConta
{
    public partial class CreateContaHubAgentReceiver : ReciverBase<ICommand>
    {

        private readonly object _menssage;

        public CreateContaHubAgentReceiver(object menssage)
        {
            _menssage = menssage;
        }

        protected override State<ICommand> Action(ICommand comand)
        {
            try
            {
                return Success("OK", comand);
            }
            catch (ReceiverException<ICommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHubAgents