using Dominio.Interfaces;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Saga
{
    public partial class Prontuary_sumary_generatedInBoxPollingWorkerHandler
    {
partial void CustomActionHook(ref State<Prontuary_sumary_generatedInBoxPollingWorkerOutputCommand> state, Prontuary_sumary_generatedInBoxPollingWorkerInputCommand comand)
{
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase