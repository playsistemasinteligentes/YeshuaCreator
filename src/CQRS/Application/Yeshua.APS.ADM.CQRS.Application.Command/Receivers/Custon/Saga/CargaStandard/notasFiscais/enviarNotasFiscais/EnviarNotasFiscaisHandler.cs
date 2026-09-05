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
    public partial class EnviarNotasFiscaisHandler
    {
        private readonly IyOutboxWriteRepository _outboxWriteRepository;
        private readonly ILogger _logger;

        public EnviarNotasFiscaisHandler(IyOutboxWriteRepository outboxWriteRepository, ILogger logger)
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
                "carga.notas-fiscais.enviar",
                new
                {
                    origem = "APSADM",
                    cargaId = saga.EntityId,
                    aguardando = "notas-fiscais"
                },
                "APSADM",
                "/yapi/APSADM/Inbox/YeshuaModuleEvent",
                "YeshuaModules:APSADM:BaseUrl");

            _outboxWriteRepository.Insert(outbox);
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Carga {saga.EntityId}: notas fiscais recebidas/aplicadas na saga standard.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
