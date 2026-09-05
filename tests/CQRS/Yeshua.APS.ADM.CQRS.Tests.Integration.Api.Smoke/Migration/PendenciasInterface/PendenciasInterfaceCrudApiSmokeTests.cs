// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration
// </yeshua>

using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.PendenciasInterface;

[SmokeTestOrder(58)]
public partial class PendenciasInterfaceCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/PendenciasInterface/PostPendenciasInterface";
    private const string ReadEndpoint = "yapi/PendenciasInterface/ReadPendenciasInterface";
    private const string UpdateEndpoint = "yapi/PendenciasInterface/PutPendenciasInterface";
    private const string DeleteEndpoint = "yapi/PendenciasInterface/DeletePendenciasInterface";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "pen_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("PendenciasInterface", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("PendenciasInterface", initialDeletePayload);

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        var readAssertionHandled = false;
        CustomizeReadAssertion(readState, createdId, ref readAssertionHandled);
        if (!readAssertionHandled)
            ApiResponseAssertions.AssertReadContainsId(readState, createdId, "pen_id");

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "pen_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("PendenciasInterface", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("PendenciasInterface", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "pen_id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "PEN_ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["PEN_STATUS_OUT"] = ApiTestData.Text("PendenciasInterface PEN_STATUS_OUT", 15),
            ["PEN_PROTOCOLO_OUT"] = ApiTestData.Text("PendenciasInterface PEN_PROTOCOLO_OUT", 80),
            ["PEN_ID_PROTOCOLO_OUT"] = ApiTestData.Text("PendenciasInterface PEN_ID_PROTOCOLO_OUT", 80),
            ["PEN_STATUS_IN"] = ApiTestData.Text("PendenciasInterface PEN_STATUS_IN", 15),
            ["PEN_PROTOCOLO_IN"] = ApiTestData.Text("PendenciasInterface PEN_PROTOCOLO_IN", 80),
            ["PEN_ID_PROTOCOLO_IN"] = ApiTestData.Text("PendenciasInterface PEN_ID_PROTOCOLO_IN", 80),
            ["DATA_ENTRADA"] = DateTime.UtcNow,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["PEN_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["PEN_ID"] = id.DeepClone();
        payload["PEN_STATUS_OUT"] = ApiTestData.Text("PendenciasInterface PEN_STATUS_OUT Update", 15);
        payload["PEN_PROTOCOLO_OUT"] = ApiTestData.Text("PendenciasInterface PEN_PROTOCOLO_OUT Update", 80);
        payload["PEN_ID_PROTOCOLO_OUT"] = ApiTestData.Text("PendenciasInterface PEN_ID_PROTOCOLO_OUT Update", 80);
        payload["PEN_STATUS_IN"] = ApiTestData.Text("PendenciasInterface PEN_STATUS_IN Update", 15);
        payload["PEN_PROTOCOLO_IN"] = ApiTestData.Text("PendenciasInterface PEN_PROTOCOLO_IN Update", 80);
        payload["PEN_ID_PROTOCOLO_IN"] = ApiTestData.Text("PendenciasInterface PEN_ID_PROTOCOLO_IN Update", 80);
        payload["DATA_ENTRADA"] = DateTime.UtcNow.AddMinutes(1);
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["PEN_ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration