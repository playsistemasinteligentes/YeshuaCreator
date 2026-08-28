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
    public struct TurmaCrudCommand : ICommand
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? TURM_HORA_INI_DIA1 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA1 { get; set; }
        public DateTime? TURM_HORA_INI_DIA2 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA2 { get; set; }
        public DateTime? TURM_HORA_INI_DIA3 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA3 { get; set; }
        public DateTime? TURM_HORA_INI_DIA4 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA4 { get; set; }
        public DateTime? TURM_HORA_INI_DIA5 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA5 { get; set; }
        public DateTime? TURM_HORA_INI_DIA6 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA6 { get; set; }
        public DateTime? TURM_HORA_INI_DIA7 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA7 { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration