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
    public class EmissaoCTeComplementarStandardSagaHandlerResolver : ISagaHandlerResolver
    {
        private readonly ReceberCTeComplementarProntoParaEmissaoHandler _ReceberCTeComplementarProntoParaEmissaoHandler;
        private readonly ValidarCTeOriginalEComplementoHandler _ValidarCTeOriginalEComplementoHandler;
        private readonly PrepararCTeComplementarHandler _PrepararCTeComplementarHandler;
        private readonly AutorizarCTeComplementarNaSefazHandler _AutorizarCTeComplementarNaSefazHandler;
        private readonly FinalizarCTeComplementarHandler _FinalizarCTeComplementarHandler;

        public EmissaoCTeComplementarStandardSagaHandlerResolver(ReceberCTeComplementarProntoParaEmissaoHandler ReceberCTeComplementarProntoParaEmissaoHandler, ValidarCTeOriginalEComplementoHandler ValidarCTeOriginalEComplementoHandler, PrepararCTeComplementarHandler PrepararCTeComplementarHandler, AutorizarCTeComplementarNaSefazHandler AutorizarCTeComplementarNaSefazHandler, FinalizarCTeComplementarHandler FinalizarCTeComplementarHandler)
        {
            _ReceberCTeComplementarProntoParaEmissaoHandler = ReceberCTeComplementarProntoParaEmissaoHandler;
            _ValidarCTeOriginalEComplementoHandler = ValidarCTeOriginalEComplementoHandler;
            _PrepararCTeComplementarHandler = PrepararCTeComplementarHandler;
            _AutorizarCTeComplementarNaSefazHandler = AutorizarCTeComplementarNaSefazHandler;
            _FinalizarCTeComplementarHandler = FinalizarCTeComplementarHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { EmissaoCTeComplementarStandardSaga.STEP_1, _ReceberCTeComplementarProntoParaEmissaoHandler },
                { EmissaoCTeComplementarStandardSaga.STEP_2, _ValidarCTeOriginalEComplementoHandler },
                { EmissaoCTeComplementarStandardSaga.STEP_3, _PrepararCTeComplementarHandler },
                { EmissaoCTeComplementarStandardSaga.STEP_4, _AutorizarCTeComplementarNaSefazHandler },
                { EmissaoCTeComplementarStandardSaga.STEP_5, _FinalizarCTeComplementarHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers