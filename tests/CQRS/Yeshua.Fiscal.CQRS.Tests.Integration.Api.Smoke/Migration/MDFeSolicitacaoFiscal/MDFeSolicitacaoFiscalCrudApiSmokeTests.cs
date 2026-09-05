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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.MDFeSolicitacaoFiscal;

[SmokeTestOrder(12)]
public partial class MDFeSolicitacaoFiscalCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/MDFeSolicitacaoFiscal/PostMDFeSolicitacaoFiscal";
    private const string ReadEndpoint = "yapi/MDFeSolicitacaoFiscal/ReadMDFeSolicitacaoFiscal";
    private const string UpdateEndpoint = "yapi/MDFeSolicitacaoFiscal/PutMDFeSolicitacaoFiscal";
    private const string DeleteEndpoint = "yapi/MDFeSolicitacaoFiscal/DeleteMDFeSolicitacaoFiscal";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("MDFeSolicitacaoFiscal", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("MDFeSolicitacaoFiscal", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("MDFeSolicitacaoFiscal", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("MDFeSolicitacaoFiscal", out var deletePayload))
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
            ["CorrelationId"] = ApiTestData.Text("MDFeSolicitacaoFiscal CorrelationId", 80),
            ["CargaId"] = ApiTestData.Text("MDFeSolicitacaoFiscal CargaId", 80),
            ["Ambiente"] = 1,
            ["UFCarregamento"] = ApiTestData.Text("MDFeSolicitacaoFiscal UFCarregamento", 2),
            ["UFDescarregamento"] = ApiTestData.Text("MDFeSolicitacaoFiscal UFDescarregamento", 2),
            ["PlacaVeiculo"] = ApiTestData.Text("MDFeSolicitacaoFiscal PlacaVeiculo", 7),
            ["CondutorDocumento"] = ApiTestData.Text("MDFeSolicitacaoFiscal CondutorDocumento", 14),
            ["DocumentosOriginariosJson"] = ApiTestData.Text("MDFeSolicitacaoFiscal DocumentosOriginariosJson", 80),
            ["TransporteSnapshotJson"] = ApiTestData.Text("MDFeSolicitacaoFiscal TransporteSnapshotJson", 80),
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
        payload["CorrelationId"] = ApiTestData.Text("MDFeSolicitacaoFiscal CorrelationId Update", 80);
        payload["CargaId"] = ApiTestData.Text("MDFeSolicitacaoFiscal CargaId Update", 80);
        payload["Ambiente"] = 1;
        payload["UFCarregamento"] = ApiTestData.Text("MDFeSolicitacaoFiscal UFCarregamento Update", 2);
        payload["UFDescarregamento"] = ApiTestData.Text("MDFeSolicitacaoFiscal UFDescarregamento Update", 2);
        payload["PlacaVeiculo"] = ApiTestData.Text("MDFeSolicitacaoFiscal PlacaVeiculo Update", 7);
        payload["CondutorDocumento"] = ApiTestData.Text("MDFeSolicitacaoFiscal CondutorDocumento Update", 14);
        payload["DocumentosOriginariosJson"] = ApiTestData.Text("MDFeSolicitacaoFiscal DocumentosOriginariosJson Update", 80);
        payload["TransporteSnapshotJson"] = ApiTestData.Text("MDFeSolicitacaoFiscal TransporteSnapshotJson Update", 80);
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