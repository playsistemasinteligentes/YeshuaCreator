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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.TipoInspecaoVisual;

[SmokeTestOrder(91)]
public partial class TipoInspecaoVisualCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/TipoInspecaoVisual/PostTipoInspecaoVisual";
    private const string ReadEndpoint = "yapi/TipoInspecaoVisual/ReadTipoInspecaoVisual";
    private const string UpdateEndpoint = "yapi/TipoInspecaoVisual/PutTipoInspecaoVisual";
    private const string DeleteEndpoint = "yapi/TipoInspecaoVisual/DeleteTipoInspecaoVisual";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("TipoInspecaoVisual", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("TipoInspecaoVisual", initialDeletePayload);

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

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("TipoInspecaoVisual", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("TipoInspecaoVisual", out var deletePayload))
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
            ["TIV_NOME"] = ApiTestData.Text("TipoInspecaoVisual TIV_NOME", 60),
            ["TIV_DESCRICAO"] = ApiTestData.Text("TipoInspecaoVisual TIV_DESCRICAO", 80),
            ["TIV_FECHAMENTO"] = ApiTestData.Text("TipoInspecaoVisual TIV_FECHAMENTO", 1),
            ["TIV_AMOSTRA_ALEATORIA"] = ApiTestData.Text("TipoInspecaoVisual TIV_AMOSTRA_ALEATORIA", 1),
            ["TIV_N_AMOSTRAS"] = 1,
            ["TIV_MEDIDA"] = ApiTestData.Text("TipoInspecaoVisual TIV_MEDIDA", 1),
            ["TIV_ESPECIFICACAO"] = 10.5m,
            ["TIV_TOL_MAIS"] = 10.5m,
            ["TIV_TOL_MENOS"] = 10.5m,
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
        payload["TIV_NOME"] = ApiTestData.Text("TipoInspecaoVisual TIV_NOME Update", 60);
        payload["TIV_DESCRICAO"] = ApiTestData.Text("TipoInspecaoVisual TIV_DESCRICAO Update", 80);
        payload["TIV_FECHAMENTO"] = ApiTestData.Text("TipoInspecaoVisual TIV_FECHAMENTO Update", 1);
        payload["TIV_AMOSTRA_ALEATORIA"] = ApiTestData.Text("TipoInspecaoVisual TIV_AMOSTRA_ALEATORIA Update", 1);
        payload["TIV_N_AMOSTRAS"] = 2;
        payload["TIV_MEDIDA"] = ApiTestData.Text("TipoInspecaoVisual TIV_MEDIDA Update", 1);
        payload["TIV_ESPECIFICACAO"] = 20.5m;
        payload["TIV_TOL_MAIS"] = 20.5m;
        payload["TIV_TOL_MENOS"] = 20.5m;
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