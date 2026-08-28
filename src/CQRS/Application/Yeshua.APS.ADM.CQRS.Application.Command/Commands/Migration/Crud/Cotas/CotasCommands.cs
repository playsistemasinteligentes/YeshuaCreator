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
    public struct CotasCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int COT_ID { get; set; }
        public DateTime? COT_DATA_DE { get; set; }
        public DateTime? COT_DATA_ATE { get; set; }
        public Decimal? COT_VALOR { get; set; }
        public Decimal? COT_OCUPADO { get; set; }
        public int REP_ID { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration