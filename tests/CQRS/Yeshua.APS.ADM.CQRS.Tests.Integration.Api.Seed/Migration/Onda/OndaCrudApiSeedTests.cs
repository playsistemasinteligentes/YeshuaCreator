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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Onda;

[SeedTestOrder(155)]
public partial class OndaCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Onda/PostOnda";
    private const string ReadEndpoint = "yapi/Onda/ReadOnda";
    private const string UpdateEndpoint = "yapi/Onda/PutOnda";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "ond_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Onda", createdId);

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        var readAssertionHandled = false;
        CustomizeReadAssertion(readState, createdId, ref readAssertionHandled);
        if (!readAssertionHandled)
            ApiResponseAssertions.AssertReadContainsId(readState, createdId, "ond_id");

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "ond_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["OND_ID"] = ApiTestData.KeyText(10),
            ["OND_ESPESSURA"] = 10.5m,
            ["OND_PESO_COLA"] = 10.5m,
            ["OND_RENDIMENTO_ONDA_1"] = 10.5m,
            ["OND_RENDIMENTO_ONDA_2"] = 10.5m,
            ["OND_PROFUNDIDADE_VINCO"] = 1,
            ["OND_ID_INTEGRACAO"] = ApiTestData.Text("Onda OND_ID_INTEGRACAO", 30),
            ["VIN_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Vinco", "VIN_ID"),
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["OND_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["OND_ID"] = id.DeepClone();
        payload["OND_ESPESSURA"] = 20.5m;
        payload["OND_PESO_COLA"] = 20.5m;
        payload["OND_RENDIMENTO_ONDA_1"] = 20.5m;
        payload["OND_RENDIMENTO_ONDA_2"] = 20.5m;
        payload["OND_PROFUNDIDADE_VINCO"] = 2;
        payload["OND_ID_INTEGRACAO"] = ApiTestData.Text("Onda OND_ID_INTEGRACAO Update", 30);
        payload["VIN_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Vinco", "VIN_ID");
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration