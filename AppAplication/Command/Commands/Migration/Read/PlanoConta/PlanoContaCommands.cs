using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct PlanoContaReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public List<int> Tipo { get; set; }
        public int? ContaPaiId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration