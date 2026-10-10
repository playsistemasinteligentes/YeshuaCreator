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
    public class DeleteItemTestavelReceiver : ReciverBase<ICommand, IItemTestavelEntity>
    {
        private readonly IItemTestavelWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteItemTestavelReceiver(
            IItemTestavelWriteRepository repository,
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

        protected override Task<State<IItemTestavelEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ItemTestavelCrudCommand c) 
             {    
                 var trackingMask = _domainTrackingPolicy.GetMask("ItemTestavel", "DeleteItemTestavel", null);
                 var hasExecutionIdentity = _executionContext.TryGetOperationalIdentity(out var executionIdentity);
                 using var domainTrackingExecutionScope = !hasExecutionIdentity && trackingMask != 0UL ? _executionContext.BeginOperationalExecution("Command.Write.ItemTestavelCrudCommand") : null;
                 if (!hasExecutionIdentity && trackingMask != 0UL)
                     executionIdentity = _executionContext.OperationalIdentity;
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteItemTestavel", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteItemTestavelReceiver), commandName: "Command.Write.ItemTestavelCrudCommand", rootOperationId: executionIdentity.RootOperationId, operationId: executionIdentity.OperationId, executionId: executionIdentity.ExecutionId, causationId: executionIdentity.CausationId);
                 var itemtestavel = new ItemTestavelFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.ITE_ID, c.ITE_DESCRICAO, c.ITE_OBS, c.ITE_NUMERO_DE_TESTES, c.ITE_CONDICIONAL_DE_AVALIACAO, c.ITE_VALOR_DA_CONDICIONAL, c.ITE_VALOR_CALCULADO_DA_CONDICIONAL, c.ITE_TIPO_AVALIACAO_FINAL, trackingMask: trackingMask);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", itemtestavel.OperationalEntityId);
                 var domainResult = ItemTestavelDomainBehavior.Apply(itemtestavel, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Delete(itemtestavel);
                     return Task.FromResult(Success("OK", itemtestavel));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, itemtestavel));
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