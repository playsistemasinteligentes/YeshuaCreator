using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yTenantReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string CnpjCpf { get; set; }
        public string Nome { get; set; }
        public int? UserId { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration