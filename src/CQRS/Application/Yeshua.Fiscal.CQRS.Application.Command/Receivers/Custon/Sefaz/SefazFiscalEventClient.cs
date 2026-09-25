using IRepository.Read;
using Repositorio.Outputs;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

namespace Command.Receivers;

internal sealed record SefazFiscalEventContext(
    string ChaveAcesso,
    string ProtocoloAutorizacao,
    int Ambiente,
    int CodigoOrgao,
    string CnpjEmitente,
    int TenantId,
    FiscalCertificateReference Certificate);

internal sealed record SefazFiscalEventResult(
    bool Registrado,
    int CodigoRetorno,
    string Motivo,
    string ChaveAcesso,
    string? ProtocoloEvento,
    int HttpStatusCode,
    string EventoXml,
    string SoapResponse);

internal static class SefazFiscalEventContextResolver
{
    public static SefazFiscalEventContext ResolveCTe(
        string chave,
        ICTeTentativaEmissaoReadRepository tentativaRepository,
        IDocumentoFiscalReadRepository documentoRepository,
        ICertificadoDigitalReadRepository certificadoRepository)
    {
        var normalized = Digits(chave);
        ValidateKey(normalized, "CT-e");
        var tentativa = tentativaRepository.FirstByChaveAcesso(normalized);
        return Resolve(normalized, tentativa?.protocoloautorizacao, tentativa?.tenantid ?? 0,
            documentoRepository, certificadoRepository, "CT-e");
    }

    public static SefazFiscalEventContext ResolveMDFe(
        string chave,
        IMDFeTentativaEmissaoReadRepository tentativaRepository,
        IDocumentoFiscalReadRepository documentoRepository,
        ICertificadoDigitalReadRepository certificadoRepository)
    {
        var normalized = Digits(chave);
        ValidateKey(normalized, "MDF-e");
        var tentativa = tentativaRepository.FirstByChaveAcesso(normalized);
        return Resolve(normalized, tentativa?.protocoloautorizacao, tentativa?.tenantid ?? 0,
            documentoRepository, certificadoRepository, "MDF-e");
    }

    private static SefazFiscalEventContext Resolve(
        string chave,
        string? protocoloTentativa,
        int tenantTentativa,
        IDocumentoFiscalReadRepository documentoRepository,
        ICertificadoDigitalReadRepository certificadoRepository,
        string tipo)
    {
        var documento = documentoRepository.FirstByChaveAcesso(chave);
        var tenantId = documento?.tenantid > 0 ? documento.tenantid : tenantTentativa;
        if (tenantId <= 0)
            throw new InvalidOperationException($"{tipo} {chave}: tenant nao foi localizado.");

        var protocolo = !string.IsNullOrWhiteSpace(protocoloTentativa)
            ? protocoloTentativa
            : documento?.protocoloautorizacao;
        if (string.IsNullOrWhiteSpace(protocolo))
            throw new InvalidOperationException($"{tipo} {chave}: protocolo de autorizacao nao foi localizado.");

        var cnpj = chave.Substring(6, 14);
        var certificado = certificadoRepository.GetAllByTenantID(tenantId)
            .Where(x => x.ativo == 1 && !x.deleted)
            .OrderByDescending(x => x.validoate)
            .FirstOrDefault(x => SameBase(x.documentotitular, cnpj));

        var certificateReference = FiscalCertificateResolver.Resolve(certificado, $"{tipo} {chave}");
        FiscalCertificateResolver.ValidateIssuer(certificateReference, cnpj, $"{tipo} {chave}");

        var ambiente = documento?.ambiente is 1 or 2 ? documento.ambiente : 2;
        return new SefazFiscalEventContext(
            chave,
            Digits(protocolo),
            ambiente,
            int.Parse(chave[..2]),
            cnpj,
            tenantId,
            certificateReference);
    }

    private static void ValidateKey(string chave, string tipo)
    {
        if (chave.Length != 44)
            throw new ArgumentException($"A chave do {tipo} deve possuir 44 digitos.");
    }

    private static bool SameBase(string left, string right)
    {
        var a = Digits(left);
        var b = Digits(right);
        return a.Length == 14 && b.Length == 14 && a[..8] == b[..8];
    }

    internal static string Digits(string? value) =>
        new((value ?? string.Empty).Where(char.IsDigit).ToArray());
}

internal static class CteRecepcaoEventoV4Client
{
    private const string Namespace = "http://www.portalfiscal.inf.br/cte";
    private const string ServiceNamespace = "http://www.portalfiscal.inf.br/cte/wsdl/CTeRecepcaoEventoV4";

    public static Task<SefazFiscalEventResult> CancelarAsync(
        SefazFiscalEventContext context, string justificativa, int sequencia, CancellationToken cancellationToken) =>
        SendAsync(context, "110111", sequencia, detail =>
        {
            Append(detail, "evCancCTe", cancelamento =>
            {
                Append(cancelamento, "descEvento", "Cancelamento", Namespace);
                Append(cancelamento, "nProt", context.ProtocoloAutorizacao, Namespace);
                Append(cancelamento, "xJust", justificativa.Trim(), Namespace);
            }, Namespace);
        }, cancellationToken);

    public static Task<SefazFiscalEventResult> CorrigirAsync(
        SefazFiscalEventContext context, string grupo, string campo, string valor, int? item,
        int sequencia, CancellationToken cancellationToken) =>
        SendAsync(context, "110110", sequencia, detail =>
        {
            Append(detail, "evCCeCTe", correcao =>
            {
                Append(correcao, "descEvento", "Carta de Correcao", Namespace);
                Append(correcao, "infCorrecao", info =>
                {
                    Append(info, "grupoAlterado", grupo.Trim(), Namespace);
                    Append(info, "campoAlterado", campo.Trim(), Namespace);
                    Append(info, "valorAlterado", valor.Trim(), Namespace);
                    if (item is > 0) Append(info, "nroItemAlterado", item.Value.ToString(), Namespace);
                }, Namespace);
                Append(correcao, "xCondUso",
                    "A Carta de Correcao e disciplinada pelo Art. 58-B do CONVENIO/SINIEF 06/89: Fica permitida a utilizacao de carta de correcao, para regularizacao de erro ocorrido na emissao de documentos fiscais relativos a prestacao de servico de transporte, desde que o erro nao esteja relacionado com: I - as variaveis que determinam o valor do imposto tais como: base de calculo, aliquota, diferenca de preco, quantidade, valor da prestacao;II - a correcao de dados cadastrais que implique mudanca do emitente, tomador, remetente ou do destinatario;III - a data de emissao ou de saida.", Namespace);
            }, Namespace);
        }, cancellationToken);

    private static Task<SefazFiscalEventResult> SendAsync(
        SefazFiscalEventContext context, string eventType, int sequence,
        Action<XmlElement> writeDetail, CancellationToken cancellationToken)
    {
        var eventXml = SefazSignedEventTransport.BuildAndSign(
            "eventoCTe", "chCTe", Namespace, "4.00", context, eventType, sequence, writeDetail, idSequenceWidth: 3);
        var endpoint = Environment.GetEnvironmentVariable("YESHUA_CTE_RECEPCAO_EVENTO_ENDPOINT")
            ?? ResolveEndpoint(context.CodigoOrgao, context.Ambiente);
        return SefazSignedEventTransport.SendAsync(
            "cte", "evento", context, eventXml, endpoint,
            ServiceNamespace, "cteDadosMsg",
            ServiceNamespace + "/cteRecepcaoEvento", false, cancellationToken);
    }

    private static string ResolveEndpoint(int uf, int ambiente)
    {
        var svsp = uf is 14 or 16 or 26 or 35;
        if (svsp)
            return ambiente == 1
                ? "https://nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoEventoV4.asmx"
                : "https://homologacao.nfe.fazenda.sp.gov.br/CTeWS/WS/CTeRecepcaoEventoV4.asmx";
        return ambiente == 1
            ? "https://cte.svrs.rs.gov.br/ws/CTeRecepcaoEventoV4/CTeRecepcaoEventoV4.asmx"
            : "https://cte-homologacao.svrs.rs.gov.br/ws/CTeRecepcaoEventoV4/CTeRecepcaoEventoV4.asmx";
    }

    private static void Append(XmlElement parent, string name, string value, string ns) =>
        SefazSignedEventTransport.Append(parent, name, value, ns);
    private static void Append(XmlElement parent, string name, Action<XmlElement> fill, string ns) =>
        SefazSignedEventTransport.Append(parent, name, fill, ns);
}

internal static class MdfeEventoFiscalClient
{
    private const string Namespace = "http://www.portalfiscal.inf.br/mdfe";
    private const string ServiceNamespace = "http://www.portalfiscal.inf.br/mdfe/wsdl/MDFeRecepcaoEvento";

    public static Task<SefazFiscalEventResult> CancelarAsync(
        SefazFiscalEventContext context, string justificativa, int sequencia, CancellationToken cancellationToken) =>
        SendAsync(context, "110111", sequencia, detail =>
        {
            SefazSignedEventTransport.Append(detail, "evCancMDFe", cancelamento =>
            {
                SefazSignedEventTransport.Append(cancelamento, "descEvento", "Cancelamento", Namespace);
                SefazSignedEventTransport.Append(cancelamento, "nProt", context.ProtocoloAutorizacao, Namespace);
                SefazSignedEventTransport.Append(cancelamento, "xJust", justificativa.Trim(), Namespace);
            }, Namespace);
        }, cancellationToken);

    public static Task<SefazFiscalEventResult> IncluirCondutorAsync(
        SefazFiscalEventContext context, string nome, string cpf, int sequencia, CancellationToken cancellationToken) =>
        SendAsync(context, "110114", sequencia, detail =>
        {
            SefazSignedEventTransport.Append(detail, "evIncCondutorMDFe", inclusao =>
            {
                SefazSignedEventTransport.Append(inclusao, "descEvento", "Inclusao Condutor", Namespace);
                SefazSignedEventTransport.Append(inclusao, "condutor", condutor =>
                {
                    SefazSignedEventTransport.Append(condutor, "xNome", nome.Trim(), Namespace);
                    SefazSignedEventTransport.Append(condutor, "CPF", SefazFiscalEventContextResolver.Digits(cpf), Namespace);
                }, Namespace);
            }, Namespace);
        }, cancellationToken);

    public static Task<SefazFiscalEventResult> EncerrarAsync(
        SefazFiscalEventContext context, int codigoUf, int codigoMunicipio,
        DateTime dataEncerramento, int sequencia, CancellationToken cancellationToken)
    {
        if (codigoUf is < 11 or > 53 || codigoMunicipio.ToString().Length != 7 ||
            !codigoMunicipio.ToString().StartsWith(codigoUf.ToString(), StringComparison.Ordinal))
            throw new ArgumentException("O municipio de encerramento deve pertencer a UF informada.");
        return SendAsync(context, "110112", sequencia, detail =>
        {
            SefazSignedEventTransport.Append(detail, "evEncMDFe", encerramento =>
            {
                SefazSignedEventTransport.Append(encerramento, "descEvento", "Encerramento", Namespace);
                SefazSignedEventTransport.Append(encerramento, "nProt", context.ProtocoloAutorizacao, Namespace);
                SefazSignedEventTransport.Append(encerramento, "dtEnc", dataEncerramento.ToString("yyyy-MM-dd"), Namespace);
                SefazSignedEventTransport.Append(encerramento, "cUF", codigoUf.ToString(), Namespace);
                SefazSignedEventTransport.Append(encerramento, "cMun", codigoMunicipio.ToString(), Namespace);
            }, Namespace);
        }, cancellationToken);
    }

    private static Task<SefazFiscalEventResult> SendAsync(
        SefazFiscalEventContext context, string eventType, int sequence,
        Action<XmlElement> writeDetail, CancellationToken cancellationToken)
    {
        var eventXml = SefazSignedEventTransport.BuildAndSign(
            "eventoMDFe", "chMDFe", Namespace, "3.00", context, eventType, sequence, writeDetail);
        var endpoint = Environment.GetEnvironmentVariable("YESHUA_MDFE_RECEPCAO_EVENTO_ENDPOINT")
            ?? (context.Ambiente == 1
                ? "https://mdfe.svrs.rs.gov.br/ws/MDFeRecepcaoEvento/MDFeRecepcaoEvento.asmx"
                : "https://mdfe-homologacao.svrs.rs.gov.br/ws/MDFeRecepcaoEvento/MDFeRecepcaoEvento.asmx");
        return SefazSignedEventTransport.SendAsync(
            "mdfe", "evento", context, eventXml, endpoint,
            ServiceNamespace, "mdfeDadosMsg",
            ServiceNamespace + "/mdfeRecepcaoEvento", true, cancellationToken);
    }
}

internal static class SefazSignedEventTransport
{
    public static string BuildAndSign(
        string rootName, string keyName, string ns, string version,
        SefazFiscalEventContext context, string eventType, int sequence,
        Action<XmlElement> writeDetail,
        int idSequenceWidth = 2)
    {
        if (sequence is < 1 or > 99) throw new ArgumentException("A sequencia do evento deve estar entre 1 e 99.");
        var doc = new XmlDocument { PreserveWhitespace = false };
        var root = doc.CreateElement(rootName, ns);
        root.SetAttribute("versao", version);
        doc.AppendChild(root);
        var info = doc.CreateElement("infEvento", ns);
        info.SetAttribute("Id", $"ID{eventType}{context.ChaveAcesso}{sequence.ToString("D" + idSequenceWidth)}");
        root.AppendChild(info);
        Append(info, "cOrgao", context.CodigoOrgao.ToString(), ns);
        Append(info, "tpAmb", context.Ambiente.ToString(), ns);
        Append(info, "CNPJ", context.CnpjEmitente, ns);
        Append(info, keyName, context.ChaveAcesso, ns);
        Append(info, "dhEvento", DateTimeOffset.Now.ToString("yyyy-MM-dd'T'HH:mm:sszzz"), ns);
        Append(info, "tpEvento", eventType, ns);
        Append(info, "nSeqEvento", sequence.ToString(), ns);
        Append(info, "detEvento", detail =>
        {
            detail.SetAttribute("versaoEvento", version);
            writeDetail(detail);
        }, ns);

        using var certificate = LoadCertificate(context.Certificate);
        using var rsa = certificate.GetRSAPrivateKey()
            ?? throw new InvalidOperationException("O certificado nao possui chave privada RSA.");
        var signedXml = new SignedXml(doc) { SigningKey = rsa };
        signedXml.SignedInfo!.CanonicalizationMethod = SignedXml.XmlDsigCanonicalizationUrl;
        signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;
        var reference = new Reference("#" + info.GetAttribute("Id")) { DigestMethod = SignedXml.XmlDsigSHA1Url };
        reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
        reference.AddTransform(new XmlDsigC14NTransform());
        signedXml.AddReference(reference);
        var keyInfo = new KeyInfo();
        keyInfo.AddClause(new KeyInfoX509Data(certificate));
        signedXml.KeyInfo = keyInfo;
        signedXml.ComputeSignature();
        root.AppendChild(doc.ImportNode(signedXml.GetXml(), true));
        return doc.OuterXml;
    }

    public static async Task<SefazFiscalEventResult> SendAsync(
        string documentType, string service, SefazFiscalEventContext context,
        string eventXml, string endpoint, string serviceNamespace, string messageElement,
        string soapAction, bool includeMdfeHeader, CancellationToken cancellationToken)
    {
        var soap = WrapSoap(eventXml, context.CodigoOrgao, serviceNamespace, messageElement, includeMdfeHeader);
        using var certificate = LoadCertificate(context.Certificate);
        using var handler = new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            SslProtocols = SslProtocols.Tls12,
            UseProxy = false
        };
        handler.ClientCertificates.Add(certificate);
        using var client = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(120) };
        using var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Version = HttpVersion.Version11,
            Content = new StringContent(soap, Encoding.UTF8, "application/soap+xml")
        };
        request.Content.Headers.ContentType!.CharSet = "utf-8";
        request.Content.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("action", $"\"{soapAction}\""));
        request.Headers.ExpectContinue = false;
        var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);
        var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        SefazFiscalDocumentStore.SalvarXmlResposta(documentType, service + "-envio", context.ChaveAcesso, eventXml);
        if (!string.IsNullOrWhiteSpace(body))
            SefazFiscalDocumentStore.SalvarXmlResposta(documentType, service + "-retorno", context.ChaveAcesso, body);
        return Parse(response.StatusCode, body, eventXml, context.ChaveAcesso);
    }

    public static void Append(XmlElement parent, string name, string value, string ns)
    {
        var child = parent.OwnerDocument!.CreateElement(name, ns);
        child.InnerText = value;
        parent.AppendChild(child);
    }

    public static void Append(XmlElement parent, string name, Action<XmlElement> fill, string ns)
    {
        var child = parent.OwnerDocument!.CreateElement(name, ns);
        parent.AppendChild(child);
        fill(child);
    }

    private static string WrapSoap(string eventXml, int uf, string serviceNs, string message, bool headerRequired)
    {
        const string soapNs = "http://www.w3.org/2003/05/soap-envelope";
        var eventDoc = new XmlDocument();
        eventDoc.LoadXml(eventXml);
        var soap = new XmlDocument { PreserveWhitespace = true };
        var envelope = soap.CreateElement("soap12", "Envelope", soapNs);
        soap.AppendChild(envelope);
        if (headerRequired)
        {
            var header = soap.CreateElement("soap12", "Header", soapNs);
            envelope.AppendChild(header);
            var config = soap.CreateElement("mdfeCabecMsg", serviceNs);
            header.AppendChild(config);
            Append(config, "cUF", uf.ToString(), serviceNs);
            Append(config, "versaoDados", "3.00", serviceNs);
        }
        var body = soap.CreateElement("soap12", "Body", soapNs);
        envelope.AppendChild(body);
        var data = soap.CreateElement(message, serviceNs);
        body.AppendChild(data);
        data.AppendChild(soap.ImportNode(eventDoc.DocumentElement!, true));
        return soap.OuterXml;
    }

    private static SefazFiscalEventResult Parse(HttpStatusCode status, string body, string eventXml, string key)
    {
        var code = 0;
        var reason = string.IsNullOrWhiteSpace(body) ? $"HTTP {(int)status}" : string.Empty;
        string? protocol = null;
        if (!string.IsNullOrWhiteSpace(body))
        {
            var doc = new XmlDocument();
            doc.LoadXml(body);
            var codes = doc.SelectNodes("//*[local-name()='cStat']");
            var reasons = doc.SelectNodes("//*[local-name()='xMotivo']");
            _ = int.TryParse(codes?.Count > 0 ? codes[^1]?.InnerText : null, out code);
            reason = reasons?.Count > 0 ? reasons[^1]?.InnerText ?? string.Empty : string.Empty;
            protocol = doc.SelectSingleNode("(//*[local-name()='nProt'])[last()]")?.InnerText;
        }
        return new SefazFiscalEventResult(code is 135 or 136, code, reason, key, protocol,
            (int)status, eventXml, body);
    }

    private static X509Certificate2 LoadCertificate(FiscalCertificateReference reference) =>
        new(reference.CertificatePath, reference.Password,
            X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
}
