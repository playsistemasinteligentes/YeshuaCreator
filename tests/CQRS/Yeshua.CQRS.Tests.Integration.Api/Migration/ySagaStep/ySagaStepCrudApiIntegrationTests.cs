using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.CQRS.Tests.Integration.Api.Migration.ySagaStep;

public partial class ySagaStepCrudApiIntegrationTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "/yapi/ySagaStep/PostySagaStep";
    private const string ReadEndpoint = "/yapi/ySagaStep/ReadySagaStep";
    private const string UpdateEndpoint = "/yapi/ySagaStep/PutySagaStep";
    private const string DeleteEndpoint = "/yapi/ySagaStep/DeleteySagaStep";

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
            ["SagaId"] = 1,
            ["StepKey"] = ApiTestData.Text("ySagaStep StepKey", 80),
            ["IndexOrder"] = 1,
            ["CorrelationId"] = ApiTestData.Text("ySagaStep CorrelationId", 80),
            ["Status"] = 0,
            ["ExecutionCount"] = 1,
            ["LastExecutionAt"] = DateTime.UtcNow,
            ["CompletedAt"] = DateTime.UtcNow,
            ["ErrorMessage"] = ApiTestData.Text("ySagaStep ErrorMessage", 80),
            ["Payload"] = ApiTestData.Text("ySagaStep Payload", 80),
            ["RetryCount"] = 1,
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
        payload["SagaId"] = 1;
        payload["StepKey"] = ApiTestData.Text("ySagaStep StepKey Update", 80);
        payload["IndexOrder"] = 2;
        payload["CorrelationId"] = ApiTestData.Text("ySagaStep CorrelationId Update", 80);
        payload["Status"] = 0;
        payload["ExecutionCount"] = 2;
        payload["LastExecutionAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["CompletedAt"] = DateTime.UtcNow.AddMinutes(1);
        payload["ErrorMessage"] = ApiTestData.Text("ySagaStep ErrorMessage Update", 80);
        payload["Payload"] = ApiTestData.Text("ySagaStep Payload Update", 80);
        payload["RetryCount"] = 2;
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