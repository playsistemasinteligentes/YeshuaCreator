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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Usuario;

[SeedTestOrder(104)]
public partial class UsuarioCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Usuario/PostUsuario";
    private const string ReadEndpoint = "yapi/Usuario/ReadUsuario";
    private const string UpdateEndpoint = "yapi/Usuario/PutUsuario";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "use_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Usuario", createdId);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "use_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["USE_NOME"] = ApiTestData.Text("Usuario USE_NOME", 80),
            ["USE_EMAIL"] = ApiTestData.Text("Usuario USE_EMAIL", 80),
            ["USE_SENHA"] = ApiTestData.Text("Usuario USE_SENHA", 50),
            ["TURM_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turma", "TURM_ID"),
            ["USE_ATIVO"] = 1,
            ["USE_CODERP"] = ApiTestData.Text("Usuario USE_CODERP", 80),
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["USE_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["USE_ID"] = id.DeepClone();
        payload["USE_NOME"] = ApiTestData.Text("Usuario USE_NOME Update", 80);
        payload["USE_EMAIL"] = ApiTestData.Text("Usuario USE_EMAIL Update", 80);
        payload["USE_SENHA"] = ApiTestData.Text("Usuario USE_SENHA Update", 50);
        payload["TURM_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Turma", "TURM_ID");
        payload["USE_ATIVO"] = 2;
        payload["USE_CODERP"] = ApiTestData.Text("Usuario USE_CODERP Update", 80);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration