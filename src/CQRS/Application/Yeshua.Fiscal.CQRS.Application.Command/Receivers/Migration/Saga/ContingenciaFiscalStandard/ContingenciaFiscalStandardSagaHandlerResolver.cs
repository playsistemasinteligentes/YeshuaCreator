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
        private readonly PrepararEntradaContingenciaHandler _PrepararEntradaContingenciaHandler;
        private readonly ValidarPlanoEmissaoFiscalHandler _ValidarPlanoEmissaoFiscalHandler;
        private readonly PublicarPlanoParaSagaFiscalHandler _PublicarPlanoParaSagaFiscalHandler;
        private readonly AguardarResultadoEmissaoFiscalHandler _AguardarResultadoEmissaoFiscalHandler;
        private readonly FinalizarContingenciaFiscalHandler _FinalizarContingenciaFiscalHandler;

        public ContingenciaFiscalStandardSagaHandlerResolver(PrepararEntradaContingenciaHandler PrepararEntradaContingenciaHandler, ValidarPlanoEmissaoFiscalHandler ValidarPlanoEmissaoFiscalHandler, PublicarPlanoParaSagaFiscalHandler PublicarPlanoParaSagaFiscalHandler, AguardarResultadoEmissaoFiscalHandler AguardarResultadoEmissaoFiscalHandler, FinalizarContingenciaFiscalHandler FinalizarContingenciaFiscalHandler)
        {
            _PrepararEntradaContingenciaHandler = PrepararEntradaContingenciaHandler;
            _ValidarPlanoEmissaoFiscalHandler = ValidarPlanoEmissaoFiscalHandler;
            _PublicarPlanoParaSagaFiscalHandler = PublicarPlanoParaSagaFiscalHandler;
            _AguardarResultadoEmissaoFiscalHandler = AguardarResultadoEmissaoFiscalHandler;
            _FinalizarContingenciaFiscalHandler = FinalizarContingenciaFiscalHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { ContingenciaFiscalStandardSaga.STEP_1, _PrepararEntradaContingenciaHandler },
                { ContingenciaFiscalStandardSaga.STEP_2, _ValidarPlanoEmissaoFiscalHandler },
                { ContingenciaFiscalStandardSaga.STEP_3, _PublicarPlanoParaSagaFiscalHandler },
                { ContingenciaFiscalStandardSaga.STEP_4, _AguardarResultadoEmissaoFiscalHandler },
                { ContingenciaFiscalStandardSaga.STEP_5, _FinalizarContingenciaFiscalHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers