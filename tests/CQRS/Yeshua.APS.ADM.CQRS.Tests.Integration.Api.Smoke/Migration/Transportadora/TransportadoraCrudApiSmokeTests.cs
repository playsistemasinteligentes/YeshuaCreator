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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.Transportadora;

[SmokeTestOrder(99)]
public partial class TransportadoraCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Transportadora/PostTransportadora";
    private const string ReadEndpoint = "yapi/Transportadora/ReadTransportadora";
    private const string UpdateEndpoint = "yapi/Transportadora/PutTransportadora";
    private const string DeleteEndpoint = "yapi/Transportadora/DeleteTransportadora";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Transportadora", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Transportadora", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("Transportadora", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Transportadora", out var deletePayload))
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
            ["TRA_ID"] = ApiTestData.Text("Transportadora TRA_ID", 30),
            ["TRA_NOME"] = ApiTestData.Text("Transportadora TRA_NOME", 80),
            ["TRA_CNPJ"] = ApiTestData.Text("Transportadora TRA_CNPJ", 14),
            ["TRA_INSCRICAO_ESTADUAL"] = ApiTestData.Text("Transportadora TRA_INSCRICAO_ESTADUAL", 20),
            ["TRA_RNTRC"] = ApiTestData.Text("Transportadora TRA_RNTRC", 20),
            ["TRA_EMAIL"] = ApiTestData.Text("Transportadora TRA_EMAIL", 80),
            ["TRA_RESPONSAVEL"] = ApiTestData.Text("Transportadora TRA_RESPONSAVEL", 80),
            ["TRA_FONE"] = ApiTestData.Text("Transportadora TRA_FONE", 15),
            ["TRA_ID_INTEGRACAO"] = ApiTestData.Text("Transportadora TRA_ID_INTEGRACAO", 80),
            ["TRA_ID_INTEGRACAO_ERP"] = ApiTestData.Text("Transportadora TRA_ID_INTEGRACAO_ERP", 80),
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
        payload["TRA_ID"] = ApiTestData.Text("Transportadora TRA_ID Update", 30);
        payload["TRA_NOME"] = ApiTestData.Text("Transportadora TRA_NOME Update", 80);
        payload["TRA_CNPJ"] = ApiTestData.Text("Transportadora TRA_CNPJ Update", 14);
        payload["TRA_INSCRICAO_ESTADUAL"] = ApiTestData.Text("Transportadora TRA_INSCRICAO_ESTADUAL Update", 20);
        payload["TRA_RNTRC"] = ApiTestData.Text("Transportadora TRA_RNTRC Update", 20);
        payload["TRA_EMAIL"] = ApiTestData.Text("Transportadora TRA_EMAIL Update", 80);
        payload["TRA_RESPONSAVEL"] = ApiTestData.Text("Transportadora TRA_RESPONSAVEL Update", 80);
        payload["TRA_FONE"] = ApiTestData.Text("Transportadora TRA_FONE Update", 15);
        payload["TRA_ID_INTEGRACAO"] = ApiTestData.Text("Transportadora TRA_ID_INTEGRACAO Update", 80);
        payload["TRA_ID_INTEGRACAO_ERP"] = ApiTestData.Text("Transportadora TRA_ID_INTEGRACAO_ERP Update", 80);
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