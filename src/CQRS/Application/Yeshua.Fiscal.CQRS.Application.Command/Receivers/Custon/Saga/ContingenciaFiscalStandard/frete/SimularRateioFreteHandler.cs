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
using System;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class SimularRateioFreteHandler
    {
        private readonly IEntradaFiscalContingenciaReadRepository _entradaReadRepository;
        private readonly IEntradaFiscalContingenciaWriteRepository _entradaWriteRepository;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository;
        private readonly ILogger _logger;

        public SimularRateioFreteHandler(
            IEntradaFiscalContingenciaReadRepository entradaReadRepository,
            IEntradaFiscalContingenciaWriteRepository entradaWriteRepository,
            INFeProdutoSnapshotReadRepository nfeProdutoSnapshotReadRepository,
            ILogger logger)
        {
            _entradaReadRepository = entradaReadRepository;
            _entradaWriteRepository = entradaWriteRepository;
            _nfeProdutoSnapshotReadRepository = nfeProdutoSnapshotReadRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            var documentos = FiscalContingenciaState.LoadDocumentos(_nfeProdutoSnapshotReadRepository, entrada.cargaid);
            var planoJson = FiscalContingenciaPayload.PlanoEmissaoJson(entrada, documentos);

            _entradaWriteRepository.UpdateSnapshotJson(entrada.id, planoJson);
            _entradaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);

            step.SetPayload(JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.rateio-frete-simulado",
                entradaFiscalContingenciaId = entrada.id,
                cargaId = entrada.cargaid,
                planoEmissaoJson = planoJson,
                occurredAtUtc = DateTime.UtcNow
            }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Contingencia fiscal {saga.EntityId}: rateio de frete simulado.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
