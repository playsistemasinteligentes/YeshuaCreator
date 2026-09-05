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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Canhotos;

[SeedTestOrder(7)]
public partial class CanhotosCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Canhotos/PostCanhotos";
    private const string ReadEndpoint = "yapi/Canhotos/ReadCanhotos";
    private const string UpdateEndpoint = "yapi/Canhotos/PutCanhotos";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Canhotos", createdId);

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
            ["CAR_ID"] = ApiTestData.Text("Canhotos CAR_ID", 30),
            ["ORD_ID"] = ApiTestData.Text("Canhotos ORD_ID", 60),
            ["NOT_ID"] = ApiTestData.Text("Canhotos NOT_ID", 30),
            ["CAN_DATA_ENTREGA"] = DateTime.UtcNow,
            ["CAN_IMG"] = ApiTestData.Text("Canhotos CAN_IMG", 80),
            ["CAN_LAT_ENTREGA"] = 10.5m,
            ["CAN_LONG_ENTREGA"] = 10.5m,
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
        payload["CAR_ID"] = ApiTestData.Text("Canhotos CAR_ID Update", 30);
        payload["ORD_ID"] = ApiTestData.Text("Canhotos ORD_ID Update", 60);
        payload["NOT_ID"] = ApiTestData.Text("Canhotos NOT_ID Update", 30);
        payload["CAN_DATA_ENTREGA"] = DateTime.UtcNow.AddMinutes(1);
        payload["CAN_IMG"] = ApiTestData.Text("Canhotos CAN_IMG Update", 80);
        payload["CAN_LAT_ENTREGA"] = 20.5m;
        payload["CAN_LONG_ENTREGA"] = 20.5m;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration