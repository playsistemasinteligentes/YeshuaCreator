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
    public struct PlanocontasReadCommand : ICommandRead, IOperationalTelemetryCommand
    {
        public int? PLA_ID { get; set; }
        public string? PLA_CODIGO { get; set; }
        public string? PLA_DESCRICAO { get; set; }
        public int? PLA_TIPO { get; set; }
        public string? PLA_NATUREZA { get; set; }
        public string? OperationalEntityId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
 public string OperationalEntity => "Planocontas";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration