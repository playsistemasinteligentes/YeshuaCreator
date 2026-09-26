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
    public class DeleteMedidasTesteReceiver : ReciverBase<ICommand, IMedidasTesteEntity>
    {
        private readonly IMedidasTesteWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteMedidasTesteReceiver(
            IMedidasTesteWriteRepository repository,
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

        protected override Task<State<IMedidasTesteEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.MedidasTesteCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteMedidasTeste", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteMedidasTesteReceiver), commandName: "Command.Write.MedidasTesteCrudCommand");
                 var medidasteste = new MedidasTesteFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.MDT_ID, c.MDT_DESC, c.MDT_VALOR_ESPERADO, c.MDT_ENCONTRADO, c.UNI_ID);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", medidasteste.OperationalEntityId);
                 var domainResult = MedidasTesteDomainBehavior.Apply(medidasteste, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Delete(medidasteste);
                     return Task.FromResult(Success("OK", medidasteste));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, medidasteste));
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