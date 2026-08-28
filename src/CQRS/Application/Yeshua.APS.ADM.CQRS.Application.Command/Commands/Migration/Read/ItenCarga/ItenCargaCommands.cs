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
    public struct ItenCargaReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string CAR_ID { get; set; }
        public string ORD_ID { get; set; }
        public DateTime? ITC_ENTREGA_PLANEJADA { get; set; }
        public DateTime? ITC_ENTREGA_REALIZADA { get; set; }
        public int? ITC_ORDEM_ENTREGA { get; set; }
        public Decimal? ITC_QTD_PLANEJADA { get; set; }
        public Decimal? ITC_QTD_REALIZADA { get; set; }
        public string ORD_HASH_KEY { get; set; }
        public string NOT_ID { get; set; }
        public DateTime? NOT_EMISSAO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration