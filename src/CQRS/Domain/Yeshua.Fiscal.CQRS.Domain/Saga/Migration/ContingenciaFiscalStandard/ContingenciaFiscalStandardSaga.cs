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
        public const string STEP_1 = "ReceberNotasFiscaisDaContingencia";
        public const string STEP_2 = "AnalisarNotasFiscaisDaContingencia";
        public const string STEP_3 = "EscolherModeloAgrupamentoCTe";
        public const string STEP_4 = "SimularAgrupamentoCTe";
        public const string STEP_5 = "InformarFreteERateio";
        public const string STEP_6 = "SimularRateioFrete";
        public const string STEP_7 = "InformarDadosTransporte";
        public const string STEP_8 = "ValidarPlanoEmissaoFiscal";
        public const string STEP_9 = "ConfirmarPlanoEmissaoFiscal";
        public const string STEP_10 = "PublicarPlanoParaSagaFiscal";
        public const string STEP_11 = "AguardarResultadoEmissaoFiscal";
        public const string STEP_12 = "FinalizarContingenciaFiscal";

        public ContingenciaFiscalStandardSaga()
        {
            AddStep(new ContingenciaFiscalStandardStep(STEP_1, 1));
            AddStep(new ContingenciaFiscalStandardStep(STEP_2, 2));
            AddStep(new ContingenciaFiscalStandardStep(STEP_3, 3));
            AddStep(new ContingenciaFiscalStandardStep(STEP_4, 4));
            AddStep(new ContingenciaFiscalStandardStep(STEP_5, 5));
            AddStep(new ContingenciaFiscalStandardStep(STEP_6, 6));
            AddStep(new ContingenciaFiscalStandardStep(STEP_7, 7));
            AddStep(new ContingenciaFiscalStandardStep(STEP_8, 8));
            AddStep(new ContingenciaFiscalStandardStep(STEP_9, 9));
            AddStep(new ContingenciaFiscalStandardStep(STEP_10, 10));
            AddStep(new ContingenciaFiscalStandardStep(STEP_11, 11));
            AddStep(new ContingenciaFiscalStandardStep(STEP_12, 12));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers