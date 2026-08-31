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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.TesteFisico;

[SeedTestOrder(160)]
public partial class TesteFisicoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/TesteFisico/PostTesteFisico";
    private const string ReadEndpoint = "yapi/TesteFisico/ReadTesteFisico";
    private const string UpdateEndpoint = "yapi/TesteFisico/PutTesteFisico";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("TesteFisico", createdId);

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
            ["ITE_ID"] = 1,
            ["USR_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Usuario", "USR_ID"),
            ["TES_NOME_TECNICO"] = ApiTestData.Text("TesteFisico TES_NOME_TECNICO", 80),
            ["TES_AMOSTRA"] = 1,
            ["TES_OP"] = ApiTestData.Text("TesteFisico TES_OP", 10),
            ["TES_VALOR_NUMERICO"] = 10.5m,
            ["TES_VALOR_DATA"] = DateTime.UtcNow,
            ["TES_VALOR_TEXTO"] = ApiTestData.Text("TesteFisico TES_VALOR_TEXTO", 80),
            ["TES_EMISSAO"] = DateTime.UtcNow,
            ["ORD_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Order", "ORD_ID"),
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
        payload["ITE_ID"] = 2;
        payload["USR_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Usuario", "USR_ID");
        payload["TES_NOME_TECNICO"] = ApiTestData.Text("TesteFisico TES_NOME_TECNICO Update", 80);
        payload["TES_AMOSTRA"] = 2;
        payload["TES_OP"] = ApiTestData.Text("TesteFisico TES_OP Update", 10);
        payload["TES_VALOR_NUMERICO"] = 20.5m;
        payload["TES_VALOR_DATA"] = DateTime.UtcNow.AddMinutes(1);
        payload["TES_VALOR_TEXTO"] = ApiTestData.Text("TesteFisico TES_VALOR_TEXTO Update", 80);
        payload["TES_EMISSAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["ORD_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Order", "ORD_ID");
        payload["PRO_ID"] = ApiTestData.Text("TesteFisico PRO_ID Update", 30);
        payload["MAQ_ID"] = ApiTestData.Text("TesteFisico MAQ_ID Update", 30);
        payload["FPR_SEQ_REPETICAO"] = 2;
        payload["FPR_SEQ_TRANFORMACAO"] = 2;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration