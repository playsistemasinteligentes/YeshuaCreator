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
    public partial class WorkerInboxUseCaseReceiver : ReciverBase< WorkerInboxUseCaseInputCommand, WorkerInboxUseCaseOutputCommand>
    {


        protected override State<WorkerInboxUseCaseOutputCommand> Action(WorkerInboxUseCaseInputCommand comand)
        {
            try
            {
                 State<WorkerInboxUseCaseOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<WorkerInboxUseCaseOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<WorkerInboxUseCaseOutputCommand> state, Command.UseCase.WorkerInboxUseCaseInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase