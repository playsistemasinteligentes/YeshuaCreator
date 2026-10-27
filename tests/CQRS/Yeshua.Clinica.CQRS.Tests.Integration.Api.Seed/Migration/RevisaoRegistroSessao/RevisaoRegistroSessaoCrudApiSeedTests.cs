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

namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Seed.Migration.RevisaoRegistroSessao;

[SeedTestOrder(29)]
public partial class RevisaoRegistroSessaoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/RevisaoRegistroSessao/PostRevisaoRegistroSessao";
    private const string ReadEndpoint = "yapi/RevisaoRegistroSessao/ReadRevisaoRegistroSessao";
    private const string UpdateEndpoint = "yapi/RevisaoRegistroSessao/PutRevisaoRegistroSessao";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();
        Task? customExecution = null;
        CustomizeExecution(client, ref customExecution);
        if (customExecution != null) { await customExecution; return; }

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("RevisaoRegistroSessao", createdId);

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
            ["SessaoId"] = ApiSeedTestContext.GetRequiredCreatedId("Sesoes", "SessaoId"),
            ["Versao"] = 1,
            ["AutorUserId"] = ApiSeedTestContext.GetRequiredCreatedId("yUser", "AutorUserId"),
            ["RevisadoEm"] = DateTime.UtcNow,
            ["Motivo"] = ApiTestData.Text("RevisaoRegistroSessao Motivo", 80),
            ["Registro"] = ApiTestData.Text("RevisaoRegistroSessao Registro", 80),
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
        payload["SessaoId"] = ApiSeedTestContext.GetRequiredCreatedId("Sesoes", "SessaoId");
        payload["Versao"] = 2;
        payload["AutorUserId"] = ApiSeedTestContext.GetRequiredCreatedId("yUser", "AutorUserId");
        payload["RevisadoEm"] = DateTime.UtcNow.AddMinutes(1);
        payload["Motivo"] = ApiTestData.Text("RevisaoRegistroSessao Motivo Update", 80);
        payload["Registro"] = ApiTestData.Text("RevisaoRegistroSessao Registro Update", 80);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeExecution(HttpClient client, ref Task? execution);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration