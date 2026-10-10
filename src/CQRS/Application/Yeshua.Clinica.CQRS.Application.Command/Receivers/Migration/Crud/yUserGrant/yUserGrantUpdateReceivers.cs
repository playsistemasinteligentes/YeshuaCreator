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
    public class UpdateyUserGrantReceiver : ReciverBase<ICommand, IyUserGrantEntity>
    {
        private readonly IyUserGrantWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateyUserGrantReceiver(
            IyUserGrantWriteRepository repository,
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

        protected override Task<State<IyUserGrantEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.yUserGrantCrudCommand c) 
             {    
                 var trackingMask = _domainTrackingPolicy.GetMask("yUserGrant", "UpdateyUserGrant", null);
                 var hasExecutionIdentity = _executionContext.TryGetOperationalIdentity(out var executionIdentity);
                 using var domainTrackingExecutionScope = !hasExecutionIdentity && trackingMask != 0UL ? _executionContext.BeginOperationalExecution("Command.Write.yUserGrantCrudCommand") : null;
                 if (!hasExecutionIdentity && trackingMask != 0UL)
                     executionIdentity = _executionContext.OperationalIdentity;
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateyUserGrant", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateyUserGrantReceiver), commandName: "Command.Write.yUserGrantCrudCommand", rootOperationId: executionIdentity.RootOperationId, operationId: executionIdentity.OperationId, executionId: executionIdentity.ExecutionId, causationId: executionIdentity.CausationId);
                 var yusergrant = new yUserGrantFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.PerfilId, c.GrantId, c.CanGrant, c.CanCreate, c.CanRead, c.CanUpdate, c.CanDelete, c.ValidUntil, trackingMask: trackingMask);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", yusergrant.OperationalEntityId);
                 var domainResult = yUserGrantDomainBehavior.Apply(yusergrant, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Update(yusergrant);
                     return Task.FromResult(Success("OK", yusergrant));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, yusergrant));
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