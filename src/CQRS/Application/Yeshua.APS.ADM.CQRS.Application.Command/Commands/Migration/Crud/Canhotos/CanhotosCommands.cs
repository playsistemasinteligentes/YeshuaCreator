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
    public struct CanhotosCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string CAR_ID { get; set; }
        public string ORD_ID { get; set; }
        public string NOT_ID { get; set; }
        public DateTime? CAN_DATA_ENTREGA { get; set; }
        public string CAN_IMG { get; set; }
        public Decimal? CAN_LAT_ENTREGA { get; set; }
        public Decimal? CAN_LONG_ENTREGA { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration