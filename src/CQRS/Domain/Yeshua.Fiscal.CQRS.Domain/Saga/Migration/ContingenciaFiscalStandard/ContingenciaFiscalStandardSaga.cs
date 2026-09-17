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
    public class ContingenciaFiscalStandardSaga : SagaBase
    {
        public const string STEP_1 = "PrepararEntradaContingencia";
        public const string STEP_2 = "ValidarPlanoEmissaoFiscal";
        public const string STEP_3 = "PublicarPlanoParaSagaFiscal";
        public const string STEP_4 = "AguardarResultadoEmissaoFiscal";
        public const string STEP_5 = "FinalizarContingenciaFiscal";

        public ContingenciaFiscalStandardSaga()
        {
            AddStep(new ContingenciaFiscalStandardStep(STEP_1, 1));
            AddStep(new ContingenciaFiscalStandardStep(STEP_2, 2));
            AddStep(new ContingenciaFiscalStandardStep(STEP_3, 3));
            AddStep(new ContingenciaFiscalStandardStep(STEP_4, 4));
            AddStep(new ContingenciaFiscalStandardStep(STEP_5, 5));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers