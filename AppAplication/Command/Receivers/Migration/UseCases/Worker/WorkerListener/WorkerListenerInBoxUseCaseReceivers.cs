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
    public partial class WorkerListenerInBoxUseCaseReceiver : ReciverBase< WorkerListenerInBoxUseCaseInputCommand, WorkerListenerInBoxUseCaseOutputCommand>
    {


        protected override State<WorkerListenerInBoxUseCaseOutputCommand> Action(WorkerListenerInBoxUseCaseInputCommand comand)
        {
            try
            {
                 State<WorkerListenerInBoxUseCaseOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<WorkerListenerInBoxUseCaseOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<WorkerListenerInBoxUseCaseOutputCommand> state, Command.UseCase.WorkerListenerInBoxUseCaseInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase