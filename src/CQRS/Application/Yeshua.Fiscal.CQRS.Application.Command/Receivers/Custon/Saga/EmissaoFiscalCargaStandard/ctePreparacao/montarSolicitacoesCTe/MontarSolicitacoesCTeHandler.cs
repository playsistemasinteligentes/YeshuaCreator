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
    public partial class MontarSolicitacoesCTeHandler
    {
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public MontarSolicitacoesCTeHandler(IyInboxWriteRepository inboxWriteRepository, ILogger logger)
        {
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.cte.solicitacoes-montadas",
                new { origem = "Fiscal", modo = "interno-prototipo", entityId = saga.EntityId }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: solicitacoes de CT-e montadas.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
