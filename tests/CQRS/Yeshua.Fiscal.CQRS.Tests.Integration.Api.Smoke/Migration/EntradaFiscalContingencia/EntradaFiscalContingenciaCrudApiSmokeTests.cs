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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.EntradaFiscalContingencia;

[SmokeTestOrder(21)]
public partial class EntradaFiscalContingenciaCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/EntradaFiscalContingencia/PostEntradaFiscalContingencia";
    private const string ReadEndpoint = "yapi/EntradaFiscalContingencia/ReadEntradaFiscalContingencia";
    private const string UpdateEndpoint = "yapi/EntradaFiscalContingencia/PutEntradaFiscalContingencia";
    private const string DeleteEndpoint = "yapi/EntradaFiscalContingencia/DeleteEntradaFiscalContingencia";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("EntradaFiscalContingencia", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("EntradaFiscalContingencia", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("EntradaFiscalContingencia", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("EntradaFiscalContingencia", out var deletePayload))
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
            ["CorrelationId"] = ApiTestData.Text("EntradaFiscalContingencia CorrelationId", 80),
            ["CargaId"] = ApiTestData.Text("EntradaFiscalContingencia CargaId", 80),
            ["TipoSolicitante"] = 1,
            ["Ambiente"] = 1,
            ["SourceApplication"] = ApiTestData.Text("EntradaFiscalContingencia SourceApplication", 80),
            ["SourceModule"] = ApiTestData.Text("EntradaFiscalContingencia SourceModule", 80),
            ["SourceMessageId"] = ApiTestData.Text("EntradaFiscalContingencia SourceMessageId", 80),
            ["EmitenteFiscalDocumento"] = ApiTestData.Text("EntradaFiscalContingencia EmitenteFiscalDocumento", 14),
            ["TomadorDocumento"] = ApiTestData.Text("EntradaFiscalContingencia TomadorDocumento", 14),
            ["TransportadorDocumento"] = ApiTestData.Text("EntradaFiscalContingencia TransportadorDocumento", 14),
            ["RemetenteDocumento"] = ApiTestData.Text("EntradaFiscalContingencia RemetenteDocumento", 14),
            ["DestinatarioDocumento"] = ApiTestData.Text("EntradaFiscalContingencia DestinatarioDocumento", 14),
            ["UFInicio"] = ApiTestData.Text("EntradaFiscalContingencia UFInicio", 2),
            ["UFFim"] = ApiTestData.Text("EntradaFiscalContingencia UFFim", 2),
            ["MunicipioInicioCodigoIbge"] = ApiTestData.Text("EntradaFiscalContingencia MunicipioInicioCodigoIbge", 7),
            ["MunicipioFimCodigoIbge"] = ApiTestData.Text("EntradaFiscalContingencia MunicipioFimCodigoIbge", 7),
            ["RNTRC"] = ApiTestData.Text("EntradaFiscalContingencia RNTRC", 20),
            ["PlacaVeiculo"] = ApiTestData.Text("EntradaFiscalContingencia PlacaVeiculo", 7),
            ["UFVeiculo"] = ApiTestData.Text("EntradaFiscalContingencia UFVeiculo", 2),
            ["CondutorDocumento"] = ApiTestData.Text("EntradaFiscalContingencia CondutorDocumento", 14),
            ["CondutorNome"] = ApiTestData.Text("EntradaFiscalContingencia CondutorNome", 80),
            ["QuantidadeDocumentos"] = 1,
            ["ValorCarga"] = 10.5m,
            ["PesoBruto"] = 10.5m,
            ["Volume"] = 10.5m,
            ["PendenciasJson"] = ApiTestData.Text("EntradaFiscalContingencia PendenciasJson", 80),
            ["SnapshotJson"] = ApiTestData.Text("EntradaFiscalContingencia SnapshotJson", 80),
            ["EmissaoFiscalCorrelationId"] = ApiTestData.Text("EntradaFiscalContingencia EmissaoFiscalCorrelationId", 80),
            ["EmissaoFiscalSagaId"] = 1,
            ["CriadoEmUtc"] = DateTime.UtcNow,
            ["AtualizadoEmUtc"] = DateTime.UtcNow,
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
        payload["CorrelationId"] = ApiTestData.Text("EntradaFiscalContingencia CorrelationId Update", 80);
        payload["CargaId"] = ApiTestData.Text("EntradaFiscalContingencia CargaId Update", 80);
        payload["TipoSolicitante"] = 1;
        payload["Ambiente"] = 1;
        payload["SourceApplication"] = ApiTestData.Text("EntradaFiscalContingencia SourceApplication Update", 80);
        payload["SourceModule"] = ApiTestData.Text("EntradaFiscalContingencia SourceModule Update", 80);
        payload["SourceMessageId"] = ApiTestData.Text("EntradaFiscalContingencia SourceMessageId Update", 80);
        payload["EmitenteFiscalDocumento"] = ApiTestData.Text("EntradaFiscalContingencia EmitenteFiscalDocumento Update", 14);
        payload["TomadorDocumento"] = ApiTestData.Text("EntradaFiscalContingencia TomadorDocumento Update", 14);
        payload["TransportadorDocumento"] = ApiTestData.Text("EntradaFiscalContingencia TransportadorDocumento Update", 14);
        payload["RemetenteDocumento"] = ApiTestData.Text("EntradaFiscalContingencia RemetenteDocumento Update", 14);
        payload["DestinatarioDocumento"] = ApiTestData.Text("EntradaFiscalContingencia DestinatarioDocumento Update", 14);
        payload["UFInicio"] = ApiTestData.Text("EntradaFiscalContingencia UFInicio Update", 2);
        payload["UFFim"] = ApiTestData.Text("EntradaFiscalContingencia UFFim Update", 2);
        payload["MunicipioInicioCodigoIbge"] = ApiTestData.Text("EntradaFiscalContingencia MunicipioInicioCodigoIbge Update", 7);
        payload["MunicipioFimCodigoIbge"] = ApiTestData.Text("EntradaFiscalContingencia MunicipioFimCodigoIbge Update", 7);
        payload["RNTRC"] = ApiTestData.Text("EntradaFiscalContingencia RNTRC Update", 20);
        payload["PlacaVeiculo"] = ApiTestData.Text("EntradaFiscalContingencia PlacaVeiculo Update", 7);
        payload["UFVeiculo"] = ApiTestData.Text("EntradaFiscalContingencia UFVeiculo Update", 2);
        payload["CondutorDocumento"] = ApiTestData.Text("EntradaFiscalContingencia CondutorDocumento Update", 14);
        payload["CondutorNome"] = ApiTestData.Text("EntradaFiscalContingencia CondutorNome Update", 80);
        payload["QuantidadeDocumentos"] = 2;
        payload["ValorCarga"] = 20.5m;
        payload["PesoBruto"] = 20.5m;
        payload["Volume"] = 20.5m;
        payload["PendenciasJson"] = ApiTestData.Text("EntradaFiscalContingencia PendenciasJson Update", 80);
        payload["SnapshotJson"] = ApiTestData.Text("EntradaFiscalContingencia SnapshotJson Update", 80);
        payload["EmissaoFiscalCorrelationId"] = ApiTestData.Text("EntradaFiscalContingencia EmissaoFiscalCorrelationId Update", 80);
        payload["EmissaoFiscalSagaId"] = 2;
        payload["CriadoEmUtc"] = DateTime.UtcNow.AddMinutes(1);
        payload["AtualizadoEmUtc"] = DateTime.UtcNow.AddMinutes(1);
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