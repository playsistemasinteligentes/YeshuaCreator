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
        private readonly DefinirDadosTransporteHandler _DefinirDadosTransporteHandler;
        private readonly EnviarNotasFiscaisHandler _EnviarNotasFiscaisHandler;
        private readonly GerarCTeHandler _GerarCTeHandler;
        private readonly GerarMDFeHandler _GerarMDFeHandler;

        public CargaStandardSagaHandlerResolver(DefinirDadosTransporteHandler DefinirDadosTransporteHandler, EnviarNotasFiscaisHandler EnviarNotasFiscaisHandler, GerarCTeHandler GerarCTeHandler, GerarMDFeHandler GerarMDFeHandler)
        {
            _DefinirDadosTransporteHandler = DefinirDadosTransporteHandler;
            _EnviarNotasFiscaisHandler = EnviarNotasFiscaisHandler;
            _GerarCTeHandler = GerarCTeHandler;
            _GerarMDFeHandler = GerarMDFeHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { CargaStandardSaga.STEP_1, _DefinirDadosTransporteHandler },
                { CargaStandardSaga.STEP_2, _EnviarNotasFiscaisHandler },
                { CargaStandardSaga.STEP_3, _GerarCTeHandler },
                { CargaStandardSaga.STEP_4, _GerarMDFeHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers