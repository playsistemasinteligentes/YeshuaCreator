using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
namespace Command.Commands
{
    public partial struct ContasRecoveryAccountUseCaseCommand : ICommand
    {
    public string email { get; set; }
    public typenotification typeNotification { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup