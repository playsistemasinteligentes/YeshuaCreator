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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Seed.Migration.EmissaoFiscalTransporteDocumento;

[SeedTestOrder(24)]
public partial class EmissaoFiscalTransporteDocumentoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/EmissaoFiscalTransporteDocumento/PostEmissaoFiscalTransporteDocumento";
    private const string ReadEndpoint = "yapi/EmissaoFiscalTransporteDocumento/ReadEmissaoFiscalTransporteDocumento";
    private const string UpdateEndpoint = "yapi/EmissaoFiscalTransporteDocumento/PutEmissaoFiscalTransporteDocumento";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("EmissaoFiscalTransporteDocumento", createdId);

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
            ["EmissaoFiscalTransporteId"] = ApiSeedTestContext.GetRequiredCreatedId("EmissaoFiscalTransporte", "EmissaoFiscalTransporteId"),
            ["DocumentoFiscalId"] = ApiSeedTestContext.GetRequiredCreatedId("DocumentoFiscal", "DocumentoFiscalId"),
            ["DocumentoFiscalOriginarioId"] = ApiSeedTestContext.GetRequiredCreatedId("DocumentoFiscalOriginario", "DocumentoFiscalOriginarioId"),
            ["NFeProdutoSnapshotId"] = ApiSeedTestContext.GetRequiredCreatedId("NFeProdutoSnapshot", "NFeProdutoSnapshotId"),
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
        payload["EmissaoFiscalTransporteId"] = ApiSeedTestContext.GetRequiredCreatedId("EmissaoFiscalTransporte", "EmissaoFiscalTransporteId");
        payload["DocumentoFiscalId"] = ApiSeedTestContext.GetRequiredCreatedId("DocumentoFiscal", "DocumentoFiscalId");
        payload["DocumentoFiscalOriginarioId"] = ApiSeedTestContext.GetRequiredCreatedId("DocumentoFiscalOriginario", "DocumentoFiscalOriginarioId");
        payload["NFeProdutoSnapshotId"] = ApiSeedTestContext.GetRequiredCreatedId("NFeProdutoSnapshot", "NFeProdutoSnapshotId");
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

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration