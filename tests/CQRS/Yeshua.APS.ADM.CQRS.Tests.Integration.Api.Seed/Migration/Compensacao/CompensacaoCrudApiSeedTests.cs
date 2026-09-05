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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Compensacao;

[SeedTestOrder(184)]
public partial class CompensacaoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Compensacao/PostCompensacao";
    private const string ReadEndpoint = "yapi/Compensacao/ReadCompensacao";
    private const string UpdateEndpoint = "yapi/Compensacao/PutCompensacao";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Compensacao", createdId);

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
            ["COM_ID"] = 1,
            ["GRP_ID"] = ApiSeedTestContext.GetRequiredCreatedId("GrupoProdutoAbstrato", "GRP_ID"),
            ["OND_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Onda", "OND_ID"),
            ["COM_VINCO1_OND"] = 1,
            ["COM_VINCO2_OND"] = 1,
            ["COM_VINCO3_OND"] = 1,
            ["COM_VINCO4_OND"] = 1,
            ["COM_VINCO5_OND"] = 1,
            ["COM_VINCO6_OND"] = 1,
            ["COM_VINCO7_OND"] = 1,
            ["COM_VINCO8_OND"] = 1,
            ["COM_VINCO9_OND"] = 1,
            ["COM_VINCO10_OND"] = 1,
            ["COM_VINCO1_CONVERSAO"] = 1,
            ["COM_VINCO2_CONVERSAO"] = 1,
            ["COM_VINCO3_CONVERSAO"] = 1,
            ["COM_VINCO4_CONVERSAO"] = 1,
            ["COM_VINCO5_CONVERSAO"] = 1,
            ["COM_VINCO6_CONVERSAO"] = 1,
            ["COM_VINCO7_CONVERSAO"] = 1,
            ["COM_VINCO8_CONVERSAO"] = 1,
            ["COM_VINCO9_CONVERSAO"] = 1,
            ["COM_VINCO10_CONVERSAO"] = 1,
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
        payload["COM_ID"] = 2;
        payload["GRP_ID"] = ApiSeedTestContext.GetRequiredCreatedId("GrupoProdutoAbstrato", "GRP_ID");
        payload["OND_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Onda", "OND_ID");
        payload["COM_VINCO1_OND"] = 2;
        payload["COM_VINCO2_OND"] = 2;
        payload["COM_VINCO3_OND"] = 2;
        payload["COM_VINCO4_OND"] = 2;
        payload["COM_VINCO5_OND"] = 2;
        payload["COM_VINCO6_OND"] = 2;
        payload["COM_VINCO7_OND"] = 2;
        payload["COM_VINCO8_OND"] = 2;
        payload["COM_VINCO9_OND"] = 2;
        payload["COM_VINCO10_OND"] = 2;
        payload["COM_VINCO1_CONVERSAO"] = 2;
        payload["COM_VINCO2_CONVERSAO"] = 2;
        payload["COM_VINCO3_CONVERSAO"] = 2;
        payload["COM_VINCO4_CONVERSAO"] = 2;
        payload["COM_VINCO5_CONVERSAO"] = 2;
        payload["COM_VINCO6_CONVERSAO"] = 2;
        payload["COM_VINCO7_CONVERSAO"] = 2;
        payload["COM_VINCO8_CONVERSAO"] = 2;
        payload["COM_VINCO9_CONVERSAO"] = 2;
        payload["COM_VINCO10_CONVERSAO"] = 2;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration