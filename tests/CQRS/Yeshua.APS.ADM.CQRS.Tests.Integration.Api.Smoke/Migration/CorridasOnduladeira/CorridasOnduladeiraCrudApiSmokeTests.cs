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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.CorridasOnduladeira;

[SmokeTestOrder(18)]
public partial class CorridasOnduladeiraCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/CorridasOnduladeira/PostCorridasOnduladeira";
    private const string ReadEndpoint = "yapi/CorridasOnduladeira/ReadCorridasOnduladeira";
    private const string UpdateEndpoint = "yapi/CorridasOnduladeira/PutCorridasOnduladeira";
    private const string DeleteEndpoint = "yapi/CorridasOnduladeira/DeleteCorridasOnduladeira";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "cor_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("CorridasOnduladeira", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("CorridasOnduladeira", initialDeletePayload);

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        var readAssertionHandled = false;
        CustomizeReadAssertion(readState, createdId, ref readAssertionHandled);
        if (!readAssertionHandled)
            ApiResponseAssertions.AssertReadContainsId(readState, createdId, "cor_id");

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "cor_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("CorridasOnduladeira", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("CorridasOnduladeira", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "cor_id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "COR_ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["BOL_ID"] = ApiTestData.Text("CorridasOnduladeira BOL_ID", 30),
            ["BOL_ID_ORIGEM"] = ApiTestData.Text("CorridasOnduladeira BOL_ID_ORIGEM", 30),
            ["PRO_LARGURA_PECA"] = 10.5m,
            ["PRO_LARGURA_PECA_PROGRAMADO"] = 10.5m,
            ["PRO_COMPRIMENTO_PECA"] = 10.5m,
            ["PRO_COMPRIMENTO_PECA_PROGRAMADO"] = 10.5m,
            ["PRO_UTILIZOU_REFILE_OBRIGATORIO"] = 10.5m,
            ["PRO_VINCOS_RECALCULADOS"] = ApiTestData.Text("CorridasOnduladeira PRO_VINCOS_RECALCULADOS", 80),
            ["COR_SOLVER"] = ApiTestData.Text("CorridasOnduladeira COR_SOLVER", 30),
            ["COR_GRAMATURA_PAPEIS_PROGRAMADOS"] = 10.5m,
            ["COR_CUSTO_PAPEIS_PROGRAMADOS"] = 10.5m,
            ["COR_GRAMATURA_RESINA_PROGRAMADOS"] = 10.5m,
            ["COR_CUSTO_RESINA_PROGRAMADOS"] = 10.5m,
            ["COR_TOLERANCIA_MENOS"] = 10.5m,
            ["COR_TOLERANCIA_MAIS"] = 10.5m,
            ["COR_PILHAS_POR_PALETE"] = 1,
            ["COR_COR_FILA"] = ApiTestData.Text("CorridasOnduladeira COR_COR_FILA", 30),
            ["COR_M_LINEAR_REALIZADO"] = 10.5m,
            ["PRO_ID_PALETE"] = ApiTestData.Text("CorridasOnduladeira PRO_ID_PALETE", 30),
            ["COR_STATUS_PALETE"] = ApiTestData.Text("CorridasOnduladeira COR_STATUS_PALETE", 30),
            ["COR_GRUPO_PRODUTIVO"] = 10.5m,
            ["COR_STATUS"] = ApiTestData.Text("CorridasOnduladeira COR_STATUS", 3),
            ["COR_STATUS_INTERFACE"] = ApiTestData.Text("CorridasOnduladeira COR_STATUS_INTERFACE", 3),
            ["MAQ_ID"] = ApiTestData.Text("CorridasOnduladeira MAQ_ID", 30),
            ["COR_ID_INTERFACE"] = 1,
            ["COR_SEQUENCIA"] = 1,
            ["COR_SEQUENCIA_ORIGEM"] = 1,
            ["ORD_ID"] = ApiTestData.Text("CorridasOnduladeira ORD_ID", 60),
            ["FPR_SEQ_REPETICAO"] = 1,
            ["ROT_SEQ_TRANFORMACAO"] = 1,
            ["COR_FACAO"] = 1,
            ["COR_FORMATO_BOBINA"] = 1,
            ["COR_INICIO_PREVISTO"] = DateTime.UtcNow,
            ["COR_FIM_PREVISTO"] = DateTime.UtcNow,
            ["PRO_ID"] = ApiTestData.Text("CorridasOnduladeira PRO_ID", 30),
            ["COR_QTD_PLANEJADO"] = 1,
            ["PRO_QTD_PACAS"] = 1,
            ["COR_PECAS_LARGURA"] = 1,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["COR_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["COR_ID"] = id.DeepClone();
        payload["BOL_ID"] = ApiTestData.Text("CorridasOnduladeira BOL_ID Update", 30);
        payload["BOL_ID_ORIGEM"] = ApiTestData.Text("CorridasOnduladeira BOL_ID_ORIGEM Update", 30);
        payload["PRO_LARGURA_PECA"] = 20.5m;
        payload["PRO_LARGURA_PECA_PROGRAMADO"] = 20.5m;
        payload["PRO_COMPRIMENTO_PECA"] = 20.5m;
        payload["PRO_COMPRIMENTO_PECA_PROGRAMADO"] = 20.5m;
        payload["PRO_UTILIZOU_REFILE_OBRIGATORIO"] = 20.5m;
        payload["PRO_VINCOS_RECALCULADOS"] = ApiTestData.Text("CorridasOnduladeira PRO_VINCOS_RECALCULADOS Update", 80);
        payload["COR_SOLVER"] = ApiTestData.Text("CorridasOnduladeira COR_SOLVER Update", 30);
        payload["COR_GRAMATURA_PAPEIS_PROGRAMADOS"] = 20.5m;
        payload["COR_CUSTO_PAPEIS_PROGRAMADOS"] = 20.5m;
        payload["COR_GRAMATURA_RESINA_PROGRAMADOS"] = 20.5m;
        payload["COR_CUSTO_RESINA_PROGRAMADOS"] = 20.5m;
        payload["COR_TOLERANCIA_MENOS"] = 20.5m;
        payload["COR_TOLERANCIA_MAIS"] = 20.5m;
        payload["COR_PILHAS_POR_PALETE"] = 2;
        payload["COR_COR_FILA"] = ApiTestData.Text("CorridasOnduladeira COR_COR_FILA Update", 30);
        payload["COR_M_LINEAR_REALIZADO"] = 20.5m;
        payload["PRO_ID_PALETE"] = ApiTestData.Text("CorridasOnduladeira PRO_ID_PALETE Update", 30);
        payload["COR_STATUS_PALETE"] = ApiTestData.Text("CorridasOnduladeira COR_STATUS_PALETE Update", 30);
        payload["COR_GRUPO_PRODUTIVO"] = 20.5m;
        payload["COR_STATUS"] = ApiTestData.Text("CorridasOnduladeira COR_STATUS Update", 3);
        payload["COR_STATUS_INTERFACE"] = ApiTestData.Text("CorridasOnduladeira COR_STATUS_INTERFACE Update", 3);
        payload["MAQ_ID"] = ApiTestData.Text("CorridasOnduladeira MAQ_ID Update", 30);
        payload["COR_ID_INTERFACE"] = 2;
        payload["COR_SEQUENCIA"] = 2;
        payload["COR_SEQUENCIA_ORIGEM"] = 2;
        payload["ORD_ID"] = ApiTestData.Text("CorridasOnduladeira ORD_ID Update", 60);
        payload["FPR_SEQ_REPETICAO"] = 2;
        payload["ROT_SEQ_TRANFORMACAO"] = 2;
        payload["COR_FACAO"] = 2;
        payload["COR_FORMATO_BOBINA"] = 2;
        payload["COR_INICIO_PREVISTO"] = DateTime.UtcNow.AddMinutes(1);
        payload["COR_FIM_PREVISTO"] = DateTime.UtcNow.AddMinutes(1);
        payload["PRO_ID"] = ApiTestData.Text("CorridasOnduladeira PRO_ID Update", 30);
        payload["COR_QTD_PLANEJADO"] = 2;
        payload["PRO_QTD_PACAS"] = 2;
        payload["COR_PECAS_LARGURA"] = 2;
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["COR_ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration