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
    public struct CalendarioCrudCommand : ICommand, IOperationalTelemetryCommand
    {
        public int CAL_ID { get; set; }
        public string CAL_DESCRICAO { get; set; }
        public int? CAL_DIVIDE_DIA_EM { get; set; }
        public string OperationalEntityId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public string OperationalEntity => "Calendario";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration