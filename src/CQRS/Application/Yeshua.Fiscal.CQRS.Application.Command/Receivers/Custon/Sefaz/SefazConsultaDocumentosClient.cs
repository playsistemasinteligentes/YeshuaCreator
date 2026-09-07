using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Command.Receivers
{
    internal sealed record SefazConsultaDocumentoResult(
        string TipoDocumento,
        bool Encontrado,
        bool Autorizado,
        int CodigoRetorno,
        string Motivo,
        string Chave,
        string? Protocolo,
        int HttpStatusCode,
        string SoapResponse,
        string? XmlStorageKey,
        string? XmlHash);

    internal static class CteConsultaV4HomologacaoClient
    {
        private const string ServiceNamespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeConsultaV4";
        private const string CteNamespace = "http://www.portalfiscal.inf.br/cte";
        private const string DefaultEndpoint = "https://homologacao.nfe.fazenda.sp.gov.br/CTeWS/WS/CTeConsultaV4.asmx";
        private const string SoapAction = "http://www.portalfiscal.inf.br/cte/wsdl/CTeConsultaV4/cteConsultaCT";

        public static SefazConsultaDocumentoResult Baixar(string chave)
        {
            return ConsultarAsync(chave, salvarXml: true).GetAwaiter().GetResult();
        }

        public static SefazConsultaDocumentoResult BaixarEPersistir(
            string chave,
            IDocumentoFiscalWriteRepository repository,
            ILogger logger,
            string correlationId)
        {
            var result = Baixar(chave);
            SefazFiscalDocumentStore.PersistirConsulta(repository, logger, correlationId, result);
            return result;
        }

        public static SefazConsultaDocumentoResult Consultar(string chave)
        {
            return ConsultarAsync(chave, salvarXml: false).GetAwaiter().GetResult();
        }

        private static async Task<SefazConsultaDocumentoResult> ConsultarAsync(string chave, bool salvarXml)
        {
            var baseOptions = CteRecepcaoSincV4Options.FromEnvironment();
            var endpoint = Environment.GetEnvironmentVariable("YESHUA_CTE_CONSULTA_ENDPOINT") ?? DefaultEndpoint;
            var cleanKey = OnlyDigits(chave);
            ValidateChave(cleanKey, "CT-e");

            var payloadXml = BuildConsultaXml(cleanKey, baseOptions.Ambiente);
            var soapEnvelope = WrapInSoapEnvelope(payloadXml, ServiceNamespace, "cteDadosMsg");
            var response = await SefazSoapConsultaTransport.PostAsync(
                endpoint,
                SoapAction,
                baseOptions.ContentMediaType,
                soapEnvelope,
                baseOptions.CertificatePath,
                baseOptions.CertificatePassword,
                baseOptions.TimeoutSeconds).ConfigureAwait(false);

            var cStat = ReadInt(response.Body, "retConsSitCTe", "cStat") ?? 0;
            var motivo = ReadText(response.Body, "retConsSitCTe", "xMotivo") ?? string.Empty;
            var protocolo = ReadText(response.Body, "infProt", "nProt");
            var chaveRetorno = ReadText(response.Body, "protCTe", "chCTe") ?? cleanKey;
            var storage = salvarXml
                ? SefazFiscalDocumentStore.SalvarXmlResposta("cte", "consulta", chaveRetorno, response.Body)
                : null;

            return new SefazConsultaDocumentoResult(
                "CTe",
                cStat is 100 or 101,
                cStat == 100,
                cStat,
                motivo,
                chaveRetorno,
                protocolo,
                response.HttpStatusCode,
                response.Body,
                storage?.Path,
                storage?.Sha256);
        }

        private static string BuildConsultaXml(string chave, int ambiente)
        {
            var doc = new XmlDocument { PreserveWhitespace = false };
            var root = doc.CreateElement("consSitCTe", CteNamespace);
            root.SetAttribute("versao", "4.00");
            doc.AppendChild(root);

            AppendElement(doc, root, "tpAmb", ambiente.ToString(), CteNamespace);
            AppendElement(doc, root, "xServ", "CONSULTAR", CteNamespace);
            AppendElement(doc, root, "chCTe", chave, CteNamespace);

            return doc.OuterXml;
        }

        private static string WrapInSoapEnvelope(string innerXml, string serviceNamespace, string dadosMsgName)
        {
            return SefazSoapConsultaTransport.WrapInSoapEnvelope(innerXml, serviceNamespace, dadosMsgName);
        }

        private static void AppendElement(XmlDocument doc, XmlElement parent, string name, string value, string xmlNamespace)
        {
            var element = doc.CreateElement(name, xmlNamespace);
            element.InnerText = value;
            parent.AppendChild(element);
        }

        private static void ValidateChave(string chave, string tipoDocumento)
        {
            if (chave.Length != 44)
                throw new InvalidOperationException($"A chave do {tipoDocumento} deve possuir 44 digitos.");
        }

        private static int? ReadInt(string xml, string parentName, string childName)
        {
            var text = ReadText(xml, parentName, childName);
            return int.TryParse(text, out var value) ? value : null;
        }

        private static string? ReadText(string xml, string parentName, string childName)
        {
            return SefazSoapConsultaTransport.ReadText(xml, parentName, childName);
        }

        private static string OnlyDigits(string value)
        {
            var builder = new StringBuilder(value.Length);
            foreach (var character in value)
            {
                if (character is >= '0' and <= '9')
                    builder.Append(character);
            }

            return builder.ToString();
        }
    }

    internal static class MdfeConsultaHomologacaoClient
    {
        private const string ServiceNamespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeConsulta";
        private const string MdfeNamespace = "http://www.portalfiscal.inf.br/mdfe";
        private const string SoapAction = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeConsulta/mdfeConsultaMDF";

        public static SefazConsultaDocumentoResult Baixar(string chave)
        {
            return ConsultarAsync(chave, salvarXml: true).GetAwaiter().GetResult();
        }

        public static SefazConsultaDocumentoResult BaixarEPersistir(
            string chave,
            IDocumentoFiscalWriteRepository repository,
            ILogger logger,
            string correlationId)
        {
            var result = Baixar(chave);
            SefazFiscalDocumentStore.PersistirConsulta(repository, logger, correlationId, result);
            return result;
        }

        public static SefazConsultaDocumentoResult Consultar(string chave)
        {
            return ConsultarAsync(chave, salvarXml: false).GetAwaiter().GetResult();
        }

        private static async Task<SefazConsultaDocumentoResult> ConsultarAsync(string chave, bool salvarXml)
        {
            var baseOptions = MdfeRecepcaoSincOptions.FromEnvironment();
            var endpoint = Environment.GetEnvironmentVariable("YESHUA_MDFE_CONSULTA_ENDPOINT")
                ?? ResolveEndpoint(baseOptions.Ambiente);
            var cleanKey = OnlyDigits(chave);
            ValidateChave(cleanKey, "MDF-e");

            var payloadXml = BuildConsultaXml(cleanKey, baseOptions.Ambiente);
            var soapEnvelope = SefazSoapConsultaTransport.WrapInSoapEnvelope(payloadXml, ServiceNamespace, "mdfeDadosMsg");
            var response = await SefazSoapConsultaTransport.PostAsync(
                endpoint,
                SoapAction,
                baseOptions.ContentMediaType,
                soapEnvelope,
                baseOptions.CertificatePath,
                baseOptions.CertificatePassword,
                baseOptions.TimeoutSeconds).ConfigureAwait(false);

            var cStat = ReadInt(response.Body, "retConsSitMDFe", "cStat") ?? 0;
            var motivo = ReadText(response.Body, "retConsSitMDFe", "xMotivo") ?? string.Empty;
            var protocolo = ReadText(response.Body, "infProt", "nProt");
            var chaveRetorno = ReadText(response.Body, "protMDFe", "chMDFe") ?? cleanKey;
            var storage = salvarXml
                ? SefazFiscalDocumentStore.SalvarXmlResposta("mdfe", "consulta", chaveRetorno, response.Body)
                : null;

            return new SefazConsultaDocumentoResult(
                "MDFe",
                cStat is 100 or 101 or 132,
                cStat == 100,
                cStat,
                motivo,
                chaveRetorno,
                protocolo,
                response.HttpStatusCode,
                response.Body,
                storage?.Path,
                storage?.Sha256);
        }

        private static string ResolveEndpoint(int ambiente)
        {
            var host = ambiente == 2
                ? "https://mdfe-homologacao.svrs.rs.gov.br"
                : "https://mdfe.svrs.rs.gov.br";

            return $"{host}/ws/MDFeConsulta/MDFeConsulta.asmx";
        }

        private static string BuildConsultaXml(string chave, int ambiente)
        {
            var doc = new XmlDocument { PreserveWhitespace = false };
            var root = doc.CreateElement("consSitMDFe", MdfeNamespace);
            root.SetAttribute("versao", "3.00");
            doc.AppendChild(root);

            AppendElement(doc, root, "tpAmb", ambiente.ToString(), MdfeNamespace);
            AppendElement(doc, root, "xServ", "CONSULTAR", MdfeNamespace);
            AppendElement(doc, root, "chMDFe", chave, MdfeNamespace);

            return doc.OuterXml;
        }

        private static void AppendElement(XmlDocument doc, XmlElement parent, string name, string value, string xmlNamespace)
        {
            var element = doc.CreateElement(name, xmlNamespace);
            element.InnerText = value;
            parent.AppendChild(element);
        }

        private static void ValidateChave(string chave, string tipoDocumento)
        {
            if (chave.Length != 44)
                throw new InvalidOperationException($"A chave do {tipoDocumento} deve possuir 44 digitos.");
        }

        private static int? ReadInt(string xml, string parentName, string childName)
        {
            var text = ReadText(xml, parentName, childName);
            return int.TryParse(text, out var value) ? value : null;
        }

        private static string? ReadText(string xml, string parentName, string childName)
        {
            return SefazSoapConsultaTransport.ReadText(xml, parentName, childName);
        }

        private static string OnlyDigits(string value)
        {
            var builder = new StringBuilder(value.Length);
            foreach (var character in value)
            {
                if (character is >= '0' and <= '9')
                    builder.Append(character);
            }

            return builder.ToString();
        }
    }

    internal static class SefazSoapConsultaTransport
    {
        public static async Task<SefazSoapResponse> PostAsync(
            string endpoint,
            string soapAction,
            string contentMediaType,
            string soapEnvelope,
            string certificatePath,
            string certificatePassword,
            int timeoutSeconds)
        {
            using var certificate = LoadCertificate(certificatePath, certificatePassword);
            using var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                SslProtocols = SslProtocols.Tls12,
                UseProxy = false
            };
            handler.ClientCertificates.Add(certificate);

            using var httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(timeoutSeconds)
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Version = HttpVersion.Version11,
                Content = new StringContent(soapEnvelope, Encoding.UTF8, contentMediaType)
            };

            request.Content.Headers.ContentType!.CharSet = "utf-8";
            request.Content.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("action", $"\"{soapAction}\""));
            request.Headers.ExpectContinue = false;
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            try
            {
                var response = await httpClient.SendAsync(request).ConfigureAwait(false);
                var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return new SefazSoapResponse((int)response.StatusCode, body);
            }
            catch (Exception ex) when (ex is HttpRequestException or AuthenticationException or IOException)
            {
                if (SefazOpenSslHttpFallback.CanHandle(ex))
                {
                    var fallbackResponse = await SefazOpenSslHttpFallback.PostAsync(
                        endpoint,
                        soapEnvelope,
                        $"{contentMediaType}; charset=utf-8; action=\"{soapAction}\"",
                        certificatePath,
                        certificatePassword,
                        timeoutSeconds).ConfigureAwait(false);

                    return new SefazSoapResponse(fallbackResponse.StatusCode, fallbackResponse.Body);
                }

                throw;
            }
        }

        public static string WrapInSoapEnvelope(string innerXml, string serviceNamespace, string dadosMsgName)
        {
            const string soapNamespace = "http://www.w3.org/2003/05/soap-envelope";

            var payload = new XmlDocument { PreserveWhitespace = false };
            payload.LoadXml(innerXml);

            var soap = new XmlDocument { PreserveWhitespace = true };
            var envelope = soap.CreateElement("soap12", "Envelope", soapNamespace);
            envelope.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            envelope.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            soap.AppendChild(envelope);

            var body = soap.CreateElement("soap12", "Body", soapNamespace);
            envelope.AppendChild(body);

            var dados = soap.CreateElement(dadosMsgName, serviceNamespace);
            body.AppendChild(dados);
            dados.AppendChild(soap.ImportNode(payload.DocumentElement!, true));

            return soap.OuterXml;
        }

        public static string? ReadText(string xml, string parentName, string childName)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return null;

            var doc = new XmlDocument { PreserveWhitespace = false };
            doc.LoadXml(xml);

            var node = doc.SelectSingleNode($"//*[local-name()='{parentName}']/*[local-name()='{childName}']");
            return node?.InnerText;
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
    }

    internal sealed record SefazSoapResponse(int HttpStatusCode, string Body);
}
