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
    public struct TipoTesteCrudCommand : ICommand
    {
        public Decimal? TT_ESPECIFICACAO { get; set; }
        public string TT_ORIGEM_ESPECIFICACAO { get; set; }
        public string TT_IMPRIME_NO_LAUDO { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public int TT_ID { get; set; }
        public string TT_NOME { get; set; }
        public string TT_DESC { get; set; }
        public Decimal? TT_TOL_MAIS { get; set; }
        public Decimal? TT_TOL_MENOS { get; set; }
        public string TT_NORMA { get; set; }
        public string TT_INICIO_PROCESSO { get; set; }
        public int TA_ID { get; set; }
        public string UNI_ID { get; set; }
        public int? TT_N_AMOSTRAS_P_TESTE { get; set; }
        public int? TT_MAX_DEF_CRITICO { get; set; }
        public int? TT_MAX_DEF_GRAVE { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration