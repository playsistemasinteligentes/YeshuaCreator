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
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, e, comand);
            }
        }
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversHub