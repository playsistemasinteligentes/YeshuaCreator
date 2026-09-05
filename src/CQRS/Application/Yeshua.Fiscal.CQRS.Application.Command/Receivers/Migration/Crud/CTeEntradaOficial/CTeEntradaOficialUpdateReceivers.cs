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
    public class UpdateCTeEntradaOficialReceiver : ReciverBase<ICommand, ICTeEntradaOficialEntity>
    {
        private readonly ICTeEntradaOficialWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateCTeEntradaOficialReceiver(
            ICTeEntradaOficialWriteRepository repository,
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

        protected override async Task<State<ICTeEntradaOficialEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CTeEntradaOficialCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateCTeEntradaOficial", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateCTeEntradaOficialReceiver), commandName: "Command.Write.CTeEntradaOficialCrudCommand");
                 var cteentradaoficial = new CTeEntradaOficialFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CorrelationId, c.SourceApplication, c.SourceModule, c.SourceMessageId, c.MessageType, c.MessageVersion, c.ReceivedAtUtc, c.PayloadHash, c.PayloadStorageKey, c.Status);
                 var domainResult = CTeEntradaOficialDomainBehavior.Apply(cteentradaoficial, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(cteentradaoficial);
                     return Success("OK", cteentradaoficial);
                 }
                 catch (Exception e)
                 {
                    return Error(e, cteentradaoficial);
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