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
    public struct PlanoacaoCrudCommand : ICommand
    {
        public int PLA_ID { get; set; }
        public string PLA_DESCRICAO { get; set; }
        public int? MET_ID { get; set; }
        public string PLA_STATUS { get; set; }
        public DateTime? PLA_DATA { get; set; }
        public string PLA_METAPERIODO { get; set; }
        public string PLA_VLRPERIODO { get; set; }
        public string PLA_METACULADO { get; set; }
        public string PLA_VLRACUMULADO { get; set; }
        public string PLA_REFERENCIA { get; set; }
        public int USE_ID { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration