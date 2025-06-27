using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Commands
{
    public struct Y_TenantCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string ProxyServer { get; set; }
        public int? UserIDAdmin { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration