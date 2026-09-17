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

namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Seed.Migration.MovimentoFinanceiro;

[SeedTestOrder(11)]
public partial class MovimentoFinanceiroCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/MovimentoFinanceiro/PostMovimentoFinanceiro";
    private const string ReadEndpoint = "yapi/MovimentoFinanceiro/ReadMovimentoFinanceiro";
    private const string UpdateEndpoint = "yapi/MovimentoFinanceiro/PutMovimentoFinanceiro";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("MovimentoFinanceiro", createdId);

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
            ["IdOrigem"] = ApiTestData.Text("MovimentoFinanceiro IdOrigem", 80),
            ["ContaDebitoId"] = ApiSeedTestContext.GetRequiredCreatedId("PlanoConta", "ContaDebitoId"),
            ["Valor"] = 10.5m,
            ["DataMovimento"] = DateTime.UtcNow,
            ["DataVencimento"] = DateTime.UtcNow,
            ["Status"] = 1,
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
        payload["IdOrigem"] = ApiTestData.Text("MovimentoFinanceiro IdOrigem Update", 80);
        payload["ContaDebitoId"] = ApiSeedTestContext.GetRequiredCreatedId("PlanoConta", "ContaDebitoId");
        payload["Valor"] = 20.5m;
        payload["DataMovimento"] = DateTime.UtcNow.AddMinutes(1);
        payload["DataVencimento"] = DateTime.UtcNow.AddMinutes(1);
        payload["Status"] = 1;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration