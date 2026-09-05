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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.Feedback;

[SmokeTestOrder(170)]
public partial class FeedbackCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Feedback/PostFeedback";
    private const string ReadEndpoint = "yapi/Feedback/ReadFeedback";
    private const string UpdateEndpoint = "yapi/Feedback/PutFeedback";
    private const string DeleteEndpoint = "yapi/Feedback/DeleteFeedback";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Feedback", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Feedback", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("Feedback", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Feedback", out var deletePayload))
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
            ["DataInicial"] = DateTime.UtcNow,
            ["Datafinal"] = DateTime.UtcNow,
            ["MaquinaId"] = ApiTestData.Text("Feedback MaquinaId", 30),
            ["OcorrenciaId"] = ApiSmokeTestContext.GetRequiredCreatedId("Ocorrencia", "OcorrenciaId"),
            ["TurnoId"] = ApiSmokeTestContext.GetRequiredCreatedId("Turno", "TurnoId"),
            ["TurmaId"] = ApiSmokeTestContext.GetRequiredCreatedId("Turma", "TurmaId"),
            ["UsuarioId"] = ApiSmokeTestContext.GetRequiredCreatedId("Usuario", "UsuarioId"),
            ["OrderId"] = ApiTestData.Text("Feedback OrderId", 60),
            ["ProdutoId"] = ApiTestData.Text("Feedback ProdutoId", 30),
            ["Observacoes"] = ApiTestData.Text("Feedback Observacoes", 80),
            ["Grupo"] = 10.5m,
            ["DiaTurma"] = ApiTestData.Text("Feedback DiaTurma", 8),
            ["SequenciaTransformacao"] = 1,
            ["SequenciaRepeticao"] = 1,
            ["QuantidadePulsos"] = 10.5m,
            ["QuantidadePecasPorPulso"] = 10.5m,
            ["FEE_QTD_TOTAL_PRODUCAO_AJUSTADA"] = 10.5m,
            ["BOL_ID"] = ApiTestData.Text("Feedback BOL_ID", 30),
            ["COR_SEQUENCIA"] = 1,
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
        payload["DataInicial"] = DateTime.UtcNow.AddMinutes(1);
        payload["Datafinal"] = DateTime.UtcNow.AddMinutes(1);
        payload["MaquinaId"] = ApiTestData.Text("Feedback MaquinaId Update", 30);
        payload["OcorrenciaId"] = ApiSmokeTestContext.GetRequiredCreatedId("Ocorrencia", "OcorrenciaId");
        payload["TurnoId"] = ApiSmokeTestContext.GetRequiredCreatedId("Turno", "TurnoId");
        payload["TurmaId"] = ApiSmokeTestContext.GetRequiredCreatedId("Turma", "TurmaId");
        payload["UsuarioId"] = ApiSmokeTestContext.GetRequiredCreatedId("Usuario", "UsuarioId");
        payload["OrderId"] = ApiTestData.Text("Feedback OrderId Update", 60);
        payload["ProdutoId"] = ApiTestData.Text("Feedback ProdutoId Update", 30);
        payload["Observacoes"] = ApiTestData.Text("Feedback Observacoes Update", 80);
        payload["Grupo"] = 20.5m;
        payload["DiaTurma"] = ApiTestData.Text("Feedback DiaTurma Update", 8);
        payload["SequenciaTransformacao"] = 2;
        payload["SequenciaRepeticao"] = 2;
        payload["QuantidadePulsos"] = 20.5m;
        payload["QuantidadePecasPorPulso"] = 20.5m;
        payload["FEE_QTD_TOTAL_PRODUCAO_AJUSTADA"] = 20.5m;
        payload["BOL_ID"] = ApiTestData.Text("Feedback BOL_ID Update", 30);
        payload["COR_SEQUENCIA"] = 2;
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