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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.CTeSolicitacaoFiscal;

[SmokeTestOrder(6)]
public partial class CTeSolicitacaoFiscalCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/CTeSolicitacaoFiscal/PostCTeSolicitacaoFiscal";
    private const string ReadEndpoint = "yapi/CTeSolicitacaoFiscal/ReadCTeSolicitacaoFiscal";
    private const string UpdateEndpoint = "yapi/CTeSolicitacaoFiscal/PutCTeSolicitacaoFiscal";
    private const string DeleteEndpoint = "yapi/CTeSolicitacaoFiscal/DeleteCTeSolicitacaoFiscal";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("CTeSolicitacaoFiscal", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("CTeSolicitacaoFiscal", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("CTeSolicitacaoFiscal", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("CTeSolicitacaoFiscal", out var deletePayload))
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
            ["EntradaOficialId"] = ApiSmokeTestContext.GetRequiredCreatedId("CTeEntradaOficial", "EntradaOficialId"),
            ["RomaneioConsolidadoId"] = ApiSmokeTestContext.GetRequiredCreatedId("CTeRomaneioConsolidado", "RomaneioConsolidadoId"),
            ["CorrelationId"] = ApiTestData.Text("CTeSolicitacaoFiscal CorrelationId", 80),
            ["Ambiente"] = 1,
            ["UFEmitente"] = ApiTestData.Text("CTeSolicitacaoFiscal UFEmitente", 2),
            ["EmitenteDocumento"] = ApiTestData.Text("CTeSolicitacaoFiscal EmitenteDocumento", 14),
            ["ProdutoFiscal"] = 57,
            ["TipoCTe"] = 0,
            ["TipoServico"] = 0,
            ["Modal"] = 1,
            ["Globalizado"] = 0,
            ["UFInicio"] = ApiTestData.Text("CTeSolicitacaoFiscal UFInicio", 2),
            ["UFFim"] = ApiTestData.Text("CTeSolicitacaoFiscal UFFim", 2),
            ["MunicipioInicioCodigoIbge"] = ApiTestData.Text("CTeSolicitacaoFiscal MunicipioInicioCodigoIbge", 7),
            ["MunicipioFimCodigoIbge"] = ApiTestData.Text("CTeSolicitacaoFiscal MunicipioFimCodigoIbge", 7),
            ["ValorServico"] = 10.5m,
            ["ValorCarga"] = 10.5m,
            ["PreferenciasManifestoJson"] = ApiTestData.Text("CTeSolicitacaoFiscal PreferenciasManifestoJson", 80),
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
        payload["EntradaOficialId"] = ApiSmokeTestContext.GetRequiredCreatedId("CTeEntradaOficial", "EntradaOficialId");
        payload["RomaneioConsolidadoId"] = ApiSmokeTestContext.GetRequiredCreatedId("CTeRomaneioConsolidado", "RomaneioConsolidadoId");
        payload["CorrelationId"] = ApiTestData.Text("CTeSolicitacaoFiscal CorrelationId Update", 80);
        payload["Ambiente"] = 1;
        payload["UFEmitente"] = ApiTestData.Text("CTeSolicitacaoFiscal UFEmitente Update", 2);
        payload["EmitenteDocumento"] = ApiTestData.Text("CTeSolicitacaoFiscal EmitenteDocumento Update", 14);
        payload["ProdutoFiscal"] = 57;
        payload["TipoCTe"] = 0;
        payload["TipoServico"] = 0;
        payload["Modal"] = 1;
        payload["Globalizado"] = 0;
        payload["UFInicio"] = ApiTestData.Text("CTeSolicitacaoFiscal UFInicio Update", 2);
        payload["UFFim"] = ApiTestData.Text("CTeSolicitacaoFiscal UFFim Update", 2);
        payload["MunicipioInicioCodigoIbge"] = ApiTestData.Text("CTeSolicitacaoFiscal MunicipioInicioCodigoIbge Update", 7);
        payload["MunicipioFimCodigoIbge"] = ApiTestData.Text("CTeSolicitacaoFiscal MunicipioFimCodigoIbge Update", 7);
        payload["ValorServico"] = 20.5m;
        payload["ValorCarga"] = 20.5m;
        payload["PreferenciasManifestoJson"] = ApiTestData.Text("CTeSolicitacaoFiscal PreferenciasManifestoJson Update", 80);
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