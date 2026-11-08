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
    public class EmissaoCTeComplementarStandardSaga : SagaBase
    {
        public const string STEP_1 = "ReceberCTeComplementarProntoParaEmissao";
        public const string STEP_2 = "ValidarCTeOriginalEComplemento";
        public const string STEP_3 = "PrepararCTeComplementar";
        public const string STEP_4 = "AutorizarCTeComplementarNaSefaz";
        public const string STEP_5 = "FinalizarCTeComplementar";

        public EmissaoCTeComplementarStandardSaga()
        {
            AddStep(new EmissaoCTeComplementarStandardStep(STEP_1, 1));
            AddStep(new EmissaoCTeComplementarStandardStep(STEP_2, 2));
            AddStep(new EmissaoCTeComplementarStandardStep(STEP_3, 3));
            AddStep(new EmissaoCTeComplementarStandardStep(STEP_4, 4));
            AddStep(new EmissaoCTeComplementarStandardStep(STEP_5, 5));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers