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
    public partial class PublicarDocumentosFiscaisDaCargaConcluidosHandler
    {
        private readonly IyOutboxWriteRepository _outboxWriteRepository;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public PublicarDocumentosFiscaisDaCargaConcluidosHandler(
            IyOutboxWriteRepository outboxWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _outboxWriteRepository = outboxWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var outbox = FiscalSagaPayloads.CreateOutbox(
                _logger,
                saga,
                step,
                "DocumentosFiscaisDaCargaConcluidos.v1",
                new
                {
                    origem = "Fiscal",
                    moduloOrigem = "Fiscal",
                    sagaOrigem = "EmissaoFiscalCargaStandard",
                    stepOrigem = "publicarDocumentosFiscaisDaCargaConcluidos",
                    moduloDestino = "APSADM",
                    sagaDestino = "CargaStandard",
                    cargaId = saga.EntityId
                },
                "APSADM",
                "/yapi/APSADM/Inbox/YeshuaModuleEvent",
                "YeshuaModules:APSADM:BaseUrl");

            _outboxWriteRepository.Insert(outbox);

            var inbox = FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.documentos-concluidos.publicacao-enfileirada",
                new
                {
                    origem = "Fiscal",
                    modo = "interno-prototipo",
                    entityId = saga.EntityId
                });

            _inboxWriteRepository.Insert(inbox);
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: documentos fiscais concluidos publicados para APS.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
