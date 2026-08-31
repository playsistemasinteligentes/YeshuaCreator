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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.Planoacao;

[SmokeTestOrder(158)]
public partial class PlanoacaoCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Planoacao/PostPlanoacao";
    private const string ReadEndpoint = "yapi/Planoacao/ReadPlanoacao";
    private const string UpdateEndpoint = "yapi/Planoacao/PutPlanoacao";
    private const string DeleteEndpoint = "yapi/Planoacao/DeletePlanoacao";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "pla_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Planoacao", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Planoacao", initialDeletePayload);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "pla_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Planoacao", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Planoacao", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "pla_id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "PLA_ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["PLA_DESCRICAO"] = ApiTestData.Text("Planoacao PLA_DESCRICAO", 80),
            ["MET_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("T_Metas", "MET_ID"),
            ["PLA_STATUS"] = ApiTestData.Text("Planoacao PLA_STATUS", 1),
            ["PLA_DATA"] = DateTime.UtcNow,
            ["PLA_METAPERIODO"] = ApiTestData.Text("Planoacao PLA_METAPERIODO", 50),
            ["PLA_VLRPERIODO"] = ApiTestData.Text("Planoacao PLA_VLRPERIODO", 50),
            ["PLA_METACULADO"] = ApiTestData.Text("Planoacao PLA_METACULADO", 50),
            ["PLA_VLRACUMULADO"] = ApiTestData.Text("Planoacao PLA_VLRACUMULADO", 50),
            ["PLA_REFERENCIA"] = ApiTestData.Text("Planoacao PLA_REFERENCIA", 50),
            ["USE_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Usuario", "USE_ID"),
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["PLA_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["PLA_ID"] = id.DeepClone();
        payload["PLA_DESCRICAO"] = ApiTestData.Text("Planoacao PLA_DESCRICAO Update", 80);
        payload["MET_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("T_Metas", "MET_ID");
        payload["PLA_STATUS"] = ApiTestData.Text("Planoacao PLA_STATUS Update", 1);
        payload["PLA_DATA"] = DateTime.UtcNow.AddMinutes(1);
        payload["PLA_METAPERIODO"] = ApiTestData.Text("Planoacao PLA_METAPERIODO Update", 50);
        payload["PLA_VLRPERIODO"] = ApiTestData.Text("Planoacao PLA_VLRPERIODO Update", 50);
        payload["PLA_METACULADO"] = ApiTestData.Text("Planoacao PLA_METACULADO Update", 50);
        payload["PLA_VLRACUMULADO"] = ApiTestData.Text("Planoacao PLA_VLRACUMULADO Update", 50);
        payload["PLA_REFERENCIA"] = ApiTestData.Text("Planoacao PLA_REFERENCIA Update", 50);
        payload["USE_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Usuario", "USE_ID");
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["PLA_ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration