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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.TempoSetupOnduladeira;

[SeedTestOrder(159)]
public partial class TempoSetupOnduladeiraCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/TempoSetupOnduladeira/PostTempoSetupOnduladeira";
    private const string ReadEndpoint = "yapi/TempoSetupOnduladeira/ReadTempoSetupOnduladeira";
    private const string UpdateEndpoint = "yapi/TempoSetupOnduladeira/PutTempoSetupOnduladeira";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "tem_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("TempoSetupOnduladeira", createdId);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "tem_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["OND_ID_DE"] = ApiSeedTestContext.GetRequiredCreatedId("Onda", "OND_ID_DE"),
            ["OND_ID_PARA"] = ApiTestData.Text("TempoSetupOnduladeira OND_ID_PARA", 10),
            ["TEM_RESINA_DE"] = ApiTestData.Text("TempoSetupOnduladeira TEM_RESINA_DE", 1),
            ["TEM_RESINA_PARA"] = ApiTestData.Text("TempoSetupOnduladeira TEM_RESINA_PARA", 1),
            ["TEM_TEMPO"] = 1,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["TEM_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["TEM_ID"] = id.DeepClone();
        payload["OND_ID_DE"] = ApiSeedTestContext.GetRequiredCreatedId("Onda", "OND_ID_DE");
        payload["OND_ID_PARA"] = ApiTestData.Text("TempoSetupOnduladeira OND_ID_PARA Update", 10);
        payload["TEM_RESINA_DE"] = ApiTestData.Text("TempoSetupOnduladeira TEM_RESINA_DE Update", 1);
        payload["TEM_RESINA_PARA"] = ApiTestData.Text("TempoSetupOnduladeira TEM_RESINA_PARA Update", 1);
        payload["TEM_TEMPO"] = 2;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration