using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.CQRS.Tests.Integration.Api.Migration.yPerfilGrant;

public partial class yPerfilGrantCrudApiIntegrationTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "/yapi/yPerfilGrant/PostyPerfilGrant";
    private const string ReadEndpoint = "/yapi/yPerfilGrant/ReadyPerfilGrant";
    private const string UpdateEndpoint = "/yapi/yPerfilGrant/PutyPerfilGrant";
    private const string DeleteEndpoint = "/yapi/yPerfilGrant/DeleteyPerfilGrant";

    [IntegrationFact]
    public async Task Crud_should_create_read_update_and_delete_through_api()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");

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
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["PerfilId"] = 1,
            ["GrantId"] = ApiTestData.Text("yPerfilGrant GrantId", 80),
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
        payload["PerfilId"] = 1;
        payload["GrantId"] = ApiTestData.Text("yPerfilGrant GrantId Update", 80);
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
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiCrudTestMigration