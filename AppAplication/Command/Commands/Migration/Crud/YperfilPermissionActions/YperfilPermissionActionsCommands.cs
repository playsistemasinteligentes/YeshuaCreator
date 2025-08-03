using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct YperfilPermissionActionsCrudCommand : ICommand
    {
        public int? PerfilId { get; set; }
        public string permissionActionsId { get; set; }
        public bool? Grant { get; set; }
        public bool? Create { get; set; }
        public bool? Read { get; set; }
        public bool? Update { get; set; }
        public bool? Delete { get; set; }
        public DateTime? ValidUntil { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration