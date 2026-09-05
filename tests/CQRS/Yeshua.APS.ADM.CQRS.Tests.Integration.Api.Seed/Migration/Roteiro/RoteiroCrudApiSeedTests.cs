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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Roteiro;

[SeedTestOrder(182)]
public partial class RoteiroCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Roteiro/PostRoteiro";
    private const string ReadEndpoint = "yapi/Roteiro/ReadRoteiro";
    private const string UpdateEndpoint = "yapi/Roteiro/PutRoteiro";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Roteiro", createdId);

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
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["MaquinaId"] = ApiSeedTestContext.GetRequiredCreatedId("Maquina", "MaquinaId"),
            ["ProdutoId"] = ApiSeedTestContext.GetRequiredCreatedId("Produto", "ProdutoId"),
            ["SequenciaTransformacao"] = 1,
            ["GrupoMaquinaId"] = ApiSeedTestContext.GetRequiredCreatedId("GrupoMaquina", "GrupoMaquinaId"),
            ["PecasPorPulso"] = 10.5m,
            ["PrioridadeInformada"] = 10.5m,
            ["Acao"] = ApiTestData.Text("Roteiro Acao", 2),
            ["Performance"] = 10.5m,
            ["TempoSetup"] = 10.5m,
            ["TempoSetupAjuste"] = 10.5m,
            ["ProximaSequenciaTransformacao"] = 1,
            ["Status"] = ApiTestData.Text("Roteiro Status", 2),
            ["HierarquiaSequenciaTransformacao"] = 10.5m,
            ["AvaliaCusto"] = 1,
            ["Operacoes"] = ApiTestData.Text("Roteiro Operacoes", 80),
            ["ExcecaoOperacoes"] = ApiTestData.Text("Roteiro ExcecaoOperacoes", 80),
            ["PercentualInicioPassoAnterior"] = 10.5m,
            ["LinhaDireta"] = ApiTestData.Text("Roteiro LinhaDireta", 2),
            ["TemplateDeTestesId"] = ApiSeedTestContext.GetRequiredCreatedId("TemplateDeTestes", "TemplateDeTestesId"),
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
        payload["MaquinaId"] = ApiSeedTestContext.GetRequiredCreatedId("Maquina", "MaquinaId");
        payload["ProdutoId"] = ApiSeedTestContext.GetRequiredCreatedId("Produto", "ProdutoId");
        payload["SequenciaTransformacao"] = 2;
        payload["GrupoMaquinaId"] = ApiSeedTestContext.GetRequiredCreatedId("GrupoMaquina", "GrupoMaquinaId");
        payload["PecasPorPulso"] = 20.5m;
        payload["PrioridadeInformada"] = 20.5m;
        payload["Acao"] = ApiTestData.Text("Roteiro Acao Update", 2);
        payload["Performance"] = 20.5m;
        payload["TempoSetup"] = 20.5m;
        payload["TempoSetupAjuste"] = 20.5m;
        payload["ProximaSequenciaTransformacao"] = 2;
        payload["Status"] = ApiTestData.Text("Roteiro Status Update", 2);
        payload["HierarquiaSequenciaTransformacao"] = 20.5m;
        payload["AvaliaCusto"] = 2;
        payload["Operacoes"] = ApiTestData.Text("Roteiro Operacoes Update", 80);
        payload["ExcecaoOperacoes"] = ApiTestData.Text("Roteiro ExcecaoOperacoes Update", 80);
        payload["PercentualInicioPassoAnterior"] = 20.5m;
        payload["LinhaDireta"] = ApiTestData.Text("Roteiro LinhaDireta Update", 2);
        payload["TemplateDeTestesId"] = ApiSeedTestContext.GetRequiredCreatedId("TemplateDeTestes", "TemplateDeTestesId");
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration