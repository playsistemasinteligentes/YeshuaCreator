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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.RestricoesDeRodagem;

[SeedTestOrder(72)]
public partial class RestricoesDeRodagemCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/RestricoesDeRodagem/PostRestricoesDeRodagem";
    private const string ReadEndpoint = "yapi/RestricoesDeRodagem/ReadRestricoesDeRodagem";
    private const string UpdateEndpoint = "yapi/RestricoesDeRodagem/PutRestricoesDeRodagem";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("RestricoesDeRodagem", createdId);

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
            ["RES_ID"] = 1,
            ["RES_TIPO"] = ApiTestData.Text("RestricoesDeRodagem RES_TIPO", 1),
            ["RES_HORA_INI"] = ApiTestData.Text("RestricoesDeRodagem RES_HORA_INI", 5),
            ["RES_HORA_FIM"] = ApiTestData.Text("RestricoesDeRodagem RES_HORA_FIM", 10),
            ["RES_VELOCIDADE_HORA_RUSH"] = 10.5m,
            ["TVE_ID"] = 1,
            ["MAP_ID"] = 1,
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
        payload["RES_ID"] = 2;
        payload["RES_TIPO"] = ApiTestData.Text("RestricoesDeRodagem RES_TIPO Update", 1);
        payload["RES_HORA_INI"] = ApiTestData.Text("RestricoesDeRodagem RES_HORA_INI Update", 5);
        payload["RES_HORA_FIM"] = ApiTestData.Text("RestricoesDeRodagem RES_HORA_FIM Update", 10);
        payload["RES_VELOCIDADE_HORA_RUSH"] = 20.5m;
        payload["TVE_ID"] = 2;
        payload["MAP_ID"] = 2;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration