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
    public partial class MontarSolicitacaoMDFeHandler
    {
        private readonly ICTeSaidaMDFeReadRepository _cteSaidaMDFeReadRepository = default!;
        private readonly ICTeRomaneioConsolidadoReadRepository _cteRomaneioConsolidadoReadRepository = default!;
        private readonly IMDFeSolicitacaoFiscalReadRepository _mdfeSolicitacaoFiscalReadRepository = default!;
        private readonly IMDFeSolicitacaoFiscalWriteRepository _mdfeSolicitacaoFiscalWriteRepository = default!;
        private readonly IMDFeDocumentoOriginarioReadRepository _mdfeDocumentoOriginarioReadRepository = default!;
        private readonly IMDFeDocumentoOriginarioWriteRepository _mdfeDocumentoOriginarioWriteRepository = default!;
        private readonly IyInboxWriteRepository _inboxWriteRepository = default!;
        private readonly ILogger _logger = default!;

        public MontarSolicitacaoMDFeHandler(
            ICTeSaidaMDFeReadRepository cteSaidaMDFeReadRepository,
            ICTeRomaneioConsolidadoReadRepository cteRomaneioConsolidadoReadRepository,
            IMDFeSolicitacaoFiscalReadRepository mdfeSolicitacaoFiscalReadRepository,
            IMDFeSolicitacaoFiscalWriteRepository mdfeSolicitacaoFiscalWriteRepository,
            IMDFeDocumentoOriginarioReadRepository mdfeDocumentoOriginarioReadRepository,
            IMDFeDocumentoOriginarioWriteRepository mdfeDocumentoOriginarioWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _cteSaidaMDFeReadRepository = cteSaidaMDFeReadRepository;
            _cteRomaneioConsolidadoReadRepository = cteRomaneioConsolidadoReadRepository;
            _mdfeSolicitacaoFiscalReadRepository = mdfeSolicitacaoFiscalReadRepository;
            _mdfeSolicitacaoFiscalWriteRepository = mdfeSolicitacaoFiscalWriteRepository;
            _mdfeDocumentoOriginarioReadRepository = mdfeDocumentoOriginarioReadRepository;
            _mdfeDocumentoOriginarioWriteRepository = mdfeDocumentoOriginarioWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var romaneio = _cteRomaneioConsolidadoReadRepository.FirstByCargaId(cargaId);
            if (romaneio == null || romaneio.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: romaneio CT-e nao encontrado para montar MDF-e.");

            var saidasCte = (_cteSaidaMDFeReadRepository.GetAllByCorrelationId(saga.CorrelationId.ToString())
                    ?? Array.Empty<Repositorio.Outputs.CTeSaidaMDFeDTO>())
                .Where(x => x.id > 0 && x.status <= 2 && !string.IsNullOrWhiteSpace(x.chaveacessocte))
                .GroupBy(x => x.chaveacessocte, StringComparer.OrdinalIgnoreCase)
                .Select(x => x.OrderByDescending(item => item.id).First())
                .OrderBy(x => x.id)
                .ToList();

            if (saidasCte.Count == 0)
                throw new InvalidOperationException($"Carga {cargaId}: CT-es autorizados nao encontrados para montar MDF-e.");

            var options = BuildOptions(romaneio);
            var solicitacaoId = GarantirSolicitacao(saga, romaneio, saidasCte, options);
            GarantirDocumentosOriginarios(solicitacaoId, saidasCte);

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.mdfe.solicitacao-montada",
                new
                {
                    origem = "Fiscal",
                    modo = "solicitacao-mdfe-montada",
                    entityId = saga.EntityId,
                    mdfeSolicitacaoFiscalId = solicitacaoId,
                    quantidadeCTes = saidasCte.Count
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: solicitacao de MDF-e montada.");
        }

        private int GarantirSolicitacao(
            SagaBase saga,
            Repositorio.Outputs.CTeRomaneioConsolidadoDTO romaneio,
            IReadOnlyCollection<Repositorio.Outputs.CTeSaidaMDFeDTO> saidasCte,
            MdfeRecepcaoSincOptions options)
        {
            var existente = _mdfeSolicitacaoFiscalReadRepository.FirstByCargaId(romaneio.cargaid);
            if (existente != null && existente.id > 0)
                return existente.id;

            var documentos = JsonSerializer.Serialize(
                saidasCte.Select(saidaCte => new
                {
                    tipo = "CTe",
                    chave = saidaCte.chaveacessocte,
                    snapshotHash = saidaCte.snapshothash
                }));

            var transporte = JsonSerializer.Serialize(new
            {
                options.Ambiente,
                options.CodigoUf,
                options.CnpjEmitente,
                options.RazaoSocial,
                options.NomeFantasia,
                options.InscricaoEstadual,
                options.CodigoMunicipioEmitente,
                options.MunicipioEmitente,
                options.UfEmitente,
                options.UfInicio,
                options.CodigoMunicipioCarregamento,
                options.MunicipioCarregamento,
                options.CodigoMunicipioDescarga,
                options.MunicipioDescarga,
                options.UfDescarga,
                options.Placa,
                condutorDocumento = options.CondutorCpf,
                condutorNome = options.CondutorNome,
                options.Rntrc,
                options.Renavam,
                options.TaraKg,
                options.CapacidadeKg,
                options.CapacidadeM3,
                options.TipoRodado,
                options.TipoCarroceria,
                options.ValorCarga,
                options.PesoBruto,
                options.ValorContrato,
                options.TipoCarga,
                options.ProdutoPredominante,
                options.NcmProdutoPredominante,
                options.ObservacaoFiscal
            });

            var solicitacao = new MDFeSolicitacaoFiscalFactory(_logger).Create(
                null,
                saga.CorrelationId.ToString(),
                romaneio.cargaid,
                options.Ambiente,
                romaneio.ufinicio,
                romaneio.uffim,
                options.Placa,
                options.CondutorCpf,
                documentos,
                transporte,
                1);

            _mdfeSolicitacaoFiscalWriteRepository.Insert(solicitacao);
            if (!solicitacao.Id.HasValue || solicitacao.Id.Value <= 0)
                throw new InvalidOperationException($"Carga {romaneio.cargaid}: solicitacao MDF-e nao recebeu Id apos insert.");

            return solicitacao.Id.Value;
        }

        private static MdfeRecepcaoSincOptions BuildOptions(Repositorio.Outputs.CTeRomaneioConsolidadoDTO romaneio)
        {
            var defaults = MdfeRecepcaoSincOptions.FromEnvironment();
            var preferencias = romaneio.preferenciasfiscaisjson ?? string.Empty;
            var emitente = OnlyDigits(FirstNotEmpty(
                JsonText(preferencias, "emitenteFiscalDocumento", "cnpjEmitente", "emitenteDocumento"),
                romaneio.emitentedocumento ?? string.Empty));
            var ufEmitente = FirstNotEmpty(JsonText(preferencias, "emitenteUf", "ufEmitente"), defaults.UfEmitente);
            var codigoMunicipioEmitente = FirstNotEmpty(
                JsonText(preferencias, "emitenteMunicipioCodigoIbge", "municipioEmitenteCodigoIbge"),
                defaults.CodigoMunicipioEmitente);
            var codigoInicio = FirstNotEmpty(romaneio.municipioiniciocodigoibge, defaults.CodigoMunicipioEmitente);
            var codigoFim = FirstNotEmpty(romaneio.municipiofimcodigoibge, defaults.CodigoMunicipioDescarga);

            return defaults with
            {
                CodigoUf = CodigoUf(ufEmitente, defaults.CodigoUf),
                CnpjEmitente = emitente,
                RazaoSocial = FirstNotEmpty(JsonText(preferencias, "emitenteRazaoSocial", "razaoSocialEmitente"), defaults.RazaoSocial),
                NomeFantasia = FirstNotEmpty(JsonText(preferencias, "emitenteNomeFantasia", "nomeFantasiaEmitente"), defaults.NomeFantasia),
                InscricaoEstadual = FirstNotEmpty(JsonText(preferencias, "emitenteInscricaoEstadual", "inscricaoEstadualEmitente"), defaults.InscricaoEstadual),
                Endereco = FirstNotEmpty(JsonText(preferencias, "emitenteLogradouro", "logradouroEmitente"), defaults.Endereco),
                NumeroEndereco = FirstNotEmpty(JsonText(preferencias, "emitenteNumero", "numeroEnderecoEmitente"), defaults.NumeroEndereco),
                Bairro = FirstNotEmpty(JsonText(preferencias, "emitenteBairro", "bairroEmitente"), defaults.Bairro),
                Cep = FirstNotEmpty(JsonText(preferencias, "emitenteCep", "cepEmitente"), defaults.Cep),
                CodigoMunicipioEmitente = codigoMunicipioEmitente,
                MunicipioEmitente = FirstNotEmpty(JsonText(preferencias, "emitenteMunicipioNome", "municipioEmitenteNome"), defaults.MunicipioEmitente),
                UfEmitente = ufEmitente,
                UfInicio = FirstNotEmpty(romaneio.ufinicio, defaults.UfInicio),
                CodigoMunicipioCarregamento = codigoInicio,
                MunicipioCarregamento = MunicipioNome(codigoInicio, defaults.CodigoMunicipioCarregamento, defaults.MunicipioCarregamento),
                CodigoMunicipioDescarga = codigoFim,
                MunicipioDescarga = MunicipioNome(codigoFim, defaults.CodigoMunicipioDescarga, defaults.MunicipioDescarga),
                UfDescarga = FirstNotEmpty(romaneio.uffim, defaults.UfDescarga),
                Rntrc = FirstNotEmpty(JsonText(preferencias, "rntrc", "RNTRC"), defaults.Rntrc),
                Placa = FirstNotEmpty(JsonText(preferencias, "placaVeiculo", "placa"), defaults.Placa),
                Renavam = FirstNotEmpty(JsonText(preferencias, "renavam", "Renavam"), defaults.Renavam),
                TaraKg = FirstNotEmpty(JsonText(preferencias, "taraKg", "TaraKg"), defaults.TaraKg),
                CapacidadeKg = FirstNotEmpty(JsonText(preferencias, "capacidadeKg", "CapacidadeKg"), defaults.CapacidadeKg),
                CapacidadeM3 = FirstNotEmpty(JsonText(preferencias, "capacidadeM3", "CapacidadeM3"), defaults.CapacidadeM3),
                TipoRodado = FirstNotEmpty(JsonText(preferencias, "tipoRodado", "TipoRodado"), defaults.TipoRodado),
                TipoCarroceria = FirstNotEmpty(JsonText(preferencias, "tipoCarroceria", "TipoCarroceria"), defaults.TipoCarroceria),
                CondutorCpf = FirstNotEmpty(JsonText(preferencias, "condutorDocumento", "cpfCondutor", "cpfMotorista"), defaults.CondutorCpf),
                CondutorNome = FirstNotEmpty(JsonText(preferencias, "condutorNome", "nomeCondutor", "nomeMotorista"), defaults.CondutorNome),
                CnpjResponsavelSeguro = FirstNotEmpty(JsonText(preferencias, "cnpjResponsavelSeguro", "CnpjResponsavelSeguro"), defaults.CnpjResponsavelSeguro),
                NomeSeguradora = FirstNotEmpty(JsonText(preferencias, "nomeSeguradora", "NomeSeguradora"), defaults.NomeSeguradora),
                CnpjSeguradora = FirstNotEmpty(JsonText(preferencias, "cnpjSeguradora", "CnpjSeguradora"), defaults.CnpjSeguradora),
                NumeroApolice = FirstNotEmpty(JsonText(preferencias, "numeroApolice", "NumeroApolice"), defaults.NumeroApolice),
                NumeroAverbacao = FirstNotEmpty(JsonText(preferencias, "numeroAverbacao", "NumeroAverbacao"), defaults.NumeroAverbacao),
                TipoCarga = FirstNotEmpty(JsonText(preferencias, "tipoCarga", "tipoCargaMDFe"), defaults.TipoCarga),
                ProdutoPredominante = FirstNotEmpty(JsonText(preferencias, "produtoPredominante", "produtoPredominanteMDFe"), defaults.ProdutoPredominante),
                NcmProdutoPredominante = FirstNotEmpty(JsonText(preferencias, "ncmProdutoPredominante", "ncmProdutoPredominanteMDFe"), defaults.NcmProdutoPredominante),
                ObservacaoFiscal = FirstNotEmpty(JsonText(preferencias, "observacaoFiscal"), defaults.ObservacaoFiscal),
                ValorCarga = JsonDecimal(romaneio.cargasnapshotjson, "valorCarga", "ValorCarga") ?? defaults.ValorCarga,
                PesoBruto = JsonDecimal(romaneio.cargasnapshotjson, "pesoBruto", "PesoBruto") ?? defaults.PesoBruto,
                ValorContrato = JsonDecimal(romaneio.preferenciasfiscaisjson, "valorFrete", "ValorFrete", "valorServico", "ValorServico", "valorContrato", "ValorContrato") ?? defaults.ValorContrato
            };
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

        private static decimal? JsonDecimal(string json, params string[] names)
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;

            try
            {
                using var document = JsonDocument.Parse(json);
                foreach (var name in names)
                {
                    foreach (var property in document.RootElement.EnumerateObject())
                    {
                        if (string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase) &&
                            property.Value.TryGetDecimal(out var value))
                        {
                            return value;
                        }
                    }
                }
            }
            catch (JsonException)
            {
                return null;
            }

            return null;
        }

        private static int CodigoUf(string uf, int fallback)
        {
            return (uf ?? string.Empty).Trim().ToUpperInvariant() switch
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

        private void GarantirDocumentosOriginarios(
            int mdfeSolicitacaoFiscalId,
            IReadOnlyCollection<Repositorio.Outputs.CTeSaidaMDFeDTO> saidasCte)
        {
            var existentes = (_mdfeDocumentoOriginarioReadRepository.GetAllByMDFeSolicitacaoFiscalId(mdfeSolicitacaoFiscalId)
                    ?? Array.Empty<Repositorio.Outputs.MDFeDocumentoOriginarioDTO>())
                .Select(x => x.chaveacesso ?? string.Empty)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            foreach (var saidaCte in saidasCte)
            {
                if (existentes.Contains(saidaCte.chaveacessocte))
                    continue;

                var documento = new MDFeDocumentoOriginarioFactory(_logger).Create(
                    null,
                    mdfeSolicitacaoFiscalId,
                    null,
                    "CTe",
                    saidaCte.chaveacessocte,
                    JsonSerializer.Serialize(new
                    {
                        saidaCte.id,
                        saidaCte.ctetentativaemissaoid,
                        saidaCte.correlationid,
                        saidaCte.chaveacessocte,
                        saidaCte.snapshothash
                    }));

                _mdfeDocumentoOriginarioWriteRepository.Insert(documento);
                existentes.Add(saidaCte.chaveacessocte);
            }
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
