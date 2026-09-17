// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using System;
using System.Linq;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class PublicarPlanoParaSagaFiscalHandler
    {
        private const string EventoIniciarSagaFiscal = "CargaProntaParaEmissaoFiscal.v1";
        private readonly IEntradaFiscalContingenciaReadRepository _entradaReadRepository = default!;
        private readonly IEntradaFiscalContingenciaWriteRepository _entradaWriteRepository = default!;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository = default!;
        private readonly IyInboxWriteRepository _inboxWriteRepository = default!;
        private readonly ILogger _logger = default!;

        public PublicarPlanoParaSagaFiscalHandler(
            IEntradaFiscalContingenciaReadRepository entradaReadRepository,
            IEntradaFiscalContingenciaWriteRepository entradaWriteRepository,
            INFeProdutoSnapshotReadRepository nfeProdutoSnapshotReadRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _entradaReadRepository = entradaReadRepository;
            _entradaWriteRepository = entradaWriteRepository;
            _nfeProdutoSnapshotReadRepository = nfeProdutoSnapshotReadRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var entrada = FiscalContingenciaState.LoadEntrada(_entradaReadRepository, saga, step);
            var documentos = FiscalContingenciaState.LoadDocumentos(_nfeProdutoSnapshotReadRepository, entrada.cargaid);
            var pendencias = FiscalContingenciaPayload.Pendencias(entrada, documentos);

            if (pendencias.Count > 0)
            {
                throw new InvalidOperationException(
                    $"Contingencia fiscal {entrada.cargaid}: plano de emissao invalido: {string.Join(", ", pendencias)}.");
            }

            var fiscalCorrelationId = string.IsNullOrWhiteSpace(entrada.emissaofiscalcorrelationid)
                ? saga.CorrelationId.ToString()
                : entrada.emissaofiscalcorrelationid;

            var preferenciasFiscaisJson = FiscalContingenciaPayload.ComplementoJson(entrada);
            var payload = JsonSerializer.Serialize(new
            {
                type = EventoIniciarSagaFiscal,
                origem = "ContingenciaFiscal",
                moduloOrigem = "Fiscal",
                sagaOrigem = nameof(ContingenciaFiscalStandardSaga),
                stepOrigem = nameof(PublicarPlanoParaSagaFiscalHandler),
                moduloDestino = "Fiscal",
                sagaDestino = nameof(EmissaoFiscalCargaStandardSaga),
                entradaFiscalContingenciaId = entrada.id,
                cargaId = entrada.cargaid,
                sagaCorrelationId = fiscalCorrelationId,
                sourceApplication = entrada.sourceapplication,
                sourceModule = entrada.sourcemodule,
                sourceMessageId = entrada.sourcemessageid,
                romaneioId = entrada.cargaid,
                payloadHash = string.Empty,
                payloadStorageKey = string.Empty,
                preferenciasFiscaisJson,
                quantidadeDocumentos = documentos.Count,
                valorCarga = documentos.Sum(x => x.valordocumento),
                pesoBruto = documentos.Sum(x => x.pesobruto),
                volume = documentos.Sum(x => x.volume),
                occurredAtUtc = DateTime.UtcNow
            });

            var inbox = new yInboxFactory(_logger).Create(
                null,
                Guid.NewGuid().ToString(),
                EventoIniciarSagaFiscal,
                "Carga",
                entrada.cargaid,
                fiscalCorrelationId,
                payload,
                0,
                DateTime.UtcNow,
                0,
                null,
                null,
                null,
                saga.Id == 0 ? null : saga.Id,
                step.Id == 0 ? null : step.Id);

            _inboxWriteRepository.Insert(inbox);
            _entradaWriteRepository.UpdateEmissaoFiscalCorrelationId(entrada.id, fiscalCorrelationId);
            _entradaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);

            step.SetPayload(JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.plano-publicado-para-saga-fiscal",
                entradaFiscalContingenciaId = entrada.id,
                cargaId = entrada.cargaid,
                emissaoFiscalCorrelationId = fiscalCorrelationId,
                quantidadeDocumentos = documentos.Count,
                occurredAtUtc = DateTime.UtcNow
            }));

            _logger.Info($"Contingencia fiscal {entrada.cargaid}: plano publicado para saga fiscal.");
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Contingencia fiscal {saga.EntityId}: publicacao para saga fiscal confirmada.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
