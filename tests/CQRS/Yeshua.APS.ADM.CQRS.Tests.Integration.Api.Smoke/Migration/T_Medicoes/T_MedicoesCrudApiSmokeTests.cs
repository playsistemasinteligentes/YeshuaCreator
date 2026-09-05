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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.T_Medicoes;

[SmokeTestOrder(45)]
public partial class T_MedicoesCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/T_Medicoes/PostT_Medicoes";
    private const string ReadEndpoint = "yapi/T_Medicoes/ReadT_Medicoes";
    private const string UpdateEndpoint = "yapi/T_Medicoes/PutT_Medicoes";
    private const string DeleteEndpoint = "yapi/T_Medicoes/DeleteT_Medicoes";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("T_Medicoes", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("T_Medicoes", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("T_Medicoes", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("T_Medicoes", out var deletePayload))
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
            ["MED_ID"] = 1,
            ["IND_ID"] = 1,
            ["MET_ID"] = 1,
            ["UNI_ID"] = 1,
            ["MED_DATA"] = DateTime.UtcNow,
            ["MED_VALOR"] = ApiTestData.Text("T_Medicoes MED_VALOR", 50),
            ["MED_AC_ANO"] = ApiTestData.Text("T_Medicoes MED_AC_ANO", 70),
            ["MED_DATAMEDICAO"] = ApiTestData.Text("T_Medicoes MED_DATAMEDICAO", 8),
            ["MED_PONDERACAO"] = 10.5m,
            ["DIM_ID"] = ApiTestData.Text("T_Medicoes DIM_ID", 80),
            ["DIM_DESCRICAO"] = ApiTestData.Text("T_Medicoes DIM_DESCRICAO", 80),
            ["DIM_SUBDIMENSAO_ID"] = ApiTestData.Text("T_Medicoes DIM_SUBDIMENSAO_ID", 80),
            ["DIM_SUB_DESCRICAO"] = ApiTestData.Text("T_Medicoes DIM_SUB_DESCRICAO", 80),
            ["PER_ID"] = ApiTestData.Text("T_Medicoes PER_ID", 3),
            ["PER_DESCRICAO"] = ApiTestData.Text("T_Medicoes PER_DESCRICAO", 30),
            ["FAT_ID"] = ApiTestData.Text("T_Medicoes FAT_ID", 80),
            ["FAT_DESCRICAO"] = ApiTestData.Text("T_Medicoes FAT_DESCRICAO", 80),
            ["MED_SQL"] = ApiTestData.Text("T_Medicoes MED_SQL", 80),
            ["DOM_EMPRESA"] = ApiTestData.Text("T_Medicoes DOM_EMPRESA", 30),
            ["DOM_FILIAL"] = ApiTestData.Text("T_Medicoes DOM_FILIAL", 30),
            ["MED_VALOR_DISPER"] = ApiTestData.Text("T_Medicoes MED_VALOR_DISPER", 50),
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
        payload["MED_ID"] = 2;
        payload["IND_ID"] = 2;
        payload["MET_ID"] = 2;
        payload["UNI_ID"] = 2;
        payload["MED_DATA"] = DateTime.UtcNow.AddMinutes(1);
        payload["MED_VALOR"] = ApiTestData.Text("T_Medicoes MED_VALOR Update", 50);
        payload["MED_AC_ANO"] = ApiTestData.Text("T_Medicoes MED_AC_ANO Update", 70);
        payload["MED_DATAMEDICAO"] = ApiTestData.Text("T_Medicoes MED_DATAMEDICAO Update", 8);
        payload["MED_PONDERACAO"] = 20.5m;
        payload["DIM_ID"] = ApiTestData.Text("T_Medicoes DIM_ID Update", 80);
        payload["DIM_DESCRICAO"] = ApiTestData.Text("T_Medicoes DIM_DESCRICAO Update", 80);
        payload["DIM_SUBDIMENSAO_ID"] = ApiTestData.Text("T_Medicoes DIM_SUBDIMENSAO_ID Update", 80);
        payload["DIM_SUB_DESCRICAO"] = ApiTestData.Text("T_Medicoes DIM_SUB_DESCRICAO Update", 80);
        payload["PER_ID"] = ApiTestData.Text("T_Medicoes PER_ID Update", 3);
        payload["PER_DESCRICAO"] = ApiTestData.Text("T_Medicoes PER_DESCRICAO Update", 30);
        payload["FAT_ID"] = ApiTestData.Text("T_Medicoes FAT_ID Update", 80);
        payload["FAT_DESCRICAO"] = ApiTestData.Text("T_Medicoes FAT_DESCRICAO Update", 80);
        payload["MED_SQL"] = ApiTestData.Text("T_Medicoes MED_SQL Update", 80);
        payload["DOM_EMPRESA"] = ApiTestData.Text("T_Medicoes DOM_EMPRESA Update", 30);
        payload["DOM_FILIAL"] = ApiTestData.Text("T_Medicoes DOM_FILIAL Update", 30);
        payload["MED_VALOR_DISPER"] = ApiTestData.Text("T_Medicoes MED_VALOR_DISPER Update", 50);
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