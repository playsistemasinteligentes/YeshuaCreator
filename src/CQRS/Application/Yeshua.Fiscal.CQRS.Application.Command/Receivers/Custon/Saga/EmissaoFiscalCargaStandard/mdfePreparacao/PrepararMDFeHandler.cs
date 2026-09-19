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
    public partial class PrepararMDFeHandler
    {
        private readonly IMDFeSolicitacaoFiscalReadRepository _mdfeSolicitacaoFiscalReadRepository = default!;
        private readonly IMDFeSolicitacaoFiscalWriteRepository _mdfeSolicitacaoFiscalWriteRepository = default!;
        private readonly IMDFeDocumentoOriginarioReadRepository _mdfeDocumentoOriginarioReadRepository = default!;
        private readonly IMDFeTentativaEmissaoReadRepository _mdfeTentativaEmissaoReadRepository = default!;
        private readonly IMDFeTentativaEmissaoWriteRepository _mdfeTentativaEmissaoWriteRepository = default!;
        private readonly IyInboxWriteRepository _inboxWriteRepository = default!;
        private readonly IEntradaFiscalContingenciaReadRepository _entradaFiscalContingenciaReadRepository = default!;
        private readonly ICertificadoDigitalReadRepository _certificadoDigitalReadRepository = default!;
        private readonly ILogger _logger = default!;

        public PrepararMDFeHandler(
            IMDFeSolicitacaoFiscalReadRepository mdfeSolicitacaoFiscalReadRepository,
            IMDFeSolicitacaoFiscalWriteRepository mdfeSolicitacaoFiscalWriteRepository,
            IMDFeDocumentoOriginarioReadRepository mdfeDocumentoOriginarioReadRepository,
            IMDFeTentativaEmissaoReadRepository mdfeTentativaEmissaoReadRepository,
            IMDFeTentativaEmissaoWriteRepository mdfeTentativaEmissaoWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            IEntradaFiscalContingenciaReadRepository entradaFiscalContingenciaReadRepository,
            ICertificadoDigitalReadRepository certificadoDigitalReadRepository,
            ILogger logger)
        {
            _mdfeSolicitacaoFiscalReadRepository = mdfeSolicitacaoFiscalReadRepository;
            _mdfeSolicitacaoFiscalWriteRepository = mdfeSolicitacaoFiscalWriteRepository;
            _mdfeDocumentoOriginarioReadRepository = mdfeDocumentoOriginarioReadRepository;
            _mdfeTentativaEmissaoReadRepository = mdfeTentativaEmissaoReadRepository;
            _mdfeTentativaEmissaoWriteRepository = mdfeTentativaEmissaoWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _entradaFiscalContingenciaReadRepository = entradaFiscalContingenciaReadRepository;
            _certificadoDigitalReadRepository = certificadoDigitalReadRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var cargaId = saga.EntityId ?? string.Empty;
            var solicitacao = _mdfeSolicitacaoFiscalReadRepository.FirstByCargaId(cargaId);
            if (solicitacao == null || solicitacao.id <= 0)
                throw new InvalidOperationException($"Carga {cargaId}: solicitacao fiscal MDF-e nao encontrada para preparar MDF-e.");

            var chavesCTe = (_mdfeDocumentoOriginarioReadRepository.GetAllByMDFeSolicitacaoFiscalId(solicitacao.id)
                    ?? Array.Empty<Repositorio.Outputs.MDFeDocumentoOriginarioDTO>())
                .Where(x => string.Equals(x.tipodocumento, "CTe", StringComparison.OrdinalIgnoreCase))
                .Select(x => OnlyDigits(x.chaveacesso ?? string.Empty))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.Ordinal)
                .ToList();

            if (chavesCTe.Count == 0)
                throw new InvalidOperationException($"Carga {cargaId}: documentos CT-e originarios nao encontrados para preparar MDF-e.");

            if (chavesCTe.Any(x => x.Length != 44))
                throw new InvalidOperationException($"Carga {cargaId}: existe chave CT-e originaria invalida para MDF-e.");

            var tentativa = _mdfeTentativaEmissaoReadRepository.FirstByMDFeSolicitacaoFiscalId(solicitacao.id);
            var tentativaId = tentativa?.id ?? 0;
            var storageKey = tentativa?.xmlassinadostoragekey ?? string.Empty;
            var xmlHash = tentativa?.xmlhash ?? string.Empty;
            var chave = tentativa?.chaveacesso ?? string.Empty;
            var numero = tentativa?.numero ?? 0;
            var serie = tentativa?.serie ?? 0;

            if (tentativaId <= 0)
            {
                var options = BuildOptions(solicitacao, chavesCTe);
                var certificado = FiscalCertificateResolver.TryResolve(
                    cargaId,
                    _entradaFiscalContingenciaReadRepository,
                    _certificadoDigitalReadRepository);
                if (certificado is not null)
                {
                    FiscalCertificateResolver.ValidateIssuer(certificado, options.CnpjEmitente, $"Solicitacao MDF-e {solicitacao.id}");
                    options = options with
                    {
                        CertificatePath = certificado.CertificatePath,
                        CertificatePassword = certificado.Password
                    };
                }
                var prepared = MdfeRecepcaoSincHomologacaoClient.Preparar(options);
                var storage = SefazFiscalDocumentStore.SalvarXmlResposta("mdfe", "preparacao", prepared.Chave, prepared.XmlMDFe);

                var entity = new MDFeTentativaEmissaoFactory(_logger).Create(
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

                _mdfeTentativaEmissaoWriteRepository.Insert(entity);
                if (!entity.Id.HasValue || entity.Id.Value <= 0)
                    throw new InvalidOperationException($"Carga {cargaId}: tentativa MDF-e nao recebeu Id apos insert.");

                tentativaId = entity.Id.Value;
                storageKey = storage.Path;
                xmlHash = storage.Sha256;
                chave = prepared.Chave;
                numero = prepared.Numero ?? 0;
                serie = prepared.Serie ?? 0;
            }

            if (solicitacao.status < 2)
                _mdfeSolicitacaoFiscalWriteRepository.UpdateStatus(solicitacao.id, 2);

            _inboxWriteRepository.Insert(FiscalSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "fiscal.mdfe.preparado",
                new
                {
                    origem = "Fiscal",
                    modo = "xml-mdfe-assinado-preparado",
                    entityId = saga.EntityId,
                    mdfeSolicitacaoFiscalId = solicitacao.id,
                    mdfeTentativaEmissaoId = tentativaId,
                    chave,
                    numero,
                    serie,
                    quantidadeCTes = chavesCTe.Count,
                    xmlAssinadoStorageKey = storageKey,
                    xmlHash
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Fiscal {saga.EntityId}: MDF-e preparado.");
        }

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

        private static MdfeRecepcaoSincOptions BuildOptions(
            Repositorio.Outputs.MDFeSolicitacaoFiscalDTO solicitacao,
            IReadOnlyCollection<string> chavesCTe)
        {
            var defaults = MdfeRecepcaoSincOptions.FromEnvironment();
            var snapshot = solicitacao.transportesnapshotjson ?? string.Empty;

            return defaults with
            {
                Ambiente = solicitacao.ambiente,
                CodigoUf = JsonInt(snapshot, "CodigoUf", "codigoUf") ?? defaults.CodigoUf,
                CnpjEmitente = FirstNotEmpty(JsonText(snapshot, "CnpjEmitente", "cnpjEmitente"), defaults.CnpjEmitente),
                RazaoSocial = FirstNotEmpty(JsonText(snapshot, "RazaoSocial", "razaoSocial"), defaults.RazaoSocial),
                NomeFantasia = FirstNotEmpty(JsonText(snapshot, "NomeFantasia", "nomeFantasia"), defaults.NomeFantasia),
                InscricaoEstadual = FirstNotEmpty(JsonText(snapshot, "InscricaoEstadual", "inscricaoEstadual"), defaults.InscricaoEstadual),
                Endereco = FirstNotEmpty(JsonText(snapshot, "Endereco", "endereco"), defaults.Endereco),
                NumeroEndereco = FirstNotEmpty(JsonText(snapshot, "NumeroEndereco", "numeroEndereco"), defaults.NumeroEndereco),
                Bairro = FirstNotEmpty(JsonText(snapshot, "Bairro", "bairro"), defaults.Bairro),
                Cep = FirstNotEmpty(JsonText(snapshot, "Cep", "cep"), defaults.Cep),
                CodigoMunicipioEmitente = FirstNotEmpty(JsonText(snapshot, "CodigoMunicipioEmitente", "codigoMunicipioEmitente"), defaults.CodigoMunicipioEmitente),
                MunicipioEmitente = FirstNotEmpty(JsonText(snapshot, "MunicipioEmitente", "municipioEmitente"), defaults.MunicipioEmitente),
                UfEmitente = FirstNotEmpty(JsonText(snapshot, "UfEmitente", "ufEmitente"), defaults.UfEmitente),
                UfInicio = FirstNotEmpty(JsonText(snapshot, "UfInicio", "ufInicio"), FirstNotEmpty(solicitacao.ufcarregamento, defaults.UfInicio)),
                CodigoMunicipioCarregamento = FirstNotEmpty(JsonText(snapshot, "CodigoMunicipioCarregamento", "codigoMunicipioCarregamento"), defaults.CodigoMunicipioCarregamento),
                MunicipioCarregamento = FirstNotEmpty(JsonText(snapshot, "MunicipioCarregamento", "municipioCarregamento"), defaults.MunicipioCarregamento),
                CodigoMunicipioDescarga = FirstNotEmpty(JsonText(snapshot, "CodigoMunicipioDescarga", "codigoMunicipioDescarga"), defaults.CodigoMunicipioDescarga),
                MunicipioDescarga = FirstNotEmpty(JsonText(snapshot, "MunicipioDescarga", "municipioDescarga"), defaults.MunicipioDescarga),
                UfDescarga = FirstNotEmpty(solicitacao.ufdescarregamento, defaults.UfDescarga),
                Placa = FirstNotEmpty(solicitacao.placaveiculo, defaults.Placa),
                CondutorCpf = FirstNotEmpty(solicitacao.condutordocumento, defaults.CondutorCpf),
                CondutorNome = FirstNotEmpty(JsonText(snapshot, "condutorNome", "CondutorNome"), defaults.CondutorNome),
                Rntrc = FirstNotEmpty(JsonText(snapshot, "Rntrc", "rntrc", "RNTRC"), defaults.Rntrc),
                Renavam = FirstNotEmpty(JsonText(snapshot, "Renavam", "renavam"), defaults.Renavam),
                TaraKg = FirstNotEmpty(JsonText(snapshot, "TaraKg", "taraKg"), defaults.TaraKg),
                CapacidadeKg = FirstNotEmpty(JsonText(snapshot, "CapacidadeKg", "capacidadeKg"), defaults.CapacidadeKg),
                CapacidadeM3 = FirstNotEmpty(JsonText(snapshot, "CapacidadeM3", "capacidadeM3"), defaults.CapacidadeM3),
                TipoRodado = FirstNotEmpty(JsonText(snapshot, "TipoRodado", "tipoRodado"), defaults.TipoRodado),
                TipoCarroceria = FirstNotEmpty(JsonText(snapshot, "TipoCarroceria", "tipoCarroceria"), defaults.TipoCarroceria),
                TipoCarga = FirstNotEmpty(JsonText(snapshot, "TipoCarga", "tipoCarga"), defaults.TipoCarga),
                ProdutoPredominante = FirstNotEmpty(JsonText(snapshot, "ProdutoPredominante", "produtoPredominante"), defaults.ProdutoPredominante),
                NcmProdutoPredominante = FirstNotEmpty(JsonText(snapshot, "NcmProdutoPredominante", "ncmProdutoPredominante"), defaults.NcmProdutoPredominante),
                ObservacaoFiscal = FirstNotEmpty(JsonText(snapshot, "ObservacaoFiscal", "observacaoFiscal"), defaults.ObservacaoFiscal),
                ValorCarga = JsonDecimal(snapshot, "ValorCarga", "valorCarga") ?? defaults.ValorCarga,
                PesoBruto = JsonDecimal(snapshot, "PesoBruto", "pesoBruto") ?? defaults.PesoBruto,
                ValorContrato = JsonDecimal(snapshot, "ValorContrato", "valorContrato") ?? defaults.ValorContrato,
                ChavesCTe = chavesCTe.ToArray()
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
            }
            catch (JsonException)
            {
                return string.Empty;
            }

            return string.Empty;
        }

        private static int? JsonInt(string json, params string[] names)
        {
            var text = JsonText(json, names);
            return int.TryParse(text, out var value) ? value : null;
        }

        private static decimal? JsonDecimal(string json, params string[] names)
        {
            var text = JsonText(json, names);
            return decimal.TryParse(text, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out var value)
                ? value
                : null;
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

        private static string FirstNotEmpty(string first, string second)
            => string.IsNullOrWhiteSpace(first) ? second ?? string.Empty : first;
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
