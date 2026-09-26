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
    public struct ClinicaCrudCommand : ICommand, IOperationalTelemetryCommand
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string OperationalEntityId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public string OperationalEntity => "Clinica";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration