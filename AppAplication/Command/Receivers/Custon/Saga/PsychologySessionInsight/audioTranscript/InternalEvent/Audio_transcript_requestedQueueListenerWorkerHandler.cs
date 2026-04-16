using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Saga
{
    public partial class Audio_transcript_requestedQueueListenerWorkerHandler
    {
partial void CustomActionHook(ref State<Audio_transcript_requestedQueueListenerWorkerOutputCommand> state, Audio_transcript_requestedQueueListenerWorkerInputCommand comand)
{
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase