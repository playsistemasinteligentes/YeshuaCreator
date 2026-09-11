// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeSagaTestMigration
// </yeshua>

using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.Saga.EncerramentoMDFeStandard;

[SmokeTestOrder(40)]
[Trait("TestPurpose", "SagaE2ESmoke")]
[Trait("SpecificationGate", "G7")]
[Trait("DiagnosticDepth", "D1")]
[Trait("ExecutionMode", "Live")]
public partial class EncerramentoMDFeStandardSagaApiSmokeTests : ApiIntegrationTestBase
{
    private const string ReadSagaEndpoint = "yapi/ySaga/ReadySaga";
    private const string ReadSagaStepEndpoint = "yapi/ySagaStep/ReadySagaStep";
    private const string ExpectedSagaType = "EncerramentoMDFeStandardSaga";
    private static readonly string[] ExpectedStepKeys =
    {
        "SolicitarEncerramentoMDFe",
        "PrepararEventoEncerramentoMDFe",
        "AutorizarEncerramentoMDFeNaSefaz",
        "PublicarMDFeEncerrado",
    };

    [IntegrationFact]
    public async Task EncerramentoMDFeStandard_saga_should_run_with_real_api_and_infrastructure()
    {
        var options = new SagaSmokeTestOptions();
        Configure(options);

        if (!options.Enabled)
            return;

        Assert.NotNull(options.StartSagaAsync);
        Assert.NotNull(options.BuildStartPayload);
        Assert.NotNull(options.BuildSagaReadPayload);

        using var client = await CreateAuthenticatedClientAsync();
        using var cancellation = new CancellationTokenSource(options.Timeout);
        var token = cancellation.Token;

        var startPayload = options.BuildStartPayload();
        var startState = await options.StartSagaAsync(client, startPayload, token);
        var sagaReadPayload = options.BuildSagaReadPayload(startState, startPayload);
        if (sagaReadPayload["Type"] is null)
            sagaReadPayload["Type"] = ExpectedSagaType;
        if (sagaReadPayload["Paginacao"] is null)
            sagaReadPayload["Paginacao"] = ApiTestData.Pagination(pageSize: 5);

        JsonObject? saga = null;
        JsonArray? steps = null;
        var deadline = DateTime.UtcNow.Add(options.Timeout);

        while (DateTime.UtcNow <= deadline)
        {
            saga = await TryReadFirstSagaAsync(client, sagaReadPayload, token);
            if (saga is not null)
            {
                var sagaId = ApiJson.GetRequiredProperty(saga, "Id");
                steps = await ReadSagaStepsAsync(client, sagaId, token);
                await options.OnObservationAsync(client, saga, steps, token);

                if (options.IsExpectedOutcome(saga, steps))
                    break;
            }

            await Task.Delay(options.PollInterval, token);
        }

        Assert.NotNull(saga);
        Assert.NotNull(steps);
        AssertGeneratedSagaStructure(saga!, steps!);
        options.AssertOutcome(saga!, steps!);
    }

    private static async Task<JsonObject?> TryReadFirstSagaAsync(HttpClient client, JsonObject payload, CancellationToken cancellationToken)
    {
        using var response = await client.PostAsJsonAsync(ReadSagaEndpoint, payload, JsonOptions, cancellationToken);
        var state = await ApiResponseAssertions.ReadSuccessStateAsync(response);
        var items = GetReadItems(state);
        return items.OfType<JsonObject>().FirstOrDefault();
    }

    private static async Task<JsonArray> ReadSagaStepsAsync(HttpClient client, JsonNode sagaId, CancellationToken cancellationToken)
    {
        var payload = new JsonObject
        {
            ["SagaId"] = sagaId.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination(pageSize: Math.Max(ExpectedStepKeys.Length + 5, 20))
        };

        using var response = await client.PostAsJsonAsync(ReadSagaStepEndpoint, payload, JsonOptions, cancellationToken);
        var state = await ApiResponseAssertions.ReadSuccessStateAsync(response);
        return GetReadItems(state);
    }

    private static JsonArray GetReadItems(JsonObject state)
    {
        var data = ApiJson.GetRequiredProperty(state, "data");
        var items = ApiJson.GetProperty(data, "items") as JsonArray;
        Assert.NotNull(items);
        return items!;
    }

    private static void AssertGeneratedSagaStructure(JsonObject saga, JsonArray steps)
    {
        var type = ApiJson.GetRequiredProperty(saga, "Type").GetValue<string>();
        Assert.Equal(ExpectedSagaType, type);

        foreach (var expectedStep in ExpectedStepKeys)
        {
            var found = steps.OfType<JsonObject>().Any(step =>
                string.Equals(
                    ApiJson.GetProperty(step, "StepKey")?.GetValue<string>(),
                    expectedStep,
                    StringComparison.OrdinalIgnoreCase));

            Assert.True(found, $"Saga step '{expectedStep}' was not found.");
        }
    }

    public sealed class SagaSmokeTestOptions
    {
        public bool Enabled { get; set; }
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(90);
        public TimeSpan PollInterval { get; set; } = TimeSpan.FromSeconds(2);
        public Func<JsonObject> BuildStartPayload { get; set; } = () => new JsonObject();
        public Func<HttpClient, JsonObject, CancellationToken, Task<JsonObject>>? StartSagaAsync { get; set; }
        public Func<JsonObject, JsonObject, JsonObject> BuildSagaReadPayload { get; set; } = (_, _) => new JsonObject();
        public Func<HttpClient, JsonObject, JsonArray, CancellationToken, Task> OnObservationAsync { get; set; } = (_, _, _, _) => Task.CompletedTask;
        public Func<JsonObject, JsonArray, bool> IsExpectedOutcome { get; set; } = (_, steps) => steps.Count >= ExpectedStepKeys.Length;
        public Action<JsonObject, JsonArray> AssertOutcome { get; set; } = (_, _) => { };
    }

    partial void Configure(SagaSmokeTestOptions options);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeSagaTestMigration