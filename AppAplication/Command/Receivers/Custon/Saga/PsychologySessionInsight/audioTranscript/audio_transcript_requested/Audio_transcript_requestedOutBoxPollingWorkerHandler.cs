using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Saga
{
    public partial class Audio_transcript_requestedOutBoxPollingWorkerHandler
    {
partial void CustomActionHook(ref State<Audio_transcript_requestedOutBoxPollingWorkerOutputCommand> state, Audio_transcript_requestedOutBoxPollingWorkerInputCommand comand)
{
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase