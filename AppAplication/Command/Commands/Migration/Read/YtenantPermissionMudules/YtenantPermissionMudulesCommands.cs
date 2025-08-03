using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct YtenantPermissionMudulesReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string permissionModulesId { get; set; }
        public int? TenantID { get; set; }
        public DateTime? ValidUntil { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration