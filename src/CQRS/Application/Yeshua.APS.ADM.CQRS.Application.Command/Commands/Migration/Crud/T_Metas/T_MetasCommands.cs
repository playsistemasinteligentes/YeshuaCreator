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
    public struct T_MetasCrudCommand : ICommand
    {
        public int MET_ID { get; set; }
        public string MET_DTINICIO { get; set; }
        public string MET_DTFIM { get; set; }
        public string MET_ALVO { get; set; }
        public int MET_TIPOALVO { get; set; }
        public int IND_ID { get; set; }
        public Decimal? MET_RANGE01 { get; set; }
        public Decimal? MET_RANGE02 { get; set; }
        public Decimal? MET_RANGE03 { get; set; }
        public int? DIM_ID { get; set; }
        public string FAT_ID { get; set; }
        public string DIM_SUBDIMENSAO_ID { get; set; }
        public string PER_ID { get; set; }
        public string DOM_EMPRESA { get; set; }
        public string DOM_FILIAL { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration