using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Microsoft.AspNetCore.Http;
namespace Command.Saga
{
public partial record Audio_transcript_generatedQueueListenerWorkerInputCommand : ICommand
{
    public List<int> lst { get; set; }
}

public partial record Audio_transcript_generatedQueueListenerWorkerOutputCommand : ICommand
{
    public List<int> lst { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup