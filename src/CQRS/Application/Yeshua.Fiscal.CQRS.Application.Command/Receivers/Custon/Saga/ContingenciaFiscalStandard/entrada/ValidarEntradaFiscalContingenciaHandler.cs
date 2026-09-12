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
    public partial class ValidarEntradaFiscalContingenciaHandler
    {
        private readonly IEntradaFiscalContingenciaReadRepository _entradaReadRepository = default!;
        private readonly IEntradaFiscalContingenciaWriteRepository _entradaWriteRepository = default!;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository = default!;
        private readonly ILogger _logger = default!;

        public ValidarEntradaFiscalContingenciaHandler(
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
            var pendencias = FiscalContingenciaPayload.Pendencias(entrada, documentos);

            if (pendencias.Count > 0)
            {
                _entradaWriteRepository.UpdatePendenciasJson(entrada.id, JsonSerializer.Serialize(pendencias));
                _entradaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);
                _entradaWriteRepository.UpdateStatus(entrada.id, 3);
                throw new InvalidOperationException($"Contingencia fiscal {entrada.cargaid}: entrada invalida: {string.Join(", ", pendencias)}.");
            }

            _entradaWriteRepository.UpdatePendenciasJson(entrada.id, "[]");
            _entradaWriteRepository.UpdateSnapshotJson(entrada.id, FiscalContingenciaPayload.SummaryJson(entrada, documentos));
            _entradaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);
            _entradaWriteRepository.UpdateStatus(entrada.id, 4);

            step.SetPayload(JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.entrada-validada",
                entradaFiscalContingenciaId = entrada.id,
                cargaId = entrada.cargaid,
                quantidadeDocumentos = documentos.Count,
                occurredAtUtc = DateTime.UtcNow
            }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Contingencia fiscal {saga.EntityId}: entrada fiscal validada.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
