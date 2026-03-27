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
    public partial class WorkerPollingInboxUseCaseReceiver : ReciverBase< WorkerPollingInboxUseCaseInputCommand, WorkerPollingInboxUseCaseOutputCommand>
    {


        protected override State<WorkerPollingInboxUseCaseOutputCommand> Action(WorkerPollingInboxUseCaseInputCommand comand)
        {
            try
            {
                Console.Write("0999999");
                State<WorkerPollingInboxUseCaseOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<WorkerPollingInboxUseCaseOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<WorkerPollingInboxUseCaseOutputCommand> state, Command.UseCase.WorkerPollingInboxUseCaseInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase