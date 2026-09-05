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
    public class EmissaoFiscalCargaStandardSaga : SagaBase
    {
        public const string STEP_1 = "ReceberCargaProntaParaEmissaoFiscal";
        public const string STEP_2 = "NormalizarDocumentosOriginarios";
        public const string STEP_3 = "MontarSolicitacoesCTe";
        public const string STEP_4 = "PrepararCTe";
        public const string STEP_5 = "AutorizarCTeNaSefaz";
        public const string STEP_6 = "PublicarCTeAutorizadoParaMDFe";
        public const string STEP_7 = "MontarSolicitacaoMDFe";
        public const string STEP_8 = "PrepararMDFe";
        public const string STEP_9 = "AutorizarMDFeNaSefaz";
        public const string STEP_10 = "PublicarDocumentosFiscaisDaCargaConcluidos";

        public EmissaoFiscalCargaStandardSaga()
        {
            AddStep(new EmissaoFiscalCargaStandardStep(STEP_1, 1));
            AddStep(new EmissaoFiscalCargaStandardStep(STEP_2, 2));
            AddStep(new EmissaoFiscalCargaStandardStep(STEP_3, 3));
            AddStep(new EmissaoFiscalCargaStandardStep(STEP_4, 4));
            AddStep(new EmissaoFiscalCargaStandardStep(STEP_5, 5));
            AddStep(new EmissaoFiscalCargaStandardStep(STEP_6, 6));
            AddStep(new EmissaoFiscalCargaStandardStep(STEP_7, 7));
            AddStep(new EmissaoFiscalCargaStandardStep(STEP_8, 8));
            AddStep(new EmissaoFiscalCargaStandardStep(STEP_9, 9));
            AddStep(new EmissaoFiscalCargaStandardStep(STEP_10, 10));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers