using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.HubServiceMethod
{
    public partial class ContasCreateContaServiceMethodReceiver : ReciverBase
    {


        protected override State Action(ICommand comand)
        {
            try
            {
                State retorno = new State(200, "OK", comand);
                if (comand is Command.Commands.ContasCreateContaServiceMethodCommand specificCommand)
                    CustomActionHook(ref retorno, specificCommand);
                return retorno;
            }
            catch (Exception e)
            {
                return new State(500, e, comand);
            }
        }
        partial void CustomActionHook(ref State state, Command.Commands.ContasCreateContaServiceMethodCommand comand);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHub