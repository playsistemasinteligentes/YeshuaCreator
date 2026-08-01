using RepositoryInterfaces.Patterns.Command;
using Command.Patterns.Command;
using Dominio.Enum.Strategy;
using Microsoft.AspNetCore.Http;
namespace Command.Saga
{
public partial record ProntuarySumaryRequestedOutBoxPollingWorkerInputCommand : ICommand
{
    public List<int> lst { get; set; }
}

public partial record ProntuarySumaryRequestedOutBoxPollingWorkerOutputCommand : ICommand
{
    public List<int> lst { get; set; }
}

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsUseCaseGroup