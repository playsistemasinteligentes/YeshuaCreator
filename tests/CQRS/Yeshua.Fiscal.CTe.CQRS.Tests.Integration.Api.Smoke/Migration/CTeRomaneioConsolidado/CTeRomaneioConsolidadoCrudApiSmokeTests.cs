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

namespace Yeshua.Fiscal.CTe.CQRS.Tests.Integration.Api.Smoke.Migration.CTeRomaneioConsolidado;

[SmokeTestOrder(2)]
public partial class CTeRomaneioConsolidadoCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/CTeRomaneioConsolidado/PostCTeRomaneioConsolidado";
    private const string ReadEndpoint = "yapi/CTeRomaneioConsolidado/ReadCTeRomaneioConsolidado";
    private const string UpdateEndpoint = "yapi/CTeRomaneioConsolidado/PutCTeRomaneioConsolidado";
    private const string DeleteEndpoint = "yapi/CTeRomaneioConsolidado/DeleteCTeRomaneioConsolidado";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("CTeRomaneioConsolidado", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("CTeRomaneioConsolidado", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("CTeRomaneioConsolidado", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("CTeRomaneioConsolidado", out var deletePayload))
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
            ["CorrelationId"] = ApiTestData.Text("CTeRomaneioConsolidado CorrelationId", 80),
            ["RomaneioId"] = ApiTestData.Text("CTeRomaneioConsolidado RomaneioId", 80),
            ["CargaId"] = ApiTestData.Text("CTeRomaneioConsolidado CargaId", 80),
            ["ConsolidadoEmUtc"] = DateTime.UtcNow,
            ["UFInicio"] = ApiTestData.Text("CTeRomaneioConsolidado UFInicio", 2),
            ["UFFim"] = ApiTestData.Text("CTeRomaneioConsolidado UFFim", 2),
            ["MunicipioInicioCodigoIbge"] = ApiTestData.Text("CTeRomaneioConsolidado MunicipioInicioCodigoIbge", 7),
            ["MunicipioFimCodigoIbge"] = ApiTestData.Text("CTeRomaneioConsolidado MunicipioFimCodigoIbge", 7),
            ["EmitenteDocumento"] = ApiTestData.Text("CTeRomaneioConsolidado EmitenteDocumento", 14),
            ["TomadorDocumento"] = ApiTestData.Text("CTeRomaneioConsolidado TomadorDocumento", 14),
            ["RotaSnapshotJson"] = ApiTestData.Text("CTeRomaneioConsolidado RotaSnapshotJson", 80),
            ["CargaSnapshotJson"] = ApiTestData.Text("CTeRomaneioConsolidado CargaSnapshotJson", 80),
            ["PreferenciasFiscaisJson"] = ApiTestData.Text("CTeRomaneioConsolidado PreferenciasFiscaisJson", 80),
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
        payload["CorrelationId"] = ApiTestData.Text("CTeRomaneioConsolidado CorrelationId Update", 80);
        payload["RomaneioId"] = ApiTestData.Text("CTeRomaneioConsolidado RomaneioId Update", 80);
        payload["CargaId"] = ApiTestData.Text("CTeRomaneioConsolidado CargaId Update", 80);
        payload["ConsolidadoEmUtc"] = DateTime.UtcNow.AddMinutes(1);
        payload["UFInicio"] = ApiTestData.Text("CTeRomaneioConsolidado UFInicio Update", 2);
        payload["UFFim"] = ApiTestData.Text("CTeRomaneioConsolidado UFFim Update", 2);
        payload["MunicipioInicioCodigoIbge"] = ApiTestData.Text("CTeRomaneioConsolidado MunicipioInicioCodigoIbge Update", 7);
        payload["MunicipioFimCodigoIbge"] = ApiTestData.Text("CTeRomaneioConsolidado MunicipioFimCodigoIbge Update", 7);
        payload["EmitenteDocumento"] = ApiTestData.Text("CTeRomaneioConsolidado EmitenteDocumento Update", 14);
        payload["TomadorDocumento"] = ApiTestData.Text("CTeRomaneioConsolidado TomadorDocumento Update", 14);
        payload["RotaSnapshotJson"] = ApiTestData.Text("CTeRomaneioConsolidado RotaSnapshotJson Update", 80);
        payload["CargaSnapshotJson"] = ApiTestData.Text("CTeRomaneioConsolidado CargaSnapshotJson Update", 80);
        payload["PreferenciasFiscaisJson"] = ApiTestData.Text("CTeRomaneioConsolidado PreferenciasFiscaisJson Update", 80);
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