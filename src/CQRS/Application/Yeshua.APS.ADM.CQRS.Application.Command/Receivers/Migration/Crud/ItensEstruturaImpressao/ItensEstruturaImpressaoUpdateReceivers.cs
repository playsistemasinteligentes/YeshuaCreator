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
    public class UpdateItensEstruturaImpressaoReceiver : ReciverBase<ICommand, IItensEstruturaImpressaoEntity>
    {
        private readonly IItensEstruturaImpressaoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateItensEstruturaImpressaoReceiver(
            IItensEstruturaImpressaoWriteRepository repository,
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

        protected override Task<State<IItensEstruturaImpressaoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ItensEstruturaImpressaoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateItensEstruturaImpressao", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateItensEstruturaImpressaoReceiver), commandName: "Command.Write.ItensEstruturaImpressaoCrudCommand");
                 var itensestruturaimpressao = new ItensEstruturaImpressaoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.IES_CUSTOM_FONT_SIZE);
                 System.Diagnostics.Activity.Current?.SetTag("yeshua.operational_entity_id", itensestruturaimpressao.OperationalEntityId);
                 var domainResult = ItensEstruturaImpressaoDomainBehavior.Apply(itensestruturaimpressao, context);
                 if (!domainResult.IsValid)
                     return Task.FromResult(ValidationError(domainResult.Errors));

                 try
                 {
                     _repository.Update(itensestruturaimpressao);
                     return Task.FromResult(Success("OK", itensestruturaimpressao));
                 }
                 catch (Exception e)
                 {
                    return Task.FromResult(Error(e, itensestruturaimpressao));
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