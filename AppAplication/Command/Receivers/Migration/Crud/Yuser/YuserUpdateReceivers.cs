using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateyUserReceiver : ReciverBase <IyUserEntity>
    {
        private readonly IyUserWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateyUserReceiver(IyUserWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyUserEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yUserCrudCommand c) 
             {    
                 var yuser = new yUserFactory(_logger).Create(c.Id, c.Nome, c.Email, c.Senha);
                 if (!yuser.isValidUpdate())
                     return ValidationError(yuser.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(yuser);
                     return Success("OK", yuser);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yuser);
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