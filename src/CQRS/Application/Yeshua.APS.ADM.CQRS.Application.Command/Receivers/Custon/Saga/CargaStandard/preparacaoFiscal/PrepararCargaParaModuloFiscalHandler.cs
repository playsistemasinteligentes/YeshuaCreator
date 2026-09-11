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
    public partial class PrepararCargaParaModuloFiscalHandler
    {
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ICargaReadRepository _cargaReadRepository;
        private readonly IVeiculoReadRepository _veiculoReadRepository;
        private readonly ITransportadoraReadRepository _transportadoraReadRepository;
        private readonly ILogger _logger;

        public PrepararCargaParaModuloFiscalHandler(
            IyInboxWriteRepository inboxWriteRepository,
            ICargaReadRepository cargaReadRepository,
            IVeiculoReadRepository veiculoReadRepository,
            ITransportadoraReadRepository transportadoraReadRepository,
            ILogger logger)
        {
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

            var inbox = CargaStandardSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "carga.preparada-para-modulo-fiscal",
                snapshotBuilder.BuildPreparationEvidence(saga, step));

            _inboxWriteRepository.Insert(inbox);
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Carga {saga.EntityId}: preparacao para modulo fiscal aplicada.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
