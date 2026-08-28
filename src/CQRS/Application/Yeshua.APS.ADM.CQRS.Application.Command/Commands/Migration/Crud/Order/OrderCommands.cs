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
    public struct OrderCrudCommand : ICommand
    {
        public string ORD_ID { get; set; }
        public string ORD_ID_RESERVA { get; set; }
        public string ORD_ID_CONJUNTO { get; set; }
        public string PRO_ID { get; set; }
        public string PRO_ID_CONJUNTO { get; set; }
        public string CLI_ID { get; set; }
        public Decimal? ORD_PRECO_UNITARIO { get; set; }
        public Decimal ORD_QUANTIDADE { get; set; }
        public DateTime ORD_DATA_ENTREGA_DE { get; set; }
        public DateTime ORD_DATA_ENTREGA_ATE { get; set; }
        public int? ORD_TIPO { get; set; }
        public Decimal? ORD_TOLERANCIA_MAIS { get; set; }
        public Decimal? ORD_TOLERANCIA_MENOS { get; set; }
        public string HASH_KEY { get; set; }
        public DateTime? ORD_INICIO_JANELA_EMBARQUE { get; set; }
        public DateTime? ORD_FIM_JANELA_EMBARQUE { get; set; }
        public DateTime? ORD_EMBARQUE_ALVO { get; set; }
        public DateTime? ORD_INICIO_GRUPO_PRODUTIVO { get; set; }
        public DateTime? ORD_FIM_GRUPO_PRODUTIVO { get; set; }
        public Decimal? ORD_PESO_UNITARIO { get; set; }
        public Decimal? ORD_PESO_UNITARIO_BRUTO { get; set; }
        public Decimal? ORD_M2_UNITARIO { get; set; }
        public string ORD_MIT { get; set; }
        public string CAR_TIPO_CARREGAMENTO { get; set; }
        public string ORD_STATUS { get; set; }
        public string ORD_TIPO_FRETE { get; set; }
        public string ORD_ENDERECO_ENTREGA { get; set; }
        public string ORD_BAIRRO_ENTREGA { get; set; }
        public string UF_ID_ENTREGA { get; set; }
        public string ORD_CEP_ENTREGA { get; set; }
        public string MUN_ID_ENTREGA { get; set; }
        public string ORD_REGIAO_ENTREGA { get; set; }
        public Decimal? ORD_LARGURA { get; set; }
        public Decimal? ORD_COMPRIMENTO { get; set; }
        public Decimal? ORD_GRAMATURA { get; set; }
        public string GRP_ID { get; set; }
        public string ORD_ID_INTEGRACAO { get; set; }
        public string ORD_OBSERVACAO_OTIMIZADOR { get; set; }
        public string ORD_COR_FILA { get; set; }
        public string ORD_PED_CLI { get; set; }
        public string ORD_OP_INTEGRACAO { get; set; }
        public string ORD_LOTE_PILOTO { get; set; }
        public int? ORD_PRIORIDADE { get; set; }
        public DateTime? ORD_EMISSAO { get; set; }
        public string REP_ID { get; set; }
        public string ORD_RESINA { get; set; }
        public string ORD_ENDURECEDOR_MIOLO { get; set; }
        public string PRO_ID_INTEGRACAO_ERP { get; set; }
        public string ORD_VINCOS_ONDULADEIRA { get; set; }
        public Decimal? ORD_ERP_CUSTOS_FIXOS { get; set; }
        public Decimal? ORD_ERP_CUSTOS_VARIAVEIS { get; set; }
        public Decimal? ORD_ERP_DESPESAS_VAR_VENDA { get; set; }
        public Decimal? ORD_ERP_IMPOSTOS { get; set; }
        public string ORD_STATUS_PLANEJAMENTO { get; set; }
        public int? ORD_TOLERANCIA_DIMENSAO_CHAPA_DE { get; set; }
        public int? ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE { get; set; }
        public Decimal? ORD_PROMOVE_DE { get; set; }
        public Decimal? ORD_PROMOVE_ATE { get; set; }
        public string ORD_TRAVA_COMPOSICAO { get; set; }
        public string ORD_TRAVA_RESINA { get; set; }
        public string ORD_PROMOVE_RESINA { get; set; }
        public Decimal? ORD_LATITUDE_ENTREGA { get; set; }
        public Decimal? ORD_LONGITUDE_ENTREGA { get; set; }
        public string OCO_ID_CANCELAMENTO { get; set; }
        public string TMP_TIPO_CARGA { get; set; }
        public string PRO_ID_PALETE { get; set; }
        public string PRO_ID_TAMPO { get; set; }
        public int? ORD_PILHAS_POR_PALETE { get; set; }
        public int? ORD_CHAPAS_POR_PILHA { get; set; }
        public DateTime? ORD_DATA_CANCELAMENTO { get; set; }
        public string ORD_STATUS_ESTATISTICA { get; set; }
        public DateTime? ORD_DATA_ESTATISTICA { get; set; }
        public string OCO_ID_MOTIVO_ATRASO { get; set; }
        public int? OTK_VERSSAO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration