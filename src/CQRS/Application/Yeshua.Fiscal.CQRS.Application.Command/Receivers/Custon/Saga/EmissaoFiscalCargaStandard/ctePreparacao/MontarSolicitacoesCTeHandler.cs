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
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class MontarSolicitacoesCTeHandler
    {
        private readonly ICTeEntradaOficialReadRepository _cteEntradaOficialReadRepository = default!;
        private readonly ICTeRomaneioConsolidadoReadRepository _cteRomaneioConsolidadoReadRepository = default!;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository = default!;
        private readonly ICTeSolicitacaoFiscalReadRepository _cteSolicitacaoFiscalReadRepository = default!;
        private readonly ICTeSolicitacaoFiscalWriteRepository _cteSolicitacaoFiscalWriteRepository = default!;
        private readonly ICTeDocumentoOriginarioReadRepository _cteDocumentoOriginarioReadRepository = default!;
        private readonly ICTeDocumentoOriginarioWriteRepository _cteDocumentoOriginarioWriteRepository = default!;
        private readonly IyInboxWriteRepository _inboxWriteRepository = default!;
        private readonly ILogger _logger = default!;

        public MontarSolicitacoesCTeHandler(
            ICTeEntradaOficialReadRepository cteEntradaOficialReadRepository,
            ICTeRomaneioConsolidadoReadRepository cteRomaneioConsolidadoReadRepository,
            INFeProdutoSnapshotReadRepository nfeProdutoSnapshotReadRepository,
            ICTeSolicitacaoFiscalReadRepository cteSolicitacaoFiscalReadRepository,
            ICTeSolicitacaoFiscalWriteRepository cteSolicitacaoFiscalWriteRepository,
            ICTeDocumentoOriginarioReadRepository cteDocumentoOriginarioReadRepository,
            ICTeDocumentoOriginarioWriteRepository cteDocumentoOriginarioWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _cteEntradaOficialReadRepository = cteEntradaOficialReadRepository;
            _cteRomaneioConsolidadoReadRepository = cteRomaneioConsolidadoReadRepository;
            _nfeProdutoSnapshotReadRepository = nfeProdutoSnapshotReadRepository;
            _cteSolicitacaoFiscalReadRepository = cteSolicitacaoFiscalReadRepository;
            _cteSolicitacaoFiscalWriteRepository = cteSolicitacaoFiscalWriteRepository;
            _cteDocumentoOriginarioReadRepository = cteDocumentoOriginarioReadRepository;
            _cteDocumentoOriginarioWriteRepository = cteDocumentoOriginarioWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var entrada = _cteEntradaOficialReadRepository.FirstByCorrelationId(saga.CorrelationId.ToString());
            if (entrada == null || entrada.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: entrada oficial CT-e nao encontrada para montar solicitacoes.");

            var romaneio = _cteRomaneioConsolidadoReadRepository.FirstByCargaId(cargaId);
            if (romaneio == null || romaneio.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: romaneio consolidado CT-e nao encontrado para montar solicitacoes.");

            var notas = (_nfeProdutoSnapshotReadRepository.GetAllByCargaId(cargaId) ?? Array.Empty<NFeProdutoSnapshotDTO>())
                .Where(x => x.status == 1 || x.status == 2)
                .GroupBy(x => x.chaveacesso ?? string.Empty)
                .Select(x => x.OrderByDescending(n => n.id).First())
                .ToList();

            if (notas.Count == 0)
                throw new InvalidOperationException($"Carga {cargaId}: nao ha NF-e valida para montar solicitacao de CT-e.");

            var solicitacaoId = GarantirSolicitacao(entrada, romaneio, notas);
            var documentosCriados = GarantirDocumentosOriginarios(solicitacaoId, notas);

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.cte.solicitacoes-montadas",
                new
                {
                    origem = "Fiscal",
                    modo = "solicitacao-cte-montada",
                    entityId = saga.EntityId,
                    entradaOficialId = entrada.id,
                    romaneioConsolidadoId = romaneio.id,
                    cteSolicitacaoFiscalId = solicitacaoId,
                    quantidadeDocumentos = notas.Count,
                    documentosCriados
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: solicitacoes de CT-e montadas.");
        }

        private int GarantirSolicitacao(
            CTeEntradaOficialDTO entrada,
            CTeRomaneioConsolidadoDTO romaneio,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> notas)
        {
            var existente = _cteSolicitacaoFiscalReadRepository.FirstByRomaneioConsolidadoId(romaneio.id);
            if (existente != null && existente.id > 0)
                return existente.id;

            var valores = ValoresFiscais.From(romaneio, notas);
            var preferencias = JsonSerializer.Serialize(new
            {
                origem = "MontarSolicitacoesCTe",
                valorServicoOrigem = valores.ValorServicoOrigem,
                valorServico = valores.ValorServico,
                valorCarga = valores.ValorCarga,
                quantidadeDocumentos = notas.Count,
                preferenciasFiscaisJson = romaneio.preferenciasfiscaisjson
            });

            var solicitacao = new CTeSolicitacaoFiscalFactory(_logger).Create(
                null,
                entrada.id,
                romaneio.id,
                entrada.correlationid,
                2,
                romaneio.ufinicio,
                romaneio.emitentedocumento,
                57,
                0,
                0,
                1,
                0,
                romaneio.ufinicio,
                romaneio.uffim,
                romaneio.municipioiniciocodigoibge,
                romaneio.municipiofimcodigoibge,
                valores.ValorServico,
                valores.ValorCarga,
                preferencias,
                1);

            _cteSolicitacaoFiscalWriteRepository.Insert(solicitacao);
            if (!solicitacao.Id.HasValue || solicitacao.Id.Value <= 0)
                throw new InvalidOperationException($"Carga {romaneio.cargaid}: solicitacao fiscal CT-e nao recebeu Id apos insert.");

            return solicitacao.Id.Value;
        }

        private int GarantirDocumentosOriginarios(
            int cteSolicitacaoFiscalId,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> notas)
        {
            var existentes = (_cteDocumentoOriginarioReadRepository.GetAllByCTeSolicitacaoFiscalId(cteSolicitacaoFiscalId)
                    ?? Array.Empty<CTeDocumentoOriginarioDTO>())
                .Select(x => x.chaveacesso ?? string.Empty)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var criados = 0;
            foreach (var nota in notas)
            {
                if (existentes.Contains(nota.chaveacesso ?? string.Empty))
                    continue;

                var documento = new CTeDocumentoOriginarioFactory(_logger).Create(
                    null,
                    cteSolicitacaoFiscalId,
                    nota.documentofiscaloriginarioid,
                    "NFe",
                    nota.chaveacesso,
                    NumeroDocumento(nota.chaveacesso ?? string.Empty),
                    SerieDocumento(nota.chaveacesso ?? string.Empty),
                    nota.emitentedocumento,
                    nota.destinatariodocumento,
                    nota.valordocumento,
                    nota.pesobruto,
                    DocumentoSnapshot(nota));

                _cteDocumentoOriginarioWriteRepository.Insert(documento);
                criados++;
            }

            return criados;
        }

        private static string DocumentoSnapshot(NFeProdutoSnapshotDTO nota)
        {
            if (!string.IsNullOrWhiteSpace(nota.snapshotjson))
                return nota.snapshotjson;

            return JsonSerializer.Serialize(new
            {
                nota.id,
                nota.documentofiscaloriginarioid,
                nota.correlationid,
                nota.cargaid,
                nota.pedidoid,
                nota.chaveacesso,
                nota.emitentedocumento,
                nota.destinatariodocumento,
                nota.uforigem,
                nota.ufdestino,
                nota.municipioorigemcodigoibge,
                nota.municipiodestinocodigoibge,
                nota.valordocumento,
                nota.pesobruto,
                nota.volume,
                nota.xmlstoragekey
            });
        }

        private static string SerieDocumento(string chaveAcesso)
        {
            if (string.IsNullOrWhiteSpace(chaveAcesso) || chaveAcesso.Length < 25)
                return string.Empty;

            return chaveAcesso.Substring(22, 3).TrimStart('0');
        }

        private static string NumeroDocumento(string chaveAcesso)
        {
            if (string.IsNullOrWhiteSpace(chaveAcesso) || chaveAcesso.Length < 34)
                return string.Empty;

            return chaveAcesso.Substring(25, 9).TrimStart('0');
        }

        private sealed class ValoresFiscais
        {
            public decimal ValorServico { get; private init; }
            public decimal ValorCarga { get; private init; }
            public string ValorServicoOrigem { get; private init; } = "padrao-homologacao";

            public static ValoresFiscais From(CTeRomaneioConsolidadoDTO romaneio, IReadOnlyCollection<NFeProdutoSnapshotDTO> notas)
            {
                var valorCarga = notas.Sum(x => x.valordocumento);
                var valorServicoInformado = ExtrairDecimal(romaneio.preferenciasfiscaisjson, "valorServico", "ValorServico", "valorFrete", "ValorFrete");

                if (valorServicoInformado.HasValue && valorServicoInformado.Value > 0)
                {
                    return new ValoresFiscais
                    {
                        ValorCarga = valorCarga,
                        ValorServico = valorServicoInformado.Value,
                        ValorServicoOrigem = "preferencias-fiscais"
                    };
                }

                return new ValoresFiscais
                {
                    ValorCarga = valorCarga,
                    ValorServico = 100m
                };
            }

            private static decimal? ExtrairDecimal(string json, params string[] names)
            {
                if (string.IsNullOrWhiteSpace(json))
                    return null;

                try
                {
                    using var document = JsonDocument.Parse(json);
                    foreach (var name in names)
                    {
                        if (document.RootElement.TryGetProperty(name, out var property)
                            && property.ValueKind == JsonValueKind.Number
                            && property.TryGetDecimal(out var value))
                        {
                            return value;
                        }
                    }
                }
                catch (JsonException)
                {
                    return null;
                }

                return null;
            }
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
