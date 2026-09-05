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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.NFeProdutoSnapshot;

[SmokeTestOrder(3)]
public partial class NFeProdutoSnapshotCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/NFeProdutoSnapshot/PostNFeProdutoSnapshot";
    private const string ReadEndpoint = "yapi/NFeProdutoSnapshot/ReadNFeProdutoSnapshot";
    private const string UpdateEndpoint = "yapi/NFeProdutoSnapshot/PutNFeProdutoSnapshot";
    private const string DeleteEndpoint = "yapi/NFeProdutoSnapshot/DeleteNFeProdutoSnapshot";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("NFeProdutoSnapshot", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("NFeProdutoSnapshot", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("NFeProdutoSnapshot", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("NFeProdutoSnapshot", out var deletePayload))
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
            ["DocumentoFiscalOriginarioId"] = ApiSmokeTestContext.GetRequiredCreatedId("DocumentoFiscalOriginario", "DocumentoFiscalOriginarioId"),
            ["CorrelationId"] = ApiTestData.Text("NFeProdutoSnapshot CorrelationId", 80),
            ["CargaId"] = ApiTestData.Text("NFeProdutoSnapshot CargaId", 80),
            ["PedidoId"] = ApiTestData.Text("NFeProdutoSnapshot PedidoId", 80),
            ["ChaveAcesso"] = ApiTestData.Text("NFeProdutoSnapshot ChaveAcesso", 44),
            ["EmitenteDocumento"] = ApiTestData.Text("NFeProdutoSnapshot EmitenteDocumento", 14),
            ["DestinatarioDocumento"] = ApiTestData.Text("NFeProdutoSnapshot DestinatarioDocumento", 14),
            ["UFOrigem"] = ApiTestData.Text("NFeProdutoSnapshot UFOrigem", 2),
            ["UFDestino"] = ApiTestData.Text("NFeProdutoSnapshot UFDestino", 2),
            ["MunicipioOrigemCodigoIbge"] = ApiTestData.Text("NFeProdutoSnapshot MunicipioOrigemCodigoIbge", 7),
            ["MunicipioDestinoCodigoIbge"] = ApiTestData.Text("NFeProdutoSnapshot MunicipioDestinoCodigoIbge", 7),
            ["ValorDocumento"] = 10.5m,
            ["PesoBruto"] = 10.5m,
            ["Volume"] = 10.5m,
            ["XmlStorageKey"] = ApiTestData.Text("NFeProdutoSnapshot XmlStorageKey", 80),
            ["SnapshotJson"] = ApiTestData.Text("NFeProdutoSnapshot SnapshotJson", 80),
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
        payload["DocumentoFiscalOriginarioId"] = ApiSmokeTestContext.GetRequiredCreatedId("DocumentoFiscalOriginario", "DocumentoFiscalOriginarioId");
        payload["CorrelationId"] = ApiTestData.Text("NFeProdutoSnapshot CorrelationId Update", 80);
        payload["CargaId"] = ApiTestData.Text("NFeProdutoSnapshot CargaId Update", 80);
        payload["PedidoId"] = ApiTestData.Text("NFeProdutoSnapshot PedidoId Update", 80);
        payload["ChaveAcesso"] = ApiTestData.Text("NFeProdutoSnapshot ChaveAcesso Update", 44);
        payload["EmitenteDocumento"] = ApiTestData.Text("NFeProdutoSnapshot EmitenteDocumento Update", 14);
        payload["DestinatarioDocumento"] = ApiTestData.Text("NFeProdutoSnapshot DestinatarioDocumento Update", 14);
        payload["UFOrigem"] = ApiTestData.Text("NFeProdutoSnapshot UFOrigem Update", 2);
        payload["UFDestino"] = ApiTestData.Text("NFeProdutoSnapshot UFDestino Update", 2);
        payload["MunicipioOrigemCodigoIbge"] = ApiTestData.Text("NFeProdutoSnapshot MunicipioOrigemCodigoIbge Update", 7);
        payload["MunicipioDestinoCodigoIbge"] = ApiTestData.Text("NFeProdutoSnapshot MunicipioDestinoCodigoIbge Update", 7);
        payload["ValorDocumento"] = 20.5m;
        payload["PesoBruto"] = 20.5m;
        payload["Volume"] = 20.5m;
        payload["XmlStorageKey"] = ApiTestData.Text("NFeProdutoSnapshot XmlStorageKey Update", 80);
        payload["SnapshotJson"] = ApiTestData.Text("NFeProdutoSnapshot SnapshotJson Update", 80);
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