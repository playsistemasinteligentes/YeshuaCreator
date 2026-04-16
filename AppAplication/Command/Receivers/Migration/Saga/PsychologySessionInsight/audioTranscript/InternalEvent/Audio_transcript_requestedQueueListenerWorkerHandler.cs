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
    public partial class Audio_transcript_requestedQueueListenerWorkerHandler : ReciverBase< Audio_transcript_requestedQueueListenerWorkerInputCommand, Audio_transcript_requestedQueueListenerWorkerOutputCommand>
    {


        protected override State<Audio_transcript_requestedQueueListenerWorkerOutputCommand> Action(Audio_transcript_requestedQueueListenerWorkerInputCommand comand)
        {
            try
            {
                 State<Audio_transcript_requestedQueueListenerWorkerOutputCommand> retorno = Success("OK", null);
                 CustomActionHook(ref retorno, comand);
                 return retorno;
            }
            catch (ReceiverException<Audio_transcript_requestedQueueListenerWorkerOutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<Audio_transcript_requestedQueueListenerWorkerOutputCommand> state, Audio_transcript_requestedQueueListenerWorkerInputCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase