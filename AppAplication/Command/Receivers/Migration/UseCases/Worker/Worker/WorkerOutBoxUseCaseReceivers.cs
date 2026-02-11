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
    public partial class WorkerOutBoxUseCaseReceiver : ReciverBase< WorkerOutBoxUseCaseInputCommand, WorkerOutBoxUseCaseOutputCommand>
    {


        protected override State<WorkerOutBoxUseCaseOutputCommand> Action(WorkerOutBoxUseCaseInputCommand comand)
        {
            try
            {
                 State<WorkerOutBoxUseCaseOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<WorkerOutBoxUseCaseOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<WorkerOutBoxUseCaseOutputCommand> state, Command.UseCase.WorkerOutBoxUseCaseInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase