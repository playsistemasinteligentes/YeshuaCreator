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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.LogsDatabase;

[SeedTestOrder(150)]
public partial class LogsDatabaseCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/LogsDatabase/PostLogsDatabase";
    private const string ReadEndpoint = "yapi/LogsDatabase/ReadLogsDatabase";
    private const string UpdateEndpoint = "yapi/LogsDatabase/PutLogsDatabase";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "logs_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("LogsDatabase", createdId);

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        var readAssertionHandled = false;
        CustomizeReadAssertion(readState, createdId, ref readAssertionHandled);
        if (!readAssertionHandled)
            ApiResponseAssertions.AssertReadContainsId(readState, createdId, "logs_id");

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "logs_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["LOGS_TABLE"] = ApiTestData.Text("LogsDatabase LOGS_TABLE", 50),
            ["LOGS_KEY"] = ApiTestData.Text("LogsDatabase LOGS_KEY", 80),
            ["LOGS_KEY1"] = ApiTestData.Text("LogsDatabase LOGS_KEY1", 80),
            ["LOGS_KEY2"] = ApiTestData.Text("LogsDatabase LOGS_KEY2", 80),
            ["LOGS_KEY3"] = ApiTestData.Text("LogsDatabase LOGS_KEY3", 80),
            ["LOGS_KEY4"] = ApiTestData.Text("LogsDatabase LOGS_KEY4", 80),
            ["LOGS_COLUMN"] = ApiTestData.Text("LogsDatabase LOGS_COLUMN", 80),
            ["LOGS_BEFORE"] = ApiTestData.Text("LogsDatabase LOGS_BEFORE", 80),
            ["LOGS_AFTER"] = ApiTestData.Text("LogsDatabase LOGS_AFTER", 80),
            ["LOGS_ACTION"] = ApiTestData.Text("LogsDatabase LOGS_ACTION", 30),
            ["LOGS_DATE"] = DateTime.UtcNow,
            ["USE_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Usuario", "USE_ID"),
            ["LOGS_ORIGEM"] = ApiTestData.Text("LogsDatabase LOGS_ORIGEM", 80),
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["LOGS_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["LOGS_ID"] = id.DeepClone();
        payload["LOGS_TABLE"] = ApiTestData.Text("LogsDatabase LOGS_TABLE Update", 50);
        payload["LOGS_KEY"] = ApiTestData.Text("LogsDatabase LOGS_KEY Update", 80);
        payload["LOGS_KEY1"] = ApiTestData.Text("LogsDatabase LOGS_KEY1 Update", 80);
        payload["LOGS_KEY2"] = ApiTestData.Text("LogsDatabase LOGS_KEY2 Update", 80);
        payload["LOGS_KEY3"] = ApiTestData.Text("LogsDatabase LOGS_KEY3 Update", 80);
        payload["LOGS_KEY4"] = ApiTestData.Text("LogsDatabase LOGS_KEY4 Update", 80);
        payload["LOGS_COLUMN"] = ApiTestData.Text("LogsDatabase LOGS_COLUMN Update", 80);
        payload["LOGS_BEFORE"] = ApiTestData.Text("LogsDatabase LOGS_BEFORE Update", 80);
        payload["LOGS_AFTER"] = ApiTestData.Text("LogsDatabase LOGS_AFTER Update", 80);
        payload["LOGS_ACTION"] = ApiTestData.Text("LogsDatabase LOGS_ACTION Update", 30);
        payload["LOGS_DATE"] = DateTime.UtcNow.AddMinutes(1);
        payload["USE_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Usuario", "USE_ID");
        payload["LOGS_ORIGEM"] = ApiTestData.Text("LogsDatabase LOGS_ORIGEM Update", 80);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration