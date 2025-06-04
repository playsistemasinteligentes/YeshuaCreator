using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.HubServiceMethod
{
    public partial class ContasLoginServiceMethodReceiver : ReciverBase
    {


        protected override State Action(ICommand comand)
        {
            try
            {
                 State retorno = Success("OK", comand);
                 if (comand is Command.Commands.ContasLoginServiceMethodCommand specificCommand)
                 CustomActionHook(ref retorno, specificCommand);
                 return retorno;
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
partial void CustomActionHook(ref State state, Command.Commands.ContasLoginServiceMethodCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHub