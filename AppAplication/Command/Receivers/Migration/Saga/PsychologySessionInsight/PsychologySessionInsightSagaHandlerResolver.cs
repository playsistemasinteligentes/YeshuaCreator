using Command.Saga;
using RepositoryInterfaces.Patterns.Saga;
using Dominio.Saga;
using System;
using System.Collections.Generic;

namespace Command.Receivers
{
    public class PsychologySessionInsightSagaHandlerResolver : ISagaHandlerResolver
    {
        private readonly AudioTranscriptRequestedHandler _AudioTranscriptRequestedHandler;
        private readonly AudioTranscriptGeneratedHandler _AudioTranscriptGeneratedHandler;
        private readonly ProntuarySumaryRequestedHandler _ProntuarySumaryRequestedHandler;
        private readonly ProntuarySumaryGeneratedHandler _ProntuarySumaryGeneratedHandler;

        public PsychologySessionInsightSagaHandlerResolver(AudioTranscriptRequestedHandler AudioTranscriptRequestedHandler, AudioTranscriptGeneratedHandler AudioTranscriptGeneratedHandler, ProntuarySumaryRequestedHandler ProntuarySumaryRequestedHandler, ProntuarySumaryGeneratedHandler ProntuarySumaryGeneratedHandler)
        {
            _AudioTranscriptRequestedHandler = AudioTranscriptRequestedHandler;
            _AudioTranscriptGeneratedHandler = AudioTranscriptGeneratedHandler;
            _ProntuarySumaryRequestedHandler = ProntuarySumaryRequestedHandler;
            _ProntuarySumaryGeneratedHandler = ProntuarySumaryGeneratedHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { PsychologySessionInsightSaga.STEP_1, _AudioTranscriptRequestedHandler },
                { PsychologySessionInsightSaga.STEP_2, _AudioTranscriptGeneratedHandler },
                { PsychologySessionInsightSaga.STEP_3, _ProntuarySumaryRequestedHandler },
                { PsychologySessionInsightSaga.STEP_4, _ProntuarySumaryGeneratedHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers