using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Saga;
using RepositoryInterfaces.Patterns.Saga;

namespace Command.Receivers
{
    public class PsychologySessionInsightSagaHandlerResolver : ISagaHandlerResolver
    {
        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
        {
            { PsychologySessionInsightSaga.STEP_1, new Command.Receivers.Migration.Saga.PsychologySessionInsight.audioTranscript.audio_transcript_requested.AudioTranscriptRequestedHandler() },
            { PsychologySessionInsightSaga.STEP_2, new Command.Receivers.Migration.Saga.PsychologySessionInsight.audioTranscript.audio_transcript_generated.AudioTranscriptGeneratedHandler() }
            //{ PsychologySessionInsightSaga.STEP_3, new SummaryRequestedHandler() },
            //{ PsychologySessionInsightSaga.STEP_4, new SummaryGeneratedHandler() }

        };
        }
    }
}
