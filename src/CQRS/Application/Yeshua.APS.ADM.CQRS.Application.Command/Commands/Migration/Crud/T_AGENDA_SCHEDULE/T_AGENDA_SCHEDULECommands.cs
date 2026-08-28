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
    public struct T_AGENDA_SCHEDULECrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int AGE_ID { get; set; }
        public DateTime? AGE_DATA_ESPECIFICA { get; set; }
        public string AGE_HORARIO_INICIO { get; set; }
        public string AGE_HORARIO_FIM { get; set; }
        public string AGE_SEGUNDA { get; set; }
        public string AGE_TERCA { get; set; }
        public string AGE_QUARTA { get; set; }
        public string AGE_QUINTA { get; set; }
        public string AGE_SEXTA { get; set; }
        public string AGE_SABADO { get; set; }
        public string AGE_DOMINGO { get; set; }
        public Decimal? AGE_INTERVALO { get; set; }
        public string AGE_ORDEM_EXECUCAO { get; set; }
        public string AGE_PARAMETROS { get; set; }
        public string AGE_EXCECAO { get; set; }
        public string AGE_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration