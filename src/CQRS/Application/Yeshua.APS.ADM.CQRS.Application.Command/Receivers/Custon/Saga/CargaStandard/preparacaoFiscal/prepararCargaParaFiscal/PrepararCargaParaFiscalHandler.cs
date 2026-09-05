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
    public partial class PrepararCargaParaFiscalHandler
    {
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public PrepararCargaParaFiscalHandler(IyInboxWriteRepository inboxWriteRepository, ILogger logger)
        {
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var inbox = CargaStandardSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "carga.preparada-para-fiscal",
                new
                {
                    origem = "APSADM",
                    modo = "interno-prototipo",
                    cargaId = saga.EntityId
                });

            _inboxWriteRepository.Insert(inbox);
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Carga {saga.EntityId}: preparacao fiscal aplicada.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
