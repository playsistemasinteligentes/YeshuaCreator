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
    public class InsertItensOrcamentoReceiver : ReciverBase<ICommand, IItensOrcamentoEntity>
    {
        private readonly IItensOrcamentoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertItensOrcamentoReceiver(
            IItensOrcamentoWriteRepository repository,
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

        protected override async Task<State<IItensOrcamentoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ItensOrcamentoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertItensOrcamento", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertItensOrcamentoReceiver), commandName: "Command.Write.ItensOrcamentoCrudCommand");
                 var itensorcamento = new ItensOrcamentoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.ITO_ID, c.ORC_ID, c.TIP_ID, c.PRO_ID, c.ITO_OBS, c.ITO_QUANTIDADE, c.ITO_CUSTO, c.ITO_MARGEM, c.ITO_VALOR_UNITARIO, c.ITO_VERSSAO_CUSTO, c.ITO_STATUS, c.ITO_ERP_CUSTOS_FIXOS, c.ITO_ERP_CUSTOS_VARIAVEIS, c.ITO_ERP_DESPESAS_VAR_VENDA, c.ITO_ERP_IMPOSTOS, c.GRP_ID_COMPOSICAO, c.ITO_LARGURA, c.ITO_COMPRIMENTO);
                 var domainResult = ItensOrcamentoDomainBehavior.Apply(itensorcamento, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(itensorcamento);
                     return Success("OK", itensorcamento);
                 }
                 catch (Exception e)
                 {
                    return Error(e, itensorcamento);
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