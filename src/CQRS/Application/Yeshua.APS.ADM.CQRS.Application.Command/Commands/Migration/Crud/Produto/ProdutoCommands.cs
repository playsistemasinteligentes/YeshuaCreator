// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration
// </yeshua>

using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct ProdutoCrudCommand : ICommand
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public Decimal? PRO_ESTOQUE_ATUAL { get; set; }
        public string UNI_ID { get; set; }
        public Decimal? PRO_FARDOS_POR_CAMADA { get; set; }
        public Decimal? PRO_CAMADAS_POR_PALETE { get; set; }
        public int? PRO_TIPO_IDENTIFICACAO { get; set; }
        public string PRO_GRUPO_PALETIZACAO { get; set; }
        public Decimal? PRO_PECAS_POR_FARDO { get; set; }
        public string PRO_ID_INTEGRACAO { get; set; }
        public string PRO_ID_INTEGRACAO_ERP { get; set; }
        public string GRP_ID { get; set; }
        public int? TEM_ID { get; set; }
        public Decimal? PRO_LARGURA_PECA { get; set; }
        public Decimal? PRO_COMPRIMENTO_PECA { get; set; }
        public Decimal? PRO_ALTURA_PECA { get; set; }
        public Decimal? PRO_LARGURA_EMBALADA { get; set; }
        public Decimal? PRO_COMPRIMENTO_EMBALADA { get; set; }
        public Decimal? PRO_ALTURA_EMBALADA { get; set; }
        public string PRO_FRENTE { get; set; }
        public string PRO_ROTACIONA_COMPRIMENTO { get; set; }
        public string PRO_ROTACIONA_LARGURA { get; set; }
        public string PRO_ROTACIONA_ALTURA { get; set; }
        public string PRO_ESCALA_COR { get; set; }
        public string PRO_SUB_ESCALA_COR { get; set; }
        public Decimal? PRO_CUSTO_SUBIDA_ESCALA_COR { get; set; }
        public Decimal? PRO_CUSTO_DECIDA_ESCALA_COR { get; set; }
        public string TMP_TIPO_CARGA { get; set; }
        public Decimal? PRO_TEMPO_CARREGAMENTO_UNITARIO { get; set; }
        public Decimal? PRO_TEMPO_DESCARREGAMENTO_UNITARIO { get; set; }
        public Decimal? PRO_PERCENTUAL_JANELA_EMBARQUE { get; set; }
        public Decimal? PRO_TEMPO_PRODUCAO_CONJUNTO { get; set; }
        public Decimal? PRO_PECAS_DA_PECA { get; set; }
        public int? PRO_TYPE { get; set; }
        public string PRO_COLOR_HEXA { get; set; }
        public string PRO_VINCOS_LARGURA { get; set; }
        public string PRO_VINCOS_COMPRIMENTO { get; set; }
        public Decimal? PRO_LARGURA_INTERNA { get; set; }
        public Decimal? PRO_COMPRIMENTO_INTERNA { get; set; }
        public Decimal? PRO_ALTURA_INTERNA { get; set; }
        public string PRO_COD_DESENHO { get; set; }
        public string PRO_FECHAMENTO { get; set; }
        public string PRO_TIPO_LAP { get; set; }
        public Decimal? PRO_TAMANHO_LAP { get; set; }
        public string PRO_LAP_PROLONGADO { get; set; }
        public Decimal? PRO_TAMANHO_LAP_PROLONG { get; set; }
        public Decimal? PRO_ARRANJO_LARGURA { get; set; }
        public Decimal? PRO_ARRANJO_COMPRIMENTO { get; set; }
        public int? PRO_FITILHOS_FARDO_LARG { get; set; }
        public int? PRO_FITILHOS_FARDO_COMP { get; set; }
        public int? PRO_FITILHOS_PALETE_LARG { get; set; }
        public int? PRO_FITILHOS_PALETE_COMP { get; set; }
        public int? PRO_FILME_PALETE { get; set; }
        public int? PRO_QTD_ESPELHO { get; set; }
        public Decimal? PRO_CUSTO { get; set; }
        public Decimal? PRO_AREA_LIQUIDA { get; set; }
        public Decimal? PRO_PESO { get; set; }
        public int? PRO_TOLERANCIA_DIMENSAO_CHAPA_DE { get; set; }
        public int? PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE { get; set; }
        public string PRO_IMG_LASTRO { get; set; }
        public string ABN_ID { get; set; }
        public int? SEG_ID { get; set; }
        public string PRO_RESINA { get; set; }
        public string PRO_ENDURECEDOR_MIOLO { get; set; }
        public string PRO_VINCOS_ONDULADEIRA { get; set; }
        public int? PRO_ADICIONAL_ABA_SUPERIOR { get; set; }
        public int? PRO_ADICIONAL_ABA_INFERIOR { get; set; }
        public string PRO_PROMOVE_RESINA { get; set; }
        public Decimal? PRO_PROMOVE_DE { get; set; }
        public Decimal? PRO_PROMOVE_ATE { get; set; }
        public int? PRO_PROFUNDIDADE_VINCO { get; set; }
        public int VIN_ID { get; set; }
        public string PRO_PROMOVE_PRODUTO { get; set; }
        public Decimal? PRO_TARA { get; set; }
        public Decimal? PRO_COMPRESSAO { get; set; }
        public string PRO_COD_BARRAS_CAIXA { get; set; }
        public string CJN_ID { get; set; }
        public string PRJ_ID { get; set; }
        public int? PRO_REFILE_LARGURA { get; set; }
        public int? PRO_REFILE_COMPRIMENTO { get; set; }
        public Decimal? PRO_M2_PONTA { get; set; }
        public int? PRO_QTD_CORTES_PECA1 { get; set; }
        public int? PRO_QTD_CORTES_PECA2 { get; set; }
        public string PRO_DIVISAO_MONTADA { get; set; }
        public Decimal? PRO_SEGMENTO_A { get; set; }
        public Decimal? PRO_SEGMENTO_B { get; set; }
        public Decimal? PRO_SEGMENTO_C { get; set; }
        public Decimal? PRO_SEGMENTO_D { get; set; }
        public Decimal? PRO_SEGMENTO_E { get; set; }
        public Decimal? PRO_SEGMENTO_F { get; set; }
        public Decimal? PRO_SEGMENTO_G { get; set; }
        public Decimal? PRO_SEGMENTO_H { get; set; }
        public Decimal? PRO_SEGMENTO_I { get; set; }
        public Decimal? PRO_QTD_GRAMPOS { get; set; }
        public Decimal? PRO_AREA_REFILE_INTERNO { get; set; }
        public Decimal? PRO_AREA_REFILE_EXTERNO { get; set; }
        public Decimal? PRO_PESO_REFILE { get; set; }
        public string PRO_ORELHA_INVERTIDA { get; set; }
        public string PRO_ENDERECO { get; set; }
        public string PRO_ID_VINCULADO { get; set; }
        public int? PRO_BATIDAS_PROXIMA_MANUTENCAO { get; set; }
        public string PRO_ENTRADA_NA_MAQUINA { get; set; }
        public string TDI_ID { get; set; }
        public int? PRO_QUEBRA_VINCO { get; set; }
        public int? PRO_LARGURA_FARDO { get; set; }
        public int? PRO_COMPRIMENTO_FARDO { get; set; }
        public Decimal? PRO_ALTURA_FARDO { get; set; }
        public string PRO_TIPO_CUSTO { get; set; }
        public string PRO_GRUPO_CONTABIL { get; set; }
        public string PRO_CLASSE_CUSTO_01 { get; set; }
        public string PRO_OBS_ALTERACAO { get; set; }
        public int? TIP_ID { get; set; }
        public Decimal? PRO_PECAS_POR_VEICULO { get; set; }
        public int? PRO_DISTANCIA_ENTRE_VINCOS { get; set; }
        public int? PRO_DISTANCIA_ENTRE_VINCOS2 { get; set; }
        public int? PRO_DISTANCIA_ENTRE_VINCOS3 { get; set; }
        public int? PRO_OUT { get; set; }
        public string PRO_ID_FACA { get; set; }
        public string PRO_ID_CLICHE { get; set; }
        public string PRO_ID_TINTA_01 { get; set; }
        public string PRO_ID_TINTA_02 { get; set; }
        public string PRO_ID_TINTA_03 { get; set; }
        public string PRO_ID_TINTA_04 { get; set; }
        public string PRO_ID_TINTA_05 { get; set; }
        public string PRO_ID_FORROSUP { get; set; }
        public string PRO_ID_CANTONEIRA { get; set; }
        public string PRO_ID_PALETE { get; set; }
        public string PRO_ID_TAMPO { get; set; }
        public string PRO_ID_FORROINF { get; set; }
        public string PRO_ID_CHAPA { get; set; }
        public string PRO_ID_COMPOSICAO { get; set; }
        public int? PRO_QUEBRA_VINCO_MAIOR { get; set; }
        public int? PRO_QUEBRA_VINCO_MENOR { get; set; }
        public string CLI_ID { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration