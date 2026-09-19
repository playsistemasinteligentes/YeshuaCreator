using Repositorio.Outputs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Command.Receivers
{
    internal static class FiscalContingenciaPayload
    {
        private static readonly HashSet<string> TiposAgrupamentoCTeSuportados = new(StringComparer.OrdinalIgnoreCase)
        {
            "um_cte_por_nfe",
            "agrupar_por_destinatario",
            "cte_unico_da_carga"
        };

        private static readonly HashSet<string> EstrategiasRateioFreteSuportadas = new(StringComparer.OrdinalIgnoreCase)
        {
            "proporcional_valor_documento",
            "proporcional_peso_bruto"
        };

        public static int EntradaId(string payload)
            => Int(payload, "entradaFiscalContingenciaId", "EntradaFiscalContingenciaId");

        public static string Text(string? json, params string[] names)
        {
            if (string.IsNullOrWhiteSpace(json))
                return string.Empty;

            try
            {
                using var document = JsonDocument.Parse(json);
                return Text(document.RootElement, names);
            }
            catch (JsonException)
            {
                return string.Empty;
            }
        }

        public static int Int(string? json, params string[] names)
        {
            if (string.IsNullOrWhiteSpace(json))
                return 0;

            try
            {
                using var document = JsonDocument.Parse(json);
                foreach (var name in names)
                {
                    if (!TryGetProperty(document.RootElement, name, out var value))
                        continue;

                    if (value.ValueKind == JsonValueKind.Number && value.TryGetInt32(out var intValue))
                        return intValue;

                    if (value.ValueKind == JsonValueKind.String && int.TryParse(value.GetString(), out intValue))
                        return intValue;
                }
            }
            catch (JsonException)
            {
            }

            return 0;
        }

        public static string ComplementoText(string payload, params string[] names)
        {
            var complemento = Text(payload, "dadosComplementaresJson", "DadosComplementaresJson");
            return Text(complemento, names);
        }

        public static string ComplementoJson(EntradaFiscalContingenciaDTO entrada)
        {
            var complemento = Text(entrada.snapshotjson, "dadosComplementaresJson", "DadosComplementaresJson");
            if (!string.IsNullOrWhiteSpace(complemento))
                return complemento;

            complemento = Text(entrada.snapshotjson, "preferenciasFiscaisJson", "PreferenciasFiscaisJson");
            return string.IsNullOrWhiteSpace(complemento) ? "{}" : complemento;
        }

        public static decimal Number(string? json, params string[] names)
        {
            if (string.IsNullOrWhiteSpace(json))
                return 0m;

            try
            {
                using var document = JsonDocument.Parse(json);
                foreach (var name in names)
                {
                    if (!TryGetProperty(document.RootElement, name, out var value))
                        continue;

                    if (value.ValueKind == JsonValueKind.Number && value.TryGetDecimal(out var decimalValue))
                        return decimalValue;

                    if (value.ValueKind == JsonValueKind.String && TryParseDecimal(value.GetString(), out decimalValue))
                        return decimalValue;
                }
            }
            catch (JsonException)
            {
            }

            return 0m;
        }

        public static List<string> Pendencias(EntradaFiscalContingenciaDTO entrada, IEnumerable<NFeProdutoSnapshotDTO> documentos)
        {
            var documentosLista = documentos as IReadOnlyCollection<NFeProdutoSnapshotDTO> ?? documentos.ToArray();
            return FiscalEmissionPlanCompiler.Compile(entrada, documentosLista).Pendencias.ToList();
        }

        internal static List<string> BuildPendencias(
            EntradaFiscalContingenciaDTO entrada,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> documentosLista,
            string? certificadoDocumentoTitular = null,
            bool certificadoFoiVerificado = false)
        {
            var pendencias = new List<string>();
            var complemento = ComplementoJson(entrada);

            Require(pendencias, entrada.cargaid, "CargaId");
            Require(pendencias, Value(entrada.emitentefiscaldocumento, complemento, "emitenteFiscalDocumento", "cnpjEmitente", "emitenteDocumento"), "EmitenteFiscalDocumento");
            Require(pendencias, Value(entrada.tomadordocumento, complemento, "tomadorDocumento", "cnpjTomador"), "TomadorDocumento");
            Require(pendencias, Value(entrada.transportadordocumento, complemento, "transportadorDocumento", "cnpjTransportador"), "TransportadorDocumento");
            Require(pendencias, Value(entrada.remetentedocumento, complemento, "remetenteDocumento", "cnpjRemetente"), "RemetenteDocumento");
            Require(pendencias, Value(entrada.destinatariodocumento, complemento, "destinatarioDocumento", "cnpjDestinatario"), "DestinatarioDocumento");
            ValidarParticipanteCTe(pendencias, complemento, "remetente", "Remetente");
            ValidarParticipanteCTe(pendencias, complemento, "destinatario", "Destinatario");

            var tomadorDocumento = Digits(Value(entrada.tomadordocumento, complemento, "tomadorDocumento", "cnpjTomador"));
            var remetenteDocumento = Digits(Value(entrada.remetentedocumento, complemento, "remetenteDocumento", "cnpjRemetente"));
            var destinatarioDocumento = Digits(Value(entrada.destinatariodocumento, complemento, "destinatarioDocumento", "cnpjDestinatario"));
            if (!string.IsNullOrWhiteSpace(tomadorDocumento) &&
                !string.Equals(tomadorDocumento, remetenteDocumento, StringComparison.Ordinal) &&
                !string.Equals(tomadorDocumento, destinatarioDocumento, StringComparison.Ordinal))
            {
                pendencias.Add("TomadorOutrosRequerCadastroCompletoToma4");
            }

            Require(pendencias, Value(entrada.rntrc, complemento, "rntrc", "RNTRC"), "RNTRC");
            Require(pendencias, Value(entrada.placaveiculo, complemento, "placaVeiculo", "placa"), "PlacaVeiculo");
            Require(pendencias, Value(entrada.ufveiculo, complemento, "ufVeiculo", "UFVeiculo"), "UFVeiculo");
            Require(pendencias, Value(entrada.condutordocumento, complemento, "condutorDocumento", "cpfMotorista", "cpfCondutor"), "CondutorDocumento");
            Require(pendencias, Value(entrada.condutornome, complemento, "condutorNome", "nomeMotorista", "nomeCondutor"), "CondutorNome");
            Require(pendencias, Value(entrada.ufinicio, complemento, "ufInicio", "UFInicio"), "UFInicio");
            Require(pendencias, Value(entrada.uffim, complemento, "ufFim", "UFFim"), "UFFim");
            Require(pendencias, Value(entrada.municipioiniciocodigoibge, complemento, "municipioInicioCodigoIbge", "codigoMunicipioInicio"), "MunicipioInicioCodigoIbge");
            Require(pendencias, Value(entrada.municipiofimcodigoibge, complemento, "municipioFimCodigoIbge", "codigoMunicipioFim"), "MunicipioFimCodigoIbge");

            if (entrada.certificadodigitalid <= 0)
                pendencias.Add("CertificadoDigital");

            var emitenteFiscalDocumento = Digits(Value(
                entrada.emitentefiscaldocumento,
                complemento,
                "emitenteFiscalDocumento",
                "cnpjEmitente",
                "emitenteDocumento"));
            var documentoCertificado = Digits(certificadoDocumentoTitular);
            if (certificadoFoiVerificado && string.IsNullOrWhiteSpace(documentoCertificado))
            {
                pendencias.Add("CertificadoDigitalIncompativelComEmitente");
            }
            else if (!string.IsNullOrWhiteSpace(documentoCertificado) &&
                     !MesmaBaseCnpj(emitenteFiscalDocumento, documentoCertificado))
            {
                pendencias.Add("CertificadoDigitalIncompativelComEmitente");
            }

            if (string.IsNullOrWhiteSpace(complemento) || complemento == "{}")
            {
                pendencias.Add("DadosComplementaresJson");
            }
            else
            {
                var tipoAgrupamento = Text(complemento, "tipoAgrupamentoCTe", "tipoAgrupamentoCte");
                var estrategiaRateio = Text(complemento, "estrategiaRateioFrete");
                var tipoCargaMdfe = Text(complemento, "tipoCargaMDFe", "tipoCarga");
                var produtoPredominanteMdfe = Text(complemento, "produtoPredominanteMDFe", "produtoPredominante");
                var ncmProdutoPredominanteMdfe = Text(complemento, "ncmProdutoPredominanteMDFe", "ncmProdutoPredominante");
                var defaultsCte = CteRecepcaoSincV4Options.FromEnvironment();
                var ufEmitente = FirstNonEmpty(Text(complemento, "emitenteUf", "ufEmitente"), defaultsCte.UfEmitente);
                var inscricaoEstadualEmitente = FirstNonEmpty(
                    Text(complemento, "emitenteInscricaoEstadual", "inscricaoEstadualEmitente"),
                    defaultsCte.InscricaoEstadual);
                var municipioEmitenteCodigoIbge = FirstNonEmpty(
                    Text(complemento, "emitenteMunicipioCodigoIbge", "municipioEmitenteCodigoIbge"),
                    defaultsCte.MunicipioEmitenteCodigoIbge);
                var ufInicio = Value(entrada.ufinicio, complemento, "ufInicio", "UFInicio");
                var ufFim = Value(entrada.uffim, complemento, "ufFim", "UFFim");
                var cfop = FirstNonEmpty(Text(complemento, "cfop", "CFOP"), CteCfopPolicy.Resolve(ufEmitente, ufInicio, ufFim));

                Require(pendencias, tipoAgrupamento, "TipoAgrupamentoCTe");
                Require(pendencias, estrategiaRateio, "EstrategiaRateioFrete");
                Require(pendencias, tipoCargaMdfe, "TipoCargaMDFe");
                Require(pendencias, produtoPredominanteMdfe, "ProdutoPredominanteMDFe");
                Require(pendencias, ncmProdutoPredominanteMdfe, "NcmProdutoPredominanteMDFe");
                Require(pendencias, ufEmitente, "UFEmitente");
                Require(pendencias, inscricaoEstadualEmitente, "InscricaoEstadualEmitente");
                Require(pendencias, municipioEmitenteCodigoIbge, "MunicipioEmitenteCodigoIbge");
                Require(pendencias, cfop, "CFOP");

                if (CteUfPolicy.ResolveCode(ufEmitente) == 0)
                    pendencias.Add("UFEmitenteInvalida");
                else if (!CteUfPolicy.MunicipioPertenceAoEstado(municipioEmitenteCodigoIbge, ufEmitente))
                    pendencias.Add("UFEmitenteDivergeMunicipioEmitente");

                if (Number(complemento, "valorFrete", "valorServico") <= 0m)
                    pendencias.Add("ValorFrete");

                if (!string.IsNullOrWhiteSpace(tipoCargaMdfe) &&
                    (tipoCargaMdfe.Length != 2 || !tipoCargaMdfe.All(char.IsDigit)))
                {
                    pendencias.Add("TipoCargaMDFeInvalido");
                }

                if (!string.IsNullOrWhiteSpace(ncmProdutoPredominanteMdfe) &&
                    (ncmProdutoPredominanteMdfe.Length != 8 || !ncmProdutoPredominanteMdfe.All(char.IsDigit)))
                {
                    pendencias.Add("NcmProdutoPredominanteMDFeInvalido");
                }

                if (cfop.Length != 4 || !cfop.All(char.IsDigit))
                    pendencias.Add("CFOPInvalido");

                ValidarParametrosDoPlano(pendencias, entrada, documentosLista, tipoAgrupamento, estrategiaRateio);
            }

            if (!documentosLista.Any())
                pendencias.Add("DocumentosOriginarios");

            return pendencias.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }

        public static string SummaryJson(EntradaFiscalContingenciaDTO entrada, IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos)
        {
            var complemento = ComplementoJson(entrada);

            return JsonSerializer.Serialize(new
            {
                entrada.id,
                entrada.correlationid,
                entrada.cargaid,
                entrada.tiposolicitante,
                entrada.ambiente,
                rntrc = Value(entrada.rntrc, complemento, "rntrc", "RNTRC"),
                placaveiculo = Value(entrada.placaveiculo, complemento, "placaVeiculo", "placa"),
                ufveiculo = Value(entrada.ufveiculo, complemento, "ufVeiculo", "UFVeiculo"),
                condutordocumento = Value(entrada.condutordocumento, complemento, "condutorDocumento", "cpfMotorista", "cpfCondutor"),
                condutornome = Value(entrada.condutornome, complemento, "condutorNome", "nomeMotorista", "nomeCondutor"),
                ufinicio = Value(entrada.ufinicio, complemento, "ufInicio", "UFInicio"),
                uffim = Value(entrada.uffim, complemento, "ufFim", "UFFim"),
                municipioiniciocodigoibge = Value(entrada.municipioiniciocodigoibge, complemento, "municipioInicioCodigoIbge", "codigoMunicipioInicio"),
                municipiofimcodigoibge = Value(entrada.municipiofimcodigoibge, complemento, "municipioFimCodigoIbge", "codigoMunicipioFim"),
                quantidadeDocumentos = documentos.Count,
                valorCarga = documentos.Sum(x => x.valordocumento),
                pesoBruto = documentos.Sum(x => x.pesobruto),
                volume = documentos.Sum(x => x.volume),
                valorFrete = Number(complemento, "valorFrete", "valorServico"),
                tipoAgrupamentoCTe = Text(complemento, "tipoAgrupamentoCTe", "tipoAgrupamentoCte"),
                estrategiaRateioFrete = Text(complemento, "estrategiaRateioFrete"),
                origemRotaFiscal = Text(complemento, "origemRotaFiscal"),
                tipoCargaMDFe = Text(complemento, "tipoCargaMDFe", "tipoCarga"),
                produtoPredominanteMDFe = Text(complemento, "produtoPredominanteMDFe", "produtoPredominante"),
                ncmProdutoPredominanteMDFe = Text(complemento, "ncmProdutoPredominanteMDFe", "ncmProdutoPredominante"),
                observacaoFiscal = Text(complemento, "observacaoFiscal"),
                dadosComplementaresJson = complemento,
                documentos = documentos.Select(x => new
                {
                    x.chaveacesso,
                    x.emitentedocumento,
                    x.destinatariodocumento,
                    x.uforigem,
                    x.ufdestino,
                    x.municipioorigemcodigoibge,
                    x.municipiodestinocodigoibge,
                    x.valordocumento,
                    x.pesobruto,
                    x.volume
                })
            });
        }

        public static string PlanoEmissaoJson(EntradaFiscalContingenciaDTO entrada, IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos)
            => FiscalEmissionPlanCompiler.Compile(entrada, documentos).PlanJson;

        internal static string BuildPlanoEmissaoJson(
            EntradaFiscalContingenciaDTO entrada,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos,
            IReadOnlyCollection<string> pendencias,
            string rulesVersion)
        {
            var complemento = ComplementoJson(entrada);
            var tipoAgrupamento = FirstNonEmpty(
                Text(complemento, "tipoAgrupamentoCTe", "tipoAgrupamentoCte"),
                "um_cte_por_nfe");
            var estrategiaRateio = FirstNonEmpty(
                Text(complemento, "estrategiaRateioFrete"),
                "proporcional_valor_documento");
            var valorFrete = Number(complemento, "valorFrete", "valorServico");
            var defaultsCte = CteRecepcaoSincV4Options.FromEnvironment();
            var defaultsMdfe = MdfeRecepcaoSincOptions.FromEnvironment();
            var ufEmitente = FirstNonEmpty(Text(complemento, "emitenteUf", "ufEmitente"), defaultsCte.UfEmitente);
            var ufInicio = Value(entrada.ufinicio, complemento, "ufInicio", "UFInicio");
            var ufFim = Value(entrada.uffim, complemento, "ufFim", "UFFim");
            var cfopCalculado = CteCfopPolicy.Resolve(ufEmitente, ufInicio, ufFim);
            var cfop = FirstNonEmpty(Text(complemento, "cfop", "CFOP"), cfopCalculado);
            var tipoCTe = Int(complemento, "tipoCTe", "TipoCTe");
            var tipoServico = Int(complemento, "tipoServico", "TipoServico");
            var modal = Int(complemento, "modal", "Modal");
            if (modal <= 0) modal = 1;
            var globalizado = Int(complemento, "globalizado", "Globalizado");
            var emitenteRazaoSocial = FirstNonEmpty(Text(complemento, "emitenteRazaoSocial", "razaoSocialEmitente"), defaultsCte.RazaoSocial);
            var emitenteNomeFantasia = FirstNonEmpty(Text(complemento, "emitenteNomeFantasia", "nomeFantasiaEmitente"), defaultsCte.NomeFantasiaEmitente);
            var emitenteInscricaoEstadual = FirstNonEmpty(Text(complemento, "emitenteInscricaoEstadual", "inscricaoEstadualEmitente"), defaultsCte.InscricaoEstadual);
            var emitenteCrt = Int(complemento, "emitenteCrt", "crtEmitente");
            if (emitenteCrt <= 0) emitenteCrt = defaultsCte.CrtEmitente;
            var emitenteLogradouro = FirstNonEmpty(Text(complemento, "emitenteLogradouro", "logradouroEmitente"), defaultsCte.LogradouroEmitente);
            var emitenteNumero = FirstNonEmpty(Text(complemento, "emitenteNumero", "numeroEnderecoEmitente"), defaultsCte.NumeroEnderecoEmitente);
            var emitenteBairro = FirstNonEmpty(Text(complemento, "emitenteBairro", "bairroEmitente"), defaultsCte.BairroEmitente);
            var emitenteCep = FirstNonEmpty(Text(complemento, "emitenteCep", "cepEmitente"), defaultsCte.CepEmitente);
            var emitenteMunicipioCodigoIbge = FirstNonEmpty(Text(complemento, "emitenteMunicipioCodigoIbge", "municipioEmitenteCodigoIbge"), defaultsCte.MunicipioEmitenteCodigoIbge);
            var emitenteMunicipioNome = FirstNonEmpty(Text(complemento, "emitenteMunicipioNome", "municipioEmitenteNome"), defaultsCte.MunicipioEmitenteNome);
            var renavam = FirstNonEmpty(Text(complemento, "renavam", "Renavam"), defaultsMdfe.Renavam);
            var taraKg = FirstNonEmpty(Text(complemento, "taraKg", "TaraKg"), defaultsMdfe.TaraKg);
            var capacidadeKg = FirstNonEmpty(Text(complemento, "capacidadeKg", "CapacidadeKg"), defaultsMdfe.CapacidadeKg);
            var capacidadeM3 = FirstNonEmpty(Text(complemento, "capacidadeM3", "CapacidadeM3"), defaultsMdfe.CapacidadeM3);
            var tipoRodado = FirstNonEmpty(Text(complemento, "tipoRodado", "TipoRodado"), defaultsMdfe.TipoRodado);
            var tipoCarroceria = FirstNonEmpty(Text(complemento, "tipoCarroceria", "TipoCarroceria"), defaultsMdfe.TipoCarroceria);
            var cnpjResponsavelSeguro = FirstNonEmpty(Text(complemento, "cnpjResponsavelSeguro", "CnpjResponsavelSeguro"), defaultsMdfe.CnpjResponsavelSeguro);
            var nomeSeguradora = FirstNonEmpty(Text(complemento, "nomeSeguradora", "NomeSeguradora"), defaultsMdfe.NomeSeguradora);
            var cnpjSeguradora = FirstNonEmpty(Text(complemento, "cnpjSeguradora", "CnpjSeguradora"), defaultsMdfe.CnpjSeguradora);
            var numeroApolice = FirstNonEmpty(Text(complemento, "numeroApolice", "NumeroApolice"), defaultsMdfe.NumeroApolice);
            var numeroAverbacao = FirstNonEmpty(Text(complemento, "numeroAverbacao", "NumeroAverbacao"), defaultsMdfe.NumeroAverbacao);
            var preferenciasEfetivasJson = BuildEffectivePreferencesJson(complemento, new Dictionary<string, object?>
            {
                ["emitenteUf"] = ufEmitente,
                ["cfop"] = cfop,
                ["tipoCTe"] = tipoCTe,
                ["tipoServico"] = tipoServico,
                ["modal"] = modal,
                ["globalizado"] = globalizado,
                ["emitenteRazaoSocial"] = emitenteRazaoSocial,
                ["emitenteNomeFantasia"] = emitenteNomeFantasia,
                ["emitenteInscricaoEstadual"] = emitenteInscricaoEstadual,
                ["emitenteCrt"] = emitenteCrt,
                ["emitenteLogradouro"] = emitenteLogradouro,
                ["emitenteNumero"] = emitenteNumero,
                ["emitenteBairro"] = emitenteBairro,
                ["emitenteCep"] = emitenteCep,
                ["emitenteMunicipioCodigoIbge"] = emitenteMunicipioCodigoIbge,
                ["emitenteMunicipioNome"] = emitenteMunicipioNome,
                ["renavam"] = renavam,
                ["taraKg"] = taraKg,
                ["capacidadeKg"] = capacidadeKg,
                ["capacidadeM3"] = capacidadeM3,
                ["tipoRodado"] = tipoRodado,
                ["tipoCarroceria"] = tipoCarroceria,
                ["cnpjResponsavelSeguro"] = cnpjResponsavelSeguro,
                ["nomeSeguradora"] = nomeSeguradora,
                ["cnpjSeguradora"] = cnpjSeguradora,
                ["numeroApolice"] = numeroApolice,
                ["numeroAverbacao"] = numeroAverbacao
            });
            var grupos = AgruparDocumentos(entrada, documentos, tipoAgrupamento);
            var totalBaseRateio = grupos.Sum(x => BaseRateio(x.Documentos, estrategiaRateio));
            var valorFreteRateado = 0m;
            var podeRatear = valorFrete > 0m &&
                totalBaseRateio > 0m &&
                EstrategiasRateioFreteSuportadas.Contains(estrategiaRateio);
            var ctesPrevistos = grupos.Select((grupo, indice) =>
            {
                var baseRateio = BaseRateio(grupo.Documentos, estrategiaRateio);
                var freteDoGrupo = !podeRatear
                    ? 0m
                    : indice == grupos.Count - 1
                        ? Math.Round(valorFrete - valorFreteRateado, 2, MidpointRounding.AwayFromZero)
                        : RatearValorFrete(valorFrete, estrategiaRateio, baseRateio, totalBaseRateio);
                valorFreteRateado += freteDoGrupo;

                return new
                {
                    grupo.Chave,
                    grupo.Descricao,
                    quantidadeDocumentos = grupo.Documentos.Count,
                    valorDocumentos = grupo.Documentos.Sum(x => x.valordocumento),
                    pesoBruto = grupo.Documentos.Sum(x => x.pesobruto),
                    valorFreteRateado = freteDoGrupo,
                    documentos = grupo.Documentos.Select(x => new
                    {
                        x.chaveacesso,
                        x.emitentedocumento,
                        x.destinatariodocumento,
                        x.uforigem,
                        x.ufdestino,
                        x.valordocumento,
                        x.pesobruto
                    }).ToArray()
                };
            }).ToArray();
            return JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.plano-emissao",
                rulesVersion,
                entrada.id,
                entrada.correlationid,
                entrada.cargaid,
                entrada.tiposolicitante,
                entrada.ambiente,
                certificadoDigitalId = entrada.certificadodigitalid,
                emitenteFiscalDocumento = Value(entrada.emitentefiscaldocumento, complemento, "emitenteFiscalDocumento", "cnpjEmitente", "emitenteDocumento"),
                tomadorDocumento = Value(entrada.tomadordocumento, complemento, "tomadorDocumento", "cnpjTomador"),
                transportadorDocumento = Value(entrada.transportadordocumento, complemento, "transportadorDocumento", "cnpjTransportador"),
                remetenteDocumento = Value(entrada.remetentedocumento, complemento, "remetenteDocumento", "cnpjRemetente"),
                destinatarioDocumento = Value(entrada.destinatariodocumento, complemento, "destinatarioDocumento", "cnpjDestinatario"),
                rntrc = Value(entrada.rntrc, complemento, "rntrc", "RNTRC"),
                placaveiculo = Value(entrada.placaveiculo, complemento, "placaVeiculo", "placa"),
                ufveiculo = Value(entrada.ufveiculo, complemento, "ufVeiculo", "UFVeiculo"),
                condutordocumento = Value(entrada.condutordocumento, complemento, "condutorDocumento", "cpfMotorista", "cpfCondutor"),
                condutornome = Value(entrada.condutornome, complemento, "condutorNome", "nomeMotorista", "nomeCondutor"),
                ufinicio = Value(entrada.ufinicio, complemento, "ufInicio", "UFInicio"),
                uffim = Value(entrada.uffim, complemento, "ufFim", "UFFim"),
                municipioiniciocodigoibge = Value(entrada.municipioiniciocodigoibge, complemento, "municipioInicioCodigoIbge", "codigoMunicipioInicio"),
                municipiofimcodigoibge = Value(entrada.municipiofimcodigoibge, complemento, "municipioFimCodigoIbge", "codigoMunicipioFim"),
                quantidadeDocumentos = documentos.Count,
                valorCarga = documentos.Sum(x => x.valordocumento),
                pesoBruto = documentos.Sum(x => x.pesobruto),
                volume = documentos.Sum(x => x.volume),
                valorFrete,
                tipoAgrupamentoCTe = tipoAgrupamento,
                estrategiaRateioFrete = estrategiaRateio,
                cfop,
                tipoCTe,
                tipoServico,
                modal,
                globalizado,
                origemRotaFiscal = Text(complemento, "origemRotaFiscal"),
                observacaoFiscal = Text(complemento, "observacaoFiscal"),
                parametrosFiscaisEfetivos = new
                {
                    emitenteUf = ufEmitente,
                    cfop,
                    cfopOrigem = string.IsNullOrWhiteSpace(Text(complemento, "cfop", "CFOP")) ? "calculado" : "informado",
                    tipoCTe,
                    tipoServico,
                    modal,
                    globalizado,
                    emitenteRazaoSocial,
                    emitenteNomeFantasia,
                    emitenteInscricaoEstadual,
                    emitenteCrt,
                    emitenteLogradouro,
                    emitenteNumero,
                    emitenteBairro,
                    emitenteCep,
                    emitenteMunicipioCodigoIbge,
                    emitenteMunicipioNome,
                    renavam,
                    taraKg,
                    capacidadeKg,
                    capacidadeM3,
                    tipoRodado,
                    tipoCarroceria,
                    cnpjResponsavelSeguro,
                    nomeSeguradora,
                    cnpjSeguradora,
                    numeroApolice,
                    numeroAverbacao
                },
                dadosComplementaresJson = preferenciasEfetivasJson,
                preferenciasFiscaisJson = preferenciasEfetivasJson,
                pendencias,
                ctesPrevistos,
                mdfesPrevistos = new[]
                {
                    new
                    {
                        chave = entrada.cargaid,
                        descricao = "MDF-e da carga",
                        emitenteDocumento = Value(entrada.emitentefiscaldocumento, complemento, "emitenteFiscalDocumento", "cnpjEmitente", "emitenteDocumento"),
                        emitenteRazaoSocial,
                        emitenteNomeFantasia,
                        emitenteInscricaoEstadual,
                        emitenteUf = ufEmitente,
                        emitenteMunicipioCodigoIbge,
                        emitenteMunicipioNome,
                        quantidadeCTes = ctesPrevistos.Length,
                        ctes = ctesPrevistos.Select(x => x.Chave).ToArray(),
                        ufinicio = Value(entrada.ufinicio, complemento, "ufInicio", "UFInicio"),
                        uffim = Value(entrada.uffim, complemento, "ufFim", "UFFim"),
                        municipioiniciocodigoibge = Value(entrada.municipioiniciocodigoibge, complemento, "municipioInicioCodigoIbge", "codigoMunicipioInicio"),
                        municipiofimcodigoibge = Value(entrada.municipiofimcodigoibge, complemento, "municipioFimCodigoIbge", "codigoMunicipioFim"),
                        rntrc = Value(entrada.rntrc, complemento, "rntrc", "RNTRC"),
                        placaveiculo = Value(entrada.placaveiculo, complemento, "placaVeiculo", "placa"),
                        condutordocumento = Value(entrada.condutordocumento, complemento, "condutorDocumento", "cpfMotorista", "cpfCondutor"),
                        condutornome = Value(entrada.condutornome, complemento, "condutorNome", "nomeMotorista", "nomeCondutor"),
                        tipoCarga = Text(complemento, "tipoCargaMDFe", "tipoCarga"),
                        produtoPredominante = Text(complemento, "produtoPredominanteMDFe", "produtoPredominante"),
                        ncmProdutoPredominante = Text(complemento, "ncmProdutoPredominanteMDFe", "ncmProdutoPredominante"),
                        valorFrete,
                        valorCarga = documentos.Sum(x => x.valordocumento),
                        pesoBruto = documentos.Sum(x => x.pesobruto),
                        observacaoFiscal = Text(complemento, "observacaoFiscal")
                    }
                }
            });
        }

        private static string BuildEffectivePreferencesJson(
            string? sourceJson,
            IReadOnlyDictionary<string, object?> effectiveValues)
        {
            JsonObject result;
            try
            {
                result = string.IsNullOrWhiteSpace(sourceJson)
                    ? new JsonObject()
                    : JsonNode.Parse(sourceJson) as JsonObject ?? new JsonObject();
            }
            catch (JsonException)
            {
                result = new JsonObject();
            }

            foreach (var item in effectiveValues)
                result[item.Key] = JsonSerializer.SerializeToNode(item.Value);

            return result.ToJsonString();
        }

        private static string Text(JsonElement root, params string[] names)
        {
            foreach (var name in names)
            {
                if (!TryGetProperty(root, name, out var value))
                    continue;

                if (value.ValueKind == JsonValueKind.String)
                    return value.GetString() ?? string.Empty;

                if (value.ValueKind is JsonValueKind.Number or JsonValueKind.True or JsonValueKind.False)
                    return value.ToString();

                if (value.ValueKind is JsonValueKind.Object or JsonValueKind.Array)
                    return value.GetRawText();
            }

            return string.Empty;
        }

        private static bool TryGetProperty(JsonElement item, string name, out JsonElement value)
        {
            if (item.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in item.EnumerateObject())
                {
                    if (string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase))
                    {
                        value = property.Value;
                        return true;
                    }
                }
            }

            value = default;
            return false;
        }

        private static void Require(List<string> pendencias, string? value, string field)
        {
            if (string.IsNullOrWhiteSpace(value))
                pendencias.Add(field);
        }

        // The confirmed contingency payload is the source of truth for CT-e parties.
        // NF-e snapshots are shown as origin data, never as a late fallback during emission.
        private static void ValidarParticipanteCTe(
            List<string> pendencias,
            string complemento,
            string participantName,
            string label)
        {
            if (string.IsNullOrWhiteSpace(complemento))
            {
                pendencias.Add(label + "Participante");
                return;
            }

            try
            {
                using var document = JsonDocument.Parse(complemento);
                if (!TryGetProperty(document.RootElement, "participantesCTe", out var participants) ||
                    participants.ValueKind != JsonValueKind.Object ||
                    !TryGetProperty(participants, participantName, out var participant) ||
                    participant.ValueKind != JsonValueKind.Object)
                {
                    pendencias.Add(label + "Participante");
                    return;
                }

                Require(pendencias, Text(participant, "documento"), label + "Documento");
                Require(pendencias, Text(participant, "nome"), label + "Nome");
                Require(pendencias, Text(participant, "logradouro"), label + "Logradouro");
                Require(pendencias, Text(participant, "numero"), label + "Numero");
                Require(pendencias, Text(participant, "bairro"), label + "Bairro");
                Require(pendencias, Text(participant, "municipioCodigoIbge"), label + "MunicipioCodigoIbge");
                Require(pendencias, Text(participant, "municipioNome"), label + "MunicipioNome");
                Require(pendencias, Text(participant, "uf"), label + "UF");
                Require(pendencias, Text(participant, "cep"), label + "Cep");
            }
            catch (JsonException)
            {
                pendencias.Add(label + "Participante");
            }
        }

        private static void ValidarParametrosDoPlano(
            List<string> pendencias,
            EntradaFiscalContingenciaDTO entrada,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos,
            string tipoAgrupamento,
            string estrategiaRateio)
        {
            if (!string.IsNullOrWhiteSpace(tipoAgrupamento) && !TiposAgrupamentoCTeSuportados.Contains(tipoAgrupamento))
                pendencias.Add("TipoAgrupamentoCTeInvalido");

            if (!string.IsNullOrWhiteSpace(estrategiaRateio) && !EstrategiasRateioFreteSuportadas.Contains(estrategiaRateio))
                pendencias.Add("EstrategiaRateioFreteNaoImplementada");

            if (documentos.Count == 0 || !TiposAgrupamentoCTeSuportados.Contains(tipoAgrupamento))
                return;

            ValidarDocumentosOriginarios(pendencias, documentos);

            if (EstrategiasRateioFreteSuportadas.Contains(estrategiaRateio))
                ValidarBaseRateio(pendencias, documentos, estrategiaRateio);

            var grupos = AgruparDocumentos(entrada, documentos, tipoAgrupamento);
            foreach (var grupo in grupos)
                ValidarGrupoCTe(pendencias, grupo);
        }

        private static void ValidarDocumentosOriginarios(
            List<string> pendencias,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos)
        {
            foreach (var documento in documentos)
            {
                if (!IsChaveAcessoNFeValida(documento.chaveacesso))
                    pendencias.Add("DocumentoOriginarioChaveAcessoInvalida");

                if (string.IsNullOrWhiteSpace(documento.emitentedocumento))
                    pendencias.Add("DocumentoOriginarioEmitente");

                if (string.IsNullOrWhiteSpace(documento.destinatariodocumento))
                    pendencias.Add("DocumentoOriginarioDestinatario");
            }
        }

        private static void ValidarBaseRateio(
            List<string> pendencias,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos,
            string estrategiaRateio)
        {
            var totalBase = BaseRateio(documentos, estrategiaRateio);
            if (totalBase <= 0m)
            {
                pendencias.Add(estrategiaRateio.Equals("proporcional_peso_bruto", StringComparison.OrdinalIgnoreCase)
                    ? "BaseRateioPesoBruto"
                    : "BaseRateioValorDocumento");
            }
        }

        private static void ValidarGrupoCTe(List<string> pendencias, ContingenciaCteGrupo grupo)
        {
            if (DistinctNonEmpty(grupo.Documentos.Select(x => x.emitentedocumento)).Count != 1)
                pendencias.Add("GrupoCTeComEmitenteMisto");

            if (DistinctNonEmpty(grupo.Documentos.Select(x => x.destinatariodocumento)).Count != 1)
                pendencias.Add("GrupoCTeComDestinatarioMisto");

            if (DistinctNonEmpty(grupo.Documentos.Select(x => x.uforigem)).Count > 1 ||
                DistinctNonEmpty(grupo.Documentos.Select(x => x.ufdestino)).Count > 1)
            {
                pendencias.Add("GrupoCTeComRotaMista");
            }
        }

        private static List<string> DistinctNonEmpty(IEnumerable<string?> values)
            => values
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .Select(value => value!.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

        private static bool IsChaveAcessoNFeValida(string? chave)
        {
            if (string.IsNullOrWhiteSpace(chave) || chave.Length != 44)
                return false;

            return chave.All(char.IsDigit);
        }

        private static string Value(string? entityValue, string complemento, params string[] names)
        {
            return string.IsNullOrWhiteSpace(entityValue)
                ? Text(complemento, names)
                : entityValue;
        }

        private static string Digits(string? value)
            => new((value ?? string.Empty).Where(char.IsDigit).ToArray());

        private static bool MesmaBaseCnpj(string primeiro, string segundo)
            => primeiro.Length >= 8 &&
               segundo.Length >= 8 &&
               string.Equals(primeiro[..8], segundo[..8], StringComparison.Ordinal);

        private static bool TryParseDecimal(string? value, out decimal result)
        {
            var text = (value ?? string.Empty).Trim();
            if (text.Contains(','))
                text = text.Replace(".", string.Empty).Replace(',', '.');

            return decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out result);
        }

        private static string FirstNonEmpty(string first, string fallback)
            => string.IsNullOrWhiteSpace(first) ? fallback : first;

        private static List<ContingenciaCteGrupo> AgruparDocumentos(
            EntradaFiscalContingenciaDTO entrada,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos,
            string tipoAgrupamento)
        {
            var grupos = new Dictionary<string, ContingenciaCteGrupo>(StringComparer.OrdinalIgnoreCase);
            var index = 0;

            foreach (var documento in documentos)
            {
                index++;
                var chave = ChaveGrupo(entrada, documento, tipoAgrupamento, index);
                if (!grupos.TryGetValue(chave, out var grupo))
                {
                    grupo = new ContingenciaCteGrupo(chave, DescricaoGrupo(entrada, documento, tipoAgrupamento, index));
                    grupos.Add(chave, grupo);
                }

                grupo.Documentos.Add(documento);
            }

            return grupos.Values.ToList();
        }

        private static string ChaveGrupo(
            EntradaFiscalContingenciaDTO entrada,
            NFeProdutoSnapshotDTO documento,
            string tipoAgrupamento,
            int index)
        {
            return tipoAgrupamento switch
            {
                "agrupar_por_destinatario" => FirstNonEmpty(documento.destinatariodocumento, "sem-destinatario"),
                "cte_unico_da_carga" => FirstNonEmpty(entrada.cargaid, "carga"),
                _ => FirstNonEmpty(documento.chaveacesso, "documento-" + index)
            };
        }

        private static string DescricaoGrupo(
            EntradaFiscalContingenciaDTO entrada,
            NFeProdutoSnapshotDTO documento,
            string tipoAgrupamento,
            int index)
        {
            return tipoAgrupamento switch
            {
                "agrupar_por_destinatario" => "Destinatario " + FirstNonEmpty(documento.destinatariodocumento, "nao informado"),
                "cte_unico_da_carga" => "Carga " + FirstNonEmpty(entrada.cargaid, "sem codigo"),
                _ => "Documento " + FirstNonEmpty(documento.chaveacesso, index.ToString(CultureInfo.InvariantCulture))
            };
        }

        private static decimal BaseRateio(IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos, string estrategiaRateio)
        {
            return estrategiaRateio switch
            {
                "proporcional_peso_bruto" => documentos.Sum(x => x.pesobruto),
                "manual" => 0m,
                "sem_rateio" => 0m,
                _ => documentos.Sum(x => x.valordocumento)
            };
        }

        private static decimal RatearValorFrete(decimal valorFrete, string estrategiaRateio, decimal baseGrupo, decimal totalBase)
        {
            if (valorFrete <= 0m || estrategiaRateio is "manual" or "sem_rateio")
                return 0m;

            if (totalBase <= 0m)
                return Math.Round(valorFrete, 2, MidpointRounding.AwayFromZero);

            return Math.Round(valorFrete * (baseGrupo / totalBase), 2, MidpointRounding.AwayFromZero);
        }

        private sealed class ContingenciaCteGrupo
        {
            public ContingenciaCteGrupo(string chave, string descricao)
            {
                Chave = chave;
                Descricao = descricao;
            }

            public string Chave { get; }
            public string Descricao { get; }
            public List<NFeProdutoSnapshotDTO> Documentos { get; } = new();
        }
    }
}
