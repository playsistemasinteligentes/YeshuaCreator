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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Seed.Migration.SefazEndpoint;

[SeedTestOrder(19)]
public partial class SefazEndpointCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/SefazEndpoint/PostSefazEndpoint";
    private const string ReadEndpoint = "yapi/SefazEndpoint/ReadSefazEndpoint";
    private const string UpdateEndpoint = "yapi/SefazEndpoint/PutSefazEndpoint";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("SefazEndpoint", createdId);

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
            ["ProdutoFiscal"] = 55,
            ["UF"] = ApiTestData.Text("SefazEndpoint UF", 2),
            ["Ambiente"] = 1,
            ["Servico"] = ApiTestData.Text("SefazEndpoint Servico", 80),
            ["Versao"] = ApiTestData.Text("SefazEndpoint Versao", 20),
            ["Url"] = ApiTestData.Text("SefazEndpoint Url", 80),
            ["Ativo"] = 0,
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
        payload["ProdutoFiscal"] = 55;
        payload["UF"] = ApiTestData.Text("SefazEndpoint UF Update", 2);
        payload["Ambiente"] = 1;
        payload["Servico"] = ApiTestData.Text("SefazEndpoint Servico Update", 80);
        payload["Versao"] = ApiTestData.Text("SefazEndpoint Versao Update", 20);
        payload["Url"] = ApiTestData.Text("SefazEndpoint Url Update", 80);
        payload["Ativo"] = 0;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration