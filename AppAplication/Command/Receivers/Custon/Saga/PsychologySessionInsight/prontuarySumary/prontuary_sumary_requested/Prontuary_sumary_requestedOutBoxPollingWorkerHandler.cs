using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Saga
{
    public partial class Prontuary_sumary_requestedOutBoxPollingWorkerHandler
    {
partial void CustomActionHook(ref State<Prontuary_sumary_requestedOutBoxPollingWorkerOutputCommand> state, Prontuary_sumary_requestedOutBoxPollingWorkerInputCommand comand)
{
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase