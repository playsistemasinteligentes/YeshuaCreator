// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration
// </yeshua>

using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Behaviors;
using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Domain;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteyTenantModuleReceiver : ReciverBase<ICommand, IyTenantModuleEntity>
    {
        private readonly IyTenantModuleWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteyTenantModuleReceiver(
            IyTenantModuleWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Dominio.Interfaces.IDomainTrackingPolicy domainTrackingPolicy,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _domainTrackingPolicy = domainTrackingPolicy;
            _executionContext = context;
        }

        protected override async Task<State<IyTenantModuleEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.yTenantModuleCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteyTenantModule", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteyTenantModuleReceiver), commandName: "Command.Write.yTenantModuleCrudCommand");
                 var ytenantmodule = new yTenantModuleFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.ModuleId, c.ValidUntil);
                 var domainResult = yTenantModuleDomainBehavior.Apply(ytenantmodule, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

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