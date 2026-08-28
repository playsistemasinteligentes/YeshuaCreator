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
    public struct T_PREFERENCIASReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? PRE_ID { get; set; }
        public string PRE_DESCRICAO { get; set; }
        public string PRE_NAMESPACE { get; set; }
        public string PRE_TIPO { get; set; }
        public string PRE_VALOR { get; set; }
        public int? USE_ID { get; set; }
        public int? PER_ID { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration