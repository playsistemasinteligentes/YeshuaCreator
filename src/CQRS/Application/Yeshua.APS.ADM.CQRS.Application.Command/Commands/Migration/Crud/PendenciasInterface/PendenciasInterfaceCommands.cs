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
    public struct PendenciasInterfaceCrudCommand : ICommand, IOperationalTelemetryCommand
    {
        public string? PEN_STATUS_OUT { get; set; }
        public string? PEN_PROTOCOLO_OUT { get; set; }
        public string? PEN_ID_PROTOCOLO_OUT { get; set; }
        public string? PEN_STATUS_IN { get; set; }
        public string? PEN_PROTOCOLO_IN { get; set; }
        public string? PEN_ID_PROTOCOLO_IN { get; set; }
        public DateTime DATA_ENTRADA { get; set; }
        public string OperationalEntityId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public int PEN_ID { get; set; }
 public string OperationalEntity => "PendenciasInterface";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration