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
                     return ValidationError(y_userpermitions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(y_userpermitions);
                     return Success("OK", y_userpermitions);
                 }
                 catch (Exception e)
                 {
                     return Error(e, comand);
                 }
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration