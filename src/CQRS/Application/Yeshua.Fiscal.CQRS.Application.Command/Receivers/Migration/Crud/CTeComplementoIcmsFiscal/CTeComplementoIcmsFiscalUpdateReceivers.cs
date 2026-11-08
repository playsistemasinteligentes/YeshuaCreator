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
    public class UpdateCTeComplementoIcmsFiscalReceiver : ReciverBase<ICommand, ICTeComplementoIcmsFiscalEntity>
    {
        private readonly ICTeComplementoIcmsFiscalWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateCTeComplementoIcmsFiscalReceiver(
            ICTeComplementoIcmsFiscalWriteRepository repository,
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

        protected override Task<State<ICTeComplementoIcmsFiscalEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CTeComplementoIcmsFiscalCrudCommand c) 
             {    
                 var trackingMask = _domainTrackingPolicy.GetMask("CTeComplementoIcmsFiscal", "UpdateCTeComplementoIcmsFiscal", null);
                 var hasExecutionIdentity = _executionContext.TryGetOperationalIdentity(out var executionIdentity);
                 using var domainTrackingExecutionScope = !hasExecutionIdentity && trackingMask != 0UL ? _executionContext.BeginOperationalExecution("Command.Write.CTeComplementoIcmsFiscalCrudCommand") : null;
                 if (!hasExecutionIdentity && trackingMask != 0UL)
                     executionIdentity = _executionContext.OperationalIdentity;
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateCTeComplementoIcmsFiscal", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateCTeComplementoIcmsFiscalReceiver), commandName: "Command.Write.CTeComplementoIcmsFiscalCrudCommand", rootOperationId: executionIdentity.RootOperationId, operationId: executionIdentity.OperationId, executionId: executionIdentity.ExecutionId, causationId: executionIdentity.CausationId);
                 var ctecomplementoicmsfiscal = new CTeComplementoIcmsFiscalFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CTeSolicitacaoFiscalId, c.ValorPrestacaoComplementar, c.CST, c.ValorBaseCalculo, c.AliquotaICMS, c.ValorICMS, trackingMask: trackingMask);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", ctecomplementoicmsfiscal.OperationalEntityId);
                 var domainResult = CTeComplementoIcmsFiscalDomainBehavior.Apply(ctecomplementoicmsfiscal, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Update(ctecomplementoicmsfiscal);
                     return Task.FromResult(Success("OK", ctecomplementoicmsfiscal));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, ctecomplementoicmsfiscal));
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