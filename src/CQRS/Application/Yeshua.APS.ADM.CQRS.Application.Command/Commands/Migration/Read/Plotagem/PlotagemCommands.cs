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
    public struct PlotagemReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? PLO_ID { get; set; }
        public string PLO_NOME { get; set; }
        public string PLO_DIMENSAO { get; set; }
        public string PLO_X { get; set; }
        public string PLO_Y { get; set; }
        public string PLO_Z { get; set; }
        public string PLO_GRAFICO { get; set; }
        public int? CON_ID { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration