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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.InspecaoVisual;

[SeedTestOrder(118)]
public partial class InspecaoVisualCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/InspecaoVisual/PostInspecaoVisual";
    private const string ReadEndpoint = "yapi/InspecaoVisual/ReadInspecaoVisual";
    private const string UpdateEndpoint = "yapi/InspecaoVisual/PutInspecaoVisual";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "ipv_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("InspecaoVisual", createdId);

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        var readAssertionHandled = false;
        CustomizeReadAssertion(readState, createdId, ref readAssertionHandled);
        if (!readAssertionHandled)
            ApiResponseAssertions.AssertReadContainsId(readState, createdId, "ipv_id");

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "ipv_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
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
            ["TURN_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turno", "TURN_ID"),
            ["TURM_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turma", "TURM_ID"),
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
        payload["TURN_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turno", "TURN_ID");
        payload["TURM_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turma", "TURM_ID");
        payload["ORD_ID"] = ApiTestData.Text("InspecaoVisual ORD_ID Update", 60);
        payload["ROT_PRO_ID"] = ApiTestData.Text("InspecaoVisual ROT_PRO_ID Update", 30);
        payload["ROT_MAQ_ID"] = ApiTestData.Text("InspecaoVisual ROT_MAQ_ID Update", 30);
        payload["ROT_SEQ_TRANSFORMACAO"] = 2;
        payload["FPR_SEQ_REPETICAO"] = 2;
        payload["IPV_STATUS_LIBERACAO"] = ApiTestData.Text("InspecaoVisual IPV_STATUS_LIBERACAO Update", 30);
        payload["IPV_VALOR_MEDIDA"] = 20.5m;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration