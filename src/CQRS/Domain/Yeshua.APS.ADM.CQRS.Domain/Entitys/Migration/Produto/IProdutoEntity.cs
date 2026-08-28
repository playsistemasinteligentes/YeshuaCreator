// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>


                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public interface IProdutoEntity
{
    string Id { get; set; }
    string Descricao { get; set; }
    string Status { get; set; }
    int? TenantID { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    int? UserId { get; set; }
    Decimal? PRO_ESTOQUE_ATUAL { get; set; }
    string UNI_ID { get; set; }
    Decimal? PRO_FARDOS_POR_CAMADA { get; set; }
    Decimal? PRO_CAMADAS_POR_PALETE { get; set; }
    int? PRO_TIPO_IDENTIFICACAO { get; set; }
    string PRO_GRUPO_PALETIZACAO { get; set; }
    Decimal? PRO_PECAS_POR_FARDO { get; set; }
    string PRO_ID_INTEGRACAO { get; set; }
    string PRO_ID_INTEGRACAO_ERP { get; set; }
    string GRP_ID { get; set; }
    int? TEM_ID { get; set; }
    Decimal? PRO_LARGURA_PECA { get; set; }
    Decimal? PRO_COMPRIMENTO_PECA { get; set; }
    Decimal? PRO_ALTURA_PECA { get; set; }
    Decimal? PRO_LARGURA_EMBALADA { get; set; }
    Decimal? PRO_COMPRIMENTO_EMBALADA { get; set; }
    Decimal? PRO_ALTURA_EMBALADA { get; set; }
    string PRO_FRENTE { get; set; }
    string PRO_ROTACIONA_COMPRIMENTO { get; set; }
    string PRO_ROTACIONA_LARGURA { get; set; }
    string PRO_ROTACIONA_ALTURA { get; set; }
    string PRO_ESCALA_COR { get; set; }
    string PRO_SUB_ESCALA_COR { get; set; }
    Decimal? PRO_CUSTO_SUBIDA_ESCALA_COR { get; set; }
    Decimal? PRO_CUSTO_DECIDA_ESCALA_COR { get; set; }
    string TMP_TIPO_CARGA { get; set; }
    Decimal? PRO_TEMPO_CARREGAMENTO_UNITARIO { get; set; }
    Decimal? PRO_TEMPO_DESCARREGAMENTO_UNITARIO { get; set; }
    Decimal? PRO_PERCENTUAL_JANELA_EMBARQUE { get; set; }
    Decimal? PRO_TEMPO_PRODUCAO_CONJUNTO { get; set; }
    Decimal? PRO_PECAS_DA_PECA { get; set; }
    int? PRO_TYPE { get; set; }
    string PRO_COLOR_HEXA { get; set; }
    string PRO_VINCOS_LARGURA { get; set; }
    string PRO_VINCOS_COMPRIMENTO { get; set; }
    Decimal? PRO_LARGURA_INTERNA { get; set; }
    Decimal? PRO_COMPRIMENTO_INTERNA { get; set; }
    Decimal? PRO_ALTURA_INTERNA { get; set; }
    string PRO_COD_DESENHO { get; set; }
    string PRO_FECHAMENTO { get; set; }
    string PRO_TIPO_LAP { get; set; }
    Decimal? PRO_TAMANHO_LAP { get; set; }
    string PRO_LAP_PROLONGADO { get; set; }
    Decimal? PRO_TAMANHO_LAP_PROLONG { get; set; }
    Decimal? PRO_ARRANJO_LARGURA { get; set; }
    Decimal? PRO_ARRANJO_COMPRIMENTO { get; set; }
    int? PRO_FITILHOS_FARDO_LARG { get; set; }
    int? PRO_FITILHOS_FARDO_COMP { get; set; }
    int? PRO_FITILHOS_PALETE_LARG { get; set; }
    int? PRO_FITILHOS_PALETE_COMP { get; set; }
    int? PRO_FILME_PALETE { get; set; }
    int? PRO_QTD_ESPELHO { get; set; }
    Decimal? PRO_CUSTO { get; set; }
    Decimal? PRO_AREA_LIQUIDA { get; set; }
    Decimal? PRO_PESO { get; set; }
    int? PRO_TOLERANCIA_DIMENSAO_CHAPA_DE { get; set; }
    int? PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE { get; set; }
    string PRO_IMG_LASTRO { get; set; }
    string ABN_ID { get; set; }
    int? SEG_ID { get; set; }
    string PRO_RESINA { get; set; }
    string PRO_ENDURECEDOR_MIOLO { get; set; }
    string PRO_VINCOS_ONDULADEIRA { get; set; }
    int? PRO_ADICIONAL_ABA_SUPERIOR { get; set; }
    int? PRO_ADICIONAL_ABA_INFERIOR { get; set; }
    string PRO_PROMOVE_RESINA { get; set; }
    Decimal? PRO_PROMOVE_DE { get; set; }
    Decimal? PRO_PROMOVE_ATE { get; set; }
    int? PRO_PROFUNDIDADE_VINCO { get; set; }
    int VIN_ID { get; set; }
    string PRO_PROMOVE_PRODUTO { get; set; }
    Decimal? PRO_TARA { get; set; }
    Decimal? PRO_COMPRESSAO { get; set; }
    string PRO_COD_BARRAS_CAIXA { get; set; }
    string CJN_ID { get; set; }
    string PRJ_ID { get; set; }
    int? PRO_REFILE_LARGURA { get; set; }
    int? PRO_REFILE_COMPRIMENTO { get; set; }
    Decimal? PRO_M2_PONTA { get; set; }
    int? PRO_QTD_CORTES_PECA1 { get; set; }
    int? PRO_QTD_CORTES_PECA2 { get; set; }
    string PRO_DIVISAO_MONTADA { get; set; }
    Decimal? PRO_SEGMENTO_A { get; set; }
    Decimal? PRO_SEGMENTO_B { get; set; }
    Decimal? PRO_SEGMENTO_C { get; set; }
    Decimal? PRO_SEGMENTO_D { get; set; }
    Decimal? PRO_SEGMENTO_E { get; set; }
    Decimal? PRO_SEGMENTO_F { get; set; }
    Decimal? PRO_SEGMENTO_G { get; set; }
    Decimal? PRO_SEGMENTO_H { get; set; }
    Decimal? PRO_SEGMENTO_I { get; set; }
    Decimal? PRO_QTD_GRAMPOS { get; set; }
    Decimal? PRO_AREA_REFILE_INTERNO { get; set; }
    Decimal? PRO_AREA_REFILE_EXTERNO { get; set; }
    Decimal? PRO_PESO_REFILE { get; set; }
    string PRO_ORELHA_INVERTIDA { get; set; }
    string PRO_ENDERECO { get; set; }
    string PRO_ID_VINCULADO { get; set; }
    int? PRO_BATIDAS_PROXIMA_MANUTENCAO { get; set; }
    string PRO_ENTRADA_NA_MAQUINA { get; set; }
    string TDI_ID { get; set; }
    int? PRO_QUEBRA_VINCO { get; set; }
    int? PRO_LARGURA_FARDO { get; set; }
    int? PRO_COMPRIMENTO_FARDO { get; set; }
    Decimal? PRO_ALTURA_FARDO { get; set; }
    string PRO_TIPO_CUSTO { get; set; }
    string PRO_GRUPO_CONTABIL { get; set; }
    string PRO_CLASSE_CUSTO_01 { get; set; }
    string PRO_OBS_ALTERACAO { get; set; }
    int? TIP_ID { get; set; }
    Decimal? PRO_PECAS_POR_VEICULO { get; set; }
    int? PRO_DISTANCIA_ENTRE_VINCOS { get; set; }
    int? PRO_DISTANCIA_ENTRE_VINCOS2 { get; set; }
    int? PRO_DISTANCIA_ENTRE_VINCOS3 { get; set; }
    int? PRO_OUT { get; set; }
    string PRO_ID_FACA { get; set; }
    string PRO_ID_CLICHE { get; set; }
    string PRO_ID_TINTA_01 { get; set; }
    string PRO_ID_TINTA_02 { get; set; }
    string PRO_ID_TINTA_03 { get; set; }
    string PRO_ID_TINTA_04 { get; set; }
    string PRO_ID_TINTA_05 { get; set; }
    string PRO_ID_FORROSUP { get; set; }
    string PRO_ID_CANTONEIRA { get; set; }
    string PRO_ID_PALETE { get; set; }
    string PRO_ID_TAMPO { get; set; }
    string PRO_ID_FORROINF { get; set; }
    string PRO_ID_CHAPA { get; set; }
    string PRO_ID_COMPOSICAO { get; set; }
    int? PRO_QUEBRA_VINCO_MAIOR { get; set; }
    int? PRO_QUEBRA_VINCO_MENOR { get; set; }
    string CLI_ID { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration