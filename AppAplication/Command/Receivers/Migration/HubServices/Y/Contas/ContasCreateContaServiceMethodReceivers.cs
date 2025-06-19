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
    public partial class ContasCreateContaServiceMethodReceiver : ReciverBase<ContasCreateContaServiceMethodCommand>
    {


        protected override State<ContasCreateContaServiceMethodCommand> Action(ICommand comand)
        {
            try
            {
                 State<ContasCreateContaServiceMethodCommand> retorno = Success("OK", (ContasCreateContaServiceMethodCommand)comand);
                 if (comand is Command.Commands.ContasCreateContaServiceMethodCommand specificCommand)
                 CustomActionHook(ref retorno, specificCommand);
                 return retorno;
            }
            catch (ReceiverException<ContasCreateContaServiceMethodCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<ContasCreateContaServiceMethodCommand> state, Command.Commands.ContasCreateContaServiceMethodCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHub