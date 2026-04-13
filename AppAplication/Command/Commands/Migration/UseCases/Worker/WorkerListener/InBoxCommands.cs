using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Microsoft.AspNetCore.Http;
namespace Command.UseCase
{
public partial record InBoxInputCommand : ICommand
{
    public string text { get; set; }
}

public partial record InBoxOutputCommand : ICommand
{
    public string text { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup