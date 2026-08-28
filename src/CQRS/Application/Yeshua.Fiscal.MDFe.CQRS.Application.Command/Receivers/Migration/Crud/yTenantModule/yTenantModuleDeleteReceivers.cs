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
    public class DeleteyTenantModuleReceiver : ReciverBase<ICommand, IyTenantModuleEntity>
    {
        private readonly IyTenantModuleWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteyTenantModuleReceiver(
            IyTenantModuleWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override async Task<State<IyTenantModuleEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.yTenantModuleCrudCommand c) 
             {    
                 var ytenantmodule = new yTenantModuleFactory(_logger).Create(c.Id, c.ModuleId, c.ValidUntil);
                 if (!ytenantmodule.isValidDelete())
                     return ValidationError(ytenantmodule.getErroMensagens(), null);

                 try
                 {
                     _repository.Delete(ytenantmodule);
                     return Success("OK", ytenantmodule);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ytenantmodule);
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