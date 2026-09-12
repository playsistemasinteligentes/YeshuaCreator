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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Seed.Migration.ContingenciaFiscal;

[SeedTestOrder(23)]
public partial class ContingenciaFiscalCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/ContingenciaFiscal/PostContingenciaFiscal";
    private const string ReadEndpoint = "yapi/ContingenciaFiscal/ReadContingenciaFiscal";
    private const string UpdateEndpoint = "yapi/ContingenciaFiscal/PutContingenciaFiscal";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("ContingenciaFiscal", createdId);

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
            ["EntradaFiscalContingenciaId"] = ApiSeedTestContext.GetRequiredCreatedId("EntradaFiscalContingencia", "EntradaFiscalContingenciaId"),
            ["CorrelationId"] = ApiTestData.Text("ContingenciaFiscal CorrelationId", 80),
            ["CargaId"] = ApiTestData.Text("ContingenciaFiscal CargaId", 80),
            ["TipoSolicitante"] = 1,
            ["Ambiente"] = 1,
            ["EmitenteDocumento"] = ApiTestData.Text("ContingenciaFiscal EmitenteDocumento", 14),
            ["TomadorDocumento"] = ApiTestData.Text("ContingenciaFiscal TomadorDocumento", 14),
            ["TransportadorDocumento"] = ApiTestData.Text("ContingenciaFiscal TransportadorDocumento", 14),
            ["QuantidadeDocumentos"] = 1,
            ["QuantidadeCTe"] = 1,
            ["QuantidadeMDFe"] = 1,
            ["ValorCarga"] = 10.5m,
            ["PesoBruto"] = 10.5m,
            ["UltimaMensagem"] = ApiTestData.Text("ContingenciaFiscal UltimaMensagem", 80),
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
        payload["EmissaoFiscalTransporteId"] = ApiSeedTestContext.GetRequiredCreatedId("EmissaoFiscalTransporte", "EmissaoFiscalTransporteId");
        payload["EntradaFiscalContingenciaId"] = ApiSeedTestContext.GetRequiredCreatedId("EntradaFiscalContingencia", "EntradaFiscalContingenciaId");
        payload["CorrelationId"] = ApiTestData.Text("ContingenciaFiscal CorrelationId Update", 80);
        payload["CargaId"] = ApiTestData.Text("ContingenciaFiscal CargaId Update", 80);
        payload["TipoSolicitante"] = 1;
        payload["Ambiente"] = 1;
        payload["EmitenteDocumento"] = ApiTestData.Text("ContingenciaFiscal EmitenteDocumento Update", 14);
        payload["TomadorDocumento"] = ApiTestData.Text("ContingenciaFiscal TomadorDocumento Update", 14);
        payload["TransportadorDocumento"] = ApiTestData.Text("ContingenciaFiscal TransportadorDocumento Update", 14);
        payload["QuantidadeDocumentos"] = 2;
        payload["QuantidadeCTe"] = 2;
        payload["QuantidadeMDFe"] = 2;
        payload["ValorCarga"] = 20.5m;
        payload["PesoBruto"] = 20.5m;
        payload["UltimaMensagem"] = ApiTestData.Text("ContingenciaFiscal UltimaMensagem Update", 80);
        payload["CriadoEmUtc"] = DateTime.UtcNow.AddMinutes(1);
        payload["AtualizadoEmUtc"] = DateTime.UtcNow.AddMinutes(1);
        payload["ConcluidoEmUtc"] = DateTime.UtcNow.AddMinutes(1);
        payload["Status"] = 1;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration