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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.IndicadoresDimencoes;

[SeedTestOrder(146)]
public partial class IndicadoresDimencoesCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/IndicadoresDimencoes/PostIndicadoresDimencoes";
    private const string ReadEndpoint = "yapi/IndicadoresDimencoes/ReadIndicadoresDimencoes";
    private const string UpdateEndpoint = "yapi/IndicadoresDimencoes/PutIndicadoresDimencoes";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("IndicadoresDimencoes", createdId);

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
            ["DIM_ID"] = 1,
            ["IND_ID"] = ApiSeedTestContext.GetRequiredCreatedId("T_Indicadores", "IND_ID"),
            ["DIM_DESCRICAO"] = ApiTestData.Text("IndicadoresDimencoes DIM_DESCRICAO", 80),
            ["DIM_SQL"] = ApiTestData.Text("IndicadoresDimencoes DIM_SQL", 80),
            ["DIM_CONEXAO"] = ApiTestData.Text("IndicadoresDimencoes DIM_CONEXAO", 80),
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
        payload["DIM_ID"] = 2;
        payload["IND_ID"] = ApiSeedTestContext.GetRequiredCreatedId("T_Indicadores", "IND_ID");
        payload["DIM_DESCRICAO"] = ApiTestData.Text("IndicadoresDimencoes DIM_DESCRICAO Update", 80);
        payload["DIM_SQL"] = ApiTestData.Text("IndicadoresDimencoes DIM_SQL Update", 80);
        payload["DIM_CONEXAO"] = ApiTestData.Text("IndicadoresDimencoes DIM_CONEXAO Update", 80);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration