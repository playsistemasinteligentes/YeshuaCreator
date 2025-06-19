using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Y_User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateY_UserReceiver : ReciverBase <Y_UserEntity>
    {
        private readonly IY_UserWriteRepository _repository;

        public UpdateY_UserReceiver(IY_UserWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<Y_UserEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_UserCrudCommand c) 
             {    
                 var y_user = new Y_UserEntity(c.Id, c.Nome, c.Email, c.Senha);
                 if (!y_user.isValidUpdate())
                     return ValidationError(y_user.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(y_user);
                     return Success("OK", y_user);
                 }
                 catch (Exception e)
                 {
                    return Error(e, y_user);
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