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
using IRepository.Write;

namespace Command.Receivers
{
    public partial class GerarCTeHandler
    {
        private readonly IyOutboxWriteRepository _outboxWriteRepository;
        private readonly ILogger _logger;

        public GerarCTeHandler(IyOutboxWriteRepository outboxWriteRepository, ILogger logger)
        {
            _outboxWriteRepository = outboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var outbox = CargaStandardSagaPayloads.CreateOutbox(
                _logger,
                saga,
                step,
                "cte.emitir.solicitar",
                new
                {
                    origem = "APSADM",
                    cargaId = saga.EntityId,
                    aguardando = "cte-autorizado"
                },
                "fiscal.cte",
                "cte.emitir.outbox",
                "cte.emitir.solicitar");

            _outboxWriteRepository.Insert(outbox);
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Carga {saga.EntityId}: CT-e aplicado na saga standard.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
