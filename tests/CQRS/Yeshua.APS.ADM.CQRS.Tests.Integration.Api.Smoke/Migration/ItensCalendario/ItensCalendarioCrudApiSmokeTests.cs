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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.ItensCalendario;

[SmokeTestOrder(149)]
public partial class ItensCalendarioCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/ItensCalendario/PostItensCalendario";
    private const string ReadEndpoint = "yapi/ItensCalendario/ReadItensCalendario";
    private const string UpdateEndpoint = "yapi/ItensCalendario/PutItensCalendario";
    private const string DeleteEndpoint = "yapi/ItensCalendario/DeleteItensCalendario";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "ica_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("ItensCalendario", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("ItensCalendario", initialDeletePayload);

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

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("ItensCalendario", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("ItensCalendario", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "ica_id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "ICA_ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["ICA_DATA_DE"] = DateTime.UtcNow,
            ["ICA_DATA_ATE"] = DateTime.UtcNow,
            ["ICA_OBSERVACAO"] = ApiTestData.Text("ItensCalendario ICA_OBSERVACAO", 80),
            ["ICA_TIPO"] = 1,
            ["URM_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Turma", "URM_ID"),
            ["URN_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Turno", "URN_ID"),
            ["CAL_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Calendario", "CAL_ID"),
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
        payload["URM_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Turma", "URM_ID");
        payload["URN_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Turno", "URN_ID");
        payload["CAL_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Calendario", "CAL_ID");
        payload["MAQ_ID"] = ApiTestData.Text("ItensCalendario MAQ_ID Update", 30);
        payload["PRO_ID"] = ApiTestData.Text("ItensCalendario PRO_ID Update", 30);
        payload["ICA_LIMPESA_MAQUINA"] = 2;
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["ICA_ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration