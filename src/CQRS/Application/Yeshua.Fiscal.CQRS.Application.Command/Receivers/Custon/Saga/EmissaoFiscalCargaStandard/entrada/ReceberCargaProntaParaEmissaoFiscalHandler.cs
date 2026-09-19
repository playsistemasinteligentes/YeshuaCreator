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
    public partial class ReceberCargaProntaParaEmissaoFiscalHandler
    {
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository = default!;
        private readonly IyInboxWriteRepository _inboxWriteRepository = default!;
        private readonly ILogger _logger = default!;

        public ReceberCargaProntaParaEmissaoFiscalHandler(
            INFeProdutoSnapshotReadRepository nfeProdutoSnapshotReadRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _nfeProdutoSnapshotReadRepository = nfeProdutoSnapshotReadRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: carga recebida para emissao fiscal.");
            AcordarAguardandoDocumentosSeJaRecebidos(saga, payload);
        }

        private void AcordarAguardandoDocumentosSeJaRecebidos(SagaBase saga, string cargaRecebidaPayload)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            if (string.IsNullOrWhiteSpace(cargaId))
                return;

            var documentos = (_nfeProdutoSnapshotReadRepository.GetAllByCargaId(cargaId) ?? Array.Empty<Repositorio.Outputs.NFeProdutoSnapshotDTO>())
                .Where(x => x != null && !x.deleted && x.status != 9)
                .ToList();

            if (documentos.Count == 0)
                return;

            var stepAguardandoDocumentos = saga.Steps.FirstOrDefault(x => x.Key == EmissaoFiscalCargaStandardSaga.STEP_2);
            if (stepAguardandoDocumentos == null)
                return;

            var inboxPayload = JsonSerializer.Serialize(new
            {
                type = "fiscal.documentos-originarios-da-carga.informados",
                origem = "Fiscal",
                modo = "documentos-ja-persistidos",
                cargaId,
                sagaId = saga.Id,
                sagaType = saga.Type,
                sagaCorrelationId = saga.CorrelationId.ToString(),
                stepKey = stepAguardandoDocumentos.Key,
                stepCorrelationId = stepAguardandoDocumentos.CorrelationId,
                payloadHash = JsonText(cargaRecebidaPayload, "payloadHash", "PayloadHash"),
                payloadStorageKey = JsonText(cargaRecebidaPayload, "payloadStorageKey", "PayloadStorageKey"),
                preferenciasFiscaisJson = JsonText(cargaRecebidaPayload, "preferenciasFiscaisJson", "PreferenciasFiscaisJson"),
                quantidadeDocumentos = documentos.Count,
                occurredAtUtc = DateTime.UtcNow
            });

            var inbox = new yInboxFactory(_logger).Create(
                null,
                Guid.NewGuid().ToString(),
                "fiscal.documentos-originarios-da-carga.informados",
                "DocumentoFiscalOriginario",
                cargaId,
                stepAguardandoDocumentos.CorrelationId,
                inboxPayload,
                0,
                DateTime.UtcNow,
                0,
                null,
                null,
                null,
                saga.Id == 0 ? null : saga.Id,
                stepAguardandoDocumentos.Id == 0 ? null : stepAguardandoDocumentos.Id);

            _inboxWriteRepository.Insert(inbox);
            _logger.Info($"Fiscal {cargaId}: documentos originarios ja estavam persistidos; step de espera foi acordado.");
        }

        private static string JsonText(string json, params string[] names)
        {
            if (string.IsNullOrWhiteSpace(json))
                return string.Empty;

            using var document = JsonDocument.Parse(json);
            foreach (var name in names)
            {
                if (document.RootElement.TryGetProperty(name, out var value) && value.ValueKind == JsonValueKind.String)
                    return value.GetString() ?? string.Empty;
            }

            return string.Empty;
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
