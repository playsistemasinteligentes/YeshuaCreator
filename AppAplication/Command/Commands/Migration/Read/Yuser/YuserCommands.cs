using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct yUserReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration