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
    public class UpdateTempoSetupOnduladeiraReceiver : ReciverBase<ICommand, ITempoSetupOnduladeiraEntity>
    {
        private readonly ITempoSetupOnduladeiraWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateTempoSetupOnduladeiraReceiver(
            ITempoSetupOnduladeiraWriteRepository repository,
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

        protected override Task<State<ITempoSetupOnduladeiraEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.TempoSetupOnduladeiraCrudCommand c) 
             {    
                 var trackingMask = _domainTrackingPolicy.GetMask("TempoSetupOnduladeira", "UpdateTempoSetupOnduladeira", null);
                 var hasExecutionIdentity = _executionContext.TryGetOperationalIdentity(out var executionIdentity);
                 using var domainTrackingExecutionScope = !hasExecutionIdentity && trackingMask != 0UL ? _executionContext.BeginOperationalExecution("Command.Write.TempoSetupOnduladeiraCrudCommand") : null;
                 if (!hasExecutionIdentity && trackingMask != 0UL)
                     executionIdentity = _executionContext.OperationalIdentity;
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateTempoSetupOnduladeira", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateTempoSetupOnduladeiraReceiver), commandName: "Command.Write.TempoSetupOnduladeiraCrudCommand", rootOperationId: executionIdentity.RootOperationId, operationId: executionIdentity.OperationId, executionId: executionIdentity.ExecutionId, causationId: executionIdentity.CausationId);
                 var temposetuponduladeira = new TempoSetupOnduladeiraFactory(_logger, _domainTrackingPolicy).Create(context, c.TEM_ID, c.OND_ID_DE, c.OND_ID_PARA, c.TEM_RESINA_DE, c.TEM_RESINA_PARA, c.TEM_TEMPO, trackingMask: trackingMask);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", temposetuponduladeira.OperationalEntityId);
                 var domainResult = TempoSetupOnduladeiraDomainBehavior.Apply(temposetuponduladeira, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Update(temposetuponduladeira);
                     return Task.FromResult(Success("OK", temposetuponduladeira));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, temposetuponduladeira));
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