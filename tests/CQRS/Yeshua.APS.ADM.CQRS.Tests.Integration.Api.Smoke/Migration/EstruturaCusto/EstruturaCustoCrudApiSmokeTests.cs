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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.EstruturaCusto;

[SmokeTestOrder(167)]
public partial class EstruturaCustoCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/EstruturaCusto/PostEstruturaCusto";
    private const string ReadEndpoint = "yapi/EstruturaCusto/ReadEstruturaCusto";
    private const string UpdateEndpoint = "yapi/EstruturaCusto/PutEstruturaCusto";
    private const string DeleteEndpoint = "yapi/EstruturaCusto/DeleteEstruturaCusto";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "est_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("EstruturaCusto", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("EstruturaCusto", initialDeletePayload);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "est_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("EstruturaCusto", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("EstruturaCusto", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "est_id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "EST_ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["ITO_ID"] = 1,
            ["ORD_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Order", "ORD_ID"),
            ["PRO_ID"] = ApiTestData.Text("EstruturaCusto PRO_ID", 30),
            ["PRO_ID_PRODUTO"] = ApiTestData.Text("EstruturaCusto PRO_ID_PRODUTO", 30),
            ["PRO_ID_COMPONENTE"] = ApiTestData.Text("EstruturaCusto PRO_ID_COMPONENTE", 30),
            ["PRO_TIPO_CUSTO"] = ApiTestData.Text("EstruturaCusto PRO_TIPO_CUSTO", 60),
            ["PRO_GRUPO_CONTABIL"] = ApiTestData.Text("EstruturaCusto PRO_GRUPO_CONTABIL", 60),
            ["EST_ORDEM"] = 1,
            ["EST_GRUPO"] = ApiTestData.Text("EstruturaCusto EST_GRUPO", 30),
            ["EST_QUANT"] = 10.5m,
            ["EST_VALOR_TOTAL"] = 10.5m,
            ["EST_DATA_BASE"] = ApiTestData.Text("EstruturaCusto EST_DATA_BASE", 6),
            ["EST_BASE_PRODUCAO"] = 10.5m,
            ["EST_NIVEL"] = 10.5m,
            ["FPR_SEQ_REPETICAO"] = 1,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["EST_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["EST_ID"] = id.DeepClone();
        payload["ITO_ID"] = 2;
        payload["ORD_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Order", "ORD_ID");
        payload["PRO_ID"] = ApiTestData.Text("EstruturaCusto PRO_ID Update", 30);
        payload["PRO_ID_PRODUTO"] = ApiTestData.Text("EstruturaCusto PRO_ID_PRODUTO Update", 30);
        payload["PRO_ID_COMPONENTE"] = ApiTestData.Text("EstruturaCusto PRO_ID_COMPONENTE Update", 30);
        payload["PRO_TIPO_CUSTO"] = ApiTestData.Text("EstruturaCusto PRO_TIPO_CUSTO Update", 60);
        payload["PRO_GRUPO_CONTABIL"] = ApiTestData.Text("EstruturaCusto PRO_GRUPO_CONTABIL Update", 60);
        payload["EST_ORDEM"] = 2;
        payload["EST_GRUPO"] = ApiTestData.Text("EstruturaCusto EST_GRUPO Update", 30);
        payload["EST_QUANT"] = 20.5m;
        payload["EST_VALOR_TOTAL"] = 20.5m;
        payload["EST_DATA_BASE"] = ApiTestData.Text("EstruturaCusto EST_DATA_BASE Update", 6);
        payload["EST_BASE_PRODUCAO"] = 20.5m;
        payload["EST_NIVEL"] = 20.5m;
        payload["FPR_SEQ_REPETICAO"] = 2;
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["EST_ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration