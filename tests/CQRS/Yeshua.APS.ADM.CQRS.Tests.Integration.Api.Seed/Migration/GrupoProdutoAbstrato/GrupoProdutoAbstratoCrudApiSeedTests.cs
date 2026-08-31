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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.GrupoProdutoAbstrato;

[SeedTestOrder(173)]
public partial class GrupoProdutoAbstratoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/GrupoProdutoAbstrato/PostGrupoProdutoAbstrato";
    private const string ReadEndpoint = "yapi/GrupoProdutoAbstrato/ReadGrupoProdutoAbstrato";
    private const string UpdateEndpoint = "yapi/GrupoProdutoAbstrato/PutGrupoProdutoAbstrato";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "grp_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("GrupoProdutoAbstrato", createdId);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "grp_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["GRP_ID"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_ID", 30),
            ["GRP_DESCRICAO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_DESCRICAO", 80),
            ["TEM_ID"] = 1,
            ["GRP_TIPO"] = 10.5m,
            ["GRP_PAP_ONDA"] = ApiSeedTestContext.GetRequiredCreatedId("Onda", "GRP_PAP_ONDA"),
            ["GRP_PAP_GRAMATURA"] = 10.5m,
            ["GRP_PAP_ALTURA"] = 10.5m,
            ["GRP_PAP_NOME_COMERCIAL"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PAP_NOME_COMERCIAL", 80),
            ["GRP_ATIVO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_ATIVO", 1),
            ["GRP_DT_CRIACAO"] = DateTime.UtcNow,
            ["GRP_PAPEL1"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PAPEL1", 30),
            ["GRP_PAPEL2"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PAPEL2", 30),
            ["GRP_PAPEL3"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PAPEL3", 30),
            ["GRP_PAPEL4"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PAPEL4", 30),
            ["GRP_PAPEL5"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PAPEL5", 30),
            ["GRP_ID_INTEGRACAO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_ID_INTEGRACAO", 80),
            ["GRP_ID_INTEGRACAO_ERP"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_ID_INTEGRACAO_ERP", 80),
            ["GRP_TYPE"] = 1,
            ["GRP_PERFORMANCE"] = 10.5m,
            ["GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO"] = 10.5m,
            ["GRP_RESINA"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_RESINA", 10),
            ["GRP_ENDURECEDOR_MIOLO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_ENDURECEDOR_MIOLO", 10),
            ["VIN_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Vinco", "VIN_ID"),
            ["GRP_COLUNA_DE"] = 10.5m,
            ["GRP_COLUNA_ATE"] = 10.5m,
            ["GRP_CRUSH"] = 10.5m,
            ["GRP_ID_FAMILIA"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_ID_FAMILIA", 30),
            ["GRP_REFILE_LARGURA"] = 10.5m,
            ["GRP_REFILE_COMPRIMENTO"] = 10.5m,
            ["GRP_TIPO_LAP"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_TIPO_LAP", 2),
            ["GRP_LAP_PROLONGADO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_LAP_PROLONGADO", 2),
            ["GRP_TAMANHO_LAP_OND_SIMPLES"] = 10.5m,
            ["GRP_TAMANHO_LAP_OND_DUPLA"] = 10.5m,
            ["GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES"] = 10.5m,
            ["GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA"] = 10.5m,
            ["GRP_FEFCO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_FEFCO", 30),
            ["GRP_TOLERANCIA_DIMENCAO_CHAPA_DE"] = 1,
            ["GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE"] = 1,
            ["GRP_PREFIXO_ID_PRODUTO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PREFIXO_ID_PRODUTO", 30),
            ["GRP_COLUNA_CAIXA"] = 10.5m,
            ["GRP_COLUNA_CHAPA"] = 10.5m,
            ["GRP_MULLEN"] = 10.5m,
            ["GRP_TENDENCIA_TOLERANCIA_PEDIDO"] = 1,
            ["GRP_PERCENTUAL_PERDA_MEDIA"] = 10.5m,
            ["GRP_FILTRA_SEQ_TRANS"] = 1,
            ["GRP_IMG_CAIXA"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_IMG_CAIXA", 80),
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["GRP_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["GRP_ID"] = id.DeepClone();
        payload["GRP_DESCRICAO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_DESCRICAO Update", 80);
        payload["TEM_ID"] = 2;
        payload["GRP_TIPO"] = 20.5m;
        payload["GRP_PAP_ONDA"] = ApiSeedTestContext.GetRequiredCreatedId("Onda", "GRP_PAP_ONDA");
        payload["GRP_PAP_GRAMATURA"] = 20.5m;
        payload["GRP_PAP_ALTURA"] = 20.5m;
        payload["GRP_PAP_NOME_COMERCIAL"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PAP_NOME_COMERCIAL Update", 80);
        payload["GRP_ATIVO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_ATIVO Update", 1);
        payload["GRP_DT_CRIACAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["GRP_PAPEL1"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PAPEL1 Update", 30);
        payload["GRP_PAPEL2"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PAPEL2 Update", 30);
        payload["GRP_PAPEL3"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PAPEL3 Update", 30);
        payload["GRP_PAPEL4"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PAPEL4 Update", 30);
        payload["GRP_PAPEL5"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PAPEL5 Update", 30);
        payload["GRP_ID_INTEGRACAO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_ID_INTEGRACAO Update", 80);
        payload["GRP_ID_INTEGRACAO_ERP"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_ID_INTEGRACAO_ERP Update", 80);
        payload["GRP_TYPE"] = 2;
        payload["GRP_PERFORMANCE"] = 20.5m;
        payload["GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO"] = 20.5m;
        payload["GRP_RESINA"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_RESINA Update", 10);
        payload["GRP_ENDURECEDOR_MIOLO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_ENDURECEDOR_MIOLO Update", 10);
        payload["VIN_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Vinco", "VIN_ID");
        payload["GRP_COLUNA_DE"] = 20.5m;
        payload["GRP_COLUNA_ATE"] = 20.5m;
        payload["GRP_CRUSH"] = 20.5m;
        payload["GRP_ID_FAMILIA"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_ID_FAMILIA Update", 30);
        payload["GRP_REFILE_LARGURA"] = 20.5m;
        payload["GRP_REFILE_COMPRIMENTO"] = 20.5m;
        payload["GRP_TIPO_LAP"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_TIPO_LAP Update", 2);
        payload["GRP_LAP_PROLONGADO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_LAP_PROLONGADO Update", 2);
        payload["GRP_TAMANHO_LAP_OND_SIMPLES"] = 20.5m;
        payload["GRP_TAMANHO_LAP_OND_DUPLA"] = 20.5m;
        payload["GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES"] = 20.5m;
        payload["GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA"] = 20.5m;
        payload["GRP_FEFCO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_FEFCO Update", 30);
        payload["GRP_TOLERANCIA_DIMENCAO_CHAPA_DE"] = 2;
        payload["GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE"] = 2;
        payload["GRP_PREFIXO_ID_PRODUTO"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_PREFIXO_ID_PRODUTO Update", 30);
        payload["GRP_COLUNA_CAIXA"] = 20.5m;
        payload["GRP_COLUNA_CHAPA"] = 20.5m;
        payload["GRP_MULLEN"] = 20.5m;
        payload["GRP_TENDENCIA_TOLERANCIA_PEDIDO"] = 2;
        payload["GRP_PERCENTUAL_PERDA_MEDIA"] = 20.5m;
        payload["GRP_FILTRA_SEQ_TRANS"] = 2;
        payload["GRP_IMG_CAIXA"] = ApiTestData.Text("GrupoProdutoAbstrato GRP_IMG_CAIXA Update", 80);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration