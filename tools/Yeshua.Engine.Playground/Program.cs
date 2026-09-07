using System.Net;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.IO.Compression;

if (args.Contains("--cte-recepcao", StringComparer.OrdinalIgnoreCase))
{
    await CteRecepcaoSincPlayground.RunAsync(args);
    return;
}

if (args.Contains("--cte-status", StringComparer.OrdinalIgnoreCase))
{
    await CteStatusServicoPlayground.RunAsync(args);
    return;
}

if (args.Contains("--cte-consulta", StringComparer.OrdinalIgnoreCase) ||
    args.Contains("--cte-baixar", StringComparer.OrdinalIgnoreCase))
{
    await CteConsultaPlayground.RunAsync(args);
    return;
}

if (args.Contains("--mdfe-recepcao-sinc", StringComparer.OrdinalIgnoreCase))
{
    await MdfeRecepcaoSincFiscalPlayground.RunAsync(args);
    return;
}

await MdfePlayground.RunAsync(args);

internal sealed record CteStatusServicoParameters(
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
    public static CteStatusServicoParameters FixedTransportador { get; } = new(
        Ambiente: 2,
        CodigoUf: 26,
        Endpoint: "https://homologacao.nfe.fazenda.sp.gov.br/CTeWS/WS/CTeStatusServicoV4.asmx",
        SoapAction: "http://www.portalfiscal.inf.br/cte/wsdl/CTeStatusServicoV4/cteStatusServicoCT",
        ContentMediaType: "application/soap+xml",
        CertificatePath: @"C:\Users\AngeloRicardoFontana\Downloads\63249950000174.pfx",
        CertificatePassword: "zanata123",
        CnpjEmitente: "63249950000174",
        RazaoSocial: "ZANATA LOGISTICA E TRANSPORTES LTDA",
        InscricaoEstadual: "128556188",
        TimeoutSeconds: 120);

    public void ValidateForSend()
    {
        if (Ambiente is not 1 and not 2)
            throw new InvalidOperationException("O ambiente do CT-e deve ser 1 (producao) ou 2 (homologacao).");

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

internal static class CteStatusServicoPlayground
{
    public static async Task RunAsync(string[] args)
    {
        var parameters = BuildParameters(args);

        Console.WriteLine("Yeshua.Engine.Playground - CT-e StatusServicoV4 isolado");
        Console.WriteLine($"Endpoint: {parameters.Endpoint}");
        Console.WriteLine($"Ambiente: {parameters.Ambiente}");
        Console.WriteLine($"UF: {parameters.CodigoUf}");
        Console.WriteLine($"Certificado: {parameters.CertificatePath}");
        Console.WriteLine($"CNPJ: {parameters.CnpjEmitente}");
        Console.WriteLine($"Emitente: {parameters.RazaoSocial}");
        Console.WriteLine();

        var statusXml = BuildStatusServicoXml(parameters);
        var soapEnvelope = WrapStatusInSoapEnvelope(statusXml);
        MdfeSefazPlaygroundOptions.ValidateXml(soapEnvelope, "envelope SOAP CT-e");
        MdfeSefazPlaygroundOptions.ValidateNoFormattingWhitespace(soapEnvelope, "envelope SOAP CT-e");

        if (args.Contains("--somente-validar", StringComparer.OrdinalIgnoreCase))
        {
            Console.WriteLine("XML de status CT-e e envelope SOAP validados localmente. Nenhuma chamada foi feita ao SEFAZ.");
            Console.WriteLine(soapEnvelope);
            return;
        }

        parameters.ValidateForSend();

        using var certificate = MdfeSefazPlaygroundOptions.LoadCertificate(
            parameters.CertificatePath,
            parameters.CertificatePassword);

        using var handler = new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            SslProtocols = SslProtocols.Tls12,
            UseProxy = false
        };
        handler.ClientCertificates.Add(certificate);

        using var httpClient = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(parameters.TimeoutSeconds)
        };

        if (args.Contains("--consultar-wsdl", StringComparer.OrdinalIgnoreCase))
        {
            var wsdlResponse = await httpClient.GetAsync(parameters.Endpoint + "?wsdl");
            var wsdl = await wsdlResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"WSDL: {(int)wsdlResponse.StatusCode} {wsdlResponse.StatusCode}");
            Console.WriteLine(wsdl);
            return;
        }

        Console.WriteLine("Enviando consulta de status CT-e para o SEFAZ (SOAP 1.2)...");

        using var request = new HttpRequestMessage(HttpMethod.Post, parameters.Endpoint)
        {
            Version = HttpVersion.Version11,
            Content = new StringContent(soapEnvelope, Encoding.UTF8, parameters.ContentMediaType)
        };

        request.Content.Headers.ContentType!.CharSet = "utf-8";
        request.Content.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("action", $"\"{parameters.SoapAction}\""));
        request.Headers.ExpectContinue = false;
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

        var response = await httpClient.SendAsync(request);
        var responseBody = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
        if (!string.IsNullOrWhiteSpace(responseBody))
        {
            Console.WriteLine(responseBody);
        }
    }

    public static CteStatusServicoParameters BuildParameters(string[] args)
    {
        var fixedParameters = CteStatusServicoParameters.FixedTransportador;
        var ambienteText = GetArg(args, "--cte-ambiente")
            ?? Environment.GetEnvironmentVariable("YESHUA_CTE_AMBIENTE")
            ?? fixedParameters.Ambiente.ToString();

        _ = int.TryParse(ambienteText, out var ambiente);
        if (ambiente <= 0)
        {
            ambiente = fixedParameters.Ambiente;
        }

        var codigoUfText = GetArg(args, "--cte-cuf")
            ?? Environment.GetEnvironmentVariable("YESHUA_CTE_CUF")
            ?? fixedParameters.CodigoUf.ToString();

        _ = int.TryParse(codigoUfText, out var codigoUf);
        if (codigoUf <= 0)
        {
            codigoUf = fixedParameters.CodigoUf;
        }

        return fixedParameters with
        {
            Ambiente = ambiente,
            CodigoUf = codigoUf,
            Endpoint = GetArg(args, "--cte-endpoint")
                ?? Environment.GetEnvironmentVariable("YESHUA_CTE_STATUS_ENDPOINT")
                ?? fixedParameters.Endpoint,
            CertificatePath = GetArg(args, "--cte-cert")
                ?? Environment.GetEnvironmentVariable("YESHUA_CTE_CERTIFICATE_PATH")
                ?? fixedParameters.CertificatePath,
            CertificatePassword = GetArg(args, "--cte-senha")
                ?? Environment.GetEnvironmentVariable("YESHUA_CTE_CERTIFICATE_PASSWORD")
                ?? fixedParameters.CertificatePassword,
            CnpjEmitente = GetArg(args, "--cte-cnpj")
                ?? Environment.GetEnvironmentVariable("YESHUA_CTE_CNPJ_EMITENTE")
                ?? fixedParameters.CnpjEmitente,
            RazaoSocial = GetArg(args, "--cte-razao")
                ?? Environment.GetEnvironmentVariable("YESHUA_CTE_RAZAO_SOCIAL")
                ?? fixedParameters.RazaoSocial,
            InscricaoEstadual = GetArg(args, "--cte-ie")
                ?? Environment.GetEnvironmentVariable("YESHUA_CTE_INSCRICAO_ESTADUAL")
                ?? fixedParameters.InscricaoEstadual
        };
    }

    private static string BuildStatusServicoXml(CteStatusServicoParameters parameters)
    {
        const string cteNamespace = "http://www.portalfiscal.inf.br/cte";

        var doc = new XmlDocument { PreserveWhitespace = false };
        var status = doc.CreateElement("consStatServCTe", cteNamespace);
        status.SetAttribute("versao", "4.00");
        doc.AppendChild(status);

        AppendElement(doc, status, "tpAmb", parameters.Ambiente.ToString(), cteNamespace);
        AppendElement(doc, status, "cUF", parameters.CodigoUf.ToString(), cteNamespace);
        AppendElement(doc, status, "xServ", "STATUS", cteNamespace);

        return doc.OuterXml;
    }

    private static string WrapStatusInSoapEnvelope(string innerXml)
    {
        const string soapNamespace = "http://www.w3.org/2003/05/soap-envelope";
        const string serviceNamespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeStatusServicoV4";

        var status = new XmlDocument { PreserveWhitespace = false };
        status.LoadXml(innerXml);

        var soap = new XmlDocument { PreserveWhitespace = true };
        var envelope = soap.CreateElement("soap12", "Envelope", soapNamespace);
        envelope.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
        envelope.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
        soap.AppendChild(envelope);

        var body = soap.CreateElement("soap12", "Body", soapNamespace);
        envelope.AppendChild(body);

        var dados = soap.CreateElement("cteDadosMsg", serviceNamespace);
        body.AppendChild(dados);
        dados.AppendChild(soap.ImportNode(status.DocumentElement!, true));

        return soap.OuterXml;
    }

    private static void AppendElement(XmlDocument doc, XmlElement parent, string name, string value, string xmlNamespace)
    {
        var element = doc.CreateElement(name, xmlNamespace);
        element.InnerText = value;
        parent.AppendChild(element);
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
}

internal static class CteRecepcaoSincPlayground
{
    private const string ServiceNamespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeRecepcaoSincV4";
    private const string RecepcaoEndpoint = "https://homologacao.nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoSincV4.asmx";
    private const string RecepcaoSoapAction = "http://www.portalfiscal.inf.br/cte/wsdl/CTeRecepcaoSincV4/cteRecepcao";

    public static async Task RunAsync(string[] args)
    {
        var parameters = BuildParameters(args);

        parameters.ValidateForSend();

        using var signingCertificate = MdfeSefazPlaygroundOptions.LoadCertificate(
            parameters.CertificatePath,
            parameters.CertificatePassword);

        var cteXml = LoadCteXml(args, parameters, signingCertificate);
        var compressedBase64 = CompressToBase64(cteXml);
        var soapEnvelope = WrapRecepcaoInSoapEnvelope(compressedBase64);

        MdfeSefazPlaygroundOptions.ValidateXml(soapEnvelope, "envelope SOAP CT-e recepcao sincrona");
        MdfeSefazPlaygroundOptions.ValidateNoFormattingWhitespace(soapEnvelope, "envelope SOAP CT-e recepcao sincrona");

        Console.WriteLine("Yeshua.Engine.Playground - CT-e RecepcaoSincV4 isolado");
        Console.WriteLine($"Endpoint: {parameters.Endpoint}");
        Console.WriteLine($"Ambiente: {parameters.Ambiente}");
        Console.WriteLine($"UF: {parameters.CodigoUf}");
        Console.WriteLine($"Certificado: {parameters.CertificatePath}");
        Console.WriteLine($"CNPJ: {parameters.CnpjEmitente}");
        Console.WriteLine($"XML CT-e bytes: {Encoding.UTF8.GetByteCount(cteXml)}");
        Console.WriteLine($"XML CT-e GZip/Base64 chars: {compressedBase64.Length}");
        Console.WriteLine();

        if (args.Contains("--somente-validar", StringComparer.OrdinalIgnoreCase))
        {
            Console.WriteLine("Envelope SOAP CT-e recepcao sincrona validado localmente. Nenhuma chamada foi feita ao SEFAZ.");
            Console.WriteLine(soapEnvelope);
            return;
        }

        using var handler = new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            SslProtocols = SslProtocols.Tls12,
            UseProxy = false
        };
        using var transportCertificate = MdfeSefazPlaygroundOptions.LoadCertificate(
            parameters.CertificatePath,
            parameters.CertificatePassword);
        handler.ClientCertificates.Add(transportCertificate);

        using var httpClient = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(parameters.TimeoutSeconds)
        };

        Console.WriteLine("Enviando CT-e para recepcao sincrona SEFAZ (SOAP 1.2)...");

        using var request = new HttpRequestMessage(HttpMethod.Post, parameters.Endpoint)
        {
            Version = HttpVersion.Version11,
            Content = new StringContent(soapEnvelope, Encoding.UTF8, parameters.ContentMediaType)
        };

        request.Content.Headers.ContentType!.CharSet = "utf-8";
        request.Content.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("action", $"\"{parameters.SoapAction}\""));
        request.Headers.ExpectContinue = false;
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

        var response = await httpClient.SendAsync(request);
        var responseBody = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
        if (!string.IsNullOrWhiteSpace(responseBody))
        {
            Console.WriteLine(responseBody);
        }
    }

    private static CteStatusServicoParameters BuildParameters(string[] args)
    {
        var endpoint = GetArg(args, "--cte-recepcao-endpoint")
            ?? GetArg(args, "--cte-endpoint")
            ?? Environment.GetEnvironmentVariable("YESHUA_CTE_RECEPCAO_ENDPOINT")
            ?? RecepcaoEndpoint;

        var statusParameters = CteStatusServicoPlayground.BuildParameters(args);

        return statusParameters with
        {
            Endpoint = endpoint,
            SoapAction = RecepcaoSoapAction
        };
    }

    private static string LoadCteXml(
        string[] args,
        CteStatusServicoParameters parameters,
        X509Certificate2 certificate)
    {
        if (args.Contains("--cte-incompleto", StringComparer.OrdinalIgnoreCase))
        {
            return BuildIncompleteCteXml();
        }

        var xmlPath = GetArg(args, "--cte-xml")
            ?? Environment.GetEnvironmentVariable("YESHUA_CTE_XML_PATH");

        if (!string.IsNullOrWhiteSpace(xmlPath))
        {
            if (!File.Exists(xmlPath))
            {
                throw new FileNotFoundException("XML CT-e informado nao foi encontrado.", xmlPath);
            }

            var xml = File.ReadAllText(xmlPath, Encoding.UTF8);
            MdfeSefazPlaygroundOptions.ValidateXml(xml, "XML CT-e informado");
            MdfeSefazPlaygroundOptions.ValidateNoFormattingWhitespace(xml, "XML CT-e informado");

            if (args.Contains("--cte-assinar", StringComparer.OrdinalIgnoreCase))
            {
                return SignCteXml(RemoveExistingSignature(xml), certificate);
            }

            return xml;
        }

        return BuildSignedHomologCteXml(parameters, certificate);
    }

    private static string BuildSignedHomologCteXml(
        CteStatusServicoParameters parameters,
        X509Certificate2 certificate)
    {
        var xml = BuildHomologCteXml(parameters);
        return SignCteXml(xml, certificate);
    }

    private static string BuildHomologCteXml(CteStatusServicoParameters parameters)
    {
        const string cteNamespace = "http://www.portalfiscal.inf.br/cte";
        const string homologacaoNome = "CTE EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";

        var now = DateTimeOffset.Now;
        var serie = 1;
        var numero = RandomNumberGenerator.GetInt32(1, 999999999);
        var codigoControle = RandomNumberGenerator.GetInt32(1, 99999999).ToString("D8");
        var chave = BuildAccessKey(
            parameters.CodigoUf,
            now,
            parameters.CnpjEmitente,
            modelo: 57,
            serie,
            numero,
            tipoEmissao: 1,
            codigoControle);

        var chaveNfeMock = BuildAccessKey(
            parameters.CodigoUf,
            now,
            parameters.CnpjEmitente,
            modelo: 55,
            serie,
            numero,
            tipoEmissao: 1,
            RandomNumberGenerator.GetInt32(1, 99999999).ToString("D8"));

        var doc = new XmlDocument { PreserveWhitespace = false };
        var cte = doc.CreateElement("CTe", cteNamespace);
        doc.AppendChild(cte);

        var infCte = doc.CreateElement("infCte", cteNamespace);
        infCte.SetAttribute("Id", "CTe" + chave);
        infCte.SetAttribute("versao", "4.00");
        cte.AppendChild(infCte);

        var ide = AppendElement(doc, infCte, "ide", cteNamespace);
        AppendElement(doc, ide, "cUF", parameters.CodigoUf.ToString(), cteNamespace);
        AppendElement(doc, ide, "cCT", codigoControle, cteNamespace);
        AppendElement(doc, ide, "CFOP", "5353", cteNamespace);
        AppendElement(doc, ide, "natOp", "PRESTACAO DE SERVICO DE TRANSPORTE", cteNamespace);
        AppendElement(doc, ide, "mod", "57", cteNamespace);
        AppendElement(doc, ide, "serie", serie.ToString(), cteNamespace);
        AppendElement(doc, ide, "nCT", numero.ToString(), cteNamespace);
        AppendElement(doc, ide, "dhEmi", now.ToString("yyyy-MM-dd'T'HH:mm:sszzz"), cteNamespace);
        AppendElement(doc, ide, "tpImp", "1", cteNamespace);
        AppendElement(doc, ide, "tpEmis", "1", cteNamespace);
        AppendElement(doc, ide, "cDV", chave[^1].ToString(), cteNamespace);
        AppendElement(doc, ide, "tpAmb", parameters.Ambiente.ToString(), cteNamespace);
        AppendElement(doc, ide, "tpCTe", "0", cteNamespace);
        AppendElement(doc, ide, "procEmi", "0", cteNamespace);
        AppendElement(doc, ide, "verProc", "YESHUA-CTE-001", cteNamespace);
        AppendElement(doc, ide, "cMunEnv", "2611606", cteNamespace);
        AppendElement(doc, ide, "xMunEnv", "RECIFE", cteNamespace);
        AppendElement(doc, ide, "UFEnv", "PE", cteNamespace);
        AppendElement(doc, ide, "modal", "01", cteNamespace);
        AppendElement(doc, ide, "tpServ", "0", cteNamespace);
        AppendElement(doc, ide, "cMunIni", "2611606", cteNamespace);
        AppendElement(doc, ide, "xMunIni", "RECIFE", cteNamespace);
        AppendElement(doc, ide, "UFIni", "PE", cteNamespace);
        AppendElement(doc, ide, "cMunFim", "2607901", cteNamespace);
        AppendElement(doc, ide, "xMunFim", "JABOATAO DOS GUARARAPES", cteNamespace);
        AppendElement(doc, ide, "UFFim", "PE", cteNamespace);
        AppendElement(doc, ide, "retira", "1", cteNamespace);
        AppendElement(doc, ide, "indIEToma", "1", cteNamespace);
        var toma3 = AppendElement(doc, ide, "toma3", cteNamespace);
        AppendElement(doc, toma3, "toma", "0", cteNamespace);

        var emit = AppendElement(doc, infCte, "emit", cteNamespace);
        AppendElement(doc, emit, "CNPJ", parameters.CnpjEmitente, cteNamespace);
        AppendElement(doc, emit, "IE", parameters.InscricaoEstadual, cteNamespace);
        AppendElement(doc, emit, "xNome", parameters.RazaoSocial, cteNamespace);
        AppendElement(doc, emit, "xFant", "ZANATA LOGISTICA", cteNamespace);
        AppendEndereco(doc, AppendElement(doc, emit, "enderEmit", cteNamespace), "RUA TESTE", "100", "CENTRO", "2611606", "RECIFE", "50000000", "PE", cteNamespace, incluirPais: false);
        AppendElement(doc, emit, "CRT", "3", cteNamespace);

        var rem = AppendElement(doc, infCte, "rem", cteNamespace);
        AppendElement(doc, rem, "CNPJ", parameters.CnpjEmitente, cteNamespace);
        AppendElement(doc, rem, "IE", parameters.InscricaoEstadual, cteNamespace);
        AppendElement(doc, rem, "xNome", homologacaoNome, cteNamespace);
        AppendEndereco(doc, AppendElement(doc, rem, "enderReme", cteNamespace), "RUA TESTE", "100", "CENTRO", "2611606", "RECIFE", "50000000", "PE", cteNamespace, incluirPais: true);

        var dest = AppendElement(doc, infCte, "dest", cteNamespace);
        AppendElement(doc, dest, "CNPJ", "00000000000191", cteNamespace);
        AppendElement(doc, dest, "IE", "ISENTO", cteNamespace);
        AppendElement(doc, dest, "xNome", homologacaoNome, cteNamespace);
        AppendEndereco(doc, AppendElement(doc, dest, "enderDest", cteNamespace), "AVENIDA TESTE", "200", "CENTRO", "2607901", "JABOATAO DOS GUARARAPES", "54000000", "PE", cteNamespace, incluirPais: true);

        var vPrest = AppendElement(doc, infCte, "vPrest", cteNamespace);
        AppendElement(doc, vPrest, "vTPrest", "100.00", cteNamespace);
        AppendElement(doc, vPrest, "vRec", "100.00", cteNamespace);
        var comp = AppendElement(doc, vPrest, "Comp", cteNamespace);
        AppendElement(doc, comp, "xNome", "FRETE", cteNamespace);
        AppendElement(doc, comp, "vComp", "100.00", cteNamespace);

        var imp = AppendElement(doc, infCte, "imp", cteNamespace);
        var icms = AppendElement(doc, imp, "ICMS", cteNamespace);
        var icms00 = AppendElement(doc, icms, "ICMS00", cteNamespace);
        AppendElement(doc, icms00, "CST", "00", cteNamespace);
        AppendElement(doc, icms00, "vBC", "100.00", cteNamespace);
        AppendElement(doc, icms00, "pICMS", "12.00", cteNamespace);
        AppendElement(doc, icms00, "vICMS", "12.00", cteNamespace);
        AppendIbsCbsHomologacao(doc, imp, cteNamespace);
        AppendElement(doc, imp, "vTotDFe", "100.00", cteNamespace);

        var infCteNorm = AppendElement(doc, infCte, "infCTeNorm", cteNamespace);
        var infCarga = AppendElement(doc, infCteNorm, "infCarga", cteNamespace);
        AppendElement(doc, infCarga, "vCarga", "1000.00", cteNamespace);
        AppendElement(doc, infCarga, "proPred", "MERCADORIA HOMOLOGACAO", cteNamespace);
        var infQ = AppendElement(doc, infCarga, "infQ", cteNamespace);
        AppendElement(doc, infQ, "cUnid", "01", cteNamespace);
        AppendElement(doc, infQ, "tpMed", "PESO BRUTO", cteNamespace);
        AppendElement(doc, infQ, "qCarga", "100.0000", cteNamespace);

        var infDoc = AppendElement(doc, infCteNorm, "infDoc", cteNamespace);
        var infNFe = AppendElement(doc, infDoc, "infNFe", cteNamespace);
        AppendElement(doc, infNFe, "chave", chaveNfeMock, cteNamespace);

        var infModal = AppendElement(doc, infCteNorm, "infModal", cteNamespace);
        infModal.SetAttribute("versaoModal", "4.00");
        var rodo = AppendElement(doc, infModal, "rodo", cteNamespace);
        AppendElement(doc, rodo, "RNTRC", "45861338", cteNamespace);

        var infRespTec = AppendElement(doc, infCte, "infRespTec", cteNamespace);
        AppendElement(doc, infRespTec, "CNPJ", parameters.CnpjEmitente, cteNamespace);
        AppendElement(doc, infRespTec, "xContato", "PLAY SISTEMAS INTELIGENTES", cteNamespace);
        AppendElement(doc, infRespTec, "email", "suporte@playsis.com.br", cteNamespace);
        AppendElement(doc, infRespTec, "fone", "62981595863", cteNamespace);

        var infCTeSupl = AppendElement(doc, cte, "infCTeSupl", cteNamespace);
        AppendElement(
            doc,
            infCTeSupl,
            "qrCodCTe",
            $"https://homologacao.nfe.fazenda.sp.gov.br/CTeConsulta/qrCode?chCTe={chave}&tpAmb={parameters.Ambiente}",
            cteNamespace);

        return doc.OuterXml;
    }

    private static void AppendIbsCbsHomologacao(XmlDocument doc, XmlElement imp, string cteNamespace)
    {
        var ibsCbs = AppendElement(doc, imp, "IBSCBS", cteNamespace);
        AppendElement(doc, ibsCbs, "CST", "000", cteNamespace);
        AppendElement(doc, ibsCbs, "cClassTrib", "000001", cteNamespace);

        var gIbsCbs = AppendElement(doc, ibsCbs, "gIBSCBS", cteNamespace);
        AppendElement(doc, gIbsCbs, "vBC", "100.00", cteNamespace);

        var gIbsUf = AppendElement(doc, gIbsCbs, "gIBSUF", cteNamespace);
        AppendElement(doc, gIbsUf, "pIBSUF", "0.1000", cteNamespace);
        AppendElement(doc, gIbsUf, "vIBSUF", "0.10", cteNamespace);

        var gIbsMun = AppendElement(doc, gIbsCbs, "gIBSMun", cteNamespace);
        AppendElement(doc, gIbsMun, "pIBSMun", "0.0000", cteNamespace);
        AppendElement(doc, gIbsMun, "vIBSMun", "0.00", cteNamespace);

        AppendElement(doc, gIbsCbs, "vIBS", "0.10", cteNamespace);

        var gCbs = AppendElement(doc, gIbsCbs, "gCBS", cteNamespace);
        AppendElement(doc, gCbs, "pCBS", "0.9000", cteNamespace);
        AppendElement(doc, gCbs, "vCBS", "0.90", cteNamespace);
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
        string xmlNamespace,
        bool incluirPais)
    {
        AppendElement(doc, parent, "xLgr", logradouro, xmlNamespace);
        AppendElement(doc, parent, "nro", numero, xmlNamespace);
        AppendElement(doc, parent, "xBairro", bairro, xmlNamespace);
        AppendElement(doc, parent, "cMun", codigoMunicipio, xmlNamespace);
        AppendElement(doc, parent, "xMun", municipio, xmlNamespace);
        AppendElement(doc, parent, "CEP", cep, xmlNamespace);
        AppendElement(doc, parent, "UF", uf, xmlNamespace);
        if (incluirPais)
        {
            AppendElement(doc, parent, "cPais", "1058", xmlNamespace);
            AppendElement(doc, parent, "xPais", "BRASIL", xmlNamespace);
        }
        else
        {
            AppendElement(doc, parent, "fone", "81999999999", xmlNamespace);
        }
    }

    private static string SignCteXml(string xml, X509Certificate2 certificate)
    {
        const string cteNamespace = "http://www.portalfiscal.inf.br/cte";

        var doc = new XmlDocument { PreserveWhitespace = false };
        doc.LoadXml(xml);

        var nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("cte", cteNamespace);

        var cteNode = doc.SelectSingleNode("/cte:CTe", nsmgr) as XmlElement
            ?? throw new InvalidOperationException("Nao foi possivel localizar o elemento CTe.");

        var infCteNode = doc.SelectSingleNode("/cte:CTe/cte:infCte", nsmgr) as XmlElement
            ?? throw new InvalidOperationException("Nao foi possivel localizar o elemento infCte.");

        var id = infCteNode.GetAttribute("Id");
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new InvalidOperationException("O atributo Id do infCte nao pode estar vazio.");
        }

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
        {
            throw new InvalidOperationException("A assinatura digital do CT-e nao passou na validacao local.");
        }

        return doc.DocumentElement!.OuterXml;
    }

    private static string RemoveExistingSignature(string xml)
    {
        var doc = new XmlDocument { PreserveWhitespace = false };
        doc.LoadXml(xml);

        var signatures = doc.GetElementsByTagName("Signature", SignedXml.XmlDsigNamespaceUrl);
        for (var i = signatures.Count - 1; i >= 0; i--)
        {
            var signature = signatures[i];
            signature?.ParentNode?.RemoveChild(signature);
        }

        return doc.DocumentElement!.OuterXml;
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
            {
                weight = 2;
            }
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
            {
                sb.Append(character);
            }
        }

        return sb.ToString();
    }

    private static string BuildIncompleteCteXml()
    {
        const string cteNamespace = "http://www.portalfiscal.inf.br/cte";

        var doc = new XmlDocument { PreserveWhitespace = false };
        var cte = doc.CreateElement("CTe", cteNamespace);
        cte.SetAttribute("versao", "4.00");
        doc.AppendChild(cte);

        var infCte = doc.CreateElement("infCte", cteNamespace);
        infCte.SetAttribute("Id", "CTe99999999999999999999999999999999999999999999");
        infCte.SetAttribute("versao", "4.00");
        cte.AppendChild(infCte);

        return doc.OuterXml;
    }

    private static XmlElement AppendElement(XmlDocument doc, XmlElement parent, string name, string xmlNamespace)
    {
        var element = doc.CreateElement(name, xmlNamespace);
        parent.AppendChild(element);
        return element;
    }

    private static XmlElement AppendElement(XmlDocument doc, XmlElement parent, string name, string value, string xmlNamespace)
    {
        var element = AppendElement(doc, parent, name, xmlNamespace);
        element.InnerText = value;
        return element;
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
}

internal sealed record CteConsultaParameters(
    CteStatusServicoParameters Common,
    string ChaveAcesso)
{
    public const string ConsultaEndpoint = "https://homologacao.nfe.fazenda.sp.gov.br/CTeWS/WS/CTeConsultaV4.asmx";
    public const string ConsultaSoapAction = "http://www.portalfiscal.inf.br/cte/wsdl/CTeConsultaV4/cteConsultaCT";
    public const string ConsultaServiceNamespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeConsultaV4";
    public const string FixedHomologacaoChave = "26260963249950000174570012031803051068183220";

    public void ValidateForSend()
    {
        Common.ValidateForSend();

        if (ChaveAcesso.Length != 44 || ChaveAcesso.Any(character => character is < '0' or > '9'))
            throw new InvalidOperationException("A chave do CT-e deve possuir exatamente 44 digitos.");
    }
}

internal static class CteConsultaPlayground
{
    public static async Task RunAsync(string[] args)
    {
        var parameters = BuildParameters(args);

        Console.WriteLine("Yeshua.Engine.Playground - CT-e ConsultaV4 isolada");
        Console.WriteLine($"Endpoint: {parameters.Common.Endpoint}");
        Console.WriteLine($"Ambiente: {parameters.Common.Ambiente}");
        Console.WriteLine($"UF: {parameters.Common.CodigoUf}");
        Console.WriteLine($"Certificado: {parameters.Common.CertificatePath}");
        Console.WriteLine($"Chave: {parameters.ChaveAcesso}");
        Console.WriteLine();

        parameters.ValidateForSend();

        var consultaXml = BuildConsultaXml(parameters);
        var soapEnvelope = WrapConsultaInSoapEnvelope(consultaXml);
        MdfeSefazPlaygroundOptions.ValidateXml(soapEnvelope, "envelope SOAP CT-e consulta");
        MdfeSefazPlaygroundOptions.ValidateNoFormattingWhitespace(soapEnvelope, "envelope SOAP CT-e consulta");

        if (args.Contains("--mostrar-xml", StringComparer.OrdinalIgnoreCase))
        {
            Console.WriteLine(soapEnvelope);
            Console.WriteLine();
        }

        if (args.Contains("--somente-validar", StringComparer.OrdinalIgnoreCase))
        {
            Console.WriteLine("XML de consulta CT-e validado localmente. Nenhuma chamada foi feita ao SEFAZ.");
            return;
        }

        using var certificate = MdfeSefazPlaygroundOptions.LoadCertificate(
            parameters.Common.CertificatePath,
            parameters.Common.CertificatePassword);

        using var handler = new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            SslProtocols = SslProtocols.Tls12,
            UseProxy = false
        };
        handler.ClientCertificates.Add(certificate);

        using var httpClient = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(parameters.Common.TimeoutSeconds)
        };

        Console.WriteLine("Consultando CT-e na SEFAZ (SOAP 1.2)...");

        using var request = new HttpRequestMessage(HttpMethod.Post, parameters.Common.Endpoint)
        {
            Version = HttpVersion.Version11,
            Content = new StringContent(soapEnvelope, Encoding.UTF8, parameters.Common.ContentMediaType)
        };

        request.Content.Headers.ContentType!.CharSet = "utf-8";
        request.Content.Headers.ContentType.Parameters.Add(
            new NameValueHeaderValue("action", $"\"{parameters.Common.SoapAction}\""));
        request.Headers.ExpectContinue = false;
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

        var response = await httpClient.SendAsync(request);
        var responseBody = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
        if (!string.IsNullOrWhiteSpace(responseBody))
        {
            Console.WriteLine(responseBody);
            PrintResponseSummary(responseBody);
            SefazDownloadArtifacts.SaveIfRequested(
                args,
                force: args.Contains("--cte-baixar", StringComparer.OrdinalIgnoreCase),
                documentType: "cte",
                serviceName: "consulta",
                key: parameters.ChaveAcesso,
                responseBody: responseBody,
                businessReturnElementNames: ["retConsSitCTe"]);
        }
    }

    private static CteConsultaParameters BuildParameters(string[] args)
    {
        var common = CteStatusServicoPlayground.BuildParameters(args) with
        {
            Endpoint = GetArg(args, "--cte-consulta-endpoint")
                ?? GetArg(args, "--cte-endpoint")
                ?? Environment.GetEnvironmentVariable("YESHUA_CTE_CONSULTA_ENDPOINT")
                ?? CteConsultaParameters.ConsultaEndpoint,
            SoapAction = CteConsultaParameters.ConsultaSoapAction
        };

        var chave = OnlyDigits(
            GetArg(args, "--cte-chave")
            ?? Environment.GetEnvironmentVariable("YESHUA_CTE_CHAVE")
            ?? CteConsultaParameters.FixedHomologacaoChave);

        return new CteConsultaParameters(common, chave);
    }

    private static string BuildConsultaXml(CteConsultaParameters parameters)
    {
        const string cteNamespace = "http://www.portalfiscal.inf.br/cte";

        var doc = new XmlDocument { PreserveWhitespace = false };
        var root = doc.CreateElement("consSitCTe", cteNamespace);
        root.SetAttribute("versao", "4.00");
        doc.AppendChild(root);

        AppendElement(doc, root, "tpAmb", parameters.Common.Ambiente.ToString(), cteNamespace);
        AppendElement(doc, root, "xServ", "CONSULTAR", cteNamespace);
        AppendElement(doc, root, "chCTe", parameters.ChaveAcesso, cteNamespace);

        return doc.OuterXml;
    }

    private static string WrapConsultaInSoapEnvelope(string innerXml)
    {
        const string soapNamespace = "http://www.w3.org/2003/05/soap-envelope";

        var consulta = new XmlDocument { PreserveWhitespace = false };
        consulta.LoadXml(innerXml);

        var soap = new XmlDocument { PreserveWhitespace = true };
        var envelope = soap.CreateElement("soap12", "Envelope", soapNamespace);
        envelope.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
        envelope.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
        soap.AppendChild(envelope);

        var body = soap.CreateElement("soap12", "Body", soapNamespace);
        envelope.AppendChild(body);

        var dados = soap.CreateElement("cteDadosMsg", CteConsultaParameters.ConsultaServiceNamespace);
        body.AppendChild(dados);
        dados.AppendChild(soap.ImportNode(consulta.DocumentElement!, true));

        return soap.OuterXml;
    }

    private static void PrintResponseSummary(string responseBody)
    {
        var doc = new XmlDocument { PreserveWhitespace = true };
        try
        {
            doc.LoadXml(responseBody);
        }
        catch (XmlException)
        {
            return;
        }

        var cStat = ReadFirst(doc, "cStat");
        var xMotivo = ReadFirst(doc, "xMotivo");
        var chCTe = ReadFirst(doc, "chCTe");
        var nProt = ReadFirst(doc, "nProt");

        if (!string.IsNullOrWhiteSpace(cStat) || !string.IsNullOrWhiteSpace(xMotivo))
        {
            Console.WriteLine();
            Console.WriteLine($"Resumo SEFAZ: {cStat} - {xMotivo}");
        }

        if (!string.IsNullOrWhiteSpace(chCTe))
            Console.WriteLine($"chCTe: {chCTe}");

        if (!string.IsNullOrWhiteSpace(nProt))
            Console.WriteLine($"nProt: {nProt}");
    }

    private static XmlElement AppendElement(XmlDocument doc, XmlElement parent, string name, string value, string xmlNamespace)
    {
        var element = doc.CreateElement(name, xmlNamespace);
        element.InnerText = value;
        parent.AppendChild(element);
        return element;
    }

    private static string? ReadFirst(XmlDocument doc, string localName)
    {
        return doc.SelectSingleNode($"//*[local-name()='{localName}']")?.InnerText;
    }

    private static string? GetArg(string[] args, string name)
    {
        for (var i = 0; i < args.Length - 1; i++)
        {
            if (string.Equals(args[i], name, StringComparison.OrdinalIgnoreCase))
                return args[i + 1];
        }

        return null;
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

internal static class SefazDownloadArtifacts
{
    public static void SaveIfRequested(
        string[] args,
        bool force,
        string documentType,
        string serviceName,
        string key,
        string responseBody,
        string[] businessReturnElementNames)
    {
        var outputDir = GetArg(args, "--saida")
            ?? GetArg(args, "--output")
            ?? Environment.GetEnvironmentVariable("YESHUA_SEFAZ_DOWNLOAD_DIR")
            ?? Path.Combine("artifacts", "sefaz-downloads");

        if (!force &&
            GetArg(args, "--saida") is null &&
            GetArg(args, "--output") is null &&
            Environment.GetEnvironmentVariable("YESHUA_SEFAZ_DOWNLOAD_DIR") is null)
        {
            return;
        }

        Directory.CreateDirectory(outputDir);

        var safeKey = string.IsNullOrWhiteSpace(key) ? "sem-chave" : OnlySafeFileName(key);
        var prefix = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + "-" + documentType + "-" + serviceName + "-" + safeKey;
        var soapPath = Path.Combine(outputDir, prefix + "-soap.xml");

        File.WriteAllText(soapPath, responseBody, Encoding.UTF8);
        Console.WriteLine($"Arquivo SOAP salvo: {Path.GetFullPath(soapPath)}");

        var businessXml = ExtractFirstElement(responseBody, businessReturnElementNames);
        if (string.IsNullOrWhiteSpace(businessXml))
            return;

        var businessPath = Path.Combine(outputDir, prefix + "-retorno.xml");
        File.WriteAllText(businessPath, businessXml, Encoding.UTF8);
        Console.WriteLine($"Arquivo retorno salvo: {Path.GetFullPath(businessPath)}");
    }

    private static string? ExtractFirstElement(string xml, string[] localNames)
    {
        var doc = new XmlDocument { PreserveWhitespace = true };
        try
        {
            doc.LoadXml(xml);
        }
        catch (XmlException)
        {
            return null;
        }

        foreach (var localName in localNames)
        {
            var node = doc.SelectSingleNode($"//*[local-name()='{localName}']");
            if (node is not null)
                return node.OuterXml;
        }

        return null;
    }

    private static string? GetArg(string[] args, string name)
    {
        for (var i = 0; i < args.Length - 1; i++)
        {
            if (string.Equals(args[i], name, StringComparison.OrdinalIgnoreCase))
                return args[i + 1];
        }

        return null;
    }

    private static string OnlySafeFileName(string value)
    {
        var invalid = Path.GetInvalidFileNameChars();
        var builder = new StringBuilder(value.Length);
        foreach (var character in value)
        {
            builder.Append(invalid.Contains(character) ? '_' : character);
        }

        return builder.ToString();
    }
}

internal static class MdfeRecepcaoSincFiscalPlayground
{
    public static Task RunAsync(string[] args)
    {
        var chaveCTe = GetArg(args, "--mdfe-chave-cte")
            ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_CHCTE")
            ?? string.Empty;

        Console.WriteLine("Yeshua.Engine.Playground - MDF-e RecepcaoSinc Fiscal");
        Console.WriteLine("Origem da implementacao: Yeshua.Fiscal.CQRS.Application.Command");
        Console.WriteLine();

        var result = Command.Receivers.MdfeRecepcaoSincHomologacaoClient.Autorizar(chaveCTe);

        Console.WriteLine($"Status HTTP: {result.HttpStatusCode}");
        Console.WriteLine($"Autorizado: {result.Autorizado}");
        Console.WriteLine($"cStat: {result.CodigoRetorno}");
        Console.WriteLine($"xMotivo: {result.Motivo}");
        Console.WriteLine($"chMDFe: {result.Chave}");
        Console.WriteLine($"nProt: {result.Protocolo}");

        if (args.Contains("--mostrar-xml", StringComparer.OrdinalIgnoreCase))
        {
            Console.WriteLine();
            Console.WriteLine(result.XmlMDFe);
            Console.WriteLine();
            Console.WriteLine(result.SoapResponse);
        }

        return Task.CompletedTask;
    }

    private static string? GetArg(string[] args, string name)
    {
        for (var i = 0; i < args.Length - 1; i++)
        {
            if (string.Equals(args[i], name, StringComparison.OrdinalIgnoreCase))
                return args[i + 1];
        }

        return null;
    }
}

internal enum MdfeSefazService
{
    RecepcaoEvento,
    Consulta,
    StatusServico,
    ConsNaoEnc
}

internal static class MdfePlayground
{
    public static async Task RunAsync(string[] args)
    {
        if (HasArg(args, "--mdfe-encerramento"))
        {
            await RunEncerramentoAsync(args);
            return;
        }

        if (HasArg(args, "--mdfe-consulta") || HasArg(args, "--mdfe-baixar"))
        {
            await RunConsultaAsync(args);
            return;
        }

        if (HasArg(args, "--mdfe-nao-encerrados"))
        {
            await RunNaoEncerradosAsync(args);
            return;
        }

        await RunStatusServicoAsync(args);
    }

    private static async Task RunStatusServicoAsync(string[] args)
    {
        var options = MdfeSefazPlaygroundOptions.FromArgs(args, MdfeSefazService.StatusServico);

        Console.WriteLine("Yeshua.Engine.Playground - MDF-e StatusServico isolado");
        PrintCommonOptions(options);

        options.Event.ValidateForStatus();
        using var certificate = MdfeSefazPlaygroundOptions.LoadCertificate(
            options.Event.CertificatePath,
            options.Event.CertificatePassword);

        var statusXml = MdfeSefazPlaygroundOptions.BuildStatusServicoXml(options.Event);
        await SendSoapAsync(args, options, statusXml, certificate, "consulta de status MDF-e");
    }

    private static async Task RunConsultaAsync(string[] args)
    {
        var options = MdfeSefazPlaygroundOptions.FromArgs(args, MdfeSefazService.Consulta);

        Console.WriteLine("Yeshua.Engine.Playground - MDF-e Consulta isolada");
        PrintCommonOptions(options);
        Console.WriteLine($"Chave: {options.Event.ChaveAcesso}");
        Console.WriteLine();

        options.Event.ValidateForConsulta();
        using var certificate = MdfeSefazPlaygroundOptions.LoadCertificate(
            options.Event.CertificatePath,
            options.Event.CertificatePassword);

        var consultaXml = MdfeSefazPlaygroundOptions.BuildConsultaXml(options.Event);
        await SendSoapAsync(args, options, consultaXml, certificate, "consulta de situacao MDF-e");
    }

    private static async Task RunNaoEncerradosAsync(string[] args)
    {
        var options = MdfeSefazPlaygroundOptions.FromArgs(args, MdfeSefazService.ConsNaoEnc);

        Console.WriteLine("Yeshua.Engine.Playground - MDF-e Nao Encerrados isolado");
        PrintCommonOptions(options);
        Console.WriteLine($"CNPJ: {options.Event.Cnpj}");
        Console.WriteLine();

        options.Event.ValidateForNaoEncerrados();
        using var certificate = MdfeSefazPlaygroundOptions.LoadCertificate(
            options.Event.CertificatePath,
            options.Event.CertificatePassword);

        var consultaXml = MdfeSefazPlaygroundOptions.BuildNaoEncerradosXml(options.Event);
        await SendSoapAsync(args, options, consultaXml, certificate, "consulta MDF-e nao encerrados");
    }

    private static async Task RunEncerramentoAsync(string[] args)
    {
        var options = MdfeSefazPlaygroundOptions.FromArgs(args, MdfeSefazService.RecepcaoEvento);

        Console.WriteLine("Yeshua.Engine.Playground - MDF-e encerramento isolado");
        PrintCommonOptions(options);
        Console.WriteLine($"Chave: {options.Event.ChaveAcesso}");
        Console.WriteLine($"Protocolo autorizacao: {options.Event.ProtocoloAutorizacao}");
        Console.WriteLine($"Encerramento: {options.Event.CodigoMunicipioEncerramento}/{options.Event.CodigoUfEncerramento}");
        Console.WriteLine();

        options.Event.Validate();
        using var certificate = MdfeSefazPlaygroundOptions.LoadCertificate(
            options.Event.CertificatePath,
            options.Event.CertificatePassword);

        var eventoXml = MdfeSefazPlaygroundOptions.BuildEventoXml(options.Event);
        var signedEventoXml = MdfeSefazPlaygroundOptions.SignEventoXml(eventoXml, certificate);
        MdfeSefazPlaygroundOptions.ValidateNoFormattingWhitespace(signedEventoXml, "evento MDF-e assinado");

        await SendSoapAsync(args, options, signedEventoXml, certificate, "evento MDF-e assinado");
    }

    private static async Task SendSoapAsync(
        string[] args,
        MdfeSefazPlaygroundOptions options,
        string payloadXml,
        X509Certificate2 certificate,
        string payloadDescription)
    {
        MdfeSefazPlaygroundOptions.ValidateXml(payloadXml, payloadDescription);
        MdfeSefazPlaygroundOptions.ValidateNoFormattingWhitespace(payloadXml, payloadDescription);

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

        if (HasArg(args, "--consultar-wsdl"))
        {
            var wsdlResponse = await httpClient.GetAsync(options.Endpoint + "?wsdl");
            var wsdl = await wsdlResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"WSDL: {(int)wsdlResponse.StatusCode} {wsdlResponse.StatusCode}");
            Console.WriteLine(wsdl);
            return;
        }

        var soapEnvelope = MdfeSefazPlaygroundOptions.WrapInSoapEnvelope(
            payloadXml,
            options.Event.CodigoOrgao,
            options.ServiceNamespace);
        MdfeSefazPlaygroundOptions.ValidateXml(soapEnvelope, "envelope SOAP MDF-e");
        MdfeSefazPlaygroundOptions.ValidateNoFormattingWhitespace(soapEnvelope, "envelope SOAP MDF-e");

        if (HasArg(args, "--mostrar-xml"))
        {
            Console.WriteLine(soapEnvelope);
            Console.WriteLine();
        }

        if (HasArg(args, "--somente-validar"))
        {
            Console.WriteLine("XML e envelope SOAP validados localmente. Nenhuma chamada foi feita ao SEFAZ.");
            return;
        }

        Console.WriteLine("Enviando XML para o SEFAZ (SOAP 1.2)...");

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

        try
        {
            var response = await httpClient.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
            if (!string.IsNullOrWhiteSpace(responseBody))
            {
                Console.WriteLine(responseBody);
                PrintResponseSummary(responseBody);
                SefazDownloadArtifacts.SaveIfRequested(
                    args,
                    force: HasArg(args, "--mdfe-baixar"),
                    documentType: "mdfe",
                    serviceName: options.Service.ToString().ToLowerInvariant(),
                    key: options.Event.ChaveAcesso,
                    responseBody: responseBody,
                    businessReturnElementNames: new[] { "retConsSitMDFe", "retConsMDFeNaoEnc", "retConsStatServMDFe", "retEventoMDFe" });
            }
        }
        catch (HttpRequestException exception)
        {
            Console.WriteLine("Falha na chamada HTTP/SOAP ao SEFAZ.");
            Console.WriteLine(exception.Message);
            if (exception.InnerException is not null)
            {
                Console.WriteLine(exception.InnerException.Message);
            }
        }
    }

    private static void PrintCommonOptions(MdfeSefazPlaygroundOptions options)
    {
        Console.WriteLine($"Servico: {options.Service}");
        Console.WriteLine($"Endpoint: {options.Endpoint}");
        Console.WriteLine($"Ambiente: {options.Event.Ambiente}");
        Console.WriteLine($"Orgao: {options.Event.CodigoOrgao}");
        Console.WriteLine($"Certificado: {options.Event.CertificatePath}");
    }

    private static void PrintResponseSummary(string responseBody)
    {
        var doc = new XmlDocument { PreserveWhitespace = true };
        try
        {
            doc.LoadXml(responseBody);
        }
        catch (XmlException)
        {
            return;
        }

        var cStat = ReadFirst(doc, "cStat");
        var xMotivo = ReadFirst(doc, "xMotivo");
        var chMDFe = ReadFirst(doc, "chMDFe");
        var nProt = ReadFirst(doc, "nProt");

        if (!string.IsNullOrWhiteSpace(cStat) || !string.IsNullOrWhiteSpace(xMotivo))
        {
            Console.WriteLine();
            Console.WriteLine($"Resumo SEFAZ: {cStat} - {xMotivo}");
        }

        if (!string.IsNullOrWhiteSpace(chMDFe))
        {
            Console.WriteLine($"chMDFe: {chMDFe}");
        }

        if (!string.IsNullOrWhiteSpace(nProt))
        {
            Console.WriteLine($"nProt: {nProt}");
        }
    }

    private static string? ReadFirst(XmlDocument doc, string localName)
    {
        return doc.SelectSingleNode($"//*[local-name()='{localName}']")?.InnerText;
    }

    private static bool HasArg(string[] args, string name)
    {
        return args.Contains(name, StringComparer.OrdinalIgnoreCase);
    }
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

    // Perfil historico que ja provou encerramento real de MDF-e contra a SVRS.
    public static MdfeEncerramentoParameters FixedMinasHistorico { get; } = new(
        CodigoOrgao: 31,
        Ambiente: 1,
        Cnpj: "57152543000141",
        ChaveAcesso: "31260757152543000141580200000056051000560591",
        ProtocoloAutorizacao: "931260037261399",
        CertificatePath: @"C:\Users\AngeloRicardoFontana\Downloads\57152543000141.pfx",
        CertificatePassword: "27111983",
        CodigoUfEncerramento: 31,
        CodigoMunicipioEncerramento: 3167202,
        SequenciaEvento: 1);

    // Perfil Pernambuco. O documento e de PE, mas o encerramento pode ocorrer em outro municipio.
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

    public static MdfeEncerramentoParameters FromArgs(string[] args)
    {
        var profile = GetArg(args, "--mdfe-perfil")
            ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_PERFIL")
            ?? "minas";

        var fixedParameters = string.Equals(profile, "pe", StringComparison.OrdinalIgnoreCase) ||
                              string.Equals(profile, "pernambuco", StringComparison.OrdinalIgnoreCase)
            ? FixedPernambuco
            : FixedMinasHistorico;

        return fixedParameters with
        {
            CodigoOrgao = GetInt(args, "--mdfe-cuf", "YESHUA_MDFE_CUF", fixedParameters.CodigoOrgao),
            Ambiente = GetInt(args, "--mdfe-ambiente", "YESHUA_MDFE_AMBIENTE", fixedParameters.Ambiente),
            Cnpj = OnlyDigits(GetValue(args, "--mdfe-cnpj", "YESHUA_MDFE_CNPJ", fixedParameters.Cnpj)),
            ChaveAcesso = OnlyDigits(GetValue(args, "--mdfe-chave", "YESHUA_MDFE_CHAVE", fixedParameters.ChaveAcesso)),
            ProtocoloAutorizacao = OnlyDigits(GetValue(args, "--mdfe-protocolo", "YESHUA_MDFE_PROTOCOLO", fixedParameters.ProtocoloAutorizacao)),
            CertificatePath = GetValue(args, "--mdfe-cert", "YESHUA_MDFE_CERT", fixedParameters.CertificatePath),
            CertificatePassword = GetValue(args, "--mdfe-senha", "YESHUA_MDFE_SENHA", fixedParameters.CertificatePassword),
            CodigoUfEncerramento = GetInt(args, "--mdfe-uf-encerramento", "YESHUA_MDFE_UF_ENCERRAMENTO", fixedParameters.CodigoUfEncerramento),
            CodigoMunicipioEncerramento = GetInt(args, "--mdfe-municipio-encerramento", "YESHUA_MDFE_MUNICIPIO_ENCERRAMENTO", fixedParameters.CodigoMunicipioEncerramento),
            SequenciaEvento = GetInt(args, "--mdfe-seq", "YESHUA_MDFE_SEQ", fixedParameters.SequenciaEvento)
        };
    }

    public string EventId => $"ID{TipoEvento}{ChaveAcesso}{SequenciaEvento:D2}";

    public void Validate()
    {
        ValidateForConsulta();
        ValidateDigits(ProtocoloAutorizacao, 15, nameof(ProtocoloAutorizacao));

        ValidateDigits(Cnpj, 14, nameof(Cnpj));

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

    public void ValidateForStatus()
    {
        ValidateCertificate();
        ValidateEnvironment();

        if (CodigoOrgao <= 0)
            throw new InvalidOperationException("O cOrgao do MDF-e deve ser informado.");
    }

    public void ValidateForConsulta()
    {
        ValidateForStatus();
        ValidateDigits(ChaveAcesso, 44, nameof(ChaveAcesso));
    }

    public void ValidateForNaoEncerrados()
    {
        ValidateForStatus();
        ValidateDigits(Cnpj, 14, nameof(Cnpj));
    }

    private void ValidateCertificate()
    {
        if (string.IsNullOrWhiteSpace(CertificatePath))
            throw new InvalidOperationException("O caminho do certificado deve ser informado.");

        if (!File.Exists(CertificatePath))
            throw new FileNotFoundException("Certificado MDF-e nao encontrado.", CertificatePath);

        if (string.IsNullOrWhiteSpace(CertificatePassword) ||
            CertificatePassword == "PREENCHER_SENHA_DO_CERTIFICADO")
        {
            throw new InvalidOperationException("Preencha a senha do certificado nos parametros fixos do MDF-e.");
        }
    }

    private void ValidateEnvironment()
    {
        if (Ambiente is not 1 and not 2)
            throw new InvalidOperationException("O ambiente deve ser 1 (producao) ou 2 (homologacao).");
    }

    private static void ValidateDigits(string value, int length, string fieldName)
    {
        if (value.Length != length || value.Any(character => character is < '0' or > '9'))
            throw new InvalidOperationException($"{fieldName} deve possuir exatamente {length} digitos.");
    }

    private static string GetValue(string[] args, string argName, string envName, string fallback)
    {
        return GetArg(args, argName)
            ?? Environment.GetEnvironmentVariable(envName)
            ?? fallback;
    }

    private static int GetInt(string[] args, string argName, string envName, int fallback)
    {
        var text = GetArg(args, argName)
            ?? Environment.GetEnvironmentVariable(envName);

        return int.TryParse(text, out var value) ? value : fallback;
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

    private static string OnlyDigits(string value)
    {
        var buffer = new StringBuilder(value.Length);
        foreach (var character in value)
        {
            if (character is >= '0' and <= '9')
            {
                buffer.Append(character);
            }
        }

        return buffer.ToString();
    }
}

internal sealed record MdfeSefazPlaygroundOptions(
    MdfeSefazService Service,
    string Endpoint,
    string SoapAction,
    string ContentMediaType,
    int TimeoutSeconds,
    string ServiceNamespace,
    MdfeEncerramentoParameters Event)
{
    public static MdfeSefazPlaygroundOptions FromArgs(
        string[] args,
        MdfeSefazService service = MdfeSefazService.RecepcaoEvento)
    {
        var eventParameters = MdfeEncerramentoParameters.FromArgs(args);
        var serviceEnvName = GetServiceEnvironmentName(service);

        var endpoint = GetArg(args, "--endpoint")
            ?? Environment.GetEnvironmentVariable($"YESHUA_MDFE_{serviceEnvName}_ENDPOINT")
            ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_ENDPOINT")
            ?? ResolveEndpoint(service, eventParameters.Ambiente);

        var soapAction = GetArg(args, "--soap-action")
            ?? Environment.GetEnvironmentVariable($"YESHUA_MDFE_{serviceEnvName}_SOAP_ACTION")
            ?? Environment.GetEnvironmentVariable("YESHUA_MDFE_SOAP_ACTION")
            ?? ResolveSoapAction(service);

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
            service,
            endpoint,
            soapAction,
            contentType,
            timeoutSeconds,
            ResolveServiceNamespace(service),
            eventParameters);
    }

    private static string ResolveEndpoint(MdfeSefazService service, int ambiente)
    {
        var host = ambiente == 2
            ? "https://mdfe-homologacao.svrs.rs.gov.br"
            : "https://mdfe.svrs.rs.gov.br";

        var serviceName = service switch
        {
            MdfeSefazService.RecepcaoEvento => "MDFeRecepcaoEvento",
            MdfeSefazService.Consulta => "MDFeConsulta",
            MdfeSefazService.StatusServico => "MDFeStatusServico",
            MdfeSefazService.ConsNaoEnc => "MDFeConsNaoEnc",
            _ => throw new InvalidOperationException("Servico MDF-e nao suportado.")
        };

        return $"{host}/ws/{serviceName}/{serviceName}.asmx";
    }

    private static string ResolveServiceNamespace(MdfeSefazService service)
    {
        var serviceName = service switch
        {
            MdfeSefazService.RecepcaoEvento => "MDFeRecepcaoEvento",
            MdfeSefazService.Consulta => "MDFeConsulta",
            MdfeSefazService.StatusServico => "MDFeStatusServico",
            MdfeSefazService.ConsNaoEnc => "MDFeConsNaoEnc",
            _ => throw new InvalidOperationException("Servico MDF-e nao suportado.")
        };

        return $"http://www.portalfiscal.inf.br/mdfe/wsdl/{serviceName}";
    }

    private static string ResolveSoapAction(MdfeSefazService service)
    {
        var methodName = service switch
        {
            MdfeSefazService.RecepcaoEvento => "mdfeRecepcaoEvento",
            MdfeSefazService.Consulta => "mdfeConsultaMDF",
            MdfeSefazService.StatusServico => "mdfeStatusServicoMDF",
            MdfeSefazService.ConsNaoEnc => "mdfeConsNaoEnc",
            _ => throw new InvalidOperationException("Servico MDF-e nao suportado.")
        };

        return $"{ResolveServiceNamespace(service)}/{methodName}";
    }

    private static string GetServiceEnvironmentName(MdfeSefazService service)
    {
        return service switch
        {
            MdfeSefazService.RecepcaoEvento => "RECEPCAO_EVENTO",
            MdfeSefazService.Consulta => "CONSULTA",
            MdfeSefazService.StatusServico => "STATUS",
            MdfeSefazService.ConsNaoEnc => "NAO_ENCERRADOS",
            _ => "SERVICO"
        };
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

    public static string BuildStatusServicoXml(MdfeEncerramentoParameters parameters)
    {
        const string mdfeNamespace = "http://www.portalfiscal.inf.br/mdfe";
        var doc = new XmlDocument { PreserveWhitespace = false };
        var root = doc.CreateElement("consStatServMDFe", mdfeNamespace);
        root.SetAttribute("versao", "3.00");
        doc.AppendChild(root);

        AppendElement(doc, root, "tpAmb", parameters.Ambiente.ToString(), mdfeNamespace);
        AppendElement(doc, root, "xServ", "STATUS", mdfeNamespace);

        return doc.OuterXml;
    }

    public static string BuildConsultaXml(MdfeEncerramentoParameters parameters)
    {
        const string mdfeNamespace = "http://www.portalfiscal.inf.br/mdfe";
        var doc = new XmlDocument { PreserveWhitespace = false };
        var root = doc.CreateElement("consSitMDFe", mdfeNamespace);
        root.SetAttribute("versao", "3.00");
        doc.AppendChild(root);

        AppendElement(doc, root, "tpAmb", parameters.Ambiente.ToString(), mdfeNamespace);
        AppendElement(doc, root, "xServ", "CONSULTAR", mdfeNamespace);
        AppendElement(doc, root, "chMDFe", parameters.ChaveAcesso, mdfeNamespace);

        return doc.OuterXml;
    }

    public static string BuildNaoEncerradosXml(MdfeEncerramentoParameters parameters)
    {
        const string mdfeNamespace = "http://www.portalfiscal.inf.br/mdfe";
        var doc = new XmlDocument { PreserveWhitespace = false };
        var root = doc.CreateElement("consMDFeNaoEnc", mdfeNamespace);
        root.SetAttribute("versao", "3.00");
        doc.AppendChild(root);

        AppendElement(doc, root, "tpAmb", parameters.Ambiente.ToString(), mdfeNamespace);
        AppendElement(doc, root, "xServ", "CONSULTAR N\u00C3O ENCERRADOS", mdfeNamespace);
        AppendElement(doc, root, "CNPJ", parameters.Cnpj, mdfeNamespace);

        return doc.OuterXml;
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
        using var sourceCertificate = new X509Certificate2(
            path,
            password,
            X509KeyStorageFlags.EphemeralKeySet | X509KeyStorageFlags.Exportable);

        var storeCertificate = TryLoadCertificateFromCurrentUserStore(sourceCertificate.Thumbprint);
        if (storeCertificate is not null)
        {
            return storeCertificate;
        }

        X509Certificate2? certificate = null;
        try
        {
            certificate = new X509Certificate2(
                path,
                password,
                X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

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
                X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

            if (!certificate.HasPrivateKey)
                throw new InvalidOperationException("O certificado nao possui chave privada RSA.");

            return certificate;
        }
    }

    private static X509Certificate2? TryLoadCertificateFromCurrentUserStore(string thumbprint)
    {
        if (!OperatingSystem.IsWindows())
        {
            return null;
        }

        using var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
        store.Open(OpenFlags.ReadOnly);
        var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, validOnly: false);

        foreach (var certificate in certificates)
        {
            if (certificate.HasPrivateKey)
            {
                return certificate;
            }

            certificate.Dispose();
        }

        return null;
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
        const string serviceNamespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoEvento";

        return WrapInSoapEnvelope(innerXml, codigoOrgao, serviceNamespace);
    }

    public static string WrapInSoapEnvelope(string innerXml, int codigoOrgao, string serviceNamespace)
    {
        const string soapNamespace = "http://www.w3.org/2003/05/soap-envelope";

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
