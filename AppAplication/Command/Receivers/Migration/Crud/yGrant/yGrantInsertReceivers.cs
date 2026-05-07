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
    public class InsertyGrantReceiver : ReciverBase<ICommand, IyGrantEntity>
    {
        private readonly IyGrantWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertyGrantReceiver(
            IyGrantWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyGrantEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yGrantCrudCommand c) 
             {    
                 var ygrant = new yGrantFactory(_logger).Create(c.Id, c.Description);
                 if (!ygrant.isValidInsert())
                     return ValidationError(ygrant.getErroMensagens(), null);

                 try
                 {
                     _repository.Insert(ygrant);
                     return Success("OK", ygrant);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ygrant);
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