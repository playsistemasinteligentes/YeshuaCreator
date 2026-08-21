// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Patterns.Saga;

namespace Dominio.Saga
{
    public class PsychologySessionInsightSaga : SagaBase
    {
        public const string STEP_1 = "AudioTranscriptRequested";
        public const string STEP_2 = "ReportEndProntuaryRequested";

        public PsychologySessionInsightSaga()
        {
            AddStep(new PsychologySessionInsightStep(STEP_1, 1));
            AddStep(new PsychologySessionInsightStep(STEP_2, 2));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers