using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Microsoft.AspNetCore.Http;
namespace Command.Saga
{
public partial record AudioTranscriptGeneratedQueueListenerWorkerInputCommand : ICommand
{
    public List<int> lst { get; set; }
}

public partial record AudioTranscriptGeneratedQueueListenerWorkerOutputCommand : ICommand
{
    public List<int> lst { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup