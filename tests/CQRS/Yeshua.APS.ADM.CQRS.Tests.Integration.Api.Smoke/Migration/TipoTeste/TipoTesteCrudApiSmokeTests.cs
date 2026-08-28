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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.TipoTeste;

[SmokeTestOrder(160)]
public partial class TipoTesteCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/TipoTeste/PostTipoTeste";
    private const string ReadEndpoint = "yapi/TipoTeste/ReadTipoTeste";
    private const string UpdateEndpoint = "yapi/TipoTeste/PutTipoTeste";
    private const string DeleteEndpoint = "yapi/TipoTeste/DeleteTipoTeste";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "tt_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("TipoTeste", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("TipoTeste", initialDeletePayload);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "tt_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("TipoTeste", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("TipoTeste", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "tt_id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "TT_ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["TT_ESPECIFICACAO"] = 10.5m,
            ["TT_ORIGEM_ESPECIFICACAO"] = ApiTestData.Text("TipoTeste TT_ORIGEM_ESPECIFICACAO", 80),
            ["TT_IMPRIME_NO_LAUDO"] = ApiTestData.Text("TipoTeste TT_IMPRIME_NO_LAUDO", 1),
            ["TT_NOME"] = ApiTestData.Text("TipoTeste TT_NOME", 50),
            ["TT_DESC"] = ApiTestData.Text("TipoTeste TT_DESC", 80),
            ["TT_TOL_MAIS"] = 10.5m,
            ["TT_TOL_MENOS"] = 10.5m,
            ["TT_NORMA"] = ApiTestData.Text("TipoTeste TT_NORMA", 50),
            ["TT_INICIO_PROCESSO"] = ApiTestData.Text("TipoTeste TT_INICIO_PROCESSO", 1),
            ["TA_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("TipoAvaliacao", "TA_ID"),
            ["UNI_ID"] = ApiTestData.Text("TipoTeste UNI_ID", 30),
            ["TT_N_AMOSTRAS_P_TESTE"] = 1,
            ["TT_MAX_DEF_CRITICO"] = 1,
            ["TT_MAX_DEF_GRAVE"] = 1,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["TT_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["TT_ID"] = id.DeepClone();
        payload["TT_ESPECIFICACAO"] = 20.5m;
        payload["TT_ORIGEM_ESPECIFICACAO"] = ApiTestData.Text("TipoTeste TT_ORIGEM_ESPECIFICACAO Update", 80);
        payload["TT_IMPRIME_NO_LAUDO"] = ApiTestData.Text("TipoTeste TT_IMPRIME_NO_LAUDO Update", 1);
        payload["TT_NOME"] = ApiTestData.Text("TipoTeste TT_NOME Update", 50);
        payload["TT_DESC"] = ApiTestData.Text("TipoTeste TT_DESC Update", 80);
        payload["TT_TOL_MAIS"] = 20.5m;
        payload["TT_TOL_MENOS"] = 20.5m;
        payload["TT_NORMA"] = ApiTestData.Text("TipoTeste TT_NORMA Update", 50);
        payload["TT_INICIO_PROCESSO"] = ApiTestData.Text("TipoTeste TT_INICIO_PROCESSO Update", 1);
        payload["TA_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("TipoAvaliacao", "TA_ID");
        payload["UNI_ID"] = ApiTestData.Text("TipoTeste UNI_ID Update", 30);
        payload["TT_N_AMOSTRAS_P_TESTE"] = 2;
        payload["TT_MAX_DEF_CRITICO"] = 2;
        payload["TT_MAX_DEF_GRAVE"] = 2;
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["TT_ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration