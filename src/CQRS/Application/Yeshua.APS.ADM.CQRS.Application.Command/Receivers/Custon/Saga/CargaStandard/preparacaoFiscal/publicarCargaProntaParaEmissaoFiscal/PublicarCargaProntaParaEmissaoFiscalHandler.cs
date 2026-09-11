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
using IRepository.Read;
using IRepository.Write;

namespace Command.Receivers
{
    public partial class PublicarCargaProntaParaEmissaoFiscalHandler
    {
        private readonly IyOutboxWriteRepository _outboxWriteRepository;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ICargaReadRepository _cargaReadRepository;
        private readonly IVeiculoReadRepository _veiculoReadRepository;
        private readonly ITransportadoraReadRepository _transportadoraReadRepository;
        private readonly ILogger _logger;

        public PublicarCargaProntaParaEmissaoFiscalHandler(
            IyOutboxWriteRepository outboxWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ICargaReadRepository cargaReadRepository,
            IVeiculoReadRepository veiculoReadRepository,
            ITransportadoraReadRepository transportadoraReadRepository,
            ILogger logger)
        {
            _outboxWriteRepository = outboxWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _cargaReadRepository = cargaReadRepository;
            _veiculoReadRepository = veiculoReadRepository;
            _transportadoraReadRepository = transportadoraReadRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var snapshotBuilder = new CargaFiscalSnapshotBuilder(
                _cargaReadRepository,
                _veiculoReadRepository,
                _transportadoraReadRepository);
            var snapshot = snapshotBuilder.Build(saga, step);

            if (!snapshot.ProntoParaPublicacao)
            {
                var bloqueio = CargaStandardSagaPayloads.CreateInbox(
                    _logger,
                    saga,
                    step,
                    "carga.publicacao-fiscal.bloqueada",
                    snapshotBuilder.BuildBlockedPublicationEvidence(snapshot));

                _inboxWriteRepository.Insert(bloqueio);
                return;
            }

            var outbox = CargaStandardSagaPayloads.CreateOutbox(
                _logger,
                saga,
                step,
                "CargaProntaParaEmissaoFiscal.v1",
                snapshot,
                "Fiscal",
                "/yapi/Fiscal/Inbox/YeshuaModuleEvent",
                "YeshuaModules:Fiscal:BaseUrl");

            _outboxWriteRepository.Insert(outbox);

            var inbox = CargaStandardSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "carga.publicacao-fiscal-enfileirada",
                new
                {
                    origem = snapshot.Origem,
                    cargaId = snapshot.CargaId,
                    contrato = "CargaProntaParaEmissaoFiscal.v1",
                    publicado = true
                });

            _inboxWriteRepository.Insert(inbox);
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Carga {saga.EntityId}: publicacao fiscal aplicada na saga standard.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
