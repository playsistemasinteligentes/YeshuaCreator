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
namespace Command.Read
{
    public struct T_IndicadoresReadCommand : ICommandRead
    {
        public int? IND_ID { get; set; }
        public string IND_DESCRICAO { get; set; }
        public int? NEG_ID { get; set; }
        public string DESC_CALCULO { get; set; }
        public int? IND_TIPOCOMPARADOR { get; set; }
        public int? IND_GRAFICO { get; set; }
        public string IND_CONEXAO { get; set; }
        public DateTime? IND_DTCRIACAO { get; set; }
        public string RESPOSAVELIND { get; set; }
        public string RESPOSAVELCARGA { get; set; }
        public string PROCEXTRACAO { get; set; }
        public string PER_ID { get; set; }
        public string DIM_ID { get; set; }
        public string DOM_EMPRESA { get; set; }
        public string DOM_FILIAL { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration