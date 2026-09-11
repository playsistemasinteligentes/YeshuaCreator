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
    public partial class AguardarComplementoDadosContingenciaHandler
    {
        private readonly IEntradaFiscalContingenciaReadRepository _entradaReadRepository;
        private readonly IEntradaFiscalContingenciaWriteRepository _entradaWriteRepository;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository;
        private readonly ILogger _logger;

        public AguardarComplementoDadosContingenciaHandler(
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
            var pendenciasJson = JsonSerializer.Serialize(pendencias);

            _entradaWriteRepository.UpdatePendenciasJson(entrada.id, pendenciasJson);
            _entradaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);

            if (pendencias.Count > 0)
            {
                _entradaWriteRepository.UpdateStatus(entrada.id, 3);
                throw new InvalidOperationException($"Contingencia fiscal {entrada.cargaid}: complemento pendente: {string.Join(", ", pendencias)}.");
            }

            _entradaWriteRepository.UpdateStatus(entrada.id, 4);
            step.SetPayload(JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.complemento-validado",
                entradaFiscalContingenciaId = entrada.id,
                cargaId = entrada.cargaid,
                occurredAtUtc = DateTime.UtcNow
            }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Contingencia fiscal {saga.EntityId}: complemento de dados validado.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
