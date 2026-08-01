using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Microsoft.AspNetCore.Http;
namespace Command.UseCase
{
public partial record RecoveryAccountInputCommand : ICommand
{
    public string email { get; set; }
    public TypeNotification typeNotification { get; set; }
}

public partial record RecoveryAccountOutputCommand : ICommand
{
    public string email { get; set; }
    public TypeNotification typeNotification { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup