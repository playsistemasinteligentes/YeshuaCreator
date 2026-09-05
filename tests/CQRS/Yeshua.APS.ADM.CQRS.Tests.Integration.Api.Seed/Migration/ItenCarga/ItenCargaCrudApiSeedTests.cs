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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.ItenCarga;

[SeedTestOrder(175)]
public partial class ItenCargaCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/ItenCarga/PostItenCarga";
    private const string ReadEndpoint = "yapi/ItenCarga/ReadItenCarga";
    private const string UpdateEndpoint = "yapi/ItenCarga/PutItenCarga";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("ItenCarga", createdId);

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
            ["CAR_ID"] = ApiTestData.Text("ItenCarga CAR_ID", 30),
            ["ORD_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Order", "ORD_ID"),
            ["ITC_ENTREGA_PLANEJADA"] = DateTime.UtcNow,
            ["ITC_ENTREGA_REALIZADA"] = DateTime.UtcNow,
            ["ITC_ORDEM_ENTREGA"] = 1,
            ["ITC_QTD_PLANEJADA"] = 10.5m,
            ["ITC_QTD_REALIZADA"] = 10.5m,
            ["ORD_HASH_KEY"] = ApiTestData.Text("ItenCarga ORD_HASH_KEY", 80),
            ["NOT_ID"] = ApiTestData.Text("ItenCarga NOT_ID", 30),
            ["NOT_EMISSAO"] = DateTime.UtcNow,
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
        payload["CAR_ID"] = ApiTestData.Text("ItenCarga CAR_ID Update", 30);
        payload["ORD_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Order", "ORD_ID");
        payload["ITC_ENTREGA_PLANEJADA"] = DateTime.UtcNow.AddMinutes(1);
        payload["ITC_ENTREGA_REALIZADA"] = DateTime.UtcNow.AddMinutes(1);
        payload["ITC_ORDEM_ENTREGA"] = 2;
        payload["ITC_QTD_PLANEJADA"] = 20.5m;
        payload["ITC_QTD_REALIZADA"] = 20.5m;
        payload["ORD_HASH_KEY"] = ApiTestData.Text("ItenCarga ORD_HASH_KEY Update", 80);
        payload["NOT_ID"] = ApiTestData.Text("ItenCarga NOT_ID Update", 30);
        payload["NOT_EMISSAO"] = DateTime.UtcNow.AddMinutes(1);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration