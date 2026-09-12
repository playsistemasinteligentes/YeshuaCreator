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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.EmissaoFiscalTransporteDocumento;

[SmokeTestOrder(24)]
public partial class EmissaoFiscalTransporteDocumentoCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/EmissaoFiscalTransporteDocumento/PostEmissaoFiscalTransporteDocumento";
    private const string ReadEndpoint = "yapi/EmissaoFiscalTransporteDocumento/ReadEmissaoFiscalTransporteDocumento";
    private const string UpdateEndpoint = "yapi/EmissaoFiscalTransporteDocumento/PutEmissaoFiscalTransporteDocumento";
    private const string DeleteEndpoint = "yapi/EmissaoFiscalTransporteDocumento/DeleteEmissaoFiscalTransporteDocumento";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("EmissaoFiscalTransporteDocumento", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("EmissaoFiscalTransporteDocumento", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("EmissaoFiscalTransporteDocumento", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("EmissaoFiscalTransporteDocumento", out var deletePayload))
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
            ["EmissaoFiscalTransporteId"] = ApiSmokeTestContext.GetRequiredCreatedId("EmissaoFiscalTransporte", "EmissaoFiscalTransporteId"),
            ["DocumentoFiscalId"] = ApiSmokeTestContext.GetRequiredCreatedId("DocumentoFiscal", "DocumentoFiscalId"),
            ["DocumentoFiscalOriginarioId"] = ApiSmokeTestContext.GetRequiredCreatedId("DocumentoFiscalOriginario", "DocumentoFiscalOriginarioId"),
            ["NFeProdutoSnapshotId"] = ApiSmokeTestContext.GetRequiredCreatedId("NFeProdutoSnapshot", "NFeProdutoSnapshotId"),
            ["ProdutoFiscal"] = 55,
            ["Papel"] = 1,
            ["TipoEvento"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento TipoEvento", 40),
            ["ChaveAcesso"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento ChaveAcesso", 44),
            ["XmlStorageKey"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento XmlStorageKey", 80),
            ["PdfStorageKey"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento PdfStorageKey", 80),
            ["Protocolo"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento Protocolo", 30),
            ["CodigoRetorno"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento CodigoRetorno", 10),
            ["MensagemRetorno"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento MensagemRetorno", 80),
            ["CriadoEmUtc"] = DateTime.UtcNow,
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
        payload["EmissaoFiscalTransporteId"] = ApiSmokeTestContext.GetRequiredCreatedId("EmissaoFiscalTransporte", "EmissaoFiscalTransporteId");
        payload["DocumentoFiscalId"] = ApiSmokeTestContext.GetRequiredCreatedId("DocumentoFiscal", "DocumentoFiscalId");
        payload["DocumentoFiscalOriginarioId"] = ApiSmokeTestContext.GetRequiredCreatedId("DocumentoFiscalOriginario", "DocumentoFiscalOriginarioId");
        payload["NFeProdutoSnapshotId"] = ApiSmokeTestContext.GetRequiredCreatedId("NFeProdutoSnapshot", "NFeProdutoSnapshotId");
        payload["ProdutoFiscal"] = 55;
        payload["Papel"] = 1;
        payload["TipoEvento"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento TipoEvento Update", 40);
        payload["ChaveAcesso"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento ChaveAcesso Update", 44);
        payload["XmlStorageKey"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento XmlStorageKey Update", 80);
        payload["PdfStorageKey"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento PdfStorageKey Update", 80);
        payload["Protocolo"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento Protocolo Update", 30);
        payload["CodigoRetorno"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento CodigoRetorno Update", 10);
        payload["MensagemRetorno"] = ApiTestData.Text("EmissaoFiscalTransporteDocumento MensagemRetorno Update", 80);
        payload["CriadoEmUtc"] = DateTime.UtcNow.AddMinutes(1);
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