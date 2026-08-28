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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.InspecaoVisual;

[SmokeTestOrder(118)]
public partial class InspecaoVisualCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/InspecaoVisual/PostInspecaoVisual";
    private const string ReadEndpoint = "yapi/InspecaoVisual/ReadInspecaoVisual";
    private const string UpdateEndpoint = "yapi/InspecaoVisual/PutInspecaoVisual";
    private const string DeleteEndpoint = "yapi/InspecaoVisual/DeleteInspecaoVisual";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "ipv_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("InspecaoVisual", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("InspecaoVisual", initialDeletePayload);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "ipv_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("InspecaoVisual", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("InspecaoVisual", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "ipv_id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "IPV_ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["IPV_VALOR"] = ApiTestData.Text("InspecaoVisual IPV_VALOR", 10),
            ["IPV_ID_OPERADOR"] = 1,
            ["IPV_ID_LIBERACAO"] = 1,
            ["IPV_OBS"] = ApiTestData.Text("InspecaoVisual IPV_OBS", 80),
            ["IPV_DATA_COLETA"] = DateTime.UtcNow,
            ["IPV_DATA_AVAL"] = DateTime.UtcNow,
            ["TIV_ID"] = 1,
            ["TURN_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Turno", "TURN_ID"),
            ["TURM_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Turma", "TURM_ID"),
            ["ORD_ID"] = ApiTestData.Text("InspecaoVisual ORD_ID", 60),
            ["ROT_PRO_ID"] = ApiTestData.Text("InspecaoVisual ROT_PRO_ID", 30),
            ["ROT_MAQ_ID"] = ApiTestData.Text("InspecaoVisual ROT_MAQ_ID", 30),
            ["ROT_SEQ_TRANSFORMACAO"] = 1,
            ["FPR_SEQ_REPETICAO"] = 1,
            ["IPV_STATUS_LIBERACAO"] = ApiTestData.Text("InspecaoVisual IPV_STATUS_LIBERACAO", 30),
            ["IPV_VALOR_MEDIDA"] = 10.5m,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["IPV_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["IPV_ID"] = id.DeepClone();
        payload["IPV_VALOR"] = ApiTestData.Text("InspecaoVisual IPV_VALOR Update", 10);
        payload["IPV_ID_OPERADOR"] = 2;
        payload["IPV_ID_LIBERACAO"] = 2;
        payload["IPV_OBS"] = ApiTestData.Text("InspecaoVisual IPV_OBS Update", 80);
        payload["IPV_DATA_COLETA"] = DateTime.UtcNow.AddMinutes(1);
        payload["IPV_DATA_AVAL"] = DateTime.UtcNow.AddMinutes(1);
        payload["TIV_ID"] = 2;
        payload["TURN_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Turno", "TURN_ID");
        payload["TURM_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Turma", "TURM_ID");
        payload["ORD_ID"] = ApiTestData.Text("InspecaoVisual ORD_ID Update", 60);
        payload["ROT_PRO_ID"] = ApiTestData.Text("InspecaoVisual ROT_PRO_ID Update", 30);
        payload["ROT_MAQ_ID"] = ApiTestData.Text("InspecaoVisual ROT_MAQ_ID Update", 30);
        payload["ROT_SEQ_TRANSFORMACAO"] = 2;
        payload["FPR_SEQ_REPETICAO"] = 2;
        payload["IPV_STATUS_LIBERACAO"] = ApiTestData.Text("InspecaoVisual IPV_STATUS_LIBERACAO Update", 30);
        payload["IPV_VALOR_MEDIDA"] = 20.5m;
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["IPV_ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration