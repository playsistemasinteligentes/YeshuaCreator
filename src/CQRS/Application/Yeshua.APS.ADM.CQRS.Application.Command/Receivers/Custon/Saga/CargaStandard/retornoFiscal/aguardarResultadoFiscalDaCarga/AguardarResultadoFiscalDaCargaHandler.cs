// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Interfaces;
using Dominio.Patterns.Saga;

namespace Command.Receivers
{
    public partial class AguardarResultadoFiscalDaCargaHandler
    {
        private readonly ILogger _logger;

        public AguardarResultadoFiscalDaCargaHandler(ILogger logger)
        {
            _logger = logger;
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Carga {saga.EntityId}: retorno fiscal recebido e aplicado.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
