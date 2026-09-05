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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.LaudoTesteFisico;

[SeedTestOrder(37)]
public partial class LaudoTesteFisicoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/LaudoTesteFisico/PostLaudoTesteFisico";
    private const string ReadEndpoint = "yapi/LaudoTesteFisico/ReadLaudoTesteFisico";
    private const string UpdateEndpoint = "yapi/LaudoTesteFisico/PutLaudoTesteFisico";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("LaudoTesteFisico", createdId);

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
            ["LTF_ID"] = 1,
            ["LTF_EMISSAO"] = DateTime.UtcNow,
            ["LTF_VALOR"] = 10.5m,
            ["LTF_OBS"] = ApiTestData.Text("LaudoTesteFisico LTF_OBS", 80),
            ["LTF_STATUS"] = ApiTestData.Text("LaudoTesteFisico LTF_STATUS", 60),
            ["ORD_ID"] = ApiTestData.Text("LaudoTesteFisico ORD_ID", 60),
            ["ROT_PRO_ID"] = ApiTestData.Text("LaudoTesteFisico ROT_PRO_ID", 30),
            ["FPR_SEQ_REPETICAO"] = 1,
            ["USE_ID"] = 1,
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
        payload["LTF_ID"] = 2;
        payload["LTF_EMISSAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["LTF_VALOR"] = 20.5m;
        payload["LTF_OBS"] = ApiTestData.Text("LaudoTesteFisico LTF_OBS Update", 80);
        payload["LTF_STATUS"] = ApiTestData.Text("LaudoTesteFisico LTF_STATUS Update", 60);
        payload["ORD_ID"] = ApiTestData.Text("LaudoTesteFisico ORD_ID Update", 60);
        payload["ROT_PRO_ID"] = ApiTestData.Text("LaudoTesteFisico ROT_PRO_ID Update", 30);
        payload["FPR_SEQ_REPETICAO"] = 2;
        payload["USE_ID"] = 2;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration