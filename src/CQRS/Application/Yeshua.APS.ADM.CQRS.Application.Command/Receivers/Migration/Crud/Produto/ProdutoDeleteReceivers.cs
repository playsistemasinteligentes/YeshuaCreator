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
    public class DeleteProdutoReceiver : ReciverBase<ICommand, IProdutoEntity>
    {
        private readonly IProdutoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteProdutoReceiver(
            IProdutoWriteRepository repository,
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

        protected override async Task<State<IProdutoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ProdutoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteProduto", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteProdutoReceiver), commandName: "Command.Write.ProdutoCrudCommand");
                 var produto = new ProdutoFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.Descricao, c.Status, c.PRO_ESTOQUE_ATUAL, c.UNI_ID, c.PRO_FARDOS_POR_CAMADA, c.PRO_CAMADAS_POR_PALETE, c.PRO_TIPO_IDENTIFICACAO, c.PRO_GRUPO_PALETIZACAO, c.PRO_PECAS_POR_FARDO, c.PRO_ID_INTEGRACAO, c.PRO_ID_INTEGRACAO_ERP, c.GRP_ID, c.TEM_ID, c.PRO_LARGURA_PECA, c.PRO_COMPRIMENTO_PECA, c.PRO_ALTURA_PECA, c.PRO_LARGURA_EMBALADA, c.PRO_COMPRIMENTO_EMBALADA, c.PRO_ALTURA_EMBALADA, c.PRO_FRENTE, c.PRO_ROTACIONA_COMPRIMENTO, c.PRO_ROTACIONA_LARGURA, c.PRO_ROTACIONA_ALTURA, c.PRO_ESCALA_COR, c.PRO_SUB_ESCALA_COR, c.PRO_CUSTO_SUBIDA_ESCALA_COR, c.PRO_CUSTO_DECIDA_ESCALA_COR, c.TMP_TIPO_CARGA, c.PRO_TEMPO_CARREGAMENTO_UNITARIO, c.PRO_TEMPO_DESCARREGAMENTO_UNITARIO, c.PRO_PERCENTUAL_JANELA_EMBARQUE, c.PRO_TEMPO_PRODUCAO_CONJUNTO, c.PRO_PECAS_DA_PECA, c.PRO_TYPE, c.PRO_COLOR_HEXA, c.PRO_VINCOS_LARGURA, c.PRO_VINCOS_COMPRIMENTO, c.PRO_LARGURA_INTERNA, c.PRO_COMPRIMENTO_INTERNA, c.PRO_ALTURA_INTERNA, c.PRO_COD_DESENHO, c.PRO_FECHAMENTO, c.PRO_TIPO_LAP, c.PRO_TAMANHO_LAP, c.PRO_LAP_PROLONGADO, c.PRO_TAMANHO_LAP_PROLONG, c.PRO_ARRANJO_LARGURA, c.PRO_ARRANJO_COMPRIMENTO, c.PRO_FITILHOS_FARDO_LARG, c.PRO_FITILHOS_FARDO_COMP, c.PRO_FITILHOS_PALETE_LARG, c.PRO_FITILHOS_PALETE_COMP, c.PRO_FILME_PALETE, c.PRO_QTD_ESPELHO, c.PRO_CUSTO, c.PRO_AREA_LIQUIDA, c.PRO_PESO, c.PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, c.PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, c.PRO_IMG_LASTRO, c.ABN_ID, c.SEG_ID, c.PRO_RESINA, c.PRO_ENDURECEDOR_MIOLO, c.PRO_VINCOS_ONDULADEIRA, c.PRO_ADICIONAL_ABA_SUPERIOR, c.PRO_ADICIONAL_ABA_INFERIOR, c.PRO_PROMOVE_RESINA, c.PRO_PROMOVE_DE, c.PRO_PROMOVE_ATE, c.PRO_PROFUNDIDADE_VINCO, c.VIN_ID, c.PRO_PROMOVE_PRODUTO, c.PRO_TARA, c.PRO_COMPRESSAO, c.PRO_COD_BARRAS_CAIXA, c.CJN_ID, c.PRJ_ID, c.PRO_REFILE_LARGURA, c.PRO_REFILE_COMPRIMENTO, c.PRO_M2_PONTA, c.PRO_QTD_CORTES_PECA1, c.PRO_QTD_CORTES_PECA2, c.PRO_DIVISAO_MONTADA, c.PRO_SEGMENTO_A, c.PRO_SEGMENTO_B, c.PRO_SEGMENTO_C, c.PRO_SEGMENTO_D, c.PRO_SEGMENTO_E, c.PRO_SEGMENTO_F, c.PRO_SEGMENTO_G, c.PRO_SEGMENTO_H, c.PRO_SEGMENTO_I, c.PRO_QTD_GRAMPOS, c.PRO_AREA_REFILE_INTERNO, c.PRO_AREA_REFILE_EXTERNO, c.PRO_PESO_REFILE, c.PRO_ORELHA_INVERTIDA, c.PRO_ENDERECO, c.PRO_ID_VINCULADO, c.PRO_BATIDAS_PROXIMA_MANUTENCAO, c.PRO_ENTRADA_NA_MAQUINA, c.TDI_ID, c.PRO_QUEBRA_VINCO, c.PRO_LARGURA_FARDO, c.PRO_COMPRIMENTO_FARDO, c.PRO_ALTURA_FARDO, c.PRO_TIPO_CUSTO, c.PRO_GRUPO_CONTABIL, c.PRO_CLASSE_CUSTO_01, c.PRO_OBS_ALTERACAO, c.TIP_ID, c.PRO_PECAS_POR_VEICULO, c.PRO_DISTANCIA_ENTRE_VINCOS, c.PRO_DISTANCIA_ENTRE_VINCOS2, c.PRO_DISTANCIA_ENTRE_VINCOS3, c.PRO_OUT, c.PRO_ID_FACA, c.PRO_ID_CLICHE, c.PRO_ID_TINTA_01, c.PRO_ID_TINTA_02, c.PRO_ID_TINTA_03, c.PRO_ID_TINTA_04, c.PRO_ID_TINTA_05, c.PRO_ID_FORROSUP, c.PRO_ID_CANTONEIRA, c.PRO_ID_PALETE, c.PRO_ID_TAMPO, c.PRO_ID_FORROINF, c.PRO_ID_CHAPA, c.PRO_ID_COMPOSICAO, c.PRO_QUEBRA_VINCO_MAIOR, c.PRO_QUEBRA_VINCO_MENOR, c.CLI_ID);
                 var domainResult = ProdutoDomainBehavior.Apply(produto, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(produto);
                     return Success("OK", produto);
                 }
                 catch (Exception e)
                 {
                    return Error(e, produto);
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