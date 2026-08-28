// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

using Shered.DB;
using System.Data.SqlTypes;
using Command.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Query.Read 
{
    public class ProdutoQueryRead : QueryBase, IProdutoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public ProdutoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel ProdutoQuery(Command.Read.ProdutoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID from Produto ";
if (!string.IsNullOrEmpty(Command.Id)) dict["Id"] = $"%{Command.Id}%";
if (!string.IsNullOrEmpty(Command.Id)) whereClauses.Add($"Id like @Id");
if (!string.IsNullOrEmpty(Command.Descricao)) dict["Descricao"] = $"%{Command.Descricao}%";
if (!string.IsNullOrEmpty(Command.Descricao)) whereClauses.Add($"Descricao like @Descricao");
if (!string.IsNullOrEmpty(Command.Status)) dict["Status"] = $"%{Command.Status}%";
if (!string.IsNullOrEmpty(Command.Status)) whereClauses.Add($"Status like @Status");
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
if (Command.UserId.HasValue) dict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"UserId = @UserId");
if (!string.IsNullOrEmpty(Command.UNI_ID)) dict["UNI_ID"] = $"%{Command.UNI_ID}%";
if (!string.IsNullOrEmpty(Command.UNI_ID)) whereClauses.Add($"UNI_ID like @UNI_ID");
if (Command.PRO_TIPO_IDENTIFICACAO.HasValue) dict["PRO_TIPO_IDENTIFICACAO"] = Command.PRO_TIPO_IDENTIFICACAO.Value;
if (Command.PRO_TIPO_IDENTIFICACAO.HasValue) whereClauses.Add($"PRO_TIPO_IDENTIFICACAO = @PRO_TIPO_IDENTIFICACAO");
if (!string.IsNullOrEmpty(Command.PRO_GRUPO_PALETIZACAO)) dict["PRO_GRUPO_PALETIZACAO"] = $"%{Command.PRO_GRUPO_PALETIZACAO}%";
if (!string.IsNullOrEmpty(Command.PRO_GRUPO_PALETIZACAO)) whereClauses.Add($"PRO_GRUPO_PALETIZACAO like @PRO_GRUPO_PALETIZACAO");
if (!string.IsNullOrEmpty(Command.PRO_ID_INTEGRACAO)) dict["PRO_ID_INTEGRACAO"] = $"%{Command.PRO_ID_INTEGRACAO}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_INTEGRACAO)) whereClauses.Add($"PRO_ID_INTEGRACAO like @PRO_ID_INTEGRACAO");
if (!string.IsNullOrEmpty(Command.PRO_ID_INTEGRACAO_ERP)) dict["PRO_ID_INTEGRACAO_ERP"] = $"%{Command.PRO_ID_INTEGRACAO_ERP}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_INTEGRACAO_ERP)) whereClauses.Add($"PRO_ID_INTEGRACAO_ERP like @PRO_ID_INTEGRACAO_ERP");
if (!string.IsNullOrEmpty(Command.GRP_ID)) dict["GRP_ID"] = $"%{Command.GRP_ID}%";
if (!string.IsNullOrEmpty(Command.GRP_ID)) whereClauses.Add($"GRP_ID like @GRP_ID");
if (Command.TEM_ID.HasValue) dict["TEM_ID"] = Command.TEM_ID.Value;
if (Command.TEM_ID.HasValue) whereClauses.Add($"TEM_ID = @TEM_ID");
if (!string.IsNullOrEmpty(Command.PRO_FRENTE)) dict["PRO_FRENTE"] = $"%{Command.PRO_FRENTE}%";
if (!string.IsNullOrEmpty(Command.PRO_FRENTE)) whereClauses.Add($"PRO_FRENTE like @PRO_FRENTE");
if (!string.IsNullOrEmpty(Command.PRO_ROTACIONA_COMPRIMENTO)) dict["PRO_ROTACIONA_COMPRIMENTO"] = $"%{Command.PRO_ROTACIONA_COMPRIMENTO}%";
if (!string.IsNullOrEmpty(Command.PRO_ROTACIONA_COMPRIMENTO)) whereClauses.Add($"PRO_ROTACIONA_COMPRIMENTO like @PRO_ROTACIONA_COMPRIMENTO");
if (!string.IsNullOrEmpty(Command.PRO_ROTACIONA_LARGURA)) dict["PRO_ROTACIONA_LARGURA"] = $"%{Command.PRO_ROTACIONA_LARGURA}%";
if (!string.IsNullOrEmpty(Command.PRO_ROTACIONA_LARGURA)) whereClauses.Add($"PRO_ROTACIONA_LARGURA like @PRO_ROTACIONA_LARGURA");
if (!string.IsNullOrEmpty(Command.PRO_ROTACIONA_ALTURA)) dict["PRO_ROTACIONA_ALTURA"] = $"%{Command.PRO_ROTACIONA_ALTURA}%";
if (!string.IsNullOrEmpty(Command.PRO_ROTACIONA_ALTURA)) whereClauses.Add($"PRO_ROTACIONA_ALTURA like @PRO_ROTACIONA_ALTURA");
if (!string.IsNullOrEmpty(Command.PRO_ESCALA_COR)) dict["PRO_ESCALA_COR"] = $"%{Command.PRO_ESCALA_COR}%";
if (!string.IsNullOrEmpty(Command.PRO_ESCALA_COR)) whereClauses.Add($"PRO_ESCALA_COR like @PRO_ESCALA_COR");
if (!string.IsNullOrEmpty(Command.PRO_SUB_ESCALA_COR)) dict["PRO_SUB_ESCALA_COR"] = $"%{Command.PRO_SUB_ESCALA_COR}%";
if (!string.IsNullOrEmpty(Command.PRO_SUB_ESCALA_COR)) whereClauses.Add($"PRO_SUB_ESCALA_COR like @PRO_SUB_ESCALA_COR");
if (!string.IsNullOrEmpty(Command.TMP_TIPO_CARGA)) dict["TMP_TIPO_CARGA"] = $"%{Command.TMP_TIPO_CARGA}%";
if (!string.IsNullOrEmpty(Command.TMP_TIPO_CARGA)) whereClauses.Add($"TMP_TIPO_CARGA like @TMP_TIPO_CARGA");
if (Command.PRO_TYPE.HasValue) dict["PRO_TYPE"] = Command.PRO_TYPE.Value;
if (Command.PRO_TYPE.HasValue) whereClauses.Add($"PRO_TYPE = @PRO_TYPE");
if (!string.IsNullOrEmpty(Command.PRO_COLOR_HEXA)) dict["PRO_COLOR_HEXA"] = $"%{Command.PRO_COLOR_HEXA}%";
if (!string.IsNullOrEmpty(Command.PRO_COLOR_HEXA)) whereClauses.Add($"PRO_COLOR_HEXA like @PRO_COLOR_HEXA");
if (!string.IsNullOrEmpty(Command.PRO_VINCOS_LARGURA)) dict["PRO_VINCOS_LARGURA"] = $"%{Command.PRO_VINCOS_LARGURA}%";
if (!string.IsNullOrEmpty(Command.PRO_VINCOS_LARGURA)) whereClauses.Add($"PRO_VINCOS_LARGURA like @PRO_VINCOS_LARGURA");
if (!string.IsNullOrEmpty(Command.PRO_VINCOS_COMPRIMENTO)) dict["PRO_VINCOS_COMPRIMENTO"] = $"%{Command.PRO_VINCOS_COMPRIMENTO}%";
if (!string.IsNullOrEmpty(Command.PRO_VINCOS_COMPRIMENTO)) whereClauses.Add($"PRO_VINCOS_COMPRIMENTO like @PRO_VINCOS_COMPRIMENTO");
if (!string.IsNullOrEmpty(Command.PRO_COD_DESENHO)) dict["PRO_COD_DESENHO"] = $"%{Command.PRO_COD_DESENHO}%";
if (!string.IsNullOrEmpty(Command.PRO_COD_DESENHO)) whereClauses.Add($"PRO_COD_DESENHO like @PRO_COD_DESENHO");
if (!string.IsNullOrEmpty(Command.PRO_FECHAMENTO)) dict["PRO_FECHAMENTO"] = $"%{Command.PRO_FECHAMENTO}%";
if (!string.IsNullOrEmpty(Command.PRO_FECHAMENTO)) whereClauses.Add($"PRO_FECHAMENTO like @PRO_FECHAMENTO");
if (!string.IsNullOrEmpty(Command.PRO_TIPO_LAP)) dict["PRO_TIPO_LAP"] = $"%{Command.PRO_TIPO_LAP}%";
if (!string.IsNullOrEmpty(Command.PRO_TIPO_LAP)) whereClauses.Add($"PRO_TIPO_LAP like @PRO_TIPO_LAP");
if (!string.IsNullOrEmpty(Command.PRO_LAP_PROLONGADO)) dict["PRO_LAP_PROLONGADO"] = $"%{Command.PRO_LAP_PROLONGADO}%";
if (!string.IsNullOrEmpty(Command.PRO_LAP_PROLONGADO)) whereClauses.Add($"PRO_LAP_PROLONGADO like @PRO_LAP_PROLONGADO");
if (Command.PRO_FITILHOS_FARDO_LARG.HasValue) dict["PRO_FITILHOS_FARDO_LARG"] = Command.PRO_FITILHOS_FARDO_LARG.Value;
if (Command.PRO_FITILHOS_FARDO_LARG.HasValue) whereClauses.Add($"PRO_FITILHOS_FARDO_LARG = @PRO_FITILHOS_FARDO_LARG");
if (Command.PRO_FITILHOS_FARDO_COMP.HasValue) dict["PRO_FITILHOS_FARDO_COMP"] = Command.PRO_FITILHOS_FARDO_COMP.Value;
if (Command.PRO_FITILHOS_FARDO_COMP.HasValue) whereClauses.Add($"PRO_FITILHOS_FARDO_COMP = @PRO_FITILHOS_FARDO_COMP");
if (Command.PRO_FITILHOS_PALETE_LARG.HasValue) dict["PRO_FITILHOS_PALETE_LARG"] = Command.PRO_FITILHOS_PALETE_LARG.Value;
if (Command.PRO_FITILHOS_PALETE_LARG.HasValue) whereClauses.Add($"PRO_FITILHOS_PALETE_LARG = @PRO_FITILHOS_PALETE_LARG");
if (Command.PRO_FITILHOS_PALETE_COMP.HasValue) dict["PRO_FITILHOS_PALETE_COMP"] = Command.PRO_FITILHOS_PALETE_COMP.Value;
if (Command.PRO_FITILHOS_PALETE_COMP.HasValue) whereClauses.Add($"PRO_FITILHOS_PALETE_COMP = @PRO_FITILHOS_PALETE_COMP");
if (Command.PRO_FILME_PALETE.HasValue) dict["PRO_FILME_PALETE"] = Command.PRO_FILME_PALETE.Value;
if (Command.PRO_FILME_PALETE.HasValue) whereClauses.Add($"PRO_FILME_PALETE = @PRO_FILME_PALETE");
if (Command.PRO_QTD_ESPELHO.HasValue) dict["PRO_QTD_ESPELHO"] = Command.PRO_QTD_ESPELHO.Value;
if (Command.PRO_QTD_ESPELHO.HasValue) whereClauses.Add($"PRO_QTD_ESPELHO = @PRO_QTD_ESPELHO");
if (Command.PRO_TOLERANCIA_DIMENSAO_CHAPA_DE.HasValue) dict["PRO_TOLERANCIA_DIMENSAO_CHAPA_DE"] = Command.PRO_TOLERANCIA_DIMENSAO_CHAPA_DE.Value;
if (Command.PRO_TOLERANCIA_DIMENSAO_CHAPA_DE.HasValue) whereClauses.Add($"PRO_TOLERANCIA_DIMENSAO_CHAPA_DE = @PRO_TOLERANCIA_DIMENSAO_CHAPA_DE");
if (Command.PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE.HasValue) dict["PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE"] = Command.PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE.Value;
if (Command.PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE.HasValue) whereClauses.Add($"PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE = @PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE");
if (!string.IsNullOrEmpty(Command.PRO_IMG_LASTRO)) dict["PRO_IMG_LASTRO"] = $"%{Command.PRO_IMG_LASTRO}%";
if (!string.IsNullOrEmpty(Command.PRO_IMG_LASTRO)) whereClauses.Add($"PRO_IMG_LASTRO like @PRO_IMG_LASTRO");
if (!string.IsNullOrEmpty(Command.ABN_ID)) dict["ABN_ID"] = $"%{Command.ABN_ID}%";
if (!string.IsNullOrEmpty(Command.ABN_ID)) whereClauses.Add($"ABN_ID like @ABN_ID");
if (Command.SEG_ID.HasValue) dict["SEG_ID"] = Command.SEG_ID.Value;
if (Command.SEG_ID.HasValue) whereClauses.Add($"SEG_ID = @SEG_ID");
if (!string.IsNullOrEmpty(Command.PRO_RESINA)) dict["PRO_RESINA"] = $"%{Command.PRO_RESINA}%";
if (!string.IsNullOrEmpty(Command.PRO_RESINA)) whereClauses.Add($"PRO_RESINA like @PRO_RESINA");
if (!string.IsNullOrEmpty(Command.PRO_ENDURECEDOR_MIOLO)) dict["PRO_ENDURECEDOR_MIOLO"] = $"%{Command.PRO_ENDURECEDOR_MIOLO}%";
if (!string.IsNullOrEmpty(Command.PRO_ENDURECEDOR_MIOLO)) whereClauses.Add($"PRO_ENDURECEDOR_MIOLO like @PRO_ENDURECEDOR_MIOLO");
if (!string.IsNullOrEmpty(Command.PRO_VINCOS_ONDULADEIRA)) dict["PRO_VINCOS_ONDULADEIRA"] = $"%{Command.PRO_VINCOS_ONDULADEIRA}%";
if (!string.IsNullOrEmpty(Command.PRO_VINCOS_ONDULADEIRA)) whereClauses.Add($"PRO_VINCOS_ONDULADEIRA like @PRO_VINCOS_ONDULADEIRA");
if (Command.PRO_ADICIONAL_ABA_SUPERIOR.HasValue) dict["PRO_ADICIONAL_ABA_SUPERIOR"] = Command.PRO_ADICIONAL_ABA_SUPERIOR.Value;
if (Command.PRO_ADICIONAL_ABA_SUPERIOR.HasValue) whereClauses.Add($"PRO_ADICIONAL_ABA_SUPERIOR = @PRO_ADICIONAL_ABA_SUPERIOR");
if (Command.PRO_ADICIONAL_ABA_INFERIOR.HasValue) dict["PRO_ADICIONAL_ABA_INFERIOR"] = Command.PRO_ADICIONAL_ABA_INFERIOR.Value;
if (Command.PRO_ADICIONAL_ABA_INFERIOR.HasValue) whereClauses.Add($"PRO_ADICIONAL_ABA_INFERIOR = @PRO_ADICIONAL_ABA_INFERIOR");
if (!string.IsNullOrEmpty(Command.PRO_PROMOVE_RESINA)) dict["PRO_PROMOVE_RESINA"] = $"%{Command.PRO_PROMOVE_RESINA}%";
if (!string.IsNullOrEmpty(Command.PRO_PROMOVE_RESINA)) whereClauses.Add($"PRO_PROMOVE_RESINA like @PRO_PROMOVE_RESINA");
if (Command.PRO_PROFUNDIDADE_VINCO.HasValue) dict["PRO_PROFUNDIDADE_VINCO"] = Command.PRO_PROFUNDIDADE_VINCO.Value;
if (Command.PRO_PROFUNDIDADE_VINCO.HasValue) whereClauses.Add($"PRO_PROFUNDIDADE_VINCO = @PRO_PROFUNDIDADE_VINCO");
if (Command.VIN_ID.HasValue) dict["VIN_ID"] = Command.VIN_ID.Value;
if (Command.VIN_ID.HasValue) whereClauses.Add($"VIN_ID = @VIN_ID");
if (!string.IsNullOrEmpty(Command.PRO_PROMOVE_PRODUTO)) dict["PRO_PROMOVE_PRODUTO"] = $"%{Command.PRO_PROMOVE_PRODUTO}%";
if (!string.IsNullOrEmpty(Command.PRO_PROMOVE_PRODUTO)) whereClauses.Add($"PRO_PROMOVE_PRODUTO like @PRO_PROMOVE_PRODUTO");
if (!string.IsNullOrEmpty(Command.PRO_COD_BARRAS_CAIXA)) dict["PRO_COD_BARRAS_CAIXA"] = $"%{Command.PRO_COD_BARRAS_CAIXA}%";
if (!string.IsNullOrEmpty(Command.PRO_COD_BARRAS_CAIXA)) whereClauses.Add($"PRO_COD_BARRAS_CAIXA like @PRO_COD_BARRAS_CAIXA");
if (!string.IsNullOrEmpty(Command.CJN_ID)) dict["CJN_ID"] = $"%{Command.CJN_ID}%";
if (!string.IsNullOrEmpty(Command.CJN_ID)) whereClauses.Add($"CJN_ID like @CJN_ID");
if (!string.IsNullOrEmpty(Command.PRJ_ID)) dict["PRJ_ID"] = $"%{Command.PRJ_ID}%";
if (!string.IsNullOrEmpty(Command.PRJ_ID)) whereClauses.Add($"PRJ_ID like @PRJ_ID");
if (Command.PRO_REFILE_LARGURA.HasValue) dict["PRO_REFILE_LARGURA"] = Command.PRO_REFILE_LARGURA.Value;
if (Command.PRO_REFILE_LARGURA.HasValue) whereClauses.Add($"PRO_REFILE_LARGURA = @PRO_REFILE_LARGURA");
if (Command.PRO_REFILE_COMPRIMENTO.HasValue) dict["PRO_REFILE_COMPRIMENTO"] = Command.PRO_REFILE_COMPRIMENTO.Value;
if (Command.PRO_REFILE_COMPRIMENTO.HasValue) whereClauses.Add($"PRO_REFILE_COMPRIMENTO = @PRO_REFILE_COMPRIMENTO");
if (Command.PRO_QTD_CORTES_PECA1.HasValue) dict["PRO_QTD_CORTES_PECA1"] = Command.PRO_QTD_CORTES_PECA1.Value;
if (Command.PRO_QTD_CORTES_PECA1.HasValue) whereClauses.Add($"PRO_QTD_CORTES_PECA1 = @PRO_QTD_CORTES_PECA1");
if (Command.PRO_QTD_CORTES_PECA2.HasValue) dict["PRO_QTD_CORTES_PECA2"] = Command.PRO_QTD_CORTES_PECA2.Value;
if (Command.PRO_QTD_CORTES_PECA2.HasValue) whereClauses.Add($"PRO_QTD_CORTES_PECA2 = @PRO_QTD_CORTES_PECA2");
if (!string.IsNullOrEmpty(Command.PRO_DIVISAO_MONTADA)) dict["PRO_DIVISAO_MONTADA"] = $"%{Command.PRO_DIVISAO_MONTADA}%";
if (!string.IsNullOrEmpty(Command.PRO_DIVISAO_MONTADA)) whereClauses.Add($"PRO_DIVISAO_MONTADA like @PRO_DIVISAO_MONTADA");
if (!string.IsNullOrEmpty(Command.PRO_ORELHA_INVERTIDA)) dict["PRO_ORELHA_INVERTIDA"] = $"%{Command.PRO_ORELHA_INVERTIDA}%";
if (!string.IsNullOrEmpty(Command.PRO_ORELHA_INVERTIDA)) whereClauses.Add($"PRO_ORELHA_INVERTIDA like @PRO_ORELHA_INVERTIDA");
if (!string.IsNullOrEmpty(Command.PRO_ENDERECO)) dict["PRO_ENDERECO"] = $"%{Command.PRO_ENDERECO}%";
if (!string.IsNullOrEmpty(Command.PRO_ENDERECO)) whereClauses.Add($"PRO_ENDERECO like @PRO_ENDERECO");
if (!string.IsNullOrEmpty(Command.PRO_ID_VINCULADO)) dict["PRO_ID_VINCULADO"] = $"%{Command.PRO_ID_VINCULADO}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_VINCULADO)) whereClauses.Add($"PRO_ID_VINCULADO like @PRO_ID_VINCULADO");
if (Command.PRO_BATIDAS_PROXIMA_MANUTENCAO.HasValue) dict["PRO_BATIDAS_PROXIMA_MANUTENCAO"] = Command.PRO_BATIDAS_PROXIMA_MANUTENCAO.Value;
if (Command.PRO_BATIDAS_PROXIMA_MANUTENCAO.HasValue) whereClauses.Add($"PRO_BATIDAS_PROXIMA_MANUTENCAO = @PRO_BATIDAS_PROXIMA_MANUTENCAO");
if (!string.IsNullOrEmpty(Command.PRO_ENTRADA_NA_MAQUINA)) dict["PRO_ENTRADA_NA_MAQUINA"] = $"%{Command.PRO_ENTRADA_NA_MAQUINA}%";
if (!string.IsNullOrEmpty(Command.PRO_ENTRADA_NA_MAQUINA)) whereClauses.Add($"PRO_ENTRADA_NA_MAQUINA like @PRO_ENTRADA_NA_MAQUINA");
if (!string.IsNullOrEmpty(Command.TDI_ID)) dict["TDI_ID"] = $"%{Command.TDI_ID}%";
if (!string.IsNullOrEmpty(Command.TDI_ID)) whereClauses.Add($"TDI_ID like @TDI_ID");
if (Command.PRO_QUEBRA_VINCO.HasValue) dict["PRO_QUEBRA_VINCO"] = Command.PRO_QUEBRA_VINCO.Value;
if (Command.PRO_QUEBRA_VINCO.HasValue) whereClauses.Add($"PRO_QUEBRA_VINCO = @PRO_QUEBRA_VINCO");
if (Command.PRO_LARGURA_FARDO.HasValue) dict["PRO_LARGURA_FARDO"] = Command.PRO_LARGURA_FARDO.Value;
if (Command.PRO_LARGURA_FARDO.HasValue) whereClauses.Add($"PRO_LARGURA_FARDO = @PRO_LARGURA_FARDO");
if (Command.PRO_COMPRIMENTO_FARDO.HasValue) dict["PRO_COMPRIMENTO_FARDO"] = Command.PRO_COMPRIMENTO_FARDO.Value;
if (Command.PRO_COMPRIMENTO_FARDO.HasValue) whereClauses.Add($"PRO_COMPRIMENTO_FARDO = @PRO_COMPRIMENTO_FARDO");
if (!string.IsNullOrEmpty(Command.PRO_TIPO_CUSTO)) dict["PRO_TIPO_CUSTO"] = $"%{Command.PRO_TIPO_CUSTO}%";
if (!string.IsNullOrEmpty(Command.PRO_TIPO_CUSTO)) whereClauses.Add($"PRO_TIPO_CUSTO like @PRO_TIPO_CUSTO");
if (!string.IsNullOrEmpty(Command.PRO_GRUPO_CONTABIL)) dict["PRO_GRUPO_CONTABIL"] = $"%{Command.PRO_GRUPO_CONTABIL}%";
if (!string.IsNullOrEmpty(Command.PRO_GRUPO_CONTABIL)) whereClauses.Add($"PRO_GRUPO_CONTABIL like @PRO_GRUPO_CONTABIL");
if (!string.IsNullOrEmpty(Command.PRO_CLASSE_CUSTO_01)) dict["PRO_CLASSE_CUSTO_01"] = $"%{Command.PRO_CLASSE_CUSTO_01}%";
if (!string.IsNullOrEmpty(Command.PRO_CLASSE_CUSTO_01)) whereClauses.Add($"PRO_CLASSE_CUSTO_01 like @PRO_CLASSE_CUSTO_01");
if (!string.IsNullOrEmpty(Command.PRO_OBS_ALTERACAO)) dict["PRO_OBS_ALTERACAO"] = $"%{Command.PRO_OBS_ALTERACAO}%";
if (!string.IsNullOrEmpty(Command.PRO_OBS_ALTERACAO)) whereClauses.Add($"PRO_OBS_ALTERACAO like @PRO_OBS_ALTERACAO");
if (Command.TIP_ID.HasValue) dict["TIP_ID"] = Command.TIP_ID.Value;
if (Command.TIP_ID.HasValue) whereClauses.Add($"TIP_ID = @TIP_ID");
if (Command.PRO_DISTANCIA_ENTRE_VINCOS.HasValue) dict["PRO_DISTANCIA_ENTRE_VINCOS"] = Command.PRO_DISTANCIA_ENTRE_VINCOS.Value;
if (Command.PRO_DISTANCIA_ENTRE_VINCOS.HasValue) whereClauses.Add($"PRO_DISTANCIA_ENTRE_VINCOS = @PRO_DISTANCIA_ENTRE_VINCOS");
if (Command.PRO_DISTANCIA_ENTRE_VINCOS2.HasValue) dict["PRO_DISTANCIA_ENTRE_VINCOS2"] = Command.PRO_DISTANCIA_ENTRE_VINCOS2.Value;
if (Command.PRO_DISTANCIA_ENTRE_VINCOS2.HasValue) whereClauses.Add($"PRO_DISTANCIA_ENTRE_VINCOS2 = @PRO_DISTANCIA_ENTRE_VINCOS2");
if (Command.PRO_DISTANCIA_ENTRE_VINCOS3.HasValue) dict["PRO_DISTANCIA_ENTRE_VINCOS3"] = Command.PRO_DISTANCIA_ENTRE_VINCOS3.Value;
if (Command.PRO_DISTANCIA_ENTRE_VINCOS3.HasValue) whereClauses.Add($"PRO_DISTANCIA_ENTRE_VINCOS3 = @PRO_DISTANCIA_ENTRE_VINCOS3");
if (Command.PRO_OUT.HasValue) dict["PRO_OUT"] = Command.PRO_OUT.Value;
if (Command.PRO_OUT.HasValue) whereClauses.Add($"PRO_OUT = @PRO_OUT");
if (!string.IsNullOrEmpty(Command.PRO_ID_FACA)) dict["PRO_ID_FACA"] = $"%{Command.PRO_ID_FACA}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_FACA)) whereClauses.Add($"PRO_ID_FACA like @PRO_ID_FACA");
if (!string.IsNullOrEmpty(Command.PRO_ID_CLICHE)) dict["PRO_ID_CLICHE"] = $"%{Command.PRO_ID_CLICHE}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_CLICHE)) whereClauses.Add($"PRO_ID_CLICHE like @PRO_ID_CLICHE");
if (!string.IsNullOrEmpty(Command.PRO_ID_TINTA_01)) dict["PRO_ID_TINTA_01"] = $"%{Command.PRO_ID_TINTA_01}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_TINTA_01)) whereClauses.Add($"PRO_ID_TINTA_01 like @PRO_ID_TINTA_01");
if (!string.IsNullOrEmpty(Command.PRO_ID_TINTA_02)) dict["PRO_ID_TINTA_02"] = $"%{Command.PRO_ID_TINTA_02}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_TINTA_02)) whereClauses.Add($"PRO_ID_TINTA_02 like @PRO_ID_TINTA_02");
if (!string.IsNullOrEmpty(Command.PRO_ID_TINTA_03)) dict["PRO_ID_TINTA_03"] = $"%{Command.PRO_ID_TINTA_03}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_TINTA_03)) whereClauses.Add($"PRO_ID_TINTA_03 like @PRO_ID_TINTA_03");
if (!string.IsNullOrEmpty(Command.PRO_ID_TINTA_04)) dict["PRO_ID_TINTA_04"] = $"%{Command.PRO_ID_TINTA_04}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_TINTA_04)) whereClauses.Add($"PRO_ID_TINTA_04 like @PRO_ID_TINTA_04");
if (!string.IsNullOrEmpty(Command.PRO_ID_TINTA_05)) dict["PRO_ID_TINTA_05"] = $"%{Command.PRO_ID_TINTA_05}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_TINTA_05)) whereClauses.Add($"PRO_ID_TINTA_05 like @PRO_ID_TINTA_05");
if (!string.IsNullOrEmpty(Command.PRO_ID_FORROSUP)) dict["PRO_ID_FORROSUP"] = $"%{Command.PRO_ID_FORROSUP}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_FORROSUP)) whereClauses.Add($"PRO_ID_FORROSUP like @PRO_ID_FORROSUP");
if (!string.IsNullOrEmpty(Command.PRO_ID_CANTONEIRA)) dict["PRO_ID_CANTONEIRA"] = $"%{Command.PRO_ID_CANTONEIRA}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_CANTONEIRA)) whereClauses.Add($"PRO_ID_CANTONEIRA like @PRO_ID_CANTONEIRA");
if (!string.IsNullOrEmpty(Command.PRO_ID_PALETE)) dict["PRO_ID_PALETE"] = $"%{Command.PRO_ID_PALETE}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_PALETE)) whereClauses.Add($"PRO_ID_PALETE like @PRO_ID_PALETE");
if (!string.IsNullOrEmpty(Command.PRO_ID_TAMPO)) dict["PRO_ID_TAMPO"] = $"%{Command.PRO_ID_TAMPO}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_TAMPO)) whereClauses.Add($"PRO_ID_TAMPO like @PRO_ID_TAMPO");
if (!string.IsNullOrEmpty(Command.PRO_ID_FORROINF)) dict["PRO_ID_FORROINF"] = $"%{Command.PRO_ID_FORROINF}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_FORROINF)) whereClauses.Add($"PRO_ID_FORROINF like @PRO_ID_FORROINF");
if (!string.IsNullOrEmpty(Command.PRO_ID_CHAPA)) dict["PRO_ID_CHAPA"] = $"%{Command.PRO_ID_CHAPA}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_CHAPA)) whereClauses.Add($"PRO_ID_CHAPA like @PRO_ID_CHAPA");
if (!string.IsNullOrEmpty(Command.PRO_ID_COMPOSICAO)) dict["PRO_ID_COMPOSICAO"] = $"%{Command.PRO_ID_COMPOSICAO}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_COMPOSICAO)) whereClauses.Add($"PRO_ID_COMPOSICAO like @PRO_ID_COMPOSICAO");
if (Command.PRO_QUEBRA_VINCO_MAIOR.HasValue) dict["PRO_QUEBRA_VINCO_MAIOR"] = Command.PRO_QUEBRA_VINCO_MAIOR.Value;
if (Command.PRO_QUEBRA_VINCO_MAIOR.HasValue) whereClauses.Add($"PRO_QUEBRA_VINCO_MAIOR = @PRO_QUEBRA_VINCO_MAIOR");
if (Command.PRO_QUEBRA_VINCO_MENOR.HasValue) dict["PRO_QUEBRA_VINCO_MENOR"] = Command.PRO_QUEBRA_VINCO_MENOR.Value;
if (Command.PRO_QUEBRA_VINCO_MENOR.HasValue) whereClauses.Add($"PRO_QUEBRA_VINCO_MENOR = @PRO_QUEBRA_VINCO_MENOR");
if (!string.IsNullOrEmpty(Command.CLI_ID)) dict["CLI_ID"] = $"%{Command.CLI_ID}%";
if (!string.IsNullOrEmpty(Command.CLI_ID)) whereClauses.Add($"CLI_ID like @CLI_ID");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel ProdutoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from yTenant ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" Id = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Id like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Nome like @Nome ");//02
                 }
           }
 dict["Id"] = _executionContext.TenantID;
 whereClauses.Add($"Id = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ProdutoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from yUser ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" Id = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Id like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Nome like @Nome ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ProdutoUNI_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select UNI_ID from UnidadeMedida ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["UNI_ID"] = numero; //01
                      whereClauses.Add($" UNI_ID = @UNI_ID");//01 
                 }
                 else 
                 {
                      dict["UNI_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" UNI_ID like @UNI_ID ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ProdutoGRP_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select GRP_ID from GrupoProdutoAbstrato ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["GRP_ID"] = numero; //01
                      whereClauses.Add($" GRP_ID = @GRP_ID");//01 
                 }
                 else 
                 {
                      dict["GRP_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" GRP_ID like @GRP_ID ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ProdutoVIN_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select VIN_ID from Vinco ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["VIN_ID"] = numero; //01
                      whereClauses.Add($" VIN_ID = @VIN_ID");//01 
                 }
                 else 
                 {
                      dict["VIN_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" VIN_ID like @VIN_ID ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Id"] = value; //04
                      whereClauses.Add($" Id = @Id ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDescricaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Descricao"] = value; //04
                      whereClauses.Add($" Descricao = @Descricao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByStatusQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Status"] = value; //04
                      whereClauses.Add($" Status = @Status ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TenantID"] = value; //04
                      whereClauses.Add($" TenantID = @TenantID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDeletedQuery(bool value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Deleted"] = value; //04
                      whereClauses.Add($" Deleted = @Deleted ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Changed"] = value; //04
                      whereClauses.Add($" Changed = @Changed ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UserId"] = value; //04
                      whereClauses.Add($" UserId = @UserId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ESTOQUE_ATUALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ESTOQUE_ATUAL"] = value; //04
                      whereClauses.Add($" PRO_ESTOQUE_ATUAL = @PRO_ESTOQUE_ATUAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUNI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UNI_ID"] = value; //04
                      whereClauses.Add($" UNI_ID = @UNI_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_FARDOS_POR_CAMADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FARDOS_POR_CAMADA"] = value; //04
                      whereClauses.Add($" PRO_FARDOS_POR_CAMADA = @PRO_FARDOS_POR_CAMADA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_CAMADAS_POR_PALETEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_CAMADAS_POR_PALETE"] = value; //04
                      whereClauses.Add($" PRO_CAMADAS_POR_PALETE = @PRO_CAMADAS_POR_PALETE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_TIPO_IDENTIFICACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TIPO_IDENTIFICACAO"] = value; //04
                      whereClauses.Add($" PRO_TIPO_IDENTIFICACAO = @PRO_TIPO_IDENTIFICACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_GRUPO_PALETIZACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_GRUPO_PALETIZACAO"] = value; //04
                      whereClauses.Add($" PRO_GRUPO_PALETIZACAO = @PRO_GRUPO_PALETIZACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_PECAS_POR_FARDOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PECAS_POR_FARDO"] = value; //04
                      whereClauses.Add($" PRO_PECAS_POR_FARDO = @PRO_PECAS_POR_FARDO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_INTEGRACAO"] = value; //04
                      whereClauses.Add($" PRO_ID_INTEGRACAO = @PRO_ID_INTEGRACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_INTEGRACAO_ERP"] = value; //04
                      whereClauses.Add($" PRO_ID_INTEGRACAO_ERP = @PRO_ID_INTEGRACAO_ERP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ID"] = value; //04
                      whereClauses.Add($" GRP_ID = @GRP_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTEM_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TEM_ID"] = value; //04
                      whereClauses.Add($" TEM_ID = @TEM_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_LARGURA_PECAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LARGURA_PECA"] = value; //04
                      whereClauses.Add($" PRO_LARGURA_PECA = @PRO_LARGURA_PECA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_COMPRIMENTO_PECAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRIMENTO_PECA"] = value; //04
                      whereClauses.Add($" PRO_COMPRIMENTO_PECA = @PRO_COMPRIMENTO_PECA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ALTURA_PECAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ALTURA_PECA"] = value; //04
                      whereClauses.Add($" PRO_ALTURA_PECA = @PRO_ALTURA_PECA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_LARGURA_EMBALADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LARGURA_EMBALADA"] = value; //04
                      whereClauses.Add($" PRO_LARGURA_EMBALADA = @PRO_LARGURA_EMBALADA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_COMPRIMENTO_EMBALADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRIMENTO_EMBALADA"] = value; //04
                      whereClauses.Add($" PRO_COMPRIMENTO_EMBALADA = @PRO_COMPRIMENTO_EMBALADA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ALTURA_EMBALADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ALTURA_EMBALADA"] = value; //04
                      whereClauses.Add($" PRO_ALTURA_EMBALADA = @PRO_ALTURA_EMBALADA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_FRENTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FRENTE"] = value; //04
                      whereClauses.Add($" PRO_FRENTE = @PRO_FRENTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ROTACIONA_COMPRIMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ROTACIONA_COMPRIMENTO"] = value; //04
                      whereClauses.Add($" PRO_ROTACIONA_COMPRIMENTO = @PRO_ROTACIONA_COMPRIMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ROTACIONA_LARGURAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ROTACIONA_LARGURA"] = value; //04
                      whereClauses.Add($" PRO_ROTACIONA_LARGURA = @PRO_ROTACIONA_LARGURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ROTACIONA_ALTURAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ROTACIONA_ALTURA"] = value; //04
                      whereClauses.Add($" PRO_ROTACIONA_ALTURA = @PRO_ROTACIONA_ALTURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ESCALA_CORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ESCALA_COR"] = value; //04
                      whereClauses.Add($" PRO_ESCALA_COR = @PRO_ESCALA_COR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_SUB_ESCALA_CORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SUB_ESCALA_COR"] = value; //04
                      whereClauses.Add($" PRO_SUB_ESCALA_COR = @PRO_SUB_ESCALA_COR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_CUSTO_SUBIDA_ESCALA_CORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_CUSTO_SUBIDA_ESCALA_COR"] = value; //04
                      whereClauses.Add($" PRO_CUSTO_SUBIDA_ESCALA_COR = @PRO_CUSTO_SUBIDA_ESCALA_COR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_CUSTO_DECIDA_ESCALA_CORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_CUSTO_DECIDA_ESCALA_COR"] = value; //04
                      whereClauses.Add($" PRO_CUSTO_DECIDA_ESCALA_COR = @PRO_CUSTO_DECIDA_ESCALA_COR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTMP_TIPO_CARGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TMP_TIPO_CARGA"] = value; //04
                      whereClauses.Add($" TMP_TIPO_CARGA = @TMP_TIPO_CARGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_TEMPO_CARREGAMENTO_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TEMPO_CARREGAMENTO_UNITARIO"] = value; //04
                      whereClauses.Add($" PRO_TEMPO_CARREGAMENTO_UNITARIO = @PRO_TEMPO_CARREGAMENTO_UNITARIO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_TEMPO_DESCARREGAMENTO_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TEMPO_DESCARREGAMENTO_UNITARIO"] = value; //04
                      whereClauses.Add($" PRO_TEMPO_DESCARREGAMENTO_UNITARIO = @PRO_TEMPO_DESCARREGAMENTO_UNITARIO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_PERCENTUAL_JANELA_EMBARQUEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PERCENTUAL_JANELA_EMBARQUE"] = value; //04
                      whereClauses.Add($" PRO_PERCENTUAL_JANELA_EMBARQUE = @PRO_PERCENTUAL_JANELA_EMBARQUE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_TEMPO_PRODUCAO_CONJUNTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TEMPO_PRODUCAO_CONJUNTO"] = value; //04
                      whereClauses.Add($" PRO_TEMPO_PRODUCAO_CONJUNTO = @PRO_TEMPO_PRODUCAO_CONJUNTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_PECAS_DA_PECAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PECAS_DA_PECA"] = value; //04
                      whereClauses.Add($" PRO_PECAS_DA_PECA = @PRO_PECAS_DA_PECA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_TYPEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TYPE"] = value; //04
                      whereClauses.Add($" PRO_TYPE = @PRO_TYPE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_COLOR_HEXAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COLOR_HEXA"] = value; //04
                      whereClauses.Add($" PRO_COLOR_HEXA = @PRO_COLOR_HEXA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_VINCOS_LARGURAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_VINCOS_LARGURA"] = value; //04
                      whereClauses.Add($" PRO_VINCOS_LARGURA = @PRO_VINCOS_LARGURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_VINCOS_COMPRIMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_VINCOS_COMPRIMENTO"] = value; //04
                      whereClauses.Add($" PRO_VINCOS_COMPRIMENTO = @PRO_VINCOS_COMPRIMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_LARGURA_INTERNAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LARGURA_INTERNA"] = value; //04
                      whereClauses.Add($" PRO_LARGURA_INTERNA = @PRO_LARGURA_INTERNA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_COMPRIMENTO_INTERNAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRIMENTO_INTERNA"] = value; //04
                      whereClauses.Add($" PRO_COMPRIMENTO_INTERNA = @PRO_COMPRIMENTO_INTERNA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ALTURA_INTERNAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ALTURA_INTERNA"] = value; //04
                      whereClauses.Add($" PRO_ALTURA_INTERNA = @PRO_ALTURA_INTERNA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_COD_DESENHOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COD_DESENHO"] = value; //04
                      whereClauses.Add($" PRO_COD_DESENHO = @PRO_COD_DESENHO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_FECHAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FECHAMENTO"] = value; //04
                      whereClauses.Add($" PRO_FECHAMENTO = @PRO_FECHAMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_TIPO_LAPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TIPO_LAP"] = value; //04
                      whereClauses.Add($" PRO_TIPO_LAP = @PRO_TIPO_LAP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_TAMANHO_LAPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TAMANHO_LAP"] = value; //04
                      whereClauses.Add($" PRO_TAMANHO_LAP = @PRO_TAMANHO_LAP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_LAP_PROLONGADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LAP_PROLONGADO"] = value; //04
                      whereClauses.Add($" PRO_LAP_PROLONGADO = @PRO_LAP_PROLONGADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_TAMANHO_LAP_PROLONGQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TAMANHO_LAP_PROLONG"] = value; //04
                      whereClauses.Add($" PRO_TAMANHO_LAP_PROLONG = @PRO_TAMANHO_LAP_PROLONG ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ARRANJO_LARGURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ARRANJO_LARGURA"] = value; //04
                      whereClauses.Add($" PRO_ARRANJO_LARGURA = @PRO_ARRANJO_LARGURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ARRANJO_COMPRIMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ARRANJO_COMPRIMENTO"] = value; //04
                      whereClauses.Add($" PRO_ARRANJO_COMPRIMENTO = @PRO_ARRANJO_COMPRIMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_FITILHOS_FARDO_LARGQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FITILHOS_FARDO_LARG"] = value; //04
                      whereClauses.Add($" PRO_FITILHOS_FARDO_LARG = @PRO_FITILHOS_FARDO_LARG ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_FITILHOS_FARDO_COMPQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FITILHOS_FARDO_COMP"] = value; //04
                      whereClauses.Add($" PRO_FITILHOS_FARDO_COMP = @PRO_FITILHOS_FARDO_COMP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_FITILHOS_PALETE_LARGQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FITILHOS_PALETE_LARG"] = value; //04
                      whereClauses.Add($" PRO_FITILHOS_PALETE_LARG = @PRO_FITILHOS_PALETE_LARG ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_FITILHOS_PALETE_COMPQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FITILHOS_PALETE_COMP"] = value; //04
                      whereClauses.Add($" PRO_FITILHOS_PALETE_COMP = @PRO_FITILHOS_PALETE_COMP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_FILME_PALETEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FILME_PALETE"] = value; //04
                      whereClauses.Add($" PRO_FILME_PALETE = @PRO_FILME_PALETE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_QTD_ESPELHOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QTD_ESPELHO"] = value; //04
                      whereClauses.Add($" PRO_QTD_ESPELHO = @PRO_QTD_ESPELHO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_CUSTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_CUSTO"] = value; //04
                      whereClauses.Add($" PRO_CUSTO = @PRO_CUSTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_AREA_LIQUIDAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_AREA_LIQUIDA"] = value; //04
                      whereClauses.Add($" PRO_AREA_LIQUIDA = @PRO_AREA_LIQUIDA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_PESOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PESO"] = value; //04
                      whereClauses.Add($" PRO_PESO = @PRO_PESO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_TOLERANCIA_DIMENSAO_CHAPA_DEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TOLERANCIA_DIMENSAO_CHAPA_DE"] = value; //04
                      whereClauses.Add($" PRO_TOLERANCIA_DIMENSAO_CHAPA_DE = @PRO_TOLERANCIA_DIMENSAO_CHAPA_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_TOLERANCIA_DIMENSAO_CHAPA_ATEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE"] = value; //04
                      whereClauses.Add($" PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE = @PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_IMG_LASTROQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_IMG_LASTRO"] = value; //04
                      whereClauses.Add($" PRO_IMG_LASTRO = @PRO_IMG_LASTRO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByABN_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ABN_ID"] = value; //04
                      whereClauses.Add($" ABN_ID = @ABN_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySEG_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["SEG_ID"] = value; //04
                      whereClauses.Add($" SEG_ID = @SEG_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_RESINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_RESINA"] = value; //04
                      whereClauses.Add($" PRO_RESINA = @PRO_RESINA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ENDURECEDOR_MIOLOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ENDURECEDOR_MIOLO"] = value; //04
                      whereClauses.Add($" PRO_ENDURECEDOR_MIOLO = @PRO_ENDURECEDOR_MIOLO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_VINCOS_ONDULADEIRAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_VINCOS_ONDULADEIRA"] = value; //04
                      whereClauses.Add($" PRO_VINCOS_ONDULADEIRA = @PRO_VINCOS_ONDULADEIRA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ADICIONAL_ABA_SUPERIORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ADICIONAL_ABA_SUPERIOR"] = value; //04
                      whereClauses.Add($" PRO_ADICIONAL_ABA_SUPERIOR = @PRO_ADICIONAL_ABA_SUPERIOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ADICIONAL_ABA_INFERIORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ADICIONAL_ABA_INFERIOR"] = value; //04
                      whereClauses.Add($" PRO_ADICIONAL_ABA_INFERIOR = @PRO_ADICIONAL_ABA_INFERIOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_PROMOVE_RESINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PROMOVE_RESINA"] = value; //04
                      whereClauses.Add($" PRO_PROMOVE_RESINA = @PRO_PROMOVE_RESINA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_PROMOVE_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PROMOVE_DE"] = value; //04
                      whereClauses.Add($" PRO_PROMOVE_DE = @PRO_PROMOVE_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_PROMOVE_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PROMOVE_ATE"] = value; //04
                      whereClauses.Add($" PRO_PROMOVE_ATE = @PRO_PROMOVE_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_PROFUNDIDADE_VINCOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PROFUNDIDADE_VINCO"] = value; //04
                      whereClauses.Add($" PRO_PROFUNDIDADE_VINCO = @PRO_PROFUNDIDADE_VINCO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVIN_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["VIN_ID"] = value; //04
                      whereClauses.Add($" VIN_ID = @VIN_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_PROMOVE_PRODUTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PROMOVE_PRODUTO"] = value; //04
                      whereClauses.Add($" PRO_PROMOVE_PRODUTO = @PRO_PROMOVE_PRODUTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_TARAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TARA"] = value; //04
                      whereClauses.Add($" PRO_TARA = @PRO_TARA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_COMPRESSAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRESSAO"] = value; //04
                      whereClauses.Add($" PRO_COMPRESSAO = @PRO_COMPRESSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_COD_BARRAS_CAIXAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COD_BARRAS_CAIXA"] = value; //04
                      whereClauses.Add($" PRO_COD_BARRAS_CAIXA = @PRO_COD_BARRAS_CAIXA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCJN_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CJN_ID"] = value; //04
                      whereClauses.Add($" CJN_ID = @CJN_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRJ_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRJ_ID"] = value; //04
                      whereClauses.Add($" PRJ_ID = @PRJ_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_REFILE_LARGURAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_REFILE_LARGURA"] = value; //04
                      whereClauses.Add($" PRO_REFILE_LARGURA = @PRO_REFILE_LARGURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_REFILE_COMPRIMENTOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_REFILE_COMPRIMENTO"] = value; //04
                      whereClauses.Add($" PRO_REFILE_COMPRIMENTO = @PRO_REFILE_COMPRIMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_M2_PONTAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_M2_PONTA"] = value; //04
                      whereClauses.Add($" PRO_M2_PONTA = @PRO_M2_PONTA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_QTD_CORTES_PECA1Query(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QTD_CORTES_PECA1"] = value; //04
                      whereClauses.Add($" PRO_QTD_CORTES_PECA1 = @PRO_QTD_CORTES_PECA1 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_QTD_CORTES_PECA2Query(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QTD_CORTES_PECA2"] = value; //04
                      whereClauses.Add($" PRO_QTD_CORTES_PECA2 = @PRO_QTD_CORTES_PECA2 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_DIVISAO_MONTADAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_DIVISAO_MONTADA"] = value; //04
                      whereClauses.Add($" PRO_DIVISAO_MONTADA = @PRO_DIVISAO_MONTADA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_SEGMENTO_AQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_A"] = value; //04
                      whereClauses.Add($" PRO_SEGMENTO_A = @PRO_SEGMENTO_A ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_SEGMENTO_BQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_B"] = value; //04
                      whereClauses.Add($" PRO_SEGMENTO_B = @PRO_SEGMENTO_B ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_SEGMENTO_CQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_C"] = value; //04
                      whereClauses.Add($" PRO_SEGMENTO_C = @PRO_SEGMENTO_C ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_SEGMENTO_DQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_D"] = value; //04
                      whereClauses.Add($" PRO_SEGMENTO_D = @PRO_SEGMENTO_D ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_SEGMENTO_EQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_E"] = value; //04
                      whereClauses.Add($" PRO_SEGMENTO_E = @PRO_SEGMENTO_E ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_SEGMENTO_FQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_F"] = value; //04
                      whereClauses.Add($" PRO_SEGMENTO_F = @PRO_SEGMENTO_F ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_SEGMENTO_GQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_G"] = value; //04
                      whereClauses.Add($" PRO_SEGMENTO_G = @PRO_SEGMENTO_G ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_SEGMENTO_HQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_H"] = value; //04
                      whereClauses.Add($" PRO_SEGMENTO_H = @PRO_SEGMENTO_H ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_SEGMENTO_IQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_I"] = value; //04
                      whereClauses.Add($" PRO_SEGMENTO_I = @PRO_SEGMENTO_I ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_QTD_GRAMPOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QTD_GRAMPOS"] = value; //04
                      whereClauses.Add($" PRO_QTD_GRAMPOS = @PRO_QTD_GRAMPOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_AREA_REFILE_INTERNOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_AREA_REFILE_INTERNO"] = value; //04
                      whereClauses.Add($" PRO_AREA_REFILE_INTERNO = @PRO_AREA_REFILE_INTERNO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_AREA_REFILE_EXTERNOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_AREA_REFILE_EXTERNO"] = value; //04
                      whereClauses.Add($" PRO_AREA_REFILE_EXTERNO = @PRO_AREA_REFILE_EXTERNO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_PESO_REFILEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PESO_REFILE"] = value; //04
                      whereClauses.Add($" PRO_PESO_REFILE = @PRO_PESO_REFILE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ORELHA_INVERTIDAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ORELHA_INVERTIDA"] = value; //04
                      whereClauses.Add($" PRO_ORELHA_INVERTIDA = @PRO_ORELHA_INVERTIDA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ENDERECOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ENDERECO"] = value; //04
                      whereClauses.Add($" PRO_ENDERECO = @PRO_ENDERECO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_VINCULADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_VINCULADO"] = value; //04
                      whereClauses.Add($" PRO_ID_VINCULADO = @PRO_ID_VINCULADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_BATIDAS_PROXIMA_MANUTENCAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_BATIDAS_PROXIMA_MANUTENCAO"] = value; //04
                      whereClauses.Add($" PRO_BATIDAS_PROXIMA_MANUTENCAO = @PRO_BATIDAS_PROXIMA_MANUTENCAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ENTRADA_NA_MAQUINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ENTRADA_NA_MAQUINA"] = value; //04
                      whereClauses.Add($" PRO_ENTRADA_NA_MAQUINA = @PRO_ENTRADA_NA_MAQUINA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTDI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TDI_ID"] = value; //04
                      whereClauses.Add($" TDI_ID = @TDI_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_QUEBRA_VINCOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QUEBRA_VINCO"] = value; //04
                      whereClauses.Add($" PRO_QUEBRA_VINCO = @PRO_QUEBRA_VINCO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_LARGURA_FARDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LARGURA_FARDO"] = value; //04
                      whereClauses.Add($" PRO_LARGURA_FARDO = @PRO_LARGURA_FARDO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_COMPRIMENTO_FARDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRIMENTO_FARDO"] = value; //04
                      whereClauses.Add($" PRO_COMPRIMENTO_FARDO = @PRO_COMPRIMENTO_FARDO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ALTURA_FARDOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ALTURA_FARDO"] = value; //04
                      whereClauses.Add($" PRO_ALTURA_FARDO = @PRO_ALTURA_FARDO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_TIPO_CUSTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TIPO_CUSTO"] = value; //04
                      whereClauses.Add($" PRO_TIPO_CUSTO = @PRO_TIPO_CUSTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_GRUPO_CONTABILQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_GRUPO_CONTABIL"] = value; //04
                      whereClauses.Add($" PRO_GRUPO_CONTABIL = @PRO_GRUPO_CONTABIL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_CLASSE_CUSTO_01Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_CLASSE_CUSTO_01"] = value; //04
                      whereClauses.Add($" PRO_CLASSE_CUSTO_01 = @PRO_CLASSE_CUSTO_01 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_OBS_ALTERACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_OBS_ALTERACAO"] = value; //04
                      whereClauses.Add($" PRO_OBS_ALTERACAO = @PRO_OBS_ALTERACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIP_ID"] = value; //04
                      whereClauses.Add($" TIP_ID = @TIP_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_PECAS_POR_VEICULOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PECAS_POR_VEICULO"] = value; //04
                      whereClauses.Add($" PRO_PECAS_POR_VEICULO = @PRO_PECAS_POR_VEICULO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_DISTANCIA_ENTRE_VINCOSQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_DISTANCIA_ENTRE_VINCOS"] = value; //04
                      whereClauses.Add($" PRO_DISTANCIA_ENTRE_VINCOS = @PRO_DISTANCIA_ENTRE_VINCOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_DISTANCIA_ENTRE_VINCOS2Query(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_DISTANCIA_ENTRE_VINCOS2"] = value; //04
                      whereClauses.Add($" PRO_DISTANCIA_ENTRE_VINCOS2 = @PRO_DISTANCIA_ENTRE_VINCOS2 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_DISTANCIA_ENTRE_VINCOS3Query(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_DISTANCIA_ENTRE_VINCOS3"] = value; //04
                      whereClauses.Add($" PRO_DISTANCIA_ENTRE_VINCOS3 = @PRO_DISTANCIA_ENTRE_VINCOS3 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_OUTQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_OUT"] = value; //04
                      whereClauses.Add($" PRO_OUT = @PRO_OUT ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_FACAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_FACA"] = value; //04
                      whereClauses.Add($" PRO_ID_FACA = @PRO_ID_FACA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_CLICHEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_CLICHE"] = value; //04
                      whereClauses.Add($" PRO_ID_CLICHE = @PRO_ID_CLICHE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_TINTA_01Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TINTA_01"] = value; //04
                      whereClauses.Add($" PRO_ID_TINTA_01 = @PRO_ID_TINTA_01 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_TINTA_02Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TINTA_02"] = value; //04
                      whereClauses.Add($" PRO_ID_TINTA_02 = @PRO_ID_TINTA_02 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_TINTA_03Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TINTA_03"] = value; //04
                      whereClauses.Add($" PRO_ID_TINTA_03 = @PRO_ID_TINTA_03 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_TINTA_04Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TINTA_04"] = value; //04
                      whereClauses.Add($" PRO_ID_TINTA_04 = @PRO_ID_TINTA_04 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_TINTA_05Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TINTA_05"] = value; //04
                      whereClauses.Add($" PRO_ID_TINTA_05 = @PRO_ID_TINTA_05 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_FORROSUPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_FORROSUP"] = value; //04
                      whereClauses.Add($" PRO_ID_FORROSUP = @PRO_ID_FORROSUP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_CANTONEIRAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_CANTONEIRA"] = value; //04
                      whereClauses.Add($" PRO_ID_CANTONEIRA = @PRO_ID_CANTONEIRA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_PALETEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_PALETE"] = value; //04
                      whereClauses.Add($" PRO_ID_PALETE = @PRO_ID_PALETE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_TAMPOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TAMPO"] = value; //04
                      whereClauses.Add($" PRO_ID_TAMPO = @PRO_ID_TAMPO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_FORROINFQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_FORROINF"] = value; //04
                      whereClauses.Add($" PRO_ID_FORROINF = @PRO_ID_FORROINF ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_CHAPAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_CHAPA"] = value; //04
                      whereClauses.Add($" PRO_ID_CHAPA = @PRO_ID_CHAPA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_COMPOSICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_COMPOSICAO"] = value; //04
                      whereClauses.Add($" PRO_ID_COMPOSICAO = @PRO_ID_COMPOSICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_QUEBRA_VINCO_MAIORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QUEBRA_VINCO_MAIOR"] = value; //04
                      whereClauses.Add($" PRO_QUEBRA_VINCO_MAIOR = @PRO_QUEBRA_VINCO_MAIOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_QUEBRA_VINCO_MENORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QUEBRA_VINCO_MENOR"] = value; //04
                      whereClauses.Add($" PRO_QUEBRA_VINCO_MENOR = @PRO_QUEBRA_VINCO_MENOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CLI_ID"] = value; //04
                      whereClauses.Add($" CLI_ID = @CLI_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Id"] = value; //06
                      whereClauses.Add($" Id = @Id ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDescricaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Descricao"] = value; //06
                      whereClauses.Add($" Descricao = @Descricao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByStatusQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Status"] = value; //06
                      whereClauses.Add($" Status = @Status ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TenantID"] = value; //06
                      whereClauses.Add($" TenantID = @TenantID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDeletedQuery(bool value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Deleted"] = value; //06
                      whereClauses.Add($" Deleted = @Deleted ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Changed"] = value; //06
                      whereClauses.Add($" Changed = @Changed ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UserId"] = value; //06
                      whereClauses.Add($" UserId = @UserId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ESTOQUE_ATUALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ESTOQUE_ATUAL"] = value; //06
                      whereClauses.Add($" PRO_ESTOQUE_ATUAL = @PRO_ESTOQUE_ATUAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUNI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UNI_ID"] = value; //06
                      whereClauses.Add($" UNI_ID = @UNI_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_FARDOS_POR_CAMADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FARDOS_POR_CAMADA"] = value; //06
                      whereClauses.Add($" PRO_FARDOS_POR_CAMADA = @PRO_FARDOS_POR_CAMADA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_CAMADAS_POR_PALETEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_CAMADAS_POR_PALETE"] = value; //06
                      whereClauses.Add($" PRO_CAMADAS_POR_PALETE = @PRO_CAMADAS_POR_PALETE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_TIPO_IDENTIFICACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TIPO_IDENTIFICACAO"] = value; //06
                      whereClauses.Add($" PRO_TIPO_IDENTIFICACAO = @PRO_TIPO_IDENTIFICACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_GRUPO_PALETIZACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_GRUPO_PALETIZACAO"] = value; //06
                      whereClauses.Add($" PRO_GRUPO_PALETIZACAO = @PRO_GRUPO_PALETIZACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_PECAS_POR_FARDOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PECAS_POR_FARDO"] = value; //06
                      whereClauses.Add($" PRO_PECAS_POR_FARDO = @PRO_PECAS_POR_FARDO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_INTEGRACAO"] = value; //06
                      whereClauses.Add($" PRO_ID_INTEGRACAO = @PRO_ID_INTEGRACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_INTEGRACAO_ERP"] = value; //06
                      whereClauses.Add($" PRO_ID_INTEGRACAO_ERP = @PRO_ID_INTEGRACAO_ERP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ID"] = value; //06
                      whereClauses.Add($" GRP_ID = @GRP_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTEM_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TEM_ID"] = value; //06
                      whereClauses.Add($" TEM_ID = @TEM_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_LARGURA_PECAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LARGURA_PECA"] = value; //06
                      whereClauses.Add($" PRO_LARGURA_PECA = @PRO_LARGURA_PECA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_COMPRIMENTO_PECAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRIMENTO_PECA"] = value; //06
                      whereClauses.Add($" PRO_COMPRIMENTO_PECA = @PRO_COMPRIMENTO_PECA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ALTURA_PECAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ALTURA_PECA"] = value; //06
                      whereClauses.Add($" PRO_ALTURA_PECA = @PRO_ALTURA_PECA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_LARGURA_EMBALADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LARGURA_EMBALADA"] = value; //06
                      whereClauses.Add($" PRO_LARGURA_EMBALADA = @PRO_LARGURA_EMBALADA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_COMPRIMENTO_EMBALADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRIMENTO_EMBALADA"] = value; //06
                      whereClauses.Add($" PRO_COMPRIMENTO_EMBALADA = @PRO_COMPRIMENTO_EMBALADA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ALTURA_EMBALADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ALTURA_EMBALADA"] = value; //06
                      whereClauses.Add($" PRO_ALTURA_EMBALADA = @PRO_ALTURA_EMBALADA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_FRENTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FRENTE"] = value; //06
                      whereClauses.Add($" PRO_FRENTE = @PRO_FRENTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ROTACIONA_COMPRIMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ROTACIONA_COMPRIMENTO"] = value; //06
                      whereClauses.Add($" PRO_ROTACIONA_COMPRIMENTO = @PRO_ROTACIONA_COMPRIMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ROTACIONA_LARGURAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ROTACIONA_LARGURA"] = value; //06
                      whereClauses.Add($" PRO_ROTACIONA_LARGURA = @PRO_ROTACIONA_LARGURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ROTACIONA_ALTURAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ROTACIONA_ALTURA"] = value; //06
                      whereClauses.Add($" PRO_ROTACIONA_ALTURA = @PRO_ROTACIONA_ALTURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ESCALA_CORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ESCALA_COR"] = value; //06
                      whereClauses.Add($" PRO_ESCALA_COR = @PRO_ESCALA_COR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_SUB_ESCALA_CORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SUB_ESCALA_COR"] = value; //06
                      whereClauses.Add($" PRO_SUB_ESCALA_COR = @PRO_SUB_ESCALA_COR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_CUSTO_SUBIDA_ESCALA_CORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_CUSTO_SUBIDA_ESCALA_COR"] = value; //06
                      whereClauses.Add($" PRO_CUSTO_SUBIDA_ESCALA_COR = @PRO_CUSTO_SUBIDA_ESCALA_COR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_CUSTO_DECIDA_ESCALA_CORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_CUSTO_DECIDA_ESCALA_COR"] = value; //06
                      whereClauses.Add($" PRO_CUSTO_DECIDA_ESCALA_COR = @PRO_CUSTO_DECIDA_ESCALA_COR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTMP_TIPO_CARGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TMP_TIPO_CARGA"] = value; //06
                      whereClauses.Add($" TMP_TIPO_CARGA = @TMP_TIPO_CARGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_TEMPO_CARREGAMENTO_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TEMPO_CARREGAMENTO_UNITARIO"] = value; //06
                      whereClauses.Add($" PRO_TEMPO_CARREGAMENTO_UNITARIO = @PRO_TEMPO_CARREGAMENTO_UNITARIO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_TEMPO_DESCARREGAMENTO_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TEMPO_DESCARREGAMENTO_UNITARIO"] = value; //06
                      whereClauses.Add($" PRO_TEMPO_DESCARREGAMENTO_UNITARIO = @PRO_TEMPO_DESCARREGAMENTO_UNITARIO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_PERCENTUAL_JANELA_EMBARQUEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PERCENTUAL_JANELA_EMBARQUE"] = value; //06
                      whereClauses.Add($" PRO_PERCENTUAL_JANELA_EMBARQUE = @PRO_PERCENTUAL_JANELA_EMBARQUE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_TEMPO_PRODUCAO_CONJUNTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TEMPO_PRODUCAO_CONJUNTO"] = value; //06
                      whereClauses.Add($" PRO_TEMPO_PRODUCAO_CONJUNTO = @PRO_TEMPO_PRODUCAO_CONJUNTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_PECAS_DA_PECAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PECAS_DA_PECA"] = value; //06
                      whereClauses.Add($" PRO_PECAS_DA_PECA = @PRO_PECAS_DA_PECA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_TYPEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TYPE"] = value; //06
                      whereClauses.Add($" PRO_TYPE = @PRO_TYPE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_COLOR_HEXAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COLOR_HEXA"] = value; //06
                      whereClauses.Add($" PRO_COLOR_HEXA = @PRO_COLOR_HEXA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_VINCOS_LARGURAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_VINCOS_LARGURA"] = value; //06
                      whereClauses.Add($" PRO_VINCOS_LARGURA = @PRO_VINCOS_LARGURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_VINCOS_COMPRIMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_VINCOS_COMPRIMENTO"] = value; //06
                      whereClauses.Add($" PRO_VINCOS_COMPRIMENTO = @PRO_VINCOS_COMPRIMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_LARGURA_INTERNAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LARGURA_INTERNA"] = value; //06
                      whereClauses.Add($" PRO_LARGURA_INTERNA = @PRO_LARGURA_INTERNA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_COMPRIMENTO_INTERNAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRIMENTO_INTERNA"] = value; //06
                      whereClauses.Add($" PRO_COMPRIMENTO_INTERNA = @PRO_COMPRIMENTO_INTERNA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ALTURA_INTERNAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ALTURA_INTERNA"] = value; //06
                      whereClauses.Add($" PRO_ALTURA_INTERNA = @PRO_ALTURA_INTERNA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_COD_DESENHOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COD_DESENHO"] = value; //06
                      whereClauses.Add($" PRO_COD_DESENHO = @PRO_COD_DESENHO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_FECHAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FECHAMENTO"] = value; //06
                      whereClauses.Add($" PRO_FECHAMENTO = @PRO_FECHAMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_TIPO_LAPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TIPO_LAP"] = value; //06
                      whereClauses.Add($" PRO_TIPO_LAP = @PRO_TIPO_LAP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_TAMANHO_LAPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TAMANHO_LAP"] = value; //06
                      whereClauses.Add($" PRO_TAMANHO_LAP = @PRO_TAMANHO_LAP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_LAP_PROLONGADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LAP_PROLONGADO"] = value; //06
                      whereClauses.Add($" PRO_LAP_PROLONGADO = @PRO_LAP_PROLONGADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_TAMANHO_LAP_PROLONGQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TAMANHO_LAP_PROLONG"] = value; //06
                      whereClauses.Add($" PRO_TAMANHO_LAP_PROLONG = @PRO_TAMANHO_LAP_PROLONG ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ARRANJO_LARGURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ARRANJO_LARGURA"] = value; //06
                      whereClauses.Add($" PRO_ARRANJO_LARGURA = @PRO_ARRANJO_LARGURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ARRANJO_COMPRIMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ARRANJO_COMPRIMENTO"] = value; //06
                      whereClauses.Add($" PRO_ARRANJO_COMPRIMENTO = @PRO_ARRANJO_COMPRIMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_FITILHOS_FARDO_LARGQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FITILHOS_FARDO_LARG"] = value; //06
                      whereClauses.Add($" PRO_FITILHOS_FARDO_LARG = @PRO_FITILHOS_FARDO_LARG ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_FITILHOS_FARDO_COMPQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FITILHOS_FARDO_COMP"] = value; //06
                      whereClauses.Add($" PRO_FITILHOS_FARDO_COMP = @PRO_FITILHOS_FARDO_COMP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_FITILHOS_PALETE_LARGQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FITILHOS_PALETE_LARG"] = value; //06
                      whereClauses.Add($" PRO_FITILHOS_PALETE_LARG = @PRO_FITILHOS_PALETE_LARG ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_FITILHOS_PALETE_COMPQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FITILHOS_PALETE_COMP"] = value; //06
                      whereClauses.Add($" PRO_FITILHOS_PALETE_COMP = @PRO_FITILHOS_PALETE_COMP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_FILME_PALETEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_FILME_PALETE"] = value; //06
                      whereClauses.Add($" PRO_FILME_PALETE = @PRO_FILME_PALETE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_QTD_ESPELHOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QTD_ESPELHO"] = value; //06
                      whereClauses.Add($" PRO_QTD_ESPELHO = @PRO_QTD_ESPELHO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_CUSTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_CUSTO"] = value; //06
                      whereClauses.Add($" PRO_CUSTO = @PRO_CUSTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_AREA_LIQUIDAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_AREA_LIQUIDA"] = value; //06
                      whereClauses.Add($" PRO_AREA_LIQUIDA = @PRO_AREA_LIQUIDA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_PESOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PESO"] = value; //06
                      whereClauses.Add($" PRO_PESO = @PRO_PESO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_TOLERANCIA_DIMENSAO_CHAPA_DEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TOLERANCIA_DIMENSAO_CHAPA_DE"] = value; //06
                      whereClauses.Add($" PRO_TOLERANCIA_DIMENSAO_CHAPA_DE = @PRO_TOLERANCIA_DIMENSAO_CHAPA_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_TOLERANCIA_DIMENSAO_CHAPA_ATEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE"] = value; //06
                      whereClauses.Add($" PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE = @PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_IMG_LASTROQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_IMG_LASTRO"] = value; //06
                      whereClauses.Add($" PRO_IMG_LASTRO = @PRO_IMG_LASTRO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByABN_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ABN_ID"] = value; //06
                      whereClauses.Add($" ABN_ID = @ABN_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySEG_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["SEG_ID"] = value; //06
                      whereClauses.Add($" SEG_ID = @SEG_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_RESINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_RESINA"] = value; //06
                      whereClauses.Add($" PRO_RESINA = @PRO_RESINA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ENDURECEDOR_MIOLOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ENDURECEDOR_MIOLO"] = value; //06
                      whereClauses.Add($" PRO_ENDURECEDOR_MIOLO = @PRO_ENDURECEDOR_MIOLO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_VINCOS_ONDULADEIRAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_VINCOS_ONDULADEIRA"] = value; //06
                      whereClauses.Add($" PRO_VINCOS_ONDULADEIRA = @PRO_VINCOS_ONDULADEIRA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ADICIONAL_ABA_SUPERIORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ADICIONAL_ABA_SUPERIOR"] = value; //06
                      whereClauses.Add($" PRO_ADICIONAL_ABA_SUPERIOR = @PRO_ADICIONAL_ABA_SUPERIOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ADICIONAL_ABA_INFERIORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ADICIONAL_ABA_INFERIOR"] = value; //06
                      whereClauses.Add($" PRO_ADICIONAL_ABA_INFERIOR = @PRO_ADICIONAL_ABA_INFERIOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_PROMOVE_RESINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PROMOVE_RESINA"] = value; //06
                      whereClauses.Add($" PRO_PROMOVE_RESINA = @PRO_PROMOVE_RESINA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_PROMOVE_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PROMOVE_DE"] = value; //06
                      whereClauses.Add($" PRO_PROMOVE_DE = @PRO_PROMOVE_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_PROMOVE_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PROMOVE_ATE"] = value; //06
                      whereClauses.Add($" PRO_PROMOVE_ATE = @PRO_PROMOVE_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_PROFUNDIDADE_VINCOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PROFUNDIDADE_VINCO"] = value; //06
                      whereClauses.Add($" PRO_PROFUNDIDADE_VINCO = @PRO_PROFUNDIDADE_VINCO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVIN_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["VIN_ID"] = value; //06
                      whereClauses.Add($" VIN_ID = @VIN_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_PROMOVE_PRODUTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PROMOVE_PRODUTO"] = value; //06
                      whereClauses.Add($" PRO_PROMOVE_PRODUTO = @PRO_PROMOVE_PRODUTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_TARAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TARA"] = value; //06
                      whereClauses.Add($" PRO_TARA = @PRO_TARA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_COMPRESSAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRESSAO"] = value; //06
                      whereClauses.Add($" PRO_COMPRESSAO = @PRO_COMPRESSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_COD_BARRAS_CAIXAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COD_BARRAS_CAIXA"] = value; //06
                      whereClauses.Add($" PRO_COD_BARRAS_CAIXA = @PRO_COD_BARRAS_CAIXA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCJN_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CJN_ID"] = value; //06
                      whereClauses.Add($" CJN_ID = @CJN_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRJ_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRJ_ID"] = value; //06
                      whereClauses.Add($" PRJ_ID = @PRJ_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_REFILE_LARGURAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_REFILE_LARGURA"] = value; //06
                      whereClauses.Add($" PRO_REFILE_LARGURA = @PRO_REFILE_LARGURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_REFILE_COMPRIMENTOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_REFILE_COMPRIMENTO"] = value; //06
                      whereClauses.Add($" PRO_REFILE_COMPRIMENTO = @PRO_REFILE_COMPRIMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_M2_PONTAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_M2_PONTA"] = value; //06
                      whereClauses.Add($" PRO_M2_PONTA = @PRO_M2_PONTA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_QTD_CORTES_PECA1Query(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QTD_CORTES_PECA1"] = value; //06
                      whereClauses.Add($" PRO_QTD_CORTES_PECA1 = @PRO_QTD_CORTES_PECA1 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_QTD_CORTES_PECA2Query(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QTD_CORTES_PECA2"] = value; //06
                      whereClauses.Add($" PRO_QTD_CORTES_PECA2 = @PRO_QTD_CORTES_PECA2 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_DIVISAO_MONTADAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_DIVISAO_MONTADA"] = value; //06
                      whereClauses.Add($" PRO_DIVISAO_MONTADA = @PRO_DIVISAO_MONTADA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_SEGMENTO_AQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_A"] = value; //06
                      whereClauses.Add($" PRO_SEGMENTO_A = @PRO_SEGMENTO_A ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_SEGMENTO_BQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_B"] = value; //06
                      whereClauses.Add($" PRO_SEGMENTO_B = @PRO_SEGMENTO_B ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_SEGMENTO_CQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_C"] = value; //06
                      whereClauses.Add($" PRO_SEGMENTO_C = @PRO_SEGMENTO_C ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_SEGMENTO_DQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_D"] = value; //06
                      whereClauses.Add($" PRO_SEGMENTO_D = @PRO_SEGMENTO_D ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_SEGMENTO_EQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_E"] = value; //06
                      whereClauses.Add($" PRO_SEGMENTO_E = @PRO_SEGMENTO_E ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_SEGMENTO_FQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_F"] = value; //06
                      whereClauses.Add($" PRO_SEGMENTO_F = @PRO_SEGMENTO_F ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_SEGMENTO_GQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_G"] = value; //06
                      whereClauses.Add($" PRO_SEGMENTO_G = @PRO_SEGMENTO_G ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_SEGMENTO_HQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_H"] = value; //06
                      whereClauses.Add($" PRO_SEGMENTO_H = @PRO_SEGMENTO_H ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_SEGMENTO_IQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_SEGMENTO_I"] = value; //06
                      whereClauses.Add($" PRO_SEGMENTO_I = @PRO_SEGMENTO_I ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_QTD_GRAMPOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QTD_GRAMPOS"] = value; //06
                      whereClauses.Add($" PRO_QTD_GRAMPOS = @PRO_QTD_GRAMPOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_AREA_REFILE_INTERNOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_AREA_REFILE_INTERNO"] = value; //06
                      whereClauses.Add($" PRO_AREA_REFILE_INTERNO = @PRO_AREA_REFILE_INTERNO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_AREA_REFILE_EXTERNOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_AREA_REFILE_EXTERNO"] = value; //06
                      whereClauses.Add($" PRO_AREA_REFILE_EXTERNO = @PRO_AREA_REFILE_EXTERNO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_PESO_REFILEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PESO_REFILE"] = value; //06
                      whereClauses.Add($" PRO_PESO_REFILE = @PRO_PESO_REFILE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ORELHA_INVERTIDAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ORELHA_INVERTIDA"] = value; //06
                      whereClauses.Add($" PRO_ORELHA_INVERTIDA = @PRO_ORELHA_INVERTIDA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ENDERECOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ENDERECO"] = value; //06
                      whereClauses.Add($" PRO_ENDERECO = @PRO_ENDERECO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_VINCULADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_VINCULADO"] = value; //06
                      whereClauses.Add($" PRO_ID_VINCULADO = @PRO_ID_VINCULADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_BATIDAS_PROXIMA_MANUTENCAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_BATIDAS_PROXIMA_MANUTENCAO"] = value; //06
                      whereClauses.Add($" PRO_BATIDAS_PROXIMA_MANUTENCAO = @PRO_BATIDAS_PROXIMA_MANUTENCAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ENTRADA_NA_MAQUINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ENTRADA_NA_MAQUINA"] = value; //06
                      whereClauses.Add($" PRO_ENTRADA_NA_MAQUINA = @PRO_ENTRADA_NA_MAQUINA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTDI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TDI_ID"] = value; //06
                      whereClauses.Add($" TDI_ID = @TDI_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_QUEBRA_VINCOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QUEBRA_VINCO"] = value; //06
                      whereClauses.Add($" PRO_QUEBRA_VINCO = @PRO_QUEBRA_VINCO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_LARGURA_FARDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LARGURA_FARDO"] = value; //06
                      whereClauses.Add($" PRO_LARGURA_FARDO = @PRO_LARGURA_FARDO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_COMPRIMENTO_FARDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRIMENTO_FARDO"] = value; //06
                      whereClauses.Add($" PRO_COMPRIMENTO_FARDO = @PRO_COMPRIMENTO_FARDO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ALTURA_FARDOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ALTURA_FARDO"] = value; //06
                      whereClauses.Add($" PRO_ALTURA_FARDO = @PRO_ALTURA_FARDO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_TIPO_CUSTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_TIPO_CUSTO"] = value; //06
                      whereClauses.Add($" PRO_TIPO_CUSTO = @PRO_TIPO_CUSTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_GRUPO_CONTABILQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_GRUPO_CONTABIL"] = value; //06
                      whereClauses.Add($" PRO_GRUPO_CONTABIL = @PRO_GRUPO_CONTABIL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_CLASSE_CUSTO_01Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_CLASSE_CUSTO_01"] = value; //06
                      whereClauses.Add($" PRO_CLASSE_CUSTO_01 = @PRO_CLASSE_CUSTO_01 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_OBS_ALTERACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_OBS_ALTERACAO"] = value; //06
                      whereClauses.Add($" PRO_OBS_ALTERACAO = @PRO_OBS_ALTERACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIP_ID"] = value; //06
                      whereClauses.Add($" TIP_ID = @TIP_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_PECAS_POR_VEICULOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_PECAS_POR_VEICULO"] = value; //06
                      whereClauses.Add($" PRO_PECAS_POR_VEICULO = @PRO_PECAS_POR_VEICULO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_DISTANCIA_ENTRE_VINCOSQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_DISTANCIA_ENTRE_VINCOS"] = value; //06
                      whereClauses.Add($" PRO_DISTANCIA_ENTRE_VINCOS = @PRO_DISTANCIA_ENTRE_VINCOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_DISTANCIA_ENTRE_VINCOS2Query(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_DISTANCIA_ENTRE_VINCOS2"] = value; //06
                      whereClauses.Add($" PRO_DISTANCIA_ENTRE_VINCOS2 = @PRO_DISTANCIA_ENTRE_VINCOS2 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_DISTANCIA_ENTRE_VINCOS3Query(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_DISTANCIA_ENTRE_VINCOS3"] = value; //06
                      whereClauses.Add($" PRO_DISTANCIA_ENTRE_VINCOS3 = @PRO_DISTANCIA_ENTRE_VINCOS3 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_OUTQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_OUT"] = value; //06
                      whereClauses.Add($" PRO_OUT = @PRO_OUT ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_FACAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_FACA"] = value; //06
                      whereClauses.Add($" PRO_ID_FACA = @PRO_ID_FACA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_CLICHEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_CLICHE"] = value; //06
                      whereClauses.Add($" PRO_ID_CLICHE = @PRO_ID_CLICHE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_TINTA_01Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TINTA_01"] = value; //06
                      whereClauses.Add($" PRO_ID_TINTA_01 = @PRO_ID_TINTA_01 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_TINTA_02Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TINTA_02"] = value; //06
                      whereClauses.Add($" PRO_ID_TINTA_02 = @PRO_ID_TINTA_02 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_TINTA_03Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TINTA_03"] = value; //06
                      whereClauses.Add($" PRO_ID_TINTA_03 = @PRO_ID_TINTA_03 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_TINTA_04Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TINTA_04"] = value; //06
                      whereClauses.Add($" PRO_ID_TINTA_04 = @PRO_ID_TINTA_04 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_TINTA_05Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TINTA_05"] = value; //06
                      whereClauses.Add($" PRO_ID_TINTA_05 = @PRO_ID_TINTA_05 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_FORROSUPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_FORROSUP"] = value; //06
                      whereClauses.Add($" PRO_ID_FORROSUP = @PRO_ID_FORROSUP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_CANTONEIRAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_CANTONEIRA"] = value; //06
                      whereClauses.Add($" PRO_ID_CANTONEIRA = @PRO_ID_CANTONEIRA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_PALETEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_PALETE"] = value; //06
                      whereClauses.Add($" PRO_ID_PALETE = @PRO_ID_PALETE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_TAMPOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TAMPO"] = value; //06
                      whereClauses.Add($" PRO_ID_TAMPO = @PRO_ID_TAMPO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_FORROINFQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_FORROINF"] = value; //06
                      whereClauses.Add($" PRO_ID_FORROINF = @PRO_ID_FORROINF ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_CHAPAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_CHAPA"] = value; //06
                      whereClauses.Add($" PRO_ID_CHAPA = @PRO_ID_CHAPA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_COMPOSICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_COMPOSICAO"] = value; //06
                      whereClauses.Add($" PRO_ID_COMPOSICAO = @PRO_ID_COMPOSICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_QUEBRA_VINCO_MAIORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QUEBRA_VINCO_MAIOR"] = value; //06
                      whereClauses.Add($" PRO_QUEBRA_VINCO_MAIOR = @PRO_QUEBRA_VINCO_MAIOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_QUEBRA_VINCO_MENORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_QUEBRA_VINCO_MENOR"] = value; //06
                      whereClauses.Add($" PRO_QUEBRA_VINCO_MENOR = @PRO_QUEBRA_VINCO_MENOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, Descricao, Status, TenantID, Deleted, Changed, UserId, PRO_ESTOQUE_ATUAL, UNI_ID, PRO_FARDOS_POR_CAMADA, PRO_CAMADAS_POR_PALETE, PRO_TIPO_IDENTIFICACAO, PRO_GRUPO_PALETIZACAO, PRO_PECAS_POR_FARDO, PRO_ID_INTEGRACAO, PRO_ID_INTEGRACAO_ERP, GRP_ID, TEM_ID, PRO_LARGURA_PECA, PRO_COMPRIMENTO_PECA, PRO_ALTURA_PECA, PRO_LARGURA_EMBALADA, PRO_COMPRIMENTO_EMBALADA, PRO_ALTURA_EMBALADA, PRO_FRENTE, PRO_ROTACIONA_COMPRIMENTO, PRO_ROTACIONA_LARGURA, PRO_ROTACIONA_ALTURA, PRO_ESCALA_COR, PRO_SUB_ESCALA_COR, PRO_CUSTO_SUBIDA_ESCALA_COR, PRO_CUSTO_DECIDA_ESCALA_COR, TMP_TIPO_CARGA, PRO_TEMPO_CARREGAMENTO_UNITARIO, PRO_TEMPO_DESCARREGAMENTO_UNITARIO, PRO_PERCENTUAL_JANELA_EMBARQUE, PRO_TEMPO_PRODUCAO_CONJUNTO, PRO_PECAS_DA_PECA, PRO_TYPE, PRO_COLOR_HEXA, PRO_VINCOS_LARGURA, PRO_VINCOS_COMPRIMENTO, PRO_LARGURA_INTERNA, PRO_COMPRIMENTO_INTERNA, PRO_ALTURA_INTERNA, PRO_COD_DESENHO, PRO_FECHAMENTO, PRO_TIPO_LAP, PRO_TAMANHO_LAP, PRO_LAP_PROLONGADO, PRO_TAMANHO_LAP_PROLONG, PRO_ARRANJO_LARGURA, PRO_ARRANJO_COMPRIMENTO, PRO_FITILHOS_FARDO_LARG, PRO_FITILHOS_FARDO_COMP, PRO_FITILHOS_PALETE_LARG, PRO_FITILHOS_PALETE_COMP, PRO_FILME_PALETE, PRO_QTD_ESPELHO, PRO_CUSTO, PRO_AREA_LIQUIDA, PRO_PESO, PRO_TOLERANCIA_DIMENSAO_CHAPA_DE, PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE, PRO_IMG_LASTRO, ABN_ID, SEG_ID, PRO_RESINA, PRO_ENDURECEDOR_MIOLO, PRO_VINCOS_ONDULADEIRA, PRO_ADICIONAL_ABA_SUPERIOR, PRO_ADICIONAL_ABA_INFERIOR, PRO_PROMOVE_RESINA, PRO_PROMOVE_DE, PRO_PROMOVE_ATE, PRO_PROFUNDIDADE_VINCO, VIN_ID, PRO_PROMOVE_PRODUTO, PRO_TARA, PRO_COMPRESSAO, PRO_COD_BARRAS_CAIXA, CJN_ID, PRJ_ID, PRO_REFILE_LARGURA, PRO_REFILE_COMPRIMENTO, PRO_M2_PONTA, PRO_QTD_CORTES_PECA1, PRO_QTD_CORTES_PECA2, PRO_DIVISAO_MONTADA, PRO_SEGMENTO_A, PRO_SEGMENTO_B, PRO_SEGMENTO_C, PRO_SEGMENTO_D, PRO_SEGMENTO_E, PRO_SEGMENTO_F, PRO_SEGMENTO_G, PRO_SEGMENTO_H, PRO_SEGMENTO_I, PRO_QTD_GRAMPOS, PRO_AREA_REFILE_INTERNO, PRO_AREA_REFILE_EXTERNO, PRO_PESO_REFILE, PRO_ORELHA_INVERTIDA, PRO_ENDERECO, PRO_ID_VINCULADO, PRO_BATIDAS_PROXIMA_MANUTENCAO, PRO_ENTRADA_NA_MAQUINA, TDI_ID, PRO_QUEBRA_VINCO, PRO_LARGURA_FARDO, PRO_COMPRIMENTO_FARDO, PRO_ALTURA_FARDO, PRO_TIPO_CUSTO, PRO_GRUPO_CONTABIL, PRO_CLASSE_CUSTO_01, PRO_OBS_ALTERACAO, TIP_ID, PRO_PECAS_POR_VEICULO, PRO_DISTANCIA_ENTRE_VINCOS, PRO_DISTANCIA_ENTRE_VINCOS2, PRO_DISTANCIA_ENTRE_VINCOS3, PRO_OUT, PRO_ID_FACA, PRO_ID_CLICHE, PRO_ID_TINTA_01, PRO_ID_TINTA_02, PRO_ID_TINTA_03, PRO_ID_TINTA_04, PRO_ID_TINTA_05, PRO_ID_FORROSUP, PRO_ID_CANTONEIRA, PRO_ID_PALETE, PRO_ID_TAMPO, PRO_ID_FORROINF, PRO_ID_CHAPA, PRO_ID_COMPOSICAO, PRO_QUEBRA_VINCO_MAIOR, PRO_QUEBRA_VINCO_MENOR, CLI_ID FROM Produto ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CLI_ID"] = value; //06
                      whereClauses.Add($" CLI_ID = @CLI_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration