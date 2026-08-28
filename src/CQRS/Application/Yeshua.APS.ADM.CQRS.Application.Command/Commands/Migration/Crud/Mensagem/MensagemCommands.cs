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
    public struct MensagemCrudCommand : ICommand
    {
        public string MEN_ID { get; set; }
        public string MEN_SEND { get; set; }
        public DateTime? MEN_EMISSION { get; set; }
        public string MEN_STATUS { get; set; }
        public string MEN_RECEIVE { get; set; }
        public string MEN_TYPE { get; set; }
        public Decimal? MEN_QTD_TRY_SEND { get; set; }
        public DateTime? MEN_DATE_TRY_SEND { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration