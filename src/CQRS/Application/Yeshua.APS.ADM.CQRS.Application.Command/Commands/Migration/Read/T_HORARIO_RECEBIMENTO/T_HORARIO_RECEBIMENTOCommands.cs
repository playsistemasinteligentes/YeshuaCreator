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
    public struct T_HORARIO_RECEBIMENTOReadCommand : ICommandRead, IOperationalTelemetryCommand
    {
        public int? HRE_DIA_DA_SEMANA { get; set; }
        public DateTime? HRE_HORA_INICIAL { get; set; }
        public DateTime? HRE_HORA_FINAL { get; set; }
        public string? CLI_ID { get; set; }
        public int? HRE_ID { get; set; }
        public string? OperationalEntityId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
 public string OperationalEntity => "T_HORARIO_RECEBIMENTO";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration