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
    public struct CalendarioDisponibilidadeVeiculosCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int CDV_ID { get; set; }
        public DateTime? CDV_DATA_DE { get; set; }
        public DateTime? CDV_DATA_ATE { get; set; }
        public int? CDV_SEGUNDA { get; set; }
        public int? CDV_TERCA { get; set; }
        public int? CDV_QUARTA { get; set; }
        public int? CDV_QUINTA { get; set; }
        public int? CDV_SEXTA { get; set; }
        public int? CDV_SABADO { get; set; }
        public int? CDV_DOMINGO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration