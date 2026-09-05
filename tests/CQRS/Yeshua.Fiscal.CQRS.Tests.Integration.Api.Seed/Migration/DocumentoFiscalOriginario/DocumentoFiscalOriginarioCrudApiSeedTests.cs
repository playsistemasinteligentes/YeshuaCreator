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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Seed.Migration.DocumentoFiscalOriginario;

[SeedTestOrder(2)]
public partial class DocumentoFiscalOriginarioCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/DocumentoFiscalOriginario/PostDocumentoFiscalOriginario";
    private const string ReadEndpoint = "yapi/DocumentoFiscalOriginario/ReadDocumentoFiscalOriginario";
    private const string UpdateEndpoint = "yapi/DocumentoFiscalOriginario/PutDocumentoFiscalOriginario";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("DocumentoFiscalOriginario", createdId);

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
            ["DocumentoFiscalId"] = ApiSeedTestContext.GetRequiredCreatedId("DocumentoFiscal", "DocumentoFiscalId"),
            ["CorrelationId"] = ApiTestData.Text("DocumentoFiscalOriginario CorrelationId", 80),
            ["SourceApplication"] = ApiTestData.Text("DocumentoFiscalOriginario SourceApplication", 80),
            ["SourceModule"] = ApiTestData.Text("DocumentoFiscalOriginario SourceModule", 80),
            ["SourceMessageId"] = ApiTestData.Text("DocumentoFiscalOriginario SourceMessageId", 80),
            ["TipoDocumento"] = ApiTestData.Text("DocumentoFiscalOriginario TipoDocumento", 30),
            ["ChaveAcesso"] = ApiTestData.Text("DocumentoFiscalOriginario ChaveAcesso", 44),
            ["Numero"] = ApiTestData.Text("DocumentoFiscalOriginario Numero", 30),
            ["Serie"] = ApiTestData.Text("DocumentoFiscalOriginario Serie", 10),
            ["EmitenteDocumento"] = ApiTestData.Text("DocumentoFiscalOriginario EmitenteDocumento", 14),
            ["DestinatarioDocumento"] = ApiTestData.Text("DocumentoFiscalOriginario DestinatarioDocumento", 14),
            ["ValorDocumento"] = 10.5m,
            ["PesoBruto"] = 10.5m,
            ["Volume"] = 10.5m,
            ["SnapshotJson"] = ApiTestData.Text("DocumentoFiscalOriginario SnapshotJson", 80),
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
        payload["DocumentoFiscalId"] = ApiSeedTestContext.GetRequiredCreatedId("DocumentoFiscal", "DocumentoFiscalId");
        payload["CorrelationId"] = ApiTestData.Text("DocumentoFiscalOriginario CorrelationId Update", 80);
        payload["SourceApplication"] = ApiTestData.Text("DocumentoFiscalOriginario SourceApplication Update", 80);
        payload["SourceModule"] = ApiTestData.Text("DocumentoFiscalOriginario SourceModule Update", 80);
        payload["SourceMessageId"] = ApiTestData.Text("DocumentoFiscalOriginario SourceMessageId Update", 80);
        payload["TipoDocumento"] = ApiTestData.Text("DocumentoFiscalOriginario TipoDocumento Update", 30);
        payload["ChaveAcesso"] = ApiTestData.Text("DocumentoFiscalOriginario ChaveAcesso Update", 44);
        payload["Numero"] = ApiTestData.Text("DocumentoFiscalOriginario Numero Update", 30);
        payload["Serie"] = ApiTestData.Text("DocumentoFiscalOriginario Serie Update", 10);
        payload["EmitenteDocumento"] = ApiTestData.Text("DocumentoFiscalOriginario EmitenteDocumento Update", 14);
        payload["DestinatarioDocumento"] = ApiTestData.Text("DocumentoFiscalOriginario DestinatarioDocumento Update", 14);
        payload["ValorDocumento"] = 20.5m;
        payload["PesoBruto"] = 20.5m;
        payload["Volume"] = 20.5m;
        payload["SnapshotJson"] = ApiTestData.Text("DocumentoFiscalOriginario SnapshotJson Update", 80);
        payload["Status"] = 1;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration