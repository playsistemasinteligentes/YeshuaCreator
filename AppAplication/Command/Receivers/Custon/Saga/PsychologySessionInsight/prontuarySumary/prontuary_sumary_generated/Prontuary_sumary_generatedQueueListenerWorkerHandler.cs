using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Saga
{
    public partial class Prontuary_sumary_generatedQueueListenerWorkerHandler
    {
partial void CustomActionHook(ref State<Prontuary_sumary_generatedQueueListenerWorkerOutputCommand> state, Prontuary_sumary_generatedQueueListenerWorkerInputCommand comand)
{
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase