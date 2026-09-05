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
    public partial class PublicarMDFeEncerradoHandler
    {
        private readonly IyOutboxWriteRepository _outboxWriteRepository;
        private readonly ILogger _logger;

        public PublicarMDFeEncerradoHandler(IyOutboxWriteRepository outboxWriteRepository, ILogger logger)
        {
            _outboxWriteRepository = outboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var outbox = FiscalSagaPayloads.CreateOutbox(
                _logger,
                saga,
                step,
                "MDFeEncerrado.v1",
                new
                {
                    origem = "Fiscal",
                    moduloOrigem = "Fiscal",
                    sagaOrigem = "EncerramentoMDFeStandard",
                    stepOrigem = "publicarMDFeEncerrado",
                    moduloDestino = "APSADM",
                    sagaDestino = "CargaStandard",
                    mdfeId = saga.EntityId
                },
                "yeshua.apsadm",
                "apsadm.carga.mdfe-encerrado.inbox",
                "MDFeEncerrado.v1");

            _outboxWriteRepository.Insert(outbox);
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"MDF-e {saga.EntityId}: encerramento publicado para APS.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
