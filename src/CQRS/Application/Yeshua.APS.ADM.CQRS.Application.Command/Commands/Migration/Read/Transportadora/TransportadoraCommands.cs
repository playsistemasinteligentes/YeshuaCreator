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
    public struct TransportadoraReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string TRA_ID { get; set; }
        public string TRA_NOME { get; set; }
        public string TRA_EMAIL { get; set; }
        public string TRA_RESPONSAVEL { get; set; }
        public string TRA_FONE { get; set; }
        public string TRA_ID_INTEGRACAO { get; set; }
        public string TRA_ID_INTEGRACAO_ERP { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration