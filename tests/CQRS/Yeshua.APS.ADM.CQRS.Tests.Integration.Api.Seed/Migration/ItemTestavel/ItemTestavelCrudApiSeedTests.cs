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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.ItemTestavel;

[SeedTestOrder(34)]
public partial class ItemTestavelCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/ItemTestavel/PostItemTestavel";
    private const string ReadEndpoint = "yapi/ItemTestavel/ReadItemTestavel";
    private const string UpdateEndpoint = "yapi/ItemTestavel/PutItemTestavel";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("ItemTestavel", createdId);

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
            ["ITE_DESCRICAO"] = ApiTestData.Text("ItemTestavel ITE_DESCRICAO", 80),
            ["ITE_OBS"] = ApiTestData.Text("ItemTestavel ITE_OBS", 10),
            ["ITE_NUMERO_DE_TESTES"] = 1,
            ["ITE_CONDICIONAL_DE_AVALIACAO"] = ApiTestData.Text("ItemTestavel ITE_CONDICIONAL_DE_AVALIACAO", 10),
            ["ITE_VALOR_DA_CONDICIONAL"] = 10.5m,
            ["ITE_VALOR_CALCULADO_DA_CONDICIONAL"] = ApiTestData.Text("ItemTestavel ITE_VALOR_CALCULADO_DA_CONDICIONAL", 10),
            ["ITE_TIPO_AVALIACAO_FINAL"] = ApiTestData.Text("ItemTestavel ITE_TIPO_AVALIACAO_FINAL", 10),
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
        payload["ITE_DESCRICAO"] = ApiTestData.Text("ItemTestavel ITE_DESCRICAO Update", 80);
        payload["ITE_OBS"] = ApiTestData.Text("ItemTestavel ITE_OBS Update", 10);
        payload["ITE_NUMERO_DE_TESTES"] = 2;
        payload["ITE_CONDICIONAL_DE_AVALIACAO"] = ApiTestData.Text("ItemTestavel ITE_CONDICIONAL_DE_AVALIACAO Update", 10);
        payload["ITE_VALOR_DA_CONDICIONAL"] = 20.5m;
        payload["ITE_VALOR_CALCULADO_DA_CONDICIONAL"] = ApiTestData.Text("ItemTestavel ITE_VALOR_CALCULADO_DA_CONDICIONAL Update", 10);
        payload["ITE_TIPO_AVALIACAO_FINAL"] = ApiTestData.Text("ItemTestavel ITE_TIPO_AVALIACAO_FINAL Update", 10);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration