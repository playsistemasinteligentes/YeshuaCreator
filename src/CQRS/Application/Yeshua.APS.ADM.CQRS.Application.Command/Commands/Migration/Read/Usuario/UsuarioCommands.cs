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
    public struct UsuarioReadCommand : ICommandRead
    {
        public int? USE_ID { get; set; }
        public string USE_NOME { get; set; }
        public string USE_EMAIL { get; set; }
        public string USE_SENHA { get; set; }
        public string TURM_ID { get; set; }
        public int? USE_ATIVO { get; set; }
        public string USE_CODERP { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration