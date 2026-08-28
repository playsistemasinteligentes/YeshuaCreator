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
    public struct ItensPackedReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? IPA_ID { get; set; }
        public string CAR_ID { get; set; }
        public string PRO_ID { get; set; }
        public string ORD_ID { get; set; }
        public Decimal? IPA_COORDC { get; set; }
        public Decimal? IPA_COORDL { get; set; }
        public Decimal? IPA_COORDA { get; set; }
        public Decimal? IPA_DIMC { get; set; }
        public Decimal? IPA_DIML { get; set; }
        public Decimal? IPA_DIMA { get; set; }
        public Decimal? IPA_QTD_POR_PALETE { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration