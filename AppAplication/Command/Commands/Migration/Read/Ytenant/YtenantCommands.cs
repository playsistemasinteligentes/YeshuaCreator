using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Commands.Read
{
    public struct YtenantReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public int? CnpjCpf { get; set; }
        public string Nome { get; set; }
        public int? UserIDAdmin { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration