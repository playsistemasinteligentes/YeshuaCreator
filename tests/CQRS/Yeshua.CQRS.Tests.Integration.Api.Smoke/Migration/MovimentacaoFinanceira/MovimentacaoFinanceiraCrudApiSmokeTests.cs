using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.CQRS.Tests.Integration.Api.Smoke.Migration.MovimentacaoFinanceira;

[SmokeTestOrder(17)]
public partial class MovimentacaoFinanceiraCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "/yapi/MovimentacaoFinanceira/PostMovimentacaoFinanceira";
    private const string ReadEndpoint = "/yapi/MovimentacaoFinanceira/ReadMovimentacaoFinanceira";
    private const string UpdateEndpoint = "/yapi/MovimentacaoFinanceira/PutMovimentacaoFinanceira";
    private const string DeleteEndpoint = "/yapi/MovimentacaoFinanceira/DeleteMovimentacaoFinanceira";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("MovimentacaoFinanceira", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("MovimentacaoFinanceira", initialDeletePayload);

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        ApiResponseAssertions.AssertReadContainsId(readState, createdId);

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("MovimentacaoFinanceira", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("MovimentacaoFinanceira", out var deletePayload))
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
            ["PacienteId"] = ApiSmokeTestContext.GetRequiredCreatedId("Paciente", "PacienteId"),
            ["ServicoId"] = ApiSmokeTestContext.GetRequiredCreatedId("Servico", "ServicoId"),
            ["Valor"] = 10.5m,
            ["TipoMovimentacao"] = 1,
            ["DataMovimentacao"] = DateTime.UtcNow,
            ["SaldoAtual"] = 10.5m,
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
        payload["PacienteId"] = ApiSmokeTestContext.GetRequiredCreatedId("Paciente", "PacienteId");
        payload["ServicoId"] = ApiSmokeTestContext.GetRequiredCreatedId("Servico", "ServicoId");
        payload["Valor"] = 20.5m;
        payload["TipoMovimentacao"] = 1;
        payload["DataMovimentacao"] = DateTime.UtcNow.AddMinutes(1);
        payload["SaldoAtual"] = 20.5m;
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
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration
