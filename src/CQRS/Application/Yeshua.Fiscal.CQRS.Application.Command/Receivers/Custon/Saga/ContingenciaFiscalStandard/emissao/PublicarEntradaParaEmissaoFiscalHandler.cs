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
using System.Text.Json;

namespace Command.Receivers
{
    public partial class PublicarEntradaParaEmissaoFiscalHandler
    {
        private const string StartFiscalSagaEvent = "CargaProntaParaEmissaoFiscal.v1";

        private readonly IEntradaFiscalContingenciaReadRepository _entradaReadRepository;
        private readonly IEntradaFiscalContingenciaWriteRepository _entradaWriteRepository;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public PublicarEntradaParaEmissaoFiscalHandler(
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
            if (documentos.Count == 0)
                throw new InvalidOperationException($"Contingencia fiscal {entrada.cargaid}: nao ha documentos para publicar ao Fiscal.");

            var dadosComplementaresJson = FiscalContingenciaPayload.Text(entrada.snapshotjson, "dadosComplementaresJson", "DadosComplementaresJson");
            var emissaoCorrelationId = string.IsNullOrWhiteSpace(entrada.emissaofiscalcorrelationid)
                ? Guid.NewGuid().ToString()
                : entrada.emissaofiscalcorrelationid;

            var payload = JsonSerializer.Serialize(new
            {
                type = StartFiscalSagaEvent,
                origem = "ContingenciaFiscal",
                moduloOrigem = "Fiscal",
                sagaOrigem = nameof(ContingenciaFiscalStandardSaga),
                stepOrigem = ContingenciaFiscalStandardSaga.STEP_10,
                modo = "contingencia-fiscal",
                cargaId = entrada.cargaid,
                sagaCorrelationId = emissaoCorrelationId,
                contingenciaSagaCorrelationId = saga.CorrelationId.ToString(),
                entradaFiscalContingenciaId = entrada.id,
                quantidadeDocumentos = documentos.Count,
                documentos = documentos,
                entradaSnapshotJson = entrada.snapshotjson,
                dadosComplementaresJson,
                preferenciasFiscaisJson = dadosComplementaresJson,
                occurredAtUtc = DateTime.UtcNow
            });

            var inbox = new yInboxFactory(_logger).Create(
                null,
                Guid.NewGuid().ToString(),
                StartFiscalSagaEvent,
                "Carga",
                entrada.cargaid,
                emissaoCorrelationId,
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
            _entradaWriteRepository.UpdateEmissaoFiscalCorrelationId(entrada.id, emissaoCorrelationId);
            _entradaWriteRepository.UpdateAtualizadoEmUtc(entrada.id, DateTime.UtcNow);
            _entradaWriteRepository.UpdateStatus(entrada.id, 5);

            step.SetPayload(JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.entrada-publicada-para-emissao",
                entradaFiscalContingenciaId = entrada.id,
                cargaId = entrada.cargaid,
                emissaoFiscalCorrelationId = emissaoCorrelationId,
                occurredAtUtc = DateTime.UtcNow
            }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Contingencia fiscal {saga.EntityId}: entrada publicada para saga fiscal.");
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
