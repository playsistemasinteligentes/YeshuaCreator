using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Microsoft.AspNetCore.Http;
namespace Command.Saga
{
public partial record Prontuary_sumary_generatedInBoxPollingWorkerInputCommand : ICommand
{
    public List<int> lst { get; set; }
}

public partial record Prontuary_sumary_generatedInBoxPollingWorkerOutputCommand : ICommand
{
    public List<int> lst { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup