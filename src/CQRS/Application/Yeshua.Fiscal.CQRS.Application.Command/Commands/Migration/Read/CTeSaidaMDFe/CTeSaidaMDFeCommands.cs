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
    public struct CTeSaidaMDFeReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? CTeTentativaEmissaoId { get; set; }
        public string CorrelationId { get; set; }
        public string ChaveAcessoCTe { get; set; }
        public string SnapshotHash { get; set; }
        public string OutboxMessageId { get; set; }
        public DateTime? PublicadoEmUtc { get; set; }
        public string UltimoErro { get; set; }
        public List<int> Status { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration