// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IProdutoQueryWrite 
     {
        public QueryModel InserirProdutoQuery(IProdutoEntity Produto);
        public QueryModel UpdateProdutoQuery(IProdutoEntity Produto);
        QueryModel UpdateDescricao(string id, string value);
        QueryModel UpdateStatus(string id, string value);
        QueryModel UpdateTenantID(string id, int value);
        QueryModel UpdateDeleted(string id, bool value);
        QueryModel UpdateChanged(string id, DateTime value);
        QueryModel UpdateUserId(string id, int value);
        QueryModel UpdatePRO_ESTOQUE_ATUAL(string id, Decimal value);
        QueryModel UpdateUNI_ID(string id, string value);
        QueryModel UpdatePRO_FARDOS_POR_CAMADA(string id, Decimal value);
        QueryModel UpdatePRO_CAMADAS_POR_PALETE(string id, Decimal value);
        QueryModel UpdatePRO_TIPO_IDENTIFICACAO(string id, int value);
        QueryModel UpdatePRO_GRUPO_PALETIZACAO(string id, string value);
        QueryModel UpdatePRO_PECAS_POR_FARDO(string id, Decimal value);
        QueryModel UpdatePRO_ID_INTEGRACAO(string id, string value);
        QueryModel UpdatePRO_ID_INTEGRACAO_ERP(string id, string value);
        QueryModel UpdateGRP_ID(string id, string value);
        QueryModel UpdateTEM_ID(string id, int value);
        QueryModel UpdatePRO_LARGURA_PECA(string id, Decimal value);
        QueryModel UpdatePRO_COMPRIMENTO_PECA(string id, Decimal value);
        QueryModel UpdatePRO_ALTURA_PECA(string id, Decimal value);
        QueryModel UpdatePRO_LARGURA_EMBALADA(string id, Decimal value);
        QueryModel UpdatePRO_COMPRIMENTO_EMBALADA(string id, Decimal value);
        QueryModel UpdatePRO_ALTURA_EMBALADA(string id, Decimal value);
        QueryModel UpdatePRO_FRENTE(string id, string value);
        QueryModel UpdatePRO_ROTACIONA_COMPRIMENTO(string id, string value);
        QueryModel UpdatePRO_ROTACIONA_LARGURA(string id, string value);
        QueryModel UpdatePRO_ROTACIONA_ALTURA(string id, string value);
        QueryModel UpdatePRO_ESCALA_COR(string id, string value);
        QueryModel UpdatePRO_SUB_ESCALA_COR(string id, string value);
        QueryModel UpdatePRO_CUSTO_SUBIDA_ESCALA_COR(string id, Decimal value);
        QueryModel UpdatePRO_CUSTO_DECIDA_ESCALA_COR(string id, Decimal value);
        QueryModel UpdateTMP_TIPO_CARGA(string id, string value);
        QueryModel UpdatePRO_TEMPO_CARREGAMENTO_UNITARIO(string id, Decimal value);
        QueryModel UpdatePRO_TEMPO_DESCARREGAMENTO_UNITARIO(string id, Decimal value);
        QueryModel UpdatePRO_PERCENTUAL_JANELA_EMBARQUE(string id, Decimal value);
        QueryModel UpdatePRO_TEMPO_PRODUCAO_CONJUNTO(string id, Decimal value);
        QueryModel UpdatePRO_PECAS_DA_PECA(string id, Decimal value);
        QueryModel UpdatePRO_TYPE(string id, int value);
        QueryModel UpdatePRO_COLOR_HEXA(string id, string value);
        QueryModel UpdatePRO_VINCOS_LARGURA(string id, string value);
        QueryModel UpdatePRO_VINCOS_COMPRIMENTO(string id, string value);
        QueryModel UpdatePRO_LARGURA_INTERNA(string id, Decimal value);
        QueryModel UpdatePRO_COMPRIMENTO_INTERNA(string id, Decimal value);
        QueryModel UpdatePRO_ALTURA_INTERNA(string id, Decimal value);
        QueryModel UpdatePRO_COD_DESENHO(string id, string value);
        QueryModel UpdatePRO_FECHAMENTO(string id, string value);
        QueryModel UpdatePRO_TIPO_LAP(string id, string value);
        QueryModel UpdatePRO_TAMANHO_LAP(string id, Decimal value);
        QueryModel UpdatePRO_LAP_PROLONGADO(string id, string value);
        QueryModel UpdatePRO_TAMANHO_LAP_PROLONG(string id, Decimal value);
        QueryModel UpdatePRO_ARRANJO_LARGURA(string id, Decimal value);
        QueryModel UpdatePRO_ARRANJO_COMPRIMENTO(string id, Decimal value);
        QueryModel UpdatePRO_FITILHOS_FARDO_LARG(string id, int value);
        QueryModel UpdatePRO_FITILHOS_FARDO_COMP(string id, int value);
        QueryModel UpdatePRO_FITILHOS_PALETE_LARG(string id, int value);
        QueryModel UpdatePRO_FITILHOS_PALETE_COMP(string id, int value);
        QueryModel UpdatePRO_FILME_PALETE(string id, int value);
        QueryModel UpdatePRO_QTD_ESPELHO(string id, int value);
        QueryModel UpdatePRO_CUSTO(string id, Decimal value);
        QueryModel UpdatePRO_AREA_LIQUIDA(string id, Decimal value);
        QueryModel UpdatePRO_PESO(string id, Decimal value);
        QueryModel UpdatePRO_TOLERANCIA_DIMENSAO_CHAPA_DE(string id, int value);
        QueryModel UpdatePRO_TOLERANCIA_DIMENSAO_CHAPA_ATE(string id, int value);
        QueryModel UpdatePRO_IMG_LASTRO(string id, string value);
        QueryModel UpdateABN_ID(string id, string value);
        QueryModel UpdateSEG_ID(string id, int value);
        QueryModel UpdatePRO_RESINA(string id, string value);
        QueryModel UpdatePRO_ENDURECEDOR_MIOLO(string id, string value);
        QueryModel UpdatePRO_VINCOS_ONDULADEIRA(string id, string value);
        QueryModel UpdatePRO_ADICIONAL_ABA_SUPERIOR(string id, int value);
        QueryModel UpdatePRO_ADICIONAL_ABA_INFERIOR(string id, int value);
        QueryModel UpdatePRO_PROMOVE_RESINA(string id, string value);
        QueryModel UpdatePRO_PROMOVE_DE(string id, Decimal value);
        QueryModel UpdatePRO_PROMOVE_ATE(string id, Decimal value);
        QueryModel UpdatePRO_PROFUNDIDADE_VINCO(string id, int value);
        QueryModel UpdateVIN_ID(string id, int value);
        QueryModel UpdatePRO_PROMOVE_PRODUTO(string id, string value);
        QueryModel UpdatePRO_TARA(string id, Decimal value);
        QueryModel UpdatePRO_COMPRESSAO(string id, Decimal value);
        QueryModel UpdatePRO_COD_BARRAS_CAIXA(string id, string value);
        QueryModel UpdateCJN_ID(string id, string value);
        QueryModel UpdatePRJ_ID(string id, string value);
        QueryModel UpdatePRO_REFILE_LARGURA(string id, int value);
        QueryModel UpdatePRO_REFILE_COMPRIMENTO(string id, int value);
        QueryModel UpdatePRO_M2_PONTA(string id, Decimal value);
        QueryModel UpdatePRO_QTD_CORTES_PECA1(string id, int value);
        QueryModel UpdatePRO_QTD_CORTES_PECA2(string id, int value);
        QueryModel UpdatePRO_DIVISAO_MONTADA(string id, string value);
        QueryModel UpdatePRO_SEGMENTO_A(string id, Decimal value);
        QueryModel UpdatePRO_SEGMENTO_B(string id, Decimal value);
        QueryModel UpdatePRO_SEGMENTO_C(string id, Decimal value);
        QueryModel UpdatePRO_SEGMENTO_D(string id, Decimal value);
        QueryModel UpdatePRO_SEGMENTO_E(string id, Decimal value);
        QueryModel UpdatePRO_SEGMENTO_F(string id, Decimal value);
        QueryModel UpdatePRO_SEGMENTO_G(string id, Decimal value);
        QueryModel UpdatePRO_SEGMENTO_H(string id, Decimal value);
        QueryModel UpdatePRO_SEGMENTO_I(string id, Decimal value);
        QueryModel UpdatePRO_QTD_GRAMPOS(string id, Decimal value);
        QueryModel UpdatePRO_AREA_REFILE_INTERNO(string id, Decimal value);
        QueryModel UpdatePRO_AREA_REFILE_EXTERNO(string id, Decimal value);
        QueryModel UpdatePRO_PESO_REFILE(string id, Decimal value);
        QueryModel UpdatePRO_ORELHA_INVERTIDA(string id, string value);
        QueryModel UpdatePRO_ENDERECO(string id, string value);
        QueryModel UpdatePRO_ID_VINCULADO(string id, string value);
        QueryModel UpdatePRO_BATIDAS_PROXIMA_MANUTENCAO(string id, int value);
        QueryModel UpdatePRO_ENTRADA_NA_MAQUINA(string id, string value);
        QueryModel UpdateTDI_ID(string id, string value);
        QueryModel UpdatePRO_QUEBRA_VINCO(string id, int value);
        QueryModel UpdatePRO_LARGURA_FARDO(string id, int value);
        QueryModel UpdatePRO_COMPRIMENTO_FARDO(string id, int value);
        QueryModel UpdatePRO_ALTURA_FARDO(string id, Decimal value);
        QueryModel UpdatePRO_TIPO_CUSTO(string id, string value);
        QueryModel UpdatePRO_GRUPO_CONTABIL(string id, string value);
        QueryModel UpdatePRO_CLASSE_CUSTO_01(string id, string value);
        QueryModel UpdatePRO_OBS_ALTERACAO(string id, string value);
        QueryModel UpdateTIP_ID(string id, int value);
        QueryModel UpdatePRO_PECAS_POR_VEICULO(string id, Decimal value);
        QueryModel UpdatePRO_DISTANCIA_ENTRE_VINCOS(string id, int value);
        QueryModel UpdatePRO_DISTANCIA_ENTRE_VINCOS2(string id, int value);
        QueryModel UpdatePRO_DISTANCIA_ENTRE_VINCOS3(string id, int value);
        QueryModel UpdatePRO_OUT(string id, int value);
        QueryModel UpdatePRO_ID_FACA(string id, string value);
        QueryModel UpdatePRO_ID_CLICHE(string id, string value);
        QueryModel UpdatePRO_ID_TINTA_01(string id, string value);
        QueryModel UpdatePRO_ID_TINTA_02(string id, string value);
        QueryModel UpdatePRO_ID_TINTA_03(string id, string value);
        QueryModel UpdatePRO_ID_TINTA_04(string id, string value);
        QueryModel UpdatePRO_ID_TINTA_05(string id, string value);
        QueryModel UpdatePRO_ID_FORROSUP(string id, string value);
        QueryModel UpdatePRO_ID_CANTONEIRA(string id, string value);
        QueryModel UpdatePRO_ID_PALETE(string id, string value);
        QueryModel UpdatePRO_ID_TAMPO(string id, string value);
        QueryModel UpdatePRO_ID_FORROINF(string id, string value);
        QueryModel UpdatePRO_ID_CHAPA(string id, string value);
        QueryModel UpdatePRO_ID_COMPOSICAO(string id, string value);
        QueryModel UpdatePRO_QUEBRA_VINCO_MAIOR(string id, int value);
        QueryModel UpdatePRO_QUEBRA_VINCO_MENOR(string id, int value);
        QueryModel UpdateCLI_ID(string id, string value);
        public QueryModel DeleteProdutoQuery(IProdutoEntity Produto);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration