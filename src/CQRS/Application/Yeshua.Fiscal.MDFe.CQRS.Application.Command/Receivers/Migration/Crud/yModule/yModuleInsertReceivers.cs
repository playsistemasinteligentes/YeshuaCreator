using System.Threading;
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
    public class InsertyModuleReceiver : ReciverBase<ICommand, IyModuleEntity>
    {
        private readonly IyModuleWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertyModuleReceiver(
            IyModuleWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override async Task<State<IyModuleEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.yModuleCrudCommand c) 
             {    
                 var ymodule = new yModuleFactory(_logger).Create(c.Id, c.Description);
                 if (!ymodule.isValidInsert())
                     return ValidationError(ymodule.getErroMensagens(), null);

                 try
                 {
                     _repository.Insert(ymodule);
                     return Success("OK", ymodule);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ymodule);
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