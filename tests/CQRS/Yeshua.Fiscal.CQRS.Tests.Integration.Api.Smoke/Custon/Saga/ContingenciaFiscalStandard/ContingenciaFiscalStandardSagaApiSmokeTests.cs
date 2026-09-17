// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeSagaTestMigration
// </yeshua>

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.Saga.ContingenciaFiscalStandard;

using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;

public partial class ContingenciaFiscalStandardSagaApiSmokeTests
{
    private const string AcaoInformarNotas = "InformarNotasFiscaisContingencia";
    private const string AcaoEscolherAgrupamento = "EscolherModeloAgrupamentoCTeContingencia";
    private const string AcaoInformarFrete = "InformarFreteERateioContingencia";
    private const string AcaoInformarTransporte = "InformarDadosTransporteContingencia";
    private const string AcaoConfirmarPlano = "ConfirmarPlanoEmissaoFiscalContingencia";
    private const string PreparationStepKey = "PrepararEntradaContingencia";
    private const string StartContingenciaEndpoint = "yapi/Fiscal/ContingenciaIniciarContingenciaFiscalUseCase";
    private const string InformarNotasEndpoint = "yapi/Fiscal/ContingenciaInformarNotasFiscaisContingenciaUseCase";
    private const string InformarAgrupamentoEndpoint = "yapi/Fiscal/ContingenciaEscolherModeloAgrupamentoCTeContingenciaUseCase";
    private const string InformarFreteEndpoint = "yapi/Fiscal/ContingenciaInformarFreteERateioContingenciaUseCase";
    private const string InformarTransporteEndpoint = "yapi/Fiscal/ContingenciaInformarDadosTransporteContingenciaUseCase";
    private const string ConfirmarPlanoEndpoint = "yapi/Fiscal/ContingenciaConfirmarPlanoEmissaoFiscalContingenciaUseCase";
    private const string ReadInboxEndpoint = "yapi/yInbox/ReadyInbox";
    private const string ExpectedEmissionSagaType = "EmissaoFiscalCargaStandardSaga";
    private const string CteSefazResponseEvent = "fiscal.cte.resposta-sefaz-homologacao";
    private const string MdfeSefazResponseEvent = "fiscal.mdfe.resposta-sefaz-homologacao";

    private static readonly string[] ExpectedEmissionStepKeys =
    {
        "ReceberCargaProntaParaEmissaoFiscal",
        "AguardarDocumentosOriginariosDaCarga",
        "PrepararEntradaFiscalDaCarga",
        "MontarSolicitacoesCTe",
        "PrepararCTe",
        "AutorizarCTeNaSefaz",
        "PublicarCTeAutorizadoParaMDFe",
        "MontarSolicitacaoMDFe",
        "PrepararMDFe",
        "AutorizarMDFeNaSefaz",
        "PublicarDocumentosFiscaisDaCargaConcluidos",
    };

    partial void Configure(SagaSmokeTestOptions options)
    {
        var evidence = new ContingenciaFiscalEvidence();

        options.Enabled = true;
        options.Timeout = TimeSpan.FromMinutes(5);
        options.PollInterval = TimeSpan.FromSeconds(2);
        options.BuildStartPayload = BuildStartPayload;
        options.StartSagaAsync = StartContingenciaAsync;
        options.BuildSagaReadPayload = BuildSagaReadPayload;
        options.OnObservationAsync = async (client, saga, steps, token) =>
        {
            evidence.ObserveContingenciaSaga(saga);

            foreach (var step in steps.OfType<JsonObject>())
                evidence.ObserveStep(step);

            await ObserveEmissionSagaAsync(client, saga, evidence, token);
        };
        options.IsExpectedOutcome = (_, steps) =>
            AllExpectedStepsCompleted(steps)
            && evidence.EmissionSagaCompleted
            && evidence.DocumentosFiscaisAutorizados;
        options.AssertOutcome = (_, steps) =>
        {
            Assert.True(AllExpectedStepsCompleted(steps), "Nem todos os steps da saga de contingencia fiscal foram concluidos.");
            Assert.True(evidence.EmissionSagaFound, evidence.EmissionSagaResumo);
            Assert.True(evidence.EmissionSagaCompleted, evidence.EmissionSagaResumo);
            Assert.True(evidence.CTeAutorizado, evidence.CTeResumo);
            Assert.True(evidence.MDFeAutorizado, evidence.MDFeResumo);
        };
    }

    private static JsonObject BuildStartPayload()
    {
        var correlationId = Guid.NewGuid().ToString();
        var cargaId = "CONT-FISCAL-SMOKE-" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
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
            ["xmlStorageKey"] = "smoke/contingencia/nfe-produto.xml"
        };

        return new JsonObject
        {
            ["CorrelationId"] = correlationId,
            ["TenantId"] = 2,
            ["TipoSolicitante"] = 1,
            ["Ambiente"] = 2,
            ["CargaId"] = cargaId,
            ["SourceApplication"] = "ContingenciaFiscalSmoke",
            ["SourceModule"] = "DocumentosOriginariosContingencia",
            ["SourceMessageId"] = Guid.NewGuid().ToString(),
            ["DocumentosOriginariosJson"] = new JsonArray(documento).ToJsonString(JsonOptions),
            ["DadosComplementaresJson"] = "{}",
            ["PayloadHash"] = string.Empty,
            ["PayloadStorageKey"] = "smoke/contingencia/documentos-originarios.json"
        };
    }

    private static async Task<JsonObject> StartContingenciaAsync(
        HttpClient client,
        JsonObject payload,
        CancellationToken cancellationToken)
    {
        using var response = await client.PostAsJsonAsync(
            StartContingenciaEndpoint,
            payload,
            JsonOptions,
            cancellationToken);

        var startState = await ApiResponseAssertions.ReadSuccessStateAsync(response);
        var startData = ReadStateData(startState);
        var correlationId = GetString(startData, "CorrelationId", "correlationId")
            ?? GetString(payload, "CorrelationId", "correlationId")
            ?? string.Empty;
        var cargaId = GetString(startData, "CargaId", "cargaId")
            ?? GetString(payload, "CargaId", "cargaId")
            ?? string.Empty;
        var entradaId = GetInt(startData, "EntradaFiscalContingenciaId", "entradaFiscalContingenciaId");

        await WaitForPreparationActionAsync(client, correlationId, cargaId, AcaoInformarNotas, cancellationToken);
        await SendPreparationStimulusAsync(
            client,
            InformarNotasEndpoint,
            payload,
            correlationId,
            cargaId,
            entradaId,
            AcaoInformarNotas,
            "{}",
            cancellationToken);

        await WaitForPreparationActionAsync(client, correlationId, cargaId, AcaoEscolherAgrupamento, cancellationToken);
        await SendPreparationStimulusAsync(
            client,
            InformarAgrupamentoEndpoint,
            payload,
            correlationId,
            cargaId,
            entradaId,
            AcaoEscolherAgrupamento,
            BuildAgrupamentoJson(),
            cancellationToken);

        await WaitForPreparationActionAsync(client, correlationId, cargaId, AcaoInformarFrete, cancellationToken);
        await SendPreparationStimulusAsync(
            client,
            InformarFreteEndpoint,
            payload,
            correlationId,
            cargaId,
            entradaId,
            AcaoInformarFrete,
            BuildFreteJson(),
            cancellationToken);

        await WaitForPreparationActionAsync(client, correlationId, cargaId, AcaoInformarTransporte, cancellationToken);
        await SendPreparationStimulusAsync(
            client,
            InformarTransporteEndpoint,
            payload,
            correlationId,
            cargaId,
            entradaId,
            AcaoInformarTransporte,
            BuildTransporteJson(),
            cancellationToken);

        await WaitForPreparationActionAsync(client, correlationId, cargaId, AcaoConfirmarPlano, cancellationToken);
        await SendPreparationStimulusAsync(
            client,
            ConfirmarPlanoEndpoint,
            payload,
            correlationId,
            cargaId,
            entradaId,
            AcaoConfirmarPlano,
            BuildConfirmacaoJson(),
            cancellationToken);

        return startState;
    }

    private static async Task WaitForPreparationActionAsync(
        HttpClient client,
        string correlationId,
        string cargaId,
        string expectedAction,
        CancellationToken cancellationToken)
    {
        var sagaReadPayload = new JsonObject
        {
            ["EntityType"] = "Carga",
            ["EntityId"] = cargaId,
            ["CorrelationId"] = correlationId,
            ["Type"] = "ContingenciaFiscalStandardSaga",
            ["Paginacao"] = ApiTestData.Pagination(pageSize: 20)
        };
        var deadline = DateTime.UtcNow.AddSeconds(45);
        var lastState = "saga nao encontrada";

        while (DateTime.UtcNow <= deadline)
        {
            var saga = await TryReadFirstSagaAsync(client, sagaReadPayload, cancellationToken);
            if (saga is not null)
            {
                var sagaId = ApiJson.GetRequiredProperty(saga, "Id");
                var steps = await ReadSagaStepsAsync(client, sagaId, cancellationToken);
                var step = steps
                    .OfType<JsonObject>()
                    .FirstOrDefault(item => string.Equals(GetString(item, "StepKey"), PreparationStepKey, StringComparison.OrdinalIgnoreCase));

                if (step is not null)
                {
                    var status = GetInt(step, "Status");
                    var payload = ReadPayload(step);
                    var currentAction = GetString(payload, "currentAction") ?? string.Empty;
                    lastState = $"{PreparationStepKey} status={status}; currentAction={currentAction}";

                    if ((status == 3 || status == 6) &&
                        string.Equals(currentAction, expectedAction, StringComparison.OrdinalIgnoreCase))
                        return;
                }
            }

            await Task.Delay(TimeSpan.FromMilliseconds(500), cancellationToken);
        }

        Assert.True(false, $"A saga nao ficou pronta para '{expectedAction}'. Ultimo estado: {lastState}.");
    }

    private static async Task SendPreparationStimulusAsync(
        HttpClient client,
        string endpoint,
        JsonObject startPayload,
        string correlationId,
        string cargaId,
        int entradaId,
        string userAction,
        string complementoJson,
        CancellationToken cancellationToken)
    {
        var payload = new JsonObject
        {
            ["CorrelationId"] = correlationId,
            ["TenantId"] = GetInt(startPayload, "TenantId", "tenantId"),
            ["CargaId"] = cargaId,
            ["EntradaFiscalContingenciaId"] = entradaId,
            ["UserAction"] = userAction,
            ["DocumentosOriginariosJson"] = GetString(startPayload, "DocumentosOriginariosJson", "documentosOriginariosJson") ?? string.Empty,
            ["DadosComplementaresJson"] = complementoJson,
            ["PayloadHash"] = GetString(startPayload, "PayloadHash", "payloadHash") ?? string.Empty,
            ["PayloadStorageKey"] = GetString(startPayload, "PayloadStorageKey", "payloadStorageKey") ?? string.Empty,
        };

        var deadline = DateTime.UtcNow.AddSeconds(30);
        while (true)
        {
            using var response = await client.PostAsJsonAsync(endpoint, payload, JsonOptions, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var state = ParseJsonObject(content);
            var data = state is null ? null : ReadStateData(state);
            var message = GetString(data, "Mensagem", "mensagem") ?? content;

            if (response.IsSuccessStatusCode)
            {
                Assert.NotNull(data);
                Assert.True(GetBoolean(data, "Accepted", "accepted"), message);
                return;
            }

            if ((int)response.StatusCode == 400 &&
                message.Contains("nao esta aguardando", StringComparison.OrdinalIgnoreCase) &&
                DateTime.UtcNow < deadline)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(500), cancellationToken);
                continue;
            }

            Assert.True(response.IsSuccessStatusCode, $"Expected HTTP success, got {(int)response.StatusCode}. Body: {content}");
            return;
        }
    }

    private static JsonObject ReadStateData(JsonObject state)
    {
        return ApiJson.GetProperty(state, "data") as JsonObject ?? state;
    }

    private static string BuildAgrupamentoJson()
    {
        return new JsonObject
        {
            ["tipoAgrupamentoCTe"] = "um_cte_por_nfe",
            ["estrategiaRateioFrete"] = "proporcional_valor_documento"
        }.ToJsonString(JsonOptions);
    }

    private static string BuildFreteJson()
    {
        return new JsonObject
        {
            ["valorFrete"] = 100.00m,
            ["valorServico"] = 100.00m,
            ["tipoAgrupamentoCTe"] = "um_cte_por_nfe",
            ["estrategiaRateioFrete"] = "proporcional_valor_documento"
        }.ToJsonString(JsonOptions);
    }

    private static string BuildTransporteJson()
    {
        return new JsonObject
        {
            ["emitenteFiscalDocumento"] = "63249950000174",
            ["tomadorDocumento"] = "63249950000174",
            ["transportadorDocumento"] = "63249950000174",
            ["remetenteDocumento"] = "63249950000174",
            ["destinatarioDocumento"] = "63249950000174",
            ["ufInicio"] = "PE",
            ["ufFim"] = "PE",
            ["municipioInicioCodigoIbge"] = "2611606",
            ["municipioFimCodigoIbge"] = "2611606",
            ["rntrc"] = "45861338",
            ["placaVeiculo"] = "KYC7G21",
            ["ufVeiculo"] = "PE",
            ["condutorDocumento"] = "00000000191",
            ["condutorNome"] = "CONDUTOR HOMOLOGACAO",
            ["tipoCTe"] = 0,
            ["tipoServico"] = 0,
            ["modal"] = 1,
            ["globalizado"] = 0
        }.ToJsonString(JsonOptions);
    }

    private static string BuildConfirmacaoJson()
    {
        var complemento = JsonNode.Parse(BuildTransporteJson()) as JsonObject ?? new JsonObject();
        complemento["valorFrete"] = 100.00m;
        complemento["valorServico"] = 100.00m;
        complemento["tipoAgrupamentoCTe"] = "um_cte_por_nfe";
        complemento["estrategiaRateioFrete"] = "proporcional_valor_documento";
        complemento["confirmado"] = true;
        return complemento.ToJsonString(JsonOptions);
    }

    private static JsonObject? ReadPayload(JsonObject item)
    {
        var payloadText = GetString(item, "Payload", "payload");
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

    private static string BuildConfirmedComplementoJson(string complementoJson)
    {
        JsonObject complemento;
        try
        {
            complemento = JsonNode.Parse(complementoJson) as JsonObject ?? new JsonObject();
        }
        catch (JsonException)
        {
            complemento = new JsonObject();
        }

        complemento["confirmado"] = true;
        return complemento.ToJsonString(JsonOptions);
    }

    private static JsonObject? ParseJsonObject(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            return null;

        try
        {
            return JsonNode.Parse(content) as JsonObject;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    private static JsonObject BuildSagaReadPayload(JsonObject _, JsonObject startPayload)
    {
        return new JsonObject
        {
            ["EntityType"] = "Carga",
            ["EntityId"] = GetString(startPayload, "CargaId"),
            ["CorrelationId"] = GetString(startPayload, "CorrelationId"),
            ["Type"] = "ContingenciaFiscalStandardSaga",
            ["Paginacao"] = ApiTestData.Pagination(pageSize: 50)
        };
    }

    private static async Task ObserveEmissionSagaAsync(
        HttpClient client,
        JsonObject contingenciaSaga,
        ContingenciaFiscalEvidence evidence,
        CancellationToken cancellationToken)
    {
        var cargaId = GetString(contingenciaSaga, "EntityId");
        if (string.IsNullOrWhiteSpace(cargaId))
            return;

        var sagaReadPayload = new JsonObject
        {
            ["EntityType"] = "Carga",
            ["EntityId"] = cargaId,
            ["Type"] = ExpectedEmissionSagaType,
            ["Paginacao"] = ApiTestData.Pagination(pageSize: 50)
        };

        var emissionSaga = await TryReadFirstSagaAsync(client, sagaReadPayload, cancellationToken);
        if (emissionSaga is null)
        {
            evidence.MarkEmissionSagaMissing(cargaId);
            return;
        }

        evidence.ObserveEmissionSaga(emissionSaga);

        var emissionSagaId = GetInt(emissionSaga, "Id");
        if (emissionSagaId <= 0)
            return;

        var emissionSteps = await ReadSagaStepsAsync(client, JsonValue.Create(emissionSagaId)!, cancellationToken);
        evidence.ObserveEmissionSteps(emissionSteps);

        foreach (var step in emissionSteps.OfType<JsonObject>())
            evidence.ObserveStep(step);

        await ObserveInboxEvidenceAsync(client, emissionSagaId, evidence, cancellationToken);
    }

    private static async Task ObserveInboxEvidenceAsync(
        HttpClient client,
        int sagaId,
        ContingenciaFiscalEvidence evidence,
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
            evidence.ObserveInbox(item);
    }

    private static JsonArray ReadItems(JsonObject state)
    {
        var data = ApiJson.GetRequiredProperty(state, "data");
        var items = ApiJson.GetProperty(data, "items") as JsonArray;
        Assert.NotNull(items);
        return items!;
    }

    private static bool AllExpectedStepsCompleted(JsonArray steps)
        => AllStepsCompleted(steps, ExpectedStepKeys);

    private static bool AllEmissionStepsCompleted(JsonArray steps)
        => AllStepsCompleted(steps, ExpectedEmissionStepKeys);

    private static bool AllStepsCompleted(JsonArray steps, IEnumerable<string> expectedStepKeys)
    {
        return expectedStepKeys.All(stepKey => StepHasStatus(steps, stepKey, 5));
    }

    private static bool StepHasStatus(JsonArray steps, string stepKey, int status)
    {
        return steps.OfType<JsonObject>().Any(step =>
            string.Equals(GetString(step, "StepKey"), stepKey, StringComparison.OrdinalIgnoreCase)
            && GetInt(step, "Status") == status);
    }

    private static string? GetString(JsonNode? node, params string[] propertyNames)
    {
        foreach (var propertyName in propertyNames)
        {
            var value = ApiJson.GetProperty(node, propertyName);
            if (value is JsonValue jsonValue)
            {
                if (jsonValue.TryGetValue<string>(out var text))
                    return text;

                if (jsonValue.TryGetValue<int>(out var intValue))
                    return intValue.ToString();
            }
        }

        return null;
    }

    private static int GetInt(JsonNode? node, params string[] propertyNames)
    {
        foreach (var propertyName in propertyNames)
        {
            var value = ApiJson.GetProperty(node, propertyName);
            if (value is not JsonValue jsonValue)
                continue;

            if (jsonValue.TryGetValue<int>(out var intValue))
                return intValue;

            if (jsonValue.TryGetValue<string>(out var text) && int.TryParse(text, out var textValue))
                return textValue;
        }

        return 0;
    }

    private static bool GetBoolean(JsonNode? node, params string[] propertyNames)
    {
        foreach (var propertyName in propertyNames)
        {
            var value = ApiJson.GetProperty(node, propertyName);
            if (value is JsonValue jsonValue && jsonValue.TryGetValue<bool>(out var boolValue))
                return boolValue;
        }

        return false;
    }

    private sealed class ContingenciaFiscalEvidence
    {
        public bool EmissionSagaFound { get; private set; }
        public bool EmissionSagaCompleted { get; private set; }
        public bool CTeAutorizado { get; private set; }
        public bool MDFeAutorizado { get; private set; }
        public bool DocumentosFiscaisAutorizados => CTeAutorizado && MDFeAutorizado;
        public string EmissionSagaResumo { get; private set; } = "Saga fiscal EmissaoFiscalCargaStandardSaga ainda nao encontrada.";
        public string CTeResumo { get; private set; } = "Retorno autorizado de CT-e nao encontrado na saga fiscal ligada a contingencia.";
        public string MDFeResumo { get; private set; } = "Retorno autorizado de MDF-e nao encontrado na saga fiscal ligada a contingencia.";

        public void ObserveContingenciaSaga(JsonObject saga)
        {
            var cargaId = GetString(saga, "EntityId") ?? "-";
            var status = GetInt(saga, "Status");
            if (!EmissionSagaFound)
                EmissionSagaResumo = $"Contingencia encontrada para carga {cargaId}, mas a saga fiscal ainda nao nasceu. Status contingencia={status}.";
        }

        public void MarkEmissionSagaMissing(string cargaId)
        {
            if (!EmissionSagaFound)
                EmissionSagaResumo = $"Saga fiscal {ExpectedEmissionSagaType} nao encontrada para carga {cargaId}.";
        }

        public void ObserveEmissionSaga(JsonObject saga)
        {
            EmissionSagaFound = true;
            var sagaId = GetInt(saga, "Id");
            var status = GetInt(saga, "Status");
            var currentStep = GetString(saga, "KeyCurrentStep") ?? "-";
            EmissionSagaResumo = $"Saga fiscal encontrada. Id={sagaId}; Status={status}; StepAtual={currentStep}.";
        }

        public void ObserveEmissionSteps(JsonArray steps)
        {
            EmissionSagaCompleted = AllEmissionStepsCompleted(steps);
            if (!EmissionSagaCompleted)
            {
                var current = steps
                    .OfType<JsonObject>()
                    .Where(step => GetInt(step, "Status") != 5)
                    .Select(step => $"{GetString(step, "StepKey") ?? "-"}={GetInt(step, "Status")}")
                    .DefaultIfEmpty("sem step pendente visivel");

                EmissionSagaResumo += " Steps fiscais pendentes: " + string.Join(", ", current) + ".";
            }
        }

        public void ObserveStep(JsonObject step)
        {
            var payload = ReadPayload(step);
            if (payload is not null)
                ObservePayload(payload);
        }

        public void ObserveInbox(JsonObject item)
        {
            var itemType = GetString(item, "Type");
            var payload = ReadPayload(item);
            if (payload is null)
                return;

            ObservePayload(payload);

            var data = ApiJson.GetProperty(payload, "data") as JsonObject;
            ObserveSefazResponse(itemType ?? GetString(payload, "type"), data);
        }

        private void ObservePayload(JsonObject payload)
        {
            var cte = ApiJson.GetProperty(payload, "cte") as JsonObject;
            var mdfe = ApiJson.GetProperty(payload, "mdfe") as JsonObject;

            if (cte is not null)
                ObserveCTe(cte);
            if (mdfe is not null)
                ObserveMDFe(mdfe);

            var data = ApiJson.GetProperty(payload, "data") as JsonObject;
            ObserveSefazResponse(GetString(payload, "type"), data);

            foreach (var nestedProperty in new[] { "resultadoPayload", "resultadoAnterior" })
            {
                var nestedPayload = GetString(payload, nestedProperty);
                if (string.IsNullOrWhiteSpace(nestedPayload))
                    continue;

                try
                {
                    if (JsonNode.Parse(nestedPayload) is JsonObject nested)
                        ObservePayload(nested);
                }
                catch (JsonException)
                {
                }
            }
        }

        private void ObserveSefazResponse(string? type, JsonObject? data)
        {
            if (data is null)
                return;

            if (string.Equals(type, CteSefazResponseEvent, StringComparison.OrdinalIgnoreCase))
            {
                ObserveCTe(data);
                return;
            }

            if (string.Equals(type, MdfeSefazResponseEvent, StringComparison.OrdinalIgnoreCase))
                ObserveMDFe(data);
        }

        private void ObserveCTe(JsonObject data)
        {
            var cStat = GetInt(data, "codigoretorno", "codigoRetorno", "cStat");
            CTeResumo = BuildResumo(data, cStat);
            CTeAutorizado = CTeAutorizado || cStat == 100 || IsAutorizado(data, cStat);
        }

        private void ObserveMDFe(JsonObject data)
        {
            var cStat = GetInt(data, "codigoretorno", "codigoRetorno", "cStat");
            MDFeResumo = BuildResumo(data, cStat);
            MDFeAutorizado = MDFeAutorizado || cStat == 100 || IsAutorizado(data, cStat);
        }

        private static bool IsAutorizado(JsonObject data, int cStat)
        {
            return cStat == 100
                && GetBoolean(data, "autorizado", "Autorizado")
                && !GetBoolean(data, "erroTecnico", "ErroTecnico");
        }

        private static JsonObject? ReadPayload(JsonObject item)
        {
            var payloadText = GetString(item, "Payload", "payload");
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

        private static string BuildResumo(JsonObject data, int cStat)
        {
            return "cStat=" + cStat
                + "; xMotivo=" + (GetString(data, "mensagemretorno", "mensagemRetorno", "xMotivo") ?? string.Empty)
                + "; chave=" + (GetString(data, "chaveacesso", "chaveAcesso", "chave") ?? string.Empty)
                + "; protocolo=" + (GetString(data, "protocoloautorizacao", "protocoloAutorizacao", "protocolo") ?? string.Empty);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeSagaTestMigration
