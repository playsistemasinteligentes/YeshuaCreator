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
    public partial class Prontuary_sumary_generatedInBoxPollingWorkerHandler : ReciverBase< Prontuary_sumary_generatedInBoxPollingWorkerInputCommand, Prontuary_sumary_generatedInBoxPollingWorkerOutputCommand>
    {


        protected override State<Prontuary_sumary_generatedInBoxPollingWorkerOutputCommand> Action(Prontuary_sumary_generatedInBoxPollingWorkerInputCommand comand)
        {
            try
            {
                 State<Prontuary_sumary_generatedInBoxPollingWorkerOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<Prontuary_sumary_generatedInBoxPollingWorkerOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<Prontuary_sumary_generatedInBoxPollingWorkerOutputCommand> state, Prontuary_sumary_generatedInBoxPollingWorkerInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase