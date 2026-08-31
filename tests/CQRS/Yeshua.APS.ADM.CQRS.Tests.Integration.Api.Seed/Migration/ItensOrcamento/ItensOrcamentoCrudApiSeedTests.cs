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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.ItensOrcamento;

[SeedTestOrder(176)]
public partial class ItensOrcamentoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/ItensOrcamento/PostItensOrcamento";
    private const string ReadEndpoint = "yapi/ItensOrcamento/ReadItensOrcamento";
    private const string UpdateEndpoint = "yapi/ItensOrcamento/PutItensOrcamento";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("ItensOrcamento", createdId);

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
            ["ORC_ID"] = 1,
            ["TIP_ID"] = 1,
            ["PRO_ID"] = ApiTestData.Text("ItensOrcamento PRO_ID", 30),
            ["ITO_OBS"] = ApiTestData.Text("ItensOrcamento ITO_OBS", 80),
            ["ITO_QUANTIDADE"] = 10.5m,
            ["ITO_CUSTO"] = 10.5m,
            ["ITO_MARGEM"] = 10.5m,
            ["ITO_VALOR_UNITARIO"] = 10.5m,
            ["ITO_VERSSAO_CUSTO"] = DateTime.UtcNow,
            ["ITO_STATUS"] = ApiTestData.Text("ItensOrcamento ITO_STATUS", 2),
            ["ITO_ERP_CUSTOS_FIXOS"] = 10.5m,
            ["ITO_ERP_CUSTOS_VARIAVEIS"] = 10.5m,
            ["ITO_ERP_DESPESAS_VAR_VENDA"] = 10.5m,
            ["ITO_ERP_IMPOSTOS"] = 10.5m,
            ["GRP_ID_COMPOSICAO"] = ApiSeedTestContext.GetRequiredCreatedId("GrupoProdutoAbstrato", "GRP_ID_COMPOSICAO"),
            ["ITO_LARGURA"] = 10.5m,
            ["ITO_COMPRIMENTO"] = 10.5m,
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
        payload["ORC_ID"] = 2;
        payload["TIP_ID"] = 2;
        payload["PRO_ID"] = ApiTestData.Text("ItensOrcamento PRO_ID Update", 30);
        payload["ITO_OBS"] = ApiTestData.Text("ItensOrcamento ITO_OBS Update", 80);
        payload["ITO_QUANTIDADE"] = 20.5m;
        payload["ITO_CUSTO"] = 20.5m;
        payload["ITO_MARGEM"] = 20.5m;
        payload["ITO_VALOR_UNITARIO"] = 20.5m;
        payload["ITO_VERSSAO_CUSTO"] = DateTime.UtcNow.AddMinutes(1);
        payload["ITO_STATUS"] = ApiTestData.Text("ItensOrcamento ITO_STATUS Update", 2);
        payload["ITO_ERP_CUSTOS_FIXOS"] = 20.5m;
        payload["ITO_ERP_CUSTOS_VARIAVEIS"] = 20.5m;
        payload["ITO_ERP_DESPESAS_VAR_VENDA"] = 20.5m;
        payload["ITO_ERP_IMPOSTOS"] = 20.5m;
        payload["GRP_ID_COMPOSICAO"] = ApiSeedTestContext.GetRequiredCreatedId("GrupoProdutoAbstrato", "GRP_ID_COMPOSICAO");
        payload["ITO_LARGURA"] = 20.5m;
        payload["ITO_COMPRIMENTO"] = 20.5m;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration