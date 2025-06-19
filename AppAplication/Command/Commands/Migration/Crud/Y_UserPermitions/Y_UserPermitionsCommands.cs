using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
namespace Command.Commands
{
    public struct Y_UserPermitionsCrudCommand : ICommand
    {
        public int? UserId { get; set; }
        public string PermitionsId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration