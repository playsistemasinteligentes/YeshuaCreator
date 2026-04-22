using Command.Saga;
using RepositoryInterfaces.Patterns.Saga;
using Dominio.Saga;
using System;
using System.Collections.Generic;

namespace Command.Receivers
{
    public class PsychologySessionInsightSagaHandlerResolver : ISagaHandlerResolver
    {
        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { PsychologySessionInsightSaga.STEP_1, new audioTranscriptRequestedHandler() },
                { PsychologySessionInsightSaga.STEP_2, new audioTranscriptGeneratedHandler() },
                { PsychologySessionInsightSaga.STEP_3, new prontuarySumaryRequestedHandler() },
                { PsychologySessionInsightSaga.STEP_4, new prontuarySumaryGeneratedHandler() },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers