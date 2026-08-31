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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Ocorrencia;

[SeedTestOrder(154)]
public partial class OcorrenciaCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Ocorrencia/PostOcorrencia";
    private const string ReadEndpoint = "yapi/Ocorrencia/ReadOcorrencia";
    private const string UpdateEndpoint = "yapi/Ocorrencia/PutOcorrencia";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "oco_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Ocorrencia", createdId);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "oco_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["OCO_ID"] = ApiTestData.Text("Ocorrencia OCO_ID", 30),
            ["OCO_DESCRICAO"] = ApiTestData.Text("Ocorrencia OCO_DESCRICAO", 80),
            ["TIP_ID"] = ApiSeedTestContext.GetRequiredCreatedId("TipoOcorrencia", "TIP_ID"),
            ["GMA_ID"] = ApiTestData.Text("Ocorrencia GMA_ID", 30),
            ["MAQ_ID"] = ApiTestData.Text("Ocorrencia MAQ_ID", 30),
            ["SPR"] = 1,
            ["OCO_SUB_TIPO"] = ApiTestData.Text("Ocorrencia OCO_SUB_TIPO", 80),
            ["SUB_ID"] = ApiTestData.Text("Ocorrencia SUB_ID", 30),
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["OCO_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["OCO_ID"] = id.DeepClone();
        payload["OCO_DESCRICAO"] = ApiTestData.Text("Ocorrencia OCO_DESCRICAO Update", 80);
        payload["TIP_ID"] = ApiSeedTestContext.GetRequiredCreatedId("TipoOcorrencia", "TIP_ID");
        payload["GMA_ID"] = ApiTestData.Text("Ocorrencia GMA_ID Update", 30);
        payload["MAQ_ID"] = ApiTestData.Text("Ocorrencia MAQ_ID Update", 30);
        payload["SPR"] = 2;
        payload["OCO_SUB_TIPO"] = ApiTestData.Text("Ocorrencia OCO_SUB_TIPO Update", 80);
        payload["SUB_ID"] = ApiTestData.Text("Ocorrencia SUB_ID Update", 30);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration