using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct ProfissionalReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int? EspecialidadeId { get; set; }
        public string Telefone { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration