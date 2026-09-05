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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Seed.Migration.CTeEntradaOficial;

[SeedTestOrder(4)]
public partial class CTeEntradaOficialCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/CTeEntradaOficial/PostCTeEntradaOficial";
    private const string ReadEndpoint = "yapi/CTeEntradaOficial/ReadCTeEntradaOficial";
    private const string UpdateEndpoint = "yapi/CTeEntradaOficial/PutCTeEntradaOficial";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("CTeEntradaOficial", createdId);

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
            ["CorrelationId"] = ApiTestData.Text("CTeEntradaOficial CorrelationId", 80),
            ["SourceApplication"] = ApiTestData.Text("CTeEntradaOficial SourceApplication", 80),
            ["SourceModule"] = ApiTestData.Text("CTeEntradaOficial SourceModule", 80),
            ["SourceMessageId"] = ApiTestData.Text("CTeEntradaOficial SourceMessageId", 80),
            ["MessageType"] = ApiTestData.Text("CTeEntradaOficial MessageType", 80),
            ["MessageVersion"] = ApiTestData.Text("CTeEntradaOficial MessageVersion", 20),
            ["ReceivedAtUtc"] = DateTime.UtcNow,
            ["PayloadHash"] = ApiTestData.Text("CTeEntradaOficial PayloadHash", 80),
            ["PayloadStorageKey"] = ApiTestData.Text("CTeEntradaOficial PayloadStorageKey", 80),
            ["Status"] = 1,
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
        payload["CorrelationId"] = ApiTestData.Text("CTeEntradaOficial CorrelationId Update", 80);
        payload["SourceApplication"] = ApiTestData.Text("CTeEntradaOficial SourceApplication Update", 80);
        payload["SourceModule"] = ApiTestData.Text("CTeEntradaOficial SourceModule Update", 80);
        payload["SourceMessageId"] = ApiTestData.Text("CTeEntradaOficial SourceMessageId Update", 80);
        payload["MessageType"] = ApiTestData.Text("CTeEntradaOficial MessageType Update", 80);
        payload["MessageVersion"] = ApiTestData.Text("CTeEntradaOficial MessageVersion Update", 20);
        payload["ReceivedAtUtc"] = DateTime.UtcNow.AddMinutes(1);
        payload["PayloadHash"] = ApiTestData.Text("CTeEntradaOficial PayloadHash Update", 80);
        payload["PayloadStorageKey"] = ApiTestData.Text("CTeEntradaOficial PayloadStorageKey Update", 80);
        payload["Status"] = 1;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration