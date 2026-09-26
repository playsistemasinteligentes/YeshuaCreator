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
    public class DeleteRegistrosOnduladeiraReceiver : ReciverBase<ICommand, IRegistrosOnduladeiraEntity>
    {
        private readonly IRegistrosOnduladeiraWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteRegistrosOnduladeiraReceiver(
            IRegistrosOnduladeiraWriteRepository repository,
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

        protected override Task<State<IRegistrosOnduladeiraEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.RegistrosOnduladeiraCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteRegistrosOnduladeira", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteRegistrosOnduladeiraReceiver), commandName: "Command.Write.RegistrosOnduladeiraCrudCommand");
                 var registrosonduladeira = new RegistrosOnduladeiraFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.REG_ID, c.REG_RESPOSTA, c.REG_STATUS, c.REG_DATA_INICIO);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", registrosonduladeira.OperationalEntityId);
                 var domainResult = RegistrosOnduladeiraDomainBehavior.Apply(registrosonduladeira, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Delete(registrosonduladeira);
                     return Task.FromResult(Success("OK", registrosonduladeira));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, registrosonduladeira));
                 }
            }
            else 
            {
                 return Task.FromResult(Error("ErroConversao"));
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration