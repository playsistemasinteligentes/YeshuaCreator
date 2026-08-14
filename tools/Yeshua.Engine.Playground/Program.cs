using System.Net;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

var options = MdfeSefazPlaygroundOptions.FromArgs(args);

Console.WriteLine("Yeshua.Engine.Playground - MDF-e encerramento isolado");
Console.WriteLine($"Endpoint: {options.Endpoint}");
Console.WriteLine($"Certificado: {options.Event.CertificatePath}");
Console.WriteLine($"Chave: {options.Event.ChaveAcesso}");
Console.WriteLine($"Orgao: {options.Event.CodigoOrgao}");
Console.WriteLine($"Encerramento: {options.Event.CodigoMunicipioEncerramento}/{options.Event.CodigoUfEncerramento}");
Console.WriteLine();

options.Event.Validate();

if (string.IsNullOrWhiteSpace(options.Event.CertificatePath) || !File.Exists(options.Event.CertificatePath))
{
    Console.WriteLine("Certificado nao encontrado.");
    Console.WriteLine($"Caminho configurado: {options.Event.CertificatePath}");
    return;
}

var xml = MdfeSefazPlaygroundOptions.BuildEventoXml(options.Event);

using var certificate = MdfeSefazPlaygroundOptions.LoadCertificate(
    options.Event.CertificatePath,
    options.Event.CertificatePassword);

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

var soapEnvelope = MdfeSefazPlaygroundOptions.WrapInSoapEnvelope(
    signedEventoXml,
    options.Event.CodigoOrgao);
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

internal sealed record MdfeEncerramentoParameters(
    int CodigoOrgao,
    int Ambiente,
    string Cnpj,
    string ChaveAcesso,
    string ProtocoloAutorizacao,
    string CertificatePath,
    string CertificatePassword,
    int CodigoUfEncerramento,
    int CodigoMunicipioEncerramento,
    int SequenciaEvento)
{
    public const string TipoEvento = "110112";

    // Parametros fixos do MDF-e atual. O documento e de PE, mas sera encerrado em Sete Lagoas/MG.
    public static MdfeEncerramentoParameters FixedPernambuco { get; } = new(
        CodigoOrgao: 26,
        Ambiente: 1,
        Cnpj: "63249950000174",
        ChaveAcesso: "26260863249950000174580100000002241000022490",
        ProtocoloAutorizacao: "926260007714300",
        CertificatePath: @"C:\Users\AngeloRicardoFontana\Downloads\63249950000174.pfx",
        CertificatePassword: "zanata123",
        CodigoUfEncerramento: 31,
        CodigoMunicipioEncerramento: 3167202,
        SequenciaEvento: 1);




    public string EventId => $"ID{TipoEvento}{ChaveAcesso}{SequenciaEvento:D2}";

    public void Validate()
    {
        ValidateDigits(ChaveAcesso, 44, nameof(ChaveAcesso));
        ValidateDigits(Cnpj, 14, nameof(Cnpj));
        ValidateDigits(ProtocoloAutorizacao, 15, nameof(ProtocoloAutorizacao));

        if (string.IsNullOrWhiteSpace(CertificatePath))
            throw new InvalidOperationException("O caminho do certificado deve ser informado.");

        if (string.IsNullOrWhiteSpace(CertificatePassword) ||
            CertificatePassword == "PREENCHER_SENHA_DO_CERTIFICADO")
        {
            throw new InvalidOperationException("Preencha a senha do certificado nos parametros fixos do MDF-e.");
        }

        if (Ambiente is not 1 and not 2)
            throw new InvalidOperationException("O ambiente deve ser 1 (producao) ou 2 (homologacao).");

        if (!ChaveAcesso.StartsWith(CodigoOrgao.ToString("D2"), StringComparison.Ordinal))
            throw new InvalidOperationException("O cOrgao nao corresponde a UF presente na chave do MDF-e.");

        if (!string.Equals(ChaveAcesso.Substring(6, 14), Cnpj, StringComparison.Ordinal))
            throw new InvalidOperationException("O CNPJ configurado nao corresponde ao CNPJ presente na chave do MDF-e.");

        var municipio = CodigoMunicipioEncerramento.ToString("D7");
        if (!municipio.StartsWith(CodigoUfEncerramento.ToString("D2"), StringComparison.Ordinal))
            throw new InvalidOperationException("O municipio de encerramento nao pertence a UF de encerramento configurada.");

        if (SequenciaEvento is < 1 or > 99)
            throw new InvalidOperationException("A sequencia do evento deve estar entre 1 e 99.");
    }

    private static void ValidateDigits(string value, int length, string fieldName)
    {
        if (value.Length != length || value.Any(character => character is < '0' or > '9'))
            throw new InvalidOperationException($"{fieldName} deve possuir exatamente {length} digitos.");
    }
}

internal sealed record MdfeSefazPlaygroundOptions(
    string Endpoint,
    string SoapAction,
    string ContentMediaType,
    int TimeoutSeconds,
    MdfeEncerramentoParameters Event)
{
    public static MdfeSefazPlaygroundOptions FromArgs(string[] args)
    {
        var endpoint = GetArg(args, "--endpoint")
            ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_ENDPOINT")
            ?? "https://mdfe.svrs.rs.gov.br/ws/MDFeRecepcaoEvento/MDFeRecepcaoEvento.asmx";

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
            soapAction,
            contentType,
            timeoutSeconds,
            MdfeEncerramentoParameters.FixedPernambuco);
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

    public static string BuildEventoXml(MdfeEncerramentoParameters parameters)
    {
        const string mdfeNamespace = "http://www.portalfiscal.inf.br/mdfe";
        var now = DateTimeOffset.Now;
        var doc = new XmlDocument { PreserveWhitespace = false };
        var evento = doc.CreateElement("eventoMDFe", mdfeNamespace);
        evento.SetAttribute("versao", "3.00");
        doc.AppendChild(evento);

        var infEvento = doc.CreateElement("infEvento", mdfeNamespace);
        infEvento.SetAttribute("Id", parameters.EventId);
        evento.AppendChild(infEvento);

        AppendElement(doc, infEvento, "cOrgao", parameters.CodigoOrgao.ToString(), mdfeNamespace);
        AppendElement(doc, infEvento, "tpAmb", parameters.Ambiente.ToString(), mdfeNamespace);
        AppendElement(doc, infEvento, "CNPJ", parameters.Cnpj, mdfeNamespace);
        AppendElement(doc, infEvento, "chMDFe", parameters.ChaveAcesso, mdfeNamespace);
        AppendElement(doc, infEvento, "dhEvento", now.ToString("yyyy-MM-dd'T'HH:mm:sszzz"), mdfeNamespace);
        AppendElement(doc, infEvento, "tpEvento", MdfeEncerramentoParameters.TipoEvento, mdfeNamespace);
        AppendElement(doc, infEvento, "nSeqEvento", parameters.SequenciaEvento.ToString(), mdfeNamespace);

        var detEvento = doc.CreateElement("detEvento", mdfeNamespace);
        detEvento.SetAttribute("versaoEvento", "3.00");
        infEvento.AppendChild(detEvento);

        var encerramento = doc.CreateElement("evEncMDFe", mdfeNamespace);
        detEvento.AppendChild(encerramento);
        AppendElement(doc, encerramento, "descEvento", "Encerramento", mdfeNamespace);
        AppendElement(doc, encerramento, "nProt", parameters.ProtocoloAutorizacao, mdfeNamespace);
        AppendElement(doc, encerramento, "dtEnc", now.ToString("yyyy-MM-dd"), mdfeNamespace);
        AppendElement(doc, encerramento, "cUF", parameters.CodigoUfEncerramento.ToString(), mdfeNamespace);
        AppendElement(doc, encerramento, "cMun", parameters.CodigoMunicipioEncerramento.ToString(), mdfeNamespace);

        return doc.OuterXml;
    }

    public static X509Certificate2 LoadCertificate(string path, string password)
    {
        X509Certificate2? certificate = null;
        try
        {
            certificate = new X509Certificate2(
                path,
                password,
                X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.Exportable);

            using var privateKey = certificate.GetRSAPrivateKey();
            if (privateKey is null)
                throw new InvalidOperationException("O certificado nao possui chave privada RSA.");

            return certificate;
        }
        catch (CryptographicException)
        {
            certificate?.Dispose();
            return new X509Certificate2(
                path,
                password,
                X509KeyStorageFlags.EphemeralKeySet | X509KeyStorageFlags.Exportable);
        }
    }

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

    public static string WrapInSoapEnvelope(string innerXml, int codigoOrgao)
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
        AppendElement(soap, cabecalho, "cUF", codigoOrgao.ToString(), serviceNamespace);
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
