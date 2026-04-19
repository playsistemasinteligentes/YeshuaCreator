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

namespace Command.Receivers.Migration.Saga.PsychologySessionInsight.audioTranscript.audio_transcript_generated
{
    public partial class AudioTranscriptGeneratedHandler : ISagaStepHandler
    {
        public string Key => PsychologySessionInsightSaga.STEP_2;

        public bool IsAsync => true;

        public void Execute(SagaBase saga, SagaStepBase step)
        {
            saga.MarkInProgress();

            CustomActionHook(saga, step);
            
            saga.MarkWaiting(step.CorrelationId);
        }
        partial void CustomActionHook(SagaBase saga, SagaStepBase step);
    }
}
