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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.ItensCalendario;

[SeedTestOrder(149)]
public partial class ItensCalendarioCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/ItensCalendario/PostItensCalendario";
    private const string ReadEndpoint = "yapi/ItensCalendario/ReadItensCalendario";
    private const string UpdateEndpoint = "yapi/ItensCalendario/PutItensCalendario";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "ica_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("ItensCalendario", createdId);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "ica_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["ICA_DATA_DE"] = DateTime.UtcNow,
            ["ICA_DATA_ATE"] = DateTime.UtcNow,
            ["ICA_OBSERVACAO"] = ApiTestData.Text("ItensCalendario ICA_OBSERVACAO", 80),
            ["ICA_TIPO"] = 1,
            ["URM_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turma", "URM_ID"),
            ["URN_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turno", "URN_ID"),
            ["CAL_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Calendario", "CAL_ID"),
            ["MAQ_ID"] = ApiTestData.Text("ItensCalendario MAQ_ID", 30),
            ["PRO_ID"] = ApiTestData.Text("ItensCalendario PRO_ID", 30),
            ["ICA_LIMPESA_MAQUINA"] = 1,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["ICA_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["ICA_ID"] = id.DeepClone();
        payload["ICA_DATA_DE"] = DateTime.UtcNow.AddMinutes(1);
        payload["ICA_DATA_ATE"] = DateTime.UtcNow.AddMinutes(1);
        payload["ICA_OBSERVACAO"] = ApiTestData.Text("ItensCalendario ICA_OBSERVACAO Update", 80);
        payload["ICA_TIPO"] = 2;
        payload["URM_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turma", "URM_ID");
        payload["URN_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turno", "URN_ID");
        payload["CAL_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Calendario", "CAL_ID");
        payload["MAQ_ID"] = ApiTestData.Text("ItensCalendario MAQ_ID Update", 30);
        payload["PRO_ID"] = ApiTestData.Text("ItensCalendario PRO_ID Update", 30);
        payload["ICA_LIMPESA_MAQUINA"] = 2;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration