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
    public partial class ReceberDocumentosOriginariosContingenciaHandler
    {
        private readonly ILogger _logger;

        public ReceberDocumentosOriginariosContingenciaHandler(ILogger logger)
        {
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            _logger.Info($"Contingencia fiscal {saga.EntityId}: documentos originarios recebidos.");
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Contingencia fiscal {saga.EntityId}: recepcao de documentos originarios confirmada.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
