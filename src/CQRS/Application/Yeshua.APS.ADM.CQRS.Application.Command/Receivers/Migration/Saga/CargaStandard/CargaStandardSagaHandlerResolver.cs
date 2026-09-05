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
    public class CargaStandardSagaHandlerResolver : ISagaHandlerResolver
    {
        private readonly CriarCargaHandler _CriarCargaHandler;
        private readonly DefinirDadosTransporteHandler _DefinirDadosTransporteHandler;
        private readonly PrepararCargaParaFiscalHandler _PrepararCargaParaFiscalHandler;
        private readonly PublicarCargaProntaParaEmissaoFiscalHandler _PublicarCargaProntaParaEmissaoFiscalHandler;
        private readonly AguardarResultadoFiscalDaCargaHandler _AguardarResultadoFiscalDaCargaHandler;
        private readonly LiberarCargaParaExpedicaoHandler _LiberarCargaParaExpedicaoHandler;

        public CargaStandardSagaHandlerResolver(CriarCargaHandler CriarCargaHandler, DefinirDadosTransporteHandler DefinirDadosTransporteHandler, PrepararCargaParaFiscalHandler PrepararCargaParaFiscalHandler, PublicarCargaProntaParaEmissaoFiscalHandler PublicarCargaProntaParaEmissaoFiscalHandler, AguardarResultadoFiscalDaCargaHandler AguardarResultadoFiscalDaCargaHandler, LiberarCargaParaExpedicaoHandler LiberarCargaParaExpedicaoHandler)
        {
            _CriarCargaHandler = CriarCargaHandler;
            _DefinirDadosTransporteHandler = DefinirDadosTransporteHandler;
            _PrepararCargaParaFiscalHandler = PrepararCargaParaFiscalHandler;
            _PublicarCargaProntaParaEmissaoFiscalHandler = PublicarCargaProntaParaEmissaoFiscalHandler;
            _AguardarResultadoFiscalDaCargaHandler = AguardarResultadoFiscalDaCargaHandler;
            _LiberarCargaParaExpedicaoHandler = LiberarCargaParaExpedicaoHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { CargaStandardSaga.STEP_1, _CriarCargaHandler },
                { CargaStandardSaga.STEP_2, _DefinirDadosTransporteHandler },
                { CargaStandardSaga.STEP_3, _PrepararCargaParaFiscalHandler },
                { CargaStandardSaga.STEP_4, _PublicarCargaProntaParaEmissaoFiscalHandler },
                { CargaStandardSaga.STEP_5, _AguardarResultadoFiscalDaCargaHandler },
                { CargaStandardSaga.STEP_6, _LiberarCargaParaExpedicaoHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers