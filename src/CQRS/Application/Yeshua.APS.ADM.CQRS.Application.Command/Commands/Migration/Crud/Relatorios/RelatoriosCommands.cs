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
    public struct RelatoriosCrudCommand : ICommand, IOperationalTelemetryCommand
    {
        public int REL_ID { get; set; }
        public string? REL_NOME_RELATORIO { get; set; }
        public string REL_NOME_CAMPO { get; set; }
        public string REL_TIPO_CAMPO { get; set; }
        public int? REL_POS_X { get; set; }
        public int? REL_POS_Y { get; set; }
        public int? REL_TAMANHO_FONTE { get; set; }
        public string OperationalEntityId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public string OperationalEntity => "Relatorios";
 public string? OperationalRecordId => OperationalEntityId;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration