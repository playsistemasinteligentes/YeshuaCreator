using Comandos.Pateners.Command;
using Dominio.Entitys.Y_Permtions;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_Permtions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateY_PermtionsReceiver : ReciverBase
    {
        private readonly IY_PermtionsWriteRepository _repository;

        public UpdateY_PermtionsReceiver(IY_PermtionsWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_PermtionsCrudCommand c) 
             {    
                 var y_permtions = new Y_PermtionsEntity(c.Id, c.Description);
                 if (!y_permtions.isValidUpdate())
                     return new State(300, y_permtions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(y_permtions);
                     return new State(200, "OK", y_permtions);
                 }
                 catch (Exception e)
                 {
                     return new State(500, e, comand);
                 }
            }
            else 
            {
                 return new State(500, "ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration