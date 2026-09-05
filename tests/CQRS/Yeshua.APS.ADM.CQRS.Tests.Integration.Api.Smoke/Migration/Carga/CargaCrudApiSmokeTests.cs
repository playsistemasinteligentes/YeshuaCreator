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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.Carga;

[SmokeTestOrder(166)]
public partial class CargaCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Carga/PostCarga";
    private const string ReadEndpoint = "yapi/Carga/ReadCarga";
    private const string UpdateEndpoint = "yapi/Carga/PutCarga";
    private const string DeleteEndpoint = "yapi/Carga/DeleteCarga";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Carga", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Carga", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("Carga", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Carga", out var deletePayload))
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
            ["CAR_ID"] = ApiTestData.Text("Carga CAR_ID", 30),
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
            ["CAR_ID_DOCA"] = ApiTestData.Text("Carga CAR_ID_DOCA", 30),
            ["VEI_PLACA"] = ApiTestData.Text("Carga VEI_PLACA", 8),
            ["TIP_ID"] = 1,
            ["TRA_ID"] = ApiTestData.Text("Carga TRA_ID", 30),
            ["CAR_GRUPO_PRODUTIVO"] = 10.5m,
            ["ROT_ID"] = ApiTestData.Text("Carga ROT_ID", 80),
            ["CAR_OBSERVACAO_DE_TRANSPORTE"] = ApiTestData.Text("Carga CAR_OBSERVACAO_DE_TRANSPORTE", 80),
            ["CAR_JUSTIFICATIVA_DE_CARREGAMENTO"] = ApiTestData.Text("Carga CAR_JUSTIFICATIVA_DE_CARREGAMENTO", 80),
            ["OCO_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Ocorrencia", "OCO_ID"),
            ["CAR_ID_JUNTADA"] = ApiTestData.Text("Carga CAR_ID_JUNTADA", 30),
            ["CAR_OBSERVACAO_OTIMIZADOR"] = ApiTestData.Text("Carga CAR_OBSERVACAO_OTIMIZADOR", 80),
            ["CAR_ID_INTEGRACAO_BALANCA"] = ApiTestData.Text("Carga CAR_ID_INTEGRACAO_BALANCA", 30),
            ["CAR_PESAGEM_LIBERADA"] = ApiTestData.Text("Carga CAR_PESAGEM_LIBERADA", 1),
            ["CAR_OBS_LIERACAO"] = ApiTestData.Text("Carga CAR_OBS_LIERACAO", 80),
            ["OCO_ID_LIERACAO"] = ApiTestData.Text("Carga OCO_ID_LIERACAO", 30),
            ["CAR_DATA_ENTRADA_VEICULO"] = DateTime.UtcNow,
            ["CAR_DATA_SAIDA_VEICULO"] = DateTime.UtcNow,
            ["CAR_DATA_ROMANEIO_CONSOLIDADO"] = DateTime.UtcNow,
            ["CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO"] = ApiTestData.Text("Carga CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO", 8),
            ["CAR_DIFERENCA_PESAGEM"] = 10.5m,
            ["CAR_DATA_AGENCIAMENTO"] = DateTime.UtcNow,
            ["TURN_ID"] = ApiTestData.Text("Carga TURN_ID", 10),
            ["TURM_ID"] = ApiTestData.Text("Carga TURM_ID", 10),
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
        payload["CAR_ID"] = ApiTestData.Text("Carga CAR_ID Update", 30);
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
        payload["CAR_ID_DOCA"] = ApiTestData.Text("Carga CAR_ID_DOCA Update", 30);
        payload["VEI_PLACA"] = ApiTestData.Text("Carga VEI_PLACA Update", 8);
        payload["TIP_ID"] = 2;
        payload["TRA_ID"] = ApiTestData.Text("Carga TRA_ID Update", 30);
        payload["CAR_GRUPO_PRODUTIVO"] = 20.5m;
        payload["ROT_ID"] = ApiTestData.Text("Carga ROT_ID Update", 80);
        payload["CAR_OBSERVACAO_DE_TRANSPORTE"] = ApiTestData.Text("Carga CAR_OBSERVACAO_DE_TRANSPORTE Update", 80);
        payload["CAR_JUSTIFICATIVA_DE_CARREGAMENTO"] = ApiTestData.Text("Carga CAR_JUSTIFICATIVA_DE_CARREGAMENTO Update", 80);
        payload["OCO_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Ocorrencia", "OCO_ID");
        payload["CAR_ID_JUNTADA"] = ApiTestData.Text("Carga CAR_ID_JUNTADA Update", 30);
        payload["CAR_OBSERVACAO_OTIMIZADOR"] = ApiTestData.Text("Carga CAR_OBSERVACAO_OTIMIZADOR Update", 80);
        payload["CAR_ID_INTEGRACAO_BALANCA"] = ApiTestData.Text("Carga CAR_ID_INTEGRACAO_BALANCA Update", 30);
        payload["CAR_PESAGEM_LIBERADA"] = ApiTestData.Text("Carga CAR_PESAGEM_LIBERADA Update", 1);
        payload["CAR_OBS_LIERACAO"] = ApiTestData.Text("Carga CAR_OBS_LIERACAO Update", 80);
        payload["OCO_ID_LIERACAO"] = ApiTestData.Text("Carga OCO_ID_LIERACAO Update", 30);
        payload["CAR_DATA_ENTRADA_VEICULO"] = DateTime.UtcNow.AddMinutes(1);
        payload["CAR_DATA_SAIDA_VEICULO"] = DateTime.UtcNow.AddMinutes(1);
        payload["CAR_DATA_ROMANEIO_CONSOLIDADO"] = DateTime.UtcNow.AddMinutes(1);
        payload["CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO"] = ApiTestData.Text("Carga CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO Update", 8);
        payload["CAR_DIFERENCA_PESAGEM"] = 20.5m;
        payload["CAR_DATA_AGENCIAMENTO"] = DateTime.UtcNow.AddMinutes(1);
        payload["TURN_ID"] = ApiTestData.Text("Carga TURN_ID Update", 10);
        payload["TURM_ID"] = ApiTestData.Text("Carga TURM_ID Update", 10);
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