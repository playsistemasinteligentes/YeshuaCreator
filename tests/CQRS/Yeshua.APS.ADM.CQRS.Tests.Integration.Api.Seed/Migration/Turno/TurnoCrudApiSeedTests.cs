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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Turno;

[SeedTestOrder(101)]
public partial class TurnoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Turno/PostTurno";
    private const string ReadEndpoint = "yapi/Turno/ReadTurno";
    private const string UpdateEndpoint = "yapi/Turno/PutTurno";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Turno", createdId);

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
            ["Id"] = ApiTestData.Text("Turno Id", 10),
            ["Descricao"] = ApiTestData.Text("Turno Descricao", 80),
            ["TURN_PRIORIDADE"] = 1,
            ["TURN_HORA_INI_DIA1"] = DateTime.UtcNow,
            ["TURN_HORA_FIM_DIA1"] = DateTime.UtcNow,
            ["TURN_HORA_INI_DIA2"] = DateTime.UtcNow,
            ["TURN_HORA_FIM_DIA2"] = DateTime.UtcNow,
            ["TURN_HORA_INI_DIA3"] = DateTime.UtcNow,
            ["TURN_HORA_FIM_DIA3"] = DateTime.UtcNow,
            ["TURN_HORA_INI_DIA4"] = DateTime.UtcNow,
            ["TURN_HORA_FIM_DIA4"] = DateTime.UtcNow,
            ["TURN_HORA_INI_DIA5"] = DateTime.UtcNow,
            ["TURN_HORA_FIM_DIA5"] = DateTime.UtcNow,
            ["TURN_HORA_INI_DIA6"] = DateTime.UtcNow,
            ["TURN_HORA_FIM_DIA6"] = DateTime.UtcNow,
            ["TURN_HORA_INI_DIA7"] = DateTime.UtcNow,
            ["TURN_HORA_FIM_DIA7"] = DateTime.UtcNow,
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
        payload["Descricao"] = ApiTestData.Text("Turno Descricao Update", 80);
        payload["TURN_PRIORIDADE"] = 2;
        payload["TURN_HORA_INI_DIA1"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_HORA_FIM_DIA1"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_HORA_INI_DIA2"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_HORA_FIM_DIA2"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_HORA_INI_DIA3"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_HORA_FIM_DIA3"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_HORA_INI_DIA4"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_HORA_FIM_DIA4"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_HORA_INI_DIA5"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_HORA_FIM_DIA5"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_HORA_INI_DIA6"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_HORA_FIM_DIA6"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_HORA_INI_DIA7"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_HORA_FIM_DIA7"] = DateTime.UtcNow.AddMinutes(1);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration