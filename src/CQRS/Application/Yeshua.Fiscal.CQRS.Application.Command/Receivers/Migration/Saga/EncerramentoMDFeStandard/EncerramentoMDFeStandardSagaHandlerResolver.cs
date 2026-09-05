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
    public class EncerramentoMDFeStandardSagaHandlerResolver : ISagaHandlerResolver
    {
        private readonly SolicitarEncerramentoMDFeHandler _SolicitarEncerramentoMDFeHandler;
        private readonly PrepararEventoEncerramentoMDFeHandler _PrepararEventoEncerramentoMDFeHandler;
        private readonly AutorizarEncerramentoMDFeNaSefazHandler _AutorizarEncerramentoMDFeNaSefazHandler;
        private readonly PublicarMDFeEncerradoHandler _PublicarMDFeEncerradoHandler;

        public EncerramentoMDFeStandardSagaHandlerResolver(SolicitarEncerramentoMDFeHandler SolicitarEncerramentoMDFeHandler, PrepararEventoEncerramentoMDFeHandler PrepararEventoEncerramentoMDFeHandler, AutorizarEncerramentoMDFeNaSefazHandler AutorizarEncerramentoMDFeNaSefazHandler, PublicarMDFeEncerradoHandler PublicarMDFeEncerradoHandler)
        {
            _SolicitarEncerramentoMDFeHandler = SolicitarEncerramentoMDFeHandler;
            _PrepararEventoEncerramentoMDFeHandler = PrepararEventoEncerramentoMDFeHandler;
            _AutorizarEncerramentoMDFeNaSefazHandler = AutorizarEncerramentoMDFeNaSefazHandler;
            _PublicarMDFeEncerradoHandler = PublicarMDFeEncerradoHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { EncerramentoMDFeStandardSaga.STEP_1, _SolicitarEncerramentoMDFeHandler },
                { EncerramentoMDFeStandardSaga.STEP_2, _PrepararEventoEncerramentoMDFeHandler },
                { EncerramentoMDFeStandardSaga.STEP_3, _AutorizarEncerramentoMDFeNaSefazHandler },
                { EncerramentoMDFeStandardSaga.STEP_4, _PublicarMDFeEncerradoHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers