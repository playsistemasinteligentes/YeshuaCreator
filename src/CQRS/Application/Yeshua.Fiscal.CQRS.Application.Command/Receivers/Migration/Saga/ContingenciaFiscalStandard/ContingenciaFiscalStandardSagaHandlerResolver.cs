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
    public class ContingenciaFiscalStandardSagaHandlerResolver : ISagaHandlerResolver
    {
        private readonly ReceberNotasFiscaisDaContingenciaHandler _ReceberNotasFiscaisDaContingenciaHandler;
        private readonly AnalisarNotasFiscaisDaContingenciaHandler _AnalisarNotasFiscaisDaContingenciaHandler;
        private readonly EscolherModeloAgrupamentoCTeHandler _EscolherModeloAgrupamentoCTeHandler;
        private readonly SimularAgrupamentoCTeHandler _SimularAgrupamentoCTeHandler;
        private readonly InformarFreteERateioHandler _InformarFreteERateioHandler;
        private readonly SimularRateioFreteHandler _SimularRateioFreteHandler;
        private readonly InformarDadosTransporteHandler _InformarDadosTransporteHandler;
        private readonly ValidarPlanoEmissaoFiscalHandler _ValidarPlanoEmissaoFiscalHandler;
        private readonly ConfirmarPlanoEmissaoFiscalHandler _ConfirmarPlanoEmissaoFiscalHandler;
        private readonly PublicarPlanoParaSagaFiscalHandler _PublicarPlanoParaSagaFiscalHandler;
        private readonly AguardarResultadoEmissaoFiscalHandler _AguardarResultadoEmissaoFiscalHandler;
        private readonly FinalizarContingenciaFiscalHandler _FinalizarContingenciaFiscalHandler;

        public ContingenciaFiscalStandardSagaHandlerResolver(ReceberNotasFiscaisDaContingenciaHandler ReceberNotasFiscaisDaContingenciaHandler, AnalisarNotasFiscaisDaContingenciaHandler AnalisarNotasFiscaisDaContingenciaHandler, EscolherModeloAgrupamentoCTeHandler EscolherModeloAgrupamentoCTeHandler, SimularAgrupamentoCTeHandler SimularAgrupamentoCTeHandler, InformarFreteERateioHandler InformarFreteERateioHandler, SimularRateioFreteHandler SimularRateioFreteHandler, InformarDadosTransporteHandler InformarDadosTransporteHandler, ValidarPlanoEmissaoFiscalHandler ValidarPlanoEmissaoFiscalHandler, ConfirmarPlanoEmissaoFiscalHandler ConfirmarPlanoEmissaoFiscalHandler, PublicarPlanoParaSagaFiscalHandler PublicarPlanoParaSagaFiscalHandler, AguardarResultadoEmissaoFiscalHandler AguardarResultadoEmissaoFiscalHandler, FinalizarContingenciaFiscalHandler FinalizarContingenciaFiscalHandler)
        {
            _ReceberNotasFiscaisDaContingenciaHandler = ReceberNotasFiscaisDaContingenciaHandler;
            _AnalisarNotasFiscaisDaContingenciaHandler = AnalisarNotasFiscaisDaContingenciaHandler;
            _EscolherModeloAgrupamentoCTeHandler = EscolherModeloAgrupamentoCTeHandler;
            _SimularAgrupamentoCTeHandler = SimularAgrupamentoCTeHandler;
            _InformarFreteERateioHandler = InformarFreteERateioHandler;
            _SimularRateioFreteHandler = SimularRateioFreteHandler;
            _InformarDadosTransporteHandler = InformarDadosTransporteHandler;
            _ValidarPlanoEmissaoFiscalHandler = ValidarPlanoEmissaoFiscalHandler;
            _ConfirmarPlanoEmissaoFiscalHandler = ConfirmarPlanoEmissaoFiscalHandler;
            _PublicarPlanoParaSagaFiscalHandler = PublicarPlanoParaSagaFiscalHandler;
            _AguardarResultadoEmissaoFiscalHandler = AguardarResultadoEmissaoFiscalHandler;
            _FinalizarContingenciaFiscalHandler = FinalizarContingenciaFiscalHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { ContingenciaFiscalStandardSaga.STEP_1, _ReceberNotasFiscaisDaContingenciaHandler },
                { ContingenciaFiscalStandardSaga.STEP_2, _AnalisarNotasFiscaisDaContingenciaHandler },
                { ContingenciaFiscalStandardSaga.STEP_3, _EscolherModeloAgrupamentoCTeHandler },
                { ContingenciaFiscalStandardSaga.STEP_4, _SimularAgrupamentoCTeHandler },
                { ContingenciaFiscalStandardSaga.STEP_5, _InformarFreteERateioHandler },
                { ContingenciaFiscalStandardSaga.STEP_6, _SimularRateioFreteHandler },
                { ContingenciaFiscalStandardSaga.STEP_7, _InformarDadosTransporteHandler },
                { ContingenciaFiscalStandardSaga.STEP_8, _ValidarPlanoEmissaoFiscalHandler },
                { ContingenciaFiscalStandardSaga.STEP_9, _ConfirmarPlanoEmissaoFiscalHandler },
                { ContingenciaFiscalStandardSaga.STEP_10, _PublicarPlanoParaSagaFiscalHandler },
                { ContingenciaFiscalStandardSaga.STEP_11, _AguardarResultadoEmissaoFiscalHandler },
                { ContingenciaFiscalStandardSaga.STEP_12, _FinalizarContingenciaFiscalHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers