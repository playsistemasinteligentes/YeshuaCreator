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
    public class ConfiguracaoInicialClinicaSagaHandlerResolver : ISagaHandlerResolver
    {
        private readonly ConfigurarEstabelecimentoHandler _ConfigurarEstabelecimentoHandler;
        private readonly VincularProfissionalInicialHandler _VincularProfissionalInicialHandler;
        private readonly DefinirServicoInicialHandler _DefinirServicoInicialHandler;

        public ConfiguracaoInicialClinicaSagaHandlerResolver(ConfigurarEstabelecimentoHandler ConfigurarEstabelecimentoHandler, VincularProfissionalInicialHandler VincularProfissionalInicialHandler, DefinirServicoInicialHandler DefinirServicoInicialHandler)
        {
            _ConfigurarEstabelecimentoHandler = ConfigurarEstabelecimentoHandler;
            _VincularProfissionalInicialHandler = VincularProfissionalInicialHandler;
            _DefinirServicoInicialHandler = DefinirServicoInicialHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { ConfiguracaoInicialClinicaSaga.STEP_1, _ConfigurarEstabelecimentoHandler },
                { ConfiguracaoInicialClinicaSaga.STEP_2, _VincularProfissionalInicialHandler },
                { ConfiguracaoInicialClinicaSaga.STEP_3, _DefinirServicoInicialHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers