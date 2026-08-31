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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.Boletim;

[SmokeTestOrder(183)]
public partial class BoletimCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/Boletim/PostBoletim";
    private const string ReadEndpoint = "yapi/Boletim/ReadBoletim";
    private const string UpdateEndpoint = "yapi/Boletim/PutBoletim";
    private const string DeleteEndpoint = "yapi/Boletim/DeleteBoletim";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("Boletim", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("Boletim", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("Boletim", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("Boletim", out var deletePayload))
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
            ["BOL_ID"] = ApiTestData.Text("Boletim BOL_ID", 30),
            ["BOL_ID_ORIGEM"] = ApiTestData.Text("Boletim BOL_ID_ORIGEM", 30),
            ["BOL_SOLVER"] = ApiTestData.Text("Boletim BOL_SOLVER", 30),
            ["BOL_INTEGRACAO"] = ApiTestData.Text("Boletim BOL_INTEGRACAO", 60),
            ["BOL_SEQUENCIA"] = 10.5m,
            ["GRP_PAP_GRAMATURA_PROGRAMADO"] = 10.5m,
            ["GRP_ID_PROGRAMADO"] = ApiSmokeTestContext.GetRequiredCreatedId("GrupoProdutoAbstrato", "GRP_ID_PROGRAMADO"),
            ["GRP_PAPEL1_PROGRAMADO"] = ApiTestData.Text("Boletim GRP_PAPEL1_PROGRAMADO", 30),
            ["GRP_PAPEL2_PROGRAMADO"] = ApiTestData.Text("Boletim GRP_PAPEL2_PROGRAMADO", 30),
            ["GRP_PAPEL3_PROGRAMADO"] = ApiTestData.Text("Boletim GRP_PAPEL3_PROGRAMADO", 30),
            ["GRP_PAPEL4_PROGRAMADO"] = ApiTestData.Text("Boletim GRP_PAPEL4_PROGRAMADO", 30),
            ["GRP_PAPEL5_PROGRAMADO"] = ApiTestData.Text("Boletim GRP_PAPEL5_PROGRAMADO", 30),
            ["BOL_STATUS_INTERFACE"] = ApiTestData.Text("Boletim BOL_STATUS_INTERFACE", 3),
            ["BOL_TIPO"] = ApiTestData.Text("Boletim BOL_TIPO", 2),
            ["BOL_FORMATO"] = 1,
            ["BOL_GRAMATURA_PAPEIS_PROGRAMADOS"] = 10.5m,
            ["BOL_GRAMATURA_PAPEIS_REALIZADO"] = 10.5m,
            ["BOL_CUSTO_PAPEIS_PROGRAMADOS"] = 10.5m,
            ["BOL_CUSTO_PAPEIS_REALIZADO"] = 10.5m,
            ["BOL_GRAMATURA_RESINA_PROGRAMADOS"] = 10.5m,
            ["BOL_CUSTO_RESINA_PROGRAMADOS"] = 10.5m,
            ["BOL_REFILE_OBRIGATORIO"] = 1,
            ["BOL_OBS"] = ApiTestData.Text("Boletim BOL_OBS", 80),
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
        payload["BOL_ID"] = ApiTestData.Text("Boletim BOL_ID Update", 30);
        payload["BOL_ID_ORIGEM"] = ApiTestData.Text("Boletim BOL_ID_ORIGEM Update", 30);
        payload["BOL_SOLVER"] = ApiTestData.Text("Boletim BOL_SOLVER Update", 30);
        payload["BOL_INTEGRACAO"] = ApiTestData.Text("Boletim BOL_INTEGRACAO Update", 60);
        payload["BOL_SEQUENCIA"] = 20.5m;
        payload["GRP_PAP_GRAMATURA_PROGRAMADO"] = 20.5m;
        payload["GRP_ID_PROGRAMADO"] = ApiSmokeTestContext.GetRequiredCreatedId("GrupoProdutoAbstrato", "GRP_ID_PROGRAMADO");
        payload["GRP_PAPEL1_PROGRAMADO"] = ApiTestData.Text("Boletim GRP_PAPEL1_PROGRAMADO Update", 30);
        payload["GRP_PAPEL2_PROGRAMADO"] = ApiTestData.Text("Boletim GRP_PAPEL2_PROGRAMADO Update", 30);
        payload["GRP_PAPEL3_PROGRAMADO"] = ApiTestData.Text("Boletim GRP_PAPEL3_PROGRAMADO Update", 30);
        payload["GRP_PAPEL4_PROGRAMADO"] = ApiTestData.Text("Boletim GRP_PAPEL4_PROGRAMADO Update", 30);
        payload["GRP_PAPEL5_PROGRAMADO"] = ApiTestData.Text("Boletim GRP_PAPEL5_PROGRAMADO Update", 30);
        payload["BOL_STATUS_INTERFACE"] = ApiTestData.Text("Boletim BOL_STATUS_INTERFACE Update", 3);
        payload["BOL_TIPO"] = ApiTestData.Text("Boletim BOL_TIPO Update", 2);
        payload["BOL_FORMATO"] = 2;
        payload["BOL_GRAMATURA_PAPEIS_PROGRAMADOS"] = 20.5m;
        payload["BOL_GRAMATURA_PAPEIS_REALIZADO"] = 20.5m;
        payload["BOL_CUSTO_PAPEIS_PROGRAMADOS"] = 20.5m;
        payload["BOL_CUSTO_PAPEIS_REALIZADO"] = 20.5m;
        payload["BOL_GRAMATURA_RESINA_PROGRAMADOS"] = 20.5m;
        payload["BOL_CUSTO_RESINA_PROGRAMADOS"] = 20.5m;
        payload["BOL_REFILE_OBRIGATORIO"] = 2;
        payload["BOL_OBS"] = ApiTestData.Text("Boletim BOL_OBS Update", 80);
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