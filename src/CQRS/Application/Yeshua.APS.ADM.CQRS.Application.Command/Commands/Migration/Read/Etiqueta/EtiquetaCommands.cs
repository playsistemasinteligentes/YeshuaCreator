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
    public struct EtiquetaReadCommand : ICommandRead
    {
        public int? ETI_ID { get; set; }
        public DateTime? ETI_EMISSAO { get; set; }
        public string ETI_CODIGO_BARRAS { get; set; }
        public int? ETI_SEQUENCIA { get; set; }
        public int? ETI_NUMERO_COPIAS { get; set; }
        public string ETI_STATUS { get; set; }
        public DateTime? ETI_DATA_FABRICACAO { get; set; }
        public string ETI_COD_BARRAS_ORIGINAL { get; set; }
        public string ETI_OP_ORIGINAL { get; set; }
        public string MAQ_ID { get; set; }
        public int? IMP_ID { get; set; }
        public int? USE_ID { get; set; }
        public string ORD_ID { get; set; }
        public string ROT_PRO_ID { get; set; }
        public int? ROT_SEQ_TRANFORMACAO { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public Decimal? ETI_QUANTIDADE_PALETE { get; set; }
        public string ETI_LOTE { get; set; }
        public string ETI_SUB_LOTE { get; set; }
        public int? ETI_IMPRIMIR_DE { get; set; }
        public int? ETI_IMPRIMIR_ATE { get; set; }
        public string BOL_ID { get; set; }
        public int? COR_SEQUENCIA { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration