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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.TipoVeiculo;

[SmokeTestOrder(94)]
public partial class TipoVeiculoCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/TipoVeiculo/PostTipoVeiculo";
    private const string ReadEndpoint = "yapi/TipoVeiculo/ReadTipoVeiculo";
    private const string UpdateEndpoint = "yapi/TipoVeiculo/PutTipoVeiculo";
    private const string DeleteEndpoint = "yapi/TipoVeiculo/DeleteTipoVeiculo";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("TipoVeiculo", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("TipoVeiculo", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("TipoVeiculo", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("TipoVeiculo", out var deletePayload))
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
            ["TIP_ID"] = 1,
            ["TIP_DESCRICAO"] = ApiTestData.Text("TipoVeiculo TIP_DESCRICAO", 80),
            ["TIP_QTD_DISPONIVEL"] = 1,
            ["TIP_VALOR_KM"] = 10.5m,
            ["TIP_VALOR_DIARIA"] = 10.5m,
            ["TIP_VALOR_AJUDANTE"] = 10.5m,
            ["TIP_QTD_EIXOS"] = 10.5m,
            ["TIP_VELOCIDADE_MEDIA"] = 10.5m,
            ["TIP_CAPACIDADE_ALTURA"] = 10.5m,
            ["TIP_CAPACIDADE_COMPRIMENTO"] = 10.5m,
            ["TIP_CAPACIDADE_LARGURA"] = 10.5m,
            ["TIP_CAPACIDADE_ALTURA_PESCOCO_E"] = 10.5m,
            ["TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E"] = 10.5m,
            ["TIP_CAPACIDADE_LARGURA_PESCOCO_E"] = 10.5m,
            ["TIP_CAPACIDADE_ALTURA_PESCOCO_D"] = 10.5m,
            ["TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D"] = 10.5m,
            ["TIP_CAPACIDADE_LARGURA_PESCOCO_D"] = 10.5m,
            ["TIP_CAPACIDADE_M3"] = 10.5m,
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
        payload["TIP_ID"] = 2;
        payload["TIP_DESCRICAO"] = ApiTestData.Text("TipoVeiculo TIP_DESCRICAO Update", 80);
        payload["TIP_QTD_DISPONIVEL"] = 2;
        payload["TIP_VALOR_KM"] = 20.5m;
        payload["TIP_VALOR_DIARIA"] = 20.5m;
        payload["TIP_VALOR_AJUDANTE"] = 20.5m;
        payload["TIP_QTD_EIXOS"] = 20.5m;
        payload["TIP_VELOCIDADE_MEDIA"] = 20.5m;
        payload["TIP_CAPACIDADE_ALTURA"] = 20.5m;
        payload["TIP_CAPACIDADE_COMPRIMENTO"] = 20.5m;
        payload["TIP_CAPACIDADE_LARGURA"] = 20.5m;
        payload["TIP_CAPACIDADE_ALTURA_PESCOCO_E"] = 20.5m;
        payload["TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E"] = 20.5m;
        payload["TIP_CAPACIDADE_LARGURA_PESCOCO_E"] = 20.5m;
        payload["TIP_CAPACIDADE_ALTURA_PESCOCO_D"] = 20.5m;
        payload["TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D"] = 20.5m;
        payload["TIP_CAPACIDADE_LARGURA_PESCOCO_D"] = 20.5m;
        payload["TIP_CAPACIDADE_M3"] = 20.5m;
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