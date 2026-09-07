using System;
using System.IO;
using System.IO.Compression;
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
    internal sealed record MdfeRecepcaoSincOptions(
        int Ambiente,
        int CodigoUf,
        string Endpoint,
        string SoapAction,
        string FallbackSoapAction,
        string ContentMediaType,
        string CertificatePath,
        string CertificatePassword,
        string CnpjEmitente,
        string RazaoSocial,
        string NomeFantasia,
        string InscricaoEstadual,
        string Endereco,
        string NumeroEndereco,
        string Bairro,
        string Cep,
        string CodigoMunicipioEmitente,
        string MunicipioEmitente,
        string UfEmitente,
        string CodigoMunicipioDescarga,
        string MunicipioDescarga,
        string UfDescarga,
        string CepDescarga,
        string Rntrc,
        string Placa,
        string Renavam,
        string TaraKg,
        string CapacidadeKg,
        string CapacidadeM3,
        string TipoRodado,
        string TipoCarroceria,
        string CondutorNome,
        string CondutorCpf,
        string CnpjResponsavelSeguro,
        string NomeSeguradora,
        string CnpjSeguradora,
        string NumeroApolice,
        string NumeroAverbacao,
        string NcmProdutoPredominante,
        string ChaveCTe,
        int TimeoutSeconds)
    {
        public static MdfeRecepcaoSincOptions FromEnvironment()
        {
            var fixedOptions = new MdfeRecepcaoSincOptions(
                Ambiente: 2,
                CodigoUf: 26,
                Endpoint: "https://mdfe-homologacao.svrs.rs.gov.br/ws/MDFeRecepcaoSinc/MDFeRecepcaoSinc.asmx",
                SoapAction: "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoSinc/mdfeRecepcao",
                FallbackSoapAction: "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoSinc",
                ContentMediaType: "application/soap+xml",
                CertificatePath: @"C:\Users\AngeloRicardoFontana\Downloads\63249950000174.pfx",
                CertificatePassword: "zanata123",
                CnpjEmitente: "63249950000174",
                RazaoSocial: "ZANATA LOGISTICA E TRANSPORTES LTDA",
                NomeFantasia: "ZANATA LOGISTICA",
                InscricaoEstadual: "128556188",
                Endereco: "RUA TESTE",
                NumeroEndereco: "100",
                Bairro: "CENTRO",
                Cep: "50000000",
                CodigoMunicipioEmitente: "2611606",
                MunicipioEmitente: "RECIFE",
                UfEmitente: "PE",
                CodigoMunicipioDescarga: "2607901",
                MunicipioDescarga: "JABOATAO DOS GUARARAPES",
                UfDescarga: "PE",
                CepDescarga: "54000000",
                Rntrc: "45861338",
                Placa: "ABC1D23",
                Renavam: "12345678901",
                TaraKg: "1000",
                CapacidadeKg: "10000",
                CapacidadeM3: "60",
                TipoRodado: "01",
                TipoCarroceria: "02",
                CondutorNome: "CONDUTOR HOMOLOGACAO",
                CondutorCpf: "11144477735",
                CnpjResponsavelSeguro: "63249950000174",
                NomeSeguradora: "PORTO SEGURO",
                CnpjSeguradora: "61198164000160",
                NumeroApolice: "06540713572",
                NumeroAverbacao: "73652309182",
                NcmProdutoPredominante: "87089990",
                ChaveCTe: "26260963249950000174570018131692871547162635",
                TimeoutSeconds: 120);

            return fixedOptions with
            {
                Endpoint = GetValue("YESHUA_MDFE_RECEPCAO_SINC_ENDPOINT", fixedOptions.Endpoint),
                SoapAction = GetValue("YESHUA_MDFE_RECEPCAO_SINC_SOAP_ACTION", fixedOptions.SoapAction),
                CertificatePath =
                    Environment.GetEnvironmentVariable("YESHUA_MDFE_CERT")
                    ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_CERTIFICATE_PATH")
                    ?? fixedOptions.CertificatePath,
                CertificatePassword =
                    Environment.GetEnvironmentVariable("YESHUA_MDFE_SENHA")
                    ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_CERTIFICATE_PASSWORD")
                    ?? fixedOptions.CertificatePassword,
                ChaveCTe =
                    OnlyDigits(Environment.GetEnvironmentVariable("YESHUA_MDFE_CHCTE") ?? fixedOptions.ChaveCTe),
                CepDescarga =
                    OnlyDigits(Environment.GetEnvironmentVariable("YESHUA_MDFE_CEP_DESCARGA") ?? fixedOptions.CepDescarga),
                CnpjResponsavelSeguro =
                    OnlyDigits(Environment.GetEnvironmentVariable("YESHUA_MDFE_SEGURO_RESPONSAVEL_CNPJ") ?? fixedOptions.CnpjResponsavelSeguro),
                NomeSeguradora =
                    GetValue("YESHUA_MDFE_SEGURADORA_NOME", fixedOptions.NomeSeguradora),
                CnpjSeguradora =
                    OnlyDigits(Environment.GetEnvironmentVariable("YESHUA_MDFE_SEGURADORA_CNPJ") ?? fixedOptions.CnpjSeguradora),
                NumeroApolice =
                    GetValue("YESHUA_MDFE_SEGURO_APOLICE", fixedOptions.NumeroApolice),
                NumeroAverbacao =
                    GetValue("YESHUA_MDFE_SEGURO_AVERBACAO", fixedOptions.NumeroAverbacao),
                NcmProdutoPredominante =
                    OnlyDigits(Environment.GetEnvironmentVariable("YESHUA_MDFE_NCM_PRODUTO_PREDOMINANTE") ?? fixedOptions.NcmProdutoPredominante),
                Placa =
                    OnlyDigitsLetters(Environment.GetEnvironmentVariable("YESHUA_MDFE_PLACA") ?? GenerateHomologacaoPlate()),
                TimeoutSeconds = GetInt("YESHUA_MDFE_TIMEOUT_SECONDS", fixedOptions.TimeoutSeconds)
            };
        }

        public void ValidateForSend()
        {
            if (Ambiente is not 1 and not 2)
                throw new InvalidOperationException("O ambiente do MDF-e deve ser 1 ou 2.");

            if (CodigoUf <= 0)
                throw new InvalidOperationException("O codigo UF do MDF-e deve ser informado.");

            if (string.IsNullOrWhiteSpace(Endpoint))
                throw new InvalidOperationException("O endpoint MDF-e deve ser informado.");

            if (string.IsNullOrWhiteSpace(CertificatePath))
                throw new InvalidOperationException("O caminho do certificado MDF-e deve ser informado.");

            if (!File.Exists(CertificatePath))
                throw new FileNotFoundException("Certificado MDF-e nao encontrado.", CertificatePath);

            if (string.IsNullOrWhiteSpace(CertificatePassword))
                throw new InvalidOperationException("A senha do certificado MDF-e deve ser informada.");

            ValidateDigits(CnpjEmitente, 14, nameof(CnpjEmitente));
            ValidateDigits(InscricaoEstadual, 9, nameof(InscricaoEstadual));
            ValidateDigits(CodigoMunicipioEmitente, 7, nameof(CodigoMunicipioEmitente));
            ValidateDigits(CodigoMunicipioDescarga, 7, nameof(CodigoMunicipioDescarga));
            ValidateDigits(Cep, 8, nameof(Cep));
            ValidateDigits(CepDescarga, 8, nameof(CepDescarga));
            ValidateDigits(OnlyDigits(ChaveCTe), 44, nameof(ChaveCTe));
            ValidateDigits(CnpjResponsavelSeguro, 14, nameof(CnpjResponsavelSeguro));
            ValidateDigits(CnpjSeguradora, 14, nameof(CnpjSeguradora));
            ValidateDigits(NcmProdutoPredominante, 8, nameof(NcmProdutoPredominante));

            if (!CodigoMunicipioEmitente.StartsWith(CodigoUf.ToString("D2"), StringComparison.Ordinal))
                throw new InvalidOperationException("O municipio emitente nao pertence a UF configurada do MDF-e.");

            if (string.IsNullOrWhiteSpace(NomeSeguradora))
                throw new InvalidOperationException("A seguradora do MDF-e deve ser informada.");

            if (string.IsNullOrWhiteSpace(NumeroApolice))
                throw new InvalidOperationException("A apolice do seguro MDF-e deve ser informada.");

            if (string.IsNullOrWhiteSpace(NumeroAverbacao))
                throw new InvalidOperationException("A averbacao do seguro MDF-e deve ser informada.");
        }

        private static string GetValue(string envName, string fallback)
        {
            return Environment.GetEnvironmentVariable(envName) ?? fallback;
        }

        private static int GetInt(string envName, int fallback)
        {
            var text = Environment.GetEnvironmentVariable(envName);
            return int.TryParse(text, out var value) && value > 0 ? value : fallback;
        }

        private static void ValidateDigits(string value, int length, string fieldName)
        {
            if (value.Length != length || value.Any(character => character is < '0' or > '9'))
                throw new InvalidOperationException($"{fieldName} deve possuir exatamente {length} digitos.");
        }

        private static string GenerateHomologacaoPlate()
        {
            return string.Concat(
                RandomLetter(),
                RandomLetter(),
                RandomLetter(),
                RandomDigit(),
                RandomLetter(),
                RandomDigit(),
                RandomDigit());
        }

        private static char RandomLetter()
        {
            return (char)('A' + RandomNumberGenerator.GetInt32(0, 26));
        }

        private static char RandomDigit()
        {
            return (char)('0' + RandomNumberGenerator.GetInt32(0, 10));
        }

        private static string OnlyDigits(string value)
        {
            var buffer = new StringBuilder(value.Length);
            foreach (var character in value)
            {
                if (character is >= '0' and <= '9')
                    buffer.Append(character);
            }

            return buffer.ToString();
        }

        private static string OnlyDigitsLetters(string value)
        {
            var buffer = new StringBuilder(value.Length);
            foreach (var character in value)
            {
                if (character is >= '0' and <= '9' or >= 'A' and <= 'Z' or >= 'a' and <= 'z')
                    buffer.Append(char.ToUpperInvariant(character));
            }

            return buffer.ToString();
        }
    }

    public sealed record MdfeRecepcaoSincResult(
        bool Autorizado,
        int CodigoRetorno,
        string Motivo,
        string Chave,
        string? Protocolo,
        int HttpStatusCode,
        string XmlMDFe,
        string SoapResponse);

    public static class MdfeRecepcaoSincHomologacaoClient
    {
        private const string ServiceNamespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoSinc";
        private const string MdfeNamespace = "http://www.portalfiscal.inf.br/mdfe";
        private const string HomologacaoTexto = "MDFE EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";

        public static MdfeRecepcaoSincResult Autorizar(string chaveCTe)
        {
            var options = MdfeRecepcaoSincOptions.FromEnvironment();
            if (!string.IsNullOrWhiteSpace(chaveCTe))
                options = options with { ChaveCTe = OnlyDigits(chaveCTe) };

            return AutorizarAsync(options).GetAwaiter().GetResult();
        }

        private static async Task<MdfeRecepcaoSincResult> AutorizarAsync(MdfeRecepcaoSincOptions options)
        {
            options.ValidateForSend();

            using var signingCertificate = LoadCertificate(options.CertificatePath, options.CertificatePassword);
            var mdfeXml = SignMdfeXml(BuildHomologMdfeXml(options), signingCertificate);
            var chave = ExtractChave(mdfeXml);
            var soapEnvelope = WrapRecepcaoInSoapEnvelope(CompressToBase64(mdfeXml));

            using var transportCertificate = LoadCertificate(options.CertificatePath, options.CertificatePassword);
            var response = await SendAsync(options, soapEnvelope, options.SoapAction, transportCertificate).ConfigureAwait(false);

            if ((HttpStatusCode)response.HttpStatusCode == HttpStatusCode.BadRequest &&
                string.IsNullOrWhiteSpace(response.SoapResponse) &&
                !string.IsNullOrWhiteSpace(options.FallbackSoapAction))
            {
                response = await SendAsync(options, soapEnvelope, options.FallbackSoapAction, transportCertificate).ConfigureAwait(false);
            }

            if (response.HttpStatusCode < 200 || response.HttpStatusCode > 299)
            {
                throw new InvalidOperationException(
                    $"SEFAZ MDF-e retornou HTTP {response.HttpStatusCode}. {response.SoapResponse}");
            }

            var codigoRetorno = ReadInt(response.SoapResponse, "infProt", "cStat")
                ?? ReadInt(response.SoapResponse, "retMDFe", "cStat")
                ?? 0;
            var motivo = ReadText(response.SoapResponse, "infProt", "xMotivo")
                ?? ReadText(response.SoapResponse, "retMDFe", "xMotivo")
                ?? string.Empty;
            var protocolo = ReadText(response.SoapResponse, "infProt", "nProt");
            var chaveRetorno = ReadText(response.SoapResponse, "infProt", "chMDFe") ?? chave;

            return response with
            {
                Autorizado = codigoRetorno == 100,
                CodigoRetorno = codigoRetorno,
                Motivo = motivo,
                Protocolo = protocolo,
                Chave = chaveRetorno,
                XmlMDFe = mdfeXml
            };
        }

        private static async Task<MdfeRecepcaoSincResult> SendAsync(
            MdfeRecepcaoSincOptions options,
            string soapEnvelope,
            string soapAction,
            X509Certificate2 certificate)
        {
            using var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                SslProtocols = SslProtocols.Tls12,
                UseProxy = false
            };
            handler.ClientCertificates.Add(certificate);

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
            if (!string.IsNullOrWhiteSpace(soapAction))
            {
                request.Content.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("action", $"\"{soapAction}\""));
            }

            request.Headers.ExpectContinue = false;
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            HttpResponseMessage response;
            try
            {
                response = await httpClient.SendAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is HttpRequestException or AuthenticationException or IOException)
            {
                if (SefazOpenSslHttpFallback.CanHandle(ex))
                {
                    var fallbackResponse = await SefazOpenSslHttpFallback.PostAsync(
                        options.Endpoint,
                        soapEnvelope,
                        $"{options.ContentMediaType}; charset=utf-8; action=\"{soapAction}\"",
                        options.CertificatePath,
                        options.CertificatePassword,
                        options.TimeoutSeconds).ConfigureAwait(false);

                    return new MdfeRecepcaoSincResult(
                        false,
                        0,
                        string.Empty,
                        string.Empty,
                        null,
                        fallbackResponse.StatusCode,
                        string.Empty,
                        fallbackResponse.Body);
                }

                throw new InvalidOperationException(
                    "Falha HTTP/SSL ao chamar SEFAZ MDF-e. " + DescribeException(ex),
                    ex);
            }

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return new MdfeRecepcaoSincResult(
                false,
                0,
                string.Empty,
                string.Empty,
                null,
                (int)response.StatusCode,
                string.Empty,
                responseBody);
        }

        private static string BuildHomologMdfeXml(MdfeRecepcaoSincOptions options)
        {
            var now = DateTimeOffset.Now;
            var serie = 1;
            var numero = RandomNumberGenerator.GetInt32(1, 999999999);
            var codigoControle = RandomNumberGenerator.GetInt32(1, 99999999).ToString("D8");
            var chave = BuildAccessKey(
                options.CodigoUf,
                now,
                options.CnpjEmitente,
                modelo: 58,
                serie,
                numero,
                tipoEmissao: 1,
                codigoControle);

            var doc = new XmlDocument { PreserveWhitespace = false };
            var mdfe = doc.CreateElement("MDFe", MdfeNamespace);
            doc.AppendChild(mdfe);

            var infMDFe = doc.CreateElement("infMDFe", MdfeNamespace);
            infMDFe.SetAttribute("versao", "3.00");
            infMDFe.SetAttribute("Id", "MDFe" + chave);
            mdfe.AppendChild(infMDFe);

            AppendIde(doc, infMDFe, options, now, serie, numero, codigoControle, chave);
            AppendEmitente(doc, infMDFe, options);
            AppendRodoviario(doc, infMDFe, options);
            AppendDocumentos(doc, infMDFe, options);
            AppendSeguro(doc, infMDFe, options);
            AppendProdutoPredominante(doc, infMDFe, options);
            AppendTotais(doc, infMDFe);
            AppendElement(doc, infMDFe, "infAdic", string.Empty);
            AppendElement(doc, (XmlElement)infMDFe.LastChild!, "infCpl", HomologacaoTexto);

            var infMDFeSupl = AppendElement(doc, mdfe, "infMDFeSupl");
            AppendElement(
                doc,
                infMDFeSupl,
                "qrCodMDFe",
                $"https://dfe-portal.svrs.rs.gov.br/mdfe/qrCode?chMDFe={chave}&tpAmb={options.Ambiente}");

            return doc.OuterXml;
        }

        private static void AppendIde(
            XmlDocument doc,
            XmlElement infMDFe,
            MdfeRecepcaoSincOptions options,
            DateTimeOffset now,
            int serie,
            int numero,
            string codigoControle,
            string chave)
        {
            var ide = AppendElement(doc, infMDFe, "ide");
            AppendElement(doc, ide, "cUF", options.CodigoUf.ToString());
            AppendElement(doc, ide, "tpAmb", options.Ambiente.ToString());
            AppendElement(doc, ide, "tpEmit", "1");
            AppendElement(doc, ide, "mod", "58");
            AppendElement(doc, ide, "serie", serie.ToString());
            AppendElement(doc, ide, "nMDF", numero.ToString());
            AppendElement(doc, ide, "cMDF", codigoControle);
            AppendElement(doc, ide, "cDV", chave[^1].ToString());
            AppendElement(doc, ide, "modal", "1");
            AppendElement(doc, ide, "dhEmi", now.ToString("yyyy-MM-dd'T'HH:mm:sszzz"));
            AppendElement(doc, ide, "tpEmis", "1");
            AppendElement(doc, ide, "procEmi", "0");
            AppendElement(doc, ide, "verProc", "YESHUA-MDFE-001");
            AppendElement(doc, ide, "UFIni", options.UfEmitente);
            AppendElement(doc, ide, "UFFim", options.UfDescarga);

            var infMunCarrega = AppendElement(doc, ide, "infMunCarrega");
            AppendElement(doc, infMunCarrega, "cMunCarrega", options.CodigoMunicipioEmitente);
            AppendElement(doc, infMunCarrega, "xMunCarrega", options.MunicipioEmitente);
            AppendElement(doc, ide, "dhIniViagem", now.ToString("yyyy-MM-dd'T'HH:mm:sszzz"));
        }

        private static void AppendEmitente(XmlDocument doc, XmlElement infMDFe, MdfeRecepcaoSincOptions options)
        {
            var emit = AppendElement(doc, infMDFe, "emit");
            AppendElement(doc, emit, "CNPJ", options.CnpjEmitente);
            AppendElement(doc, emit, "IE", options.InscricaoEstadual);
            AppendElement(doc, emit, "xNome", options.RazaoSocial);
            AppendElement(doc, emit, "xFant", options.NomeFantasia);

            var enderEmit = AppendElement(doc, emit, "enderEmit");
            AppendElement(doc, enderEmit, "xLgr", options.Endereco);
            AppendElement(doc, enderEmit, "nro", options.NumeroEndereco);
            AppendElement(doc, enderEmit, "xBairro", options.Bairro);
            AppendElement(doc, enderEmit, "cMun", options.CodigoMunicipioEmitente);
            AppendElement(doc, enderEmit, "xMun", options.MunicipioEmitente);
            AppendElement(doc, enderEmit, "CEP", options.Cep);
            AppendElement(doc, enderEmit, "UF", options.UfEmitente);
        }

        private static void AppendRodoviario(XmlDocument doc, XmlElement infMDFe, MdfeRecepcaoSincOptions options)
        {
            var infModal = AppendElement(doc, infMDFe, "infModal");
            infModal.SetAttribute("versaoModal", "3.00");

            var rodo = AppendElement(doc, infModal, "rodo");
            var infANTT = AppendElement(doc, rodo, "infANTT");
            AppendElement(doc, infANTT, "RNTRC", options.Rntrc);

            var infContratante = AppendElement(doc, infANTT, "infContratante");
            AppendElement(doc, infContratante, "CNPJ", options.CnpjEmitente);

            var infPag = AppendElement(doc, infANTT, "infPag");
            AppendElement(doc, infPag, "xNome", options.RazaoSocial);
            AppendElement(doc, infPag, "CNPJ", options.CnpjEmitente);

            var comp = AppendElement(doc, infPag, "Comp");
            AppendElement(doc, comp, "tpComp", "99");
            AppendElement(doc, comp, "vComp", "1000.00");
            AppendElement(doc, comp, "xComp", "FRETE");

            AppendElement(doc, infPag, "vContrato", "1000.00");
            AppendElement(doc, infPag, "indPag", "0");

            var infBanc = AppendElement(doc, infPag, "infBanc");
            AppendElement(doc, infBanc, "codBanco", "001");
            AppendElement(doc, infBanc, "codAgencia", "0001");

            var veicTracao = AppendElement(doc, rodo, "veicTracao");
            AppendElement(doc, veicTracao, "cInt", "TRACAO01");
            AppendElement(doc, veicTracao, "placa", OnlyDigitsLetters(options.Placa));
            AppendElement(doc, veicTracao, "RENAVAM", OnlyDigits(options.Renavam));
            AppendElement(doc, veicTracao, "tara", OnlyDigits(options.TaraKg));
            AppendElement(doc, veicTracao, "capKG", OnlyDigits(options.CapacidadeKg));
            AppendElement(doc, veicTracao, "capM3", OnlyDigits(options.CapacidadeM3));

            var condutor = AppendElement(doc, veicTracao, "condutor");
            AppendElement(doc, condutor, "xNome", options.CondutorNome);
            AppendElement(doc, condutor, "CPF", OnlyDigits(options.CondutorCpf));

            AppendElement(doc, veicTracao, "tpRod", options.TipoRodado);
            AppendElement(doc, veicTracao, "tpCar", options.TipoCarroceria);
            AppendElement(doc, veicTracao, "UF", options.UfEmitente);
        }

        private static void AppendDocumentos(XmlDocument doc, XmlElement infMDFe, MdfeRecepcaoSincOptions options)
        {
            var infDoc = AppendElement(doc, infMDFe, "infDoc");
            var descarga = AppendElement(doc, infDoc, "infMunDescarga");
            AppendElement(doc, descarga, "cMunDescarga", options.CodigoMunicipioDescarga);
            AppendElement(doc, descarga, "xMunDescarga", options.MunicipioDescarga);

            var infCTe = AppendElement(doc, descarga, "infCTe");
            AppendElement(doc, infCTe, "chCTe", OnlyDigits(options.ChaveCTe));
        }

        private static void AppendSeguro(XmlDocument doc, XmlElement infMDFe, MdfeRecepcaoSincOptions options)
        {
            var seg = AppendElement(doc, infMDFe, "seg");
            var infResp = AppendElement(doc, seg, "infResp");
            AppendElement(doc, infResp, "respSeg", "1");
            AppendElement(doc, infResp, "CNPJ", OnlyDigits(options.CnpjResponsavelSeguro));

            var infSeg = AppendElement(doc, seg, "infSeg");
            AppendElement(doc, infSeg, "xSeg", options.NomeSeguradora);
            AppendElement(doc, infSeg, "CNPJ", OnlyDigits(options.CnpjSeguradora));
            AppendElement(doc, seg, "nApol", options.NumeroApolice);
            AppendElement(doc, seg, "nAver", options.NumeroAverbacao);
        }

        private static void AppendProdutoPredominante(XmlDocument doc, XmlElement infMDFe, MdfeRecepcaoSincOptions options)
        {
            var prodPred = AppendElement(doc, infMDFe, "prodPred");
            AppendElement(doc, prodPred, "tpCarga", "05");
            AppendElement(doc, prodPred, "xProd", "PRODUTO HOMOLOGACAO");
            AppendElement(doc, prodPred, "NCM", OnlyDigits(options.NcmProdutoPredominante));

            var infLotacao = AppendElement(doc, prodPred, "infLotacao");
            var infLocalCarrega = AppendElement(doc, infLotacao, "infLocalCarrega");
            AppendElement(doc, infLocalCarrega, "CEP", OnlyDigits(options.Cep));

            var infLocalDescarrega = AppendElement(doc, infLotacao, "infLocalDescarrega");
            AppendElement(doc, infLocalDescarrega, "CEP", OnlyDigits(options.CepDescarga));
        }

        private static void AppendTotais(XmlDocument doc, XmlElement infMDFe)
        {
            var tot = AppendElement(doc, infMDFe, "tot");
            AppendElement(doc, tot, "qCTe", "1");
            AppendElement(doc, tot, "vCarga", "1000.00");
            AppendElement(doc, tot, "cUnid", "01");
            AppendElement(doc, tot, "qCarga", "100.0000");
        }

        private static string SignMdfeXml(string xml, X509Certificate2 certificate)
        {
            var doc = new XmlDocument { PreserveWhitespace = false };
            doc.LoadXml(xml);

            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("mdfe", MdfeNamespace);

            var mdfeNode = doc.SelectSingleNode("/mdfe:MDFe", nsmgr) as XmlElement
                ?? throw new InvalidOperationException("Nao foi possivel localizar o elemento MDFe.");
            var infMDFeNode = doc.SelectSingleNode("/mdfe:MDFe/mdfe:infMDFe", nsmgr) as XmlElement
                ?? throw new InvalidOperationException("Nao foi possivel localizar o elemento infMDFe.");

            var id = infMDFeNode.GetAttribute("Id");
            if (string.IsNullOrWhiteSpace(id))
                throw new InvalidOperationException("O atributo Id do infMDFe nao pode estar vazio.");

            using var rsa = certificate.GetRSAPrivateKey()
                ?? throw new InvalidOperationException("O certificado MDF-e nao possui chave privada RSA.");

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
            mdfeNode.AppendChild(doc.ImportNode(signature, true));

            var verifier = new SignedXml(doc);
            verifier.LoadXml(signature);
            if (!verifier.CheckSignature(certificate, true))
                throw new InvalidOperationException("A assinatura digital do MDF-e nao passou na validacao local.");

            return doc.DocumentElement!.OuterXml;
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

            var dados = soap.CreateElement("mdfeDadosMsg", ServiceNamespace);
            body.AppendChild(dados);
            dados.InnerText = compressedBase64;

            return soap.OuterXml;
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
                    throw new InvalidOperationException("O certificado MDF-e nao possui chave privada RSA.");

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
                    throw new InvalidOperationException("O certificado MDF-e nao possui chave privada RSA.");

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

        private static XmlElement AppendElement(XmlDocument doc, XmlElement parent, string name)
        {
            var element = doc.CreateElement(name, MdfeNamespace);
            parent.AppendChild(element);
            return element;
        }

        private static XmlElement AppendElement(XmlDocument doc, XmlElement parent, string name, string value)
        {
            var element = AppendElement(doc, parent, name);
            element.InnerText = value;
            return element;
        }

        private static void AppendElement(XmlDocument doc, XmlElement parent, string name, string value, string xmlNamespace)
        {
            var element = doc.CreateElement(name, xmlNamespace);
            element.InnerText = value;
            parent.AppendChild(element);
        }

        private static string ExtractChave(string mdfeXml)
        {
            var doc = new XmlDocument { PreserveWhitespace = false };
            doc.LoadXml(mdfeXml);

            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("mdfe", MdfeNamespace);

            var infMDFeNode = doc.SelectSingleNode("/mdfe:MDFe/mdfe:infMDFe", nsmgr) as XmlElement
                ?? throw new InvalidOperationException("Nao foi possivel localizar a chave do MDF-e.");

            var id = infMDFeNode.GetAttribute("Id");
            return id.StartsWith("MDFe", StringComparison.Ordinal) ? id[4..] : id;
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

        private static string OnlyDigitsLetters(string value)
        {
            var sb = new StringBuilder(value.Length);
            foreach (var character in value)
            {
                if (character is >= '0' and <= '9' or >= 'A' and <= 'Z' or >= 'a' and <= 'z')
                    sb.Append(char.ToUpperInvariant(character));
            }

            return sb.ToString();
        }
    }
}
