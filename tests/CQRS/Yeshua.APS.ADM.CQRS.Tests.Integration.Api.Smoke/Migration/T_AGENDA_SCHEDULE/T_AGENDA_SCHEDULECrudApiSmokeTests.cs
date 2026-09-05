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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.T_AGENDA_SCHEDULE;

[SmokeTestOrder(3)]
public partial class T_AGENDA_SCHEDULECrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/T_AGENDA_SCHEDULE/PostT_AGENDA_SCHEDULE";
    private const string ReadEndpoint = "yapi/T_AGENDA_SCHEDULE/ReadT_AGENDA_SCHEDULE";
    private const string UpdateEndpoint = "yapi/T_AGENDA_SCHEDULE/PutT_AGENDA_SCHEDULE";
    private const string DeleteEndpoint = "yapi/T_AGENDA_SCHEDULE/DeleteT_AGENDA_SCHEDULE";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("T_AGENDA_SCHEDULE", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("T_AGENDA_SCHEDULE", initialDeletePayload);

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

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("T_AGENDA_SCHEDULE", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("T_AGENDA_SCHEDULE", out var deletePayload))
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
            ["AGE_ID"] = 1,
            ["AGE_DATA_ESPECIFICA"] = DateTime.UtcNow,
            ["AGE_HORARIO_INICIO"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_HORARIO_INICIO", 16),
            ["AGE_HORARIO_FIM"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_HORARIO_FIM", 16),
            ["AGE_SEGUNDA"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_SEGUNDA", 10),
            ["AGE_TERCA"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_TERCA", 10),
            ["AGE_QUARTA"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_QUARTA", 10),
            ["AGE_QUINTA"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_QUINTA", 10),
            ["AGE_SEXTA"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_SEXTA", 10),
            ["AGE_SABADO"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_SABADO", 10),
            ["AGE_DOMINGO"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_DOMINGO", 10),
            ["AGE_INTERVALO"] = 10.5m,
            ["AGE_ORDEM_EXECUCAO"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_ORDEM_EXECUCAO", 50),
            ["AGE_PARAMETROS"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_PARAMETROS", 80),
            ["AGE_EXCECAO"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_EXCECAO", 10),
            ["AGE_DESCRICAO"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_DESCRICAO", 80),
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
        payload["AGE_ID"] = 2;
        payload["AGE_DATA_ESPECIFICA"] = DateTime.UtcNow.AddMinutes(1);
        payload["AGE_HORARIO_INICIO"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_HORARIO_INICIO Update", 16);
        payload["AGE_HORARIO_FIM"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_HORARIO_FIM Update", 16);
        payload["AGE_SEGUNDA"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_SEGUNDA Update", 10);
        payload["AGE_TERCA"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_TERCA Update", 10);
        payload["AGE_QUARTA"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_QUARTA Update", 10);
        payload["AGE_QUINTA"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_QUINTA Update", 10);
        payload["AGE_SEXTA"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_SEXTA Update", 10);
        payload["AGE_SABADO"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_SABADO Update", 10);
        payload["AGE_DOMINGO"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_DOMINGO Update", 10);
        payload["AGE_INTERVALO"] = 20.5m;
        payload["AGE_ORDEM_EXECUCAO"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_ORDEM_EXECUCAO Update", 50);
        payload["AGE_PARAMETROS"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_PARAMETROS Update", 80);
        payload["AGE_EXCECAO"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_EXCECAO Update", 10);
        payload["AGE_DESCRICAO"] = ApiTestData.Text("T_AGENDA_SCHEDULE AGE_DESCRICAO Update", 80);
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