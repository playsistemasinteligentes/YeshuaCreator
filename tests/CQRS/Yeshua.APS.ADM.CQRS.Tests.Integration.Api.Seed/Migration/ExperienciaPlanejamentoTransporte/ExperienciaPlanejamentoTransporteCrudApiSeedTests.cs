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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.ExperienciaPlanejamentoTransporte;

[SeedTestOrder(121)]
public partial class ExperienciaPlanejamentoTransporteCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/ExperienciaPlanejamentoTransporte/PostExperienciaPlanejamentoTransporte";
    private const string ReadEndpoint = "yapi/ExperienciaPlanejamentoTransporte/ReadExperienciaPlanejamentoTransporte";
    private const string UpdateEndpoint = "yapi/ExperienciaPlanejamentoTransporte/PutExperienciaPlanejamentoTransporte";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("ExperienciaPlanejamentoTransporte", createdId);

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
            ["Tipo"] = 1,
            ["Referencia"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte Referencia", 80),
            ["PedidoId"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte PedidoId", 60),
            ["ClienteId"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte ClienteId", 30),
            ["Municipio"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte Municipio", 80),
            ["Regiao"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte Regiao", 80),
            ["RotaId"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte RotaId", 80),
            ["Peso"] = 10.5m,
            ["Volume"] = 10.5m,
            ["Observacao"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte Observacao", 80),
            ["CriadoEm"] = DateTime.UtcNow,
            ["CriadoPor"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte CriadoPor", 80),
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
        payload["Tipo"] = 1;
        payload["Referencia"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte Referencia Update", 80);
        payload["PedidoId"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte PedidoId Update", 60);
        payload["ClienteId"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte ClienteId Update", 30);
        payload["Municipio"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte Municipio Update", 80);
        payload["Regiao"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte Regiao Update", 80);
        payload["RotaId"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte RotaId Update", 80);
        payload["Peso"] = 20.5m;
        payload["Volume"] = 20.5m;
        payload["Observacao"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte Observacao Update", 80);
        payload["CriadoEm"] = DateTime.UtcNow.AddMinutes(1);
        payload["CriadoPor"] = ApiTestData.Text("ExperienciaPlanejamentoTransporte CriadoPor Update", 80);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration