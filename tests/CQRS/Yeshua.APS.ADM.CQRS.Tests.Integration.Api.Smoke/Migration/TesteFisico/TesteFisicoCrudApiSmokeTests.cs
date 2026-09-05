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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.TesteFisico;

[SmokeTestOrder(160)]
public partial class TesteFisicoCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/TesteFisico/PostTesteFisico";
    private const string ReadEndpoint = "yapi/TesteFisico/ReadTesteFisico";
    private const string UpdateEndpoint = "yapi/TesteFisico/PutTesteFisico";
    private const string DeleteEndpoint = "yapi/TesteFisico/DeleteTesteFisico";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("TesteFisico", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("TesteFisico", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("TesteFisico", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("TesteFisico", out var deletePayload))
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
            ["TES_ID"] = 1,
            ["ITE_ID"] = 1,
            ["USR_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Usuario", "USR_ID"),
            ["TES_NOME_TECNICO"] = ApiTestData.Text("TesteFisico TES_NOME_TECNICO", 80),
            ["TES_AMOSTRA"] = 1,
            ["TES_OP"] = ApiTestData.Text("TesteFisico TES_OP", 10),
            ["TES_VALOR_NUMERICO"] = 10.5m,
            ["TES_VALOR_DATA"] = DateTime.UtcNow,
            ["TES_VALOR_TEXTO"] = ApiTestData.Text("TesteFisico TES_VALOR_TEXTO", 80),
            ["TES_EMISSAO"] = DateTime.UtcNow,
            ["ORD_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Order", "ORD_ID"),
            ["PRO_ID"] = ApiTestData.Text("TesteFisico PRO_ID", 30),
            ["MAQ_ID"] = ApiTestData.Text("TesteFisico MAQ_ID", 30),
            ["FPR_SEQ_REPETICAO"] = 1,
            ["FPR_SEQ_TRANFORMACAO"] = 1,
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
        payload["TES_ID"] = 2;
        payload["ITE_ID"] = 2;
        payload["USR_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Usuario", "USR_ID");
        payload["TES_NOME_TECNICO"] = ApiTestData.Text("TesteFisico TES_NOME_TECNICO Update", 80);
        payload["TES_AMOSTRA"] = 2;
        payload["TES_OP"] = ApiTestData.Text("TesteFisico TES_OP Update", 10);
        payload["TES_VALOR_NUMERICO"] = 20.5m;
        payload["TES_VALOR_DATA"] = DateTime.UtcNow.AddMinutes(1);
        payload["TES_VALOR_TEXTO"] = ApiTestData.Text("TesteFisico TES_VALOR_TEXTO Update", 80);
        payload["TES_EMISSAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["ORD_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Order", "ORD_ID");
        payload["PRO_ID"] = ApiTestData.Text("TesteFisico PRO_ID Update", 30);
        payload["MAQ_ID"] = ApiTestData.Text("TesteFisico MAQ_ID Update", 30);
        payload["FPR_SEQ_REPETICAO"] = 2;
        payload["FPR_SEQ_TRANFORMACAO"] = 2;
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