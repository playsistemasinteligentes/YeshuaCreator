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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Seed.Migration.CTeSolicitacaoFiscal;

[SeedTestOrder(6)]
public partial class CTeSolicitacaoFiscalCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/CTeSolicitacaoFiscal/PostCTeSolicitacaoFiscal";
    private const string ReadEndpoint = "yapi/CTeSolicitacaoFiscal/ReadCTeSolicitacaoFiscal";
    private const string UpdateEndpoint = "yapi/CTeSolicitacaoFiscal/PutCTeSolicitacaoFiscal";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("CTeSolicitacaoFiscal", createdId);

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
            ["EntradaOficialId"] = ApiSeedTestContext.GetRequiredCreatedId("CTeEntradaOficial", "EntradaOficialId"),
            ["RomaneioConsolidadoId"] = ApiSeedTestContext.GetRequiredCreatedId("CTeRomaneioConsolidado", "RomaneioConsolidadoId"),
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
        payload["EntradaOficialId"] = ApiSeedTestContext.GetRequiredCreatedId("CTeEntradaOficial", "EntradaOficialId");
        payload["RomaneioConsolidadoId"] = ApiSeedTestContext.GetRequiredCreatedId("CTeRomaneioConsolidado", "RomaneioConsolidadoId");
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

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration