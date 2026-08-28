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
    public struct TesteFisicoReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? TES_ID { get; set; }
        public int? ITE_ID { get; set; }
        public int? USR_ID { get; set; }
        public string TES_NOME_TECNICO { get; set; }
        public int? TES_AMOSTRA { get; set; }
        public string TES_OP { get; set; }
        public Decimal? TES_VALOR_NUMERICO { get; set; }
        public DateTime? TES_VALOR_DATA { get; set; }
        public string TES_VALOR_TEXTO { get; set; }
        public DateTime? TES_EMISSAO { get; set; }
        public string ORD_ID { get; set; }
        public string PRO_ID { get; set; }
        public string MAQ_ID { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public int? FPR_SEQ_TRANFORMACAO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration