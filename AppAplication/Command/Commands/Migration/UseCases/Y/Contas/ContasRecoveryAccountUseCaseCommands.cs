using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
namespace Command.Commands
{
    public partial struct ContasRecoveryAccountUseCaseCommand : ICommand
    {
    public string email { get; set; }
    public TypeNotification typeNotification { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup