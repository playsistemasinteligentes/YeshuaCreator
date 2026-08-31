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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.CorridasOnduladeiraEstudo;

[SeedTestOrder(19)]
public partial class CorridasOnduladeiraEstudoCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/CorridasOnduladeiraEstudo/PostCorridasOnduladeiraEstudo";
    private const string ReadEndpoint = "yapi/CorridasOnduladeiraEstudo/ReadCorridasOnduladeiraEstudo";
    private const string UpdateEndpoint = "yapi/CorridasOnduladeiraEstudo/PutCorridasOnduladeiraEstudo";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("CorridasOnduladeiraEstudo", createdId);

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
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["BOL_ID"] = ApiTestData.Text("CorridasOnduladeiraEstudo BOL_ID", 30),
            ["BOL_ID_ORIGEM"] = ApiTestData.Text("CorridasOnduladeiraEstudo BOL_ID_ORIGEM", 30),
            ["PRO_LARGURA_PECA"] = 10.5m,
            ["PRO_LARGURA_PECA_PROGRAMADO"] = 10.5m,
            ["PRO_COMPRIMENTO_PECA"] = 10.5m,
            ["PRO_COMPRIMENTO_PECA_PROGRAMADO"] = 10.5m,
            ["PRO_UTILIZOU_REFILE_OBRIGATORIO"] = 10.5m,
            ["PRO_VINCOS_RECALCULADOS"] = ApiTestData.Text("CorridasOnduladeiraEstudo PRO_VINCOS_RECALCULADOS", 80),
            ["COR_SOLVER"] = ApiTestData.Text("CorridasOnduladeiraEstudo COR_SOLVER", 30),
            ["COR_GRAMATURA_PAPEIS_PROGRAMADOS"] = 10.5m,
            ["COR_CUSTO_PAPEIS_PROGRAMADOS"] = 10.5m,
            ["COR_GRAMATURA_RESINA_PROGRAMADOS"] = 10.5m,
            ["COR_CUSTO_RESINA_PROGRAMADOS"] = 10.5m,
            ["COR_TOLERANCIA_MENOS"] = 10.5m,
            ["COR_TOLERANCIA_MAIS"] = 10.5m,
            ["COR_PILHAS_POR_PALETE"] = 1,
            ["COR_M_LINEAR_REALIZADO"] = 10.5m,
            ["PRO_ID_PALETE"] = ApiTestData.Text("CorridasOnduladeiraEstudo PRO_ID_PALETE", 30),
            ["COR_STATUS_PALETE"] = ApiTestData.Text("CorridasOnduladeiraEstudo COR_STATUS_PALETE", 30),
            ["COR_GRUPO_PRODUTIVO"] = 10.5m,
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
        payload["BOL_ID"] = ApiTestData.Text("CorridasOnduladeiraEstudo BOL_ID Update", 30);
        payload["BOL_ID_ORIGEM"] = ApiTestData.Text("CorridasOnduladeiraEstudo BOL_ID_ORIGEM Update", 30);
        payload["PRO_LARGURA_PECA"] = 20.5m;
        payload["PRO_LARGURA_PECA_PROGRAMADO"] = 20.5m;
        payload["PRO_COMPRIMENTO_PECA"] = 20.5m;
        payload["PRO_COMPRIMENTO_PECA_PROGRAMADO"] = 20.5m;
        payload["PRO_UTILIZOU_REFILE_OBRIGATORIO"] = 20.5m;
        payload["PRO_VINCOS_RECALCULADOS"] = ApiTestData.Text("CorridasOnduladeiraEstudo PRO_VINCOS_RECALCULADOS Update", 80);
        payload["COR_SOLVER"] = ApiTestData.Text("CorridasOnduladeiraEstudo COR_SOLVER Update", 30);
        payload["COR_GRAMATURA_PAPEIS_PROGRAMADOS"] = 20.5m;
        payload["COR_CUSTO_PAPEIS_PROGRAMADOS"] = 20.5m;
        payload["COR_GRAMATURA_RESINA_PROGRAMADOS"] = 20.5m;
        payload["COR_CUSTO_RESINA_PROGRAMADOS"] = 20.5m;
        payload["COR_TOLERANCIA_MENOS"] = 20.5m;
        payload["COR_TOLERANCIA_MAIS"] = 20.5m;
        payload["COR_PILHAS_POR_PALETE"] = 2;
        payload["COR_M_LINEAR_REALIZADO"] = 20.5m;
        payload["PRO_ID_PALETE"] = ApiTestData.Text("CorridasOnduladeiraEstudo PRO_ID_PALETE Update", 30);
        payload["COR_STATUS_PALETE"] = ApiTestData.Text("CorridasOnduladeiraEstudo COR_STATUS_PALETE Update", 30);
        payload["COR_GRUPO_PRODUTIVO"] = 20.5m;
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration