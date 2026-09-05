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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.DocumentoFiscal;

[SmokeTestOrder(1)]
public partial class DocumentoFiscalCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/DocumentoFiscal/PostDocumentoFiscal";
    private const string ReadEndpoint = "yapi/DocumentoFiscal/ReadDocumentoFiscal";
    private const string UpdateEndpoint = "yapi/DocumentoFiscal/PutDocumentoFiscal";
    private const string DeleteEndpoint = "yapi/DocumentoFiscal/DeleteDocumentoFiscal";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("DocumentoFiscal", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("DocumentoFiscal", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("DocumentoFiscal", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("DocumentoFiscal", out var deletePayload))
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
            ["CorrelationId"] = ApiTestData.Text("DocumentoFiscal CorrelationId", 80),
            ["ProdutoFiscal"] = 55,
            ["ChaveAcesso"] = ApiTestData.Text("DocumentoFiscal ChaveAcesso", 44),
            ["Serie"] = 1,
            ["Numero"] = 1,
            ["Ambiente"] = 1,
            ["UFEmitente"] = ApiTestData.Text("DocumentoFiscal UFEmitente", 2),
            ["EmitenteDocumento"] = ApiTestData.Text("DocumentoFiscal EmitenteDocumento", 14),
            ["DestinatarioDocumento"] = ApiTestData.Text("DocumentoFiscal DestinatarioDocumento", 14),
            ["XmlStorageKey"] = ApiTestData.Text("DocumentoFiscal XmlStorageKey", 80),
            ["XmlHash"] = ApiTestData.Text("DocumentoFiscal XmlHash", 80),
            ["ProtocoloAutorizacao"] = ApiTestData.Text("DocumentoFiscal ProtocoloAutorizacao", 30),
            ["CodigoRetorno"] = ApiTestData.Text("DocumentoFiscal CodigoRetorno", 10),
            ["MensagemRetorno"] = ApiTestData.Text("DocumentoFiscal MensagemRetorno", 80),
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
        payload["CorrelationId"] = ApiTestData.Text("DocumentoFiscal CorrelationId Update", 80);
        payload["ProdutoFiscal"] = 55;
        payload["ChaveAcesso"] = ApiTestData.Text("DocumentoFiscal ChaveAcesso Update", 44);
        payload["Serie"] = 2;
        payload["Numero"] = 2;
        payload["Ambiente"] = 1;
        payload["UFEmitente"] = ApiTestData.Text("DocumentoFiscal UFEmitente Update", 2);
        payload["EmitenteDocumento"] = ApiTestData.Text("DocumentoFiscal EmitenteDocumento Update", 14);
        payload["DestinatarioDocumento"] = ApiTestData.Text("DocumentoFiscal DestinatarioDocumento Update", 14);
        payload["XmlStorageKey"] = ApiTestData.Text("DocumentoFiscal XmlStorageKey Update", 80);
        payload["XmlHash"] = ApiTestData.Text("DocumentoFiscal XmlHash Update", 80);
        payload["ProtocoloAutorizacao"] = ApiTestData.Text("DocumentoFiscal ProtocoloAutorizacao Update", 30);
        payload["CodigoRetorno"] = ApiTestData.Text("DocumentoFiscal CodigoRetorno Update", 10);
        payload["MensagemRetorno"] = ApiTestData.Text("DocumentoFiscal MensagemRetorno Update", 80);
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