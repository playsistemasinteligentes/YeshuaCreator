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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.Cliente;

[SmokeTestOrder(140)]
public partial class ClienteCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Cliente/PostCliente";
    private const string ReadEndpoint = "yapi/Cliente/ReadCliente";
    private const string UpdateEndpoint = "yapi/Cliente/PutCliente";
    private const string DeleteEndpoint = "yapi/Cliente/DeleteCliente";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "cli_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Cliente", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Cliente", initialDeletePayload);

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        var readAssertionHandled = false;
        CustomizeReadAssertion(readState, createdId, ref readAssertionHandled);
        if (!readAssertionHandled)
            ApiResponseAssertions.AssertReadContainsId(readState, createdId, "cli_id");

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "cli_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Cliente", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Cliente", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "cli_id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "CLI_ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["CLI_ID"] = ApiTestData.KeyText(12),
            ["CLI_NOME"] = ApiTestData.Text("Cliente CLI_NOME", 80),
            ["CLI_FONE"] = ApiTestData.Text("Cliente CLI_FONE", 68),
            ["CLI_OBS"] = ApiTestData.Text("Cliente CLI_OBS", 80),
            ["CLI_ENDERECO_ENTREGA"] = ApiTestData.Text("Cliente CLI_ENDERECO_ENTREGA", 80),
            ["CLI_CPF_CNPJ"] = ApiTestData.Text("Cliente CLI_CPF_CNPJ", 18),
            ["CLI_BAIRRO_ENTREGA"] = ApiTestData.Text("Cliente CLI_BAIRRO_ENTREGA", 80),
            ["CLI_CEP_ENTREGA"] = ApiTestData.Text("Cliente CLI_CEP_ENTREGA", 10),
            ["CLI_EMAIL"] = ApiTestData.Text("Cliente CLI_EMAIL", 80),
            ["CLI_INTEGRACAO"] = ApiTestData.Text("Cliente CLI_INTEGRACAO", 80),
            ["MUN_ID_ENTREGA"] = ApiSmokeTestContext.GetRequiredCreatedId("Municipio", "MUN_ID_ENTREGA"),
            ["CLI_TRANSLADO"] = 10.5m,
            ["CLI_REGIAO_ENTREGA"] = ApiTestData.Text("Cliente CLI_REGIAO_ENTREGA", 80),
            ["CLI_EXIGENTE_NA_IMPRESSAO"] = 1,
            ["CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO"] = 10.5m,
            ["CLI_TEMPO_DESCARREGAMENTO_UNITARIO"] = 10.5m,
            ["CLI_PERCENTUAL_JANELA_EMBARQUE"] = 10.5m,
            ["REP_ID"] = ApiTestData.Text("Cliente REP_ID", 30),
            ["CLI_RAZAO_SOCIAL"] = ApiTestData.Text("Cliente CLI_RAZAO_SOCIAL", 80),
            ["CLI_EMAIL_MONITORAMENTO_TRANSPORTE"] = ApiTestData.Text("Cliente CLI_EMAIL_MONITORAMENTO_TRANSPORTE", 80),
            ["CLI_CONTATO"] = ApiTestData.Text("Cliente CLI_CONTATO", 80),
            ["CLI_SETOR"] = ApiTestData.Text("Cliente CLI_SETOR", 80),
            ["SEG_ID"] = ApiTestData.Text("Cliente SEG_ID", 30),
            ["CLI_TIPO"] = ApiTestData.Text("Cliente CLI_TIPO", 1),
            ["CLI_INTEGRACAO_ERP"] = ApiTestData.Text("Cliente CLI_INTEGRACAO_ERP", 30),
            ["CLI_LATITUDE_ENTREGA"] = 10.5m,
            ["CLI_LONGITUDE_ENTREGA"] = 10.5m,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["CLI_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["CLI_ID"] = id.DeepClone();
        payload["CLI_NOME"] = ApiTestData.Text("Cliente CLI_NOME Update", 80);
        payload["CLI_FONE"] = ApiTestData.Text("Cliente CLI_FONE Update", 68);
        payload["CLI_OBS"] = ApiTestData.Text("Cliente CLI_OBS Update", 80);
        payload["CLI_ENDERECO_ENTREGA"] = ApiTestData.Text("Cliente CLI_ENDERECO_ENTREGA Update", 80);
        payload["CLI_CPF_CNPJ"] = ApiTestData.Text("Cliente CLI_CPF_CNPJ Update", 18);
        payload["CLI_BAIRRO_ENTREGA"] = ApiTestData.Text("Cliente CLI_BAIRRO_ENTREGA Update", 80);
        payload["CLI_CEP_ENTREGA"] = ApiTestData.Text("Cliente CLI_CEP_ENTREGA Update", 10);
        payload["CLI_EMAIL"] = ApiTestData.Text("Cliente CLI_EMAIL Update", 80);
        payload["CLI_INTEGRACAO"] = ApiTestData.Text("Cliente CLI_INTEGRACAO Update", 80);
        payload["MUN_ID_ENTREGA"] = ApiSmokeTestContext.GetRequiredCreatedId("Municipio", "MUN_ID_ENTREGA");
        payload["CLI_TRANSLADO"] = 20.5m;
        payload["CLI_REGIAO_ENTREGA"] = ApiTestData.Text("Cliente CLI_REGIAO_ENTREGA Update", 80);
        payload["CLI_EXIGENTE_NA_IMPRESSAO"] = 2;
        payload["CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO"] = 20.5m;
        payload["CLI_TEMPO_DESCARREGAMENTO_UNITARIO"] = 20.5m;
        payload["CLI_PERCENTUAL_JANELA_EMBARQUE"] = 20.5m;
        payload["REP_ID"] = ApiTestData.Text("Cliente REP_ID Update", 30);
        payload["CLI_RAZAO_SOCIAL"] = ApiTestData.Text("Cliente CLI_RAZAO_SOCIAL Update", 80);
        payload["CLI_EMAIL_MONITORAMENTO_TRANSPORTE"] = ApiTestData.Text("Cliente CLI_EMAIL_MONITORAMENTO_TRANSPORTE Update", 80);
        payload["CLI_CONTATO"] = ApiTestData.Text("Cliente CLI_CONTATO Update", 80);
        payload["CLI_SETOR"] = ApiTestData.Text("Cliente CLI_SETOR Update", 80);
        payload["SEG_ID"] = ApiTestData.Text("Cliente SEG_ID Update", 30);
        payload["CLI_TIPO"] = ApiTestData.Text("Cliente CLI_TIPO Update", 1);
        payload["CLI_INTEGRACAO_ERP"] = ApiTestData.Text("Cliente CLI_INTEGRACAO_ERP Update", 30);
        payload["CLI_LATITUDE_ENTREGA"] = 20.5m;
        payload["CLI_LONGITUDE_ENTREGA"] = 20.5m;
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["CLI_ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration