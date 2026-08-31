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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.TargetProduto;

[SeedTestOrder(180)]
public partial class TargetProdutoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/TargetProduto/PostTargetProduto";
    private const string ReadEndpoint = "yapi/TargetProduto/ReadTargetProduto";
    private const string UpdateEndpoint = "yapi/TargetProduto/PutTargetProduto";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "tar_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("TargetProduto", createdId);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "tar_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["MOV_ID"] = ApiSeedTestContext.GetRequiredCreatedId("MovimentoEstoque", "MOV_ID"),
            ["ORD_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Order", "ORD_ID"),
            ["PRO_ID"] = ApiTestData.Text("TargetProduto PRO_ID", 30),
            ["MAQ_ID"] = ApiTestData.Text("TargetProduto MAQ_ID", 30),
            ["UNI_ID"] = ApiSeedTestContext.GetRequiredCreatedId("UnidadeMedida", "UNI_ID"),
            ["TURM_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turma", "TURM_ID"),
            ["TURN_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turno", "TURN_ID"),
            ["USE_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Usuario", "USE_ID"),
            ["TAR_DIA_TURMA"] = ApiTestData.Text("TargetProduto TAR_DIA_TURMA", 8),
            ["TAR_META_PERFORMANCE"] = 10.5m,
            ["TAR_REALIZADO_PERFORMANCE"] = 10.5m,
            ["TAR_PERCENTUAL_REALIZADO_PERFORMANCE"] = 10.5m,
            ["TAR_PROXIMA_META_PERFORMANCE"] = 10.5m,
            ["TAR_META_TEMPO_SETUP"] = 10.5m,
            ["TAR_REALIZADO_TEMPO_SETUP"] = 10.5m,
            ["TAR_PROXIMA_META_TEMPO_SETUP"] = 10.5m,
            ["TAR_META_TEMPO_SETUP_AJUSTE"] = 10.5m,
            ["TAR_REALIZADO_TEMPO_SETUP_AJUSTE"] = 10.5m,
            ["TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE"] = 10.5m,
            ["OCO_ID_PERFORMANCE"] = ApiSeedTestContext.GetRequiredCreatedId("Ocorrencia", "OCO_ID_PERFORMANCE"),
            ["TAR_OBS_PERFORMANCE"] = ApiTestData.Text("TargetProduto TAR_OBS_PERFORMANCE", 80),
            ["OCO_ID_SETUP"] = ApiTestData.Text("TargetProduto OCO_ID_SETUP", 30),
            ["TAR_OBS_SETUP"] = ApiTestData.Text("TargetProduto TAR_OBS_SETUP", 80),
            ["OCO_ID_SETUPA"] = ApiTestData.Text("TargetProduto OCO_ID_SETUPA", 30),
            ["TAR_OBS_SETUPA"] = ApiTestData.Text("TargetProduto TAR_OBS_SETUPA", 80),
            ["TAR_TIPO_FEEDBACK_PERFORMANCE"] = ApiTestData.Text("TargetProduto TAR_TIPO_FEEDBACK_PERFORMANCE", 1),
            ["TAR_TIPO_FEEDBACK_SETUP"] = ApiTestData.Text("TargetProduto TAR_TIPO_FEEDBACK_SETUP", 1),
            ["TAR_TIPO_FEEDBACK_SETUP_AJUSTE"] = ApiTestData.Text("TargetProduto TAR_TIPO_FEEDBACK_SETUP_AJUSTE", 1),
            ["TAR_QTD_SETUP_AJUSTE"] = 10.5m,
            ["TAR_QTD"] = 10.5m,
            ["TAR_PARAMETRO_TIME_WORK_STOP_MACHINE"] = 1,
            ["TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE"] = 1,
            ["ROT_SEQ_TRANFORMACAO"] = 1,
            ["FPR_SEQ_REPETICAO"] = 1,
            ["TAR_PERFORMANCE_MAX_VERDE"] = 10.5m,
            ["TAR_PERFORMANCE_MIN_VERDE"] = 10.5m,
            ["TAR_SETUP_MAX_VERDE"] = 10.5m,
            ["TAR_SETUP_MIN_VERDE"] = 10.5m,
            ["TAR_SETUPA_MAX_VERDE"] = 10.5m,
            ["TAR_SETUPA_MIN_VERDE"] = 10.5m,
            ["TAR_PERFORMANCE_MIN_AMARELO"] = 10.5m,
            ["TAR_SETUP_MAX_AMARELO"] = 10.5m,
            ["TAR_SETUPA_MAX_AMARELO"] = 10.5m,
            ["TAR_OBS_OP_PARCIAL"] = ApiTestData.Text("TargetProduto TAR_OBS_OP_PARCIAL", 80),
            ["TAR_OCO_ID_OP_PARCIAL"] = ApiTestData.Text("TargetProduto TAR_OCO_ID_OP_PARCIAL", 30),
            ["TAR_COR_PERFORMANCE"] = ApiTestData.Text("TargetProduto TAR_COR_PERFORMANCE", 10),
            ["TAR_COR_SETUP_GERAL"] = ApiTestData.Text("TargetProduto TAR_COR_SETUP_GERAL", 10),
            ["TAR_COR_SETUP"] = ApiTestData.Text("TargetProduto TAR_COR_SETUP", 10),
            ["TAR_COR_SETUPA"] = ApiTestData.Text("TargetProduto TAR_COR_SETUPA", 10),
            ["TAR_DIA_TURMA_D"] = DateTime.UtcNow,
            ["FEE_QTD_PECAS_POR_PULSO"] = 10.5m,
            ["TAR_QTD_PERDAS"] = 10.5m,
            ["TAR_DATA_INICIAL"] = DateTime.UtcNow,
            ["TAR_DATA_FINAL"] = DateTime.UtcNow,
            ["TAR_APROVADO"] = ApiTestData.Text("TargetProduto TAR_APROVADO", 2),
            ["TAR_TEMPO_PRODUZINDO"] = 1,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["TAR_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["TAR_ID"] = id.DeepClone();
        payload["MOV_ID"] = ApiSeedTestContext.GetRequiredCreatedId("MovimentoEstoque", "MOV_ID");
        payload["ORD_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Order", "ORD_ID");
        payload["PRO_ID"] = ApiTestData.Text("TargetProduto PRO_ID Update", 30);
        payload["MAQ_ID"] = ApiTestData.Text("TargetProduto MAQ_ID Update", 30);
        payload["UNI_ID"] = ApiSeedTestContext.GetRequiredCreatedId("UnidadeMedida", "UNI_ID");
        payload["TURM_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turma", "TURM_ID");
        payload["TURN_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turno", "TURN_ID");
        payload["USE_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Usuario", "USE_ID");
        payload["TAR_DIA_TURMA"] = ApiTestData.Text("TargetProduto TAR_DIA_TURMA Update", 8);
        payload["TAR_META_PERFORMANCE"] = 20.5m;
        payload["TAR_REALIZADO_PERFORMANCE"] = 20.5m;
        payload["TAR_PERCENTUAL_REALIZADO_PERFORMANCE"] = 20.5m;
        payload["TAR_PROXIMA_META_PERFORMANCE"] = 20.5m;
        payload["TAR_META_TEMPO_SETUP"] = 20.5m;
        payload["TAR_REALIZADO_TEMPO_SETUP"] = 20.5m;
        payload["TAR_PROXIMA_META_TEMPO_SETUP"] = 20.5m;
        payload["TAR_META_TEMPO_SETUP_AJUSTE"] = 20.5m;
        payload["TAR_REALIZADO_TEMPO_SETUP_AJUSTE"] = 20.5m;
        payload["TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE"] = 20.5m;
        payload["OCO_ID_PERFORMANCE"] = ApiSeedTestContext.GetRequiredCreatedId("Ocorrencia", "OCO_ID_PERFORMANCE");
        payload["TAR_OBS_PERFORMANCE"] = ApiTestData.Text("TargetProduto TAR_OBS_PERFORMANCE Update", 80);
        payload["OCO_ID_SETUP"] = ApiTestData.Text("TargetProduto OCO_ID_SETUP Update", 30);
        payload["TAR_OBS_SETUP"] = ApiTestData.Text("TargetProduto TAR_OBS_SETUP Update", 80);
        payload["OCO_ID_SETUPA"] = ApiTestData.Text("TargetProduto OCO_ID_SETUPA Update", 30);
        payload["TAR_OBS_SETUPA"] = ApiTestData.Text("TargetProduto TAR_OBS_SETUPA Update", 80);
        payload["TAR_TIPO_FEEDBACK_PERFORMANCE"] = ApiTestData.Text("TargetProduto TAR_TIPO_FEEDBACK_PERFORMANCE Update", 1);
        payload["TAR_TIPO_FEEDBACK_SETUP"] = ApiTestData.Text("TargetProduto TAR_TIPO_FEEDBACK_SETUP Update", 1);
        payload["TAR_TIPO_FEEDBACK_SETUP_AJUSTE"] = ApiTestData.Text("TargetProduto TAR_TIPO_FEEDBACK_SETUP_AJUSTE Update", 1);
        payload["TAR_QTD_SETUP_AJUSTE"] = 20.5m;
        payload["TAR_QTD"] = 20.5m;
        payload["TAR_PARAMETRO_TIME_WORK_STOP_MACHINE"] = 2;
        payload["TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE"] = 2;
        payload["ROT_SEQ_TRANFORMACAO"] = 2;
        payload["FPR_SEQ_REPETICAO"] = 2;
        payload["TAR_PERFORMANCE_MAX_VERDE"] = 20.5m;
        payload["TAR_PERFORMANCE_MIN_VERDE"] = 20.5m;
        payload["TAR_SETUP_MAX_VERDE"] = 20.5m;
        payload["TAR_SETUP_MIN_VERDE"] = 20.5m;
        payload["TAR_SETUPA_MAX_VERDE"] = 20.5m;
        payload["TAR_SETUPA_MIN_VERDE"] = 20.5m;
        payload["TAR_PERFORMANCE_MIN_AMARELO"] = 20.5m;
        payload["TAR_SETUP_MAX_AMARELO"] = 20.5m;
        payload["TAR_SETUPA_MAX_AMARELO"] = 20.5m;
        payload["TAR_OBS_OP_PARCIAL"] = ApiTestData.Text("TargetProduto TAR_OBS_OP_PARCIAL Update", 80);
        payload["TAR_OCO_ID_OP_PARCIAL"] = ApiTestData.Text("TargetProduto TAR_OCO_ID_OP_PARCIAL Update", 30);
        payload["TAR_COR_PERFORMANCE"] = ApiTestData.Text("TargetProduto TAR_COR_PERFORMANCE Update", 10);
        payload["TAR_COR_SETUP_GERAL"] = ApiTestData.Text("TargetProduto TAR_COR_SETUP_GERAL Update", 10);
        payload["TAR_COR_SETUP"] = ApiTestData.Text("TargetProduto TAR_COR_SETUP Update", 10);
        payload["TAR_COR_SETUPA"] = ApiTestData.Text("TargetProduto TAR_COR_SETUPA Update", 10);
        payload["TAR_DIA_TURMA_D"] = DateTime.UtcNow.AddMinutes(1);
        payload["FEE_QTD_PECAS_POR_PULSO"] = 20.5m;
        payload["TAR_QTD_PERDAS"] = 20.5m;
        payload["TAR_DATA_INICIAL"] = DateTime.UtcNow.AddMinutes(1);
        payload["TAR_DATA_FINAL"] = DateTime.UtcNow.AddMinutes(1);
        payload["TAR_APROVADO"] = ApiTestData.Text("TargetProduto TAR_APROVADO Update", 2);
        payload["TAR_TEMPO_PRODUZINDO"] = 2;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration