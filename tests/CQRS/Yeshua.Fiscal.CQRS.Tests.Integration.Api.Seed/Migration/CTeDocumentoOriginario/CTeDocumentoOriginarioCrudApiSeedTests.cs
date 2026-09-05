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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Seed.Migration.CTeDocumentoOriginario;

[SeedTestOrder(7)]
public partial class CTeDocumentoOriginarioCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/CTeDocumentoOriginario/PostCTeDocumentoOriginario";
    private const string ReadEndpoint = "yapi/CTeDocumentoOriginario/ReadCTeDocumentoOriginario";
    private const string UpdateEndpoint = "yapi/CTeDocumentoOriginario/PutCTeDocumentoOriginario";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("CTeDocumentoOriginario", createdId);

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
            ["CTeSolicitacaoFiscalId"] = ApiSeedTestContext.GetRequiredCreatedId("CTeSolicitacaoFiscal", "CTeSolicitacaoFiscalId"),
            ["DocumentoFiscalOriginarioId"] = ApiSeedTestContext.GetRequiredCreatedId("DocumentoFiscalOriginario", "DocumentoFiscalOriginarioId"),
            ["TipoDocumento"] = ApiTestData.Text("CTeDocumentoOriginario TipoDocumento", 30),
            ["ChaveAcesso"] = ApiTestData.Text("CTeDocumentoOriginario ChaveAcesso", 44),
            ["Numero"] = ApiTestData.Text("CTeDocumentoOriginario Numero", 30),
            ["Serie"] = ApiTestData.Text("CTeDocumentoOriginario Serie", 10),
            ["EmitenteDocumento"] = ApiTestData.Text("CTeDocumentoOriginario EmitenteDocumento", 14),
            ["DestinatarioDocumento"] = ApiTestData.Text("CTeDocumentoOriginario DestinatarioDocumento", 14),
            ["ValorDocumento"] = 10.5m,
            ["PesoBruto"] = 10.5m,
            ["SnapshotJson"] = ApiTestData.Text("CTeDocumentoOriginario SnapshotJson", 80),
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
        payload["CTeSolicitacaoFiscalId"] = ApiSeedTestContext.GetRequiredCreatedId("CTeSolicitacaoFiscal", "CTeSolicitacaoFiscalId");
        payload["DocumentoFiscalOriginarioId"] = ApiSeedTestContext.GetRequiredCreatedId("DocumentoFiscalOriginario", "DocumentoFiscalOriginarioId");
        payload["TipoDocumento"] = ApiTestData.Text("CTeDocumentoOriginario TipoDocumento Update", 30);
        payload["ChaveAcesso"] = ApiTestData.Text("CTeDocumentoOriginario ChaveAcesso Update", 44);
        payload["Numero"] = ApiTestData.Text("CTeDocumentoOriginario Numero Update", 30);
        payload["Serie"] = ApiTestData.Text("CTeDocumentoOriginario Serie Update", 10);
        payload["EmitenteDocumento"] = ApiTestData.Text("CTeDocumentoOriginario EmitenteDocumento Update", 14);
        payload["DestinatarioDocumento"] = ApiTestData.Text("CTeDocumentoOriginario DestinatarioDocumento Update", 14);
        payload["ValorDocumento"] = 20.5m;
        payload["PesoBruto"] = 20.5m;
        payload["SnapshotJson"] = ApiTestData.Text("CTeDocumentoOriginario SnapshotJson Update", 80);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration