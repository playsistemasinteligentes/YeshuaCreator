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
    public struct ItensCalendarioCrudCommand : ICommand, IOperationalTelemetryCommand
    {
        public int ICA_ID { get; set; }
        public DateTime ICA_DATA_DE { get; set; }
        public DateTime ICA_DATA_ATE { get; set; }
        public string? ICA_OBSERVACAO { get; set; }
        public int ICA_TIPO { get; set; }
        public string? URM_ID { get; set; }
        public string? URN_ID { get; set; }
        public int CAL_ID { get; set; }
        public string? MAQ_ID { get; set; }
        public string? PRO_ID { get; set; }
        public int? ICA_LIMPESA_MAQUINA { get; set; }
        public string OperationalEntityId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public string OperationalEntity => "ItensCalendario";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration