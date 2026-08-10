using System.Net;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

var options = MdfeSefazPlaygroundOptions.FromArgs(args);

Console.WriteLine("Yeshua.Engine.Playground - MDF-e encerramento isolado");
Console.WriteLine($"Endpoint: {options.Endpoint}");
Console.WriteLine($"XML: {options.XmlPath}");
Console.WriteLine($"Certificado: {options.CertificatePath}");
Console.WriteLine();

if (!File.Exists(options.XmlPath))
{
    Directory.CreateDirectory(Path.GetDirectoryName(options.XmlPath)!);
    await File.WriteAllTextAsync(options.XmlPath, MdfeSefazPlaygroundOptions.TemplateXml, Encoding.UTF8);
    Console.WriteLine("O XML de teste ainda nao existia.");
    Console.WriteLine("Criei um template em:");
    Console.WriteLine(options.XmlPath);
    Console.WriteLine("Preencha com o leiaute oficial do evento de encerramento e rode de novo.");
    return;
}

if (string.IsNullOrWhiteSpace(options.CertificatePath) || !File.Exists(options.CertificatePath))
{
    Console.WriteLine("Certificado nao encontrado.");
    Console.WriteLine("Defina YESHUA_MDFE_CERTIFICATE_PATH ou use --certificado.");
    return;
}

var xml = await File.ReadAllTextAsync(options.XmlPath, Encoding.UTF8);
if (string.IsNullOrWhiteSpace(xml))
{
    Console.WriteLine("O arquivo XML esta vazio.");
    return;
}

using var certificate = new X509Certificate2(
    options.CertificatePath,
    options.CertificatePassword,
    X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.Exportable);

var signedEventoXml = MdfeSefazPlaygroundOptions.SignEventoXml(xml, certificate);
MdfeSefazPlaygroundOptions.ValidateNoFormattingWhitespace(signedEventoXml, "evento MDF-e assinado");

using var handler = new HttpClientHandler
{
    ClientCertificateOptions = ClientCertificateOption.Manual,
    SslProtocols = SslProtocols.Tls12
};
handler.ClientCertificates.Add(certificate);

using var httpClient = new HttpClient(handler)
{
    Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds)
};

if (args.Contains("--consultar-wsdl", StringComparer.OrdinalIgnoreCase))
{
    var wsdlResponse = await httpClient.GetAsync(options.Endpoint + "?wsdl");
    var wsdl = await wsdlResponse.Content.ReadAsStringAsync();
    Console.WriteLine($"WSDL: {(int)wsdlResponse.StatusCode} {wsdlResponse.StatusCode}");
    Console.WriteLine(wsdl);
    return;
}

var soapEnvelope = MdfeSefazPlaygroundOptions.WrapInSoapEnvelope(signedEventoXml);
MdfeSefazPlaygroundOptions.ValidateXml(soapEnvelope, "envelope SOAP");
MdfeSefazPlaygroundOptions.ValidateNoFormattingWhitespace(soapEnvelope, "envelope SOAP");

if (args.Contains("--somente-validar", StringComparer.OrdinalIgnoreCase))
{
    Console.WriteLine("XML assinado e envelope SOAP validados localmente. Nenhuma chamada foi feita ao SEFAZ.");
    return;
}

Console.WriteLine();
Console.WriteLine("Enviando XML para o SEFAZ (SOAP 1.2)...");

using var request = new HttpRequestMessage(HttpMethod.Post, options.Endpoint)
{
    Version = HttpVersion.Version11,
    Content = new StringContent(soapEnvelope, Encoding.UTF8, options.ContentMediaType)
};

request.Content.Headers.ContentType!.CharSet = "utf-8";
request.Content.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("action", $"\"{options.SoapAction}\""));
request.Headers.ExpectContinue = false;
request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

var response = await httpClient.SendAsync(request);
var responseBody = await response.Content.ReadAsStringAsync();

Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
if (!string.IsNullOrWhiteSpace(responseBody))
{
    Console.WriteLine(responseBody);
}

