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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration.ItensPacked;

[SmokeTestOrder(176)]
public partial class ItensPackedCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/ItensPacked/PostItensPacked";
    private const string ReadEndpoint = "yapi/ItensPacked/ReadItensPacked";
    private const string UpdateEndpoint = "yapi/ItensPacked/PutItensPacked";
    private const string DeleteEndpoint = "yapi/ItensPacked/DeleteItensPacked";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("ItensPacked", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("ItensPacked", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("ItensPacked", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("ItensPacked", out var deletePayload))
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
            ["IPA_ID"] = 1,
            ["CAR_ID"] = ApiTestData.Text("ItensPacked CAR_ID", 30),
            ["PRO_ID"] = ApiTestData.Text("ItensPacked PRO_ID", 30),
            ["ORD_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Order", "ORD_ID"),
            ["IPA_COORDC"] = 10.5m,
            ["IPA_COORDL"] = 10.5m,
            ["IPA_COORDA"] = 10.5m,
            ["IPA_DIMC"] = 10.5m,
            ["IPA_DIML"] = 10.5m,
            ["IPA_DIMA"] = 10.5m,
            ["IPA_QTD_POR_PALETE"] = 10.5m,
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
        payload["IPA_ID"] = 2;
        payload["CAR_ID"] = ApiTestData.Text("ItensPacked CAR_ID Update", 30);
        payload["PRO_ID"] = ApiTestData.Text("ItensPacked PRO_ID Update", 30);
        payload["ORD_ID"] = ApiSmokeTestContext.GetRequiredCreatedId("Order", "ORD_ID");
        payload["IPA_COORDC"] = 20.5m;
        payload["IPA_COORDL"] = 20.5m;
        payload["IPA_COORDA"] = 20.5m;
        payload["IPA_DIMC"] = 20.5m;
        payload["IPA_DIML"] = 20.5m;
        payload["IPA_DIMA"] = 20.5m;
        payload["IPA_QTD_POR_PALETE"] = 20.5m;
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