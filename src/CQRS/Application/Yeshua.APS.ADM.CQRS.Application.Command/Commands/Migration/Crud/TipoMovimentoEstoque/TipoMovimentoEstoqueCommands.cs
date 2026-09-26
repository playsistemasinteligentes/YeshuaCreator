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
    public struct TipoMovimentoEstoqueCrudCommand : ICommand, IOperationalTelemetryCommand
    {
        public string TIP_ID { get; set; }
        public string TIP_DESCRICAO { get; set; }
        public int TIP_TYPE { get; set; }
        public int SPR { get; set; }
        public string OperationalEntityId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public string OperationalEntity => "TipoMovimentoEstoque";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration