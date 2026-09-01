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

namespace Yeshua.Fiscal.MDFe.CQRS.Tests.Integration.Api.Seed.Migration.ySagaStep;

[SeedTestOrder(5)]
public partial class ySagaStepCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/ySagaStep/PostySagaStep";
    private const string ReadEndpoint = "yapi/ySagaStep/ReadySagaStep";
    private const string UpdateEndpoint = "yapi/ySagaStep/PutySagaStep";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("ySagaStep", createdId);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["SagaId"] = ApiSeedTestContext.GetRequiredCreatedId("ySaga", "SagaId"),
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
        payload["SagaId"] = ApiSeedTestContext.GetRequiredCreatedId("ySaga", "SagaId");
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

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration