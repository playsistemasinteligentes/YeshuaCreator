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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.CargaPrevista;

[SmokeTestOrder(8)]
public partial class CargaPrevistaCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/CargaPrevista/PostCargaPrevista";
    private const string ReadEndpoint = "yapi/CargaPrevista/ReadCargaPrevista";
    private const string UpdateEndpoint = "yapi/CargaPrevista/PutCargaPrevista";
    private const string DeleteEndpoint = "yapi/CargaPrevista/DeleteCargaPrevista";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("CargaPrevista", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("CargaPrevista", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("CargaPrevista", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("CargaPrevista", out var deletePayload))
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
            ["CAR_ID"] = ApiTestData.Text("CargaPrevista CAR_ID", 30),
            ["ORD_ID"] = ApiTestData.Text("CargaPrevista ORD_ID", 60),
            ["ITC_QTD_PLANEJADA"] = 10.5m,
            ["CAR_PREVISAO_MATERIA_PRIMA"] = DateTime.UtcNow,
            ["CAR_DATA_INICIO_PREVISTO"] = DateTime.UtcNow,
            ["CAR_DATA_INICIO_REALIZADO"] = DateTime.UtcNow,
            ["CAR_DATA_FIM_PREVISTO"] = DateTime.UtcNow,
            ["CAR_DATA_FIM_REALIZADO"] = DateTime.UtcNow,
            ["CAR_INICIO_JANELA_EMBARQUE"] = DateTime.UtcNow,
            ["CAR_FIM_JANELA_EMBARQUE"] = DateTime.UtcNow,
            ["CAR_EMBARQUE_ALVO"] = DateTime.UtcNow,
            ["CAR_STATUS"] = 10.5m,
            ["CAR_PESO_TEORICO"] = 10.5m,
            ["CAR_VOLUME_TEORICO"] = 10.5m,
            ["CAR_PESO_REAL"] = 10.5m,
            ["CAR_VOLUME_REAL"] = 10.5m,
            ["CAR_PESO_EMBALAGEM"] = 10.5m,
            ["CAR_PESO_ENTRADA"] = 10.5m,
            ["CAR_PESO_SAIDA"] = 10.5m,
            ["CAR_ID_DOCA"] = ApiTestData.Text("CargaPrevista CAR_ID_DOCA", 30),
            ["VEI_PLACA"] = ApiTestData.Text("CargaPrevista VEI_PLACA", 8),
            ["TIP_ID"] = 1,
            ["TRA_ID"] = ApiTestData.Text("CargaPrevista TRA_ID", 30),
            ["CAR_GRUPO_PRODUTIVO"] = 10.5m,
            ["ROT_ID"] = ApiTestData.Text("CargaPrevista ROT_ID", 80),
            ["CAR_OBSERVACAO_DE_TRANSPORTE"] = ApiTestData.Text("CargaPrevista CAR_OBSERVACAO_DE_TRANSPORTE", 80),
            ["CAR_JUSTIFICATIVA_DE_CARREGAMENTO"] = ApiTestData.Text("CargaPrevista CAR_JUSTIFICATIVA_DE_CARREGAMENTO", 80),
            ["OCO_ID"] = ApiTestData.Text("CargaPrevista OCO_ID", 30),
            ["CAR_ID_JUNTADA"] = ApiTestData.Text("CargaPrevista CAR_ID_JUNTADA", 30),
            ["CAR_OBSERVACAO_OTIMIZADOR"] = ApiTestData.Text("CargaPrevista CAR_OBSERVACAO_OTIMIZADOR", 80),
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
        payload["CAR_ID"] = ApiTestData.Text("CargaPrevista CAR_ID Update", 30);
        payload["ORD_ID"] = ApiTestData.Text("CargaPrevista ORD_ID Update", 60);
        payload["ITC_QTD_PLANEJADA"] = 20.5m;
        payload["CAR_PREVISAO_MATERIA_PRIMA"] = DateTime.UtcNow.AddMinutes(1);
        payload["CAR_DATA_INICIO_PREVISTO"] = DateTime.UtcNow.AddMinutes(1);
        payload["CAR_DATA_INICIO_REALIZADO"] = DateTime.UtcNow.AddMinutes(1);
        payload["CAR_DATA_FIM_PREVISTO"] = DateTime.UtcNow.AddMinutes(1);
        payload["CAR_DATA_FIM_REALIZADO"] = DateTime.UtcNow.AddMinutes(1);
        payload["CAR_INICIO_JANELA_EMBARQUE"] = DateTime.UtcNow.AddMinutes(1);
        payload["CAR_FIM_JANELA_EMBARQUE"] = DateTime.UtcNow.AddMinutes(1);
        payload["CAR_EMBARQUE_ALVO"] = DateTime.UtcNow.AddMinutes(1);
        payload["CAR_STATUS"] = 20.5m;
        payload["CAR_PESO_TEORICO"] = 20.5m;
        payload["CAR_VOLUME_TEORICO"] = 20.5m;
        payload["CAR_PESO_REAL"] = 20.5m;
        payload["CAR_VOLUME_REAL"] = 20.5m;
        payload["CAR_PESO_EMBALAGEM"] = 20.5m;
        payload["CAR_PESO_ENTRADA"] = 20.5m;
        payload["CAR_PESO_SAIDA"] = 20.5m;
        payload["CAR_ID_DOCA"] = ApiTestData.Text("CargaPrevista CAR_ID_DOCA Update", 30);
        payload["VEI_PLACA"] = ApiTestData.Text("CargaPrevista VEI_PLACA Update", 8);
        payload["TIP_ID"] = 2;
        payload["TRA_ID"] = ApiTestData.Text("CargaPrevista TRA_ID Update", 30);
        payload["CAR_GRUPO_PRODUTIVO"] = 20.5m;
        payload["ROT_ID"] = ApiTestData.Text("CargaPrevista ROT_ID Update", 80);
        payload["CAR_OBSERVACAO_DE_TRANSPORTE"] = ApiTestData.Text("CargaPrevista CAR_OBSERVACAO_DE_TRANSPORTE Update", 80);
        payload["CAR_JUSTIFICATIVA_DE_CARREGAMENTO"] = ApiTestData.Text("CargaPrevista CAR_JUSTIFICATIVA_DE_CARREGAMENTO Update", 80);
        payload["OCO_ID"] = ApiTestData.Text("CargaPrevista OCO_ID Update", 30);
        payload["CAR_ID_JUNTADA"] = ApiTestData.Text("CargaPrevista CAR_ID_JUNTADA Update", 30);
        payload["CAR_OBSERVACAO_OTIMIZADOR"] = ApiTestData.Text("CargaPrevista CAR_OBSERVACAO_OTIMIZADOR Update", 80);
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