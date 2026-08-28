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
                    public interface IOrderEntity
{
    string ORD_ID { get; set; }
    string ORD_ID_RESERVA { get; set; }
    string ORD_ID_CONJUNTO { get; set; }
    string PRO_ID { get; set; }
    string PRO_ID_CONJUNTO { get; set; }
    string CLI_ID { get; set; }
    Decimal? ORD_PRECO_UNITARIO { get; set; }
    Decimal ORD_QUANTIDADE { get; set; }
    DateTime ORD_DATA_ENTREGA_DE { get; set; }
    DateTime ORD_DATA_ENTREGA_ATE { get; set; }
    int? ORD_TIPO { get; set; }
    Decimal? ORD_TOLERANCIA_MAIS { get; set; }
    Decimal? ORD_TOLERANCIA_MENOS { get; set; }
    string HASH_KEY { get; set; }
    DateTime? ORD_INICIO_JANELA_EMBARQUE { get; set; }
    DateTime? ORD_FIM_JANELA_EMBARQUE { get; set; }
    DateTime? ORD_EMBARQUE_ALVO { get; set; }
    DateTime? ORD_INICIO_GRUPO_PRODUTIVO { get; set; }
    DateTime? ORD_FIM_GRUPO_PRODUTIVO { get; set; }
    Decimal? ORD_PESO_UNITARIO { get; set; }
    Decimal? ORD_PESO_UNITARIO_BRUTO { get; set; }
    Decimal? ORD_M2_UNITARIO { get; set; }
    string ORD_MIT { get; set; }
    string CAR_TIPO_CARREGAMENTO { get; set; }
    string ORD_STATUS { get; set; }
    string ORD_TIPO_FRETE { get; set; }
    string ORD_ENDERECO_ENTREGA { get; set; }
    string ORD_BAIRRO_ENTREGA { get; set; }
    string UF_ID_ENTREGA { get; set; }
    string ORD_CEP_ENTREGA { get; set; }
    string MUN_ID_ENTREGA { get; set; }
    string ORD_REGIAO_ENTREGA { get; set; }
    Decimal? ORD_LARGURA { get; set; }
    Decimal? ORD_COMPRIMENTO { get; set; }
    Decimal? ORD_GRAMATURA { get; set; }
    string GRP_ID { get; set; }
    string ORD_ID_INTEGRACAO { get; set; }
    string ORD_OBSERVACAO_OTIMIZADOR { get; set; }
    string ORD_COR_FILA { get; set; }
    string ORD_PED_CLI { get; set; }
    string ORD_OP_INTEGRACAO { get; set; }
    string ORD_LOTE_PILOTO { get; set; }
    int? ORD_PRIORIDADE { get; set; }
    DateTime? ORD_EMISSAO { get; set; }
    string REP_ID { get; set; }
    string ORD_RESINA { get; set; }
    string ORD_ENDURECEDOR_MIOLO { get; set; }
    string PRO_ID_INTEGRACAO_ERP { get; set; }
    string ORD_VINCOS_ONDULADEIRA { get; set; }
    Decimal? ORD_ERP_CUSTOS_FIXOS { get; set; }
    Decimal? ORD_ERP_CUSTOS_VARIAVEIS { get; set; }
    Decimal? ORD_ERP_DESPESAS_VAR_VENDA { get; set; }
    Decimal? ORD_ERP_IMPOSTOS { get; set; }
    string ORD_STATUS_PLANEJAMENTO { get; set; }
    int? ORD_TOLERANCIA_DIMENSAO_CHAPA_DE { get; set; }
    int? ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE { get; set; }
    Decimal? ORD_PROMOVE_DE { get; set; }
    Decimal? ORD_PROMOVE_ATE { get; set; }
    string ORD_TRAVA_COMPOSICAO { get; set; }
    string ORD_TRAVA_RESINA { get; set; }
    string ORD_PROMOVE_RESINA { get; set; }
    Decimal? ORD_LATITUDE_ENTREGA { get; set; }
    Decimal? ORD_LONGITUDE_ENTREGA { get; set; }
    string OCO_ID_CANCELAMENTO { get; set; }
    string TMP_TIPO_CARGA { get; set; }
    string PRO_ID_PALETE { get; set; }
    string PRO_ID_TAMPO { get; set; }
    int? ORD_PILHAS_POR_PALETE { get; set; }
    int? ORD_CHAPAS_POR_PILHA { get; set; }
    DateTime? ORD_DATA_CANCELAMENTO { get; set; }
    string ORD_STATUS_ESTATISTICA { get; set; }
    DateTime? ORD_DATA_ESTATISTICA { get; set; }
    string OCO_ID_MOTIVO_ATRASO { get; set; }
    int? OTK_VERSSAO { get; set; }
    int? TenantID { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    int? UserId { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration