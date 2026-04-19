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
    public partial class Audio_transcript_generatedInBoxPollingWorkerHandler : ReciverBase< Audio_transcript_generatedInBoxPollingWorkerInputCommand, Audio_transcript_generatedInBoxPollingWorkerOutputCommand>
    {


        protected override State<Audio_transcript_generatedInBoxPollingWorkerOutputCommand> Action(Audio_transcript_generatedInBoxPollingWorkerInputCommand comand)
        {
            try
            {
                 State<Audio_transcript_generatedInBoxPollingWorkerOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<Audio_transcript_generatedInBoxPollingWorkerOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<Audio_transcript_generatedInBoxPollingWorkerOutputCommand> state, Audio_transcript_generatedInBoxPollingWorkerInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase