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
    public class TesteSyncSaga : SagaBase
    {
        public const string STEP_1 = "TesteSyncPasso1";
        public const string STEP_2 = "TesteSyncPasso2";
        public const string STEP_3 = "TesteSyncPasso3";
        public const string STEP_4 = "TesteSyncPasso4";
        public const string STEP_5 = "TesteSyncPasso5";

        public TesteSyncSaga()
        {
            AddStep(new TesteSyncStep(STEP_1, 1));
            AddStep(new TesteSyncStep(STEP_2, 2));
            AddStep(new TesteSyncStep(STEP_3, 3));
            AddStep(new TesteSyncStep(STEP_4, 4));
            AddStep(new TesteSyncStep(STEP_5, 5));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers