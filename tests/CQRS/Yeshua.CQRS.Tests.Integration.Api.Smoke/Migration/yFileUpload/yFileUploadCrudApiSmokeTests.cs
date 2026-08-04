using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.CQRS.Tests.Integration.Api.Smoke.Migration.yFileUpload;

[SmokeTestOrder(8)]
public partial class yFileUploadCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "/yapi/yFileUpload/PostyFileUpload";
    private const string ReadEndpoint = "/yapi/yFileUpload/ReadyFileUpload";
    private const string UpdateEndpoint = "/yapi/yFileUpload/PutyFileUpload";
    private const string DeleteEndpoint = "/yapi/yFileUpload/DeleteyFileUpload";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("yFileUpload", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("yFileUpload", initialDeletePayload);

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        ApiResponseAssertions.AssertReadContainsId(readState, createdId);

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("yFileUpload", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("yFileUpload", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "Id");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
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

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["Id"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration
