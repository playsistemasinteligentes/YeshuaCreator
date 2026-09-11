// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeSagaTestMigration
// </yeshua>

using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.Saga.EmissaoFiscalCargaStandard;

public partial class EmissaoFiscalCargaStandardSagaApiSmokeTests
{
    private const string StartFiscalSagaEndpoint = "yapi/Fiscal/Inbox/YeshuaModuleEvent";
    private const string ReadInboxEndpoint = "yapi/yInbox/ReadyInbox";
    private const string InformarDocumentosOriginariosEndpoint = "yapi/Fiscal/EntradaInformarDocumentosOriginariosDaCargaUseCase";
    private const string StartFiscalSagaEvent = "CargaProntaParaEmissaoFiscal.v1";
    private const string CteSefazResponseEvent = "fiscal.cte.resposta-sefaz-homologacao";
    private const string MdfeSefazResponseEvent = "fiscal.mdfe.resposta-sefaz-homologacao";

    partial void Configure(SagaSmokeTestOptions options)
    {
        var evidence = new FiscalSagaEvidence();

        options.Enabled = true;
        options.Timeout = TimeSpan.FromMinutes(5);
        options.PollInterval = TimeSpan.FromSeconds(2);
        options.BuildStartPayload = BuildStartPayload;
        options.StartSagaAsync = StartFiscalSagaAsync;
        options.BuildSagaReadPayload = BuildSagaReadPayload;
        options.OnObservationAsync = async (client, saga, steps, token) =>
        {
            foreach (var step in steps.OfType<JsonObject>())
                evidence.ObserveStep(step);

            var sagaId = GetInt(saga, "Id");
            if (sagaId > 0)
                await ObserveInboxEvidenceAsync(client, sagaId, evidence, token);

            await SimularErpInformandoDocumentosOriginariosAsync(client, saga, steps, evidence, token);
        };
        options.IsExpectedOutcome = (_, steps) =>
            AllExpectedStepsCompleted(steps);
        options.AssertOutcome = (_, steps) =>
        {
            Assert.True(AllExpectedStepsCompleted(steps), "Nem todos os steps da saga fiscal foram concluidos.");
            Assert.True(evidence.CteAutorizado, evidence.CteResumo);
            Assert.True(evidence.MdfeAutorizado, evidence.MdfeResumo);
        };
    }

    private static JsonObject BuildStartPayload()
    {
        var correlationId = Guid.NewGuid().ToString();
        var entityId = "FISCAL-SMOKE-" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
        var payload = new JsonObject
        {
            ["sagaCorrelationId"] = correlationId,
            ["cargaId"] = entityId,
            ["origem"] = "SmokeTest",
            ["modo"] = "sefaz-homologacao",
            ["createdAtUtc"] = DateTime.UtcNow
        };

        return new JsonObject
        {
            ["MessageId"] = Guid.NewGuid().ToString(),
            ["Type"] = StartFiscalSagaEvent,
            ["EntityType"] = "Carga",
            ["EntityId"] = entityId,
            ["CorrelationId"] = correlationId,
            ["Payload"] = payload.ToJsonString(JsonOptions),
            ["Source"] = "SmokeTest",
            ["Transport"] = "YeshuaApi"
        };
    }

    private static async Task<JsonObject> StartFiscalSagaAsync(
        HttpClient client,
        JsonObject payload,
        CancellationToken cancellationToken)
    {
        using var response = await client.PostAsJsonAsync(
            StartFiscalSagaEndpoint,
            payload,
            JsonOptions,
            cancellationToken);

        return await ApiResponseAssertions.ReadSuccessStateAsync(response);
    }

    private static JsonObject BuildSagaReadPayload(JsonObject _, JsonObject startPayload)
    {
        return new JsonObject
        {
            ["EntityType"] = GetString(startPayload, "EntityType"),
            ["EntityId"] = GetString(startPayload, "EntityId"),
            ["Type"] = "EmissaoFiscalCargaStandardSaga",
            ["Paginacao"] = ApiTestData.Pagination(pageSize: 50)
        };
    }

    private static async Task ObserveInboxEvidenceAsync(
        HttpClient client,
        int sagaId,
        FiscalSagaEvidence evidence,
        CancellationToken cancellationToken)
    {
        var payload = new JsonObject
        {
            ["SagaId"] = sagaId,
            ["Paginacao"] = ApiTestData.Pagination(pageSize: 100)
        };

        using var response = await client.PostAsJsonAsync(
            ReadInboxEndpoint,
            payload,
            JsonOptions,
            cancellationToken);

        var state = await ApiResponseAssertions.ReadSuccessStateAsync(response);
        foreach (var item in ReadItems(state).OfType<JsonObject>())
            evidence.Observe(item);
    }

    private static async Task SimularErpInformandoDocumentosOriginariosAsync(
        HttpClient client,
        JsonObject saga,
        JsonArray steps,
        FiscalSagaEvidence evidence,
        CancellationToken cancellationToken)
    {
        if (evidence.DocumentosOriginariosInformados)
            return;

        if (!StepHasStatus(steps, "AguardarDocumentosOriginariosDaCarga", 3))
            return;

        var cargaId = GetString(saga, "EntityId") ?? ("FISCAL-SMOKE-" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff"));
        var correlationId = GetString(saga, "CorrelationId") ?? Guid.NewGuid().ToString();
        var documento = new JsonObject
        {
            ["tipoDocumento"] = "NFe",
            ["chaveAcesso"] = "26260963249950000174550010000000011000000018",
            ["numero"] = "1",
            ["serie"] = "1",
            ["emitenteDocumento"] = "63249950000174",
            ["destinatarioDocumento"] = "63249950000174",
            ["ufOrigem"] = "PE",
            ["ufDestino"] = "PE",
            ["municipioOrigemCodigoIbge"] = "2611606",
            ["municipioDestinoCodigoIbge"] = "2611606",
            ["valorDocumento"] = 1000.00m,
            ["pesoBruto"] = 100.00m,
            ["volume"] = 1.00m,
            ["xmlStorageKey"] = "smoke/nfe-produto.xml"
        };

        var payload = new JsonObject
        {
            ["CorrelationId"] = correlationId,
            ["TenantId"] = 1,
            ["SourceApplication"] = "ERP-MOCK",
            ["SourceModule"] = "NotasFiscaisProduto",
            ["SourceMessageId"] = Guid.NewGuid().ToString(),
            ["CargaId"] = cargaId,
            ["DocumentosOriginariosJson"] = new JsonArray(documento).ToJsonString(JsonOptions),
            ["PayloadHash"] = string.Empty,
            ["PayloadStorageKey"] = "smoke/documentos-originarios.json"
        };

        using var response = await client.PostAsJsonAsync(
            InformarDocumentosOriginariosEndpoint,
            payload,
            JsonOptions,
            cancellationToken);

        await ApiResponseAssertions.ReadSuccessStateAsync(response);
        evidence.MarkDocumentosOriginariosInformados();
    }

    private static JsonArray ReadItems(JsonObject state)
    {
        var data = ApiJson.GetRequiredProperty(state, "data");
        var items = ApiJson.GetProperty(data, "items") as JsonArray;
        Assert.NotNull(items);
        return items!;
    }

    private static bool AllExpectedStepsCompleted(JsonArray steps)
    {
        return StepHasStatus(steps, "ReceberCargaProntaParaEmissaoFiscal", 5)
            && StepHasStatus(steps, "AguardarDocumentosOriginariosDaCarga", 5)
            && StepHasStatus(steps, "PrepararEntradaFiscalDaCarga", 5)
            && StepHasStatus(steps, "MontarSolicitacoesCTe", 5)
            && StepHasStatus(steps, "PrepararCTe", 5)
            && StepHasStatus(steps, "AutorizarCTeNaSefaz", 5)
            && StepHasStatus(steps, "PublicarCTeAutorizadoParaMDFe", 5)
            && StepHasStatus(steps, "MontarSolicitacaoMDFe", 5)
            && StepHasStatus(steps, "PrepararMDFe", 5)
            && StepHasStatus(steps, "AutorizarMDFeNaSefaz", 5)
            && StepHasStatus(steps, "PublicarDocumentosFiscaisDaCargaConcluidos", 5);
    }

    private static bool StepHasStatus(JsonArray steps, string stepKey, int status)
    {
        return steps.OfType<JsonObject>().Any(step =>
            string.Equals(GetString(step, "StepKey"), stepKey, StringComparison.OrdinalIgnoreCase)
            && GetInt(step, "Status") == status);
    }

    private static string? GetString(JsonNode? node, string propertyName)
    {
        return ApiJson.GetProperty(node, propertyName)?.GetValue<string>();
    }

    private static int GetInt(JsonNode? node, string propertyName)
    {
        var value = ApiJson.GetProperty(node, propertyName);
        if (value is null)
            return 0;

        if (value is JsonValue jsonValue)
        {
            if (jsonValue.TryGetValue<int>(out var intValue))
                return intValue;

            if (jsonValue.TryGetValue<string>(out var text) && int.TryParse(text, out var textValue))
                return textValue;
        }

        return 0;
    }

    private static bool GetBoolean(JsonNode? node, string propertyName)
    {
        var value = ApiJson.GetProperty(node, propertyName);
        return value is JsonValue jsonValue && jsonValue.TryGetValue<bool>(out var boolValue) && boolValue;
    }

    private sealed class FiscalSagaEvidence
    {
        public bool DocumentosOriginariosInformados { get; private set; }
        public bool CteAutorizado { get; private set; }
        public bool MdfeAutorizado { get; private set; }
        public string CteResumo { get; private set; } = "Retorno SEFAZ CT-e autorizado nao encontrado no yInbox nem nos steps.";
        public string MdfeResumo { get; private set; } = "Retorno SEFAZ MDF-e autorizado nao encontrado no yInbox nem nos steps.";

        public void MarkDocumentosOriginariosInformados()
        {
            DocumentosOriginariosInformados = true;
        }

        public void Observe(JsonObject item)
        {
            var type = GetString(item, "Type");
            var payload = ReadPayload(item);
            ObservePayload(type ?? GetString(payload, "type"), ApiJson.GetProperty(payload, "data") as JsonObject);
        }

        public void ObserveStep(JsonObject step)
        {
            var payload = ReadPayload(step);
            ObservePayload(GetString(payload, "type"), ApiJson.GetProperty(payload, "data") as JsonObject);
        }

        private static JsonObject? ReadPayload(JsonObject item)
        {
            var payloadText = GetString(item, "Payload");
            if (string.IsNullOrWhiteSpace(payloadText))
                return null;

            try
            {
                return JsonNode.Parse(payloadText) as JsonObject;
            }
            catch (JsonException)
            {
                return null;
            }
        }

        private void ObservePayload(string? type, JsonObject? data)
        {
            if (!string.Equals(type, CteSefazResponseEvent, StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(type, MdfeSefazResponseEvent, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (data is null)
                return;

            var resumo = BuildResumo(data);
            var autorizado = GetBoolean(data, "autorizado")
                && !GetBoolean(data, "erroTecnico")
                && GetInt(data, "cStat") == 100;

            if (string.Equals(type, CteSefazResponseEvent, StringComparison.OrdinalIgnoreCase))
            {
                CteResumo = resumo;
                CteAutorizado = CteAutorizado || autorizado;
                return;
            }

            MdfeResumo = resumo;
            MdfeAutorizado = MdfeAutorizado || autorizado;
        }

        private static string BuildResumo(JsonObject data)
        {
            return "cStat=" + GetInt(data, "cStat")
                + "; xMotivo=" + (GetString(data, "xMotivo") ?? string.Empty)
                + "; chave=" + (GetString(data, "chave") ?? string.Empty)
                + "; protocolo=" + (GetString(data, "protocolo") ?? string.Empty);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeSagaTestMigration
