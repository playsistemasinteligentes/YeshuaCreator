// Escopo: 
using Command.Write;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Dominio.Interfaces;
using Command.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class WorkerPollingOutBoxUseCaseReceiver : ReciverBase< WorkerPollingOutBoxUseCaseInputCommand, WorkerPollingOutBoxUseCaseOutputCommand>
    {


        protected override State<WorkerPollingOutBoxUseCaseOutputCommand> Action(WorkerPollingOutBoxUseCaseInputCommand comand)
        {
            try
            {
                 State<WorkerPollingOutBoxUseCaseOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<WorkerPollingOutBoxUseCaseOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<WorkerPollingOutBoxUseCaseOutputCommand> state, Command.UseCase.WorkerPollingOutBoxUseCaseInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase