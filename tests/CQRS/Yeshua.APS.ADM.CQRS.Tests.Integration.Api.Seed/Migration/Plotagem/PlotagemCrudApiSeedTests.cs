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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Plotagem;

[SeedTestOrder(63)]
public partial class PlotagemCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Plotagem/PostPlotagem";
    private const string ReadEndpoint = "yapi/Plotagem/ReadPlotagem";
    private const string UpdateEndpoint = "yapi/Plotagem/PutPlotagem";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Plotagem", createdId);

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
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["PLO_ID"] = 1,
            ["PLO_NOME"] = ApiTestData.Text("Plotagem PLO_NOME", 80),
            ["PLO_DIMENSAO"] = ApiTestData.Text("Plotagem PLO_DIMENSAO", 80),
            ["PLO_X"] = ApiTestData.Text("Plotagem PLO_X", 80),
            ["PLO_Y"] = ApiTestData.Text("Plotagem PLO_Y", 80),
            ["PLO_Z"] = ApiTestData.Text("Plotagem PLO_Z", 80),
            ["PLO_GRAFICO"] = ApiTestData.Text("Plotagem PLO_GRAFICO", 10),
            ["CON_ID"] = 1,
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
        payload["PLO_ID"] = 2;
        payload["PLO_NOME"] = ApiTestData.Text("Plotagem PLO_NOME Update", 80);
        payload["PLO_DIMENSAO"] = ApiTestData.Text("Plotagem PLO_DIMENSAO Update", 80);
        payload["PLO_X"] = ApiTestData.Text("Plotagem PLO_X Update", 80);
        payload["PLO_Y"] = ApiTestData.Text("Plotagem PLO_Y Update", 80);
        payload["PLO_Z"] = ApiTestData.Text("Plotagem PLO_Z Update", 80);
        payload["PLO_GRAFICO"] = ApiTestData.Text("Plotagem PLO_GRAFICO Update", 10);
        payload["CON_ID"] = 2;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration