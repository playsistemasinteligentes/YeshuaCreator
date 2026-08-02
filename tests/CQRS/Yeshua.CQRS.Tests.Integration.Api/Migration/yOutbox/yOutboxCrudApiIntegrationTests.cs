using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.CQRS.Tests.Integration.Api.Migration.yOutbox;

public partial class yOutboxCrudApiIntegrationTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "/yapi/yOutbox/PostyOutbox";
    private const string ReadEndpoint = "/yapi/yOutbox/ReadyOutbox";
    private const string UpdateEndpoint = "/yapi/yOutbox/PutyOutbox";
    private const string DeleteEndpoint = "/yapi/yOutbox/DeleteyOutbox";

    [IntegrationFact]
    public async Task Crud_should_create_read_update_and_delete_through_api()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        ApiResponseAssertions.AssertReadContainsId(readState, createdId);

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["MessageId"] = ApiTestData.Text("yOutbox MessageId", 80),
            ["Type"] = ApiTestData.Text("yOutbox Type", 80),
            ["EntityType"] = ApiTestData.Text("yOutbox EntityType", 80),
            ["EntityId"] = ApiTestData.Text("yOutbox EntityId", 80),
            ["CorrelationId"] = ApiTestData.Text("yOutbox CorrelationId", 80),
            ["Payload"] = ApiTestData.Text("yOutbox Payload", 80),
            ["Status"] = 0,
            ["TransportType"] = 1,
            ["TransportData"] = ApiTestData.Text("yOutbox TransportData", 80),
            ["CreatedAt"] = DateTime.UtcNow,
            ["SentAt"] = DateTime.UtcNow,
            ["RetryCount"] = 1,
            ["LastError"] = ApiTestData.Text("yOutbox LastError", 80),
            ["ProcessingAt"] = DateTime.UtcNow,
            ["NextAttemptAt"] = DateTime.UtcNow,
            ["SagaId"] = 1,
            ["SagaStepId"] = 1,
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
        payload["MessageId"] = ApiTestData.Text("yOutbox MessageId Update", 80);
        payload["Type"] = ApiTestData.Text("yOutbox Type Update", 80);
        payload["EntityType"] = ApiTestData.Text("yOutbox EntityType Update", 80);
        payload["EntityId"] = ApiTestData.Text("yOutbox EntityId Update", 80);
        payload["CorrelationId"] = ApiTestData.Text("yOutbox CorrelationId Update", 80);
        payload["Payload"] = ApiTestData.Text("yOutbox Payload Update", 80);
        payload["Status"] = 0;
        payload["TransportType"] = 1;
        payload["TransportData"] = ApiTestData.Text("yOutbox TransportData Update", 80);
        payload["CreatedAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["SentAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["RetryCount"] = 2;
        payload["LastError"] = ApiTestData.Text("yOutbox LastError Update", 80);
        payload["ProcessingAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["NextAttemptAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["SagaId"] = 1;
        payload["SagaStepId"] = 1;
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["Id"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiCrudTestMigration