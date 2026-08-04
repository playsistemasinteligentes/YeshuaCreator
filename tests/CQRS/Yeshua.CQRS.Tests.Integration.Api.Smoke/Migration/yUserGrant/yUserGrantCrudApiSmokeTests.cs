using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.CQRS.Tests.Integration.Api.Smoke.Migration.yUserGrant;

[SmokeTestOrder(25)]
public partial class yUserGrantCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "/yapi/yUserGrant/PostyUserGrant";
    private const string ReadEndpoint = "/yapi/yUserGrant/ReadyUserGrant";
    private const string UpdateEndpoint = "/yapi/yUserGrant/PutyUserGrant";
    private const string DeleteEndpoint = "/yapi/yUserGrant/DeleteyUserGrant";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("yUserGrant", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("yUserGrant", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("yUserGrant", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("yUserGrant", out var deletePayload))
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
            ["PerfilId"] = ApiSmokeTestContext.GetRequiredCreatedId("yPerfil", "PerfilId"),
            ["GrantId"] = ApiTestData.Text("yUserGrant GrantId", 80),
            ["Grant"] = false,
            ["Create"] = false,
            ["Read"] = false,
            ["Update"] = false,
            ["Delete"] = false,
            ["ValidUntil"] = DateTime.UtcNow,
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
        payload["PerfilId"] = ApiSmokeTestContext.GetRequiredCreatedId("yPerfil", "PerfilId");
        payload["GrantId"] = ApiTestData.Text("yUserGrant GrantId Update", 80);
        payload["Grant"] = true;
        payload["Create"] = true;
        payload["Read"] = true;
        payload["Update"] = true;
        payload["Delete"] = true;
        payload["ValidUntil"] = DateTime.UtcNow.AddMinutes(1);
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
