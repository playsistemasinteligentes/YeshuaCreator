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
    public class EncerramentoMDFeStandardSaga : SagaBase
    {
        public const string STEP_1 = "SolicitarEncerramentoMDFe";
        public const string STEP_2 = "PrepararEventoEncerramentoMDFe";
        public const string STEP_3 = "AutorizarEncerramentoMDFeNaSefaz";
        public const string STEP_4 = "PublicarMDFeEncerrado";

        public EncerramentoMDFeStandardSaga()
        {
            AddStep(new EncerramentoMDFeStandardStep(STEP_1, 1));
            AddStep(new EncerramentoMDFeStandardStep(STEP_2, 2));
            AddStep(new EncerramentoMDFeStandardStep(STEP_3, 3));
            AddStep(new EncerramentoMDFeStandardStep(STEP_4, 4));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers