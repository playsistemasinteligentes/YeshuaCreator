using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_UserPermitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateY_UserPermitionsReceiver : ReciverBase <Y_UserPermitionsEntity>
    {
        private readonly IY_UserPermitionsWriteRepository _repository;

        public UpdateY_UserPermitionsReceiver(IY_UserPermitionsWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<Y_UserPermitionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_UserPermitionsCrudCommand c) 
             {    
                 var y_userpermitions = new Y_UserPermitionsEntity(c.UserId, c.PermitionsId);
                 if (!y_userpermitions.isValidUpdate())
                     return ValidationError(y_userpermitions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(y_userpermitions);
                     return Success("OK", y_userpermitions);
                 }
                 catch (Exception e)
                 {
                    return Error(e, y_userpermitions);
                 }
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration