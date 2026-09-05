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
    public partial class PublicarCargaProntaParaEmissaoFiscalHandler
    {
        private readonly IyOutboxWriteRepository _outboxWriteRepository;
        private readonly ILogger _logger;

        public PublicarCargaProntaParaEmissaoFiscalHandler(IyOutboxWriteRepository outboxWriteRepository, ILogger logger)
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
                "CargaProntaParaEmissaoFiscal.v1",
                new
                {
                    origem = "APSADM",
                    moduloOrigem = "APSADM",
                    sagaOrigem = "CargaStandard",
                    stepOrigem = "publicarCargaProntaParaEmissaoFiscal",
                    moduloDestino = "Fiscal",
                    sagaDestino = "EmissaoFiscalCargaStandard",
                    cargaId = saga.EntityId
                },
                "yeshua.fiscal",
                "fiscal.emissao-carga.inbox",
                "CargaProntaParaEmissaoFiscal.v1");

            _outboxWriteRepository.Insert(outbox);
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Carga {saga.EntityId}: publicacao fiscal aplicada na saga standard.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
