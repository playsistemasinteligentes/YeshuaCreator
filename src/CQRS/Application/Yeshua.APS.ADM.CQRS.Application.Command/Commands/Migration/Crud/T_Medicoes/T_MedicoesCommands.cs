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
    public struct T_MedicoesCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int MED_ID { get; set; }
        public int? IND_ID { get; set; }
        public int? MET_ID { get; set; }
        public int? UNI_ID { get; set; }
        public DateTime MED_DATA { get; set; }
        public string MED_VALOR { get; set; }
        public string MED_AC_ANO { get; set; }
        public string MED_DATAMEDICAO { get; set; }
        public Decimal? MED_PONDERACAO { get; set; }
        public string DIM_ID { get; set; }
        public string DIM_DESCRICAO { get; set; }
        public string DIM_SUBDIMENSAO_ID { get; set; }
        public string DIM_SUB_DESCRICAO { get; set; }
        public string PER_ID { get; set; }
        public string PER_DESCRICAO { get; set; }
        public string FAT_ID { get; set; }
        public string FAT_DESCRICAO { get; set; }
        public string MED_SQL { get; set; }
        public string DOM_EMPRESA { get; set; }
        public string DOM_FILIAL { get; set; }
        public string MED_VALOR_DISPER { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration