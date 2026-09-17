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

namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Seed.Migration.MovimentacaoFinanceira;

[SeedTestOrder(8)]
public partial class MovimentacaoFinanceiraCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/MovimentacaoFinanceira/PostMovimentacaoFinanceira";
    private const string ReadEndpoint = "yapi/MovimentacaoFinanceira/ReadMovimentacaoFinanceira";
    private const string UpdateEndpoint = "yapi/MovimentacaoFinanceira/PutMovimentacaoFinanceira";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("MovimentacaoFinanceira", createdId);

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
            ["PacienteId"] = ApiSeedTestContext.GetRequiredCreatedId("Paciente", "PacienteId"),
            ["ServicoId"] = ApiSeedTestContext.GetRequiredCreatedId("Servico", "ServicoId"),
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
        payload["PacienteId"] = ApiSeedTestContext.GetRequiredCreatedId("Paciente", "PacienteId");
        payload["ServicoId"] = ApiSeedTestContext.GetRequiredCreatedId("Servico", "ServicoId");
        payload["Valor"] = 20.5m;
        payload["TipoMovimentacao"] = 1;
        payload["DataMovimentacao"] = DateTime.UtcNow.AddMinutes(1);
        payload["SaldoAtual"] = 20.5m;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration