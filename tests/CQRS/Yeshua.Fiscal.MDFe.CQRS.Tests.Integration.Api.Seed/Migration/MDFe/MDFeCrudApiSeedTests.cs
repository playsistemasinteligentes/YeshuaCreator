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

namespace Yeshua.Fiscal.MDFe.CQRS.Tests.Integration.Api.Seed.Migration.MDFe;

[SeedTestOrder(1)]
public partial class MDFeCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/MDFe/PostMDFe";
    private const string ReadEndpoint = "yapi/MDFe/ReadMDFe";
    private const string UpdateEndpoint = "yapi/MDFe/PutMDFe";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("MDFe", createdId);

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
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["ChaveAcesso"] = ApiTestData.Text("MDFe ChaveAcesso", 44),
            ["Serie"] = 1,
            ["Numero"] = 1,
            ["UfCarregamento"] = ApiTestData.Text("MDFe UfCarregamento", 2),
            ["UfDescarregamento"] = ApiTestData.Text("MDFe UfDescarregamento", 2),
            ["PlacaVeiculo"] = ApiTestData.Text("MDFe PlacaVeiculo", 7),
            ["EmitidoEm"] = DateTime.UtcNow,
            ["AutorizadoEm"] = DateTime.UtcNow,
            ["IniciadoEm"] = DateTime.UtcNow,
            ["EncerradoEm"] = DateTime.UtcNow,
            ["CanceladoEm"] = DateTime.UtcNow,
            ["Situacao"] = 1,
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
        payload["ChaveAcesso"] = ApiTestData.Text("MDFe ChaveAcesso Update", 44);
        payload["Serie"] = 2;
        payload["Numero"] = 2;
        payload["UfCarregamento"] = ApiTestData.Text("MDFe UfCarregamento Update", 2);
        payload["UfDescarregamento"] = ApiTestData.Text("MDFe UfDescarregamento Update", 2);
        payload["PlacaVeiculo"] = ApiTestData.Text("MDFe PlacaVeiculo Update", 7);
        payload["EmitidoEm"] = DateTime.UtcNow.AddMinutes(1);
        payload["AutorizadoEm"] = DateTime.UtcNow.AddMinutes(1);
        payload["IniciadoEm"] = DateTime.UtcNow.AddMinutes(1);
        payload["EncerradoEm"] = DateTime.UtcNow.AddMinutes(1);
        payload["CanceladoEm"] = DateTime.UtcNow.AddMinutes(1);
        payload["Situacao"] = 1;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration