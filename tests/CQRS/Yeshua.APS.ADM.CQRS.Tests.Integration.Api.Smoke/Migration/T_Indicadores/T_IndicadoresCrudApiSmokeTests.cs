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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.T_Indicadores;

[SmokeTestOrder(144)]
public partial class T_IndicadoresCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/T_Indicadores/PostT_Indicadores";
    private const string ReadEndpoint = "yapi/T_Indicadores/ReadT_Indicadores";
    private const string UpdateEndpoint = "yapi/T_Indicadores/PutT_Indicadores";
    private const string DeleteEndpoint = "yapi/T_Indicadores/DeleteT_Indicadores";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "ind_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("T_Indicadores", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("T_Indicadores", initialDeletePayload);

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        var readAssertionHandled = false;
        CustomizeReadAssertion(readState, createdId, ref readAssertionHandled);
        if (!readAssertionHandled)
            ApiResponseAssertions.AssertReadContainsId(readState, createdId, "ind_id");

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "ind_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("T_Indicadores", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("T_Indicadores", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "ind_id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "IND_ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["IND_DESCRICAO"] = ApiTestData.Text("T_Indicadores IND_DESCRICAO", 80),
            ["NEG_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("T_Negocio", "NEG_ID"),
            ["DESC_CALCULO"] = ApiTestData.Text("T_Indicadores DESC_CALCULO", 80),
            ["IND_TIPOCOMPARADOR"] = 1,
            ["IND_GRAFICO"] = 1,
            ["IND_CONEXAO"] = ApiTestData.Text("T_Indicadores IND_CONEXAO", 80),
            ["IND_DTCRIACAO"] = DateTime.UtcNow,
            ["RESPOSAVELIND"] = ApiTestData.Text("T_Indicadores RESPOSAVELIND", 80),
            ["RESPOSAVELCARGA"] = ApiTestData.Text("T_Indicadores RESPOSAVELCARGA", 80),
            ["PROCEXTRACAO"] = ApiTestData.Text("T_Indicadores PROCEXTRACAO", 80),
            ["PER_ID"] = ApiTestData.Text("T_Indicadores PER_ID", 3),
            ["DIM_ID"] = ApiTestData.Text("T_Indicadores DIM_ID", 80),
            ["DOM_EMPRESA"] = ApiTestData.Text("T_Indicadores DOM_EMPRESA", 30),
            ["DOM_FILIAL"] = ApiTestData.Text("T_Indicadores DOM_FILIAL", 30),
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["IND_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["IND_ID"] = id.DeepClone();
        payload["IND_DESCRICAO"] = ApiTestData.Text("T_Indicadores IND_DESCRICAO Update", 80);
        payload["NEG_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("T_Negocio", "NEG_ID");
        payload["DESC_CALCULO"] = ApiTestData.Text("T_Indicadores DESC_CALCULO Update", 80);
        payload["IND_TIPOCOMPARADOR"] = 2;
        payload["IND_GRAFICO"] = 2;
        payload["IND_CONEXAO"] = ApiTestData.Text("T_Indicadores IND_CONEXAO Update", 80);
        payload["IND_DTCRIACAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["RESPOSAVELIND"] = ApiTestData.Text("T_Indicadores RESPOSAVELIND Update", 80);
        payload["RESPOSAVELCARGA"] = ApiTestData.Text("T_Indicadores RESPOSAVELCARGA Update", 80);
        payload["PROCEXTRACAO"] = ApiTestData.Text("T_Indicadores PROCEXTRACAO Update", 80);
        payload["PER_ID"] = ApiTestData.Text("T_Indicadores PER_ID Update", 3);
        payload["DIM_ID"] = ApiTestData.Text("T_Indicadores DIM_ID Update", 80);
        payload["DOM_EMPRESA"] = ApiTestData.Text("T_Indicadores DOM_EMPRESA Update", 30);
        payload["DOM_FILIAL"] = ApiTestData.Text("T_Indicadores DOM_FILIAL Update", 30);
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["IND_ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration