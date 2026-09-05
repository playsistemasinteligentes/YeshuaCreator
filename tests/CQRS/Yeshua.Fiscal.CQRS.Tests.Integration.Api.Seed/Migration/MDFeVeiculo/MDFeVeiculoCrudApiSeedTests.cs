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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Seed.Migration.MDFeVeiculo;

[SeedTestOrder(15)]
public partial class MDFeVeiculoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/MDFeVeiculo/PostMDFeVeiculo";
    private const string ReadEndpoint = "yapi/MDFeVeiculo/ReadMDFeVeiculo";
    private const string UpdateEndpoint = "yapi/MDFeVeiculo/PutMDFeVeiculo";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("MDFeVeiculo", createdId);

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
            ["MDFeSolicitacaoFiscalId"] = ApiSeedTestContext.GetRequiredCreatedId("MDFeSolicitacaoFiscal", "MDFeSolicitacaoFiscalId"),
            ["Placa"] = ApiTestData.Text("MDFeVeiculo Placa", 7),
            ["Renavam"] = ApiTestData.Text("MDFeVeiculo Renavam", 20),
            ["Tara"] = 10.5m,
            ["CapacidadeKg"] = 10.5m,
            ["CapacidadeM3"] = 10.5m,
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
        payload["MDFeSolicitacaoFiscalId"] = ApiSeedTestContext.GetRequiredCreatedId("MDFeSolicitacaoFiscal", "MDFeSolicitacaoFiscalId");
        payload["Placa"] = ApiTestData.Text("MDFeVeiculo Placa Update", 7);
        payload["Renavam"] = ApiTestData.Text("MDFeVeiculo Renavam Update", 20);
        payload["Tara"] = 20.5m;
        payload["CapacidadeKg"] = 20.5m;
        payload["CapacidadeM3"] = 20.5m;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration