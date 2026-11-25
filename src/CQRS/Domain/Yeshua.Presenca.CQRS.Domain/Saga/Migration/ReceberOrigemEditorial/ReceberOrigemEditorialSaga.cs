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
    public class ReceberOrigemEditorialSaga : SagaBase
    {
        public const string STEP_1 = "RegistrarPautaDeOrigem";

        public ReceberOrigemEditorialSaga()
        {
            AddStep(new ReceberOrigemEditorialStep(STEP_1, 1));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers