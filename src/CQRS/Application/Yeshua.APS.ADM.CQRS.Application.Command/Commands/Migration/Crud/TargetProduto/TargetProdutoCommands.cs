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
    public struct TargetProdutoCrudCommand : ICommand
    {
        public int TAR_ID { get; set; }
        public int? MOV_ID { get; set; }
        public string ORD_ID { get; set; }
        public string PRO_ID { get; set; }
        public string MAQ_ID { get; set; }
        public string UNI_ID { get; set; }
        public string TURM_ID { get; set; }
        public string TURN_ID { get; set; }
        public int? USE_ID { get; set; }
        public string TAR_DIA_TURMA { get; set; }
        public Decimal TAR_META_PERFORMANCE { get; set; }
        public Decimal? TAR_REALIZADO_PERFORMANCE { get; set; }
        public Decimal? TAR_PERCENTUAL_REALIZADO_PERFORMANCE { get; set; }
        public Decimal? TAR_PROXIMA_META_PERFORMANCE { get; set; }
        public Decimal TAR_META_TEMPO_SETUP { get; set; }
        public Decimal? TAR_REALIZADO_TEMPO_SETUP { get; set; }
        public Decimal? TAR_PROXIMA_META_TEMPO_SETUP { get; set; }
        public Decimal TAR_META_TEMPO_SETUP_AJUSTE { get; set; }
        public Decimal? TAR_REALIZADO_TEMPO_SETUP_AJUSTE { get; set; }
        public Decimal? TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE { get; set; }
        public string OCO_ID_PERFORMANCE { get; set; }
        public string TAR_OBS_PERFORMANCE { get; set; }
        public string OCO_ID_SETUP { get; set; }
        public string TAR_OBS_SETUP { get; set; }
        public string OCO_ID_SETUPA { get; set; }
        public string TAR_OBS_SETUPA { get; set; }
        public string TAR_TIPO_FEEDBACK_PERFORMANCE { get; set; }
        public string TAR_TIPO_FEEDBACK_SETUP { get; set; }
        public string TAR_TIPO_FEEDBACK_SETUP_AJUSTE { get; set; }
        public Decimal? TAR_QTD_SETUP_AJUSTE { get; set; }
        public Decimal? TAR_QTD { get; set; }
        public int? TAR_PARAMETRO_TIME_WORK_STOP_MACHINE { get; set; }
        public int? TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE { get; set; }
        public int? ROT_SEQ_TRANFORMACAO { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public Decimal? TAR_PERFORMANCE_MAX_VERDE { get; set; }
        public Decimal? TAR_PERFORMANCE_MIN_VERDE { get; set; }
        public Decimal? TAR_SETUP_MAX_VERDE { get; set; }
        public Decimal? TAR_SETUP_MIN_VERDE { get; set; }
        public Decimal? TAR_SETUPA_MAX_VERDE { get; set; }
        public Decimal? TAR_SETUPA_MIN_VERDE { get; set; }
        public Decimal? TAR_PERFORMANCE_MIN_AMARELO { get; set; }
        public Decimal? TAR_SETUP_MAX_AMARELO { get; set; }
        public Decimal? TAR_SETUPA_MAX_AMARELO { get; set; }
        public string TAR_OBS_OP_PARCIAL { get; set; }
        public string TAR_OCO_ID_OP_PARCIAL { get; set; }
        public string TAR_COR_PERFORMANCE { get; set; }
        public string TAR_COR_SETUP_GERAL { get; set; }
        public string TAR_COR_SETUP { get; set; }
        public string TAR_COR_SETUPA { get; set; }
        public DateTime? TAR_DIA_TURMA_D { get; set; }
        public Decimal? FEE_QTD_PECAS_POR_PULSO { get; set; }
        public Decimal? TAR_QTD_PERDAS { get; set; }
        public DateTime? TAR_DATA_INICIAL { get; set; }
        public DateTime? TAR_DATA_FINAL { get; set; }
        public string TAR_APROVADO { get; set; }
        public int? TAR_TEMPO_PRODUZINDO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration