using RepositoryInterfaces.Patterns.Saga;
using Dominio.Saga;
using System;
using System.Collections.Generic;

namespace Command.Receivers
{
    public class PsychologySessionInsightSagaHandlerResolver : ISagaHandlerResolver
    {
        private readonly AudioTranscriptRequestedHandler _AudioTranscriptRequestedHandler;
        private readonly ReportEndProntuaryRequestedHandler _ReportEndProntuaryRequestedHandler;

        public PsychologySessionInsightSagaHandlerResolver(AudioTranscriptRequestedHandler AudioTranscriptRequestedHandler, ReportEndProntuaryRequestedHandler ReportEndProntuaryRequestedHandler)
        {
            _AudioTranscriptRequestedHandler = AudioTranscriptRequestedHandler;
            _ReportEndProntuaryRequestedHandler = ReportEndProntuaryRequestedHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { PsychologySessionInsightSaga.STEP_1, _AudioTranscriptRequestedHandler },
                { PsychologySessionInsightSaga.STEP_2, _ReportEndProntuaryRequestedHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers