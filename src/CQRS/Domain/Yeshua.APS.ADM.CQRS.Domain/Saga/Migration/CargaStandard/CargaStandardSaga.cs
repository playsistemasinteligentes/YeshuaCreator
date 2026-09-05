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
    public class CargaStandardSaga : SagaBase
    {
        public const string STEP_1 = "DefinirDadosTransporte";
        public const string STEP_2 = "EnviarNotasFiscais";
        public const string STEP_3 = "GerarCTe";
        public const string STEP_4 = "GerarMDFe";

        public CargaStandardSaga()
        {
            AddStep(new CargaStandardStep(STEP_1, 1));
            AddStep(new CargaStandardStep(STEP_2, 2));
            AddStep(new CargaStandardStep(STEP_3, 3));
            AddStep(new CargaStandardStep(STEP_4, 4));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers