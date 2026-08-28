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
    public struct OrcamentoReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? ORC_ID { get; set; }
        public string REP_ID { get; set; }
        public string CON_ID { get; set; }
        public string ORC_TIPO_FRETE { get; set; }
        public DateTime? ORC_EMISSAO { get; set; }
        public string CLI_ID { get; set; }
        public int? VER_ID { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration