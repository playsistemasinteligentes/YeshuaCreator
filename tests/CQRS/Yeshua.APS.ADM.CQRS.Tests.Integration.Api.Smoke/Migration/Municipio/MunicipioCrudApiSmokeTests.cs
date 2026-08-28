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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.Municipio;

[SmokeTestOrder(51)]
public partial class MunicipioCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Municipio/PostMunicipio";
    private const string ReadEndpoint = "yapi/Municipio/ReadMunicipio";
    private const string UpdateEndpoint = "yapi/Municipio/PutMunicipio";
    private const string DeleteEndpoint = "yapi/Municipio/DeleteMunicipio";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "mun_id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Municipio", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Municipio", initialDeletePayload);

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
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "mun_id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Municipio", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Municipio", out var deletePayload))
            return;

        using var client = await CreateAuthenticatedClientAsync();
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "mun_id");
        var expectedId = ApiJson.GetRequiredProperty(deletePayload, "MUN_ID");
        ApiResponseAssertions.AssertSameJsonValue(expectedId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["MUN_ID"] = ApiTestData.Text("Municipio MUN_ID", 50),
            ["MUN_NOME"] = ApiTestData.Text("Municipio MUN_NOME", 80),
            ["UF_COD"] = ApiTestData.Text("Municipio UF_COD", 2),
            ["MUN_CODIGO_IBGE"] = ApiTestData.Text("Municipio MUN_CODIGO_IBGE", 50),
            ["MUN_LATITUDE"] = 10.5m,
            ["MUN_LONGITUDE"] = 10.5m,
            ["MUN_ID_INTEGRACAO_ERP"] = ApiTestData.Text("Municipio MUN_ID_INTEGRACAO_ERP", 80),
            ["MUN_CODIGO_SIAFI"] = ApiTestData.Text("Municipio MUN_CODIGO_SIAFI", 80),
            ["MUN_CODIGO_CNPJ"] = ApiTestData.Text("Municipio MUN_CODIGO_CNPJ", 80),
            ["MUN_DISTANCIA_KM"] = 10.5m,
        };
    }

    private static JsonObject BuildReadByIdPayload(JsonNode id)
    {
        return new JsonObject
        {
            ["MUN_ID"] = id.DeepClone(),
            ["Paginacao"] = ApiTestData.Pagination()
        };
    }

    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)
    {
        var payload = (JsonObject)createPayload.DeepClone();
        payload["MUN_ID"] = id.DeepClone();
        payload["MUN_NOME"] = ApiTestData.Text("Municipio MUN_NOME Update", 80);
        payload["UF_COD"] = ApiTestData.Text("Municipio UF_COD Update", 2);
        payload["MUN_CODIGO_IBGE"] = ApiTestData.Text("Municipio MUN_CODIGO_IBGE Update", 50);
        payload["MUN_LATITUDE"] = 20.5m;
        payload["MUN_LONGITUDE"] = 20.5m;
        payload["MUN_ID_INTEGRACAO_ERP"] = ApiTestData.Text("Municipio MUN_ID_INTEGRACAO_ERP Update", 80);
        payload["MUN_CODIGO_SIAFI"] = ApiTestData.Text("Municipio MUN_CODIGO_SIAFI Update", 80);
        payload["MUN_CODIGO_CNPJ"] = ApiTestData.Text("Municipio MUN_CODIGO_CNPJ Update", 80);
        payload["MUN_DISTANCIA_KM"] = 20.5m;
        return payload;
    }

    private static JsonObject BuildDeletePayload(JsonObject updatePayload, JsonNode id)
    {
        var payload = (JsonObject)updatePayload.DeepClone();
        payload["MUN_ID"] = id.DeepClone();
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSmokeCrudTestMigration