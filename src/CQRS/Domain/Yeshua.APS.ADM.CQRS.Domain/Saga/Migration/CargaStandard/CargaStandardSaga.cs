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
        public const string STEP_1 = "CriarCarga";
        public const string STEP_2 = "DefinirDadosTransporte";
        public const string STEP_3 = "PrepararCargaParaFiscal";
        public const string STEP_4 = "PublicarCargaProntaParaEmissaoFiscal";
        public const string STEP_5 = "AguardarResultadoFiscalDaCarga";
        public const string STEP_6 = "LiberarCargaParaExpedicao";

        public CargaStandardSaga()
        {
            AddStep(new CargaStandardStep(STEP_1, 1));
            AddStep(new CargaStandardStep(STEP_2, 2));
            AddStep(new CargaStandardStep(STEP_3, 3));
            AddStep(new CargaStandardStep(STEP_4, 4));
            AddStep(new CargaStandardStep(STEP_5, 5));
            AddStep(new CargaStandardStep(STEP_6, 6));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers