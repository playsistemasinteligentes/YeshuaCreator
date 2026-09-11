// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration
// </yeshua>

using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Seed.Migration.yOutbox;

[SeedTestOrder(25)]
public partial class yOutboxCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/yOutbox/PostyOutbox";
    private const string ReadEndpoint = "yapi/yOutbox/ReadyOutbox";
    private const string UpdateEndpoint = "yapi/yOutbox/PutyOutbox";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("yOutbox", createdId);

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        var readAssertionHandled = false;
        CustomizeReadAssertion(readState, createdId, ref readAssertionHandled);
        if (!readAssertionHandled)
            ApiResponseAssertions.AssertReadContainsId(readState, createdId, "id");

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["MessageId"] = ApiTestData.Text("yOutbox MessageId", 80),
            ["Type"] = ApiTestData.Text("yOutbox Type", 80),
            ["EntityType"] = ApiTestData.Text("yOutbox EntityType", 80),
            ["EntityId"] = ApiTestData.Text("yOutbox EntityId", 80),
            ["CorrelationId"] = ApiTestData.Text("yOutbox CorrelationId", 80),
            ["Payload"] = ApiTestData.Text("yOutbox Payload", 80),
            ["Status"] = 0,
            ["TransportType"] = 1,
            ["TransportData"] = ApiTestData.Text("yOutbox TransportData", 80),
            ["CreatedAt"] = DateTime.UtcNow,
            ["SentAt"] = DateTime.UtcNow,
            ["RetryCount"] = 1,
            ["LastError"] = ApiTestData.Text("yOutbox LastError", 80),
            ["ProcessingAt"] = DateTime.UtcNow,
            ["NextAttemptAt"] = DateTime.UtcNow,
            ["SagaId"] = ApiSeedTestContext.GetRequiredCreatedId("ySaga", "SagaId"),
            ["SagaStepId"] = ApiSeedTestContext.GetRequiredCreatedId("ySagaStep", "SagaStepId"),
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["Id"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["Id"] = id.DeepClone();
        payload["MessageId"] = ApiTestData.Text("yOutbox MessageId Update", 80);
        payload["Type"] = ApiTestData.Text("yOutbox Type Update", 80);
        payload["EntityType"] = ApiTestData.Text("yOutbox EntityType Update", 80);
        payload["EntityId"] = ApiTestData.Text("yOutbox EntityId Update", 80);
        payload["CorrelationId"] = ApiTestData.Text("yOutbox CorrelationId Update", 80);
        payload["Payload"] = ApiTestData.Text("yOutbox Payload Update", 80);
        payload["Status"] = 0;
        payload["TransportType"] = 1;
        payload["TransportData"] = ApiTestData.Text("yOutbox TransportData Update", 80);
        payload["CreatedAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["SentAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["RetryCount"] = 2;
        payload["LastError"] = ApiTestData.Text("yOutbox LastError Update", 80);
        payload["ProcessingAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["NextAttemptAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["SagaId"] = ApiSeedTestContext.GetRequiredCreatedId("ySaga", "SagaId");
        payload["SagaStepId"] = ApiSeedTestContext.GetRequiredCreatedId("ySagaStep", "SagaStepId");
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration