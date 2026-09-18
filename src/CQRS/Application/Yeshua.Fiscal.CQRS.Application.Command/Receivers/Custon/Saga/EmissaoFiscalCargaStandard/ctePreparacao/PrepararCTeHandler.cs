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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class PrepararCTeHandler
    {
        private readonly ICTeRomaneioConsolidadoReadRepository _cteRomaneioConsolidadoReadRepository = default!;
        private readonly ICTeSolicitacaoFiscalReadRepository _cteSolicitacaoFiscalReadRepository = default!;
        private readonly ICTeSolicitacaoFiscalWriteRepository _cteSolicitacaoFiscalWriteRepository = default!;
        private readonly ICTeDocumentoOriginarioReadRepository _cteDocumentoOriginarioReadRepository = default!;
        private readonly ICTeParticipanteSnapshotReadRepository _cteParticipanteSnapshotReadRepository = default!;
        private readonly ICTeTentativaEmissaoReadRepository _cteTentativaEmissaoReadRepository = default!;
        private readonly ICTeTentativaEmissaoWriteRepository _cteTentativaEmissaoWriteRepository = default!;
        private readonly IyInboxWriteRepository _inboxWriteRepository = default!;
        private readonly ILogger _logger = default!;

        public PrepararCTeHandler(
            ICTeRomaneioConsolidadoReadRepository cteRomaneioConsolidadoReadRepository,
            ICTeSolicitacaoFiscalReadRepository cteSolicitacaoFiscalReadRepository,
            ICTeSolicitacaoFiscalWriteRepository cteSolicitacaoFiscalWriteRepository,
            ICTeDocumentoOriginarioReadRepository cteDocumentoOriginarioReadRepository,
            ICTeParticipanteSnapshotReadRepository cteParticipanteSnapshotReadRepository,
            ICTeTentativaEmissaoReadRepository cteTentativaEmissaoReadRepository,
            ICTeTentativaEmissaoWriteRepository cteTentativaEmissaoWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _cteRomaneioConsolidadoReadRepository = cteRomaneioConsolidadoReadRepository;
            _cteSolicitacaoFiscalReadRepository = cteSolicitacaoFiscalReadRepository;
            _cteSolicitacaoFiscalWriteRepository = cteSolicitacaoFiscalWriteRepository;
            _cteDocumentoOriginarioReadRepository = cteDocumentoOriginarioReadRepository;
            _cteParticipanteSnapshotReadRepository = cteParticipanteSnapshotReadRepository;
            _cteTentativaEmissaoReadRepository = cteTentativaEmissaoReadRepository;
            _cteTentativaEmissaoWriteRepository = cteTentativaEmissaoWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var romaneio = _cteRomaneioConsolidadoReadRepository.FirstByCargaId(cargaId);
            if (romaneio == null || romaneio.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: romaneio consolidado CT-e nao encontrado para preparar CT-e.");

            var solicitacoes = (_cteSolicitacaoFiscalReadRepository.GetAllByRomaneioConsolidadoId(romaneio.id)
                    ?? Array.Empty<Repositorio.Outputs.CTeSolicitacaoFiscalDTO>())
                .OrderBy(x => x.id)
                .ToList();

            if (solicitacoes.Count == 0)
                throw new InvalidOperationException($"Carga {cargaId}: solicitacoes fiscais CT-e nao encontradas para preparar CT-e.");

            var preparados = new List<CTePreparadoResumo>(solicitacoes.Count);
            foreach (var solicitacao in solicitacoes)
                preparados.Add(PrepararSolicitacao(cargaId, solicitacao));

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.cte.preparado",
                new
                {
                    origem = "Fiscal",
                    modo = "xml-cte-assinado-preparado",
                    entityId = saga.EntityId,
                    quantidadeCTes = preparados.Count,
                    ctes = preparados
                }));
        }

        private CTePreparadoResumo PrepararSolicitacao(
            string cargaId,
            Repositorio.Outputs.CTeSolicitacaoFiscalDTO solicitacao)
        {
            var tentativa = _cteTentativaEmissaoReadRepository.FirstByCTeSolicitacaoFiscalId(solicitacao.id);
            var tentativaId = tentativa?.id ?? 0;
            var storageKey = tentativa?.xmlassinadostoragekey ?? string.Empty;
            var xmlHash = tentativa?.xmlhash ?? string.Empty;
            var chave = tentativa?.chaveacesso ?? string.Empty;
            var numero = tentativa?.numero ?? 0;
            var serie = tentativa?.serie ?? 0;

            if (tentativaId <= 0)
            {
                var documentos = (_cteDocumentoOriginarioReadRepository.GetAllByCTeSolicitacaoFiscalId(solicitacao.id)
                        ?? Array.Empty<Repositorio.Outputs.CTeDocumentoOriginarioDTO>())
                    .Where(x => string.Equals(x.tipodocumento, "NFe", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(x => x.id)
                    .ToList();

                if (documentos.Count == 0)
                    throw new InvalidOperationException($"Carga {cargaId}: solicitacao CT-e {solicitacao.id} nao possui NF-e originaria.");

                var participantes = (_cteParticipanteSnapshotReadRepository.GetAllByCTeSolicitacaoFiscalId(solicitacao.id)
                        ?? Array.Empty<Repositorio.Outputs.CTeParticipanteSnapshotDTO>())
                    .ToList();
                var options = BuildOptions(solicitacao, documentos, participantes);
                var prepared = CteRecepcaoSincV4HomologacaoClient.Preparar(options);
                var storage = SefazFiscalDocumentStore.SalvarXmlResposta("cte", "preparacao", prepared.Chave, prepared.XmlCte);

                var entity = new CTeTentativaEmissaoFactory(_logger).Create(
                    null,
                    solicitacao.id,
                    prepared.Chave,
                    prepared.Numero,
                    prepared.Serie,
                    1,
                    storage.Path,
                    string.Empty,
                    storage.Sha256,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    null,
                    null,
                    1);

                _cteTentativaEmissaoWriteRepository.Insert(entity);
                if (!entity.Id.HasValue || entity.Id.Value <= 0)
                    throw new InvalidOperationException($"Carga {cargaId}: tentativa CT-e nao recebeu Id apos insert.");

                tentativaId = entity.Id.Value;
                storageKey = storage.Path;
                xmlHash = storage.Sha256;
                chave = prepared.Chave;
                numero = prepared.Numero ?? 0;
                serie = prepared.Serie ?? 0;
            }

            if (solicitacao.status < 3)
                _cteSolicitacaoFiscalWriteRepository.UpdateStatus(solicitacao.id, 3);

            return new CTePreparadoResumo(
                solicitacao.id,
                tentativaId,
                chave,
                numero,
                serie,
                storageKey,
                xmlHash);
        }

        private static CteRecepcaoSincV4Options BuildOptions(
            Repositorio.Outputs.CTeSolicitacaoFiscalDTO solicitacao,
            IReadOnlyCollection<Repositorio.Outputs.CTeDocumentoOriginarioDTO> documentos,
            IReadOnlyCollection<Repositorio.Outputs.CTeParticipanteSnapshotDTO> participantes)
        {
            var defaults = CteRecepcaoSincV4Options.FromEnvironment();
            var remetenteDocumento = SingleDocument(documentos.Select(x => x.emitentedocumento), "remetente", solicitacao.id);
            var destinatarioDocumento = SingleDocument(documentos.Select(x => x.destinatariodocumento), "destinatario", solicitacao.id);
            var chavesNFe = documentos
                .Select(x => OnlyDigits(x.chaveacesso ?? string.Empty))
                .Distinct(StringComparer.Ordinal)
                .ToArray();

            var municipioInicio = solicitacao.municipioiniciocodigoibge ?? string.Empty;
            var municipioFim = solicitacao.municipiofimcodigoibge ?? string.Empty;
            var emitente = OnlyDigits(solicitacao.emitentedocumento ?? string.Empty);

            return defaults with
            {
                Ambiente = solicitacao.ambiente,
                CodigoUf = CodigoUf(solicitacao.ufemitente, solicitacao.ufinicio, defaults.CodigoUf),
                CnpjEmitente = emitente,
                TipoCTe = solicitacao.tipocte,
                TipoServico = solicitacao.tiposervico,
                Modal = solicitacao.modal,
                Globalizado = solicitacao.globalizado,
                UfInicio = FirstNotEmpty(solicitacao.ufinicio, defaults.UfInicio),
                UfFim = FirstNotEmpty(solicitacao.uffim, defaults.UfFim),
                MunicipioInicioCodigoIbge = FirstNotEmpty(municipioInicio, defaults.MunicipioInicioCodigoIbge),
                MunicipioInicioNome = MunicipioNome(municipioInicio, defaults.MunicipioInicioCodigoIbge, defaults.MunicipioInicioNome),
                MunicipioFimCodigoIbge = FirstNotEmpty(municipioFim, defaults.MunicipioFimCodigoIbge),
                MunicipioFimNome = MunicipioNome(municipioFim, defaults.MunicipioFimCodigoIbge, defaults.MunicipioFimNome),
                RemetenteDocumento = remetenteDocumento,
                DestinatarioDocumento = destinatarioDocumento,
                Remetente = ParticipantOptions(participantes, "Remetente", remetenteDocumento),
                Destinatario = ParticipantOptions(participantes, "Destinatario", destinatarioDocumento),
                TomadorDocumento = RequiredJsonText(
                    solicitacao.preferenciasmanifestojson,
                    solicitacao.id,
                    "tomadorDocumento",
                    "cnpjTomador"),
                RazaoSocial = FirstNotEmpty(JsonText(solicitacao.preferenciasmanifestojson, "emitenteRazaoSocial", "razaoSocialEmitente"), defaults.RazaoSocial),
                InscricaoEstadual = FirstNotEmpty(JsonText(solicitacao.preferenciasmanifestojson, "emitenteInscricaoEstadual", "inscricaoEstadualEmitente"), defaults.InscricaoEstadual),
                NomeFantasiaEmitente = FirstNotEmpty(JsonText(solicitacao.preferenciasmanifestojson, "emitenteNomeFantasia", "nomeFantasiaEmitente"), defaults.NomeFantasiaEmitente),
                LogradouroEmitente = FirstNotEmpty(JsonText(solicitacao.preferenciasmanifestojson, "emitenteLogradouro", "logradouroEmitente"), defaults.LogradouroEmitente),
                NumeroEnderecoEmitente = FirstNotEmpty(JsonText(solicitacao.preferenciasmanifestojson, "emitenteNumero", "numeroEnderecoEmitente"), defaults.NumeroEnderecoEmitente),
                BairroEmitente = FirstNotEmpty(JsonText(solicitacao.preferenciasmanifestojson, "emitenteBairro", "bairroEmitente"), defaults.BairroEmitente),
                CepEmitente = FirstNotEmpty(JsonText(solicitacao.preferenciasmanifestojson, "emitenteCep", "cepEmitente"), defaults.CepEmitente),
                MunicipioEmitenteCodigoIbge = FirstNotEmpty(JsonText(solicitacao.preferenciasmanifestojson, "emitenteMunicipioCodigoIbge", "municipioEmitenteCodigoIbge"), defaults.MunicipioEmitenteCodigoIbge),
                MunicipioEmitenteNome = FirstNotEmpty(JsonText(solicitacao.preferenciasmanifestojson, "emitenteMunicipioNome", "municipioEmitenteNome"), defaults.MunicipioEmitenteNome),
                UfEmitente = FirstNotEmpty(JsonText(solicitacao.preferenciasmanifestojson, "emitenteUf", "ufEmitente"), defaults.UfEmitente),
                CrtEmitente = JsonInt(solicitacao.preferenciasmanifestojson, defaults.CrtEmitente, "emitenteCrt", "crtEmitente"),
                ObservacaoFiscal = JsonText(solicitacao.preferenciasmanifestojson, "observacaoFiscal"),
                Rntrc = FirstNotEmpty(JsonText(solicitacao.preferenciasmanifestojson, "rntrc", "RNTRC"), defaults.Rntrc),
                ValorServico = solicitacao.valorservico,
                ValorCarga = solicitacao.valorcarga,
                PesoBruto = documentos.Sum(x => x.pesobruto),
                ChavesNFe = chavesNFe
            };
        }

        private static CteParticipantOptions ParticipantOptions(
            IReadOnlyCollection<Repositorio.Outputs.CTeParticipanteSnapshotDTO> participantes,
            string papel,
            string documento)
        {
            var participant = participantes.FirstOrDefault(x =>
                string.Equals(x.papel, papel, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(OnlyDigits(x.documento ?? string.Empty), OnlyDigits(documento), StringComparison.Ordinal));
            if (participant == null)
                return CteParticipantOptions.Empty;

            var address = AddressSnapshot.From(participant.enderecojson);
            return new CteParticipantOptions(
                participant.documento ?? string.Empty,
                participant.nome ?? string.Empty,
                participant.inscricaoestadual ?? string.Empty,
                address.Logradouro,
                address.Numero,
                address.Bairro,
                FirstNotEmpty(participant.municipiocodigoibge, address.MunicipioCodigoIbge),
                address.MunicipioNome,
                address.Cep,
                FirstNotEmpty(participant.uf, address.UF));
        }

        private static string RequiredJsonText(string json, int requestId, params string[] names)
        {
            var value = OnlyDigits(JsonText(json, names));
            if (value.Length is not 11 and not 14)
                throw new InvalidOperationException($"Solicitacao CT-e {requestId}: documento do tomador nao informado.");

            return value;
        }

        private static int JsonInt(string json, int fallback, params string[] names)
        {
            var value = JsonText(json, names);
            return int.TryParse(value, out var number) ? number : fallback;
        }

        private static string SingleDocument(IEnumerable<string> source, string role, int requestId)
        {
            var documents = source
                .Select(OnlyDigits)
                .Where(x => x.Length is 11 or 14)
                .Distinct(StringComparer.Ordinal)
                .ToArray();

            if (documents.Length != 1)
                throw new InvalidOperationException($"Solicitacao CT-e {requestId}: o grupo deve possuir exatamente um {role}.");

            return documents[0];
        }

        private static string JsonText(string json, params string[] names)
        {
            if (string.IsNullOrWhiteSpace(json))
                return string.Empty;

            try
            {
                using var document = JsonDocument.Parse(json);
                foreach (var name in names)
                {
                    foreach (var property in document.RootElement.EnumerateObject())
                    {
                        if (string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase))
                            return property.Value.ValueKind == JsonValueKind.String
                                ? property.Value.GetString() ?? string.Empty
                                : property.Value.ToString();
                    }
                }

                foreach (var nestedName in new[] { "preferenciasFiscaisJson", "dadosComplementaresJson" })
                {
                    foreach (var property in document.RootElement.EnumerateObject())
                    {
                        if (string.Equals(property.Name, nestedName, StringComparison.OrdinalIgnoreCase) &&
                            property.Value.ValueKind == JsonValueKind.String)
                        {
                            return JsonText(property.Value.GetString() ?? string.Empty, names);
                        }
                    }
                }
            }
            catch (JsonException)
            {
                return string.Empty;
            }

            return string.Empty;
        }

        private static int CodigoUf(string first, string second, int fallback)
        {
            return FirstNotEmpty(first, second).Trim().ToUpperInvariant() switch
            {
                "RO" => 11, "AC" => 12, "AM" => 13, "RR" => 14, "PA" => 15, "AP" => 16, "TO" => 17,
                "MA" => 21, "PI" => 22, "CE" => 23, "RN" => 24, "PB" => 25, "PE" => 26, "AL" => 27, "SE" => 28, "BA" => 29,
                "MG" => 31, "ES" => 32, "RJ" => 33, "SP" => 35,
                "PR" => 41, "SC" => 42, "RS" => 43,
                "MS" => 50, "MT" => 51, "GO" => 52, "DF" => 53,
                _ => fallback
            };
        }

        private static string MunicipioNome(string code, string defaultCode, string defaultName)
            => string.Equals(code, defaultCode, StringComparison.Ordinal) ? defaultName : $"MUNICIPIO {code}";

        private static string FirstNotEmpty(string first, string second)
            => string.IsNullOrWhiteSpace(first) ? second ?? string.Empty : first;

        private static string OnlyDigits(string value)
        {
            var buffer = new char[value.Length];
            var count = 0;
            foreach (var character in value)
            {
                if (character is >= '0' and <= '9')
                    buffer[count++] = character;
            }

            return new string(buffer, 0, count);
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: CT-e preparado.");
        }

        private sealed record CTePreparadoResumo(
            int CTeSolicitacaoFiscalId,
            int CTeTentativaEmissaoId,
            string Chave,
            int Numero,
            int Serie,
            string XmlAssinadoStorageKey,
            string XmlHash);

        private sealed record AddressSnapshot(
            string Logradouro,
            string Numero,
            string Bairro,
            string MunicipioCodigoIbge,
            string MunicipioNome,
            string UF,
            string Cep)
        {
            public static AddressSnapshot From(string json)
            {
                if (!string.IsNullOrWhiteSpace(json))
                {
                    try
                    {
                        using var document = JsonDocument.Parse(json);
                        var root = document.RootElement;
                        return new AddressSnapshot(
                            ElementText(root, "logradouro"),
                            ElementText(root, "numero"),
                            ElementText(root, "bairro"),
                            ElementText(root, "municipioCodigoIbge"),
                            ElementText(root, "municipioNome"),
                            ElementText(root, "uf"),
                            ElementText(root, "cep"));
                    }
                    catch (JsonException)
                    {
                    }
                }

                return new AddressSnapshot(
                    string.Empty, string.Empty, string.Empty, string.Empty,
                    string.Empty, string.Empty, string.Empty);
            }

            private static string ElementText(JsonElement element, string name)
            {
                foreach (var property in element.EnumerateObject())
                {
                    if (string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase))
                        return property.Value.ValueKind == JsonValueKind.String
                            ? property.Value.GetString() ?? string.Empty
                            : property.Value.ToString();
                }

                return string.Empty;
            }
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
