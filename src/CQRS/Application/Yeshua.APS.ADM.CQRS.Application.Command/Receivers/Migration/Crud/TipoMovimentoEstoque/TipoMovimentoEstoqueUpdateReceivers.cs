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
    public class UpdateTipoMovimentoEstoqueReceiver : ReciverBase<ICommand, ITipoMovimentoEstoqueEntity>
    {
        private readonly ITipoMovimentoEstoqueWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateTipoMovimentoEstoqueReceiver(
            ITipoMovimentoEstoqueWriteRepository repository,
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

        protected override async Task<State<ITipoMovimentoEstoqueEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.TipoMovimentoEstoqueCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateTipoMovimentoEstoque", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateTipoMovimentoEstoqueReceiver), commandName: "Command.Write.TipoMovimentoEstoqueCrudCommand");
                 var tipomovimentoestoque = new TipoMovimentoEstoqueFactory(_logger, _domainTrackingPolicy).Create(context, c.TIP_ID, c.TIP_DESCRICAO, c.TIP_TYPE, c.SPR);
                 var domainResult = TipoMovimentoEstoqueDomainBehavior.Apply(tipomovimentoestoque, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(tipomovimentoestoque);
                     return Success("OK", tipomovimentoestoque);
                 }
                 catch (Exception e)
                 {
                    return Error(e, tipomovimentoestoque);
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