using Command.Receivers;
using Repositorio.Outputs;
using System.Reflection;
using System.Text.Json;

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Custon.CIOT;

public sealed class CiotFiscalContingenciaTests
{
    [Fact]
    public void Preview_should_require_ciot_when_rntrc_is_present()
    {
        var entrada = CreateEntrada(BuildComplemento(ciotNumero: string.Empty, ciotResponsavelDocumento: string.Empty));

        var pendencias = FiscalContingenciaPayload.Pendencias(entrada, CreateDocumentos());

        Assert.Contains("CIOT", pendencias);
        Assert.Contains("CIOTResponsavelDocumento", pendencias);
    }

    [Fact]
    public void Preview_should_accept_valid_ciot_and_publish_it_in_plan()
    {
        var entrada = CreateEntrada(BuildComplemento(ciotNumero: "123456789012", ciotResponsavelDocumento: "63249950000174"));

        var pendencias = FiscalContingenciaPayload.Pendencias(entrada, CreateDocumentos());
        var planoJson = FiscalContingenciaPayload.PlanoEmissaoJson(entrada, CreateDocumentos());

        Assert.DoesNotContain("CIOT", pendencias);
        Assert.DoesNotContain("CIOTInvalido", pendencias);
        Assert.DoesNotContain("CIOTResponsavelDocumento", pendencias);
        Assert.DoesNotContain("CIOTResponsavelDocumentoInvalido", pendencias);

        using var plano = JsonDocument.Parse(planoJson);
        Assert.Equal("123456789012", plano.RootElement.GetProperty("ciotNumero").GetString());
        Assert.Equal("63249950000174", plano.RootElement.GetProperty("ciotResponsavelDocumento").GetString());
        Assert.Equal(
            "123456789012",
            plano.RootElement.GetProperty("parametrosFiscaisEfetivos").GetProperty("ciotNumero").GetString());
        Assert.Equal(
            "123456789012",
            plano.RootElement.GetProperty("mdfesPrevistos")[0].GetProperty("ciotNumero").GetString());
    }

    [Fact]
    public void Mdfe_options_should_reject_ciot_without_responsavel()
    {
        var certificatePath = Path.GetTempFileName();
        try
        {
            var options = MdfeRecepcaoSincOptions.FromEnvironment() with
            {
                CertificatePath = certificatePath,
                CiotNumero = "123456789012",
                CiotResponsavelDocumento = string.Empty,
                ChavesCTe = new[] { "26260963249950000174570010000000011000000018" }
            };

            var exception = Assert.Throws<InvalidOperationException>(() => options.ValidateForSend());
            Assert.Contains("responsavel pelo CIOT", exception.Message, StringComparison.OrdinalIgnoreCase);
        }
        finally
        {
            File.Delete(certificatePath);
        }
    }

    [Fact]
    public void Mdfe_xml_should_emit_infCIOT_when_ciot_is_present()
    {
        var options = MdfeRecepcaoSincOptions.FromEnvironment() with
        {
            CiotNumero = "123456789012",
            CiotResponsavelDocumento = "63249950000174",
            ChavesCTe = new[] { "26260963249950000174570010000000011000000018" }
        };

        var method = typeof(MdfeRecepcaoSincHomologacaoClient).GetMethod(
            "BuildHomologMdfeXml",
            BindingFlags.NonPublic | BindingFlags.Static);

        Assert.NotNull(method);

        var xml = Assert.IsType<string>(method.Invoke(null, new object[] { options }));
        Assert.Contains("<infCIOT>", xml, StringComparison.Ordinal);
        Assert.Contains("<CIOT>123456789012</CIOT>", xml, StringComparison.Ordinal);
        Assert.Contains("<CNPJ>63249950000174</CNPJ>", xml, StringComparison.Ordinal);
    }

    private static EntradaFiscalContingenciaDTO CreateEntrada(string complementoJson)
        => new()
        {
            id = 1,
            correlationid = Guid.NewGuid().ToString("D"),
            cargaid = "CONT-FISCAL-CIOT-TESTE",
            tiposolicitante = 1,
            ambiente = 2,
            emitentefiscaldocumento = "63249950000174",
            tomadordocumento = "63249950000174",
            transportadordocumento = "63249950000174",
            remetentedocumento = "63249950000174",
            destinatariodocumento = "63249950000174",
            ufinicio = "PE",
            uffim = "PE",
            municipioiniciocodigoibge = "2611606",
            municipiofimcodigoibge = "2611606",
            rntrc = "45861338",
            placaveiculo = "KYC7G21",
            ufveiculo = "PE",
            condutordocumento = "00000000191",
            condutornome = "CONDUTOR HOMOLOGACAO",
            certificadodigitalid = 1,
            snapshotjson = JsonSerializer.Serialize(new
            {
                dadosComplementaresJson = complementoJson,
                preferenciasFiscaisJson = complementoJson
            })
        };

    private static IReadOnlyCollection<NFeProdutoSnapshotDTO> CreateDocumentos()
        => new[]
        {
            new NFeProdutoSnapshotDTO
            {
                id = 1,
                correlationid = Guid.NewGuid().ToString("D"),
                cargaid = "CONT-FISCAL-CIOT-TESTE",
                chaveacesso = "26260963249950000174550010000000011000000018",
                emitentedocumento = "63249950000174",
                destinatariodocumento = "63249950000174",
                uforigem = "PE",
                ufdestino = "PE",
                municipioorigemcodigoibge = "2611606",
                municipiodestinocodigoibge = "2611606",
                valordocumento = 1000m,
                pesobruto = 100m,
                volume = 1m
            }
        };

    private static string BuildComplemento(string ciotNumero, string ciotResponsavelDocumento)
        => JsonSerializer.Serialize(new
        {
            tipoAgrupamentoCTe = "um_cte_por_nfe",
            estrategiaRateioFrete = "proporcional_valor_documento",
            valorFrete = 100m,
            tipoCargaMDFe = "05",
            produtoPredominanteMDFe = "PRODUTO HOMOLOGACAO",
            ncmProdutoPredominanteMDFe = "87089990",
            origemRotaFiscal = "manual_contingencia",
            cfop = "5932",
            emitenteUf = "PE",
            emitenteInscricaoEstadual = "128556188",
            emitenteMunicipioCodigoIbge = "2611606",
            emitenteRazaoSocial = "CTE EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL",
            emitenteNomeFantasia = "HOMOLOGACAO",
            emitenteLogradouro = "RUA TESTE",
            emitenteNumero = "100",
            emitenteBairro = "CENTRO",
            emitenteCep = "50000000",
            emitenteMunicipioNome = "RECIFE",
            ciotNumero,
            ciotResponsavelDocumento,
            participantesCTe = new
            {
                remetente = CreateParticipante(),
                destinatario = CreateParticipante()
            }
        });

    private static object CreateParticipante()
        => new
        {
            documento = "63249950000174",
            nome = "CTE EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL",
            logradouro = "RUA TESTE",
            numero = "100",
            bairro = "CENTRO",
            municipioCodigoIbge = "2611606",
            municipioNome = "RECIFE",
            uf = "PE",
            cep = "50000000"
        };
}
