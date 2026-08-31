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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.Roteiro;

[SmokeTestOrder(182)]
public partial class RoteiroCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Roteiro/PostRoteiro";
    private const string ReadEndpoint = "yapi/Roteiro/ReadRoteiro";
    private const string UpdateEndpoint = "yapi/Roteiro/PutRoteiro";
    private const string DeleteEndpoint = "yapi/Roteiro/DeleteRoteiro";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Roteiro", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Roteiro", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("Roteiro", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Roteiro", out var deletePayload))
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
            ["MaquinaId"] = ApiSmokeTestContext.GetRequiredCreatedId("Maquina", "MaquinaId"),
            ["ProdutoId"] = ApiSmokeTestContext.GetRequiredCreatedId("Produto", "ProdutoId"),
            ["SequenciaTransformacao"] = 1,
            ["GrupoMaquinaId"] = ApiSmokeTestContext.GetRequiredCreatedId("GrupoMaquina", "GrupoMaquinaId"),
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
            ["TemplateDeTestesId"] = ApiSmokeTestContext.GetRequiredCreatedId("TemplateDeTestes", "TemplateDeTestesId"),
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
        payload["MaquinaId"] = ApiSmokeTestContext.GetRequiredCreatedId("Maquina", "MaquinaId");
        payload["ProdutoId"] = ApiSmokeTestContext.GetRequiredCreatedId("Produto", "ProdutoId");
        payload["SequenciaTransformacao"] = 2;
        payload["GrupoMaquinaId"] = ApiSmokeTestContext.GetRequiredCreatedId("GrupoMaquina", "GrupoMaquinaId");
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
        payload["TemplateDeTestesId"] = ApiSmokeTestContext.GetRequiredCreatedId("TemplateDeTestes", "TemplateDeTestesId");
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