using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
namespace Command.Commands
{
    public partial record ContasLoginUseCaseCommand : ICommand
    {
    public string email { get; set; }
    public string password { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup