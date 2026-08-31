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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Colaborador;

[SeedTestOrder(141)]
public partial class ColaboradorCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Colaborador/PostColaborador";
    private const string ReadEndpoint = "yapi/Colaborador/ReadColaborador";
    private const string UpdateEndpoint = "yapi/Colaborador/PutColaborador";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "col_cpf");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("Colaborador", createdId);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "col_cpf");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["COL_CPF"] = ApiTestData.Text("Colaborador COL_CPF", 14),
            ["COL_NOME"] = ApiTestData.Text("Colaborador COL_NOME", 80),
            ["COL_NASCIMENTO"] = DateTime.UtcNow,
            ["COL_EMAIL"] = ApiTestData.Text("Colaborador COL_EMAIL", 80),
            ["COL_MATRICULA"] = ApiTestData.Text("Colaborador COL_MATRICULA", 10),
            ["TURM_id"] = ApiSeedTestContext.GetRequiredCreatedId("Turma", "TURM_id"),
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["COL_CPF"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["COL_CPF"] = id.DeepClone();
        payload["COL_NOME"] = ApiTestData.Text("Colaborador COL_NOME Update", 80);
        payload["COL_NASCIMENTO"] = DateTime.UtcNow.AddMinutes(1);
        payload["COL_EMAIL"] = ApiTestData.Text("Colaborador COL_EMAIL Update", 80);
        payload["COL_MATRICULA"] = ApiTestData.Text("Colaborador COL_MATRICULA Update", 10);
        payload["TURM_id"] = ApiSeedTestContext.GetRequiredCreatedId("Turma", "TURM_id");
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration