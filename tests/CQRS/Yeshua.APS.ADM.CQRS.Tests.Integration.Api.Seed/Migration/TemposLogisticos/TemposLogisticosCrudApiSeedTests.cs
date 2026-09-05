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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.TemposLogisticos;

[SeedTestOrder(85)]
public partial class TemposLogisticosCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/TemposLogisticos/PostTemposLogisticos";
    private const string ReadEndpoint = "yapi/TemposLogisticos/ReadTemposLogisticos";
    private const string UpdateEndpoint = "yapi/TemposLogisticos/PutTemposLogisticos";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("TemposLogisticos", createdId);

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
            ["TMP_TIPO_TEMPO"] = ApiTestData.Text("TemposLogisticos TMP_TIPO_TEMPO", 50),
            ["TMP_TIPO_CARGA"] = ApiTestData.Text("TemposLogisticos TMP_TIPO_CARGA", 50),
            ["TMP_TEMPO_MEDIO_UNITARIO"] = 10.5m,
            ["CLI_ID"] = ApiTestData.Text("TemposLogisticos CLI_ID", 30),
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
        payload["TMP_TIPO_TEMPO"] = ApiTestData.Text("TemposLogisticos TMP_TIPO_TEMPO Update", 50);
        payload["TMP_TIPO_CARGA"] = ApiTestData.Text("TemposLogisticos TMP_TIPO_CARGA Update", 50);
        payload["TMP_TEMPO_MEDIO_UNITARIO"] = 20.5m;
        payload["CLI_ID"] = ApiTestData.Text("TemposLogisticos CLI_ID Update", 30);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration