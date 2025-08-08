using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct yPerfilGrantCrudCommand : ICommand
    {
        public int? PerfilId { get; set; }
        public string GrantId { get; set; }
        public bool? Grant { get; set; }
        public bool? Create { get; set; }
        public bool? Read { get; set; }
        public bool? Update { get; set; }
        public bool? Delete { get; set; }
        public DateTime? ValidUntil { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration