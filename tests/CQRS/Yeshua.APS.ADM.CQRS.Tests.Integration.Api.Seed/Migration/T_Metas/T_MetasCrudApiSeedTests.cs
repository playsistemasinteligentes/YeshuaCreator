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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.T_Metas;

[SeedTestOrder(152)]
public partial class T_MetasCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/T_Metas/PostT_Metas";
    private const string ReadEndpoint = "yapi/T_Metas/ReadT_Metas";
    private const string UpdateEndpoint = "yapi/T_Metas/PutT_Metas";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "met_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("T_Metas", createdId);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "met_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["MET_DTINICIO"] = ApiTestData.Text("T_Metas MET_DTINICIO", 8),
            ["MET_DTFIM"] = ApiTestData.Text("T_Metas MET_DTFIM", 8),
            ["MET_ALVO"] = ApiTestData.Text("T_Metas MET_ALVO", 50),
            ["MET_TIPOALVO"] = 1,
            ["IND_ID"] = ApiSeedTestContext.GetRequiredCreatedId("T_Indicadores", "IND_ID"),
            ["MET_RANGE01"] = 10.5m,
            ["MET_RANGE02"] = 10.5m,
            ["MET_RANGE03"] = 10.5m,
            ["DIM_ID"] = 1,
            ["FAT_ID"] = ApiTestData.Text("T_Metas FAT_ID", 80),
            ["DIM_SUBDIMENSAO_ID"] = ApiTestData.Text("T_Metas DIM_SUBDIMENSAO_ID", 80),
            ["PER_ID"] = ApiTestData.Text("T_Metas PER_ID", 3),
            ["DOM_EMPRESA"] = ApiTestData.Text("T_Metas DOM_EMPRESA", 30),
            ["DOM_FILIAL"] = ApiTestData.Text("T_Metas DOM_FILIAL", 30),
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["MET_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["MET_ID"] = id.DeepClone();
        payload["MET_DTINICIO"] = ApiTestData.Text("T_Metas MET_DTINICIO Update", 8);
        payload["MET_DTFIM"] = ApiTestData.Text("T_Metas MET_DTFIM Update", 8);
        payload["MET_ALVO"] = ApiTestData.Text("T_Metas MET_ALVO Update", 50);
        payload["MET_TIPOALVO"] = 2;
        payload["IND_ID"] = ApiSeedTestContext.GetRequiredCreatedId("T_Indicadores", "IND_ID");
        payload["MET_RANGE01"] = 20.5m;
        payload["MET_RANGE02"] = 20.5m;
        payload["MET_RANGE03"] = 20.5m;
        payload["DIM_ID"] = 2;
        payload["FAT_ID"] = ApiTestData.Text("T_Metas FAT_ID Update", 80);
        payload["DIM_SUBDIMENSAO_ID"] = ApiTestData.Text("T_Metas DIM_SUBDIMENSAO_ID Update", 80);
        payload["PER_ID"] = ApiTestData.Text("T_Metas PER_ID Update", 3);
        payload["DOM_EMPRESA"] = ApiTestData.Text("T_Metas DOM_EMPRESA Update", 30);
        payload["DOM_FILIAL"] = ApiTestData.Text("T_Metas DOM_FILIAL Update", 30);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration