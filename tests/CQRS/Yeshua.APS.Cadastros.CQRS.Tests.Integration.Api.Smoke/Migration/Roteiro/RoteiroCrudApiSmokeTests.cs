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

namespace Yeshua.APS.Cadastros.CQRS.Tests.Integration.Api.Smoke.Migration.Roteiro;

[SmokeTestOrder(5)]
public partial class RoteiroCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Roteiro/PostRoteiro";
    private const string ReadEndpoint = "yapi/Roteiro/ReadRoteiro";
    private const string UpdateEndpoint = "yapi/Roteiro/PutRoteiro";
    private const string DeleteEndpoint = "yapi/Roteiro/DeleteRoteiro";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "maq_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Roteiro", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Roteiro", initialDeletePayload);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "maq_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Roteiro", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Roteiro", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "maq_id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "MAQ_ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["MAQ_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Maquina", "MAQ_ID"),
            ["PRO_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Produto", "PRO_ID"),
            ["ROT_SEQ_TRANFORMACAO"] = 1,
            ["GMA_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("GrupoMaquina", "GMA_ID"),
            ["ROT_PECAS_POR_PULSO"] = 10.5m,
            ["ROT_PRIORIDADE_INFORMADA"] = 10.5m,
            ["ROT_ACAO"] = ApiTestData.Text("Roteiro ROT_ACAO", 2),
            ["ROT_PERFORMANCE"] = 10.5m,
            ["ROT_TEMPO_SETUP"] = 10.5m,
            ["ROT_TEMPO_SETUP_AJUSTE"] = 10.5m,
            ["ROT_VA_PARA_SEQ_TRANSFORMACAO"] = 1,
            ["ROT_STATUS"] = ApiTestData.Text("Roteiro ROT_STATUS", 2),
            ["ROT_HIERARQUIA_SEQ_TRANSFORMACAO"] = 10.5m,
            ["ROT_AVALIA_CUSTO"] = 1,
            ["ROT_OPERACOES"] = ApiTestData.Text("Roteiro ROT_OPERACOES", 80),
            ["ROT_EXCECAO_OPERACOES"] = ApiTestData.Text("Roteiro ROT_EXCECAO_OPERACOES", 80),
            ["ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR"] = 10.5m,
            ["ROT_LINHA_DIRETA"] = ApiTestData.Text("Roteiro ROT_LINHA_DIRETA", 2),
            ["TEM_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("TemplateDeTestes", "TEM_ID"),
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["MAQ_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["MAQ_ID"] = id.DeepClone();
        payload["GMA_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("GrupoMaquina", "GMA_ID");
        payload["ROT_PECAS_POR_PULSO"] = 20.5m;
        payload["ROT_PRIORIDADE_INFORMADA"] = 20.5m;
        payload["ROT_ACAO"] = ApiTestData.Text("Roteiro ROT_ACAO Update", 2);
        payload["ROT_PERFORMANCE"] = 20.5m;
        payload["ROT_TEMPO_SETUP"] = 20.5m;
        payload["ROT_TEMPO_SETUP_AJUSTE"] = 20.5m;
        payload["ROT_VA_PARA_SEQ_TRANSFORMACAO"] = 2;
        payload["ROT_STATUS"] = ApiTestData.Text("Roteiro ROT_STATUS Update", 2);
        payload["ROT_HIERARQUIA_SEQ_TRANSFORMACAO"] = 20.5m;
        payload["ROT_AVALIA_CUSTO"] = 2;
        payload["ROT_OPERACOES"] = ApiTestData.Text("Roteiro ROT_OPERACOES Update", 80);
        payload["ROT_EXCECAO_OPERACOES"] = ApiTestData.Text("Roteiro ROT_EXCECAO_OPERACOES Update", 80);
        payload["ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR"] = 20.5m;
        payload["ROT_LINHA_DIRETA"] = ApiTestData.Text("Roteiro ROT_LINHA_DIRETA Update", 2);
        payload["TEM_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("TemplateDeTestes", "TEM_ID");
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["MAQ_ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration