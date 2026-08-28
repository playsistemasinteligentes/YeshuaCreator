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
    public struct PlanoAmostralTesteCrudCommand : ICommand
    {
        public Decimal? GRP_TIPO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public int PAT_ID { get; set; }
        public int? PAT_QTD_CAIXAS_DE { get; set; }
        public int? PAT_QTD_CAIXAS_ATE { get; set; }
        public int? PAT_N_AMOSTRAGEM { get; set; }
        public Decimal? PAT_PERCENT_ESPECIF { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration