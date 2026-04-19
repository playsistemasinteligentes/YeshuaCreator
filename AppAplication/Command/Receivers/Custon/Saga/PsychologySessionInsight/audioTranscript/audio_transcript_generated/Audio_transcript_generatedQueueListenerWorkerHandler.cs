using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Saga
{
    public partial class Audio_transcript_generatedQueueListenerWorkerHandler
    {
        partial void CustomActionHook(ref State<Audio_transcript_generatedQueueListenerWorkerOutputCommand> state, Audio_transcript_generatedQueueListenerWorkerInputCommand comand)
        {
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase