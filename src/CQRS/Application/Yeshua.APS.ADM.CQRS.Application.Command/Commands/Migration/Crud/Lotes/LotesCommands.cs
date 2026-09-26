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
    public struct LotesCrudCommand : ICommand, IOperationalTelemetryCommand
    {
        public int? Id { get; set; }
        public string MOV_LOTE { get; set; }
        public string MOV_SUB_LOTE { get; set; }
        public Decimal? LOT_LARGURA { get; set; }
        public Decimal? LOT_COMPRIMENTO { get; set; }
        public Decimal? LOT_DIAMETRO { get; set; }
        public string OperationalEntityId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public string OperationalEntity => "Lotes";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration