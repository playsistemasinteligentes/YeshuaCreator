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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.OrderTrack;

[SeedTestOrder(179)]
public partial class OrderTrackCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/OrderTrack/PostOrderTrack";
    private const string ReadEndpoint = "yapi/OrderTrack/ReadOrderTrack";
    private const string UpdateEndpoint = "yapi/OrderTrack/PutOrderTrack";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("OrderTrack", createdId);

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
            ["OTK_ID"] = 1,
            ["OTK_SEQUENCIA"] = 10.5m,
            ["OTK_VERSSAO"] = 1,
            ["ORD_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Order", "ORD_ID"),
            ["OTK_EVENTO"] = ApiTestData.Text("OrderTrack OTK_EVENTO", 80),
            ["OTK_DATA_NECESSIDADE_DE"] = DateTime.UtcNow,
            ["OTK_DATA_NECESSIDADE_ATE"] = DateTime.UtcNow,
            ["OTK_DATA_PREVISTA"] = DateTime.UtcNow,
            ["OTK_DATA_REALIZADA"] = DateTime.UtcNow,
            ["FPR_ID"] = 1,
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
        payload["OTK_ID"] = 2;
        payload["OTK_SEQUENCIA"] = 20.5m;
        payload["OTK_VERSSAO"] = 2;
        payload["ORD_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Order", "ORD_ID");
        payload["OTK_EVENTO"] = ApiTestData.Text("OrderTrack OTK_EVENTO Update", 80);
        payload["OTK_DATA_NECESSIDADE_DE"] = DateTime.UtcNow.AddMinutes(1);
        payload["OTK_DATA_NECESSIDADE_ATE"] = DateTime.UtcNow.AddMinutes(1);
        payload["OTK_DATA_PREVISTA"] = DateTime.UtcNow.AddMinutes(1);
        payload["OTK_DATA_REALIZADA"] = DateTime.UtcNow.AddMinutes(1);
        payload["FPR_ID"] = 2;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration