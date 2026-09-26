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
    public struct yTenantCrudCommand : ICommand, IOperationalTelemetryCommand
    {
        public string OperationalEntityId { get; set; }
        public int? Id { get; set; }
        public string CnpjCpf { get; set; }
        public string Nome { get; set; }
        public int? UserId { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
 public string OperationalEntity => "yTenant";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration