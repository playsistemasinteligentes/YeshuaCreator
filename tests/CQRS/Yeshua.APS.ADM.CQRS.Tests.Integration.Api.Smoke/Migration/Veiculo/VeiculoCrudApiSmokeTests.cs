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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.Veiculo;

[SmokeTestOrder(110)]
public partial class VeiculoCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Veiculo/PostVeiculo";
    private const string ReadEndpoint = "yapi/Veiculo/ReadVeiculo";
    private const string UpdateEndpoint = "yapi/Veiculo/PutVeiculo";
    private const string DeleteEndpoint = "yapi/Veiculo/DeleteVeiculo";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Veiculo", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Veiculo", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("Veiculo", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Veiculo", out var deletePayload))
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
            ["VEI_PLACA"] = ApiTestData.Text("Veiculo VEI_PLACA", 8),
            ["TIP_ID"] = 1,
            ["VEI_CAPACIDADE_M3"] = 10.5m,
            ["VEI_CAPACIDADE_LARGURA"] = 10.5m,
            ["VEI_CAPACIDADE_COMPRIMENTO"] = 10.5m,
            ["VEI_CAPACIDADE_ALTURA"] = 10.5m,
            ["VEI_MODELO"] = ApiTestData.Text("Veiculo VEI_MODELO", 60),
            ["VEI_NOME_MOTORISTA"] = ApiTestData.Text("Veiculo VEI_NOME_MOTORISTA", 80),
            ["VEI_DADOS_CONTATO"] = ApiTestData.Text("Veiculo VEI_DADOS_CONTATO", 80),
            ["VEI_CPF_MOTORISTA"] = ApiTestData.Text("Veiculo VEI_CPF_MOTORISTA", 11),
            ["TCA_ID"] = ApiTestData.Text("Veiculo TCA_ID", 30),
            ["VEI_EMISSAO"] = DateTime.UtcNow,
            ["VEI_VENCIMENTO"] = DateTime.UtcNow,
            ["VEI_STATUS"] = ApiTestData.Text("Veiculo VEI_STATUS", 2),
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
        payload["VEI_PLACA"] = ApiTestData.Text("Veiculo VEI_PLACA Update", 8);
        payload["TIP_ID"] = 2;
        payload["VEI_CAPACIDADE_M3"] = 20.5m;
        payload["VEI_CAPACIDADE_LARGURA"] = 20.5m;
        payload["VEI_CAPACIDADE_COMPRIMENTO"] = 20.5m;
        payload["VEI_CAPACIDADE_ALTURA"] = 20.5m;
        payload["VEI_MODELO"] = ApiTestData.Text("Veiculo VEI_MODELO Update", 60);
        payload["VEI_NOME_MOTORISTA"] = ApiTestData.Text("Veiculo VEI_NOME_MOTORISTA Update", 80);
        payload["VEI_DADOS_CONTATO"] = ApiTestData.Text("Veiculo VEI_DADOS_CONTATO Update", 80);
        payload["VEI_CPF_MOTORISTA"] = ApiTestData.Text("Veiculo VEI_CPF_MOTORISTA Update", 11);
        payload["TCA_ID"] = ApiTestData.Text("Veiculo TCA_ID Update", 30);
        payload["VEI_EMISSAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["VEI_VENCIMENTO"] = DateTime.UtcNow.AddMinutes(1);
        payload["VEI_STATUS"] = ApiTestData.Text("Veiculo VEI_STATUS Update", 2);
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