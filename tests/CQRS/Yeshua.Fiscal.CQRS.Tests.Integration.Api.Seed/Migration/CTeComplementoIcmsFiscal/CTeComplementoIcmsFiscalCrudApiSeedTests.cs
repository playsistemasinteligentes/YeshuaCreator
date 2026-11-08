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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Seed.Migration.CTeComplementoIcmsFiscal;

[SeedTestOrder(8)]
public partial class CTeComplementoIcmsFiscalCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/CTeComplementoIcmsFiscal/PostCTeComplementoIcmsFiscal";
    private const string ReadEndpoint = "yapi/CTeComplementoIcmsFiscal/ReadCTeComplementoIcmsFiscal";
    private const string UpdateEndpoint = "yapi/CTeComplementoIcmsFiscal/PutCTeComplementoIcmsFiscal";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();
        Task? customExecution = null;
        CustomizeExecution(client, ref customExecution);
        if (customExecution != null) { await customExecution; return; }

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("CTeComplementoIcmsFiscal", createdId);

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
            ["CTeSolicitacaoFiscalId"] = ApiSeedTestContext.GetRequiredCreatedId("CTeSolicitacaoFiscal", "CTeSolicitacaoFiscalId"),
            ["ValorPrestacaoComplementar"] = 10.5m,
            ["CST"] = ApiTestData.Text("CTeComplementoIcmsFiscal CST", 3),
            ["ValorBaseCalculo"] = 10.5m,
            ["AliquotaICMS"] = 10.5m,
            ["ValorICMS"] = 10.5m,
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
        payload["CTeSolicitacaoFiscalId"] = ApiSeedTestContext.GetRequiredCreatedId("CTeSolicitacaoFiscal", "CTeSolicitacaoFiscalId");
        payload["ValorPrestacaoComplementar"] = 20.5m;
        payload["CST"] = ApiTestData.Text("CTeComplementoIcmsFiscal CST Update", 3);
        payload["ValorBaseCalculo"] = 20.5m;
        payload["AliquotaICMS"] = 20.5m;
        payload["ValorICMS"] = 20.5m;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeExecution(HttpClient client, ref Task? execution);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration