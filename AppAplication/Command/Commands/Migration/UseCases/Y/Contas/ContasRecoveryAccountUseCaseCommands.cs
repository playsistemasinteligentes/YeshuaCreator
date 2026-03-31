using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Microsoft.AspNetCore.Http;
namespace Command.UseCase
{
public partial record ContasRecoveryAccountUseCaseInputCommand : ICommand
{
    public string email { get; set; }
    public TypeNotification typeNotification { get; set; }
}

public partial record ContasRecoveryAccountUseCaseOutputCommand : ICommand
{
    public string email { get; set; }
    public TypeNotification typeNotification { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup