using System;
using System.IO;
using System.IO.Compression;
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
                    ?? fixedOptions.InscricaoEstadual
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
        }
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

        private static async Task<CteRecepcaoSincV4Result> AutorizarAsync(CteRecepcaoSincV4Options options)
        {
            options.ValidateForSend();

            using var signingCertificate = LoadCertificate(options.CertificatePath, options.CertificatePassword);
            var cteXml = SignCteXml(BuildHomologCteXml(options), signingCertificate);
            var chave = ExtractChave(cteXml);
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
            AppendElement(doc, ide, "CFOP", "5353");
            AppendElement(doc, ide, "natOp", "PRESTACAO DE SERVICO DE TRANSPORTE");
            AppendElement(doc, ide, "mod", "57");
            AppendElement(doc, ide, "serie", serie.ToString());
            AppendElement(doc, ide, "nCT", numero.ToString());
            AppendElement(doc, ide, "dhEmi", now.ToString("yyyy-MM-dd'T'HH:mm:sszzz"));
            AppendElement(doc, ide, "tpImp", "1");
            AppendElement(doc, ide, "tpEmis", "1");
            AppendElement(doc, ide, "cDV", chave[^1].ToString());
            AppendElement(doc, ide, "tpAmb", options.Ambiente.ToString());
            AppendElement(doc, ide, "tpCTe", "0");
            AppendElement(doc, ide, "procEmi", "0");
            AppendElement(doc, ide, "verProc", "YESHUA-CTE-001");
            AppendElement(doc, ide, "cMunEnv", "2611606");
            AppendElement(doc, ide, "xMunEnv", "RECIFE");
            AppendElement(doc, ide, "UFEnv", "PE");
            AppendElement(doc, ide, "modal", "01");
            AppendElement(doc, ide, "tpServ", "0");
            AppendElement(doc, ide, "cMunIni", "2611606");
            AppendElement(doc, ide, "xMunIni", "RECIFE");
            AppendElement(doc, ide, "UFIni", "PE");
            AppendElement(doc, ide, "cMunFim", "2607901");
            AppendElement(doc, ide, "xMunFim", "JABOATAO DOS GUARARAPES");
            AppendElement(doc, ide, "UFFim", "PE");
            AppendElement(doc, ide, "retira", "1");
            AppendElement(doc, ide, "indIEToma", "1");
            var toma3 = AppendElement(doc, ide, "toma3");
            AppendElement(doc, toma3, "toma", "0");

            var emit = AppendElement(doc, infCte, "emit");
            AppendElement(doc, emit, "CNPJ", options.CnpjEmitente);
            AppendElement(doc, emit, "IE", options.InscricaoEstadual);
            AppendElement(doc, emit, "xNome", options.RazaoSocial);
            AppendElement(doc, emit, "xFant", "ZANATA LOGISTICA");
            AppendEndereco(doc, AppendElement(doc, emit, "enderEmit"), "RUA TESTE", "100", "CENTRO", "2611606", "RECIFE", "50000000", "PE", incluirPais: false);
            AppendElement(doc, emit, "CRT", "3");

            var rem = AppendElement(doc, infCte, "rem");
            AppendElement(doc, rem, "CNPJ", options.CnpjEmitente);
            AppendElement(doc, rem, "IE", options.InscricaoEstadual);
            AppendElement(doc, rem, "xNome", HomologacaoNome);
            AppendEndereco(doc, AppendElement(doc, rem, "enderReme"), "RUA TESTE", "100", "CENTRO", "2611606", "RECIFE", "50000000", "PE", incluirPais: true);

            var dest = AppendElement(doc, infCte, "dest");
            AppendElement(doc, dest, "CNPJ", "00000000000191");
            AppendElement(doc, dest, "IE", "ISENTO");
            AppendElement(doc, dest, "xNome", HomologacaoNome);
            AppendEndereco(doc, AppendElement(doc, dest, "enderDest"), "AVENIDA TESTE", "200", "CENTRO", "2607901", "JABOATAO DOS GUARARAPES", "54000000", "PE", incluirPais: true);

            var vPrest = AppendElement(doc, infCte, "vPrest");
            AppendElement(doc, vPrest, "vTPrest", "100.00");
            AppendElement(doc, vPrest, "vRec", "100.00");
            var comp = AppendElement(doc, vPrest, "Comp");
            AppendElement(doc, comp, "xNome", "FRETE");
            AppendElement(doc, comp, "vComp", "100.00");

            var imp = AppendElement(doc, infCte, "imp");
            var icms = AppendElement(doc, imp, "ICMS");
            var icms00 = AppendElement(doc, icms, "ICMS00");
            AppendElement(doc, icms00, "CST", "00");
            AppendElement(doc, icms00, "vBC", "100.00");
            AppendElement(doc, icms00, "pICMS", "12.00");
            AppendElement(doc, icms00, "vICMS", "12.00");
            AppendIbsCbsHomologacao(doc, imp);
            AppendElement(doc, imp, "vTotDFe", "100.00");

            var infCteNorm = AppendElement(doc, infCte, "infCTeNorm");
            var infCarga = AppendElement(doc, infCteNorm, "infCarga");
            AppendElement(doc, infCarga, "vCarga", "1000.00");
            AppendElement(doc, infCarga, "proPred", "MERCADORIA HOMOLOGACAO");
            var infQ = AppendElement(doc, infCarga, "infQ");
            AppendElement(doc, infQ, "cUnid", "01");
            AppendElement(doc, infQ, "tpMed", "PESO BRUTO");
            AppendElement(doc, infQ, "qCarga", "100.0000");

            var infDoc = AppendElement(doc, infCteNorm, "infDoc");
            var infNFe = AppendElement(doc, infDoc, "infNFe");
            AppendElement(doc, infNFe, "chave", chaveNfeMock);

            var infModal = AppendElement(doc, infCteNorm, "infModal");
            infModal.SetAttribute("versaoModal", "4.00");
            var rodo = AppendElement(doc, infModal, "rodo");
            AppendElement(doc, rodo, "RNTRC", "45861338");

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
