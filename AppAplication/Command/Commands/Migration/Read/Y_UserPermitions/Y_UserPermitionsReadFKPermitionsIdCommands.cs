using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Commands.Read
{
    public struct Y_UserPermitionsReadFKPermitionsIdCommand : ICommand
    {
        public string Id { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration