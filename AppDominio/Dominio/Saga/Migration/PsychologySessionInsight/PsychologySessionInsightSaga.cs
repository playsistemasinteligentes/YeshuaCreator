using Dominio.Patterns.Saga;

namespace Dominio.Saga
{
    public class PsychologySessionInsightSaga : SagaBase
    {
        public const string STEP_1 = "audio_transcript_requested";
        public const string STEP_2 = "audio_transcript_generated";
        //public const string STEP_3 = "summary_requested";
        //public const string STEP_4 = "summary_generated";

        public PsychologySessionInsightSaga()
        {
            AddStep(new PsychologyStep(STEP_1));
            AddStep(new PsychologyStep(STEP_2));
            //  AddStep(new PsychologyStep(STEP_3));
            //  AddStep(new PsychologyStep(STEP_4));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase