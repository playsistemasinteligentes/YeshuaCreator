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

namespace Yeshua.Fiscal.MDFe.CQRS.Tests.Integration.Api.Seed.Migration.yFileUpload;

[SeedTestOrder(3)]
public partial class yFileUploadCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/yFileUpload/PostyFileUpload";
    private const string ReadEndpoint = "yapi/yFileUpload/ReadyFileUpload";
    private const string UpdateEndpoint = "yapi/yFileUpload/PutyFileUpload";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("yFileUpload", createdId);

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        var readAssertionHandled = false;
        CustomizeReadAssertion(readState, createdId, ref readAssertionHandled);
        if (!readAssertionHandled)
            ApiResponseAssertions.AssertReadContainsId(readState, createdId);

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
            ["Type"] = ApiTestData.Text("yFileUpload Type", 50),
            ["Status"] = 0,
            ["FilePath"] = ApiTestData.Text("yFileUpload FilePath", 80),
            ["FileSize"] = 1L,
            ["EntityType"] = ApiTestData.Text("yFileUpload EntityType", 80),
            ["EntityId"] = ApiTestData.Text("yFileUpload EntityId", 80),
            ["CreatedAt"] = DateTime.UtcNow,
            ["CompletedAt"] = DateTime.UtcNow,
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
        payload["Type"] = ApiTestData.Text("yFileUpload Type Update", 50);
        payload["Status"] = 0;
        payload["FilePath"] = ApiTestData.Text("yFileUpload FilePath Update", 80);
        payload["FileSize"] = 2L;
        payload["EntityType"] = ApiTestData.Text("yFileUpload EntityType Update", 80);
        payload["EntityId"] = ApiTestData.Text("yFileUpload EntityId Update", 80);
        payload["CreatedAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["CompletedAt"] = DateTime.UtcNow.AddMinutes(1);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration