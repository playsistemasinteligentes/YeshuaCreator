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
    public class InsertyUserReceiver : ReciverBase<ICommand, IyUserEntity>
    {
        private readonly IyUserWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertyUserReceiver(
            IyUserWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyUserEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yUserCrudCommand c) 
             {    
                 var yuser = new yUserFactory(_logger).Create(c.Id, c.Nome, c.Email, c.Senha);
                 if (!yuser.isValidInsert())
                     return ValidationError(yuser.getErroMensagens(), null);

                 try
                 {
                     _repository.Insert(yuser);
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