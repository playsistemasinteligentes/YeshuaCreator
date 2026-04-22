using Dominio.Patterns.Saga;

namespace Dominio.Saga
{
    public class PsychologySessionInsightSaga : SagaBase
    {
        public const string STEP_1 = "audioTranscriptRequested";
        public const string STEP_2 = "audioTranscriptGenerated";
        public const string STEP_3 = "prontuarySumaryRequested";
        public const string STEP_4 = "prontuarySumaryGenerated";

        public PsychologySessionInsightSaga()
        {
            AddStep(new PsychologySessionInsightStep(STEP_1));
            AddStep(new PsychologySessionInsightStep(STEP_2));
            AddStep(new PsychologySessionInsightStep(STEP_3));
            AddStep(new PsychologySessionInsightStep(STEP_4));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers