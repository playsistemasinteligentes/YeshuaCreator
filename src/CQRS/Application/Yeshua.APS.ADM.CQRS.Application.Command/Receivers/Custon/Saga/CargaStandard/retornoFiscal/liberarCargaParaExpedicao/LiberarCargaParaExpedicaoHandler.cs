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
    public partial class LiberarCargaParaExpedicaoHandler
    {
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public LiberarCargaParaExpedicaoHandler(IyInboxWriteRepository inboxWriteRepository, ILogger logger)
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
                "carga.liberada-para-expedicao",
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
            _logger.Info($"Carga {saga.EntityId}: liberada para expedicao.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
