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
    public class InsertyUserGrantReceiver : ReciverBase<ICommand, IyUserGrantEntity>
    {
        private readonly IyUserGrantWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertyUserGrantReceiver(
            IyUserGrantWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<IyUserGrantEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yUserGrantCrudCommand c) 
             {    
                 var yusergrant = new yUserGrantFactory(_logger).Create(c.Id, c.PerfilId, c.GrantId, c.CanGrant, c.CanCreate, c.CanRead, c.CanUpdate, c.CanDelete, c.ValidUntil);
                 if (!yusergrant.isValidInsert())
                     return ValidationError(yusergrant.getErroMensagens(), null);

                 try
                 {
                     _repository.Insert(yusergrant);
                     return Success("OK", yusergrant);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yusergrant);
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