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

namespace Yeshua.Fiscal.CTe.CQRS.Tests.Integration.Api.Smoke.Migration.CTeDocumentoOriginario;

[SmokeTestOrder(4)]
public partial class CTeDocumentoOriginarioCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/CTeDocumentoOriginario/PostCTeDocumentoOriginario";
    private const string ReadEndpoint = "yapi/CTeDocumentoOriginario/ReadCTeDocumentoOriginario";
    private const string UpdateEndpoint = "yapi/CTeDocumentoOriginario/PutCTeDocumentoOriginario";
    private const string DeleteEndpoint = "yapi/CTeDocumentoOriginario/DeleteCTeDocumentoOriginario";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("CTeDocumentoOriginario", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("CTeDocumentoOriginario", initialDeletePayload);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("CTeDocumentoOriginario", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("CTeDocumentoOriginario", out var deletePayload))
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
            ["CTeSolicitacaoFiscalId"] = ApiSmokeTestContext.GetRequiredCreatedId("CTeSolicitacaoFiscal", "CTeSolicitacaoFiscalId"),
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
        payload["CTeSolicitacaoFiscalId"] = ApiSmokeTestContext.GetRequiredCreatedId("CTeSolicitacaoFiscal", "CTeSolicitacaoFiscalId");
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