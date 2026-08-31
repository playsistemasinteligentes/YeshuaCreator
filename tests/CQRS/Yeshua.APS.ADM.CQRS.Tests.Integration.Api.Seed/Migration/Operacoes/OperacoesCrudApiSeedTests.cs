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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Operacoes;

[SeedTestOrder(54)]
public partial class OperacoesCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Operacoes/PostOperacoes";
    private const string ReadEndpoint = "yapi/Operacoes/ReadOperacoes";
    private const string UpdateEndpoint = "yapi/Operacoes/PutOperacoes";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Operacoes", createdId);

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
            ["OPE_TIPO_REGISTRO"] = ApiTestData.Text("Operacoes OPE_TIPO_REGISTRO", 2),
            ["OPE_ID"] = ApiTestData.Text("Operacoes OPE_ID", 60),
            ["GMA_ID"] = ApiTestData.Text("Operacoes GMA_ID", 10),
            ["MAQ_ID"] = ApiTestData.Text("Operacoes MAQ_ID", 30),
            ["PRO_ID"] = ApiTestData.Text("Operacoes PRO_ID", 30),
            ["OPE_EXCECAO"] = ApiTestData.Text("Operacoes OPE_EXCECAO", 10),
            ["ROT_SEQ_TRANFORMACAO"] = 1,
            ["ORD_ID"] = ApiTestData.Text("Operacoes ORD_ID", 60),
            ["FPR_SEQ_REPETICAO"] = 1,
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
        payload["OPE_TIPO_REGISTRO"] = ApiTestData.Text("Operacoes OPE_TIPO_REGISTRO Update", 2);
        payload["OPE_ID"] = ApiTestData.Text("Operacoes OPE_ID Update", 60);
        payload["GMA_ID"] = ApiTestData.Text("Operacoes GMA_ID Update", 10);
        payload["MAQ_ID"] = ApiTestData.Text("Operacoes MAQ_ID Update", 30);
        payload["PRO_ID"] = ApiTestData.Text("Operacoes PRO_ID Update", 30);
        payload["OPE_EXCECAO"] = ApiTestData.Text("Operacoes OPE_EXCECAO Update", 10);
        payload["ROT_SEQ_TRANFORMACAO"] = 2;
        payload["ORD_ID"] = ApiTestData.Text("Operacoes ORD_ID Update", 60);
        payload["FPR_SEQ_REPETICAO"] = 2;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration