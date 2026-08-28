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
    public struct TipoInspecaoVisualCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int TIV_ID { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public string TIV_NOME { get; set; }
        public string TIV_DESCRICAO { get; set; }
        public string TIV_FECHAMENTO { get; set; }
        public string TIV_AMOSTRA_ALEATORIA { get; set; }
        public int? TIV_N_AMOSTRAS { get; set; }
        public string TIV_MEDIDA { get; set; }
        public Decimal? TIV_ESPECIFICACAO { get; set; }
        public Decimal? TIV_TOL_MAIS { get; set; }
        public Decimal? TIV_TOL_MENOS { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration