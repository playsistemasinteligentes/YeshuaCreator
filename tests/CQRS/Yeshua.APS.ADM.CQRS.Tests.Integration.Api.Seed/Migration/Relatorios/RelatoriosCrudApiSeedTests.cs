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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Relatorios;

[SeedTestOrder(117)]
public partial class RelatoriosCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Relatorios/PostRelatorios";
    private const string ReadEndpoint = "yapi/Relatorios/ReadRelatorios";
    private const string UpdateEndpoint = "yapi/Relatorios/PutRelatorios";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "rel_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Relatorios", createdId);

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        var readAssertionHandled = false;
        CustomizeReadAssertion(readState, createdId, ref readAssertionHandled);
        if (!readAssertionHandled)
            ApiResponseAssertions.AssertReadContainsId(readState, createdId, "rel_id");

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "rel_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["REL_NOME_RELATORIO"] = ApiTestData.Text("Relatorios REL_NOME_RELATORIO", 30),
            ["REL_NOME_CAMPO"] = ApiTestData.Text("Relatorios REL_NOME_CAMPO", 80),
            ["REL_TIPO_CAMPO"] = ApiTestData.Text("Relatorios REL_TIPO_CAMPO", 50),
            ["REL_POS_X"] = 1,
            ["REL_POS_Y"] = 1,
            ["REL_TAMANHO_FONTE"] = 1,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["REL_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["REL_ID"] = id.DeepClone();
        payload["REL_NOME_RELATORIO"] = ApiTestData.Text("Relatorios REL_NOME_RELATORIO Update", 30);
        payload["REL_NOME_CAMPO"] = ApiTestData.Text("Relatorios REL_NOME_CAMPO Update", 80);
        payload["REL_TIPO_CAMPO"] = ApiTestData.Text("Relatorios REL_TIPO_CAMPO Update", 50);
        payload["REL_POS_X"] = 2;
        payload["REL_POS_Y"] = 2;
        payload["REL_TAMANHO_FONTE"] = 2;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration