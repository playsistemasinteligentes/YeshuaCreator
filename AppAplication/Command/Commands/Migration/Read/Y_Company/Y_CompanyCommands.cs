using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Commands.Read
{
    public struct Y_CompanyReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string ProxyServer { get; set; }
        public int? UserIDAdmin { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration