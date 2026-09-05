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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.yInbox;

[SeedTestOrder(126)]
public partial class yInboxCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/yInbox/PostyInbox";
    private const string ReadEndpoint = "yapi/yInbox/ReadyInbox";
    private const string UpdateEndpoint = "yapi/yInbox/PutyInbox";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("yInbox", createdId);

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
            ["MessageId"] = ApiTestData.Text("yInbox MessageId", 80),
            ["Type"] = ApiTestData.Text("yInbox Type", 80),
            ["EntityType"] = ApiTestData.Text("yInbox EntityType", 80),
            ["EntityId"] = ApiTestData.Text("yInbox EntityId", 80),
            ["CorrelationId"] = ApiTestData.Text("yInbox CorrelationId", 80),
            ["Payload"] = ApiTestData.Text("yInbox Payload", 80),
            ["Status"] = 0,
            ["CreatedAt"] = DateTime.UtcNow,
            ["RetryCount"] = 1,
            ["LastError"] = ApiTestData.Text("yInbox LastError", 80),
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
        payload["MessageId"] = ApiTestData.Text("yInbox MessageId Update", 80);
        payload["Type"] = ApiTestData.Text("yInbox Type Update", 80);
        payload["EntityType"] = ApiTestData.Text("yInbox EntityType Update", 80);
        payload["EntityId"] = ApiTestData.Text("yInbox EntityId Update", 80);
        payload["CorrelationId"] = ApiTestData.Text("yInbox CorrelationId Update", 80);
        payload["Payload"] = ApiTestData.Text("yInbox Payload Update", 80);
        payload["Status"] = 0;
        payload["CreatedAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["RetryCount"] = 2;
        payload["LastError"] = ApiTestData.Text("yInbox LastError Update", 80);
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