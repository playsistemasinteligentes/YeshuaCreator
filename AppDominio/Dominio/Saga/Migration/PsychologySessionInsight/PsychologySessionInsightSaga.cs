using Dominio.Patterns.Saga;

namespace Dominio.Saga
{
    public class PsychologySessionInsightSaga : SagaBase
    {
        public const string STEP_1 = "AudioTranscriptRequested";
        public const string STEP_2 = "AudioTranscriptGenerated";
        public const string STEP_3 = "ProntuarySumaryRequested";
        public const string STEP_4 = "ProntuarySumaryGenerated";

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