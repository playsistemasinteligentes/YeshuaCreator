using Comandos.Pateners.Command;
using Dominio.Entitys.Y_User;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertY_UserReceiver : ReciverBase
    {
        private readonly IY_UserWriteRepository _repository;

        public InsertY_UserReceiver(IY_UserWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_UserCrudCommand c) 
             {    
                 var y_user = new Y_UserEntity(c.Id, c.Nome, c.Email, c.Senha);
                 if (!y_user.isValidInsert())
                     return ValidationError(y_user.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(y_user);
                     return Success("OK", y_user);
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