using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YtenantPermissionMudulesCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string permissionModulesId { get; set; }
        public int? TenantID { get; set; }
        public DateTime? ValidUntil { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration