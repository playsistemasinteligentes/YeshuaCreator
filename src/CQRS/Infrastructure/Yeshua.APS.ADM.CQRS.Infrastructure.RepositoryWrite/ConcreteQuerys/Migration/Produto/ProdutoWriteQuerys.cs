// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class ProdutoQueryWrite : QueryBase, IProdutoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ProdutoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirProdutoQuery(IProdutoEntity Produto)
        {
            this.Query = $@" INSERT INTO Produto (Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID) VALUES(@Id, @Descricao, @Status, @TenantID, @Deleted, @Changed, @UserId, @PRO_ESTOQUE_ATUAL, @UNI_ID, @PRO_FARDOS_POR_CAMADA, @PRO_CAMADAS_POR_PALETE, @PRO_TIPO_IDENTIFICACAO, @PRO_GRUPO_PALETIZACAO, @PRO_PECAS_POR_FARDO, @PRO_ID_INTEGRACAO, @PRO_ID_INTEGRACAO_ERP, @GRP_ID, @TEM_ID, @PRO_LARGURA_PECA, @PRO_COMPRIMENTO_PECA, @PRO_ALTURA_PECA, @PRO_LARGURA_EMBALADA, @PRO_COMPRIMENTO_EMBALADA, @PRO_ALTURA_EMBALADA, @PRO_FRENTE, @PRO_ROTACIONA_COMPRIMENTO, @PRO_ROTACIONA_LARGURA, @PRO_ROTACIONA_ALTURA, @PRO_ESCALA_COR, @PRO_SUB_ESCALA_COR, @PRO_CUSTO_SUBIDA_ESCALA_COR, @PRO_CUSTO_DECIDA_ESCALA_COR, @TMP_TIPO_CARGA, @PRO_TEMPO_CARREGAMENTO_UNITARIO, @PRO_TEMPO_DESCARREGAMENTO_UNITARIO, @PRO_PERCENTUAL_JANELA_EMBARQUE, @PRO_TEMPO_PRODUCAO_CONJUNTO, @PRO_PECAS_DA_PECA, @PRO_TYPE, @PRO_COLOR_HEXA, @PRO_VINCOS_LARGURA, @PRO_VINCOS_COMPRIMENTO, @PRO_LARGURA_INTERNA, @PRO_COMPRIMENTO_INTERNA, @PRO_ALTURA_INTERNA, @PRO_COD_DESENHO, @PRO_FECHAMENTO, @PRO_TIPO_LAP, @PRO_TAMANHO_LAP, @PRO_LAP_PROLONGADO, @PRO_TAMANHO_LAP_PROLONG, @PRO_ARRANJO_LARGURA, @PRO_ARRANJO_COMPRIMENTO, @PRO_FITILHOS_FARDO_LARG, @PRO_FITILHOS_FARDO_COMP, @PRO_FITILHOS_PALETE_LARG, @PRO_FITILHOS_PALETE_COMP, @PRO_FILME_PALETE, @PRO_QTD_ESPELHO, @PRO_CUSTO, @PRO_AREA_LIQUIDA, @PRO_PESO, @PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, @PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, @PRO_IMG_LASTRO, @ABN_ID, @SEG_ID, @PRO_RESINA, @PRO_ENDURECEDOR_MIOLO, @PRO_VINCOS_ONDULADEIRA, @PRO_ADICIONAL_ABA_SUPERIOR, @PRO_ADICIONAL_ABA_INFERIOR, @PRO_PROMOVE_RESINA, @PRO_PROMOVE_DE, @PRO_PROMOVE_ATE, @PRO_PROFUNDIDADE_VINCO, @VIN_ID, @PRO_PROMOVE_PRODUTO, @PRO_TARA, @PRO_COMPRESSAO, @PRO_COD_BARRAS_CAIXA, @CJN_ID, @PRJ_ID, @PRO_REFILE_LARGURA, @PRO_REFILE_COMPRIMENTO, @PRO_M2_PONTA, @PRO_QTD_CORTES_PECA1, @PRO_QTD_CORTES_PECA2, @PRO_DIVISAO_MONTADA, @PRO_SEGMENTO_A, @PRO_SEGMENTO_B, @PRO_SEGMENTO_C, @PRO_SEGMENTO_D, @PRO_SEGMENTO_E, @PRO_SEGMENTO_F, @PRO_SEGMENTO_G, @PRO_SEGMENTO_H, @PRO_SEGMENTO_I, @PRO_QTD_GRAMPOS, @PRO_AREA_REFILE_INTERNO, @PRO_AREA_REFILE_EXTERNO, @PRO_PESO_REFILE, @PRO_ORELHA_INVERTIDA, @PRO_ENDERECO, @PRO_ID_VINCULADO, @PRO_BATIDAS_PROXIMA_MANUTENCAO, @PRO_ENTRADA_NA_MAQUINA, @TDI_ID, @PRO_QUEBRA_VINCO, @PRO_LARGURA_FARDO, @PRO_COMPRIMENTO_FARDO, @PRO_ALTURA_FARDO, @PRO_TIPO_CUSTO, @PRO_GRUPO_CONTABIL, @PRO_CLASSE_CUSTO_01, @PRO_OBS_ALTERACAO, @TIP_ID, @PRO_PECAS_POR_VEICULO, @PRO_DISTANCIA_ENTRE_VINCOS, @PRO_DISTANCIA_ENTRE_VINCOS2, @PRO_DISTANCIA_ENTRE_VINCOS3, @PRO_OUT, @PRO_ID_FACA, @PRO_ID_CLICHE, @PRO_ID_TINTA_01, @PRO_ID_TINTA_02, @PRO_ID_TINTA_03, @PRO_ID_TINTA_04, @PRO_ID_TINTA_05, @PRO_ID_FORROSUP, @PRO_ID_CANTONEIRA, @PRO_ID_PALETE, @PRO_ID_TAMPO, @PRO_ID_FORROINF, @PRO_ID_CHAPA, @PRO_ID_COMPOSICAO, @PRO_QUEBRA_VINCO_MAIOR, @PRO_QUEBRA_VINCO_MENOR, @CLI_ID) ";
            this.Parameters = new
            {
                Id = Produto.Id,
                Descricao = Produto.Descricao,
                Status = Produto.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
                PRO_ESTOQUE_ATUAL = Produto.PRO_ESTOQUE_ATUAL,
                UNI_ID = Produto.UNI_ID,
                PRO_FARDOS_POR_CAMADA = Produto.PRO_FARDOS_POR_CAMADA,
                PRO_CAMADAS_POR_PALETE = Produto.PRO_CAMADAS_POR_PALETE,
                PRO_TIPO_IDENTIFICACAO = Produto.PRO_TIPO_IDENTIFICACAO,
                PRO_GRUPO_PALETIZACAO = Produto.PRO_GRUPO_PALETIZACAO,
                PRO_PECAS_POR_FARDO = Produto.PRO_PECAS_POR_FARDO,
                PRO_ID_INTEGRACAO = Produto.PRO_ID_INTEGRACAO,
                PRO_ID_INTEGRACAO_ERP = Produto.PRO_ID_INTEGRACAO_ERP,
                GRP_ID = Produto.GRP_ID,
                TEM_ID = Produto.TEM_ID,
                PRO_LARGURA_PECA = Produto.PRO_LARGURA_PECA,
                PRO_COMPRIMENTO_PECA = Produto.PRO_COMPRIMENTO_PECA,
                PRO_ALTURA_PECA = Produto.PRO_ALTURA_PECA,
                PRO_LARGURA_EMBALADA = Produto.PRO_LARGURA_EMBALADA,
                PRO_COMPRIMENTO_EMBALADA = Produto.PRO_COMPRIMENTO_EMBALADA,
                PRO_ALTURA_EMBALADA = Produto.PRO_ALTURA_EMBALADA,
                PRO_FRENTE = Produto.PRO_FRENTE,
                PRO_ROTACIONA_COMPRIMENTO = Produto.PRO_ROTACIONA_COMPRIMENTO,
                PRO_ROTACIONA_LARGURA = Produto.PRO_ROTACIONA_LARGURA,
                PRO_ROTACIONA_ALTURA = Produto.PRO_ROTACIONA_ALTURA,
                PRO_ESCALA_COR = Produto.PRO_ESCALA_COR,
                PRO_SUB_ESCALA_COR = Produto.PRO_SUB_ESCALA_COR,
                PRO_CUSTO_SUBIDA_ESCALA_COR = Produto.PRO_CUSTO_SUBIDA_ESCALA_COR,
                PRO_CUSTO_DECIDA_ESCALA_COR = Produto.PRO_CUSTO_DECIDA_ESCALA_COR,
                TMP_TIPO_CARGA = Produto.TMP_TIPO_CARGA,
                PRO_TEMPO_CARREGAMENTO_UNITARIO = Produto.PRO_TEMPO_CARREGAMENTO_UNITARIO,
                PRO_TEMPO_DESCARREGAMENTO_UNITARIO = Produto.PRO_TEMPO_DESCARREGAMENTO_UNITARIO,
                PRO_PERCENTUAL_JANELA_EMBARQUE = Produto.PRO_PERCENTUAL_JANELA_EMBARQUE,
                PRO_TEMPO_PRODUCAO_CONJUNTO = Produto.PRO_TEMPO_PRODUCAO_CONJUNTO,
                PRO_PECAS_DA_PECA = Produto.PRO_PECAS_DA_PECA,
                PRO_TYPE = Produto.PRO_TYPE,
                PRO_COLOR_HEXA = Produto.PRO_COLOR_HEXA,
                PRO_VINCOS_LARGURA = Produto.PRO_VINCOS_LARGURA,
                PRO_VINCOS_COMPRIMENTO = Produto.PRO_VINCOS_COMPRIMENTO,
                PRO_LARGURA_INTERNA = Produto.PRO_LARGURA_INTERNA,
                PRO_COMPRIMENTO_INTERNA = Produto.PRO_COMPRIMENTO_INTERNA,
                PRO_ALTURA_INTERNA = Produto.PRO_ALTURA_INTERNA,
                PRO_COD_DESENHO = Produto.PRO_COD_DESENHO,
                PRO_FECHAMENTO = Produto.PRO_FECHAMENTO,
                PRO_TIPO_LAP = Produto.PRO_TIPO_LAP,
                PRO_TAMANHO_LAP = Produto.PRO_TAMANHO_LAP,
                PRO_LAP_PROLONGADO = Produto.PRO_LAP_PROLONGADO,
                PRO_TAMANHO_LAP_PROLONG = Produto.PRO_TAMANHO_LAP_PROLONG,
                PRO_ARRANJO_LARGURA = Produto.PRO_ARRANJO_LARGURA,
                PRO_ARRANJO_COMPRIMENTO = Produto.PRO_ARRANJO_COMPRIMENTO,
                PRO_FITILHOS_FARDO_LARG = Produto.PRO_FITILHOS_FARDO_LARG,
                PRO_FITILHOS_FARDO_COMP = Produto.PRO_FITILHOS_FARDO_COMP,
                PRO_FITILHOS_PALETE_LARG = Produto.PRO_FITILHOS_PALETE_LARG,
                PRO_FITILHOS_PALETE_COMP = Produto.PRO_FITILHOS_PALETE_COMP,
                PRO_FILME_PALETE = Produto.PRO_FILME_PALETE,
                PRO_QTD_ESPELHO = Produto.PRO_QTD_ESPELHO,
                PRO_CUSTO = Produto.PRO_CUSTO,
                PRO_AREA_LIQUIDA = Produto.PRO_AREA_LIQUIDA,
                PRO_PESO = Produto.PRO_PESO,
                PRO_TOLERANCIA_DIMENSAO_CHAPA_DE = Produto.PRO_TOLERANCIA_DIMENSAO_CHAPA_DE,
                PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE = Produto.PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE,
                PRO_IMG_LASTRO = Produto.PRO_IMG_LASTRO,
                ABN_ID = Produto.ABN_ID,
                SEG_ID = Produto.SEG_ID,
                PRO_RESINA = Produto.PRO_RESINA,
                PRO_ENDURECEDOR_MIOLO = Produto.PRO_ENDURECEDOR_MIOLO,
                PRO_VINCOS_ONDULADEIRA = Produto.PRO_VINCOS_ONDULADEIRA,
                PRO_ADICIONAL_ABA_SUPERIOR = Produto.PRO_ADICIONAL_ABA_SUPERIOR,
                PRO_ADICIONAL_ABA_INFERIOR = Produto.PRO_ADICIONAL_ABA_INFERIOR,
                PRO_PROMOVE_RESINA = Produto.PRO_PROMOVE_RESINA,
                PRO_PROMOVE_DE = Produto.PRO_PROMOVE_DE,
                PRO_PROMOVE_ATE = Produto.PRO_PROMOVE_ATE,
                PRO_PROFUNDIDADE_VINCO = Produto.PRO_PROFUNDIDADE_VINCO,
                VIN_ID = Produto.VIN_ID,
                PRO_PROMOVE_PRODUTO = Produto.PRO_PROMOVE_PRODUTO,
                PRO_TARA = Produto.PRO_TARA,
                PRO_COMPRESSAO = Produto.PRO_COMPRESSAO,
                PRO_COD_BARRAS_CAIXA = Produto.PRO_COD_BARRAS_CAIXA,
                CJN_ID = Produto.CJN_ID,
                PRJ_ID = Produto.PRJ_ID,
                PRO_REFILE_LARGURA = Produto.PRO_REFILE_LARGURA,
                PRO_REFILE_COMPRIMENTO = Produto.PRO_REFILE_COMPRIMENTO,
                PRO_M2_PONTA = Produto.PRO_M2_PONTA,
                PRO_QTD_CORTES_PECA1 = Produto.PRO_QTD_CORTES_PECA1,
                PRO_QTD_CORTES_PECA2 = Produto.PRO_QTD_CORTES_PECA2,
                PRO_DIVISAO_MONTADA = Produto.PRO_DIVISAO_MONTADA,
                PRO_SEGMENTO_A = Produto.PRO_SEGMENTO_A,
                PRO_SEGMENTO_B = Produto.PRO_SEGMENTO_B,
                PRO_SEGMENTO_C = Produto.PRO_SEGMENTO_C,
                PRO_SEGMENTO_D = Produto.PRO_SEGMENTO_D,
                PRO_SEGMENTO_E = Produto.PRO_SEGMENTO_E,
                PRO_SEGMENTO_F = Produto.PRO_SEGMENTO_F,
                PRO_SEGMENTO_G = Produto.PRO_SEGMENTO_G,
                PRO_SEGMENTO_H = Produto.PRO_SEGMENTO_H,
                PRO_SEGMENTO_I = Produto.PRO_SEGMENTO_I,
                PRO_QTD_GRAMPOS = Produto.PRO_QTD_GRAMPOS,
                PRO_AREA_REFILE_INTERNO = Produto.PRO_AREA_REFILE_INTERNO,
                PRO_AREA_REFILE_EXTERNO = Produto.PRO_AREA_REFILE_EXTERNO,
                PRO_PESO_REFILE = Produto.PRO_PESO_REFILE,
                PRO_ORELHA_INVERTIDA = Produto.PRO_ORELHA_INVERTIDA,
                PRO_ENDERECO = Produto.PRO_ENDERECO,
                PRO_ID_VINCULADO = Produto.PRO_ID_VINCULADO,
                PRO_BATIDAS_PROXIMA_MANUTENCAO = Produto.PRO_BATIDAS_PROXIMA_MANUTENCAO,
                PRO_ENTRADA_NA_MAQUINA = Produto.PRO_ENTRADA_NA_MAQUINA,
                TDI_ID = Produto.TDI_ID,
                PRO_QUEBRA_VINCO = Produto.PRO_QUEBRA_VINCO,
                PRO_LARGURA_FARDO = Produto.PRO_LARGURA_FARDO,
                PRO_COMPRIMENTO_FARDO = Produto.PRO_COMPRIMENTO_FARDO,
                PRO_ALTURA_FARDO = Produto.PRO_ALTURA_FARDO,
                PRO_TIPO_CUSTO = Produto.PRO_TIPO_CUSTO,
                PRO_GRUPO_CONTABIL = Produto.PRO_GRUPO_CONTABIL,
                PRO_CLASSE_CUSTO_01 = Produto.PRO_CLASSE_CUSTO_01,
                PRO_OBS_ALTERACAO = Produto.PRO_OBS_ALTERACAO,
                TIP_ID = Produto.TIP_ID,
                PRO_PECAS_POR_VEICULO = Produto.PRO_PECAS_POR_VEICULO,
                PRO_DISTANCIA_ENTRE_VINCOS = Produto.PRO_DISTANCIA_ENTRE_VINCOS,
                PRO_DISTANCIA_ENTRE_VINCOS2 = Produto.PRO_DISTANCIA_ENTRE_VINCOS2,
                PRO_DISTANCIA_ENTRE_VINCOS3 = Produto.PRO_DISTANCIA_ENTRE_VINCOS3,
                PRO_OUT = Produto.PRO_OUT,
                PRO_ID_FACA = Produto.PRO_ID_FACA,
                PRO_ID_CLICHE = Produto.PRO_ID_CLICHE,
                PRO_ID_TINTA_01 = Produto.PRO_ID_TINTA_01,
                PRO_ID_TINTA_02 = Produto.PRO_ID_TINTA_02,
                PRO_ID_TINTA_03 = Produto.PRO_ID_TINTA_03,
                PRO_ID_TINTA_04 = Produto.PRO_ID_TINTA_04,
                PRO_ID_TINTA_05 = Produto.PRO_ID_TINTA_05,
                PRO_ID_FORROSUP = Produto.PRO_ID_FORROSUP,
                PRO_ID_CANTONEIRA = Produto.PRO_ID_CANTONEIRA,
                PRO_ID_PALETE = Produto.PRO_ID_PALETE,
                PRO_ID_TAMPO = Produto.PRO_ID_TAMPO,
                PRO_ID_FORROINF = Produto.PRO_ID_FORROINF,
                PRO_ID_CHAPA = Produto.PRO_ID_CHAPA,
                PRO_ID_COMPOSICAO = Produto.PRO_ID_COMPOSICAO,
                PRO_QUEBRA_VINCO_MAIOR = Produto.PRO_QUEBRA_VINCO_MAIOR,
                PRO_QUEBRA_VINCO_MENOR = Produto.PRO_QUEBRA_VINCO_MENOR,
                CLI_ID = Produto.CLI_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProdutoQuery(IProdutoEntity Produto)
        {
            this.Query = $@" UPDATE Produto SET Descricao = @Descricao, Status = @Status, Changed = @Changed, UserId = @UserId, PRO_ESTOQUE_ATUAL = @PRO_ESTOQUE_ATUAL, UNI_ID = @UNI_ID, PRO_FARDOS_POR_CAMADA = @PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE = @PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO = @PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO = @PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO = @PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO = @PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP = @PRO_ID_INTEGRACAO_ERP, GRP_ID = @GRP_ID, TEM_ID = @TEM_ID, PRO_LARGURA_PECA = @PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA = @PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA = @PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA = @PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA = @PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA = @PRO_ALTURA_EMBALADA, PRO_FRENTE = @PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO = @PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA = @PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA = @PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR = @PRO_ESCALA_COR, PRO_SUB_ESCALA_COR = @PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR = @PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR = @PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA = @TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO = @PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO = @PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE = @PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO = @PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA = @PRO_PECAS_DA_PECA, PRO_TYPE = @PRO_TYPE, PRO_COLOR_HEXA = @PRO_COLOR_HEXA, PRO_VINCOS_LARGURA = @PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO = @PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA = @PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA = @PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA = @PRO_ALTURA_INTERNA, PRO_COD_DESENHO = @PRO_COD_DESENHO, PRO_FECHAMENTO = @PRO_FECHAMENTO, PRO_TIPO_LAP = @PRO_TIPO_LAP, PRO_TAMANHO_LAP = @PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO = @PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG = @PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA = @PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO = @PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG = @PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP = @PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG = @PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP = @PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE = @PRO_FILME_PALETE, PRO_QTD_ESPELHO = @PRO_QTD_ESPELHO, PRO_CUSTO = @PRO_CUSTO, PRO_AREA_LIQUIDA = @PRO_AREA_LIQUIDA, PRO_PESO = @PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE = @PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE = @PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO = @PRO_IMG_LASTRO, ABN_ID = @ABN_ID, SEG_ID = @SEG_ID, PRO_RESINA = @PRO_RESINA, PRO_ENDURECEDOR_MIOLO = @PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA = @PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR = @PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR = @PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA = @PRO_PROMOVE_RESINA, PRO_PROMOVE_DE = @PRO_PROMOVE_DE, PRO_PROMOVE_ATE = @PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO = @PRO_PROFUNDIDADE_VINCO, VIN_ID = @VIN_ID, PRO_PROMOVE_PRODUTO = @PRO_PROMOVE_PRODUTO, PRO_TARA = @PRO_TARA, PRO_COMPRESSAO = @PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA = @PRO_COD_BARRAS_CAIXA, CJN_ID = @CJN_ID, PRJ_ID = @PRJ_ID, PRO_REFILE_LARGURA = @PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO = @PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA = @PRO_M2_PONTA, PRO_QTD_CORTES_PECA1 = @PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2 = @PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA = @PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A = @PRO_SEGMENTO_A, PRO_SEGMENTO_B = @PRO_SEGMENTO_B, PRO_SEGMENTO_C = @PRO_SEGMENTO_C, PRO_SEGMENTO_D = @PRO_SEGMENTO_D, PRO_SEGMENTO_E = @PRO_SEGMENTO_E, PRO_SEGMENTO_F = @PRO_SEGMENTO_F, PRO_SEGMENTO_G = @PRO_SEGMENTO_G, PRO_SEGMENTO_H = @PRO_SEGMENTO_H, PRO_SEGMENTO_I = @PRO_SEGMENTO_I, PRO_QTD_GRAMPOS = @PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO = @PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO = @PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE = @PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA = @PRO_ORELHA_INVERTIDA, PRO_ENDERECO = @PRO_ENDERECO, PRO_ID_VINCULADO = @PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO = @PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA = @PRO_ENTRADA_NA_MAQUINA, TDI_ID = @TDI_ID, PRO_QUEBRA_VINCO = @PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO = @PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO = @PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO = @PRO_ALTURA_FARDO, PRO_TIPO_CUSTO = @PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL = @PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01 = @PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO = @PRO_OBS_ALTERACAO, TIP_ID = @TIP_ID, PRO_PECAS_POR_VEICULO = @PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS = @PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2 = @PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3 = @PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT = @PRO_OUT, PRO_ID_FACA = @PRO_ID_FACA, PRO_ID_CLICHE = @PRO_ID_CLICHE, PRO_ID_TINTA_01 = @PRO_ID_TINTA_01, PRO_ID_TINTA_02 = @PRO_ID_TINTA_02, PRO_ID_TINTA_03 = @PRO_ID_TINTA_03, PRO_ID_TINTA_04 = @PRO_ID_TINTA_04, PRO_ID_TINTA_05 = @PRO_ID_TINTA_05, PRO_ID_FORROSUP = @PRO_ID_FORROSUP, PRO_ID_CANTONEIRA = @PRO_ID_CANTONEIRA, PRO_ID_PALETE = @PRO_ID_PALETE, PRO_ID_TAMPO = @PRO_ID_TAMPO, PRO_ID_FORROINF = @PRO_ID_FORROINF, PRO_ID_CHAPA = @PRO_ID_CHAPA, PRO_ID_COMPOSICAO = @PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR = @PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR = @PRO_QUEBRA_VINCO_MENOR, CLI_ID = @CLI_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = Produto.Descricao,
                Status = Produto.Status,
                Changed = Produto.Changed,
                UserId = _executionContext.UserId,
                PRO_ESTOQUE_ATUAL = Produto.PRO_ESTOQUE_ATUAL,
                UNI_ID = Produto.UNI_ID,
                PRO_FARDOS_POR_CAMADA = Produto.PRO_FARDOS_POR_CAMADA,
                PRO_CAMADAS_POR_PALETE = Produto.PRO_CAMADAS_POR_PALETE,
                PRO_TIPO_IDENTIFICACAO = Produto.PRO_TIPO_IDENTIFICACAO,
                PRO_GRUPO_PALETIZACAO = Produto.PRO_GRUPO_PALETIZACAO,
                PRO_PECAS_POR_FARDO = Produto.PRO_PECAS_POR_FARDO,
                PRO_ID_INTEGRACAO = Produto.PRO_ID_INTEGRACAO,
                PRO_ID_INTEGRACAO_ERP = Produto.PRO_ID_INTEGRACAO_ERP,
                GRP_ID = Produto.GRP_ID,
                TEM_ID = Produto.TEM_ID,
                PRO_LARGURA_PECA = Produto.PRO_LARGURA_PECA,
                PRO_COMPRIMENTO_PECA = Produto.PRO_COMPRIMENTO_PECA,
                PRO_ALTURA_PECA = Produto.PRO_ALTURA_PECA,
                PRO_LARGURA_EMBALADA = Produto.PRO_LARGURA_EMBALADA,
                PRO_COMPRIMENTO_EMBALADA = Produto.PRO_COMPRIMENTO_EMBALADA,
                PRO_ALTURA_EMBALADA = Produto.PRO_ALTURA_EMBALADA,
                PRO_FRENTE = Produto.PRO_FRENTE,
                PRO_ROTACIONA_COMPRIMENTO = Produto.PRO_ROTACIONA_COMPRIMENTO,
                PRO_ROTACIONA_LARGURA = Produto.PRO_ROTACIONA_LARGURA,
                PRO_ROTACIONA_ALTURA = Produto.PRO_ROTACIONA_ALTURA,
                PRO_ESCALA_COR = Produto.PRO_ESCALA_COR,
                PRO_SUB_ESCALA_COR = Produto.PRO_SUB_ESCALA_COR,
                PRO_CUSTO_SUBIDA_ESCALA_COR = Produto.PRO_CUSTO_SUBIDA_ESCALA_COR,
                PRO_CUSTO_DECIDA_ESCALA_COR = Produto.PRO_CUSTO_DECIDA_ESCALA_COR,
                TMP_TIPO_CARGA = Produto.TMP_TIPO_CARGA,
                PRO_TEMPO_CARREGAMENTO_UNITARIO = Produto.PRO_TEMPO_CARREGAMENTO_UNITARIO,
                PRO_TEMPO_DESCARREGAMENTO_UNITARIO = Produto.PRO_TEMPO_DESCARREGAMENTO_UNITARIO,
                PRO_PERCENTUAL_JANELA_EMBARQUE = Produto.PRO_PERCENTUAL_JANELA_EMBARQUE,
                PRO_TEMPO_PRODUCAO_CONJUNTO = Produto.PRO_TEMPO_PRODUCAO_CONJUNTO,
                PRO_PECAS_DA_PECA = Produto.PRO_PECAS_DA_PECA,
                PRO_TYPE = Produto.PRO_TYPE,
                PRO_COLOR_HEXA = Produto.PRO_COLOR_HEXA,
                PRO_VINCOS_LARGURA = Produto.PRO_VINCOS_LARGURA,
                PRO_VINCOS_COMPRIMENTO = Produto.PRO_VINCOS_COMPRIMENTO,
                PRO_LARGURA_INTERNA = Produto.PRO_LARGURA_INTERNA,
                PRO_COMPRIMENTO_INTERNA = Produto.PRO_COMPRIMENTO_INTERNA,
                PRO_ALTURA_INTERNA = Produto.PRO_ALTURA_INTERNA,
                PRO_COD_DESENHO = Produto.PRO_COD_DESENHO,
                PRO_FECHAMENTO = Produto.PRO_FECHAMENTO,
                PRO_TIPO_LAP = Produto.PRO_TIPO_LAP,
                PRO_TAMANHO_LAP = Produto.PRO_TAMANHO_LAP,
                PRO_LAP_PROLONGADO = Produto.PRO_LAP_PROLONGADO,
                PRO_TAMANHO_LAP_PROLONG = Produto.PRO_TAMANHO_LAP_PROLONG,
                PRO_ARRANJO_LARGURA = Produto.PRO_ARRANJO_LARGURA,
                PRO_ARRANJO_COMPRIMENTO = Produto.PRO_ARRANJO_COMPRIMENTO,
                PRO_FITILHOS_FARDO_LARG = Produto.PRO_FITILHOS_FARDO_LARG,
                PRO_FITILHOS_FARDO_COMP = Produto.PRO_FITILHOS_FARDO_COMP,
                PRO_FITILHOS_PALETE_LARG = Produto.PRO_FITILHOS_PALETE_LARG,
                PRO_FITILHOS_PALETE_COMP = Produto.PRO_FITILHOS_PALETE_COMP,
                PRO_FILME_PALETE = Produto.PRO_FILME_PALETE,
                PRO_QTD_ESPELHO = Produto.PRO_QTD_ESPELHO,
                PRO_CUSTO = Produto.PRO_CUSTO,
                PRO_AREA_LIQUIDA = Produto.PRO_AREA_LIQUIDA,
                PRO_PESO = Produto.PRO_PESO,
                PRO_TOLERANCIA_DIMENSAO_CHAPA_DE = Produto.PRO_TOLERANCIA_DIMENSAO_CHAPA_DE,
                PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE = Produto.PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE,
                PRO_IMG_LASTRO = Produto.PRO_IMG_LASTRO,
                ABN_ID = Produto.ABN_ID,
                SEG_ID = Produto.SEG_ID,
                PRO_RESINA = Produto.PRO_RESINA,
                PRO_ENDURECEDOR_MIOLO = Produto.PRO_ENDURECEDOR_MIOLO,
                PRO_VINCOS_ONDULADEIRA = Produto.PRO_VINCOS_ONDULADEIRA,
                PRO_ADICIONAL_ABA_SUPERIOR = Produto.PRO_ADICIONAL_ABA_SUPERIOR,
                PRO_ADICIONAL_ABA_INFERIOR = Produto.PRO_ADICIONAL_ABA_INFERIOR,
                PRO_PROMOVE_RESINA = Produto.PRO_PROMOVE_RESINA,
                PRO_PROMOVE_DE = Produto.PRO_PROMOVE_DE,
                PRO_PROMOVE_ATE = Produto.PRO_PROMOVE_ATE,
                PRO_PROFUNDIDADE_VINCO = Produto.PRO_PROFUNDIDADE_VINCO,
                VIN_ID = Produto.VIN_ID,
                PRO_PROMOVE_PRODUTO = Produto.PRO_PROMOVE_PRODUTO,
                PRO_TARA = Produto.PRO_TARA,
                PRO_COMPRESSAO = Produto.PRO_COMPRESSAO,
                PRO_COD_BARRAS_CAIXA = Produto.PRO_COD_BARRAS_CAIXA,
                CJN_ID = Produto.CJN_ID,
                PRJ_ID = Produto.PRJ_ID,
                PRO_REFILE_LARGURA = Produto.PRO_REFILE_LARGURA,
                PRO_REFILE_COMPRIMENTO = Produto.PRO_REFILE_COMPRIMENTO,
                PRO_M2_PONTA = Produto.PRO_M2_PONTA,
                PRO_QTD_CORTES_PECA1 = Produto.PRO_QTD_CORTES_PECA1,
                PRO_QTD_CORTES_PECA2 = Produto.PRO_QTD_CORTES_PECA2,
                PRO_DIVISAO_MONTADA = Produto.PRO_DIVISAO_MONTADA,
                PRO_SEGMENTO_A = Produto.PRO_SEGMENTO_A,
                PRO_SEGMENTO_B = Produto.PRO_SEGMENTO_B,
                PRO_SEGMENTO_C = Produto.PRO_SEGMENTO_C,
                PRO_SEGMENTO_D = Produto.PRO_SEGMENTO_D,
                PRO_SEGMENTO_E = Produto.PRO_SEGMENTO_E,
                PRO_SEGMENTO_F = Produto.PRO_SEGMENTO_F,
                PRO_SEGMENTO_G = Produto.PRO_SEGMENTO_G,
                PRO_SEGMENTO_H = Produto.PRO_SEGMENTO_H,
                PRO_SEGMENTO_I = Produto.PRO_SEGMENTO_I,
                PRO_QTD_GRAMPOS = Produto.PRO_QTD_GRAMPOS,
                PRO_AREA_REFILE_INTERNO = Produto.PRO_AREA_REFILE_INTERNO,
                PRO_AREA_REFILE_EXTERNO = Produto.PRO_AREA_REFILE_EXTERNO,
                PRO_PESO_REFILE = Produto.PRO_PESO_REFILE,
                PRO_ORELHA_INVERTIDA = Produto.PRO_ORELHA_INVERTIDA,
                PRO_ENDERECO = Produto.PRO_ENDERECO,
                PRO_ID_VINCULADO = Produto.PRO_ID_VINCULADO,
                PRO_BATIDAS_PROXIMA_MANUTENCAO = Produto.PRO_BATIDAS_PROXIMA_MANUTENCAO,
                PRO_ENTRADA_NA_MAQUINA = Produto.PRO_ENTRADA_NA_MAQUINA,
                TDI_ID = Produto.TDI_ID,
                PRO_QUEBRA_VINCO = Produto.PRO_QUEBRA_VINCO,
                PRO_LARGURA_FARDO = Produto.PRO_LARGURA_FARDO,
                PRO_COMPRIMENTO_FARDO = Produto.PRO_COMPRIMENTO_FARDO,
                PRO_ALTURA_FARDO = Produto.PRO_ALTURA_FARDO,
                PRO_TIPO_CUSTO = Produto.PRO_TIPO_CUSTO,
                PRO_GRUPO_CONTABIL = Produto.PRO_GRUPO_CONTABIL,
                PRO_CLASSE_CUSTO_01 = Produto.PRO_CLASSE_CUSTO_01,
                PRO_OBS_ALTERACAO = Produto.PRO_OBS_ALTERACAO,
                TIP_ID = Produto.TIP_ID,
                PRO_PECAS_POR_VEICULO = Produto.PRO_PECAS_POR_VEICULO,
                PRO_DISTANCIA_ENTRE_VINCOS = Produto.PRO_DISTANCIA_ENTRE_VINCOS,
                PRO_DISTANCIA_ENTRE_VINCOS2 = Produto.PRO_DISTANCIA_ENTRE_VINCOS2,
                PRO_DISTANCIA_ENTRE_VINCOS3 = Produto.PRO_DISTANCIA_ENTRE_VINCOS3,
                PRO_OUT = Produto.PRO_OUT,
                PRO_ID_FACA = Produto.PRO_ID_FACA,
                PRO_ID_CLICHE = Produto.PRO_ID_CLICHE,
                PRO_ID_TINTA_01 = Produto.PRO_ID_TINTA_01,
                PRO_ID_TINTA_02 = Produto.PRO_ID_TINTA_02,
                PRO_ID_TINTA_03 = Produto.PRO_ID_TINTA_03,
                PRO_ID_TINTA_04 = Produto.PRO_ID_TINTA_04,
                PRO_ID_TINTA_05 = Produto.PRO_ID_TINTA_05,
                PRO_ID_FORROSUP = Produto.PRO_ID_FORROSUP,
                PRO_ID_CANTONEIRA = Produto.PRO_ID_CANTONEIRA,
                PRO_ID_PALETE = Produto.PRO_ID_PALETE,
                PRO_ID_TAMPO = Produto.PRO_ID_TAMPO,
                PRO_ID_FORROINF = Produto.PRO_ID_FORROINF,
                PRO_ID_CHAPA = Produto.PRO_ID_CHAPA,
                PRO_ID_COMPOSICAO = Produto.PRO_ID_COMPOSICAO,
                PRO_QUEBRA_VINCO_MAIOR = Produto.PRO_QUEBRA_VINCO_MAIOR,
                PRO_QUEBRA_VINCO_MENOR = Produto.PRO_QUEBRA_VINCO_MENOR,
                CLI_ID = Produto.CLI_ID,
                Id = Produto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescricao(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET Descricao = @Descricao WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string id, bool value)
        {
            this.Query = $@" UPDATE Produto SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string id, DateTime value)
        {
            this.Query = $@" UPDATE Produto SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ESTOQUE_ATUAL(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ESTOQUE_ATUAL = @PRO_ESTOQUE_ATUAL WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ESTOQUE_ATUAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUNI_ID(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET UNI_ID = @UNI_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                UNI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_FARDOS_POR_CAMADA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_FARDOS_POR_CAMADA = @PRO_FARDOS_POR_CAMADA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_FARDOS_POR_CAMADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_CAMADAS_POR_PALETE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_CAMADAS_POR_PALETE = @PRO_CAMADAS_POR_PALETE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_CAMADAS_POR_PALETE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_TIPO_IDENTIFICACAO(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_TIPO_IDENTIFICACAO = @PRO_TIPO_IDENTIFICACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_TIPO_IDENTIFICACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_GRUPO_PALETIZACAO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_GRUPO_PALETIZACAO = @PRO_GRUPO_PALETIZACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_GRUPO_PALETIZACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_PECAS_POR_FARDO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_PECAS_POR_FARDO = @PRO_PECAS_POR_FARDO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_PECAS_POR_FARDO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_INTEGRACAO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_INTEGRACAO = @PRO_ID_INTEGRACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_INTEGRACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_INTEGRACAO_ERP(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_INTEGRACAO_ERP = @PRO_ID_INTEGRACAO_ERP WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_INTEGRACAO_ERP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_ID(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET GRP_ID = @GRP_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                GRP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTEM_ID(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET TEM_ID = @TEM_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                TEM_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_LARGURA_PECA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_LARGURA_PECA = @PRO_LARGURA_PECA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_LARGURA_PECA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_COMPRIMENTO_PECA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_COMPRIMENTO_PECA = @PRO_COMPRIMENTO_PECA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_COMPRIMENTO_PECA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ALTURA_PECA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ALTURA_PECA = @PRO_ALTURA_PECA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ALTURA_PECA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_LARGURA_EMBALADA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_LARGURA_EMBALADA = @PRO_LARGURA_EMBALADA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_LARGURA_EMBALADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_COMPRIMENTO_EMBALADA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_COMPRIMENTO_EMBALADA = @PRO_COMPRIMENTO_EMBALADA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_COMPRIMENTO_EMBALADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ALTURA_EMBALADA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ALTURA_EMBALADA = @PRO_ALTURA_EMBALADA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ALTURA_EMBALADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_FRENTE(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_FRENTE = @PRO_FRENTE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_FRENTE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ROTACIONA_COMPRIMENTO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ROTACIONA_COMPRIMENTO = @PRO_ROTACIONA_COMPRIMENTO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ROTACIONA_COMPRIMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ROTACIONA_LARGURA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ROTACIONA_LARGURA = @PRO_ROTACIONA_LARGURA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ROTACIONA_LARGURA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ROTACIONA_ALTURA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ROTACIONA_ALTURA = @PRO_ROTACIONA_ALTURA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ROTACIONA_ALTURA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ESCALA_COR(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ESCALA_COR = @PRO_ESCALA_COR WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ESCALA_COR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_SUB_ESCALA_COR(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_SUB_ESCALA_COR = @PRO_SUB_ESCALA_COR WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_SUB_ESCALA_COR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_CUSTO_SUBIDA_ESCALA_COR(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_CUSTO_SUBIDA_ESCALA_COR = @PRO_CUSTO_SUBIDA_ESCALA_COR WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_CUSTO_SUBIDA_ESCALA_COR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_CUSTO_DECIDA_ESCALA_COR(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_CUSTO_DECIDA_ESCALA_COR = @PRO_CUSTO_DECIDA_ESCALA_COR WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_CUSTO_DECIDA_ESCALA_COR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTMP_TIPO_CARGA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET TMP_TIPO_CARGA = @TMP_TIPO_CARGA WHERE Id = @Id ";
            this.Parameters = new
            {
                TMP_TIPO_CARGA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_TEMPO_CARREGAMENTO_UNITARIO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_TEMPO_CARREGAMENTO_UNITARIO = @PRO_TEMPO_CARREGAMENTO_UNITARIO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_TEMPO_CARREGAMENTO_UNITARIO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_TEMPO_DESCARREGAMENTO_UNITARIO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_TEMPO_DESCARREGAMENTO_UNITARIO = @PRO_TEMPO_DESCARREGAMENTO_UNITARIO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_TEMPO_DESCARREGAMENTO_UNITARIO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_PERCENTUAL_JANELA_EMBARQUE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_PERCENTUAL_JANELA_EMBARQUE = @PRO_PERCENTUAL_JANELA_EMBARQUE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_PERCENTUAL_JANELA_EMBARQUE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_TEMPO_PRODUCAO_CONJUNTO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_TEMPO_PRODUCAO_CONJUNTO = @PRO_TEMPO_PRODUCAO_CONJUNTO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_TEMPO_PRODUCAO_CONJUNTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_PECAS_DA_PECA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_PECAS_DA_PECA = @PRO_PECAS_DA_PECA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_PECAS_DA_PECA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_TYPE(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_TYPE = @PRO_TYPE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_TYPE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_COLOR_HEXA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_COLOR_HEXA = @PRO_COLOR_HEXA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_COLOR_HEXA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_VINCOS_LARGURA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_VINCOS_LARGURA = @PRO_VINCOS_LARGURA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_VINCOS_LARGURA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_VINCOS_COMPRIMENTO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_VINCOS_COMPRIMENTO = @PRO_VINCOS_COMPRIMENTO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_VINCOS_COMPRIMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_LARGURA_INTERNA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_LARGURA_INTERNA = @PRO_LARGURA_INTERNA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_LARGURA_INTERNA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_COMPRIMENTO_INTERNA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_COMPRIMENTO_INTERNA = @PRO_COMPRIMENTO_INTERNA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_COMPRIMENTO_INTERNA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ALTURA_INTERNA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ALTURA_INTERNA = @PRO_ALTURA_INTERNA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ALTURA_INTERNA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_COD_DESENHO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_COD_DESENHO = @PRO_COD_DESENHO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_COD_DESENHO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_FECHAMENTO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_FECHAMENTO = @PRO_FECHAMENTO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_FECHAMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_TIPO_LAP(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_TIPO_LAP = @PRO_TIPO_LAP WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_TIPO_LAP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_TAMANHO_LAP(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_TAMANHO_LAP = @PRO_TAMANHO_LAP WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_TAMANHO_LAP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_LAP_PROLONGADO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_LAP_PROLONGADO = @PRO_LAP_PROLONGADO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_LAP_PROLONGADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_TAMANHO_LAP_PROLONG(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_TAMANHO_LAP_PROLONG = @PRO_TAMANHO_LAP_PROLONG WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_TAMANHO_LAP_PROLONG = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ARRANJO_LARGURA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ARRANJO_LARGURA = @PRO_ARRANJO_LARGURA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ARRANJO_LARGURA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ARRANJO_COMPRIMENTO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ARRANJO_COMPRIMENTO = @PRO_ARRANJO_COMPRIMENTO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ARRANJO_COMPRIMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_FITILHOS_FARDO_LARG(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_FITILHOS_FARDO_LARG = @PRO_FITILHOS_FARDO_LARG WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_FITILHOS_FARDO_LARG = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_FITILHOS_FARDO_COMP(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_FITILHOS_FARDO_COMP = @PRO_FITILHOS_FARDO_COMP WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_FITILHOS_FARDO_COMP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_FITILHOS_PALETE_LARG(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_FITILHOS_PALETE_LARG = @PRO_FITILHOS_PALETE_LARG WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_FITILHOS_PALETE_LARG = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_FITILHOS_PALETE_COMP(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_FITILHOS_PALETE_COMP = @PRO_FITILHOS_PALETE_COMP WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_FITILHOS_PALETE_COMP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_FILME_PALETE(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_FILME_PALETE = @PRO_FILME_PALETE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_FILME_PALETE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_QTD_ESPELHO(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_QTD_ESPELHO = @PRO_QTD_ESPELHO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_QTD_ESPELHO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_CUSTO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_CUSTO = @PRO_CUSTO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_CUSTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_AREA_LIQUIDA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_AREA_LIQUIDA = @PRO_AREA_LIQUIDA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_AREA_LIQUIDA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_PESO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_PESO = @PRO_PESO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_PESO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_TOLERANCIA_DIMENSAO_CHAPA_DE(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_TOLERANCIA_DIMENSAO_CHAPA_DE = @PRO_TOLERANCIA_DIMENSAO_CHAPA_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_TOLERANCIA_DIMENSAO_CHAPA_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_TOLERANCIA_DIMENSAO_CHAPA_ATE(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE = @PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_IMG_LASTRO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_IMG_LASTRO = @PRO_IMG_LASTRO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_IMG_LASTRO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateABN_ID(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET ABN_ID = @ABN_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ABN_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSEG_ID(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET SEG_ID = @SEG_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                SEG_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_RESINA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_RESINA = @PRO_RESINA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_RESINA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ENDURECEDOR_MIOLO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ENDURECEDOR_MIOLO = @PRO_ENDURECEDOR_MIOLO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ENDURECEDOR_MIOLO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_VINCOS_ONDULADEIRA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_VINCOS_ONDULADEIRA = @PRO_VINCOS_ONDULADEIRA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_VINCOS_ONDULADEIRA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ADICIONAL_ABA_SUPERIOR(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ADICIONAL_ABA_SUPERIOR = @PRO_ADICIONAL_ABA_SUPERIOR WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ADICIONAL_ABA_SUPERIOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ADICIONAL_ABA_INFERIOR(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ADICIONAL_ABA_INFERIOR = @PRO_ADICIONAL_ABA_INFERIOR WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ADICIONAL_ABA_INFERIOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_PROMOVE_RESINA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_PROMOVE_RESINA = @PRO_PROMOVE_RESINA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_PROMOVE_RESINA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_PROMOVE_DE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_PROMOVE_DE = @PRO_PROMOVE_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_PROMOVE_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_PROMOVE_ATE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_PROMOVE_ATE = @PRO_PROMOVE_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_PROMOVE_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_PROFUNDIDADE_VINCO(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_PROFUNDIDADE_VINCO = @PRO_PROFUNDIDADE_VINCO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_PROFUNDIDADE_VINCO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVIN_ID(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET VIN_ID = @VIN_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                VIN_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_PROMOVE_PRODUTO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_PROMOVE_PRODUTO = @PRO_PROMOVE_PRODUTO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_PROMOVE_PRODUTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_TARA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_TARA = @PRO_TARA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_TARA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_COMPRESSAO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_COMPRESSAO = @PRO_COMPRESSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_COMPRESSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_COD_BARRAS_CAIXA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_COD_BARRAS_CAIXA = @PRO_COD_BARRAS_CAIXA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_COD_BARRAS_CAIXA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCJN_ID(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET CJN_ID = @CJN_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CJN_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRJ_ID(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRJ_ID = @PRJ_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                PRJ_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_REFILE_LARGURA(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_REFILE_LARGURA = @PRO_REFILE_LARGURA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_REFILE_LARGURA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_REFILE_COMPRIMENTO(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_REFILE_COMPRIMENTO = @PRO_REFILE_COMPRIMENTO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_REFILE_COMPRIMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_M2_PONTA(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_M2_PONTA = @PRO_M2_PONTA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_M2_PONTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_QTD_CORTES_PECA1(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_QTD_CORTES_PECA1 = @PRO_QTD_CORTES_PECA1 WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_QTD_CORTES_PECA1 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_QTD_CORTES_PECA2(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_QTD_CORTES_PECA2 = @PRO_QTD_CORTES_PECA2 WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_QTD_CORTES_PECA2 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_DIVISAO_MONTADA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_DIVISAO_MONTADA = @PRO_DIVISAO_MONTADA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_DIVISAO_MONTADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_SEGMENTO_A(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_SEGMENTO_A = @PRO_SEGMENTO_A WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_SEGMENTO_A = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_SEGMENTO_B(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_SEGMENTO_B = @PRO_SEGMENTO_B WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_SEGMENTO_B = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_SEGMENTO_C(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_SEGMENTO_C = @PRO_SEGMENTO_C WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_SEGMENTO_C = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_SEGMENTO_D(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_SEGMENTO_D = @PRO_SEGMENTO_D WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_SEGMENTO_D = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_SEGMENTO_E(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_SEGMENTO_E = @PRO_SEGMENTO_E WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_SEGMENTO_E = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_SEGMENTO_F(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_SEGMENTO_F = @PRO_SEGMENTO_F WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_SEGMENTO_F = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_SEGMENTO_G(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_SEGMENTO_G = @PRO_SEGMENTO_G WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_SEGMENTO_G = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_SEGMENTO_H(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_SEGMENTO_H = @PRO_SEGMENTO_H WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_SEGMENTO_H = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_SEGMENTO_I(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_SEGMENTO_I = @PRO_SEGMENTO_I WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_SEGMENTO_I = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_QTD_GRAMPOS(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_QTD_GRAMPOS = @PRO_QTD_GRAMPOS WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_QTD_GRAMPOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_AREA_REFILE_INTERNO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_AREA_REFILE_INTERNO = @PRO_AREA_REFILE_INTERNO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_AREA_REFILE_INTERNO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_AREA_REFILE_EXTERNO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_AREA_REFILE_EXTERNO = @PRO_AREA_REFILE_EXTERNO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_AREA_REFILE_EXTERNO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_PESO_REFILE(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_PESO_REFILE = @PRO_PESO_REFILE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_PESO_REFILE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ORELHA_INVERTIDA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ORELHA_INVERTIDA = @PRO_ORELHA_INVERTIDA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ORELHA_INVERTIDA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ENDERECO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ENDERECO = @PRO_ENDERECO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ENDERECO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_VINCULADO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_VINCULADO = @PRO_ID_VINCULADO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_VINCULADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_BATIDAS_PROXIMA_MANUTENCAO(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_BATIDAS_PROXIMA_MANUTENCAO = @PRO_BATIDAS_PROXIMA_MANUTENCAO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_BATIDAS_PROXIMA_MANUTENCAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ENTRADA_NA_MAQUINA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ENTRADA_NA_MAQUINA = @PRO_ENTRADA_NA_MAQUINA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ENTRADA_NA_MAQUINA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTDI_ID(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET TDI_ID = @TDI_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                TDI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_QUEBRA_VINCO(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_QUEBRA_VINCO = @PRO_QUEBRA_VINCO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_QUEBRA_VINCO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_LARGURA_FARDO(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_LARGURA_FARDO = @PRO_LARGURA_FARDO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_LARGURA_FARDO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_COMPRIMENTO_FARDO(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_COMPRIMENTO_FARDO = @PRO_COMPRIMENTO_FARDO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_COMPRIMENTO_FARDO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ALTURA_FARDO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ALTURA_FARDO = @PRO_ALTURA_FARDO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ALTURA_FARDO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_TIPO_CUSTO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_TIPO_CUSTO = @PRO_TIPO_CUSTO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_TIPO_CUSTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_GRUPO_CONTABIL(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_GRUPO_CONTABIL = @PRO_GRUPO_CONTABIL WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_GRUPO_CONTABIL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_CLASSE_CUSTO_01(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_CLASSE_CUSTO_01 = @PRO_CLASSE_CUSTO_01 WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_CLASSE_CUSTO_01 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_OBS_ALTERACAO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_OBS_ALTERACAO = @PRO_OBS_ALTERACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_OBS_ALTERACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_ID(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET TIP_ID = @TIP_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                TIP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_PECAS_POR_VEICULO(string id, Decimal value)
        {
            this.Query = $@" UPDATE Produto SET PRO_PECAS_POR_VEICULO = @PRO_PECAS_POR_VEICULO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_PECAS_POR_VEICULO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_DISTANCIA_ENTRE_VINCOS(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_DISTANCIA_ENTRE_VINCOS = @PRO_DISTANCIA_ENTRE_VINCOS WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_DISTANCIA_ENTRE_VINCOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_DISTANCIA_ENTRE_VINCOS2(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_DISTANCIA_ENTRE_VINCOS2 = @PRO_DISTANCIA_ENTRE_VINCOS2 WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_DISTANCIA_ENTRE_VINCOS2 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_DISTANCIA_ENTRE_VINCOS3(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_DISTANCIA_ENTRE_VINCOS3 = @PRO_DISTANCIA_ENTRE_VINCOS3 WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_DISTANCIA_ENTRE_VINCOS3 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_OUT(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_OUT = @PRO_OUT WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_OUT = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_FACA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_FACA = @PRO_ID_FACA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_FACA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_CLICHE(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_CLICHE = @PRO_ID_CLICHE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_CLICHE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_TINTA_01(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_TINTA_01 = @PRO_ID_TINTA_01 WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_TINTA_01 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_TINTA_02(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_TINTA_02 = @PRO_ID_TINTA_02 WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_TINTA_02 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_TINTA_03(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_TINTA_03 = @PRO_ID_TINTA_03 WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_TINTA_03 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_TINTA_04(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_TINTA_04 = @PRO_ID_TINTA_04 WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_TINTA_04 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_TINTA_05(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_TINTA_05 = @PRO_ID_TINTA_05 WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_TINTA_05 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_FORROSUP(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_FORROSUP = @PRO_ID_FORROSUP WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_FORROSUP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_CANTONEIRA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_CANTONEIRA = @PRO_ID_CANTONEIRA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_CANTONEIRA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_PALETE(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_PALETE = @PRO_ID_PALETE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_PALETE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_TAMPO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_TAMPO = @PRO_ID_TAMPO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_TAMPO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_FORROINF(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_FORROINF = @PRO_ID_FORROINF WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_FORROINF = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_CHAPA(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_CHAPA = @PRO_ID_CHAPA WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_CHAPA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_COMPOSICAO(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_ID_COMPOSICAO = @PRO_ID_COMPOSICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_COMPOSICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_QUEBRA_VINCO_MAIOR(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_QUEBRA_VINCO_MAIOR = @PRO_QUEBRA_VINCO_MAIOR WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_QUEBRA_VINCO_MAIOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_QUEBRA_VINCO_MENOR(string id, int value)
        {
            this.Query = $@" UPDATE Produto SET PRO_QUEBRA_VINCO_MENOR = @PRO_QUEBRA_VINCO_MENOR WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_QUEBRA_VINCO_MENOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_ID(string id, string value)
        {
            this.Query = $@" UPDATE Produto SET CLI_ID = @CLI_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CLI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteProdutoQuery(IProdutoEntity Produto)
        {
            this.Query = $@" DELETE FROM Produto WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Produto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration