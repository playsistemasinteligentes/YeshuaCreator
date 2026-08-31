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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.FilaProducao;

[SeedTestOrder(171)]
public partial class FilaProducaoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/FilaProducao/PostFilaProducao";
    private const string ReadEndpoint = "yapi/FilaProducao/ReadFilaProducao";
    private const string UpdateEndpoint = "yapi/FilaProducao/PutFilaProducao";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("FilaProducao", createdId);

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
            ["ORD_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Order", "ORD_ID"),
            ["ROT_PRO_ID"] = ApiTestData.Text("FilaProducao ROT_PRO_ID", 30),
            ["FPR_QUANTIDADE_PREVISTA"] = 10.5m,
            ["ROT_MAQ_ID"] = ApiTestData.Text("FilaProducao ROT_MAQ_ID", 30),
            ["FPR_DATA_INICIO_PREVISTA"] = DateTime.UtcNow,
            ["FPR_DATA_FIM_PREVISTA"] = DateTime.UtcNow,
            ["FPR_DATA_FIM_MAXIMA"] = DateTime.UtcNow,
            ["ROT_SEQ_TRANFORMACAO"] = 1,
            ["FPR_SEQ_REPETICAO"] = 1,
            ["FPR_OBS_PRODUCAO"] = ApiTestData.Text("FilaProducao FPR_OBS_PRODUCAO", 80),
            ["FPR_STATUS"] = ApiTestData.Text("FilaProducao FPR_STATUS", 2),
            ["FPR_TEMPO_DECORRIDO_SETUP"] = 10.5m,
            ["FPR_TEMPO_DECORRIDO_SETUPA"] = 10.5m,
            ["FPR_TEMPO_DECORRIDO_PERFORMANC"] = 10.5m,
            ["FPR_TEMPO_DECO_PEQUENA_PARADA"] = 10.5m,
            ["FPR_QTD_PERFORMANCE"] = 10.5m,
            ["FPR_QTD_SETUP"] = 10.5m,
            ["FPR_QTD_PRODUZIDA"] = 10.5m,
            ["FPR_TEMPO_TEORICO_PERFORMANCE"] = 10.5m,
            ["FPR_TEMPO_RESTANTE_PERFORMANC"] = 10.5m,
            ["FPR_VELOCIDADE_P_ATINGIR_META"] = 10.5m,
            ["FPR_QTD_RESTANTE"] = 10.5m,
            ["FPR_VELO_ATU_PC_SEGUNDO"] = 10.5m,
            ["FPR_PERFORMANCE_PROJETADA"] = 10.5m,
            ["FPR_TEMPO_RESTANTE_TOTAL"] = 10.5m,
            ["FPR_FIM_PREVISTO_ATUAL"] = DateTime.UtcNow,
            ["FPR_PRODUZINDO"] = 1,
            ["FPR_ORDEM_NA_FILA"] = 10.5m,
            ["FPR_ID_INTEGRACAO"] = ApiTestData.Text("FilaProducao FPR_ID_INTEGRACAO", 80),
            ["FPR_TRUNCADO"] = ApiTestData.Text("FilaProducao FPR_TRUNCADO", 1),
            ["FPR_DATA_TRUNC_INI"] = DateTime.UtcNow,
            ["FPR_DATA_TRUNC_FIM"] = DateTime.UtcNow,
            ["FPR_COR_FILA"] = ApiTestData.Text("FilaProducao FPR_COR_FILA", 30),
            ["MAQ_ID_MANUAL"] = ApiTestData.Text("FilaProducao MAQ_ID_MANUAL", 30),
            ["MAQ_ID_RESTRINGIDA"] = ApiTestData.Text("FilaProducao MAQ_ID_RESTRINGIDA", 80),
            ["FPR_PREVISAO_MATERIA_PRIMA"] = DateTime.UtcNow,
            ["FPR_DATA_NECESSIDADE_INICIO_PRODUCAO"] = DateTime.UtcNow,
            ["FPR_DATA_NECESSIDADE_FIM_PRODUCAO"] = DateTime.UtcNow,
            ["FPR_GRUPO_PRODUTIVO"] = 10.5m,
            ["FPR_INICIO_GRUPO_PRODUTIVO"] = DateTime.UtcNow,
            ["FPR_FIM_GRUPO_PRODUTIVO"] = DateTime.UtcNow,
            ["FPR_COR_BICO1"] = ApiTestData.Text("FilaProducao FPR_COR_BICO1", 30),
            ["FPR_COR_BICO2"] = ApiTestData.Text("FilaProducao FPR_COR_BICO2", 30),
            ["FPR_COR_BICO3"] = ApiTestData.Text("FilaProducao FPR_COR_BICO3", 30),
            ["FPR_COR_BICO4"] = ApiTestData.Text("FilaProducao FPR_COR_BICO4", 30),
            ["FPR_COR_BICO5"] = ApiTestData.Text("FilaProducao FPR_COR_BICO5", 30),
            ["FPR_META_SETUP"] = 10.5m,
            ["FPR_ORD_ID_REPROGRAMADO"] = ApiTestData.Text("FilaProducao FPR_ORD_ID_REPROGRAMADO", 30),
            ["FPR_PRIORIDADE"] = 1,
            ["FPR_SEQ_INCLUSAO_FILA"] = 1,
            ["FPR_HIERARQUIA_SEQ_TRANSFORMACAO"] = 1,
            ["FPR_ID_ORIGEM"] = 1,
            ["FPR_DATA_ENTREGA"] = DateTime.UtcNow,
            ["EQU_ID"] = ApiTestData.Text("FilaProducao EQU_ID", 30),
            ["FPR_GRUPO_PRODUTIVO_MANUAL"] = 10.5m,
            ["FPR_EMISSAO"] = DateTime.UtcNow,
            ["FPR_MOTIVO_PULA_FILA"] = ApiTestData.Text("FilaProducao FPR_MOTIVO_PULA_FILA", 80),
            ["OCO_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Ocorrencia", "OCO_ID"),
            ["FPR_TOLERANCIA_MENOS"] = 10.5m,
            ["FPR_TOLERANCIA_MAIS"] = 10.5m,
            ["FPR_DATA_ENCERRAMENTO"] = DateTime.UtcNow,
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
        payload["ORD_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Order", "ORD_ID");
        payload["ROT_PRO_ID"] = ApiTestData.Text("FilaProducao ROT_PRO_ID Update", 30);
        payload["FPR_QUANTIDADE_PREVISTA"] = 20.5m;
        payload["ROT_MAQ_ID"] = ApiTestData.Text("FilaProducao ROT_MAQ_ID Update", 30);
        payload["FPR_DATA_INICIO_PREVISTA"] = DateTime.UtcNow.AddMinutes(1);
        payload["FPR_DATA_FIM_PREVISTA"] = DateTime.UtcNow.AddMinutes(1);
        payload["FPR_DATA_FIM_MAXIMA"] = DateTime.UtcNow.AddMinutes(1);
        payload["ROT_SEQ_TRANFORMACAO"] = 2;
        payload["FPR_SEQ_REPETICAO"] = 2;
        payload["FPR_OBS_PRODUCAO"] = ApiTestData.Text("FilaProducao FPR_OBS_PRODUCAO Update", 80);
        payload["FPR_STATUS"] = ApiTestData.Text("FilaProducao FPR_STATUS Update", 2);
        payload["FPR_TEMPO_DECORRIDO_SETUP"] = 20.5m;
        payload["FPR_TEMPO_DECORRIDO_SETUPA"] = 20.5m;
        payload["FPR_TEMPO_DECORRIDO_PERFORMANC"] = 20.5m;
        payload["FPR_TEMPO_DECO_PEQUENA_PARADA"] = 20.5m;
        payload["FPR_QTD_PERFORMANCE"] = 20.5m;
        payload["FPR_QTD_SETUP"] = 20.5m;
        payload["FPR_QTD_PRODUZIDA"] = 20.5m;
        payload["FPR_TEMPO_TEORICO_PERFORMANCE"] = 20.5m;
        payload["FPR_TEMPO_RESTANTE_PERFORMANC"] = 20.5m;
        payload["FPR_VELOCIDADE_P_ATINGIR_META"] = 20.5m;
        payload["FPR_QTD_RESTANTE"] = 20.5m;
        payload["FPR_VELO_ATU_PC_SEGUNDO"] = 20.5m;
        payload["FPR_PERFORMANCE_PROJETADA"] = 20.5m;
        payload["FPR_TEMPO_RESTANTE_TOTAL"] = 20.5m;
        payload["FPR_FIM_PREVISTO_ATUAL"] = DateTime.UtcNow.AddMinutes(1);
        payload["FPR_PRODUZINDO"] = 2;
        payload["FPR_ORDEM_NA_FILA"] = 20.5m;
        payload["FPR_ID_INTEGRACAO"] = ApiTestData.Text("FilaProducao FPR_ID_INTEGRACAO Update", 80);
        payload["FPR_TRUNCADO"] = ApiTestData.Text("FilaProducao FPR_TRUNCADO Update", 1);
        payload["FPR_DATA_TRUNC_INI"] = DateTime.UtcNow.AddMinutes(1);
        payload["FPR_DATA_TRUNC_FIM"] = DateTime.UtcNow.AddMinutes(1);
        payload["FPR_COR_FILA"] = ApiTestData.Text("FilaProducao FPR_COR_FILA Update", 30);
        payload["MAQ_ID_MANUAL"] = ApiTestData.Text("FilaProducao MAQ_ID_MANUAL Update", 30);
        payload["MAQ_ID_RESTRINGIDA"] = ApiTestData.Text("FilaProducao MAQ_ID_RESTRINGIDA Update", 80);
        payload["FPR_PREVISAO_MATERIA_PRIMA"] = DateTime.UtcNow.AddMinutes(1);
        payload["FPR_DATA_NECESSIDADE_INICIO_PRODUCAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["FPR_DATA_NECESSIDADE_FIM_PRODUCAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["FPR_GRUPO_PRODUTIVO"] = 20.5m;
        payload["FPR_INICIO_GRUPO_PRODUTIVO"] = DateTime.UtcNow.AddMinutes(1);
        payload["FPR_FIM_GRUPO_PRODUTIVO"] = DateTime.UtcNow.AddMinutes(1);
        payload["FPR_COR_BICO1"] = ApiTestData.Text("FilaProducao FPR_COR_BICO1 Update", 30);
        payload["FPR_COR_BICO2"] = ApiTestData.Text("FilaProducao FPR_COR_BICO2 Update", 30);
        payload["FPR_COR_BICO3"] = ApiTestData.Text("FilaProducao FPR_COR_BICO3 Update", 30);
        payload["FPR_COR_BICO4"] = ApiTestData.Text("FilaProducao FPR_COR_BICO4 Update", 30);
        payload["FPR_COR_BICO5"] = ApiTestData.Text("FilaProducao FPR_COR_BICO5 Update", 30);
        payload["FPR_META_SETUP"] = 20.5m;
        payload["FPR_ORD_ID_REPROGRAMADO"] = ApiTestData.Text("FilaProducao FPR_ORD_ID_REPROGRAMADO Update", 30);
        payload["FPR_PRIORIDADE"] = 2;
        payload["FPR_SEQ_INCLUSAO_FILA"] = 2;
        payload["FPR_HIERARQUIA_SEQ_TRANSFORMACAO"] = 2;
        payload["FPR_ID_ORIGEM"] = 2;
        payload["FPR_DATA_ENTREGA"] = DateTime.UtcNow.AddMinutes(1);
        payload["EQU_ID"] = ApiTestData.Text("FilaProducao EQU_ID Update", 30);
        payload["FPR_GRUPO_PRODUTIVO_MANUAL"] = 20.5m;
        payload["FPR_EMISSAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["FPR_MOTIVO_PULA_FILA"] = ApiTestData.Text("FilaProducao FPR_MOTIVO_PULA_FILA Update", 80);
        payload["OCO_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Ocorrencia", "OCO_ID");
        payload["FPR_TOLERANCIA_MENOS"] = 20.5m;
        payload["FPR_TOLERANCIA_MAIS"] = 20.5m;
        payload["FPR_DATA_ENCERRAMENTO"] = DateTime.UtcNow.AddMinutes(1);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration