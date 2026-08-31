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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.Maquina;

[SmokeTestOrder(138)]
public partial class MaquinaCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Maquina/PostMaquina";
    private const string ReadEndpoint = "yapi/Maquina/ReadMaquina";
    private const string UpdateEndpoint = "yapi/Maquina/PutMaquina";
    private const string DeleteEndpoint = "yapi/Maquina/DeleteMaquina";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Maquina", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Maquina", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("Maquina", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Maquina", out var deletePayload))
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
            ["Id"] = ApiTestData.Text("Maquina Id", 30),
            ["Descricao"] = ApiTestData.Text("Maquina Descricao", 80),
            ["Status"] = ApiTestData.Text("Maquina Status", 2),
            ["CAL_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Calendario", "CAL_ID"),
            ["MAQ_CONTROL_IP"] = ApiTestData.Text("Maquina MAQ_CONTROL_IP", 30),
            ["GMA_ID"] = ApiTestData.Text("Maquina GMA_ID", 30),
            ["MAQ_ULTIMA_ATUALIZACAO"] = DateTime.UtcNow,
            ["MAQ_SIRENE_SEMAFORO"] = 1,
            ["MAQ_COR_SEMAFORO"] = ApiTestData.Text("Maquina MAQ_COR_SEMAFORO", 30),
            ["MAQ_ID_MAQ_PAI"] = ApiTestData.Text("Maquina MAQ_ID_MAQ_PAI", 30),
            ["MAQ_TIPO_CONTADOR"] = 1,
            ["MAQ_TIPO_PLANEJAMENTO"] = ApiTestData.Text("Maquina MAQ_TIPO_PLANEJAMENTO", 60),
            ["MAQ_AVALIA_CUSTO"] = 1,
            ["FPR_ID_OP_PRODUZINDO"] = 1,
            ["MAQ_CONGELA_FILA"] = 1,
            ["MAQ_TEMPO_MIN_PARADA"] = 1,
            ["MAQ_QTD_CORES"] = 1,
            ["MAQ_ID_INTEGRACAO"] = ApiTestData.Text("Maquina MAQ_ID_INTEGRACAO", 80),
            ["MAQ_ID_INTEGRACAO_ERP"] = ApiTestData.Text("Maquina MAQ_ID_INTEGRACAO_ERP", 80),
            ["MAQ_HIERARQUIA_SEQ_TRANSFORMACAO"] = 10.5m,
            ["EQU_ID"] = ApiTestData.Text("Maquina EQU_ID", 30),
            ["MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR"] = 10.5m,
            ["MAQ_ACOMPANHA_LOTE_PILOTO"] = ApiTestData.Text("Maquina MAQ_ACOMPANHA_LOTE_PILOTO", 60),
            ["MAQ_ID_SENSOR"] = 1,
            ["MAQ_DEBOUNCING_LOW"] = 1,
            ["MAQ_DEBOUNCING_HIGHT"] = 1,
            ["MAQ_TIPO_SINAL"] = 1,
            ["TEM_ID"] = 1,
            ["MAQ_COMPRIMENTO_CHAPA_DE"] = 10.5m,
            ["MAQ_COMPRIMENTO_CHAPA_ATE"] = 10.5m,
            ["MAQ_LARGURA_CHAPA_DE"] = 10.5m,
            ["MAQ_LARGURA_CHAPA_ATE"] = 10.5m,
            ["MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR"] = 10.5m,
            ["MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR"] = 10.5m,
            ["MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR"] = 10.5m,
            ["MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR"] = 10.5m,
            ["MAQ_COMPRIMENTO_ENTRE_VINCO_DE"] = 10.5m,
            ["MAQ_COMPRIMENTO_ENTRE_VINCO_ATE"] = 10.5m,
            ["MAQ_LARGURA_ENTRE_VINCO_DE"] = 10.5m,
            ["MAQ_LARGURA_ENTRE_VINCO_ATE"] = 10.5m,
            ["MAQ_ALTURA_ENTRE_VINCO_DE"] = 10.5m,
            ["MAQ_ALTURA_ENTRE_VINCO_ATE"] = 10.5m,
            ["MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE"] = 10.5m,
            ["MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE"] = 10.5m,
            ["MAQ_ABA_DE"] = 10.5m,
            ["MAQ_ABA_ATE"] = 10.5m,
            ["MAQ_LAP_DE"] = 10.5m,
            ["MAQ_LAP_ATE"] = 10.5m,
            ["MAQ_ONDAS"] = ApiTestData.Text("Maquina MAQ_ONDAS", 30),
            ["MAQ_PROLONGA_LAP"] = ApiTestData.Text("Maquina MAQ_PROLONGA_LAP", 30),
            ["MAQ_LARGURA_IMPRESSAO"] = 10.5m,
            ["MAQ_COMPRIMENTO_IMPRESSAO"] = 10.5m,
            ["MAQ_ROLO_DISPOSITIVO_DE"] = 10.5m,
            ["MAQ_ROLO_DISPOSITIVO_ATE"] = 10.5m,
            ["MAQ_FAMILIAS"] = ApiTestData.Text("Maquina MAQ_FAMILIAS", 80),
            ["MAQ_REFILE_MINIMO"] = 10.5m,
            ["MAQ_LARGURA_UTIL"] = 10.5m,
            ["MAQ_TOTAL_ACO"] = 10.5m,
            ["MAQ_FECHAMENTO"] = ApiTestData.Text("Maquina MAQ_FECHAMENTO", 30),
            ["MAQ_OPERACAO_VINCAR"] = 10.5m,
            ["MAQ_OPERACAO_MONTA_DIVISAO"] = 10.5m,
            ["MAQ_OPERACAO_SERRAR"] = 10.5m,
            ["MAQ_TIPO_LAP"] = ApiTestData.Text("Maquina MAQ_TIPO_LAP", 2),
            ["MAQ_INDICE_PARADAS_POR_OP"] = 10.5m,
            ["MAQ_PERDA_MAXIMA"] = 1,
            ["MAQ_TOTAL_PECAS_REFILANDO"] = 1,
            ["MAQ_TOTAL_PECAS_NAO_REFILANDO"] = 1,
            ["MAQ_TOTAL_VINCOS"] = 1,
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
        payload["Descricao"] = ApiTestData.Text("Maquina Descricao Update", 80);
        payload["Status"] = ApiTestData.Text("Maquina Status Update", 2);
        payload["CAL_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Calendario", "CAL_ID");
        payload["MAQ_CONTROL_IP"] = ApiTestData.Text("Maquina MAQ_CONTROL_IP Update", 30);
        payload["GMA_ID"] = ApiTestData.Text("Maquina GMA_ID Update", 30);
        payload["MAQ_ULTIMA_ATUALIZACAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["MAQ_SIRENE_SEMAFORO"] = 2;
        payload["MAQ_COR_SEMAFORO"] = ApiTestData.Text("Maquina MAQ_COR_SEMAFORO Update", 30);
        payload["MAQ_ID_MAQ_PAI"] = ApiTestData.Text("Maquina MAQ_ID_MAQ_PAI Update", 30);
        payload["MAQ_TIPO_CONTADOR"] = 2;
        payload["MAQ_TIPO_PLANEJAMENTO"] = ApiTestData.Text("Maquina MAQ_TIPO_PLANEJAMENTO Update", 60);
        payload["MAQ_AVALIA_CUSTO"] = 2;
        payload["FPR_ID_OP_PRODUZINDO"] = 2;
        payload["MAQ_CONGELA_FILA"] = 2;
        payload["MAQ_TEMPO_MIN_PARADA"] = 2;
        payload["MAQ_QTD_CORES"] = 2;
        payload["MAQ_ID_INTEGRACAO"] = ApiTestData.Text("Maquina MAQ_ID_INTEGRACAO Update", 80);
        payload["MAQ_ID_INTEGRACAO_ERP"] = ApiTestData.Text("Maquina MAQ_ID_INTEGRACAO_ERP Update", 80);
        payload["MAQ_HIERARQUIA_SEQ_TRANSFORMACAO"] = 20.5m;
        payload["EQU_ID"] = ApiTestData.Text("Maquina EQU_ID Update", 30);
        payload["MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR"] = 20.5m;
        payload["MAQ_ACOMPANHA_LOTE_PILOTO"] = ApiTestData.Text("Maquina MAQ_ACOMPANHA_LOTE_PILOTO Update", 60);
        payload["MAQ_ID_SENSOR"] = 2;
        payload["MAQ_DEBOUNCING_LOW"] = 2;
        payload["MAQ_DEBOUNCING_HIGHT"] = 2;
        payload["MAQ_TIPO_SINAL"] = 2;
        payload["TEM_ID"] = 2;
        payload["MAQ_COMPRIMENTO_CHAPA_DE"] = 20.5m;
        payload["MAQ_COMPRIMENTO_CHAPA_ATE"] = 20.5m;
        payload["MAQ_LARGURA_CHAPA_DE"] = 20.5m;
        payload["MAQ_LARGURA_CHAPA_ATE"] = 20.5m;
        payload["MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR"] = 20.5m;
        payload["MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR"] = 20.5m;
        payload["MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR"] = 20.5m;
        payload["MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR"] = 20.5m;
        payload["MAQ_COMPRIMENTO_ENTRE_VINCO_DE"] = 20.5m;
        payload["MAQ_COMPRIMENTO_ENTRE_VINCO_ATE"] = 20.5m;
        payload["MAQ_LARGURA_ENTRE_VINCO_DE"] = 20.5m;
        payload["MAQ_LARGURA_ENTRE_VINCO_ATE"] = 20.5m;
        payload["MAQ_ALTURA_ENTRE_VINCO_DE"] = 20.5m;
        payload["MAQ_ALTURA_ENTRE_VINCO_ATE"] = 20.5m;
        payload["MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE"] = 20.5m;
        payload["MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE"] = 20.5m;
        payload["MAQ_ABA_DE"] = 20.5m;
        payload["MAQ_ABA_ATE"] = 20.5m;
        payload["MAQ_LAP_DE"] = 20.5m;
        payload["MAQ_LAP_ATE"] = 20.5m;
        payload["MAQ_ONDAS"] = ApiTestData.Text("Maquina MAQ_ONDAS Update", 30);
        payload["MAQ_PROLONGA_LAP"] = ApiTestData.Text("Maquina MAQ_PROLONGA_LAP Update", 30);
        payload["MAQ_LARGURA_IMPRESSAO"] = 20.5m;
        payload["MAQ_COMPRIMENTO_IMPRESSAO"] = 20.5m;
        payload["MAQ_ROLO_DISPOSITIVO_DE"] = 20.5m;
        payload["MAQ_ROLO_DISPOSITIVO_ATE"] = 20.5m;
        payload["MAQ_FAMILIAS"] = ApiTestData.Text("Maquina MAQ_FAMILIAS Update", 80);
        payload["MAQ_REFILE_MINIMO"] = 20.5m;
        payload["MAQ_LARGURA_UTIL"] = 20.5m;
        payload["MAQ_TOTAL_ACO"] = 20.5m;
        payload["MAQ_FECHAMENTO"] = ApiTestData.Text("Maquina MAQ_FECHAMENTO Update", 30);
        payload["MAQ_OPERACAO_VINCAR"] = 20.5m;
        payload["MAQ_OPERACAO_MONTA_DIVISAO"] = 20.5m;
        payload["MAQ_OPERACAO_SERRAR"] = 20.5m;
        payload["MAQ_TIPO_LAP"] = ApiTestData.Text("Maquina MAQ_TIPO_LAP Update", 2);
        payload["MAQ_INDICE_PARADAS_POR_OP"] = 20.5m;
        payload["MAQ_PERDA_MAXIMA"] = 2;
        payload["MAQ_TOTAL_PECAS_REFILANDO"] = 2;
        payload["MAQ_TOTAL_PECAS_NAO_REFILANDO"] = 2;
        payload["MAQ_TOTAL_VINCOS"] = 2;
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