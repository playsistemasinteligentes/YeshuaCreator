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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.ClpMedicoes;

[SmokeTestOrder(10)]
public partial class ClpMedicoesCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/ClpMedicoes/PostClpMedicoes";
    private const string ReadEndpoint = "yapi/ClpMedicoes/ReadClpMedicoes";
    private const string UpdateEndpoint = "yapi/ClpMedicoes/PutClpMedicoes";
    private const string DeleteEndpoint = "yapi/ClpMedicoes/DeleteClpMedicoes";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("ClpMedicoes", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("ClpMedicoes", initialDeletePayload);

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

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("ClpMedicoes", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("ClpMedicoes", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "Id");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["Id2"] = 1,
            ["MaquinaId"] = ApiTestData.Text("ClpMedicoes MaquinaId", 30),
            ["DataInicio"] = DateTime.UtcNow,
            ["DataFim"] = DateTime.UtcNow,
            ["Emissao"] = DateTime.UtcNow,
            ["Quantidade"] = 10.5m,
            ["Grupo"] = 10.5m,
            ["Status"] = 1,
            ["TurnoId"] = ApiTestData.Text("ClpMedicoes TurnoId", 1),
            ["TurmaId"] = ApiTestData.Text("ClpMedicoes TurmaId", 1),
            ["IdLoteClp"] = 1,
            ["OcorrenciaId"] = ApiTestData.Text("ClpMedicoes OcorrenciaId", 30),
            ["Fase"] = 1,
            ["ClpOrigem"] = ApiTestData.Text("ClpMedicoes ClpOrigem", 1),
            ["CLP_LOTE"] = 1,
            ["COMPACTA"] = 1,
            ["BOL_ID"] = ApiTestData.Text("ClpMedicoes BOL_ID", 30),
            ["COR_SEQUENCIA"] = 1,
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
        payload["Id2"] = 2;
        payload["MaquinaId"] = ApiTestData.Text("ClpMedicoes MaquinaId Update", 30);
        payload["DataInicio"] = DateTime.UtcNow.AddMinutes(1);
        payload["DataFim"] = DateTime.UtcNow.AddMinutes(1);
        payload["Emissao"] = DateTime.UtcNow.AddMinutes(1);
        payload["Quantidade"] = 20.5m;
        payload["Grupo"] = 20.5m;
        payload["Status"] = 2;
        payload["TurnoId"] = ApiTestData.Text("ClpMedicoes TurnoId Update", 1);
        payload["TurmaId"] = ApiTestData.Text("ClpMedicoes TurmaId Update", 1);
        payload["IdLoteClp"] = 2;
        payload["OcorrenciaId"] = ApiTestData.Text("ClpMedicoes OcorrenciaId Update", 30);
        payload["Fase"] = 2;
        payload["ClpOrigem"] = ApiTestData.Text("ClpMedicoes ClpOrigem Update", 1);
        payload["CLP_LOTE"] = 2;
        payload["COMPACTA"] = 2;
        payload["BOL_ID"] = ApiTestData.Text("ClpMedicoes BOL_ID Update", 30);
        payload["COR_SEQUENCIA"] = 2;
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
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration