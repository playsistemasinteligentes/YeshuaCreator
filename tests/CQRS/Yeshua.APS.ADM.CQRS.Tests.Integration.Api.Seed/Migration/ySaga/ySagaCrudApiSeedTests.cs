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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.ySaga;

[SeedTestOrder(123)]
public partial class ySagaCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/ySaga/PostySaga";
    private const string ReadEndpoint = "yapi/ySaga/ReadySaga";
    private const string UpdateEndpoint = "yapi/ySaga/PutySaga";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("ySaga", createdId);

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
            ["CorrelationId"] = ApiTestData.Text("ySaga CorrelationId", 80),
            ["Type"] = ApiTestData.Text("ySaga Type", 80),
            ["Status"] = 0,
            ["KeyCurrentStep"] = ApiTestData.Text("ySaga KeyCurrentStep", 80),
            ["CreatedAt"] = DateTime.UtcNow,
            ["CompletedAt"] = DateTime.UtcNow,
            ["EntityType"] = ApiTestData.Text("ySaga EntityType", 80),
            ["EntityId"] = ApiTestData.Text("ySaga EntityId", 80),
            ["NextExecutionAt"] = DateTime.UtcNow,
            ["LockedAt"] = DateTime.UtcNow,
            ["LockedBy"] = ApiTestData.Text("ySaga LockedBy", 80),
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
        payload["CorrelationId"] = ApiTestData.Text("ySaga CorrelationId Update", 80);
        payload["Type"] = ApiTestData.Text("ySaga Type Update", 80);
        payload["Status"] = 0;
        payload["KeyCurrentStep"] = ApiTestData.Text("ySaga KeyCurrentStep Update", 80);
        payload["CreatedAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["CompletedAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["EntityType"] = ApiTestData.Text("ySaga EntityType Update", 80);
        payload["EntityId"] = ApiTestData.Text("ySaga EntityId Update", 80);
        payload["NextExecutionAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["LockedAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["LockedBy"] = ApiTestData.Text("ySaga LockedBy Update", 80);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration