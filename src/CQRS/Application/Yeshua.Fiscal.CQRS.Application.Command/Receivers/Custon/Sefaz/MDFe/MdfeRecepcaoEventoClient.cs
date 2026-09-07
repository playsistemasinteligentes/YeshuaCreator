using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Command.Receivers
{
    internal sealed record MdfeEncerramentoSefazOptions(
        int CodigoOrgao,
        int Ambiente,
        string Cnpj,
        string ChaveAcesso,
        string ProtocoloAutorizacao,
        string CertificatePath,
        string CertificatePassword,
        int CodigoUfEncerramento,
        int CodigoMunicipioEncerramento,
        int SequenciaEvento,
        string Endpoint,
        string SoapAction,
        string ContentMediaType,
        int TimeoutSeconds)
    {
        public const string TipoEvento = "110112";

        public static MdfeEncerramentoSefazOptions FromEnvironment()
        {
            var fixedOptions = new MdfeEncerramentoSefazOptions(
                CodigoOrgao: 31,
                Ambiente: 1,
                Cnpj: "57152543000141",
                ChaveAcesso: "31260757152543000141580200000056051000560591",
                ProtocoloAutorizacao: "931260037261399",
                CertificatePath: @"C:\Users\AngeloRicardoFontana\Downloads\57152543000141.pfx",
                CertificatePassword: "27111983",
                CodigoUfEncerramento: 31,
                CodigoMunicipioEncerramento: 3167202,
                SequenciaEvento: 1,
                Endpoint: "https://mdfe.svrs.rs.gov.br/ws/MDFeRecepcaoEvento/MDFeRecepcaoEvento.asmx",
                SoapAction: "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoEvento/mdfeRecepcaoEvento",
                ContentMediaType: "application/soap+xml",
                TimeoutSeconds: 120);

            return fixedOptions with
            {
                CodigoOrgao = GetInt("YESHUA_MDFE_CUF", fixedOptions.CodigoOrgao),
                Ambiente = GetInt("YESHUA_MDFE_AMBIENTE", fixedOptions.Ambiente),
                Cnpj = OnlyDigits(GetValue("YESHUA_MDFE_CNPJ", fixedOptions.Cnpj)),
                ChaveAcesso = OnlyDigits(GetValue("YESHUA_MDFE_CHAVE", fixedOptions.ChaveAcesso)),
                ProtocoloAutorizacao = OnlyDigits(GetValue("YESHUA_MDFE_PROTOCOLO", fixedOptions.ProtocoloAutorizacao)),
                CertificatePath = GetValue("YESHUA_MDFE_CERT", fixedOptions.CertificatePath),
                CertificatePassword = GetValue("YESHUA_MDFE_SENHA", fixedOptions.CertificatePassword),
                CodigoUfEncerramento = GetInt("YESHUA_MDFE_UF_ENCERRAMENTO", fixedOptions.CodigoUfEncerramento),
                CodigoMunicipioEncerramento = GetInt("YESHUA_MDFE_MUNICIPIO_ENCERRAMENTO", fixedOptions.CodigoMunicipioEncerramento),
                SequenciaEvento = GetInt("YESHUA_MDFE_SEQ", fixedOptions.SequenciaEvento),
                Endpoint = GetValue("YESHUA_MDFE_RECEPCAO_EVENTO_ENDPOINT", fixedOptions.Endpoint),
                SoapAction = GetValue("YESHUA_MDFE_RECEPCAO_EVENTO_SOAP_ACTION", fixedOptions.SoapAction),
                ContentMediaType = GetValue("YESHUA_MDFE_CONTENT_TYPE", fixedOptions.ContentMediaType),
                TimeoutSeconds = GetInt("YESHUA_MDFE_TIMEOUT_SECONDS", fixedOptions.TimeoutSeconds)
            };
        }

        public string EventId => $"ID{TipoEvento}{ChaveAcesso}{SequenciaEvento:D2}";

        public void Validate()
        {
            ValidateEnvironment();
            ValidateDigits(CodigoOrgao.ToString("D2"), 2, nameof(CodigoOrgao));
            ValidateDigits(Cnpj, 14, nameof(Cnpj));
            ValidateDigits(ChaveAcesso, 44, nameof(ChaveAcesso));
            ValidateDigits(ProtocoloAutorizacao, 15, nameof(ProtocoloAutorizacao));

            if (!ChaveAcesso.StartsWith(CodigoOrgao.ToString("D2"), StringComparison.Ordinal))
                throw new InvalidOperationException("O cOrgao nao corresponde a UF presente na chave do MDF-e.");

            if (!string.Equals(ChaveAcesso.Substring(6, 14), Cnpj, StringComparison.Ordinal))
                throw new InvalidOperationException("O CNPJ configurado nao corresponde ao CNPJ presente na chave do MDF-e.");

            var municipio = CodigoMunicipioEncerramento.ToString("D7");
            if (!municipio.StartsWith(CodigoUfEncerramento.ToString("D2"), StringComparison.Ordinal))
                throw new InvalidOperationException("O municipio de encerramento nao pertence a UF configurada.");

            if (SequenciaEvento is < 1 or > 99)
                throw new InvalidOperationException("A sequencia do evento deve estar entre 1 e 99.");

            if (string.IsNullOrWhiteSpace(Endpoint))
                throw new InvalidOperationException("O endpoint MDF-e deve ser informado.");

            if (string.IsNullOrWhiteSpace(CertificatePath))
                throw new InvalidOperationException("O caminho do certificado MDF-e deve ser informado.");

            if (!File.Exists(CertificatePath))
                throw new FileNotFoundException("Certificado MDF-e nao encontrado.", CertificatePath);

            if (string.IsNullOrWhiteSpace(CertificatePassword))
                throw new InvalidOperationException("A senha do certificado MDF-e deve ser informada.");
        }

        private void ValidateEnvironment()
        {
            if (Ambiente is not 1 and not 2)
                throw new InvalidOperationException("O ambiente MDF-e deve ser 1 ou 2.");
        }

        private static void ValidateDigits(string value, int length, string fieldName)
        {
            if (value.Length != length || value.Any(character => character is < '0' or > '9'))
                throw new InvalidOperationException($"{fieldName} deve possuir exatamente {length} digitos.");
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
    }

    internal sealed record MdfeEncerramentoSefazResult(
        bool Encerrado,
        int CodigoRetorno,
        string Motivo,
        string ChaveAcesso,
        string? Protocolo,
        int HttpStatusCode,
        string EventoXml,
        string SoapResponse);

    internal static class MdfeRecepcaoEventoClient
    {
        private const string ServiceNamespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoEvento";
        private const string MdfeNamespace = "http://www.portalfiscal.inf.br/mdfe";

        public static async Task<MdfeEncerramentoSefazResult> EncerrarAsync(
            MdfeEncerramentoSefazOptions options,
            CancellationToken cancellationToken = default)
        {
            options.Validate();

            using var signingCertificate = LoadCertificate(options.CertificatePath, options.CertificatePassword);
            var eventoXml = BuildEventoXml(options);
            var signedEventoXml = SignEventoXml(eventoXml, signingCertificate);
            ValidateNoFormattingWhitespace(signedEventoXml, "evento MDF-e assinado");

            var soapEnvelope = WrapInSoapEnvelope(signedEventoXml, options.CodigoOrgao);
            ValidateNoFormattingWhitespace(soapEnvelope, "envelope SOAP MDF-e");

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
            if (!string.IsNullOrWhiteSpace(options.SoapAction))
            {
                request.Content.Headers.ContentType.Parameters.Add(
                    new NameValueHeaderValue("action", $"\"{options.SoapAction}\""));
            }

            request.Headers.ExpectContinue = false;
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            var response = await httpClient.SendAsync(request, cancellationToken);
            var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);

            return ParseResult(response.StatusCode, responseBody, signedEventoXml, options.ChaveAcesso);
        }

        private static MdfeEncerramentoSefazResult ParseResult(
            HttpStatusCode httpStatusCode,
            string responseBody,
            string eventoXml,
            string fallbackChave)
        {
            var codigo = 0;
            var motivo = string.Empty;
            var chave = fallbackChave;
            string? protocolo = null;

            if (!string.IsNullOrWhiteSpace(responseBody))
            {
                var doc = new XmlDocument { PreserveWhitespace = true };
                doc.LoadXml(responseBody);

                _ = int.TryParse(ReadFirst(doc, "cStat"), out codigo);
                motivo = ReadFirst(doc, "xMotivo") ?? string.Empty;
                chave = ReadFirst(doc, "chMDFe") ?? fallbackChave;
                protocolo = ReadFirst(doc, "nProt");
            }

            return new MdfeEncerramentoSefazResult(
                Encerrado: codigo == 135,
                CodigoRetorno: codigo,
                Motivo: motivo,
                ChaveAcesso: chave,
                Protocolo: protocolo,
                HttpStatusCode: (int)httpStatusCode,
                EventoXml: eventoXml,
                SoapResponse: responseBody);
        }

        private static string? ReadFirst(XmlDocument doc, string localName)
        {
            return doc.SelectSingleNode($"//*[local-name()='{localName}']")?.InnerText;
        }

        private static string BuildEventoXml(MdfeEncerramentoSefazOptions options)
        {
            var now = DateTimeOffset.Now;
            var doc = new XmlDocument { PreserveWhitespace = false };
            var evento = doc.CreateElement("eventoMDFe", MdfeNamespace);
            evento.SetAttribute("versao", "3.00");
            doc.AppendChild(evento);

            var infEvento = doc.CreateElement("infEvento", MdfeNamespace);
            infEvento.SetAttribute("Id", options.EventId);
            evento.AppendChild(infEvento);

            AppendElement(doc, infEvento, "cOrgao", options.CodigoOrgao.ToString(), MdfeNamespace);
            AppendElement(doc, infEvento, "tpAmb", options.Ambiente.ToString(), MdfeNamespace);
            AppendElement(doc, infEvento, "CNPJ", options.Cnpj, MdfeNamespace);
            AppendElement(doc, infEvento, "chMDFe", options.ChaveAcesso, MdfeNamespace);
            AppendElement(doc, infEvento, "dhEvento", now.ToString("yyyy-MM-dd'T'HH:mm:sszzz"), MdfeNamespace);
            AppendElement(doc, infEvento, "tpEvento", MdfeEncerramentoSefazOptions.TipoEvento, MdfeNamespace);
            AppendElement(doc, infEvento, "nSeqEvento", options.SequenciaEvento.ToString(), MdfeNamespace);

            var detEvento = doc.CreateElement("detEvento", MdfeNamespace);
            detEvento.SetAttribute("versaoEvento", "3.00");
            infEvento.AppendChild(detEvento);

            var encerramento = doc.CreateElement("evEncMDFe", MdfeNamespace);
            detEvento.AppendChild(encerramento);
            AppendElement(doc, encerramento, "descEvento", "Encerramento", MdfeNamespace);
            AppendElement(doc, encerramento, "nProt", options.ProtocoloAutorizacao, MdfeNamespace);
            AppendElement(doc, encerramento, "dtEnc", now.ToString("yyyy-MM-dd"), MdfeNamespace);
            AppendElement(doc, encerramento, "cUF", options.CodigoUfEncerramento.ToString(), MdfeNamespace);
            AppendElement(doc, encerramento, "cMun", options.CodigoMunicipioEncerramento.ToString(), MdfeNamespace);

            return doc.OuterXml;
        }

        private static string SignEventoXml(string xml, X509Certificate2 certificate)
        {
            var doc = new XmlDocument { PreserveWhitespace = false };
            doc.LoadXml(xml);

            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("mdfe", MdfeNamespace);

            var eventoNode = doc.SelectSingleNode("/mdfe:eventoMDFe", nsmgr) as XmlElement
                ?? throw new InvalidOperationException("Nao foi possivel localizar o elemento eventoMDFe.");

            var infEventoNode = doc.SelectSingleNode("/mdfe:eventoMDFe/mdfe:infEvento", nsmgr) as XmlElement
                ?? throw new InvalidOperationException("Nao foi possivel localizar o elemento infEvento.");

            var id = infEventoNode.GetAttribute("Id");
            if (string.IsNullOrWhiteSpace(id))
                throw new InvalidOperationException("O atributo Id do infEvento nao pode estar vazio.");

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
            eventoNode.AppendChild(doc.ImportNode(signature, true));

            var verifier = new SignedXml(doc);
            verifier.LoadXml(signature);
            if (!verifier.CheckSignature(certificate, true))
                throw new InvalidOperationException("A assinatura digital do evento MDF-e nao passou na validacao local.");

            return doc.DocumentElement!.OuterXml;
        }

        private static string WrapInSoapEnvelope(string innerXml, int codigoOrgao)
        {
            const string soapNamespace = "http://www.w3.org/2003/05/soap-envelope";

            var evento = new XmlDocument { PreserveWhitespace = false };
            evento.LoadXml(innerXml);

            var soap = new XmlDocument { PreserveWhitespace = true };
            var envelope = soap.CreateElement("soap12", "Envelope", soapNamespace);
            soap.AppendChild(envelope);

            var header = soap.CreateElement("soap12", "Header", soapNamespace);
            envelope.AppendChild(header);

            var cabecalho = soap.CreateElement("mdfeCabecMsg", ServiceNamespace);
            header.AppendChild(cabecalho);
            AppendElement(soap, cabecalho, "cUF", codigoOrgao.ToString(), ServiceNamespace);
            AppendElement(soap, cabecalho, "versaoDados", "3.00", ServiceNamespace);

            var body = soap.CreateElement("soap12", "Body", soapNamespace);
            envelope.AppendChild(body);

            var dados = soap.CreateElement("mdfeDadosMsg", ServiceNamespace);
            body.AppendChild(dados);
            dados.AppendChild(soap.ImportNode(evento.DocumentElement!, true));

            return soap.OuterXml;
        }

        private static X509Certificate2 LoadCertificate(string path, string password)
        {
            using var sourceCertificate = new X509Certificate2(
                path,
                password,
                X509KeyStorageFlags.EphemeralKeySet | X509KeyStorageFlags.Exportable);

            var storeCertificate = TryLoadCertificateFromCurrentUserStore(sourceCertificate.Thumbprint);
            if (storeCertificate is not null)
                return storeCertificate;

            X509Certificate2? certificate = null;
            try
            {
                certificate = new X509Certificate2(
                    path,
                    password,
                    X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

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
                    X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

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

        private static void AppendElement(XmlDocument doc, XmlElement parent, string name, string value, string xmlNamespace)
        {
            var element = doc.CreateElement(name, xmlNamespace);
            element.InnerText = value;
            parent.AppendChild(element);
        }

        private static void ValidateNoFormattingWhitespace(string xml, string description)
        {
            var doc = new XmlDocument { PreserveWhitespace = true };
            doc.LoadXml(xml);

            if (ContainsFormattingWhitespace(doc))
                throw new InvalidOperationException(
                    $"O {description} contem espacos ou quebras de linha entre as tags e seria rejeitado pelo SEFAZ.");
        }

        private static bool ContainsFormattingWhitespace(XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.NodeType is XmlNodeType.Whitespace or XmlNodeType.SignificantWhitespace ||
                    child.NodeType == XmlNodeType.Text && string.IsNullOrWhiteSpace(child.Value))
                {
                    return true;
                }

                if (ContainsFormattingWhitespace(child))
                    return true;
            }

            return false;
        }
    }
}
