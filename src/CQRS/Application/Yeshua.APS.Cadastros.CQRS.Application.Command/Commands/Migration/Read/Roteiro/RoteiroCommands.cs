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
    public struct RoteiroReadCommand : ICommandRead
    {
        public string MAQ_ID { get; set; }
        public string PRO_ID { get; set; }
        public int? ROT_SEQ_TRANFORMACAO { get; set; }
        public string GMA_ID { get; set; }
        public Decimal? ROT_PECAS_POR_PULSO { get; set; }
        public Decimal? ROT_PRIORIDADE_INFORMADA { get; set; }
        public string ROT_ACAO { get; set; }
        public Decimal? ROT_PERFORMANCE { get; set; }
        public Decimal? ROT_TEMPO_SETUP { get; set; }
        public Decimal? ROT_TEMPO_SETUP_AJUSTE { get; set; }
        public int? ROT_VA_PARA_SEQ_TRANSFORMACAO { get; set; }
        public string ROT_STATUS { get; set; }
        public Decimal? ROT_HIERARQUIA_SEQ_TRANSFORMACAO { get; set; }
        public int? ROT_AVALIA_CUSTO { get; set; }
        public string ROT_OPERACOES { get; set; }
        public string ROT_EXCECAO_OPERACOES { get; set; }
        public Decimal? ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR { get; set; }
        public string ROT_LINHA_DIRETA { get; set; }
        public int? TEM_ID { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration