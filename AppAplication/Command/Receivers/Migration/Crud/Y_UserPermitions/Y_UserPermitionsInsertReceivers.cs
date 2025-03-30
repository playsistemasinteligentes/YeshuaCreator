using Comandos.Pateners.Command;
using Dominio.Entitys.Y_UserPermitions;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_UserPermitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertY_UserPermitionsReceiver : ReciverBase
    {
        private readonly IY_UserPermitionsWriteRepository _repository;

        public InsertY_UserPermitionsReceiver(IY_UserPermitionsWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_UserPermitionsCrudCommand c) 
             {    
                 var y_userpermitions = new Y_UserPermitionsEntity(c.UserId, c.PermitionsId);
                 if (!y_userpermitions.isValidInsert())
                     return new State(300, y_userpermitions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(y_userpermitions);
                     return new State(200, "OK", comand);
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