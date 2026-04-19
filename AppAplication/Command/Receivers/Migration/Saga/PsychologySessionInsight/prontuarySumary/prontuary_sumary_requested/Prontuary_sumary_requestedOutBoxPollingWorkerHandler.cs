// Escopo: 
using Command.Write;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Dominio.Interfaces;
using Command.UseCase;
using Command.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Saga
{
    public partial class Prontuary_sumary_requestedOutBoxPollingWorkerHandler : ReciverBase< Prontuary_sumary_requestedOutBoxPollingWorkerInputCommand, Prontuary_sumary_requestedOutBoxPollingWorkerOutputCommand>
    {


        protected override State<Prontuary_sumary_requestedOutBoxPollingWorkerOutputCommand> Action(Prontuary_sumary_requestedOutBoxPollingWorkerInputCommand comand)
        {
            try
            {
                 State<Prontuary_sumary_requestedOutBoxPollingWorkerOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<Prontuary_sumary_requestedOutBoxPollingWorkerOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<Prontuary_sumary_requestedOutBoxPollingWorkerOutputCommand> state, Prontuary_sumary_requestedOutBoxPollingWorkerInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase