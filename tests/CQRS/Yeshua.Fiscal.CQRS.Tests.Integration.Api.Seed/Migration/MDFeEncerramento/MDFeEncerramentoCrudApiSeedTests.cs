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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Seed.Migration.MDFeEncerramento;

[SeedTestOrder(18)]
public partial class MDFeEncerramentoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/MDFeEncerramento/PostMDFeEncerramento";
    private const string ReadEndpoint = "yapi/MDFeEncerramento/ReadMDFeEncerramento";
    private const string UpdateEndpoint = "yapi/MDFeEncerramento/PutMDFeEncerramento";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("MDFeEncerramento", createdId);

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
            ["MDFeId"] = ApiSeedTestContext.GetRequiredCreatedId("MDFe", "MDFeId"),
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
        payload["MDFeId"] = ApiSeedTestContext.GetRequiredCreatedId("MDFe", "MDFeId");
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

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration