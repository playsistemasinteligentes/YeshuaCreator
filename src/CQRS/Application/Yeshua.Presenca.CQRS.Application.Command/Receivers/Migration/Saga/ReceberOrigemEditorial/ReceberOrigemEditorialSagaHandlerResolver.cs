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
    public class ReceberOrigemEditorialSagaHandlerResolver : ISagaHandlerResolver
    {
        private readonly RegistrarPautaDeOrigemHandler _RegistrarPautaDeOrigemHandler;

        public ReceberOrigemEditorialSagaHandlerResolver(RegistrarPautaDeOrigemHandler RegistrarPautaDeOrigemHandler)
        {
            _RegistrarPautaDeOrigemHandler = RegistrarPautaDeOrigemHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { ReceberOrigemEditorialSaga.STEP_1, _RegistrarPautaDeOrigemHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers