// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using RepositoryInterfaces.Patterns.Saga;
using Dominio.Saga;
using System;
using System.Collections.Generic;

namespace Command.Receivers
{
    public class EmissaoFiscalCargaStandardSagaHandlerResolver : ISagaHandlerResolver
    {
        private readonly ReceberCargaProntaParaEmissaoFiscalHandler _ReceberCargaProntaParaEmissaoFiscalHandler;
        private readonly AguardarDocumentosOriginariosDaCargaHandler _AguardarDocumentosOriginariosDaCargaHandler;
        private readonly PrepararEntradaFiscalDaCargaHandler _PrepararEntradaFiscalDaCargaHandler;
        private readonly MontarSolicitacoesCTeHandler _MontarSolicitacoesCTeHandler;
        private readonly PrepararCTeHandler _PrepararCTeHandler;
        private readonly AutorizarCTeNaSefazHandler _AutorizarCTeNaSefazHandler;
        private readonly PublicarCTeAutorizadoParaMDFeHandler _PublicarCTeAutorizadoParaMDFeHandler;
        private readonly MontarSolicitacaoMDFeHandler _MontarSolicitacaoMDFeHandler;
        private readonly PrepararMDFeHandler _PrepararMDFeHandler;
        private readonly AutorizarMDFeNaSefazHandler _AutorizarMDFeNaSefazHandler;
        private readonly PublicarDocumentosFiscaisDaCargaConcluidosHandler _PublicarDocumentosFiscaisDaCargaConcluidosHandler;

        public EmissaoFiscalCargaStandardSagaHandlerResolver(ReceberCargaProntaParaEmissaoFiscalHandler ReceberCargaProntaParaEmissaoFiscalHandler, AguardarDocumentosOriginariosDaCargaHandler AguardarDocumentosOriginariosDaCargaHandler, PrepararEntradaFiscalDaCargaHandler PrepararEntradaFiscalDaCargaHandler, MontarSolicitacoesCTeHandler MontarSolicitacoesCTeHandler, PrepararCTeHandler PrepararCTeHandler, AutorizarCTeNaSefazHandler AutorizarCTeNaSefazHandler, PublicarCTeAutorizadoParaMDFeHandler PublicarCTeAutorizadoParaMDFeHandler, MontarSolicitacaoMDFeHandler MontarSolicitacaoMDFeHandler, PrepararMDFeHandler PrepararMDFeHandler, AutorizarMDFeNaSefazHandler AutorizarMDFeNaSefazHandler, PublicarDocumentosFiscaisDaCargaConcluidosHandler PublicarDocumentosFiscaisDaCargaConcluidosHandler)
        {
            _ReceberCargaProntaParaEmissaoFiscalHandler = ReceberCargaProntaParaEmissaoFiscalHandler;
            _AguardarDocumentosOriginariosDaCargaHandler = AguardarDocumentosOriginariosDaCargaHandler;
            _PrepararEntradaFiscalDaCargaHandler = PrepararEntradaFiscalDaCargaHandler;
            _MontarSolicitacoesCTeHandler = MontarSolicitacoesCTeHandler;
            _PrepararCTeHandler = PrepararCTeHandler;
            _AutorizarCTeNaSefazHandler = AutorizarCTeNaSefazHandler;
            _PublicarCTeAutorizadoParaMDFeHandler = PublicarCTeAutorizadoParaMDFeHandler;
            _MontarSolicitacaoMDFeHandler = MontarSolicitacaoMDFeHandler;
            _PrepararMDFeHandler = PrepararMDFeHandler;
            _AutorizarMDFeNaSefazHandler = AutorizarMDFeNaSefazHandler;
            _PublicarDocumentosFiscaisDaCargaConcluidosHandler = PublicarDocumentosFiscaisDaCargaConcluidosHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { EmissaoFiscalCargaStandardSaga.STEP_1, _ReceberCargaProntaParaEmissaoFiscalHandler },
                { EmissaoFiscalCargaStandardSaga.STEP_2, _AguardarDocumentosOriginariosDaCargaHandler },
                { EmissaoFiscalCargaStandardSaga.STEP_3, _PrepararEntradaFiscalDaCargaHandler },
                { EmissaoFiscalCargaStandardSaga.STEP_4, _MontarSolicitacoesCTeHandler },
                { EmissaoFiscalCargaStandardSaga.STEP_5, _PrepararCTeHandler },
                { EmissaoFiscalCargaStandardSaga.STEP_6, _AutorizarCTeNaSefazHandler },
                { EmissaoFiscalCargaStandardSaga.STEP_7, _PublicarCTeAutorizadoParaMDFeHandler },
                { EmissaoFiscalCargaStandardSaga.STEP_8, _MontarSolicitacaoMDFeHandler },
                { EmissaoFiscalCargaStandardSaga.STEP_9, _PrepararMDFeHandler },
                { EmissaoFiscalCargaStandardSaga.STEP_10, _AutorizarMDFeNaSefazHandler },
                { EmissaoFiscalCargaStandardSaga.STEP_11, _PublicarDocumentosFiscaisDaCargaConcluidosHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers