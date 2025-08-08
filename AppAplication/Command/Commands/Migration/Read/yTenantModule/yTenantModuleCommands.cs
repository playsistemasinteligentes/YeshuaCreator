using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yTenantModuleReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string ModuleId { get; set; }
        public int? TenantID { get; set; }
        public DateTime? ValidUntil { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration