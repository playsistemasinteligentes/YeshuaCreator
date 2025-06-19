using Command.Commands;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.HubServiceMethod
{
    public partial class ContasLoginServiceMethodReceiver : ReciverBase<ContasLoginServiceMethodCommand>
    {


        protected override State<ContasLoginServiceMethodCommand> Action(ICommand comand)
        {
            try
            {
                 State<ContasLoginServiceMethodCommand> retorno = Success("OK", (ContasLoginServiceMethodCommand)comand);
                 if (comand is Command.Commands.ContasLoginServiceMethodCommand specificCommand)
                 CustomActionHook(ref retorno, specificCommand);
                 return retorno;
            }
            catch (ReceiverException<ContasLoginServiceMethodCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<ContasLoginServiceMethodCommand> state, Command.Commands.ContasLoginServiceMethodCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHub