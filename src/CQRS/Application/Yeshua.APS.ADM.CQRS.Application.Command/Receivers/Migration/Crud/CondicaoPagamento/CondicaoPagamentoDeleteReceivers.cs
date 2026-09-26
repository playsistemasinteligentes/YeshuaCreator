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
    public class DeleteCondicaoPagamentoReceiver : ReciverBase<ICommand, ICondicaoPagamentoEntity>
    {
        private readonly ICondicaoPagamentoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteCondicaoPagamentoReceiver(
            ICondicaoPagamentoWriteRepository repository,
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

        protected override Task<State<ICondicaoPagamentoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.CondicaoPagamentoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteCondicaoPagamento", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteCondicaoPagamentoReceiver), commandName: "Command.Write.CondicaoPagamentoCrudCommand");
                 var condicaopagamento = new CondicaoPagamentoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.CON_ID, c.CON_DESCRICAO, c.CON_PARCELAS, c.CON_VALOR_ACRECIMO, c.CON_INTEGRACAO_ERP);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", condicaopagamento.OperationalEntityId);
                 var domainResult = CondicaoPagamentoDomainBehavior.Apply(condicaopagamento, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Delete(condicaopagamento);
                     return Task.FromResult(Success("OK", condicaopagamento));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, condicaopagamento));
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