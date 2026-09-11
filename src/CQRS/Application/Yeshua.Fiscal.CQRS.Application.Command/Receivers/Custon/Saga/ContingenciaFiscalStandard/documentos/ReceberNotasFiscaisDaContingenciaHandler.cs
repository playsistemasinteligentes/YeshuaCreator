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
using System;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class ReceberNotasFiscaisDaContingenciaHandler
    {
        private readonly IEntradaFiscalContingenciaReadRepository _entradaReadRepository;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository;
        private readonly ILogger _logger;

        public ReceberNotasFiscaisDaContingenciaHandler(
            IEntradaFiscalContingenciaReadRepository entradaReadRepository,
            INFeProdutoSnapshotReadRepository nfeProdutoSnapshotReadRepository,
            ILogger logger)
        {
            _entradaReadRepository = entradaReadRepository;
            _nfeProdutoSnapshotReadRepository = nfeProdutoSnapshotReadRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            var documentos = FiscalContingenciaState.LoadDocumentos(_nfeProdutoSnapshotReadRepository, entrada.cargaid);
            if (documentos.Count == 0)
            {
                step.SetPayload(JsonSerializer.Serialize(new
                {
                    type = "fiscal.contingencia.aguardando-notas-fiscais",
                    entradaFiscalContingenciaId = entrada.id,
                    cargaId = entrada.cargaid,
                    quantidadeDocumentos = 0,
                    mensagem = "Nenhuma NF-e recebida para iniciar preparacao.",
                    occurredAtUtc = DateTime.UtcNow
                }));
                return;
            }

            step.SetPayload(JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.notas-recebidas",
                entradaFiscalContingenciaId = entrada.id,
                cargaId = entrada.cargaid,
                quantidadeDocumentos = documentos.Count,
                occurredAtUtc = DateTime.UtcNow
            }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Contingencia fiscal {saga.EntityId}: notas fiscais recebidas.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
