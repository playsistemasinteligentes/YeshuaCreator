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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Produto;

[SeedTestOrder(181)]
public partial class ProdutoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Produto/PostProduto";
    private const string ReadEndpoint = "yapi/Produto/ReadProduto";
    private const string UpdateEndpoint = "yapi/Produto/PutProduto";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Produto", createdId);

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
            ["Id"] = ApiTestData.Text("Produto Id", 30),
            ["Descricao"] = ApiTestData.Text("Produto Descricao", 80),
            ["Status"] = ApiTestData.Text("Produto Status", 2),
            ["PRO_ESTOQUE_ATUAL"] = 10.5m,
            ["UNI_ID"] = ApiSeedTestContext.GetRequiredCreatedId("UnidadeMedida", "UNI_ID"),
            ["PRO_FARDOS_POR_CAMADA"] = 10.5m,
            ["PRO_CAMADAS_POR_PALETE"] = 10.5m,
            ["PRO_TIPO_IDENTIFICACAO"] = 1,
            ["PRO_GRUPO_PALETIZACAO"] = ApiTestData.Text("Produto PRO_GRUPO_PALETIZACAO", 30),
            ["PRO_PECAS_POR_FARDO"] = 10.5m,
            ["PRO_ID_INTEGRACAO"] = ApiTestData.Text("Produto PRO_ID_INTEGRACAO", 80),
            ["PRO_ID_INTEGRACAO_ERP"] = ApiTestData.Text("Produto PRO_ID_INTEGRACAO_ERP", 80),
            ["GRP_ID"] = ApiSeedTestContext.GetRequiredCreatedId("GrupoProdutoAbstrato", "GRP_ID"),
            ["TEM_ID"] = 1,
            ["PRO_LARGURA_PECA"] = 10.5m,
            ["PRO_COMPRIMENTO_PECA"] = 10.5m,
            ["PRO_ALTURA_PECA"] = 10.5m,
            ["PRO_LARGURA_EMBALADA"] = 10.5m,
            ["PRO_COMPRIMENTO_EMBALADA"] = 10.5m,
            ["PRO_ALTURA_EMBALADA"] = 10.5m,
            ["PRO_FRENTE"] = ApiTestData.Text("Produto PRO_FRENTE", 1),
            ["PRO_ROTACIONA_COMPRIMENTO"] = ApiTestData.Text("Produto PRO_ROTACIONA_COMPRIMENTO", 1),
            ["PRO_ROTACIONA_LARGURA"] = ApiTestData.Text("Produto PRO_ROTACIONA_LARGURA", 1),
            ["PRO_ROTACIONA_ALTURA"] = ApiTestData.Text("Produto PRO_ROTACIONA_ALTURA", 1),
            ["PRO_ESCALA_COR"] = ApiTestData.Text("Produto PRO_ESCALA_COR", 30),
            ["PRO_SUB_ESCALA_COR"] = ApiTestData.Text("Produto PRO_SUB_ESCALA_COR", 30),
            ["PRO_CUSTO_SUBIDA_ESCALA_COR"] = 10.5m,
            ["PRO_CUSTO_DECIDA_ESCALA_COR"] = 10.5m,
            ["TMP_TIPO_CARGA"] = ApiTestData.Text("Produto TMP_TIPO_CARGA", 50),
            ["PRO_TEMPO_CARREGAMENTO_UNITARIO"] = 10.5m,
            ["PRO_TEMPO_DESCARREGAMENTO_UNITARIO"] = 10.5m,
            ["PRO_PERCENTUAL_JANELA_EMBARQUE"] = 10.5m,
            ["PRO_TEMPO_PRODUCAO_CONJUNTO"] = 10.5m,
            ["PRO_PECAS_DA_PECA"] = 10.5m,
            ["PRO_TYPE"] = 1,
            ["PRO_COLOR_HEXA"] = ApiTestData.Text("Produto PRO_COLOR_HEXA", 6),
            ["PRO_VINCOS_LARGURA"] = ApiTestData.Text("Produto PRO_VINCOS_LARGURA", 80),
            ["PRO_VINCOS_COMPRIMENTO"] = ApiTestData.Text("Produto PRO_VINCOS_COMPRIMENTO", 80),
            ["PRO_LARGURA_INTERNA"] = 10.5m,
            ["PRO_COMPRIMENTO_INTERNA"] = 10.5m,
            ["PRO_ALTURA_INTERNA"] = 10.5m,
            ["PRO_COD_DESENHO"] = ApiTestData.Text("Produto PRO_COD_DESENHO", 80),
            ["PRO_FECHAMENTO"] = ApiTestData.Text("Produto PRO_FECHAMENTO", 1),
            ["PRO_TIPO_LAP"] = ApiTestData.Text("Produto PRO_TIPO_LAP", 1),
            ["PRO_TAMANHO_LAP"] = 10.5m,
            ["PRO_LAP_PROLONGADO"] = ApiTestData.Text("Produto PRO_LAP_PROLONGADO", 2),
            ["PRO_TAMANHO_LAP_PROLONG"] = 10.5m,
            ["PRO_ARRANJO_LARGURA"] = 10.5m,
            ["PRO_ARRANJO_COMPRIMENTO"] = 10.5m,
            ["PRO_FITILHOS_FARDO_LARG"] = 1,
            ["PRO_FITILHOS_FARDO_COMP"] = 1,
            ["PRO_FITILHOS_PALETE_LARG"] = 1,
            ["PRO_FITILHOS_PALETE_COMP"] = 1,
            ["PRO_FILME_PALETE"] = 1,
            ["PRO_QTD_ESPELHO"] = 1,
            ["PRO_CUSTO"] = 10.5m,
            ["PRO_AREA_LIQUIDA"] = 10.5m,
            ["PRO_PESO"] = 10.5m,
            ["PRO_TOLERANCIA_DIMENSAO_CHAPA_DE"] = 1,
            ["PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE"] = 1,
            ["PRO_IMG_LASTRO"] = ApiTestData.Text("Produto PRO_IMG_LASTRO", 80),
            ["ABN_ID"] = ApiTestData.Text("Produto ABN_ID", 50),
            ["SEG_ID"] = 1,
            ["PRO_RESINA"] = ApiTestData.Text("Produto PRO_RESINA", 1),
            ["PRO_ENDURECEDOR_MIOLO"] = ApiTestData.Text("Produto PRO_ENDURECEDOR_MIOLO", 1),
            ["PRO_VINCOS_ONDULADEIRA"] = ApiTestData.Text("Produto PRO_VINCOS_ONDULADEIRA", 80),
            ["PRO_ADICIONAL_ABA_SUPERIOR"] = 1,
            ["PRO_ADICIONAL_ABA_INFERIOR"] = 1,
            ["PRO_PROMOVE_RESINA"] = ApiTestData.Text("Produto PRO_PROMOVE_RESINA", 1),
            ["PRO_PROMOVE_DE"] = 10.5m,
            ["PRO_PROMOVE_ATE"] = 10.5m,
            ["PRO_PROFUNDIDADE_VINCO"] = 1,
            ["VIN_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Vinco", "VIN_ID"),
            ["PRO_PROMOVE_PRODUTO"] = ApiTestData.Text("Produto PRO_PROMOVE_PRODUTO", 1),
            ["PRO_TARA"] = 10.5m,
            ["PRO_COMPRESSAO"] = 10.5m,
            ["PRO_COD_BARRAS_CAIXA"] = ApiTestData.Text("Produto PRO_COD_BARRAS_CAIXA", 80),
            ["CJN_ID"] = ApiTestData.Text("Produto CJN_ID", 30),
            ["PRJ_ID"] = ApiTestData.Text("Produto PRJ_ID", 80),
            ["PRO_REFILE_LARGURA"] = 1,
            ["PRO_REFILE_COMPRIMENTO"] = 1,
            ["PRO_M2_PONTA"] = 10.5m,
            ["PRO_QTD_CORTES_PECA1"] = 1,
            ["PRO_QTD_CORTES_PECA2"] = 1,
            ["PRO_DIVISAO_MONTADA"] = ApiTestData.Text("Produto PRO_DIVISAO_MONTADA", 3),
            ["PRO_SEGMENTO_A"] = 10.5m,
            ["PRO_SEGMENTO_B"] = 10.5m,
            ["PRO_SEGMENTO_C"] = 10.5m,
            ["PRO_SEGMENTO_D"] = 10.5m,
            ["PRO_SEGMENTO_E"] = 10.5m,
            ["PRO_SEGMENTO_F"] = 10.5m,
            ["PRO_SEGMENTO_G"] = 10.5m,
            ["PRO_SEGMENTO_H"] = 10.5m,
            ["PRO_SEGMENTO_I"] = 10.5m,
            ["PRO_QTD_GRAMPOS"] = 10.5m,
            ["PRO_AREA_REFILE_INTERNO"] = 10.5m,
            ["PRO_AREA_REFILE_EXTERNO"] = 10.5m,
            ["PRO_PESO_REFILE"] = 10.5m,
            ["PRO_ORELHA_INVERTIDA"] = ApiTestData.Text("Produto PRO_ORELHA_INVERTIDA", 1),
            ["PRO_ENDERECO"] = ApiTestData.Text("Produto PRO_ENDERECO", 30),
            ["PRO_ID_VINCULADO"] = ApiTestData.Text("Produto PRO_ID_VINCULADO", 30),
            ["PRO_BATIDAS_PROXIMA_MANUTENCAO"] = 1,
            ["PRO_ENTRADA_NA_MAQUINA"] = ApiTestData.Text("Produto PRO_ENTRADA_NA_MAQUINA", 1),
            ["TDI_ID"] = ApiTestData.Text("Produto TDI_ID", 30),
            ["PRO_QUEBRA_VINCO"] = 1,
            ["PRO_LARGURA_FARDO"] = 1,
            ["PRO_COMPRIMENTO_FARDO"] = 1,
            ["PRO_ALTURA_FARDO"] = 10.5m,
            ["PRO_TIPO_CUSTO"] = ApiTestData.Text("Produto PRO_TIPO_CUSTO", 1),
            ["PRO_GRUPO_CONTABIL"] = ApiTestData.Text("Produto PRO_GRUPO_CONTABIL", 60),
            ["PRO_CLASSE_CUSTO_01"] = ApiTestData.Text("Produto PRO_CLASSE_CUSTO_01", 60),
            ["PRO_OBS_ALTERACAO"] = ApiTestData.Text("Produto PRO_OBS_ALTERACAO", 80),
            ["TIP_ID"] = 1,
            ["PRO_PECAS_POR_VEICULO"] = 10.5m,
            ["PRO_DISTANCIA_ENTRE_VINCOS"] = 1,
            ["PRO_DISTANCIA_ENTRE_VINCOS2"] = 1,
            ["PRO_DISTANCIA_ENTRE_VINCOS3"] = 1,
            ["PRO_OUT"] = 1,
            ["PRO_ID_FACA"] = ApiTestData.Text("Produto PRO_ID_FACA", 30),
            ["PRO_ID_CLICHE"] = ApiTestData.Text("Produto PRO_ID_CLICHE", 30),
            ["PRO_ID_TINTA_01"] = ApiTestData.Text("Produto PRO_ID_TINTA_01", 30),
            ["PRO_ID_TINTA_02"] = ApiTestData.Text("Produto PRO_ID_TINTA_02", 30),
            ["PRO_ID_TINTA_03"] = ApiTestData.Text("Produto PRO_ID_TINTA_03", 30),
            ["PRO_ID_TINTA_04"] = ApiTestData.Text("Produto PRO_ID_TINTA_04", 30),
            ["PRO_ID_TINTA_05"] = ApiTestData.Text("Produto PRO_ID_TINTA_05", 30),
            ["PRO_ID_FORROSUP"] = ApiTestData.Text("Produto PRO_ID_FORROSUP", 30),
            ["PRO_ID_CANTONEIRA"] = ApiTestData.Text("Produto PRO_ID_CANTONEIRA", 30),
            ["PRO_ID_PALETE"] = ApiTestData.Text("Produto PRO_ID_PALETE", 30),
            ["PRO_ID_TAMPO"] = ApiTestData.Text("Produto PRO_ID_TAMPO", 30),
            ["PRO_ID_FORROINF"] = ApiTestData.Text("Produto PRO_ID_FORROINF", 30),
            ["PRO_ID_CHAPA"] = ApiTestData.Text("Produto PRO_ID_CHAPA", 30),
            ["PRO_ID_COMPOSICAO"] = ApiTestData.Text("Produto PRO_ID_COMPOSICAO", 30),
            ["PRO_QUEBRA_VINCO_MAIOR"] = 1,
            ["PRO_QUEBRA_VINCO_MENOR"] = 1,
            ["CLI_ID"] = ApiTestData.Text("Produto CLI_ID", 30),
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
        payload["Descricao"] = ApiTestData.Text("Produto Descricao Update", 80);
        payload["Status"] = ApiTestData.Text("Produto Status Update", 2);
        payload["PRO_ESTOQUE_ATUAL"] = 20.5m;
        payload["UNI_ID"] = ApiSeedTestContext.GetRequiredCreatedId("UnidadeMedida", "UNI_ID");
        payload["PRO_FARDOS_POR_CAMADA"] = 20.5m;
        payload["PRO_CAMADAS_POR_PALETE"] = 20.5m;
        payload["PRO_TIPO_IDENTIFICACAO"] = 2;
        payload["PRO_GRUPO_PALETIZACAO"] = ApiTestData.Text("Produto PRO_GRUPO_PALETIZACAO Update", 30);
        payload["PRO_PECAS_POR_FARDO"] = 20.5m;
        payload["PRO_ID_INTEGRACAO"] = ApiTestData.Text("Produto PRO_ID_INTEGRACAO Update", 80);
        payload["PRO_ID_INTEGRACAO_ERP"] = ApiTestData.Text("Produto PRO_ID_INTEGRACAO_ERP Update", 80);
        payload["GRP_ID"] = ApiSeedTestContext.GetRequiredCreatedId("GrupoProdutoAbstrato", "GRP_ID");
        payload["TEM_ID"] = 2;
        payload["PRO_LARGURA_PECA"] = 20.5m;
        payload["PRO_COMPRIMENTO_PECA"] = 20.5m;
        payload["PRO_ALTURA_PECA"] = 20.5m;
        payload["PRO_LARGURA_EMBALADA"] = 20.5m;
        payload["PRO_COMPRIMENTO_EMBALADA"] = 20.5m;
        payload["PRO_ALTURA_EMBALADA"] = 20.5m;
        payload["PRO_FRENTE"] = ApiTestData.Text("Produto PRO_FRENTE Update", 1);
        payload["PRO_ROTACIONA_COMPRIMENTO"] = ApiTestData.Text("Produto PRO_ROTACIONA_COMPRIMENTO Update", 1);
        payload["PRO_ROTACIONA_LARGURA"] = ApiTestData.Text("Produto PRO_ROTACIONA_LARGURA Update", 1);
        payload["PRO_ROTACIONA_ALTURA"] = ApiTestData.Text("Produto PRO_ROTACIONA_ALTURA Update", 1);
        payload["PRO_ESCALA_COR"] = ApiTestData.Text("Produto PRO_ESCALA_COR Update", 30);
        payload["PRO_SUB_ESCALA_COR"] = ApiTestData.Text("Produto PRO_SUB_ESCALA_COR Update", 30);
        payload["PRO_CUSTO_SUBIDA_ESCALA_COR"] = 20.5m;
        payload["PRO_CUSTO_DECIDA_ESCALA_COR"] = 20.5m;
        payload["TMP_TIPO_CARGA"] = ApiTestData.Text("Produto TMP_TIPO_CARGA Update", 50);
        payload["PRO_TEMPO_CARREGAMENTO_UNITARIO"] = 20.5m;
        payload["PRO_TEMPO_DESCARREGAMENTO_UNITARIO"] = 20.5m;
        payload["PRO_PERCENTUAL_JANELA_EMBARQUE"] = 20.5m;
        payload["PRO_TEMPO_PRODUCAO_CONJUNTO"] = 20.5m;
        payload["PRO_PECAS_DA_PECA"] = 20.5m;
        payload["PRO_TYPE"] = 2;
        payload["PRO_COLOR_HEXA"] = ApiTestData.Text("Produto PRO_COLOR_HEXA Update", 6);
        payload["PRO_VINCOS_LARGURA"] = ApiTestData.Text("Produto PRO_VINCOS_LARGURA Update", 80);
        payload["PRO_VINCOS_COMPRIMENTO"] = ApiTestData.Text("Produto PRO_VINCOS_COMPRIMENTO Update", 80);
        payload["PRO_LARGURA_INTERNA"] = 20.5m;
        payload["PRO_COMPRIMENTO_INTERNA"] = 20.5m;
        payload["PRO_ALTURA_INTERNA"] = 20.5m;
        payload["PRO_COD_DESENHO"] = ApiTestData.Text("Produto PRO_COD_DESENHO Update", 80);
        payload["PRO_FECHAMENTO"] = ApiTestData.Text("Produto PRO_FECHAMENTO Update", 1);
        payload["PRO_TIPO_LAP"] = ApiTestData.Text("Produto PRO_TIPO_LAP Update", 1);
        payload["PRO_TAMANHO_LAP"] = 20.5m;
        payload["PRO_LAP_PROLONGADO"] = ApiTestData.Text("Produto PRO_LAP_PROLONGADO Update", 2);
        payload["PRO_TAMANHO_LAP_PROLONG"] = 20.5m;
        payload["PRO_ARRANJO_LARGURA"] = 20.5m;
        payload["PRO_ARRANJO_COMPRIMENTO"] = 20.5m;
        payload["PRO_FITILHOS_FARDO_LARG"] = 2;
        payload["PRO_FITILHOS_FARDO_COMP"] = 2;
        payload["PRO_FITILHOS_PALETE_LARG"] = 2;
        payload["PRO_FITILHOS_PALETE_COMP"] = 2;
        payload["PRO_FILME_PALETE"] = 2;
        payload["PRO_QTD_ESPELHO"] = 2;
        payload["PRO_CUSTO"] = 20.5m;
        payload["PRO_AREA_LIQUIDA"] = 20.5m;
        payload["PRO_PESO"] = 20.5m;
        payload["PRO_TOLERANCIA_DIMENSAO_CHAPA_DE"] = 2;
        payload["PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE"] = 2;
        payload["PRO_IMG_LASTRO"] = ApiTestData.Text("Produto PRO_IMG_LASTRO Update", 80);
        payload["ABN_ID"] = ApiTestData.Text("Produto ABN_ID Update", 50);
        payload["SEG_ID"] = 2;
        payload["PRO_RESINA"] = ApiTestData.Text("Produto PRO_RESINA Update", 1);
        payload["PRO_ENDURECEDOR_MIOLO"] = ApiTestData.Text("Produto PRO_ENDURECEDOR_MIOLO Update", 1);
        payload["PRO_VINCOS_ONDULADEIRA"] = ApiTestData.Text("Produto PRO_VINCOS_ONDULADEIRA Update", 80);
        payload["PRO_ADICIONAL_ABA_SUPERIOR"] = 2;
        payload["PRO_ADICIONAL_ABA_INFERIOR"] = 2;
        payload["PRO_PROMOVE_RESINA"] = ApiTestData.Text("Produto PRO_PROMOVE_RESINA Update", 1);
        payload["PRO_PROMOVE_DE"] = 20.5m;
        payload["PRO_PROMOVE_ATE"] = 20.5m;
        payload["PRO_PROFUNDIDADE_VINCO"] = 2;
        payload["VIN_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Vinco", "VIN_ID");
        payload["PRO_PROMOVE_PRODUTO"] = ApiTestData.Text("Produto PRO_PROMOVE_PRODUTO Update", 1);
        payload["PRO_TARA"] = 20.5m;
        payload["PRO_COMPRESSAO"] = 20.5m;
        payload["PRO_COD_BARRAS_CAIXA"] = ApiTestData.Text("Produto PRO_COD_BARRAS_CAIXA Update", 80);
        payload["CJN_ID"] = ApiTestData.Text("Produto CJN_ID Update", 30);
        payload["PRJ_ID"] = ApiTestData.Text("Produto PRJ_ID Update", 80);
        payload["PRO_REFILE_LARGURA"] = 2;
        payload["PRO_REFILE_COMPRIMENTO"] = 2;
        payload["PRO_M2_PONTA"] = 20.5m;
        payload["PRO_QTD_CORTES_PECA1"] = 2;
        payload["PRO_QTD_CORTES_PECA2"] = 2;
        payload["PRO_DIVISAO_MONTADA"] = ApiTestData.Text("Produto PRO_DIVISAO_MONTADA Update", 3);
        payload["PRO_SEGMENTO_A"] = 20.5m;
        payload["PRO_SEGMENTO_B"] = 20.5m;
        payload["PRO_SEGMENTO_C"] = 20.5m;
        payload["PRO_SEGMENTO_D"] = 20.5m;
        payload["PRO_SEGMENTO_E"] = 20.5m;
        payload["PRO_SEGMENTO_F"] = 20.5m;
        payload["PRO_SEGMENTO_G"] = 20.5m;
        payload["PRO_SEGMENTO_H"] = 20.5m;
        payload["PRO_SEGMENTO_I"] = 20.5m;
        payload["PRO_QTD_GRAMPOS"] = 20.5m;
        payload["PRO_AREA_REFILE_INTERNO"] = 20.5m;
        payload["PRO_AREA_REFILE_EXTERNO"] = 20.5m;
        payload["PRO_PESO_REFILE"] = 20.5m;
        payload["PRO_ORELHA_INVERTIDA"] = ApiTestData.Text("Produto PRO_ORELHA_INVERTIDA Update", 1);
        payload["PRO_ENDERECO"] = ApiTestData.Text("Produto PRO_ENDERECO Update", 30);
        payload["PRO_ID_VINCULADO"] = ApiTestData.Text("Produto PRO_ID_VINCULADO Update", 30);
        payload["PRO_BATIDAS_PROXIMA_MANUTENCAO"] = 2;
        payload["PRO_ENTRADA_NA_MAQUINA"] = ApiTestData.Text("Produto PRO_ENTRADA_NA_MAQUINA Update", 1);
        payload["TDI_ID"] = ApiTestData.Text("Produto TDI_ID Update", 30);
        payload["PRO_QUEBRA_VINCO"] = 2;
        payload["PRO_LARGURA_FARDO"] = 2;
        payload["PRO_COMPRIMENTO_FARDO"] = 2;
        payload["PRO_ALTURA_FARDO"] = 20.5m;
        payload["PRO_TIPO_CUSTO"] = ApiTestData.Text("Produto PRO_TIPO_CUSTO Update", 1);
        payload["PRO_GRUPO_CONTABIL"] = ApiTestData.Text("Produto PRO_GRUPO_CONTABIL Update", 60);
        payload["PRO_CLASSE_CUSTO_01"] = ApiTestData.Text("Produto PRO_CLASSE_CUSTO_01 Update", 60);
        payload["PRO_OBS_ALTERACAO"] = ApiTestData.Text("Produto PRO_OBS_ALTERACAO Update", 80);
        payload["TIP_ID"] = 2;
        payload["PRO_PECAS_POR_VEICULO"] = 20.5m;
        payload["PRO_DISTANCIA_ENTRE_VINCOS"] = 2;
        payload["PRO_DISTANCIA_ENTRE_VINCOS2"] = 2;
        payload["PRO_DISTANCIA_ENTRE_VINCOS3"] = 2;
        payload["PRO_OUT"] = 2;
        payload["PRO_ID_FACA"] = ApiTestData.Text("Produto PRO_ID_FACA Update", 30);
        payload["PRO_ID_CLICHE"] = ApiTestData.Text("Produto PRO_ID_CLICHE Update", 30);
        payload["PRO_ID_TINTA_01"] = ApiTestData.Text("Produto PRO_ID_TINTA_01 Update", 30);
        payload["PRO_ID_TINTA_02"] = ApiTestData.Text("Produto PRO_ID_TINTA_02 Update", 30);
        payload["PRO_ID_TINTA_03"] = ApiTestData.Text("Produto PRO_ID_TINTA_03 Update", 30);
        payload["PRO_ID_TINTA_04"] = ApiTestData.Text("Produto PRO_ID_TINTA_04 Update", 30);
        payload["PRO_ID_TINTA_05"] = ApiTestData.Text("Produto PRO_ID_TINTA_05 Update", 30);
        payload["PRO_ID_FORROSUP"] = ApiTestData.Text("Produto PRO_ID_FORROSUP Update", 30);
        payload["PRO_ID_CANTONEIRA"] = ApiTestData.Text("Produto PRO_ID_CANTONEIRA Update", 30);
        payload["PRO_ID_PALETE"] = ApiTestData.Text("Produto PRO_ID_PALETE Update", 30);
        payload["PRO_ID_TAMPO"] = ApiTestData.Text("Produto PRO_ID_TAMPO Update", 30);
        payload["PRO_ID_FORROINF"] = ApiTestData.Text("Produto PRO_ID_FORROINF Update", 30);
        payload["PRO_ID_CHAPA"] = ApiTestData.Text("Produto PRO_ID_CHAPA Update", 30);
        payload["PRO_ID_COMPOSICAO"] = ApiTestData.Text("Produto PRO_ID_COMPOSICAO Update", 30);
        payload["PRO_QUEBRA_VINCO_MAIOR"] = 2;
        payload["PRO_QUEBRA_VINCO_MENOR"] = 2;
        payload["CLI_ID"] = ApiTestData.Text("Produto CLI_ID Update", 30);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration