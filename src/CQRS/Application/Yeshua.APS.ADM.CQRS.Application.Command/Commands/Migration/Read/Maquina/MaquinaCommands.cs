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
    public struct MaquinaReadCommand : ICommandRead
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public int? CAL_ID { get; set; }
        public string MAQ_CONTROL_IP { get; set; }
        public string GMA_ID { get; set; }
        public DateTime? MAQ_ULTIMA_ATUALIZACAO { get; set; }
        public int? MAQ_SIRENE_SEMAFORO { get; set; }
        public string MAQ_COR_SEMAFORO { get; set; }
        public string MAQ_ID_MAQ_PAI { get; set; }
        public int? MAQ_TIPO_CONTADOR { get; set; }
        public string MAQ_TIPO_PLANEJAMENTO { get; set; }
        public int? MAQ_AVALIA_CUSTO { get; set; }
        public int? FPR_ID_OP_PRODUZINDO { get; set; }
        public int? MAQ_CONGELA_FILA { get; set; }
        public int? MAQ_TEMPO_MIN_PARADA { get; set; }
        public int? MAQ_QTD_CORES { get; set; }
        public string MAQ_ID_INTEGRACAO { get; set; }
        public string MAQ_ID_INTEGRACAO_ERP { get; set; }
        public Decimal? MAQ_HIERARQUIA_SEQ_TRANSFORMACAO { get; set; }
        public string EQU_ID { get; set; }
        public Decimal? MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR { get; set; }
        public string MAQ_ACOMPANHA_LOTE_PILOTO { get; set; }
        public int? MAQ_ID_SENSOR { get; set; }
        public int? MAQ_DEBOUNCING_LOW { get; set; }
        public int? MAQ_DEBOUNCING_HIGHT { get; set; }
        public int? MAQ_TIPO_SINAL { get; set; }
        public int? TEM_ID { get; set; }
        public Decimal? MAQ_COMPRIMENTO_CHAPA_DE { get; set; }
        public Decimal? MAQ_COMPRIMENTO_CHAPA_ATE { get; set; }
        public Decimal? MAQ_LARGURA_CHAPA_DE { get; set; }
        public Decimal? MAQ_LARGURA_CHAPA_ATE { get; set; }
        public Decimal? MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR { get; set; }
        public Decimal? MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR { get; set; }
        public Decimal? MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR { get; set; }
        public Decimal? MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR { get; set; }
        public Decimal? MAQ_COMPRIMENTO_ENTRE_VINCO_DE { get; set; }
        public Decimal? MAQ_COMPRIMENTO_ENTRE_VINCO_ATE { get; set; }
        public Decimal? MAQ_LARGURA_ENTRE_VINCO_DE { get; set; }
        public Decimal? MAQ_LARGURA_ENTRE_VINCO_ATE { get; set; }
        public Decimal? MAQ_ALTURA_ENTRE_VINCO_DE { get; set; }
        public Decimal? MAQ_ALTURA_ENTRE_VINCO_ATE { get; set; }
        public Decimal? MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE { get; set; }
        public Decimal? MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE { get; set; }
        public Decimal? MAQ_ABA_DE { get; set; }
        public Decimal? MAQ_ABA_ATE { get; set; }
        public Decimal? MAQ_LAP_DE { get; set; }
        public Decimal? MAQ_LAP_ATE { get; set; }
        public string MAQ_ONDAS { get; set; }
        public string MAQ_PROLONGA_LAP { get; set; }
        public Decimal? MAQ_LARGURA_IMPRESSAO { get; set; }
        public Decimal? MAQ_COMPRIMENTO_IMPRESSAO { get; set; }
        public Decimal? MAQ_ROLO_DISPOSITIVO_DE { get; set; }
        public Decimal? MAQ_ROLO_DISPOSITIVO_ATE { get; set; }
        public string MAQ_FAMILIAS { get; set; }
        public Decimal? MAQ_REFILE_MINIMO { get; set; }
        public Decimal? MAQ_LARGURA_UTIL { get; set; }
        public Decimal? MAQ_TOTAL_ACO { get; set; }
        public string MAQ_FECHAMENTO { get; set; }
        public Decimal? MAQ_OPERACAO_VINCAR { get; set; }
        public Decimal? MAQ_OPERACAO_MONTA_DIVISAO { get; set; }
        public Decimal? MAQ_OPERACAO_SERRAR { get; set; }
        public string MAQ_TIPO_LAP { get; set; }
        public Decimal? MAQ_INDICE_PARADAS_POR_OP { get; set; }
        public int? MAQ_PERDA_MAXIMA { get; set; }
        public int? MAQ_TOTAL_PECAS_REFILANDO { get; set; }
        public int? MAQ_TOTAL_PECAS_NAO_REFILANDO { get; set; }
        public int? MAQ_TOTAL_VINCOS { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration