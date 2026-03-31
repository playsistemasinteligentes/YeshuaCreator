using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Microsoft.AspNetCore.Http;
namespace Command.UseCase
{
public partial record WorkerListenerInBoxUseCaseInputCommand : ICommand
{
    public string text { get; set; }
}

public partial record WorkerListenerInBoxUseCaseOutputCommand : ICommand
{
    public string text { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup