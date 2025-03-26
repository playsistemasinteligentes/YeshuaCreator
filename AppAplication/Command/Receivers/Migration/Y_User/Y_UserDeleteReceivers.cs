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
    public class DeleteY_UserReceiver : ReciverBase
    {
        private readonly IY_UserWriteRepository _repository;

        public DeleteY_UserReceiver(IY_UserWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_UserCrudCommand c) 
             {    
                 var y_user = new Y_UserEntity(c.Id, c.Nome, c.Email, c.Senha);
                 if (!y_user.isValidDelete())
                     return new State(300, y_user.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(y_user);
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