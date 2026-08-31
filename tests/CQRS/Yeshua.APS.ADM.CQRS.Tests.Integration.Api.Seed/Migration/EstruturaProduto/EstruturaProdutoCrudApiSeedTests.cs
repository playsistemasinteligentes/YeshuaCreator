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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.EstruturaProduto;

[SeedTestOrder(25)]
public partial class EstruturaProdutoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/EstruturaProduto/PostEstruturaProduto";
    private const string ReadEndpoint = "yapi/EstruturaProduto/ReadEstruturaProduto";
    private const string UpdateEndpoint = "yapi/EstruturaProduto/PutEstruturaProduto";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("EstruturaProduto", createdId);

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
            ["EST_DATA_VALIDADE"] = DateTime.UtcNow,
            ["PRO_ID_PRODUTO"] = ApiTestData.Text("EstruturaProduto PRO_ID_PRODUTO", 30),
            ["PRO_ID_COMPONENTE"] = ApiTestData.Text("EstruturaProduto PRO_ID_COMPONENTE", 30),
            ["EST_QUANT"] = 10.5m,
            ["EST_DATA_INCLUSAO"] = DateTime.UtcNow,
            ["EST_BASE_PRODUCAO"] = 10.5m,
            ["EST_TIPO_REQUISICAO"] = ApiTestData.Text("EstruturaProduto EST_TIPO_REQUISICAO", 2),
            ["EST_CODIGO_DE_EXCECAO"] = ApiTestData.Text("EstruturaProduto EST_CODIGO_DE_EXCECAO", 80),
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
        payload["EST_DATA_VALIDADE"] = DateTime.UtcNow.AddMinutes(1);
        payload["PRO_ID_PRODUTO"] = ApiTestData.Text("EstruturaProduto PRO_ID_PRODUTO Update", 30);
        payload["PRO_ID_COMPONENTE"] = ApiTestData.Text("EstruturaProduto PRO_ID_COMPONENTE Update", 30);
        payload["EST_QUANT"] = 20.5m;
        payload["EST_DATA_INCLUSAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["EST_BASE_PRODUCAO"] = 20.5m;
        payload["EST_TIPO_REQUISICAO"] = ApiTestData.Text("EstruturaProduto EST_TIPO_REQUISICAO Update", 2);
        payload["EST_CODIGO_DE_EXCECAO"] = ApiTestData.Text("EstruturaProduto EST_CODIGO_DE_EXCECAO Update", 80);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration