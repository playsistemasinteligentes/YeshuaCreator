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
    public struct ObservacoesCrudCommand : ICommand
    {
        public int OBS_ID { get; set; }
        public string OBS_TIPO { get; set; }
        public string OBS_DESCRICAO { get; set; }
        public string CLI_ID { get; set; }
        public string MAQ_ID { get; set; }
        public string PRO_ID { get; set; }
        public int? ROT_SEQ_TRANFORMACAO { get; set; }
        public string OBS_INTEGRACAO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration