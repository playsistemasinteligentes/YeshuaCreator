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
    public struct CargaPrevistaCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string CAR_ID { get; set; }
        public string ORD_ID { get; set; }
        public Decimal ITC_QTD_PLANEJADA { get; set; }
        public DateTime? CAR_PREVISAO_MATERIA_PRIMA { get; set; }
        public DateTime? CAR_DATA_INICIO_PREVISTO { get; set; }
        public DateTime? CAR_DATA_INICIO_REALIZADO { get; set; }
        public DateTime? CAR_DATA_FIM_PREVISTO { get; set; }
        public DateTime? CAR_DATA_FIM_REALIZADO { get; set; }
        public DateTime? CAR_INICIO_JANELA_EMBARQUE { get; set; }
        public DateTime? CAR_FIM_JANELA_EMBARQUE { get; set; }
        public DateTime? CAR_EMBARQUE_ALVO { get; set; }
        public Decimal? CAR_STATUS { get; set; }
        public Decimal? CAR_PESO_TEORICO { get; set; }
        public Decimal? CAR_VOLUME_TEORICO { get; set; }
        public Decimal? CAR_PESO_REAL { get; set; }
        public Decimal? CAR_VOLUME_REAL { get; set; }
        public Decimal? CAR_PESO_EMBALAGEM { get; set; }
        public Decimal? CAR_PESO_ENTRADA { get; set; }
        public Decimal? CAR_PESO_SAIDA { get; set; }
        public string CAR_ID_DOCA { get; set; }
        public string VEI_PLACA { get; set; }
        public int? TIP_ID { get; set; }
        public string TRA_ID { get; set; }
        public Decimal? CAR_GRUPO_PRODUTIVO { get; set; }
        public string ROT_ID { get; set; }
        public string CAR_OBSERVACAO_DE_TRANSPORTE { get; set; }
        public string CAR_JUSTIFICATIVA_DE_CARREGAMENTO { get; set; }
        public string OCO_ID { get; set; }
        public string CAR_ID_JUNTADA { get; set; }
        public string CAR_OBSERVACAO_OTIMIZADOR { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration