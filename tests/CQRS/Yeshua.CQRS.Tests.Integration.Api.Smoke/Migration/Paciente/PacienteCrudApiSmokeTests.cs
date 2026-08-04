using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.CQRS.Tests.Integration.Api.Smoke.Migration.Paciente;

[SmokeTestOrder(4)]
public partial class PacienteCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "/yapi/Paciente/PostPaciente";
    private const string ReadEndpoint = "/yapi/Paciente/ReadPaciente";
    private const string UpdateEndpoint = "/yapi/Paciente/PutPaciente";
    private const string DeleteEndpoint = "/yapi/Paciente/DeletePaciente";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Paciente", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Paciente", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("Paciente", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Paciente", out var deletePayload))
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
            ["Nome"] = ApiTestData.Text("Paciente Nome", 80),
            ["Telefone"] = ApiTestData.Text("Paciente Telefone", 20),
            ["DataNascimento"] = DateTime.UtcNow,
            ["Genero"] = 1,
            ["Escolaridade"] = ApiTestData.Text("Paciente Escolaridade", 60),
            ["Profissao"] = ApiTestData.Text("Paciente Profissao", 60),
            ["Endereco"] = ApiTestData.Text("Paciente Endereco", 80),
            ["NomeResponsavel"] = ApiTestData.Text("Paciente NomeResponsavel", 80),
            ["TelefoneResponsavel"] = ApiTestData.Text("Paciente TelefoneResponsavel", 15),
            ["Observacao"] = ApiTestData.Text("Paciente Observacao", 80),
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
        payload["Nome"] = ApiTestData.Text("Paciente Nome Update", 80);
        payload["Telefone"] = ApiTestData.Text("Paciente Telefone Update", 20);
        payload["DataNascimento"] = DateTime.UtcNow.AddMinutes(1);
        payload["Genero"] = 1;
        payload["Escolaridade"] = ApiTestData.Text("Paciente Escolaridade Update", 60);
        payload["Profissao"] = ApiTestData.Text("Paciente Profissao Update", 60);
        payload["Endereco"] = ApiTestData.Text("Paciente Endereco Update", 80);
        payload["NomeResponsavel"] = ApiTestData.Text("Paciente NomeResponsavel Update", 80);
        payload["TelefoneResponsavel"] = ApiTestData.Text("Paciente TelefoneResponsavel Update", 15);
        payload["Observacao"] = ApiTestData.Text("Paciente Observacao Update", 80);
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
