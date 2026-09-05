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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.Etiqueta;

[SmokeTestOrder(168)]
public partial class EtiquetaCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Etiqueta/PostEtiqueta";
    private const string ReadEndpoint = "yapi/Etiqueta/ReadEtiqueta";
    private const string UpdateEndpoint = "yapi/Etiqueta/PutEtiqueta";
    private const string DeleteEndpoint = "yapi/Etiqueta/DeleteEtiqueta";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "eti_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Etiqueta", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Etiqueta", initialDeletePayload);

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        var readAssertionHandled = false;
        CustomizeReadAssertion(readState, createdId, ref readAssertionHandled);
        if (!readAssertionHandled)
            ApiResponseAssertions.AssertReadContainsId(readState, createdId, "eti_id");

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "eti_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Etiqueta", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Etiqueta", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "eti_id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "ETI_ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["ETI_EMISSAO"] = DateTime.UtcNow,
            ["ETI_CODIGO_BARRAS"] = ApiTestData.Text("Etiqueta ETI_CODIGO_BARRAS", 80),
            ["ETI_SEQUENCIA"] = 1,
            ["ETI_NUMERO_COPIAS"] = 1,
            ["ETI_STATUS"] = ApiTestData.Text("Etiqueta ETI_STATUS", 1),
            ["ETI_DATA_FABRICACAO"] = DateTime.UtcNow,
            ["ETI_COD_BARRAS_ORIGINAL"] = ApiTestData.Text("Etiqueta ETI_COD_BARRAS_ORIGINAL", 80),
            ["ETI_OP_ORIGINAL"] = ApiTestData.Text("Etiqueta ETI_OP_ORIGINAL", 80),
            ["MAQ_ID"] = ApiTestData.Text("Etiqueta MAQ_ID", 30),
            ["IMP_ID"] = 1,
            ["USE_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Usuario", "USE_ID"),
            ["ORD_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Order", "ORD_ID"),
            ["ROT_PRO_ID"] = ApiTestData.Text("Etiqueta ROT_PRO_ID", 30),
            ["ROT_SEQ_TRANFORMACAO"] = 1,
            ["FPR_SEQ_REPETICAO"] = 1,
            ["ETI_QUANTIDADE_PALETE"] = 10.5m,
            ["ETI_LOTE"] = ApiTestData.Text("Etiqueta ETI_LOTE", 80),
            ["ETI_SUB_LOTE"] = ApiTestData.Text("Etiqueta ETI_SUB_LOTE", 30),
            ["ETI_IMPRIMIR_DE"] = 1,
            ["ETI_IMPRIMIR_ATE"] = 1,
            ["BOL_ID"] = ApiTestData.Text("Etiqueta BOL_ID", 30),
            ["COR_SEQUENCIA"] = 1,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["ETI_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["ETI_ID"] = id.DeepClone();
        payload["ETI_EMISSAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["ETI_CODIGO_BARRAS"] = ApiTestData.Text("Etiqueta ETI_CODIGO_BARRAS Update", 80);
        payload["ETI_SEQUENCIA"] = 2;
        payload["ETI_NUMERO_COPIAS"] = 2;
        payload["ETI_STATUS"] = ApiTestData.Text("Etiqueta ETI_STATUS Update", 1);
        payload["ETI_DATA_FABRICACAO"] = DateTime.UtcNow.AddMinutes(1);
        payload["ETI_COD_BARRAS_ORIGINAL"] = ApiTestData.Text("Etiqueta ETI_COD_BARRAS_ORIGINAL Update", 80);
        payload["ETI_OP_ORIGINAL"] = ApiTestData.Text("Etiqueta ETI_OP_ORIGINAL Update", 80);
        payload["MAQ_ID"] = ApiTestData.Text("Etiqueta MAQ_ID Update", 30);
        payload["IMP_ID"] = 2;
        payload["USE_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Usuario", "USE_ID");
        payload["ORD_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Order", "ORD_ID");
        payload["ROT_PRO_ID"] = ApiTestData.Text("Etiqueta ROT_PRO_ID Update", 30);
        payload["ROT_SEQ_TRANFORMACAO"] = 2;
        payload["FPR_SEQ_REPETICAO"] = 2;
        payload["ETI_QUANTIDADE_PALETE"] = 20.5m;
        payload["ETI_LOTE"] = ApiTestData.Text("Etiqueta ETI_LOTE Update", 80);
        payload["ETI_SUB_LOTE"] = ApiTestData.Text("Etiqueta ETI_SUB_LOTE Update", 30);
        payload["ETI_IMPRIMIR_DE"] = 2;
        payload["ETI_IMPRIMIR_ATE"] = 2;
        payload["BOL_ID"] = ApiTestData.Text("Etiqueta BOL_ID Update", 30);
        payload["COR_SEQUENCIA"] = 2;
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["ETI_ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration