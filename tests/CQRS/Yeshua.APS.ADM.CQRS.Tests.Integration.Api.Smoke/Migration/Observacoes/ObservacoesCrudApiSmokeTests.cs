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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.Observacoes;

[SmokeTestOrder(153)]
public partial class ObservacoesCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Observacoes/PostObservacoes";
    private const string ReadEndpoint = "yapi/Observacoes/ReadObservacoes";
    private const string UpdateEndpoint = "yapi/Observacoes/PutObservacoes";
    private const string DeleteEndpoint = "yapi/Observacoes/DeleteObservacoes";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "obs_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Observacoes", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Observacoes", initialDeletePayload);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "obs_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Observacoes", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Observacoes", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "obs_id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "OBS_ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["OBS_TIPO"] = ApiTestData.Text("Observacoes OBS_TIPO", 30),
            ["OBS_DESCRICAO"] = ApiTestData.Text("Observacoes OBS_DESCRICAO", 80),
            ["CLI_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Cliente", "CLI_ID"),
            ["MAQ_ID"] = ApiTestData.Text("Observacoes MAQ_ID", 30),
            ["PRO_ID"] = ApiTestData.Text("Observacoes PRO_ID", 30),
            ["ROT_SEQ_TRANFORMACAO"] = 1,
            ["OBS_INTEGRACAO"] = ApiTestData.Text("Observacoes OBS_INTEGRACAO", 50),
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["OBS_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["OBS_ID"] = id.DeepClone();
        payload["OBS_TIPO"] = ApiTestData.Text("Observacoes OBS_TIPO Update", 30);
        payload["OBS_DESCRICAO"] = ApiTestData.Text("Observacoes OBS_DESCRICAO Update", 80);
        payload["CLI_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Cliente", "CLI_ID");
        payload["MAQ_ID"] = ApiTestData.Text("Observacoes MAQ_ID Update", 30);
        payload["PRO_ID"] = ApiTestData.Text("Observacoes PRO_ID Update", 30);
        payload["ROT_SEQ_TRANFORMACAO"] = 2;
        payload["OBS_INTEGRACAO"] = ApiTestData.Text("Observacoes OBS_INTEGRACAO Update", 50);
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["OBS_ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration