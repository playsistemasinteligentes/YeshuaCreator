// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration
// </yeshua>

using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.Memorias.CQRS.Tests.Integration.Api.Smoke.Migration.PublicacaoAlbum;

[SmokeTestOrder(4)]
public partial class PublicacaoAlbumCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/PublicacaoAlbum/PostPublicacaoAlbum";
    private const string ReadEndpoint = "yapi/PublicacaoAlbum/ReadPublicacaoAlbum";
    private const string UpdateEndpoint = "yapi/PublicacaoAlbum/PutPublicacaoAlbum";
    private const string DeleteEndpoint = "yapi/PublicacaoAlbum/DeletePublicacaoAlbum";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("PublicacaoAlbum", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("PublicacaoAlbum", initialDeletePayload);

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

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("PublicacaoAlbum", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("PublicacaoAlbum", out var deletePayload))
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
            ["AlbumId"] = ApiSmokeTestContext.GetRequiredCreatedId("Album", "AlbumId"),
            ["CorrelationId"] = ApiTestData.Text("PublicacaoAlbum CorrelationId", 80),
            ["ManifestStorageKey"] = ApiTestData.Text("PublicacaoAlbum ManifestStorageKey", 80),
            ["VideoStorageKey"] = ApiTestData.Text("PublicacaoAlbum VideoStorageKey", 80),
            ["YouTubeVideoId"] = ApiTestData.Text("PublicacaoAlbum YouTubeVideoId", 80),
            ["YouTubeUrl"] = ApiTestData.Text("PublicacaoAlbum YouTubeUrl", 80),
            ["Mensagem"] = ApiTestData.Text("PublicacaoAlbum Mensagem", 80),
            ["SolicitadaEmUtc"] = DateTime.UtcNow,
            ["PublicadaEmUtc"] = DateTime.UtcNow,
            ["Status"] = 1,
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
        payload["AlbumId"] = ApiSmokeTestContext.GetRequiredCreatedId("Album", "AlbumId");
        payload["CorrelationId"] = ApiTestData.Text("PublicacaoAlbum CorrelationId Update", 80);
        payload["ManifestStorageKey"] = ApiTestData.Text("PublicacaoAlbum ManifestStorageKey Update", 80);
        payload["VideoStorageKey"] = ApiTestData.Text("PublicacaoAlbum VideoStorageKey Update", 80);
        payload["YouTubeVideoId"] = ApiTestData.Text("PublicacaoAlbum YouTubeVideoId Update", 80);
        payload["YouTubeUrl"] = ApiTestData.Text("PublicacaoAlbum YouTubeUrl Update", 80);
        payload["Mensagem"] = ApiTestData.Text("PublicacaoAlbum Mensagem Update", 80);
        payload["SolicitadaEmUtc"] = DateTime.UtcNow.AddMinutes(1);
        payload["PublicadaEmUtc"] = DateTime.UtcNow.AddMinutes(1);
        payload["Status"] = 1;
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
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration