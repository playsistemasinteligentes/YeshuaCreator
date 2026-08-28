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
    public class DeleteyTenantReceiver : ReciverBase<ICommand, IyTenantEntity>
    {
        private readonly IyTenantWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteyTenantReceiver(
            IyTenantWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override async Task<State<IyTenantEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.yTenantCrudCommand c) 
             {    
                 var ytenant = new yTenantFactory(_logger).Create(c.CnpjCpf, c.Nome, c.UserId);
                 if (!ytenant.isValidDelete())
                     return ValidationError(ytenant.getErroMensagens(), null);

                 try
                 {
                     _repository.Delete(ytenant);
                     return Success("OK", ytenant);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ytenant);
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