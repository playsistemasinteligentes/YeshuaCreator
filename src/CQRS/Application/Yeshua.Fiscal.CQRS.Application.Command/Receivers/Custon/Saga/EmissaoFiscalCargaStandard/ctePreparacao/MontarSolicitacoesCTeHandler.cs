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
        private readonly ICTeParticipanteSnapshotReadRepository _cteParticipanteSnapshotReadRepository = default!;
        private readonly ICTeParticipanteSnapshotWriteRepository _cteParticipanteSnapshotWriteRepository = default!;
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
            ICTeParticipanteSnapshotReadRepository cteParticipanteSnapshotReadRepository,
            ICTeParticipanteSnapshotWriteRepository cteParticipanteSnapshotWriteRepository,
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
            _cteParticipanteSnapshotReadRepository = cteParticipanteSnapshotReadRepository;
            _cteParticipanteSnapshotWriteRepository = cteParticipanteSnapshotWriteRepository;
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

            var plano = PlanoEmissao.Load(entrada, romaneio, notas);
            var notasPorChave = notas.ToDictionary(x => x.chaveacesso ?? string.Empty, StringComparer.OrdinalIgnoreCase);
            var chavesPlanejadas = plano.CTes
                .SelectMany(x => x.DocumentKeys)
                .ToList();

            if (chavesPlanejadas.Count != chavesPlanejadas.Distinct(StringComparer.OrdinalIgnoreCase).Count())
                throw new InvalidOperationException($"Carga {cargaId}: o plano de emissao possui NF-e repetida entre grupos CT-e.");

            if (chavesPlanejadas.Count != notas.Count || chavesPlanejadas.Any(x => !notasPorChave.ContainsKey(x)))
                throw new InvalidOperationException($"Carga {cargaId}: os documentos do plano CT-e nao correspondem as NF-e disponiveis.");

            var solicitacoes = new List<int>(plano.CTes.Count);
            var documentosCriados = 0;
            foreach (var grupo in plano.CTes)
            {
                var notasDoGrupo = grupo.DocumentKeys.Select(x => notasPorChave[x]).ToList();
                var solicitacaoId = GarantirSolicitacao(entrada, romaneio, plano, grupo, notasDoGrupo);
                solicitacoes.Add(solicitacaoId);
                documentosCriados += GarantirDocumentosOriginarios(solicitacaoId, notasDoGrupo);
                GarantirParticipantes(solicitacaoId, notasDoGrupo);
            }

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
                    cteSolicitacaoFiscalIds = solicitacoes,
                    quantidadeSolicitacoes = solicitacoes.Count,
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
            PlanoEmissao plano,
            PlanoCTe grupo,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> notas)
        {
            var existente = (_cteSolicitacaoFiscalReadRepository.GetAllByRomaneioConsolidadoId(romaneio.id)
                    ?? Array.Empty<CTeSolicitacaoFiscalDTO>())
                .FirstOrDefault(x => string.Equals(
                    PlanoGroupKey(x.preferenciasmanifestojson),
                    grupo.Key,
                    StringComparison.OrdinalIgnoreCase));

            if (existente != null && existente.id > 0)
                return existente.id;

            var preferencias = JsonSerializer.Serialize(new
            {
                origem = "MontarSolicitacoesCTe",
                grupoChave = grupo.Key,
                grupoDescricao = grupo.Description,
                valorServicoOrigem = plano.FromStoredPlan ? "plano-emissao-confirmado" : "preferencias-fiscais",
                valorServico = grupo.FreightValue,
                valorCarga = grupo.DocumentsValue,
                quantidadeDocumentos = notas.Count,
                documentos = grupo.DocumentKeys,
                preferenciasFiscaisJson = plano.PreferencesJson
            });

            var solicitacao = new CTeSolicitacaoFiscalFactory(_logger).Create(
                null,
                entrada.id,
                romaneio.id,
                entrada.correlationid,
                plano.Environment,
                plano.StartState,
                plano.IssuerDocument,
                57,
                plano.CteType,
                plano.ServiceType,
                plano.Modal,
                plano.Globalized,
                plano.StartState,
                plano.EndState,
                plano.StartCityCode,
                plano.EndCityCode,
                grupo.FreightValue,
                grupo.DocumentsValue,
                preferencias,
                1);

            _cteSolicitacaoFiscalWriteRepository.Insert(solicitacao);
            if (!solicitacao.Id.HasValue || solicitacao.Id.Value <= 0)
                throw new InvalidOperationException($"Carga {romaneio.cargaid}: solicitacao fiscal CT-e nao recebeu Id apos insert.");

            return solicitacao.Id.Value;
        }

        private static string PlanoGroupKey(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return string.Empty;

            try
            {
                using var document = JsonDocument.Parse(json);
                return JsonText(document.RootElement, "grupoChave", "GrupoChave");
            }
            catch (JsonException)
            {
                return string.Empty;
            }
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

        private void GarantirParticipantes(
            int cteSolicitacaoFiscalId,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> notas)
        {
            var existentes = (_cteParticipanteSnapshotReadRepository.GetAllByCTeSolicitacaoFiscalId(cteSolicitacaoFiscalId)
                    ?? Array.Empty<CTeParticipanteSnapshotDTO>())
                .Select(x => $"{x.papel}|{OnlyDigits(x.documento ?? string.Empty)}")
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var primeiraNota = notas.First();
            InserirParticipante(
                cteSolicitacaoFiscalId,
                "Remetente",
                primeiraNota.emitentedocumento,
                primeiraNota.uforigem,
                primeiraNota.municipioorigemcodigoibge,
                primeiraNota.snapshotjson,
                "emitenteSnapshot",
                existentes);
            InserirParticipante(
                cteSolicitacaoFiscalId,
                "Destinatario",
                primeiraNota.destinatariodocumento,
                primeiraNota.ufdestino,
                primeiraNota.municipiodestinocodigoibge,
                primeiraNota.snapshotjson,
                "destinatarioSnapshot",
                existentes);
        }

        private void InserirParticipante(
            int cteSolicitacaoFiscalId,
            string papel,
            string documentoFallback,
            string ufFallback,
            string municipioFallback,
            string snapshotJson,
            string snapshotProperty,
            HashSet<string> existentes)
        {
            var snapshot = ParticipanteSnapshot.From(
                snapshotJson,
                snapshotProperty,
                documentoFallback,
                ufFallback,
                municipioFallback);
            var key = $"{papel}|{OnlyDigits(snapshot.Documento)}";
            if (string.IsNullOrWhiteSpace(snapshot.Documento) || existentes.Contains(key))
                return;

            var participante = new CTeParticipanteSnapshotFactory(_logger).Create(
                null,
                cteSolicitacaoFiscalId,
                papel,
                snapshot.Documento,
                snapshot.Nome,
                snapshot.InscricaoEstadual,
                snapshot.UF,
                snapshot.MunicipioCodigoIbge,
                snapshot.EnderecoJson);
            _cteParticipanteSnapshotWriteRepository.Insert(participante);
            existentes.Add(key);
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

        private sealed record PlanoCTe(
            string Key,
            string Description,
            decimal DocumentsValue,
            decimal GrossWeight,
            decimal FreightValue,
            IReadOnlyList<string> DocumentKeys);

        private sealed class PlanoEmissao
        {
            public bool FromStoredPlan { get; private init; }
            public int Environment { get; private init; }
            public string StartState { get; private init; } = string.Empty;
            public string EndState { get; private init; } = string.Empty;
            public string StartCityCode { get; private init; } = string.Empty;
            public string EndCityCode { get; private init; } = string.Empty;
            public string IssuerDocument { get; private init; } = string.Empty;
            public int CteType { get; private init; }
            public int ServiceType { get; private init; }
            public int Modal { get; private init; }
            public int Globalized { get; private init; }
            public string PreferencesJson { get; private init; } = string.Empty;
            public IReadOnlyList<PlanoCTe> CTes { get; private init; } = Array.Empty<PlanoCTe>();

            public static PlanoEmissao Load(
                CTeEntradaOficialDTO entrada,
                CTeRomaneioConsolidadoDTO romaneio,
                IReadOnlyCollection<NFeProdutoSnapshotDTO> notas)
            {
                if (!string.IsNullOrWhiteSpace(entrada.payloadstoragekey))
                {
                    var json = FiscalPayloadStore.Read(entrada.payloadstoragekey, entrada.payloadhash);
                    return Parse(json, romaneio);
                }

                var valorCarga = notas.Sum(x => x.valordocumento);
                var valorServico = JsonDecimal(romaneio.preferenciasfiscaisjson, "valorServico", "ValorServico", "valorFrete", "ValorFrete") ?? 100m;
                return new PlanoEmissao
                {
                    FromStoredPlan = false,
                    Environment = 2,
                    StartState = romaneio.ufinicio,
                    EndState = romaneio.uffim,
                    StartCityCode = romaneio.municipioiniciocodigoibge,
                    EndCityCode = romaneio.municipiofimcodigoibge,
                    IssuerDocument = romaneio.emitentedocumento,
                    Modal = 1,
                    PreferencesJson = romaneio.preferenciasfiscaisjson,
                    CTes = new[]
                    {
                        new PlanoCTe(
                            romaneio.cargaid,
                            "CT-e consolidado da carga",
                            valorCarga,
                            notas.Sum(x => x.pesobruto),
                            valorServico,
                            notas.Select(x => x.chaveacesso ?? string.Empty).ToArray())
                    }
                };
            }

            private static PlanoEmissao Parse(string json, CTeRomaneioConsolidadoDTO romaneio)
            {
                using var document = JsonDocument.Parse(json);
                var root = document.RootElement;
                if (!TryProperty(root, "ctesPrevistos", out var ctesElement) || ctesElement.ValueKind != JsonValueKind.Array)
                    throw new InvalidOperationException($"Carga {romaneio.cargaid}: plano confirmado nao possui ctesPrevistos.");

                var ctes = new List<PlanoCTe>();
                foreach (var cteElement in ctesElement.EnumerateArray())
                {
                    if (!TryProperty(cteElement, "documentos", out var documentsElement) || documentsElement.ValueKind != JsonValueKind.Array)
                        throw new InvalidOperationException($"Carga {romaneio.cargaid}: grupo CT-e do plano nao possui documentos.");

                    var keys = documentsElement
                        .EnumerateArray()
                        .Select(x => JsonText(x, "chaveacesso", "ChaveAcesso"))
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToArray();

                    if (keys.Length == 0)
                        throw new InvalidOperationException($"Carga {romaneio.cargaid}: grupo CT-e do plano nao possui chaves de NF-e.");

                    ctes.Add(new PlanoCTe(
                        JsonText(cteElement, "Chave", "chave"),
                        JsonText(cteElement, "Descricao", "descricao"),
                        JsonDecimal(cteElement, "valorDocumentos", "ValorDocumentos") ?? 0m,
                        JsonDecimal(cteElement, "pesoBruto", "PesoBruto") ?? 0m,
                        JsonDecimal(cteElement, "valorFreteRateado", "ValorFreteRateado") ?? 0m,
                        keys));
                }

                if (ctes.Count == 0)
                    throw new InvalidOperationException($"Carga {romaneio.cargaid}: plano confirmado nao possui grupos CT-e.");

                return new PlanoEmissao
                {
                    FromStoredPlan = true,
                    Environment = JsonInt(root, "ambiente", "Ambiente") is 1 or 2 ? JsonInt(root, "ambiente", "Ambiente") : 2,
                    StartState = FirstNotEmpty(JsonText(root, "ufinicio", "UFInicio"), romaneio.ufinicio),
                    EndState = FirstNotEmpty(JsonText(root, "uffim", "UFFim"), romaneio.uffim),
                    StartCityCode = FirstNotEmpty(JsonText(root, "municipioiniciocodigoibge", "MunicipioInicioCodigoIbge"), romaneio.municipioiniciocodigoibge),
                    EndCityCode = FirstNotEmpty(JsonText(root, "municipiofimcodigoibge", "MunicipioFimCodigoIbge"), romaneio.municipiofimcodigoibge),
                    IssuerDocument = FirstNotEmpty(JsonText(root, "emitenteFiscalDocumento", "emitentefiscaldocumento"), romaneio.emitentedocumento),
                    CteType = JsonInt(root, "tipoCTE", "tipoCTe", "TipoCTe"),
                    ServiceType = JsonInt(root, "tipoServico", "TipoServico"),
                    Modal = JsonInt(root, "modal", "Modal") is var modal && modal > 0 ? modal : 1,
                    Globalized = JsonInt(root, "globalizado", "Globalizado"),
                    PreferencesJson = FirstNotEmpty(JsonText(root, "preferenciasFiscaisJson", "PreferenciasFiscaisJson"), romaneio.preferenciasfiscaisjson),
                    CTes = ctes
                };
            }
        }

        private static string FirstNotEmpty(string first, string second)
            => string.IsNullOrWhiteSpace(first) ? second ?? string.Empty : first;

        private static string JsonText(JsonElement element, params string[] names)
        {
            foreach (var name in names)
            {
                if (!TryProperty(element, name, out var value))
                    continue;

                return value.ValueKind == JsonValueKind.String
                    ? value.GetString() ?? string.Empty
                    : value.ToString();
            }

            return string.Empty;
        }

        private static int JsonInt(JsonElement element, params string[] names)
        {
            foreach (var name in names)
            {
                if (TryProperty(element, name, out var value) && value.TryGetInt32(out var number))
                    return number;
            }

            return 0;
        }

        private static decimal? JsonDecimal(string json, params string[] names)
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;

            try
            {
                using var document = JsonDocument.Parse(json);
                return JsonDecimal(document.RootElement, names);
            }
            catch (JsonException)
            {
                return null;
            }
        }

        private static decimal? JsonDecimal(JsonElement element, params string[] names)
        {
            foreach (var name in names)
            {
                if (TryProperty(element, name, out var value) && value.TryGetDecimal(out var number))
                    return number;
            }

            return null;
        }

        private static bool TryProperty(JsonElement element, string name, out JsonElement value)
        {
            if (element.TryGetProperty(name, out value))
                return true;

            foreach (var property in element.EnumerateObject())
            {
                if (string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    value = property.Value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        private static string OnlyDigits(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            return new string(value.Where(character => character is >= '0' and <= '9').ToArray());
        }

        private sealed record ParticipanteSnapshot(
            string Documento,
            string Nome,
            string InscricaoEstadual,
            string UF,
            string MunicipioCodigoIbge,
            string EnderecoJson)
        {
            public static ParticipanteSnapshot From(
                string json,
                string propertyName,
                string documentoFallback,
                string ufFallback,
                string municipioFallback)
            {
                if (!string.IsNullOrWhiteSpace(json))
                {
                    try
                    {
                        using var document = JsonDocument.Parse(json);
                        if (TryProperty(document.RootElement, propertyName, out var participant) &&
                            participant.ValueKind == JsonValueKind.Object)
                        {
                            return new ParticipanteSnapshot(
                                FirstNotEmpty(JsonText(participant, "documento"), documentoFallback),
                                JsonText(participant, "nome"),
                                JsonText(participant, "inscricaoEstadual"),
                                FirstNotEmpty(JsonText(participant, "uf"), ufFallback),
                                FirstNotEmpty(JsonText(participant, "municipioCodigoIbge"), municipioFallback),
                                participant.GetRawText());
                        }
                    }
                    catch (JsonException)
                    {
                    }
                }

                return new ParticipanteSnapshot(
                    documentoFallback ?? string.Empty,
                    string.Empty,
                    string.Empty,
                    ufFallback ?? string.Empty,
                    municipioFallback ?? string.Empty,
                    "{}");
            }
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
