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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.RotaPontosMapa;

[SeedTestOrder(77)]
public partial class RotaPontosMapaCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/RotaPontosMapa/PostRotaPontosMapa";
    private const string ReadEndpoint = "yapi/RotaPontosMapa/ReadRotaPontosMapa";
    private const string UpdateEndpoint = "yapi/RotaPontosMapa/PutRotaPontosMapa";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("RotaPontosMapa", createdId);

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
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["ROT_ID"] = ApiTestData.Text("RotaPontosMapa ROT_ID", 80),
            ["PON_ID_DESTINO"] = ApiSeedTestContext.GetRequiredCreatedId("PontosMapa", "PON_ID_DESTINO"),
            ["PON_ID_ORIGEM"] = ApiTestData.Text("RotaPontosMapa PON_ID_ORIGEM", 80),
            ["ROT_CUSTO_TOTAL"] = 10.5m,
            ["PON_ID_ROTEIRO"] = ApiTestData.Text("RotaPontosMapa PON_ID_ROTEIRO", 80),
            ["ROT_ORDEM_ROTEIRO"] = 1,
            ["ROT_TIPO"] = ApiTestData.Text("RotaPontosMapa ROT_TIPO", 2),
            ["ROT_DISTANCIA"] = 10.5m,
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
        payload["ROT_ID"] = ApiTestData.Text("RotaPontosMapa ROT_ID Update", 80);
        payload["PON_ID_DESTINO"] = ApiSeedTestContext.GetRequiredCreatedId("PontosMapa", "PON_ID_DESTINO");
        payload["PON_ID_ORIGEM"] = ApiTestData.Text("RotaPontosMapa PON_ID_ORIGEM Update", 80);
        payload["ROT_CUSTO_TOTAL"] = 20.5m;
        payload["PON_ID_ROTEIRO"] = ApiTestData.Text("RotaPontosMapa PON_ID_ROTEIRO Update", 80);
        payload["ROT_ORDEM_ROTEIRO"] = 2;
        payload["ROT_TIPO"] = ApiTestData.Text("RotaPontosMapa ROT_TIPO Update", 2);
        payload["ROT_DISTANCIA"] = 20.5m;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration