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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.T_PREFERENCIAS;

[SeedTestOrder(66)]
public partial class T_PREFERENCIASCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/T_PREFERENCIAS/PostT_PREFERENCIAS";
    private const string ReadEndpoint = "yapi/T_PREFERENCIAS/ReadT_PREFERENCIAS";
    private const string UpdateEndpoint = "yapi/T_PREFERENCIAS/PutT_PREFERENCIAS";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("T_PREFERENCIAS", createdId);

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
            ["PRE_ID"] = 1,
            ["PRE_DESCRICAO"] = ApiTestData.Text("T_PREFERENCIAS PRE_DESCRICAO", 80),
            ["PRE_NAMESPACE"] = ApiTestData.Text("T_PREFERENCIAS PRE_NAMESPACE", 80),
            ["PRE_TIPO"] = ApiTestData.Text("T_PREFERENCIAS PRE_TIPO", 50),
            ["PRE_VALOR"] = ApiTestData.Text("T_PREFERENCIAS PRE_VALOR", 80),
            ["USE_ID"] = 1,
            ["PER_ID"] = 1,
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
        payload["PRE_ID"] = 2;
        payload["PRE_DESCRICAO"] = ApiTestData.Text("T_PREFERENCIAS PRE_DESCRICAO Update", 80);
        payload["PRE_NAMESPACE"] = ApiTestData.Text("T_PREFERENCIAS PRE_NAMESPACE Update", 80);
        payload["PRE_TIPO"] = ApiTestData.Text("T_PREFERENCIAS PRE_TIPO Update", 50);
        payload["PRE_VALOR"] = ApiTestData.Text("T_PREFERENCIAS PRE_VALOR Update", 80);
        payload["USE_ID"] = 2;
        payload["PER_ID"] = 2;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration