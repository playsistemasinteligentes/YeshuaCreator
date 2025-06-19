using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Commands.Read
{
    public struct Y_PermtionsReadCommand : ICommandRead
    {
        public string Id { get; set; }
        public string Description { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration