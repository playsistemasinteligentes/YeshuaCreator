using Command.Saga;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Migration.Saga.PsychologySessionInsight.audioTranscript.audio_transcript_requested
{
    public class AudioTranscriptRequestedHandler : ISagaStepHandler
    {
        public string Key => PsychologySessionInsightSaga.STEP_1;

        public bool IsAsync => true;

        public void Execute(SagaBase saga, SagaStepBase step)
        {
            saga.MarkInProgress();

            // gerar outbox / chamar serviço externo

            saga.MarkWaiting(step.CorrelationId);
        }
    }
}
