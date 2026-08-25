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
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertyOutboxReceiver : ReciverBase<ICommand, IyOutboxEntity>
    {
        private readonly IyOutboxWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertyOutboxReceiver(
            IyOutboxWriteRepository repository,
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

        protected override State<IyOutboxEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yOutboxCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertyOutbox", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertyOutboxReceiver), commandName: "Command.Write.yOutboxCrudCommand");
                 var youtbox = new yOutboxFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.MessageId, c.Type, c.EntityType, c.EntityId, c.CorrelationId, c.Payload, c.Status, c.TransportType, c.TransportData, c.CreatedAt, c.SentAt, c.RetryCount, c.LastError, c.ProcessingAt, c.NextAttemptAt, c.SagaId, c.SagaStepId);
                 var domainResult = yOutboxDomainBehavior.Apply(youtbox, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(youtbox);
                     return Success("OK", youtbox);
                 }
                 catch (Exception e)
                 {
                    return Error(e, youtbox);
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