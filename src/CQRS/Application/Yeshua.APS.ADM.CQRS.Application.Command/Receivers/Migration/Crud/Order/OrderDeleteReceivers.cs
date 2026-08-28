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
    public class DeleteOrderReceiver : ReciverBase<ICommand, IOrderEntity>
    {
        private readonly IOrderWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteOrderReceiver(
            IOrderWriteRepository repository,
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

        protected override async Task<State<IOrderEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.OrderCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteOrder", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteOrderReceiver), commandName: "Command.Write.OrderCrudCommand");
                 var order = new OrderFactory(_logger, _domainTrackingPolicy).Create(context, c.ORD_ID, c.ORD_ID_RESERVA, c.ORD_ID_CONJUNTO, c.PRO_ID, c.PRO_ID_CONJUNTO, c.CLI_ID, c.ORD_PRECO_UNITARIO, c.ORD_QUANTIDADE, c.ORD_DATA_ENTREGA_DE, c.ORD_DATA_ENTREGA_ATE, c.ORD_TIPO, c.ORD_TOLERANCIA_MAIS, c.ORD_TOLERANCIA_MENOS, c.HASH_KEY, c.ORD_INICIO_JANELA_EMBARQUE, c.ORD_FIM_JANELA_EMBARQUE, c.ORD_EMBARQUE_ALVO, c.ORD_INICIO_GRUPO_PRODUTIVO, c.ORD_FIM_GRUPO_PRODUTIVO, c.ORD_PESO_UNITARIO, c.ORD_PESO_UNITARIO_BRUTO, c.ORD_M2_UNITARIO, c.ORD_MIT, c.CAR_TIPO_CARREGAMENTO, c.ORD_STATUS, c.ORD_TIPO_FRETE, c.ORD_ENDERECO_ENTREGA, c.ORD_BAIRRO_ENTREGA, c.UF_ID_ENTREGA, c.ORD_CEP_ENTREGA, c.MUN_ID_ENTREGA, c.ORD_REGIAO_ENTREGA, c.ORD_LARGURA, c.ORD_COMPRIMENTO, c.ORD_GRAMATURA, c.GRP_ID, c.ORD_ID_INTEGRACAO, c.ORD_OBSERVACAO_OTIMIZADOR, c.ORD_COR_FILA, c.ORD_PED_CLI, c.ORD_OP_INTEGRACAO, c.ORD_LOTE_PILOTO, c.ORD_PRIORIDADE, c.ORD_EMISSAO, c.REP_ID, c.ORD_RESINA, c.ORD_ENDURECEDOR_MIOLO, c.PRO_ID_INTEGRACAO_ERP, c.ORD_VINCOS_ONDULADEIRA, c.ORD_ERP_CUSTOS_FIXOS, c.ORD_ERP_CUSTOS_VARIAVEIS, c.ORD_ERP_DESPESAS_VAR_VENDA, c.ORD_ERP_IMPOSTOS, c.ORD_STATUS_PLANEJAMENTO, c.ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, c.ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, c.ORD_PROMOVE_DE, c.ORD_PROMOVE_ATE, c.ORD_TRAVA_COMPOSICAO, c.ORD_TRAVA_RESINA, c.ORD_PROMOVE_RESINA, c.ORD_LATITUDE_ENTREGA, c.ORD_LONGITUDE_ENTREGA, c.OCO_ID_CANCELAMENTO, c.TMP_TIPO_CARGA, c.PRO_ID_PALETE, c.PRO_ID_TAMPO, c.ORD_PILHAS_POR_PALETE, c.ORD_CHAPAS_POR_PILHA, c.ORD_DATA_CANCELAMENTO, c.ORD_STATUS_ESTATISTICA, c.ORD_DATA_ESTATISTICA, c.OCO_ID_MOTIVO_ATRASO, c.OTK_VERSSAO);
                 var domainResult = OrderDomainBehavior.Apply(order, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(order);
                     return Success("OK", order);
                 }
                 catch (Exception e)
                 {
                    return Error(e, order);
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