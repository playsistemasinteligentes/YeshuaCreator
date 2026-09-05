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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Segmento;

[SeedTestOrder(78)]
public partial class SegmentoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Segmento/PostSegmento";
    private const string ReadEndpoint = "yapi/Segmento/ReadSegmento";
    private const string UpdateEndpoint = "yapi/Segmento/PutSegmento";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Segmento", createdId);

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
            ["SEG_ID"] = ApiTestData.Text("Segmento SEG_ID", 30),
            ["SEG_DESCRICAO"] = ApiTestData.Text("Segmento SEG_DESCRICAO", 50),
            ["SEG_ID_SEGUIMENTO_PAI"] = ApiTestData.Text("Segmento SEG_ID_SEGUIMENTO_PAI", 30),
            ["GRS_ID"] = ApiTestData.Text("Segmento GRS_ID", 30),
            ["SEG_INTEGRACAO_ERP"] = ApiTestData.Text("Segmento SEG_INTEGRACAO_ERP", 80),
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
        payload["SEG_ID"] = ApiTestData.Text("Segmento SEG_ID Update", 30);
        payload["SEG_DESCRICAO"] = ApiTestData.Text("Segmento SEG_DESCRICAO Update", 50);
        payload["SEG_ID_SEGUIMENTO_PAI"] = ApiTestData.Text("Segmento SEG_ID_SEGUIMENTO_PAI Update", 30);
        payload["GRS_ID"] = ApiTestData.Text("Segmento GRS_ID Update", 30);
        payload["SEG_INTEGRACAO_ERP"] = ApiTestData.Text("Segmento SEG_INTEGRACAO_ERP Update", 80);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration