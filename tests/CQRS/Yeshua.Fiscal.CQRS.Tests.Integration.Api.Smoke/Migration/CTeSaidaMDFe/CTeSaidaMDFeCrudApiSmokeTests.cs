// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration
// </yeshua>

using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.CTeSaidaMDFe;

[SmokeTestOrder(10)]
public partial class CTeSaidaMDFeCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/CTeSaidaMDFe/PostCTeSaidaMDFe";
    private const string ReadEndpoint = "yapi/CTeSaidaMDFe/ReadCTeSaidaMDFe";
    private const string UpdateEndpoint = "yapi/CTeSaidaMDFe/PutCTeSaidaMDFe";
    private const string DeleteEndpoint = "yapi/CTeSaidaMDFe/DeleteCTeSaidaMDFe";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("CTeSaidaMDFe", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("CTeSaidaMDFe", initialDeletePayload);

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

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("CTeSaidaMDFe", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("CTeSaidaMDFe", out var deletePayload))
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
            ["CTeTentativaEmissaoId"] = ApiSmokeTestContext.GetRequiredCreatedId("CTeTentativaEmissao", "CTeTentativaEmissaoId"),
            ["CorrelationId"] = ApiTestData.Text("CTeSaidaMDFe CorrelationId", 80),
            ["ChaveAcessoCTe"] = ApiTestData.Text("CTeSaidaMDFe ChaveAcessoCTe", 44),
            ["SnapshotHash"] = ApiTestData.Text("CTeSaidaMDFe SnapshotHash", 80),
            ["OutboxMessageId"] = ApiTestData.Text("CTeSaidaMDFe OutboxMessageId", 80),
            ["PublicadoEmUtc"] = DateTime.UtcNow,
            ["UltimoErro"] = ApiTestData.Text("CTeSaidaMDFe UltimoErro", 80),
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
        payload["CTeTentativaEmissaoId"] = ApiSmokeTestContext.GetRequiredCreatedId("CTeTentativaEmissao", "CTeTentativaEmissaoId");
        payload["CorrelationId"] = ApiTestData.Text("CTeSaidaMDFe CorrelationId Update", 80);
        payload["ChaveAcessoCTe"] = ApiTestData.Text("CTeSaidaMDFe ChaveAcessoCTe Update", 44);
        payload["SnapshotHash"] = ApiTestData.Text("CTeSaidaMDFe SnapshotHash Update", 80);
        payload["OutboxMessageId"] = ApiTestData.Text("CTeSaidaMDFe OutboxMessageId Update", 80);
        payload["PublicadoEmUtc"] = DateTime.UtcNow.AddMinutes(1);
        payload["UltimoErro"] = ApiTestData.Text("CTeSaidaMDFe UltimoErro Update", 80);
        payload["Status"] = 1;
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
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration