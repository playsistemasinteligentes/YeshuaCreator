using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct yTenantCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string CnpjCpf { get; set; }
        public string Nome { get; set; }
        public int? UserId { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration