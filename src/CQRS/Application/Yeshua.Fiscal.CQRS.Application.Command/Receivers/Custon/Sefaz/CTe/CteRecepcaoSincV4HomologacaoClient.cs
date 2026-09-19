using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Command.Receivers
{
    internal sealed record CteParticipantOptions(
        string Documento,
        string Nome,
        string InscricaoEstadual,
        string Logradouro,
        string Numero,
        string Bairro,
        string CodigoMunicipio,
        string Municipio,
        string Cep,
        string Uf)
    {
        public static CteParticipantOptions Empty { get; } = new(
            string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
    }

    internal sealed record CteRecepcaoSincV4Options(
        int Ambiente,
        int CodigoUf,
        string Endpoint,
        string SoapAction,
        string ContentMediaType,
        string CertificatePath,
        string CertificatePassword,
        string CnpjEmitente,
        string RazaoSocial,
        string InscricaoEstadual,
        int TimeoutSeconds)
    {
        public int TipoCTe { get; init; }
        public int TipoServico { get; init; }
        public int Modal { get; init; } = 1;
        public int Globalizado { get; init; }
        public string UfInicio { get; init; } = "PE";
        public string UfFim { get; init; } = "PE";
        public string Cfop { get; init; } = string.Empty;
        public string MunicipioInicioCodigoIbge { get; init; } = "2611606";
        public string MunicipioInicioNome { get; init; } = "RECIFE";
        public string MunicipioFimCodigoIbge { get; init; } = "2607901";
        public string MunicipioFimNome { get; init; } = "JABOATAO DOS GUARARAPES";
        public string RemetenteDocumento { get; init; } = string.Empty;
        public string DestinatarioDocumento { get; init; } = string.Empty;
        public string TomadorDocumento { get; init; } = string.Empty;
        public CteParticipantOptions Remetente { get; init; } = CteParticipantOptions.Empty;
        public CteParticipantOptions Destinatario { get; init; } = CteParticipantOptions.Empty;
        public string NomeFantasiaEmitente { get; init; } = string.Empty;
        public string LogradouroEmitente { get; init; } = "RUA TESTE";
        public string NumeroEnderecoEmitente { get; init; } = "100";
        public string BairroEmitente { get; init; } = "CENTRO";
        public string CepEmitente { get; init; } = "50000000";
        public string MunicipioEmitenteCodigoIbge { get; init; } = "2611606";
        public string MunicipioEmitenteNome { get; init; } = "RECIFE";
        public string UfEmitente { get; init; } = "PE";
        public int CrtEmitente { get; init; } = 3;
        public string ObservacaoFiscal { get; init; } = string.Empty;
        public string Rntrc { get; init; } = "45861338";
        public decimal ValorServico { get; init; } = 100m;
        public decimal ValorCarga { get; init; } = 1000m;
        public decimal PesoBruto { get; init; } = 100m;
        public IReadOnlyList<string> ChavesNFe { get; init; } = Array.Empty<string>();

        public static CteRecepcaoSincV4Options FromEnvironment()
        {
            var fixedOptions = new CteRecepcaoSincV4Options(
                Ambiente: 2,
                CodigoUf: 26,
                Endpoint: "https://homologacao.nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoSincV4.asmx",
                SoapAction: "http://www.portalfiscal.inf.br/cte/wsdl/CTeRecepcaoSincV4/cteRecepcao",
                ContentMediaType: "application/soap+xml",
                CertificatePath: @"C:\Users\AngeloRicardoFontana\Downloads\63249950000174.pfx",
                CertificatePassword: "zanata123",
                CnpjEmitente: "63249950000174",
                RazaoSocial: "ZANATA LOGISTICA E TRANSPORTES LTDA",
                InscricaoEstadual: "128556188",
                TimeoutSeconds: 120);

            return fixedOptions with
            {
                Endpoint = Environment.GetEnvironmentVariable("YESHUA_CTE_RECEPCAO_ENDPOINT") ?? fixedOptions.Endpoint,
                CertificatePath =
                    Environment.GetEnvironmentVariable("YESHUA_CTE_CERT")
                    ?? Environment.GetEnvironmentVariable("YESHUA_CTE_CERTIFICATE_PATH")
                    ?? fixedOptions.CertificatePath,
                CertificatePassword =
                    Environment.GetEnvironmentVariable("YESHUA_CTE_SENHA")
                    ?? Environment.GetEnvironmentVariable("YESHUA_CTE_CERTIFICATE_PASSWORD")
                    ?? fixedOptions.CertificatePassword,
                CnpjEmitente =
                    Environment.GetEnvironmentVariable("YESHUA_CTE_CNPJ")
                    ?? Environment.GetEnvironmentVariable("YESHUA_CTE_CNPJ_EMITENTE")
                    ?? fixedOptions.CnpjEmitente,
                RazaoSocial =
                    Environment.GetEnvironmentVariable("YESHUA_CTE_RAZAO")
                    ?? Environment.GetEnvironmentVariable("YESHUA_CTE_RAZAO_SOCIAL")
                    ?? fixedOptions.RazaoSocial,
                InscricaoEstadual =
                    Environment.GetEnvironmentVariable("YESHUA_CTE_IE")
                    ?? Environment.GetEnvironmentVariable("YESHUA_CTE_INSCRICAO_ESTADUAL")
                    ?? fixedOptions.InscricaoEstadual,
                NomeFantasiaEmitente = Environment.GetEnvironmentVariable("YESHUA_CTE_NOME_FANTASIA") ?? "ZANATA LOGISTICA",
                LogradouroEmitente = Environment.GetEnvironmentVariable("YESHUA_CTE_ENDERECO_LOGRADOURO") ?? "RUA TESTE",
                NumeroEnderecoEmitente = Environment.GetEnvironmentVariable("YESHUA_CTE_ENDERECO_NUMERO") ?? "100",
                BairroEmitente = Environment.GetEnvironmentVariable("YESHUA_CTE_ENDERECO_BAIRRO") ?? "CENTRO",
                CepEmitente = Environment.GetEnvironmentVariable("YESHUA_CTE_ENDERECO_CEP") ?? "50000000",
                MunicipioEmitenteCodigoIbge = Environment.GetEnvironmentVariable("YESHUA_CTE_MUNICIPIO_CODIGO_IBGE") ?? "2611606",
                MunicipioEmitenteNome = Environment.GetEnvironmentVariable("YESHUA_CTE_MUNICIPIO_NOME") ?? "RECIFE",
                UfEmitente = Environment.GetEnvironmentVariable("YESHUA_CTE_UF") ?? "PE",
                CrtEmitente = int.TryParse(Environment.GetEnvironmentVariable("YESHUA_CTE_CRT"), out var crt) ? crt : 3,
                RemetenteDocumento =
                    Environment.GetEnvironmentVariable("YESHUA_CTE_REMETENTE_DOCUMENTO")
                    ?? Environment.GetEnvironmentVariable("YESHUA_CTE_CNPJ")
                    ?? fixedOptions.CnpjEmitente,
                DestinatarioDocumento = Environment.GetEnvironmentVariable("YESHUA_CTE_DESTINATARIO_DOCUMENTO") ?? "00000000000191",
                TomadorDocumento =
                    Environment.GetEnvironmentVariable("YESHUA_CTE_TOMADOR_DOCUMENTO")
                    ?? Environment.GetEnvironmentVariable("YESHUA_CTE_REMETENTE_DOCUMENTO")
                    ?? Environment.GetEnvironmentVariable("YESHUA_CTE_CNPJ")
                    ?? fixedOptions.CnpjEmitente,
                ObservacaoFiscal = Environment.GetEnvironmentVariable("YESHUA_CTE_OBSERVACAO_FISCAL") ?? string.Empty
            };
        }

        public void ValidateForSend()
        {
            if (Ambiente is not 1 and not 2)
                throw new InvalidOperationException("O ambiente do CT-e deve ser 1 ou 2.");

            if (CodigoUf <= 0)
                throw new InvalidOperationException("O codigo UF do CT-e deve ser informado.");

            if (string.IsNullOrWhiteSpace(Endpoint))
                throw new InvalidOperationException("O endpoint CT-e deve ser informado.");

            if (string.IsNullOrWhiteSpace(CertificatePath))
                throw new InvalidOperationException("O caminho do certificado CT-e deve ser informado.");

            if (!File.Exists(CertificatePath))
                throw new FileNotFoundException("Certificado CT-e nao encontrado.", CertificatePath);

            if (string.IsNullOrWhiteSpace(CertificatePassword))
                throw new InvalidOperationException("A senha do certificado CT-e deve ser informada.");

            if (Modal != 1)
                throw new NotSupportedException("O prototipo atual de CT-e implementa somente o modal rodoviario.");

            if (TipoCTe != 0)
                throw new NotSupportedException("O prototipo atual de CT-e implementa somente CT-e normal.");

            if (TipoServico != 0)
            {
                throw new NotSupportedException(
                    "Subcontratacao e redespacho exigem documentos anteriores e participantes proprios. " +
                    "O montador atual implementa somente servico normal.");
            }

            if (Globalizado != 0)
                throw new NotSupportedException("O CT-e globalizado ainda nao foi implementado no montador XML.");

            if (Ambiente == 1)
            {
                throw new NotSupportedException(
                    "A tributacao do CT-e ainda usa valores de homologacao. " +
                    "Envio em producao permanece bloqueado ate a politica fiscal real ser implementada.");
            }

            if (ValorServico <= 0m)
                throw new InvalidOperationException("O valor do servico do CT-e deve ser maior que zero.");

            if (ValorCarga <= 0m)
                throw new InvalidOperationException("O valor da carga do CT-e deve ser maior que zero.");

            if (PesoBruto <= 0m)
                throw new InvalidOperationException("O peso bruto do CT-e deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(TomadorDocumento))
                throw new InvalidOperationException("O documento do tomador do CT-e deve ser informado.");

            ValidateParticipant(Remetente, RemetenteDocumento, "remetente");
            ValidateParticipant(Destinatario, DestinatarioDocumento, "destinatario");

            if (!SameDocument(TomadorDocumento, RemetenteDocumento) &&
                !SameDocument(TomadorDocumento, DestinatarioDocumento))
            {
                throw new NotSupportedException(
                    "O tomador informado nao e remetente nem destinatario. " +
                    "O contrato atual ainda nao possui o cadastro completo exigido pelo toma4.");
            }

            if (string.IsNullOrWhiteSpace(RazaoSocial) ||
                string.IsNullOrWhiteSpace(InscricaoEstadual) ||
                string.IsNullOrWhiteSpace(LogradouroEmitente) ||
                string.IsNullOrWhiteSpace(NumeroEnderecoEmitente) ||
                string.IsNullOrWhiteSpace(BairroEmitente) ||
                string.IsNullOrWhiteSpace(CepEmitente) ||
                string.IsNullOrWhiteSpace(MunicipioEmitenteCodigoIbge) ||
                string.IsNullOrWhiteSpace(MunicipioEmitenteNome) ||
                string.IsNullOrWhiteSpace(UfEmitente))
            {
                throw new InvalidOperationException("O cadastro fiscal completo do emitente do CT-e deve ser informado.");
            }

            var codigoUfEmitente = CteUfPolicy.ResolveCode(UfEmitente);
            if (codigoUfEmitente == 0)
                throw new InvalidOperationException($"A UF do emitente do CT-e e invalida: {UfEmitente}.");

            if (CodigoUf != codigoUfEmitente)
            {
                throw new InvalidOperationException(
                    $"O codigo da UF autorizadora {CodigoUf:D2} diverge da UF do emitente {UfEmitente} ({codigoUfEmitente:D2}).");
            }

            if (!CteUfPolicy.MunicipioPertenceAoEstado(MunicipioEmitenteCodigoIbge, UfEmitente))
            {
                throw new InvalidOperationException(
                    $"O municipio IBGE do emitente {MunicipioEmitenteCodigoIbge} diverge da UF {UfEmitente}.");
            }

            foreach (var chaveNFe in ChavesNFe)
            {
                if (chaveNFe.Length != 44 || chaveNFe.Any(character => character is < '0' or > '9'))
                    throw new InvalidOperationException("Toda chave NF-e do CT-e deve possuir exatamente 44 digitos.");
            }
        }

        private static bool SameDocument(string first, string second)
            => string.Equals(Digits(first), Digits(second), StringComparison.Ordinal);

        private static void ValidateParticipant(
            CteParticipantOptions participant,
            string documentFallback,
            string role)
        {
            var document = string.IsNullOrWhiteSpace(participant.Documento)
                ? documentFallback
                : participant.Documento;
            if (Digits(document).Length is not 11 and not 14)
                throw new InvalidOperationException($"O documento do {role} do CT-e deve ser informado.");

            // pendencia: dados antigos de homologacao nao possuem snapshot completo.
            // Novas entradas devem sempre preencher CTeParticipanteSnapshot a partir da NF-e.
            if (!string.IsNullOrWhiteSpace(participant.Documento) &&
                (string.IsNullOrWhiteSpace(participant.Nome) ||
                 string.IsNullOrWhiteSpace(participant.Logradouro) ||
                 string.IsNullOrWhiteSpace(participant.Numero) ||
                 string.IsNullOrWhiteSpace(participant.Bairro) ||
                 string.IsNullOrWhiteSpace(participant.CodigoMunicipio) ||
                 string.IsNullOrWhiteSpace(participant.Municipio) ||
                 string.IsNullOrWhiteSpace(participant.Uf)))
            {
                throw new InvalidOperationException($"O snapshot fiscal completo do {role} do CT-e deve ser informado.");
            }
        }

        private static string Digits(string value)
            => new(value.Where(character => character is >= '0' and <= '9').ToArray());
    }

    internal sealed record CteRecepcaoSincV4Result(
        bool Autorizado,
        int CodigoRetorno,
        string Motivo,
        string Chave,
        string? Protocolo,
        int HttpStatusCode,
        string XmlCte,
        string SoapResponse);

    internal sealed record CteRecepcaoSincV4Prepared(
        string Chave,
        int? Numero,
        int? Serie,
        string XmlCte,
        string XmlHash);

    internal static class CteRecepcaoSincV4HomologacaoClient
    {
        private const string ServiceNamespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeRecepcaoSincV4";
        private const string CteNamespace = "http://www.portalfiscal.inf.br/cte";
        private const string HomologacaoNome = "CTE EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";

        public static CteRecepcaoSincV4Result Autorizar()
        {
            return AutorizarAsync(CteRecepcaoSincV4Options.FromEnvironment())
                .GetAwaiter()
                .GetResult();
        }

        public static CteRecepcaoSincV4Prepared Preparar()
        {
            return Preparar(CteRecepcaoSincV4Options.FromEnvironment());
        }

        public static CteRecepcaoSincV4Prepared Preparar(CteRecepcaoSincV4Options options)
        {
            return PrepararCore(options);
        }

        public static CteRecepcaoSincV4Result Autorizar(CteRecepcaoSincV4Prepared prepared)
        {
            return EnviarAsync(CteRecepcaoSincV4Options.FromEnvironment(), prepared)
                .GetAwaiter()
                .GetResult();
        }

        public static CteRecepcaoSincV4Result Autorizar(
            CteRecepcaoSincV4Prepared prepared,
            string certificatePath,
            string certificatePassword)
        {
            var options = CteRecepcaoSincV4Options.FromEnvironment() with
            {
                CertificatePath = certificatePath,
                CertificatePassword = certificatePassword
            };
            return EnviarAsync(options, prepared).GetAwaiter().GetResult();
        }

        private static async Task<CteRecepcaoSincV4Result> AutorizarAsync(CteRecepcaoSincV4Options options)
        {
            var prepared = Preparar(options);
            return await EnviarAsync(options, prepared).ConfigureAwait(false);
        }

        private static CteRecepcaoSincV4Prepared PrepararCore(CteRecepcaoSincV4Options options)
        {
            options.ValidateForSend();

            // pendencia: separar a montagem do XML fiscal do fluxo de assinatura por certificado.
            // Futuramente a assinatura pode ocorrer fora do servidor, na maquina local do usuario,
            // quando essa politica for escolhida para o aplicativo/cliente.
            using var signingCertificate = LoadCertificate(options.CertificatePath, options.CertificatePassword);
            var cteXml = SignCteXml(BuildHomologCteXml(options), signingCertificate);
            var chave = ExtractChave(cteXml);
            var chaveInfo = SefazChaveAcessoInfo.Parse(chave);

            return new CteRecepcaoSincV4Prepared(
                chave,
                chaveInfo.Numero,
                chaveInfo.Serie,
                cteXml,
                Hash(cteXml));
        }

        private static async Task<CteRecepcaoSincV4Result> EnviarAsync(
            CteRecepcaoSincV4Options options,
            CteRecepcaoSincV4Prepared prepared)
        {
            options.ValidateForSend();

            var cteXml = prepared.XmlCte;
            var chave = prepared.Chave;
            var soapEnvelope = WrapRecepcaoInSoapEnvelope(CompressToBase64(cteXml));
            using var transportCertificate = LoadCertificate(options.CertificatePath, options.CertificatePassword);

            using var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                SslProtocols = SslProtocols.Tls12,
                UseProxy = false
            };
            handler.ClientCertificates.Add(transportCertificate);

            using var httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds)
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, options.Endpoint)
            {
                Version = HttpVersion.Version11,
                Content = new StringContent(soapEnvelope, Encoding.UTF8, options.ContentMediaType)
            };

            request.Content.Headers.ContentType!.CharSet = "utf-8";
            request.Content.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("action", $"\"{options.SoapAction}\""));
            request.Headers.ExpectContinue = false;
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            string responseBody;
            int httpStatusCode;
            try
            {
                var response = await httpClient.SendAsync(request).ConfigureAwait(false);
                responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                httpStatusCode = (int)response.StatusCode;
            }
            catch (Exception ex) when (ex is HttpRequestException or AuthenticationException or IOException)
            {
                if (SefazOpenSslHttpFallback.CanHandle(ex))
                {
                    var fallbackResponse = await SefazOpenSslHttpFallback.PostAsync(
                        options.Endpoint,
                        soapEnvelope,
                        $"{options.ContentMediaType}; charset=utf-8; action=\"{options.SoapAction}\"",
                        options.CertificatePath,
                        options.CertificatePassword,
                        options.TimeoutSeconds).ConfigureAwait(false);

                    responseBody = fallbackResponse.Body;
                    httpStatusCode = fallbackResponse.StatusCode;
                }
                else
                {
                    throw new InvalidOperationException(
                        "Falha HTTP/SSL ao chamar SEFAZ CT-e. " + DescribeException(ex),
                        ex);
                }
            }

            if (httpStatusCode < 200 || httpStatusCode > 299)
            {
                throw new InvalidOperationException(
                    $"SEFAZ CT-e retornou HTTP {httpStatusCode}. {responseBody}");
            }

            var codigoRetorno = ReadInt(responseBody, "infProt", "cStat")
                ?? ReadInt(responseBody, "retCTe", "cStat")
                ?? 0;
            var motivo = ReadText(responseBody, "infProt", "xMotivo")
                ?? ReadText(responseBody, "retCTe", "xMotivo")
                ?? string.Empty;
            var protocolo = ReadText(responseBody, "infProt", "nProt");

            return new CteRecepcaoSincV4Result(
                codigoRetorno == 100,
                codigoRetorno,
                motivo,
                chave,
                protocolo,
                httpStatusCode,
                cteXml,
                responseBody);
        }

        private static string BuildHomologCteXml(CteRecepcaoSincV4Options options)
        {
            var now = DateTimeOffset.Now;
            var serie = 1;
            var numero = RandomNumberGenerator.GetInt32(1, 999999999);
            var codigoControle = RandomNumberGenerator.GetInt32(1, 99999999).ToString("D8");
            var chave = BuildAccessKey(
                options.CodigoUf,
                now,
                options.CnpjEmitente,
                modelo: 57,
                serie,
                numero,
                tipoEmissao: 1,
                codigoControle);

            var chaveNfeMock = BuildAccessKey(
                options.CodigoUf,
                now,
                options.CnpjEmitente,
                modelo: 55,
                serie,
                numero,
                tipoEmissao: 1,
                RandomNumberGenerator.GetInt32(1, 99999999).ToString("D8"));

            var doc = new XmlDocument { PreserveWhitespace = false };
            var cte = doc.CreateElement("CTe", CteNamespace);
            doc.AppendChild(cte);

            var infCte = doc.CreateElement("infCte", CteNamespace);
            infCte.SetAttribute("Id", "CTe" + chave);
            infCte.SetAttribute("versao", "4.00");
            cte.AppendChild(infCte);

            var ide = AppendElement(doc, infCte, "ide");
            AppendElement(doc, ide, "cUF", options.CodigoUf.ToString());
            AppendElement(doc, ide, "cCT", codigoControle);
            AppendElement(
                doc,
                ide,
                "CFOP",
                string.IsNullOrWhiteSpace(options.Cfop)
                    ? CteCfopPolicy.Resolve(options.UfEmitente, options.UfInicio, options.UfFim)
                    : options.Cfop.Trim());
            AppendElement(doc, ide, "natOp", "PRESTACAO DE SERVICO DE TRANSPORTE");
            AppendElement(doc, ide, "mod", "57");
            AppendElement(doc, ide, "serie", serie.ToString());
            AppendElement(doc, ide, "nCT", numero.ToString());
            AppendElement(doc, ide, "dhEmi", now.ToString("yyyy-MM-dd'T'HH:mm:sszzz"));
            AppendElement(doc, ide, "tpImp", "1");
            AppendElement(doc, ide, "tpEmis", "1");
            AppendElement(doc, ide, "cDV", chave[^1].ToString());
            AppendElement(doc, ide, "tpAmb", options.Ambiente.ToString());
            AppendElement(doc, ide, "tpCTe", options.TipoCTe.ToString(CultureInfo.InvariantCulture));
            AppendElement(doc, ide, "procEmi", "0");
            AppendElement(doc, ide, "verProc", "YESHUA-CTE-001");
            AppendElement(doc, ide, "cMunEnv", options.MunicipioInicioCodigoIbge);
            AppendElement(doc, ide, "xMunEnv", options.MunicipioInicioNome);
            AppendElement(doc, ide, "UFEnv", options.UfInicio);
            AppendElement(doc, ide, "modal", options.Modal.ToString("D2", CultureInfo.InvariantCulture));
            AppendElement(doc, ide, "tpServ", options.TipoServico.ToString(CultureInfo.InvariantCulture));
            AppendElement(doc, ide, "cMunIni", options.MunicipioInicioCodigoIbge);
            AppendElement(doc, ide, "xMunIni", options.MunicipioInicioNome);
            AppendElement(doc, ide, "UFIni", options.UfInicio);
            AppendElement(doc, ide, "cMunFim", options.MunicipioFimCodigoIbge);
            AppendElement(doc, ide, "xMunFim", options.MunicipioFimNome);
            AppendElement(doc, ide, "UFFim", options.UfFim);
            AppendElement(doc, ide, "retira", "1");
            AppendElement(doc, ide, "indIEToma", "1");
            var toma3 = AppendElement(doc, ide, "toma3");
            AppendElement(doc, toma3, "toma", ResolveToma3(options).ToString(CultureInfo.InvariantCulture));

            if (!string.IsNullOrWhiteSpace(options.ObservacaoFiscal))
            {
                var compl = AppendElement(doc, infCte, "compl");
                AppendElement(doc, compl, "xObs", options.ObservacaoFiscal.Trim());
            }

            var emit = AppendElement(doc, infCte, "emit");
            AppendElement(doc, emit, "CNPJ", options.CnpjEmitente);
            AppendElement(doc, emit, "IE", options.InscricaoEstadual);
            AppendElement(doc, emit, "xNome", NomeParaAmbiente(options.Ambiente, options.RazaoSocial));
            if (!string.IsNullOrWhiteSpace(options.NomeFantasiaEmitente))
                AppendElement(doc, emit, "xFant", options.NomeFantasiaEmitente);
            AppendEndereco(
                doc,
                AppendElement(doc, emit, "enderEmit"),
                options.LogradouroEmitente,
                options.NumeroEnderecoEmitente,
                options.BairroEmitente,
                options.MunicipioEmitenteCodigoIbge,
                options.MunicipioEmitenteNome,
                options.CepEmitente,
                options.UfEmitente,
                incluirPais: false);
            AppendElement(doc, emit, "CRT", options.CrtEmitente.ToString(CultureInfo.InvariantCulture));

            AppendParticipant(
                doc,
                infCte,
                "rem",
                "enderReme",
                options.Ambiente,
                options.Remetente,
                options.RemetenteDocumento,
                options.CnpjEmitente,
                options.InscricaoEstadual,
                options.MunicipioInicioCodigoIbge,
                options.MunicipioInicioNome,
                options.UfInicio,
                "RUA TESTE",
                "100",
                "50000000");

            AppendParticipant(
                doc,
                infCte,
                "dest",
                "enderDest",
                options.Ambiente,
                options.Destinatario,
                options.DestinatarioDocumento,
                "00000000000191",
                "ISENTO",
                options.MunicipioFimCodigoIbge,
                options.MunicipioFimNome,
                options.UfFim,
                "AVENIDA TESTE",
                "200",
                "54000000");

            var vPrest = AppendElement(doc, infCte, "vPrest");
            AppendElement(doc, vPrest, "vTPrest", Money(options.ValorServico));
            AppendElement(doc, vPrest, "vRec", Money(options.ValorServico));
            var comp = AppendElement(doc, vPrest, "Comp");
            AppendElement(doc, comp, "xNome", "FRETE");
            AppendElement(doc, comp, "vComp", Money(options.ValorServico));

            var imp = AppendElement(doc, infCte, "imp");
            var icms = AppendElement(doc, imp, "ICMS");
            var icms00 = AppendElement(doc, icms, "ICMS00");
            AppendElement(doc, icms00, "CST", "00");
            AppendElement(doc, icms00, "vBC", Money(options.ValorServico));
            AppendElement(doc, icms00, "pICMS", "12.00");
            AppendElement(doc, icms00, "vICMS", Money(options.ValorServico * 0.12m));
            AppendIbsCbsHomologacao(doc, imp);
            AppendElement(doc, imp, "vTotDFe", Money(options.ValorServico));

            var infCteNorm = AppendElement(doc, infCte, "infCTeNorm");
            var infCarga = AppendElement(doc, infCteNorm, "infCarga");
            AppendElement(doc, infCarga, "vCarga", Money(options.ValorCarga));
            AppendElement(doc, infCarga, "proPred", "MERCADORIA HOMOLOGACAO");
            var infQ = AppendElement(doc, infCarga, "infQ");
            AppendElement(doc, infQ, "cUnid", "01");
            AppendElement(doc, infQ, "tpMed", "PESO BRUTO");
            AppendElement(doc, infQ, "qCarga", Quantity(options.PesoBruto));

            var infDoc = AppendElement(doc, infCteNorm, "infDoc");
            var chavesNFe = options.ChavesNFe.Count > 0 ? options.ChavesNFe : new[] { chaveNfeMock };
            foreach (var chaveNFe in chavesNFe)
            {
                var infNFe = AppendElement(doc, infDoc, "infNFe");
                AppendElement(doc, infNFe, "chave", chaveNFe);
            }

            var infModal = AppendElement(doc, infCteNorm, "infModal");
            infModal.SetAttribute("versaoModal", "4.00");
            var rodo = AppendElement(doc, infModal, "rodo");
            AppendElement(doc, rodo, "RNTRC", options.Rntrc);

            var infRespTec = AppendElement(doc, infCte, "infRespTec");
            AppendElement(doc, infRespTec, "CNPJ", options.CnpjEmitente);
            AppendElement(doc, infRespTec, "xContato", "PLAY SISTEMAS INTELIGENTES");
            AppendElement(doc, infRespTec, "email", "suporte@playsis.com.br");
            AppendElement(doc, infRespTec, "fone", "62981595863");

            var infCTeSupl = AppendElement(doc, cte, "infCTeSupl");
            AppendElement(
                doc,
                infCTeSupl,
                "qrCodCTe",
                $"https://homologacao.nfe.fazenda.sp.gov.br/CTeConsulta/qrCode?chCTe={chave}&tpAmb={options.Ambiente}");

            return doc.OuterXml;
        }

        private static int ResolveToma3(CteRecepcaoSincV4Options options)
        {
            var tomador = OnlyDigits(options.TomadorDocumento);
            if (string.Equals(tomador, OnlyDigits(options.RemetenteDocumento), StringComparison.Ordinal))
                return 0;

            if (string.Equals(tomador, OnlyDigits(options.DestinatarioDocumento), StringComparison.Ordinal))
                return 3;

            throw new NotSupportedException("O tomador informado exige toma4, ainda nao suportado pelo contrato atual.");
        }

        private static void AppendIbsCbsHomologacao(XmlDocument doc, XmlElement imp)
        {
            var ibsCbs = AppendElement(doc, imp, "IBSCBS");
            AppendElement(doc, ibsCbs, "CST", "000");
            AppendElement(doc, ibsCbs, "cClassTrib", "000001");

            var gIbsCbs = AppendElement(doc, ibsCbs, "gIBSCBS");
            AppendElement(doc, gIbsCbs, "vBC", "100.00");

            var gIbsUf = AppendElement(doc, gIbsCbs, "gIBSUF");
            AppendElement(doc, gIbsUf, "pIBSUF", "0.1000");
            AppendElement(doc, gIbsUf, "vIBSUF", "0.10");

            var gIbsMun = AppendElement(doc, gIbsCbs, "gIBSMun");
            AppendElement(doc, gIbsMun, "pIBSMun", "0.0000");
            AppendElement(doc, gIbsMun, "vIBSMun", "0.00");

            AppendElement(doc, gIbsCbs, "vIBS", "0.10");

            var gCbs = AppendElement(doc, gIbsCbs, "gCBS");
            AppendElement(doc, gCbs, "pCBS", "0.9000");
            AppendElement(doc, gCbs, "vCBS", "0.90");
        }

        private static void AppendEndereco(
            XmlDocument doc,
            XmlElement parent,
            string logradouro,
            string numero,
            string bairro,
            string codigoMunicipio,
            string municipio,
            string cep,
            string uf,
            bool incluirPais)
        {
            AppendElement(doc, parent, "xLgr", logradouro);
            AppendElement(doc, parent, "nro", numero);
            AppendElement(doc, parent, "xBairro", bairro);
            AppendElement(doc, parent, "cMun", codigoMunicipio);
            AppendElement(doc, parent, "xMun", municipio);
            AppendElement(doc, parent, "CEP", cep);
            AppendElement(doc, parent, "UF", uf);
            if (incluirPais)
            {
                AppendElement(doc, parent, "cPais", "1058");
                AppendElement(doc, parent, "xPais", "BRASIL");
            }
            else
            {
                AppendElement(doc, parent, "fone", "81999999999");
            }
        }

        private static void AppendParticipant(
            XmlDocument doc,
            XmlElement infCte,
            string elementName,
            string addressElementName,
            int ambiente,
            CteParticipantOptions participant,
            string documentFallback,
            string cnpjFallback,
            string ieFallback,
            string cityCodeFallback,
            string cityFallback,
            string ufFallback,
            string streetFallback,
            string numberFallback,
            string cepFallback)
        {
            var element = AppendElement(doc, infCte, elementName);
            AppendDocumento(
                doc,
                element,
                FirstNotEmpty(participant.Documento, documentFallback),
                cnpjFallback);
            AppendElement(doc, element, "IE", FirstNotEmpty(participant.InscricaoEstadual, ieFallback));
            AppendElement(doc, element, "xNome", NomeParaAmbiente(ambiente, participant.Nome));
            AppendEndereco(
                doc,
                AppendElement(doc, element, addressElementName),
                FirstNotEmpty(participant.Logradouro, streetFallback),
                FirstNotEmpty(participant.Numero, numberFallback),
                FirstNotEmpty(participant.Bairro, "CENTRO"),
                FirstNotEmpty(participant.CodigoMunicipio, cityCodeFallback),
                FirstNotEmpty(participant.Municipio, cityFallback),
                FirstNotEmpty(participant.Cep, cepFallback),
                FirstNotEmpty(participant.Uf, ufFallback),
                incluirPais: true);
        }

        private static string FirstNotEmpty(string first, string fallback)
            => string.IsNullOrWhiteSpace(first) ? fallback : first;

        private static string NomeParaAmbiente(int ambiente, string nomeEfetivo)
            => ambiente == 2 ? HomologacaoNome : FirstNotEmpty(nomeEfetivo, HomologacaoNome);

        private static void AppendDocumento(
            XmlDocument doc,
            XmlElement parent,
            string documento,
            string fallbackCnpj)
        {
            var digits = OnlyDigits(documento);
            if (digits.Length == 11)
            {
                AppendElement(doc, parent, "CPF", digits);
                return;
            }

            AppendElement(doc, parent, "CNPJ", digits.Length == 14 ? digits : OnlyDigits(fallbackCnpj));
        }

        private static string Money(decimal value)
            => value.ToString("0.00", CultureInfo.InvariantCulture);

        private static string Quantity(decimal value)
            => value.ToString("0.0000", CultureInfo.InvariantCulture);

        private static string SignCteXml(string xml, X509Certificate2 certificate)
        {
            var doc = new XmlDocument { PreserveWhitespace = false };
            doc.LoadXml(xml);

            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("cte", CteNamespace);

            var cteNode = doc.SelectSingleNode("/cte:CTe", nsmgr) as XmlElement
                ?? throw new InvalidOperationException("Nao foi possivel localizar o elemento CTe.");
            var infCteNode = doc.SelectSingleNode("/cte:CTe/cte:infCte", nsmgr) as XmlElement
                ?? throw new InvalidOperationException("Nao foi possivel localizar o elemento infCte.");

            var id = infCteNode.GetAttribute("Id");
            if (string.IsNullOrWhiteSpace(id))
                throw new InvalidOperationException("O atributo Id do infCte nao pode estar vazio.");

            using var rsa = certificate.GetRSAPrivateKey()
                ?? throw new InvalidOperationException("O certificado CT-e nao possui chave privada RSA.");

            var signedXml = new SignedXml(doc)
            {
                SigningKey = rsa
            };
            signedXml.SignedInfo!.CanonicalizationMethod = SignedXml.XmlDsigCanonicalizationUrl;
            signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;

            var reference = new Reference("#" + id)
            {
                DigestMethod = SignedXml.XmlDsigSHA1Url
            };
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.AddTransform(new XmlDsigC14NTransform());
            signedXml.AddReference(reference);

            var keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(certificate));
            signedXml.KeyInfo = keyInfo;

            signedXml.ComputeSignature();
            var signature = signedXml.GetXml();
            cteNode.AppendChild(doc.ImportNode(signature, true));

            var verifier = new SignedXml(doc);
            verifier.LoadXml(signature);
            if (!verifier.CheckSignature(certificate, true))
                throw new InvalidOperationException("A assinatura digital do CT-e nao passou na validacao local.");

            return doc.DocumentElement!.OuterXml;
        }

        private static X509Certificate2 LoadCertificate(string path, string password)
        {
            X509Certificate2? certificate = null;
            try
            {
                certificate = new X509Certificate2(
                    path,
                    password,
                    X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

                if (!certificate.HasPrivateKey)
                    throw new InvalidOperationException("O certificado nao possui chave privada RSA.");

                return certificate;
            }
            catch (CryptographicException)
            {
                certificate?.Dispose();

                certificate = new X509Certificate2(
                    path,
                    password,
                    X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

                if (!certificate.HasPrivateKey)
                    throw new InvalidOperationException("O certificado nao possui chave privada RSA.");

                return certificate;
            }
        }

        private static X509Certificate2? TryLoadCertificateFromCurrentUserStore(string thumbprint)
        {
            if (!OperatingSystem.IsWindows())
                return null;

            using var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, validOnly: false);

            foreach (var certificate in certificates)
            {
                if (certificate.HasPrivateKey)
                    return certificate;

                certificate.Dispose();
            }

            return null;
        }

        private static string CompressToBase64(string xml)
        {
            var bytes = Encoding.UTF8.GetBytes(xml);

            using var input = new MemoryStream(bytes);
            using var output = new MemoryStream();
            using (var gzip = new GZipStream(output, CompressionMode.Compress))
            {
                input.CopyTo(gzip);
            }

            return Convert.ToBase64String(output.ToArray());
        }

        private static string WrapRecepcaoInSoapEnvelope(string compressedBase64)
        {
            const string soapNamespace = "http://www.w3.org/2003/05/soap-envelope";

            var soap = new XmlDocument { PreserveWhitespace = true };
            var envelope = soap.CreateElement("soap12", "Envelope", soapNamespace);
            envelope.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            envelope.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            soap.AppendChild(envelope);

            var body = soap.CreateElement("soap12", "Body", soapNamespace);
            envelope.AppendChild(body);

            var dados = soap.CreateElement("cteDadosMsg", ServiceNamespace);
            dados.InnerText = compressedBase64;
            body.AppendChild(dados);

            return soap.OuterXml;
        }

        private static XmlElement AppendElement(XmlDocument doc, XmlElement parent, string name)
        {
            var element = doc.CreateElement(name, CteNamespace);
            parent.AppendChild(element);
            return element;
        }

        private static XmlElement AppendElement(XmlDocument doc, XmlElement parent, string name, string value)
        {
            var element = AppendElement(doc, parent, name);
            element.InnerText = value;
            return element;
        }

        private static string ExtractChave(string cteXml)
        {
            var doc = new XmlDocument { PreserveWhitespace = false };
            doc.LoadXml(cteXml);

            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("cte", CteNamespace);

            var infCteNode = doc.SelectSingleNode("/cte:CTe/cte:infCte", nsmgr) as XmlElement
                ?? throw new InvalidOperationException("Nao foi possivel localizar a chave do CT-e.");

            var id = infCteNode.GetAttribute("Id");
            return id.StartsWith("CTe", StringComparison.Ordinal) ? id[3..] : id;
        }

        private static int? ReadInt(string xml, string parentName, string childName)
        {
            var text = ReadText(xml, parentName, childName);
            return int.TryParse(text, out var value) ? value : null;
        }

        private static string DescribeException(Exception exception)
        {
            var sb = new StringBuilder();
            Exception? current = exception;
            while (current is not null)
            {
                if (sb.Length > 0)
                    sb.Append(" | Inner: ");

                sb.Append(current.GetType().FullName);
                sb.Append(": ");
                sb.Append(current.Message);
                current = current.InnerException;
            }

            return sb.ToString();
        }

        private static string? ReadText(string xml, string parentName, string childName)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return null;

            var doc = new XmlDocument { PreserveWhitespace = false };
            doc.LoadXml(xml);

            var node = doc.SelectSingleNode($"//*[local-name()='{parentName}']/*[local-name()='{childName}']");
            return node?.InnerText;
        }

        private static string Hash(string value)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(value));
            var builder = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

        private static string BuildAccessKey(
            int codigoUf,
            DateTimeOffset emissao,
            string cnpj,
            int modelo,
            int serie,
            int numero,
            int tipoEmissao,
            string codigoControle)
        {
            var keyWithoutDigit =
                codigoUf.ToString("D2") +
                emissao.ToString("yyMM") +
                OnlyDigits(cnpj).PadLeft(14, '0')[..14] +
                modelo.ToString("D2") +
                serie.ToString("D3") +
                numero.ToString("D9") +
                tipoEmissao.ToString() +
                OnlyDigits(codigoControle).PadLeft(8, '0')[..8];

            return keyWithoutDigit + CalculateModulo11Digit(keyWithoutDigit).ToString();
        }

        private static int CalculateModulo11Digit(string value)
        {
            var weight = 2;
            var sum = 0;

            for (var i = value.Length - 1; i >= 0; i--)
            {
                sum += (value[i] - '0') * weight;
                weight++;
                if (weight > 9)
                    weight = 2;
            }

            var digit = 11 - (sum % 11);
            return digit >= 10 ? 0 : digit;
        }

        private static string OnlyDigits(string value)
        {
            var sb = new StringBuilder(value.Length);
            foreach (var character in value)
            {
                if (character is >= '0' and <= '9')
                    sb.Append(character);
            }

            return sb.ToString();
        }
    }
}
