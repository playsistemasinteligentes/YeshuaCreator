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
using Dominio.Entitys;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class PrepararEntradaFiscalDaCargaHandler
    {
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository = default!;
        private readonly ICTeEntradaOficialReadRepository _cteEntradaOficialReadRepository = default!;
        private readonly ICTeEntradaOficialWriteRepository _cteEntradaOficialWriteRepository = default!;
        private readonly ICTeRomaneioConsolidadoReadRepository _cteRomaneioConsolidadoReadRepository = default!;
        private readonly ICTeRomaneioConsolidadoWriteRepository _cteRomaneioConsolidadoWriteRepository = default!;
        private readonly IyInboxWriteRepository _inboxWriteRepository = default!;
        private readonly ILogger _logger = default!;

        public PrepararEntradaFiscalDaCargaHandler(
            INFeProdutoSnapshotReadRepository nfeProdutoSnapshotReadRepository,
            ICTeEntradaOficialReadRepository cteEntradaOficialReadRepository,
            ICTeEntradaOficialWriteRepository cteEntradaOficialWriteRepository,
            ICTeRomaneioConsolidadoReadRepository cteRomaneioConsolidadoReadRepository,
            ICTeRomaneioConsolidadoWriteRepository cteRomaneioConsolidadoWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _nfeProdutoSnapshotReadRepository = nfeProdutoSnapshotReadRepository;
            _cteEntradaOficialReadRepository = cteEntradaOficialReadRepository;
            _cteEntradaOficialWriteRepository = cteEntradaOficialWriteRepository;
            _cteRomaneioConsolidadoReadRepository = cteRomaneioConsolidadoReadRepository;
            _cteRomaneioConsolidadoWriteRepository = cteRomaneioConsolidadoWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var notas = (_nfeProdutoSnapshotReadRepository.GetAllByCargaId(cargaId) ?? Array.Empty<NFeProdutoSnapshotDTO>())
                .Where(x => x.status == 1 || x.status == 2)
                .GroupBy(x => x.chaveacesso ?? string.Empty)
                .Select(x => x.OrderByDescending(n => n.id).First())
                .ToList();

            if (notas.Count == 0)
                throw new InvalidOperationException($"Carga {cargaId}: nao ha documentos originarios validos para preparar a entrada fiscal.");

            var input = EntradaFiscalStepInput.From(step.Payload);
            var resumo = EntradaFiscalResumo.From(cargaId, notas);
            var entradaOficialId = GarantirEntradaOficial(saga, step, input, resumo);
            var romaneioConsolidadoId = GarantirRomaneioConsolidado(saga, entradaOficialId, input, resumo);

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.entrada-fiscal-da-carga.preparada",
                new
                {
                    origem = "Fiscal",
                    modo = "entrada-fiscal-preparada",
                    entityId = saga.EntityId,
                    entradaOficialId,
                    romaneioConsolidadoId,
                    quantidadeDocumentos = notas.Count,
                    resumo.ValorCarga,
                    resumo.PesoBruto,
                    resumo.Volume,
                    resumo.UFInicio,
                    resumo.UFFim,
                    resumo.MunicipioInicioCodigoIbge,
                    resumo.MunicipioFimCodigoIbge
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: entrada fiscal da carga preparada.");
        }

        private int GarantirEntradaOficial(
            SagaBase saga,
            SagaStepBase step,
            EntradaFiscalStepInput input,
            EntradaFiscalResumo resumo)
        {
            var correlationId = saga.CorrelationId.ToString();
            var existente = _cteEntradaOficialReadRepository.FirstByCorrelationId(correlationId);
            if (existente != null && existente.id > 0)
                return existente.id;

            var payloadBase = string.IsNullOrWhiteSpace(step.Payload)
                ? JsonSerializer.Serialize(resumo)
                : step.Payload;

            var entrada = new CTeEntradaOficialFactory(_logger).Create(
                null,
                correlationId,
                input.SourceApplication,
                input.SourceModule,
                input.SourceMessageId,
                "EntradaFiscalCargaStandard",
                "1",
                DateTime.UtcNow,
                string.IsNullOrWhiteSpace(input.PayloadHash) ? Sha256(payloadBase) : input.PayloadHash,
                input.PayloadStorageKey,
                2);

            _cteEntradaOficialWriteRepository.Insert(entrada);
            if (!entrada.Id.HasValue || entrada.Id.Value <= 0)
                throw new InvalidOperationException($"Carga {resumo.CargaId}: entrada oficial CT-e nao recebeu Id apos insert.");

            return entrada.Id.Value;
        }

        private int GarantirRomaneioConsolidado(
            SagaBase saga,
            int entradaOficialId,
            EntradaFiscalStepInput input,
            EntradaFiscalResumo resumo)
        {
            var existente = _cteRomaneioConsolidadoReadRepository.FirstByCargaId(resumo.CargaId);
            if (existente != null && existente.id > 0)
                return existente.id;

            var rotaSnapshotJson = JsonSerializer.Serialize(new
            {
                resumo.UFInicio,
                resumo.UFFim,
                resumo.MunicipioInicioCodigoIbge,
                resumo.MunicipioFimCodigoIbge
            });

            var cargaSnapshotJson = JsonSerializer.Serialize(new
            {
                resumo.CargaId,
                resumo.QuantidadeDocumentos,
                resumo.ValorCarga,
                resumo.PesoBruto,
                resumo.Volume
            });

            var preferenciasFiscaisJson = PreferenciasFiscaisJson(input);

            var romaneio = new CTeRomaneioConsolidadoFactory(_logger).Create(
                null,
                entradaOficialId,
                saga.CorrelationId.ToString(),
                string.IsNullOrWhiteSpace(input.RomaneioId) ? resumo.CargaId : input.RomaneioId,
                resumo.CargaId,
                DateTime.UtcNow,
                resumo.UFInicio,
                resumo.UFFim,
                resumo.MunicipioInicioCodigoIbge,
                resumo.MunicipioFimCodigoIbge,
                resumo.EmitenteDocumento,
                resumo.TomadorDocumento,
                rotaSnapshotJson,
                cargaSnapshotJson,
                preferenciasFiscaisJson,
                1);

            _cteRomaneioConsolidadoWriteRepository.Insert(romaneio);
            if (!romaneio.Id.HasValue || romaneio.Id.Value <= 0)
                throw new InvalidOperationException($"Carga {resumo.CargaId}: romaneio consolidado CT-e nao recebeu Id apos insert.");

            return romaneio.Id.Value;
        }

        private static string PreferenciasFiscaisJson(EntradaFiscalStepInput input)
        {
            if (!string.IsNullOrWhiteSpace(input.PreferenciasFiscaisJson))
                return input.PreferenciasFiscaisJson;

            // pendencia: formalizar a propriedade de frete, rateio, agrupamento e rota fiscal.
            // No fluxo APS esses dados devem vir no snapshot; na contingencia nascem na tela.
            return JsonSerializer.Serialize(new
            {
                tipoCTe = 0,
                tipoServico = 0,
                modal = 1,
                globalizado = 0,
                origem = "PrepararEntradaFiscalDaCarga"
            });
        }

        private static string Sha256(string value)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(value ?? string.Empty));
            return Convert.ToHexString(bytes);
        }

        private sealed class EntradaFiscalStepInput
        {
            public string SourceApplication { get; private init; } = "ERP";
            public string SourceModule { get; private init; } = "DocumentosOriginarios";
            public string SourceMessageId { get; private init; } = Guid.NewGuid().ToString();
            public string PayloadHash { get; private init; } = string.Empty;
            public string PayloadStorageKey { get; private init; } = string.Empty;
            public string RomaneioId { get; private init; } = string.Empty;
            public string PreferenciasFiscaisJson { get; private init; } = string.Empty;

            public static EntradaFiscalStepInput From(string payload)
            {
                if (string.IsNullOrWhiteSpace(payload))
                    return new EntradaFiscalStepInput();

                try
                {
                    using var document = JsonDocument.Parse(payload);
                    var root = document.RootElement;
                    var preferencias = Text(root, "preferenciasFiscaisJson", "PreferenciasFiscaisJson", "dadosComplementaresJson", "DadosComplementaresJson");
                    if (string.IsNullOrWhiteSpace(preferencias))
                    {
                        var entradaSnapshotJson = Text(root, "entradaSnapshotJson", "EntradaSnapshotJson");
                        preferencias = TextFromJson(entradaSnapshotJson, "dadosComplementaresJson", "DadosComplementaresJson", "preferenciasFiscaisJson", "PreferenciasFiscaisJson");
                    }

                    return new EntradaFiscalStepInput
                    {
                        SourceApplication = Text(root, "sourceApplication", "SourceApplication") ?? "ERP",
                        SourceModule = Text(root, "sourceModule", "SourceModule") ?? "DocumentosOriginarios",
                        SourceMessageId = Text(root, "sourceMessageId", "SourceMessageId") ?? Guid.NewGuid().ToString(),
                        PayloadHash = Text(root, "payloadHash", "PayloadHash") ?? string.Empty,
                        PayloadStorageKey = Text(root, "payloadStorageKey", "PayloadStorageKey") ?? string.Empty,
                        RomaneioId = Text(root, "romaneioId", "RomaneioId") ?? string.Empty,
                        PreferenciasFiscaisJson = preferencias ?? string.Empty
                    };
                }
                catch (JsonException)
                {
                    return new EntradaFiscalStepInput();
                }
            }

            private static string? Text(JsonElement root, params string[] names)
            {
                foreach (var name in names)
                {
                    if (root.TryGetProperty(name, out var property) && property.ValueKind == JsonValueKind.String)
                    {
                        var value = property.GetString();
                        if (!string.IsNullOrWhiteSpace(value))
                            return value;
                    }
                }

                return null;
            }

            private static string? TextFromJson(string? json, params string[] names)
            {
                if (string.IsNullOrWhiteSpace(json))
                    return null;

                try
                {
                    using var document = JsonDocument.Parse(json);
                    return Text(document.RootElement, names);
                }
                catch (JsonException)
                {
                    return null;
                }
            }
        }

        private sealed class EntradaFiscalResumo
        {
            public string CargaId { get; private init; } = string.Empty;
            public int QuantidadeDocumentos { get; private init; }
            public decimal ValorCarga { get; private init; }
            public decimal PesoBruto { get; private init; }
            public decimal Volume { get; private init; }
            public string UFInicio { get; private init; } = string.Empty;
            public string UFFim { get; private init; } = string.Empty;
            public string MunicipioInicioCodigoIbge { get; private init; } = string.Empty;
            public string MunicipioFimCodigoIbge { get; private init; } = string.Empty;
            public string EmitenteDocumento { get; private init; } = string.Empty;
            public string TomadorDocumento { get; private init; } = string.Empty;

            public static EntradaFiscalResumo From(string cargaId, IReadOnlyCollection<NFeProdutoSnapshotDTO> notas)
            {
                var primeira = notas.OrderBy(x => x.id).First();
                var ultima = notas.OrderByDescending(x => x.id).First();

                return new EntradaFiscalResumo
                {
                    CargaId = cargaId,
                    QuantidadeDocumentos = notas.Count,
                    ValorCarga = notas.Sum(x => x.valordocumento),
                    PesoBruto = notas.Sum(x => x.pesobruto),
                    Volume = notas.Sum(x => x.volume),
                    UFInicio = primeira.uforigem ?? string.Empty,
                    UFFim = ultima.ufdestino ?? string.Empty,
                    MunicipioInicioCodigoIbge = primeira.municipioorigemcodigoibge ?? string.Empty,
                    MunicipioFimCodigoIbge = ultima.municipiodestinocodigoibge ?? string.Empty,
                    EmitenteDocumento = primeira.emitentedocumento ?? string.Empty,
                    TomadorDocumento = primeira.destinatariodocumento ?? string.Empty
                };
            }
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
