// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeSagaTestMigration
// </yeshua>

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.Saga.TesteSync;

using System.Net.Http.Json;
using System.Text.Json.Nodes;

public partial class TesteSyncSagaApiSmokeTests
{
    private const string StartTesteSyncEndpoint = "yapi/Fiscal/TesteIniciarSagaTesteSyncUseCase";

    partial void Configure(SagaSmokeTestOptions options)
    {
        options.Enabled = true;
        options.Timeout = TimeSpan.FromSeconds(20);
        options.PollInterval = TimeSpan.FromMilliseconds(250);
        options.BuildStartPayload = BuildStartPayload;
        options.StartSagaAsync = StartTesteSyncAsync;
        options.BuildSagaReadPayload = BuildSagaReadPayload;
        options.IsExpectedOutcome = IsExpectedOutcome;
        options.AssertOutcome = AssertTesteSyncOutcome;
    }

    private static JsonObject BuildStartPayload()
    {
        var correlationId = Guid.NewGuid().ToString();
        var entityId = "TESTE-SYNC-SMOKE-" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");

        return new JsonObject
        {
            ["CorrelationId"] = correlationId,
            ["TenantId"] = 2,
            ["EntityId"] = entityId
        };
    }

    private static async Task<JsonObject> StartTesteSyncAsync(
        HttpClient client,
        JsonObject payload,
        CancellationToken cancellationToken)
    {
        using var response = await client.PostAsJsonAsync(
            StartTesteSyncEndpoint,
            payload,
            JsonOptions,
            cancellationToken);

        return await ApiResponseAssertions.ReadSuccessStateAsync(response);
    }

    private static JsonObject BuildSagaReadPayload(JsonObject _, JsonObject startPayload)
    {
        return new JsonObject
        {
            ["EntityType"] = "TesteSync",
            ["EntityId"] = GetString(startPayload, "EntityId"),
            ["CorrelationId"] = GetString(startPayload, "CorrelationId"),
            ["Type"] = "TesteSyncSaga",
            ["Paginacao"] = ApiTestData.Pagination(pageSize: 20)
        };
    }

    private static bool IsExpectedOutcome(JsonObject saga, JsonArray steps)
    {
        return GetInt(saga, "Status") == 2 && AllStepsCompleted(steps);
    }

    private static void AssertTesteSyncOutcome(JsonObject saga, JsonArray steps)
    {
        Assert.Equal(2, GetInt(saga, "Status"));
        Assert.True(AllStepsCompleted(steps), "A saga TesteSync deveria concluir os cinco steps na mesma chamada.");
    }

    private static bool AllStepsCompleted(JsonArray steps)
    {
        return ExpectedStepKeys.All(stepKey =>
            steps.OfType<JsonObject>().Any(step =>
                string.Equals(GetString(step, "StepKey"), stepKey, StringComparison.OrdinalIgnoreCase)
                && GetInt(step, "Status") == 5));
    }

    private static string? GetString(JsonNode? node, params string[] propertyNames)
    {
        foreach (var propertyName in propertyNames)
        {
            var value = ApiJson.GetProperty(node, propertyName);
            if (value is JsonValue jsonValue)
                return jsonValue.GetValue<string>();
        }

        return null;
    }

    private static int GetInt(JsonNode? node, params string[] propertyNames)
    {
        foreach (var propertyName in propertyNames)
        {
            var value = ApiJson.GetProperty(node, propertyName);
            if (value is JsonValue jsonValue && jsonValue.TryGetValue<int>(out var number))
                return number;
        }

        return 0;
    }
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeSagaTestMigration
