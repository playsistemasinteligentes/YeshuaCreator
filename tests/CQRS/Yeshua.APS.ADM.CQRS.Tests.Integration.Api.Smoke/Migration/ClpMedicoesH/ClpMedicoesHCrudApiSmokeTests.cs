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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.ClpMedicoesH;

[SmokeTestOrder(11)]
public partial class ClpMedicoesHCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/ClpMedicoesH/PostClpMedicoesH";
    private const string ReadEndpoint = "yapi/ClpMedicoesH/ReadClpMedicoesH";
    private const string UpdateEndpoint = "yapi/ClpMedicoesH/PutClpMedicoesH";
    private const string DeleteEndpoint = "yapi/ClpMedicoesH/DeleteClpMedicoesH";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("ClpMedicoesH", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("ClpMedicoesH", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("ClpMedicoesH", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("ClpMedicoesH", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["ID"] = 1,
            ["MAQUINA_ID"] = ApiTestData.Text("ClpMedicoesH MAQUINA_ID", 10),
            ["DATA_INI"] = DateTime.UtcNow,
            ["DATA_FIM"] = DateTime.UtcNow,
            ["CLP_EMISSAO"] = DateTime.UtcNow,
            ["QTD"] = 10.5m,
            ["GRUPO"] = 10.5m,
            ["STATUS"] = 1,
            ["URN_ID"] = ApiTestData.Text("ClpMedicoesH URN_ID", 1),
            ["URM_ID"] = ApiTestData.Text("ClpMedicoesH URM_ID", 1),
            ["ID_LOTE_CLP"] = 1,
            ["OCO_ID"] = ApiTestData.Text("ClpMedicoesH OCO_ID", 30),
            ["FASE"] = 1,
            ["CLP_ORIGEM"] = ApiTestData.Text("ClpMedicoesH CLP_ORIGEM", 1),
            ["CLP_LOTE"] = 1,
            ["COMPACTA"] = 1,
            ["BOL_ID"] = ApiTestData.Text("ClpMedicoesH BOL_ID", 30),
            ["COR_SEQUENCIA"] = 1,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["ID"] = id.DeepClone();
        payload["MAQUINA_ID"] = ApiTestData.Text("ClpMedicoesH MAQUINA_ID Update", 10);
        payload["DATA_INI"] = DateTime.UtcNow.AddMinutes(1);
        payload["DATA_FIM"] = DateTime.UtcNow.AddMinutes(1);
        payload["CLP_EMISSAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["QTD"] = 20.5m;
        payload["GRUPO"] = 20.5m;
        payload["STATUS"] = 2;
        payload["URN_ID"] = ApiTestData.Text("ClpMedicoesH URN_ID Update", 1);
        payload["URM_ID"] = ApiTestData.Text("ClpMedicoesH URM_ID Update", 1);
        payload["ID_LOTE_CLP"] = 2;
        payload["OCO_ID"] = ApiTestData.Text("ClpMedicoesH OCO_ID Update", 30);
        payload["FASE"] = 2;
        payload["CLP_ORIGEM"] = ApiTestData.Text("ClpMedicoesH CLP_ORIGEM Update", 1);
        payload["CLP_LOTE"] = 2;
        payload["COMPACTA"] = 2;
        payload["BOL_ID"] = ApiTestData.Text("ClpMedicoesH BOL_ID Update", 30);
        payload["COR_SEQUENCIA"] = 2;
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration