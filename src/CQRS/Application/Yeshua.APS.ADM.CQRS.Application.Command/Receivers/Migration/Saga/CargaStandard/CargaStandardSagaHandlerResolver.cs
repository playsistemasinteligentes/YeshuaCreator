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
        private readonly AguardarDadosTransporteHandler _AguardarDadosTransporteHandler;
        private readonly AguardarAgendamentoHandler _AguardarAgendamentoHandler;
        private readonly AguardarInicioCarregamentoHandler _AguardarInicioCarregamentoHandler;
        private readonly AguardarFinalizacaoCarregamentoHandler _AguardarFinalizacaoCarregamentoHandler;
        private readonly PrepararCargaParaModuloFiscalHandler _PrepararCargaParaModuloFiscalHandler;
        private readonly PublicarCargaProntaParaEmissaoFiscalHandler _PublicarCargaProntaParaEmissaoFiscalHandler;
        private readonly AguardarFinalizacaoFiscalHandler _AguardarFinalizacaoFiscalHandler;
        private readonly LiberarCargaParaExpedicaoHandler _LiberarCargaParaExpedicaoHandler;

        public CargaStandardSagaHandlerResolver(AguardarDadosTransporteHandler AguardarDadosTransporteHandler, AguardarAgendamentoHandler AguardarAgendamentoHandler, AguardarInicioCarregamentoHandler AguardarInicioCarregamentoHandler, AguardarFinalizacaoCarregamentoHandler AguardarFinalizacaoCarregamentoHandler, PrepararCargaParaModuloFiscalHandler PrepararCargaParaModuloFiscalHandler, PublicarCargaProntaParaEmissaoFiscalHandler PublicarCargaProntaParaEmissaoFiscalHandler, AguardarFinalizacaoFiscalHandler AguardarFinalizacaoFiscalHandler, LiberarCargaParaExpedicaoHandler LiberarCargaParaExpedicaoHandler)
        {
            _AguardarDadosTransporteHandler = AguardarDadosTransporteHandler;
            _AguardarAgendamentoHandler = AguardarAgendamentoHandler;
            _AguardarInicioCarregamentoHandler = AguardarInicioCarregamentoHandler;
            _AguardarFinalizacaoCarregamentoHandler = AguardarFinalizacaoCarregamentoHandler;
            _PrepararCargaParaModuloFiscalHandler = PrepararCargaParaModuloFiscalHandler;
            _PublicarCargaProntaParaEmissaoFiscalHandler = PublicarCargaProntaParaEmissaoFiscalHandler;
            _AguardarFinalizacaoFiscalHandler = AguardarFinalizacaoFiscalHandler;
            _LiberarCargaParaExpedicaoHandler = LiberarCargaParaExpedicaoHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { CargaStandardSaga.STEP_1, _AguardarDadosTransporteHandler },
                { CargaStandardSaga.STEP_2, _AguardarAgendamentoHandler },
                { CargaStandardSaga.STEP_3, _AguardarInicioCarregamentoHandler },
                { CargaStandardSaga.STEP_4, _AguardarFinalizacaoCarregamentoHandler },
                { CargaStandardSaga.STEP_5, _PrepararCargaParaModuloFiscalHandler },
                { CargaStandardSaga.STEP_6, _PublicarCargaProntaParaEmissaoFiscalHandler },
                { CargaStandardSaga.STEP_7, _AguardarFinalizacaoFiscalHandler },
                { CargaStandardSaga.STEP_8, _LiberarCargaParaExpedicaoHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers