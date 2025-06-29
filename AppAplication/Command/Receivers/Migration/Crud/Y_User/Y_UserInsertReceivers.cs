using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Y_User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertY_UserReceiver : ReciverBase <IY_UserEntity>
    {
        private readonly IY_UserWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertY_UserReceiver(IY_UserWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IY_UserEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_UserCrudCommand c) 
             {    
                 var y_user = new Y_UserFactory(_logger).Create(c.Id, c.Nome, c.Email, c.Senha, c.TenantID);
                 if (!y_user.isValidInsert())
                     return ValidationError(y_user.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(y_user);
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