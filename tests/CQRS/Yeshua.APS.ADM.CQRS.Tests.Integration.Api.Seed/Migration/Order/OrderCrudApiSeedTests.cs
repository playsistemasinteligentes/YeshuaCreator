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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Order;

[SeedTestOrder(157)]
public partial class OrderCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Order/PostOrder";
    private const string ReadEndpoint = "yapi/Order/ReadOrder";
    private const string UpdateEndpoint = "yapi/Order/PutOrder";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "ord_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Order", createdId);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "ord_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["ORD_ID"] = ApiTestData.Text("Order ORD_ID", 60),
            ["ORD_ID_RESERVA"] = ApiTestData.Text("Order ORD_ID_RESERVA", 60),
            ["ORD_ID_CONJUNTO"] = ApiTestData.Text("Order ORD_ID_CONJUNTO", 30),
            ["PRO_ID"] = ApiTestData.Text("Order PRO_ID", 30),
            ["PRO_ID_CONJUNTO"] = ApiTestData.Text("Order PRO_ID_CONJUNTO", 30),
            ["CLI_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Cliente", "CLI_ID"),
            ["ORD_PRECO_UNITARIO"] = 10.5m,
            ["ORD_QUANTIDADE"] = 10.5m,
            ["ORD_DATA_ENTREGA_DE"] = DateTime.UtcNow,
            ["ORD_DATA_ENTREGA_ATE"] = DateTime.UtcNow,
            ["ORD_TIPO"] = 1,
            ["ORD_TOLERANCIA_MAIS"] = 10.5m,
            ["ORD_TOLERANCIA_MENOS"] = 10.5m,
            ["HASH_KEY"] = ApiTestData.Text("Order HASH_KEY", 80),
            ["ORD_INICIO_JANELA_EMBARQUE"] = DateTime.UtcNow,
            ["ORD_FIM_JANELA_EMBARQUE"] = DateTime.UtcNow,
            ["ORD_EMBARQUE_ALVO"] = DateTime.UtcNow,
            ["ORD_INICIO_GRUPO_PRODUTIVO"] = DateTime.UtcNow,
            ["ORD_FIM_GRUPO_PRODUTIVO"] = DateTime.UtcNow,
            ["ORD_PESO_UNITARIO"] = 10.5m,
            ["ORD_PESO_UNITARIO_BRUTO"] = 10.5m,
            ["ORD_M2_UNITARIO"] = 10.5m,
            ["ORD_MIT"] = ApiTestData.Text("Order ORD_MIT", 80),
            ["CAR_TIPO_CARREGAMENTO"] = ApiTestData.Text("Order CAR_TIPO_CARREGAMENTO", 50),
            ["ORD_STATUS"] = ApiTestData.Text("Order ORD_STATUS", 10),
            ["ORD_TIPO_FRETE"] = ApiTestData.Text("Order ORD_TIPO_FRETE", 3),
            ["ORD_ENDERECO_ENTREGA"] = ApiTestData.Text("Order ORD_ENDERECO_ENTREGA", 80),
            ["ORD_BAIRRO_ENTREGA"] = ApiTestData.Text("Order ORD_BAIRRO_ENTREGA", 80),
            ["UF_ID_ENTREGA"] = ApiTestData.Text("Order UF_ID_ENTREGA", 2),
            ["ORD_CEP_ENTREGA"] = ApiTestData.Text("Order ORD_CEP_ENTREGA", 10),
            ["MUN_ID_ENTREGA"] = ApiSeedTestContext.GetRequiredCreatedId("Municipio", "MUN_ID_ENTREGA"),
            ["ORD_REGIAO_ENTREGA"] = ApiSeedTestContext.GetRequiredCreatedId("PontosMapa", "ORD_REGIAO_ENTREGA"),
            ["ORD_LARGURA"] = 10.5m,
            ["ORD_COMPRIMENTO"] = 10.5m,
            ["ORD_GRAMATURA"] = 10.5m,
            ["GRP_ID"] = ApiTestData.Text("Order GRP_ID", 80),
            ["ORD_ID_INTEGRACAO"] = ApiTestData.Text("Order ORD_ID_INTEGRACAO", 80),
            ["ORD_OBSERVACAO_OTIMIZADOR"] = ApiTestData.Text("Order ORD_OBSERVACAO_OTIMIZADOR", 80),
            ["ORD_COR_FILA"] = ApiTestData.Text("Order ORD_COR_FILA", 30),
            ["ORD_PED_CLI"] = ApiTestData.Text("Order ORD_PED_CLI", 80),
            ["ORD_OP_INTEGRACAO"] = ApiTestData.Text("Order ORD_OP_INTEGRACAO", 80),
            ["ORD_LOTE_PILOTO"] = ApiTestData.Text("Order ORD_LOTE_PILOTO", 2),
            ["ORD_PRIORIDADE"] = 1,
            ["ORD_EMISSAO"] = DateTime.UtcNow,
            ["REP_ID"] = ApiTestData.Text("Order REP_ID", 30),
            ["ORD_RESINA"] = ApiTestData.Text("Order ORD_RESINA", 1),
            ["ORD_ENDURECEDOR_MIOLO"] = ApiTestData.Text("Order ORD_ENDURECEDOR_MIOLO", 1),
            ["PRO_ID_INTEGRACAO_ERP"] = ApiTestData.Text("Order PRO_ID_INTEGRACAO_ERP", 30),
            ["ORD_VINCOS_ONDULADEIRA"] = ApiTestData.Text("Order ORD_VINCOS_ONDULADEIRA", 80),
            ["ORD_ERP_CUSTOS_FIXOS"] = 10.5m,
            ["ORD_ERP_CUSTOS_VARIAVEIS"] = 10.5m,
            ["ORD_ERP_DESPESAS_VAR_VENDA"] = 10.5m,
            ["ORD_ERP_IMPOSTOS"] = 10.5m,
            ["ORD_STATUS_PLANEJAMENTO"] = ApiTestData.Text("Order ORD_STATUS_PLANEJAMENTO", 2),
            ["ORD_TOLERANCIA_DIMENSAO_CHAPA_DE"] = 1,
            ["ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE"] = 1,
            ["ORD_PROMOVE_DE"] = 10.5m,
            ["ORD_PROMOVE_ATE"] = 10.5m,
            ["ORD_TRAVA_COMPOSICAO"] = ApiTestData.Text("Order ORD_TRAVA_COMPOSICAO", 30),
            ["ORD_TRAVA_RESINA"] = ApiTestData.Text("Order ORD_TRAVA_RESINA", 1),
            ["ORD_PROMOVE_RESINA"] = ApiTestData.Text("Order ORD_PROMOVE_RESINA", 1),
            ["ORD_LATITUDE_ENTREGA"] = 10.5m,
            ["ORD_LONGITUDE_ENTREGA"] = 10.5m,
            ["OCO_ID_CANCELAMENTO"] = ApiSeedTestContext.GetRequiredCreatedId("Ocorrencia", "OCO_ID_CANCELAMENTO"),
            ["TMP_TIPO_CARGA"] = ApiTestData.Text("Order TMP_TIPO_CARGA", 50),
            ["PRO_ID_PALETE"] = ApiTestData.Text("Order PRO_ID_PALETE", 30),
            ["PRO_ID_TAMPO"] = ApiTestData.Text("Order PRO_ID_TAMPO", 30),
            ["ORD_PILHAS_POR_PALETE"] = 1,
            ["ORD_CHAPAS_POR_PILHA"] = 1,
            ["ORD_DATA_CANCELAMENTO"] = DateTime.UtcNow,
            ["ORD_STATUS_ESTATISTICA"] = ApiTestData.Text("Order ORD_STATUS_ESTATISTICA", 2),
            ["ORD_DATA_ESTATISTICA"] = DateTime.UtcNow,
            ["OCO_ID_MOTIVO_ATRASO"] = ApiTestData.Text("Order OCO_ID_MOTIVO_ATRASO", 30),
            ["OTK_VERSSAO"] = 1,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["ORD_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["ORD_ID"] = id.DeepClone();
        payload["ORD_ID_RESERVA"] = ApiTestData.Text("Order ORD_ID_RESERVA Update", 60);
        payload["ORD_ID_CONJUNTO"] = ApiTestData.Text("Order ORD_ID_CONJUNTO Update", 30);
        payload["PRO_ID"] = ApiTestData.Text("Order PRO_ID Update", 30);
        payload["PRO_ID_CONJUNTO"] = ApiTestData.Text("Order PRO_ID_CONJUNTO Update", 30);
        payload["CLI_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Cliente", "CLI_ID");
        payload["ORD_PRECO_UNITARIO"] = 20.5m;
        payload["ORD_QUANTIDADE"] = 20.5m;
        payload["ORD_DATA_ENTREGA_DE"] = DateTime.UtcNow.AddMinutes(1);
        payload["ORD_DATA_ENTREGA_ATE"] = DateTime.UtcNow.AddMinutes(1);
        payload["ORD_TIPO"] = 2;
        payload["ORD_TOLERANCIA_MAIS"] = 20.5m;
        payload["ORD_TOLERANCIA_MENOS"] = 20.5m;
        payload["HASH_KEY"] = ApiTestData.Text("Order HASH_KEY Update", 80);
        payload["ORD_INICIO_JANELA_EMBARQUE"] = DateTime.UtcNow.AddMinutes(1);
        payload["ORD_FIM_JANELA_EMBARQUE"] = DateTime.UtcNow.AddMinutes(1);
        payload["ORD_EMBARQUE_ALVO"] = DateTime.UtcNow.AddMinutes(1);
        payload["ORD_INICIO_GRUPO_PRODUTIVO"] = DateTime.UtcNow.AddMinutes(1);
        payload["ORD_FIM_GRUPO_PRODUTIVO"] = DateTime.UtcNow.AddMinutes(1);
        payload["ORD_PESO_UNITARIO"] = 20.5m;
        payload["ORD_PESO_UNITARIO_BRUTO"] = 20.5m;
        payload["ORD_M2_UNITARIO"] = 20.5m;
        payload["ORD_MIT"] = ApiTestData.Text("Order ORD_MIT Update", 80);
        payload["CAR_TIPO_CARREGAMENTO"] = ApiTestData.Text("Order CAR_TIPO_CARREGAMENTO Update", 50);
        payload["ORD_STATUS"] = ApiTestData.Text("Order ORD_STATUS Update", 10);
        payload["ORD_TIPO_FRETE"] = ApiTestData.Text("Order ORD_TIPO_FRETE Update", 3);
        payload["ORD_ENDERECO_ENTREGA"] = ApiTestData.Text("Order ORD_ENDERECO_ENTREGA Update", 80);
        payload["ORD_BAIRRO_ENTREGA"] = ApiTestData.Text("Order ORD_BAIRRO_ENTREGA Update", 80);
        payload["UF_ID_ENTREGA"] = ApiTestData.Text("Order UF_ID_ENTREGA Update", 2);
        payload["ORD_CEP_ENTREGA"] = ApiTestData.Text("Order ORD_CEP_ENTREGA Update", 10);
        payload["MUN_ID_ENTREGA"] = ApiSeedTestContext.GetRequiredCreatedId("Municipio", "MUN_ID_ENTREGA");
        payload["ORD_REGIAO_ENTREGA"] = ApiSeedTestContext.GetRequiredCreatedId("PontosMapa", "ORD_REGIAO_ENTREGA");
        payload["ORD_LARGURA"] = 20.5m;
        payload["ORD_COMPRIMENTO"] = 20.5m;
        payload["ORD_GRAMATURA"] = 20.5m;
        payload["GRP_ID"] = ApiTestData.Text("Order GRP_ID Update", 80);
        payload["ORD_ID_INTEGRACAO"] = ApiTestData.Text("Order ORD_ID_INTEGRACAO Update", 80);
        payload["ORD_OBSERVACAO_OTIMIZADOR"] = ApiTestData.Text("Order ORD_OBSERVACAO_OTIMIZADOR Update", 80);
        payload["ORD_COR_FILA"] = ApiTestData.Text("Order ORD_COR_FILA Update", 30);
        payload["ORD_PED_CLI"] = ApiTestData.Text("Order ORD_PED_CLI Update", 80);
        payload["ORD_OP_INTEGRACAO"] = ApiTestData.Text("Order ORD_OP_INTEGRACAO Update", 80);
        payload["ORD_LOTE_PILOTO"] = ApiTestData.Text("Order ORD_LOTE_PILOTO Update", 2);
        payload["ORD_PRIORIDADE"] = 2;
        payload["ORD_EMISSAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["REP_ID"] = ApiTestData.Text("Order REP_ID Update", 30);
        payload["ORD_RESINA"] = ApiTestData.Text("Order ORD_RESINA Update", 1);
        payload["ORD_ENDURECEDOR_MIOLO"] = ApiTestData.Text("Order ORD_ENDURECEDOR_MIOLO Update", 1);
        payload["PRO_ID_INTEGRACAO_ERP"] = ApiTestData.Text("Order PRO_ID_INTEGRACAO_ERP Update", 30);
        payload["ORD_VINCOS_ONDULADEIRA"] = ApiTestData.Text("Order ORD_VINCOS_ONDULADEIRA Update", 80);
        payload["ORD_ERP_CUSTOS_FIXOS"] = 20.5m;
        payload["ORD_ERP_CUSTOS_VARIAVEIS"] = 20.5m;
        payload["ORD_ERP_DESPESAS_VAR_VENDA"] = 20.5m;
        payload["ORD_ERP_IMPOSTOS"] = 20.5m;
        payload["ORD_STATUS_PLANEJAMENTO"] = ApiTestData.Text("Order ORD_STATUS_PLANEJAMENTO Update", 2);
        payload["ORD_TOLERANCIA_DIMENSAO_CHAPA_DE"] = 2;
        payload["ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE"] = 2;
        payload["ORD_PROMOVE_DE"] = 20.5m;
        payload["ORD_PROMOVE_ATE"] = 20.5m;
        payload["ORD_TRAVA_COMPOSICAO"] = ApiTestData.Text("Order ORD_TRAVA_COMPOSICAO Update", 30);
        payload["ORD_TRAVA_RESINA"] = ApiTestData.Text("Order ORD_TRAVA_RESINA Update", 1);
        payload["ORD_PROMOVE_RESINA"] = ApiTestData.Text("Order ORD_PROMOVE_RESINA Update", 1);
        payload["ORD_LATITUDE_ENTREGA"] = 20.5m;
        payload["ORD_LONGITUDE_ENTREGA"] = 20.5m;
        payload["OCO_ID_CANCELAMENTO"] = ApiSeedTestContext.GetRequiredCreatedId("Ocorrencia", "OCO_ID_CANCELAMENTO");
        payload["TMP_TIPO_CARGA"] = ApiTestData.Text("Order TMP_TIPO_CARGA Update", 50);
        payload["PRO_ID_PALETE"] = ApiTestData.Text("Order PRO_ID_PALETE Update", 30);
        payload["PRO_ID_TAMPO"] = ApiTestData.Text("Order PRO_ID_TAMPO Update", 30);
        payload["ORD_PILHAS_POR_PALETE"] = 2;
        payload["ORD_CHAPAS_POR_PILHA"] = 2;
        payload["ORD_DATA_CANCELAMENTO"] = DateTime.UtcNow.AddMinutes(1);
        payload["ORD_STATUS_ESTATISTICA"] = ApiTestData.Text("Order ORD_STATUS_ESTATISTICA Update", 2);
        payload["ORD_DATA_ESTATISTICA"] = DateTime.UtcNow.AddMinutes(1);
        payload["OCO_ID_MOTIVO_ATRASO"] = ApiTestData.Text("Order OCO_ID_MOTIVO_ATRASO Update", 30);
        payload["OTK_VERSSAO"] = 2;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration