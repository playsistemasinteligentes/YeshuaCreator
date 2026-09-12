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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.EmissaoFiscalTransporte;

[SmokeTestOrder(22)]
public partial class EmissaoFiscalTransporteCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/EmissaoFiscalTransporte/PostEmissaoFiscalTransporte";
    private const string ReadEndpoint = "yapi/EmissaoFiscalTransporte/ReadEmissaoFiscalTransporte";
    private const string UpdateEndpoint = "yapi/EmissaoFiscalTransporte/PutEmissaoFiscalTransporte";
    private const string DeleteEndpoint = "yapi/EmissaoFiscalTransporte/DeleteEmissaoFiscalTransporte";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("EmissaoFiscalTransporte", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("EmissaoFiscalTransporte", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("EmissaoFiscalTransporte", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("EmissaoFiscalTransporte", out var deletePayload))
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
            ["CorrelationId"] = ApiTestData.Text("EmissaoFiscalTransporte CorrelationId", 80),
            ["OrigemFluxo"] = 1,
            ["CargaId"] = ApiTestData.Text("EmissaoFiscalTransporte CargaId", 80),
            ["RomaneioId"] = ApiTestData.Text("EmissaoFiscalTransporte RomaneioId", 80),
            ["Ambiente"] = 1,
            ["EmitenteDocumento"] = ApiTestData.Text("EmissaoFiscalTransporte EmitenteDocumento", 14),
            ["TomadorDocumento"] = ApiTestData.Text("EmissaoFiscalTransporte TomadorDocumento", 14),
            ["TransportadorDocumento"] = ApiTestData.Text("EmissaoFiscalTransporte TransportadorDocumento", 14),
            ["UFInicio"] = ApiTestData.Text("EmissaoFiscalTransporte UFInicio", 2),
            ["UFFim"] = ApiTestData.Text("EmissaoFiscalTransporte UFFim", 2),
            ["MunicipioInicioCodigoIbge"] = ApiTestData.Text("EmissaoFiscalTransporte MunicipioInicioCodigoIbge", 7),
            ["MunicipioFimCodigoIbge"] = ApiTestData.Text("EmissaoFiscalTransporte MunicipioFimCodigoIbge", 7),
            ["QuantidadeNFe"] = 1,
            ["QuantidadeCTe"] = 1,
            ["QuantidadeMDFe"] = 1,
            ["ValorCarga"] = 10.5m,
            ["PesoBruto"] = 10.5m,
            ["Volume"] = 10.5m,
            ["UltimaMensagem"] = ApiTestData.Text("EmissaoFiscalTransporte UltimaMensagem", 80),
            ["CriadoEmUtc"] = DateTime.UtcNow,
            ["AtualizadoEmUtc"] = DateTime.UtcNow,
            ["ConcluidoEmUtc"] = DateTime.UtcNow,
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
        payload["CorrelationId"] = ApiTestData.Text("EmissaoFiscalTransporte CorrelationId Update", 80);
        payload["OrigemFluxo"] = 1;
        payload["CargaId"] = ApiTestData.Text("EmissaoFiscalTransporte CargaId Update", 80);
        payload["RomaneioId"] = ApiTestData.Text("EmissaoFiscalTransporte RomaneioId Update", 80);
        payload["Ambiente"] = 1;
        payload["EmitenteDocumento"] = ApiTestData.Text("EmissaoFiscalTransporte EmitenteDocumento Update", 14);
        payload["TomadorDocumento"] = ApiTestData.Text("EmissaoFiscalTransporte TomadorDocumento Update", 14);
        payload["TransportadorDocumento"] = ApiTestData.Text("EmissaoFiscalTransporte TransportadorDocumento Update", 14);
        payload["UFInicio"] = ApiTestData.Text("EmissaoFiscalTransporte UFInicio Update", 2);
        payload["UFFim"] = ApiTestData.Text("EmissaoFiscalTransporte UFFim Update", 2);
        payload["MunicipioInicioCodigoIbge"] = ApiTestData.Text("EmissaoFiscalTransporte MunicipioInicioCodigoIbge Update", 7);
        payload["MunicipioFimCodigoIbge"] = ApiTestData.Text("EmissaoFiscalTransporte MunicipioFimCodigoIbge Update", 7);
        payload["QuantidadeNFe"] = 2;
        payload["QuantidadeCTe"] = 2;
        payload["QuantidadeMDFe"] = 2;
        payload["ValorCarga"] = 20.5m;
        payload["PesoBruto"] = 20.5m;
        payload["Volume"] = 20.5m;
        payload["UltimaMensagem"] = ApiTestData.Text("EmissaoFiscalTransporte UltimaMensagem Update", 80);
        payload["CriadoEmUtc"] = DateTime.UtcNow.AddMinutes(1);
        payload["AtualizadoEmUtc"] = DateTime.UtcNow.AddMinutes(1);
        payload["ConcluidoEmUtc"] = DateTime.UtcNow.AddMinutes(1);
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