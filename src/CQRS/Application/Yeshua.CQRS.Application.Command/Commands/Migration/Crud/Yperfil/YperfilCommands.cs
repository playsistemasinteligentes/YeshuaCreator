using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct yPerfilCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration