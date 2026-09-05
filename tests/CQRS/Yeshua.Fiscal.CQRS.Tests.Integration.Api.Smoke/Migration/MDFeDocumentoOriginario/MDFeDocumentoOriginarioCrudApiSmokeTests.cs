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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.MDFeDocumentoOriginario;

[SmokeTestOrder(13)]
public partial class MDFeDocumentoOriginarioCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/MDFeDocumentoOriginario/PostMDFeDocumentoOriginario";
    private const string ReadEndpoint = "yapi/MDFeDocumentoOriginario/ReadMDFeDocumentoOriginario";
    private const string UpdateEndpoint = "yapi/MDFeDocumentoOriginario/PutMDFeDocumentoOriginario";
    private const string DeleteEndpoint = "yapi/MDFeDocumentoOriginario/DeleteMDFeDocumentoOriginario";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("MDFeDocumentoOriginario", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("MDFeDocumentoOriginario", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("MDFeDocumentoOriginario", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("MDFeDocumentoOriginario", out var deletePayload))
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
            ["MDFeSolicitacaoFiscalId"] = ApiSmokeTestContext.GetRequiredCreatedId("MDFeSolicitacaoFiscal", "MDFeSolicitacaoFiscalId"),
            ["DocumentoFiscalOriginarioId"] = ApiSmokeTestContext.GetRequiredCreatedId("DocumentoFiscalOriginario", "DocumentoFiscalOriginarioId"),
            ["TipoDocumento"] = ApiTestData.Text("MDFeDocumentoOriginario TipoDocumento", 30),
            ["ChaveAcesso"] = ApiTestData.Text("MDFeDocumentoOriginario ChaveAcesso", 44),
            ["SnapshotJson"] = ApiTestData.Text("MDFeDocumentoOriginario SnapshotJson", 80),
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
        payload["MDFeSolicitacaoFiscalId"] = ApiSmokeTestContext.GetRequiredCreatedId("MDFeSolicitacaoFiscal", "MDFeSolicitacaoFiscalId");
        payload["DocumentoFiscalOriginarioId"] = ApiSmokeTestContext.GetRequiredCreatedId("DocumentoFiscalOriginario", "DocumentoFiscalOriginarioId");
        payload["TipoDocumento"] = ApiTestData.Text("MDFeDocumentoOriginario TipoDocumento Update", 30);
        payload["ChaveAcesso"] = ApiTestData.Text("MDFeDocumentoOriginario ChaveAcesso Update", 44);
        payload["SnapshotJson"] = ApiTestData.Text("MDFeDocumentoOriginario SnapshotJson Update", 80);
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