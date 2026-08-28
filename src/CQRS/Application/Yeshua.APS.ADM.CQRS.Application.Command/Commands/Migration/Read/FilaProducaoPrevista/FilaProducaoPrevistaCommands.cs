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
namespace Command.Read
{
    public struct FilaProducaoPrevistaReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string ORD_ID { get; set; }
        public string ROT_PRO_ID { get; set; }
        public Decimal? FPR_QUANTIDADE_PREVISTA { get; set; }
        public string ROT_MAQ_ID { get; set; }
        public DateTime? FPR_DATA_INICIO_PREVISTA { get; set; }
        public DateTime? FPR_DATA_FIM_PREVISTA { get; set; }
        public DateTime? FPR_DATA_FIM_MAXIMA { get; set; }
        public int? ROT_SEQ_TRANFORMACAO { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public string FPR_OBS_PRODUCAO { get; set; }
        public string FPR_STATUS { get; set; }
        public Decimal? FPR_TEMPO_DECORRIDO_SETUP { get; set; }
        public Decimal? FPR_TEMPO_DECORRIDO_SETUPA { get; set; }
        public Decimal? FPR_TEMPO_DECORRIDO_PERFORMANC { get; set; }
        public Decimal? FPR_TEMPO_DECO_PEQUENA_PARADA { get; set; }
        public Decimal? FPR_QTD_PERFORMANCE { get; set; }
        public Decimal? FPR_QTD_SETUP { get; set; }
        public Decimal? FPR_QTD_PRODUZIDA { get; set; }
        public Decimal? FPR_TEMPO_TEORICO_PERFORMANCE { get; set; }
        public Decimal? FPR_TEMPO_RESTANTE_PERFORMANC { get; set; }
        public Decimal? FPR_VELOCIDADE_P_ATINGIR_META { get; set; }
        public Decimal? FPR_QTD_RESTANTE { get; set; }
        public Decimal? FPR_VELO_ATU_PC_SEGUNDO { get; set; }
        public Decimal? FPR_PERFORMANCE_PROJETADA { get; set; }
        public Decimal? FPR_TEMPO_RESTANTE_TOTAL { get; set; }
        public DateTime? FPR_FIM_PREVISTO_ATUAL { get; set; }
        public int? FPR_PRODUZINDO { get; set; }
        public Decimal? FPR_ORDEM_NA_FILA { get; set; }
        public string FPR_ID_INTEGRACAO { get; set; }
        public string FPR_TRUNCADO { get; set; }
        public DateTime? FPR_DATA_TRUNC_INI { get; set; }
        public DateTime? FPR_DATA_TRUNC_FIM { get; set; }
        public int? FPR_ID { get; set; }
        public string FPR_COR_FILA { get; set; }
        public string MAQ_ID_MANUAL { get; set; }
        public string MAQ_ID_RESTRINGIDA { get; set; }
        public DateTime? FPR_PREVISAO_MATERIA_PRIMA { get; set; }
        public DateTime? FPR_DATA_NECESSIDADE_INICIO_PRODUCAO { get; set; }
        public DateTime? FPR_DATA_NECESSIDADE_FIM_PRODUCAO { get; set; }
        public Decimal? FPR_GRUPO_PRODUTIVO { get; set; }
        public DateTime? FPR_INICIO_GRUPO_PRODUTIVO { get; set; }
        public DateTime? FPR_FIM_GRUPO_PRODUTIVO { get; set; }
        public string FPR_COR_BICO1 { get; set; }
        public string FPR_COR_BICO2 { get; set; }
        public string FPR_COR_BICO3 { get; set; }
        public string FPR_COR_BICO4 { get; set; }
        public string FPR_COR_BICO5 { get; set; }
        public Decimal? FPR_META_SETUP { get; set; }
        public string FPR_ORD_ID_REPROGRAMADO { get; set; }
        public int? FPR_PRIORIDADE { get; set; }
        public int? FPR_SEQ_INCLUSAO_FILA { get; set; }
        public int? FPR_HIERARQUIA_SEQ_TRANSFORMACAO { get; set; }
        public int? FPR_ID_ORIGEM { get; set; }
        public DateTime? FPR_DATA_ENTREGA { get; set; }
        public string EQU_ID { get; set; }
        public Decimal? FPR_GRUPO_PRODUTIVO_MANUAL { get; set; }
        public DateTime? FPR_EMISSAO { get; set; }
        public string FPR_MOTIVO_PULA_FILA { get; set; }
        public string OCO_ID { get; set; }
        public string FPR_PESO_UNITARIO { get; set; }
        public string FPR_M2_UNITARIO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration