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
    public class TranscreverAudioSuporteSagaHandlerResolver : ISagaHandlerResolver
    {
        private readonly TranscreverAudioChamadoHandler _TranscreverAudioChamadoHandler;

        public TranscreverAudioSuporteSagaHandlerResolver(TranscreverAudioChamadoHandler TranscreverAudioChamadoHandler)
        {
            _TranscreverAudioChamadoHandler = TranscreverAudioChamadoHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { TranscreverAudioSuporteSaga.STEP_1, _TranscreverAudioChamadoHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers