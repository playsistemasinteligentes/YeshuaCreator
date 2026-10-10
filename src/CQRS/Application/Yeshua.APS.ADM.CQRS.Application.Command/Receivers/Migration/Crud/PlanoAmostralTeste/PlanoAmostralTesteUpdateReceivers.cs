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
    public class UpdatePlanoAmostralTesteReceiver : ReciverBase<ICommand, IPlanoAmostralTesteEntity>
    {
        private readonly IPlanoAmostralTesteWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdatePlanoAmostralTesteReceiver(
            IPlanoAmostralTesteWriteRepository repository,
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

        protected override Task<State<IPlanoAmostralTesteEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.PlanoAmostralTesteCrudCommand c) 
             {    
                 var trackingMask = _domainTrackingPolicy.GetMask("PlanoAmostralTeste", "UpdatePlanoAmostralTeste", null);
                 var hasExecutionIdentity = _executionContext.TryGetOperationalIdentity(out var executionIdentity);
                 using var domainTrackingExecutionScope = !hasExecutionIdentity && trackingMask != 0UL ? _executionContext.BeginOperationalExecution("Command.Write.PlanoAmostralTesteCrudCommand") : null;
                 if (!hasExecutionIdentity && trackingMask != 0UL)
                     executionIdentity = _executionContext.OperationalIdentity;
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdatePlanoAmostralTeste", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdatePlanoAmostralTesteReceiver), commandName: "Command.Write.PlanoAmostralTesteCrudCommand", rootOperationId: executionIdentity.RootOperationId, operationId: executionIdentity.OperationId, executionId: executionIdentity.ExecutionId, causationId: executionIdentity.CausationId);
                 var planoamostralteste = new PlanoAmostralTesteFactory(_logger, _domainTrackingPolicy).Create(context, c.GRP_TIPO, c.PAT_ID, c.PAT_QTD_CAIXAS_DE, c.PAT_QTD_CAIXAS_ATE, c.PAT_N_AMOSTRAGEM, c.PAT_PERCENT_ESPECIF, trackingMask: trackingMask);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", planoamostralteste.OperationalEntityId);
                 var domainResult = PlanoAmostralTesteDomainBehavior.Apply(planoamostralteste, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Update(planoamostralteste);
                     return Task.FromResult(Success("OK", planoamostralteste));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, planoamostralteste));
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