internal sealed record MdfeSefazPlaygroundOptions(
    string Endpoint,
    string CertificatePath,
    string CertificatePassword,
    string XmlPath,
    string SoapAction,
    string ContentMediaType,
    int TimeoutSeconds)
{
    public static MdfeSefazPlaygroundOptions FromArgs(string[] args)
    {
        var endpoint = GetArg(args, "--endpoint")
            ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_ENDPOINT")
            ?? "https://mdfe.svrs.rs.gov.br/ws/MDFeRecepcaoEvento/MDFeRecepcaoEvento.asmx";

        var certificatePath = GetArg(args, "--certificado")
            ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_CERTIFICATE_PATH")
            ?? @"C:\Users\AngeloRicardoFontana\Downloads\51072863000105.pfx";

        var certificatePassword = GetArg(args, "--senha")
            ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_CERTIFICATE_PASSWORD")
            ?? "12345678";

        var xmlPath = GetArg(args, "--xml")
            ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_XML_PATH")
            ?? Path.Combine(AppContext.BaseDirectory, "fixtures", "mdfe-encerramento.xml");

        var soapAction = GetArg(args, "--soap-action")
            ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_SOAP_ACTION")
            ?? "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoEvento/mdfeRecepcaoEvento";

        var contentType = GetArg(args, "--content-type")
            ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_CONTENT_TYPE")
            ?? "application/soap+xml";

        var timeoutSecondsText = GetArg(args, "--timeout")
            ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_TIMEOUT_SECONDS")
            ?? "120";

        _ = int.TryParse(timeoutSecondsText, out var timeoutSeconds);
        if (timeoutSeconds <= 0)
        {
            timeoutSeconds = 120;
        }

        return new MdfeSefazPlaygroundOptions(
            endpoint,
            certificatePath,
            certificatePassword,
            xmlPath,
            soapAction,
            contentType,
            timeoutSeconds);
    }

    private static string? GetArg(string[] args, string name)
    {
        for (var i = 0; i < args.Length - 1; i++)
        {
            if (string.Equals(args[i], name, StringComparison.OrdinalIgnoreCase))
            {
                return args[i + 1];
            }
        }

        return null;
    }

    public const string TemplateXml = """
<?xml version="1.0" encoding="utf-8"?>
<!--
  pendencia: substituir este payload pelo leiaute oficial do evento 110112 do MDF-e.
  O playground fica isolado do motor e da infra do CQRS, servindo apenas para testar a chamada SEFAZ.
-->
<eventoMDFe xmlns="http://www.portalfiscal.inf.br/mdfe" versao="3.00">
  <infEvento Id="ID1101122626085107286300010558105000000630100006309101">
    <cOrgao>31</cOrgao>
    <tpAmb>1</tpAmb>
    <CNPJ>51072863000105</CNPJ>
    <chMDFe>26260851072863000105581050000006301000063091</chMDFe>
    <dhEvento>2026-08-06T00:00:00-03:00</dhEvento>
    <tpEvento>110112</tpEvento>
    <nSeqEvento>1</nSeqEvento>
    <detEvento versaoEvento="3.00">
      <evEncMDFe>
        <descEvento>Encerramento</descEvento>
        <nProt>926260007318465</nProt>
        <dtEnc>2026-08-06</dtEnc>
        <cUF>31</cUF>
        <cMun>3167202</cMun>
      </evEncMDFe>
    </detEvento>
  </infEvento>
</eventoMDFe>
""";

    public static string SignEventoXml(string xml, X509Certificate2 certificate)
    {
        var doc = new XmlDocument { PreserveWhitespace = false };
        doc.LoadXml(xml);

        var nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("mdfe", "http://www.portalfiscal.inf.br/mdfe");

        var eventoNode = doc.SelectSingleNode("/mdfe:eventoMDFe", nsmgr) as XmlElement
            ?? throw new InvalidOperationException("Nao foi possivel localizar o elemento eventoMDFe.");

        var infEventoNode = doc.SelectSingleNode("/mdfe:eventoMDFe/mdfe:infEvento", nsmgr) as XmlElement
            ?? throw new InvalidOperationException("Nao foi possivel localizar o elemento infEvento.");

        var id = infEventoNode.GetAttribute("Id");
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new InvalidOperationException("O atributo Id do infEvento nao pode estar vazio.");
        }

        UpdateEventDates(doc, nsmgr);

        using var rsa = certificate.GetRSAPrivateKey()
            ?? throw new InvalidOperationException("O certificado nao possui chave privada RSA.");

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
        {
            throw new InvalidOperationException("A assinatura digital do evento MDF-e nao passou na validacao local.");
        }

        return doc.DocumentElement!.OuterXml;
    }

    private static void UpdateEventDates(XmlDocument doc, XmlNamespaceManager nsmgr)
    {
        var now = DateTimeOffset.Now;
        var eventDateNode = doc.SelectSingleNode("/mdfe:eventoMDFe/mdfe:infEvento/mdfe:dhEvento", nsmgr);
        var closingDateNode = doc.SelectSingleNode("/mdfe:eventoMDFe/mdfe:infEvento/mdfe:detEvento/mdfe:evEncMDFe/mdfe:dtEnc", nsmgr);

        eventDateNode!.InnerText = now.ToString("yyyy-MM-dd'T'HH:mm:sszzz");
        closingDateNode!.InnerText = now.ToString("yyyy-MM-dd");
    }

    public static string WrapInSoapEnvelope(string innerXml)
    {
        const string soapNamespace = "http://www.w3.org/2003/05/soap-envelope";
        const string serviceNamespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoEvento";

        var evento = new XmlDocument { PreserveWhitespace = false };
        evento.LoadXml(innerXml);

        var soap = new XmlDocument { PreserveWhitespace = true };
        var envelope = soap.CreateElement("soap12", "Envelope", soapNamespace);
        soap.AppendChild(envelope);

        var header = soap.CreateElement("soap12", "Header", soapNamespace);
        envelope.AppendChild(header);

        var cabecalho = soap.CreateElement("mdfeCabecMsg", serviceNamespace);
        header.AppendChild(cabecalho);
        AppendElement(soap, cabecalho, "cUF", "31", serviceNamespace);
        AppendElement(soap, cabecalho, "versaoDados", "3.00", serviceNamespace);

        var body = soap.CreateElement("soap12", "Body", soapNamespace);
        envelope.AppendChild(body);

        var dados = soap.CreateElement("mdfeDadosMsg", serviceNamespace);
        body.AppendChild(dados);
        dados.AppendChild(soap.ImportNode(evento.DocumentElement!, true));

        return soap.OuterXml;
    }

    private static void AppendElement(XmlDocument doc, XmlElement parent, string name, string value, string xmlNamespace)
    {
        var element = doc.CreateElement(name, xmlNamespace);
        element.InnerText = value;
        parent.AppendChild(element);
    }

    public static void ValidateXml(string xml, string description)
    {
        var doc = new XmlDocument { PreserveWhitespace = true };
        try
        {
            doc.LoadXml(xml);
        }
        catch (XmlException exception)
        {
            throw new InvalidOperationException($"O {description} esta malformado.", exception);
        }
    }

    public static void ValidateNoFormattingWhitespace(string xml, string description)
    {
        var doc = new XmlDocument { PreserveWhitespace = true };
        doc.LoadXml(xml);

        if (ContainsFormattingWhitespace(doc))
        {
            throw new InvalidOperationException(
                $"O {description} contem espacos ou quebras de linha entre as tags e seria rejeitado pelo SEFAZ.");
        }
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
            {
                return true;
            }
        }

        return false;
    }
}
