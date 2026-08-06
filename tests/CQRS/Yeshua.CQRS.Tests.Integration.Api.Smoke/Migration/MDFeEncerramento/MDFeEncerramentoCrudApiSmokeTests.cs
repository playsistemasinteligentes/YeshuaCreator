using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.CQRS.Tests.Integration.Api.Smoke.Migration.MDFeEncerramento;

[SmokeTestOrder(2)]
public partial class MDFeEncerramentoCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "/yapi/MDFeEncerramento/PostMDFeEncerramento";
    private const string ReadEndpoint = "/yapi/MDFeEncerramento/ReadMDFeEncerramento";
    private const string UpdateEndpoint = "/yapi/MDFeEncerramento/PutMDFeEncerramento";
    private const string DeleteEndpoint = "/yapi/MDFeEncerramento/DeleteMDFeEncerramento";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("MDFeEncerramento", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("MDFeEncerramento", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("MDFeEncerramento", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("MDFeEncerramento", out var deletePayload))
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
            ["MDFeId"] = ApiSmokeTestContext.GetRequiredCreatedId("MDFe", "MDFeId"),
            ["ChaveAcesso"] = ApiTestData.Text("MDFeEncerramento ChaveAcesso", 44),
            ["UfCarregamento"] = ApiTestData.Text("MDFeEncerramento UfCarregamento", 2),
            ["UfDescarregamento"] = ApiTestData.Text("MDFeEncerramento UfDescarregamento", 2),
            ["PlacaVeiculo"] = ApiTestData.Text("MDFeEncerramento PlacaVeiculo", 7),
            ["SolicitadoEm"] = DateTime.UtcNow,
            ["AutorizadoEm"] = DateTime.UtcNow,
            ["Protocolo"] = ApiTestData.Text("MDFeEncerramento Protocolo", 20),
            ["CodigoRetorno"] = ApiTestData.Text("MDFeEncerramento CodigoRetorno", 10),
            ["MensagemRetorno"] = ApiTestData.Text("MDFeEncerramento MensagemRetorno", 80),
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
        payload["MDFeId"] = ApiSmokeTestContext.GetRequiredCreatedId("MDFe", "MDFeId");
        payload["ChaveAcesso"] = ApiTestData.Text("MDFeEncerramento ChaveAcesso Update", 44);
        payload["UfCarregamento"] = ApiTestData.Text("MDFeEncerramento UfCarregamento Update", 2);
        payload["UfDescarregamento"] = ApiTestData.Text("MDFeEncerramento UfDescarregamento Update", 2);
        payload["PlacaVeiculo"] = ApiTestData.Text("MDFeEncerramento PlacaVeiculo Update", 7);
        payload["SolicitadoEm"] = DateTime.UtcNow.AddMinutes(1);
        payload["AutorizadoEm"] = DateTime.UtcNow.AddMinutes(1);
        payload["Protocolo"] = ApiTestData.Text("MDFeEncerramento Protocolo Update", 20);
        payload["CodigoRetorno"] = ApiTestData.Text("MDFeEncerramento CodigoRetorno Update", 10);
        payload["MensagemRetorno"] = ApiTestData.Text("MDFeEncerramento MensagemRetorno Update", 80);
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