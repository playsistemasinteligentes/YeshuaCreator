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

namespace Yeshua.Fiscal.CTe.CQRS.Tests.Integration.Api.Smoke.Migration.CTeTentativaEmissao;

[SmokeTestOrder(6)]
public partial class CTeTentativaEmissaoCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/CTeTentativaEmissao/PostCTeTentativaEmissao";
    private const string ReadEndpoint = "yapi/CTeTentativaEmissao/ReadCTeTentativaEmissao";
    private const string UpdateEndpoint = "yapi/CTeTentativaEmissao/PutCTeTentativaEmissao";
    private const string DeleteEndpoint = "yapi/CTeTentativaEmissao/DeleteCTeTentativaEmissao";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("CTeTentativaEmissao", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("CTeTentativaEmissao", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("CTeTentativaEmissao", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("CTeTentativaEmissao", out var deletePayload))
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
            ["CTeSolicitacaoFiscalId"] = ApiSmokeTestContext.GetRequiredCreatedId("CTeSolicitacaoFiscal", "CTeSolicitacaoFiscalId"),
            ["ChaveAcesso"] = ApiTestData.Text("CTeTentativaEmissao ChaveAcesso", 44),
            ["Numero"] = 1,
            ["Serie"] = 1,
            ["Tentativa"] = 1,
            ["XmlAssinadoStorageKey"] = ApiTestData.Text("CTeTentativaEmissao XmlAssinadoStorageKey", 80),
            ["XmlProcStorageKey"] = ApiTestData.Text("CTeTentativaEmissao XmlProcStorageKey", 80),
            ["XmlHash"] = ApiTestData.Text("CTeTentativaEmissao XmlHash", 80),
            ["CodigoRetorno"] = ApiTestData.Text("CTeTentativaEmissao CodigoRetorno", 10),
            ["MensagemRetorno"] = ApiTestData.Text("CTeTentativaEmissao MensagemRetorno", 80),
            ["ProtocoloAutorizacao"] = ApiTestData.Text("CTeTentativaEmissao ProtocoloAutorizacao", 30),
            ["EnviadoEmUtc"] = DateTime.UtcNow,
            ["AutorizadoEmUtc"] = DateTime.UtcNow,
            ["Status"] = 1,
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
        payload["CTeSolicitacaoFiscalId"] = ApiSmokeTestContext.GetRequiredCreatedId("CTeSolicitacaoFiscal", "CTeSolicitacaoFiscalId");
        payload["ChaveAcesso"] = ApiTestData.Text("CTeTentativaEmissao ChaveAcesso Update", 44);
        payload["Numero"] = 2;
        payload["Serie"] = 2;
        payload["Tentativa"] = 2;
        payload["XmlAssinadoStorageKey"] = ApiTestData.Text("CTeTentativaEmissao XmlAssinadoStorageKey Update", 80);
        payload["XmlProcStorageKey"] = ApiTestData.Text("CTeTentativaEmissao XmlProcStorageKey Update", 80);
        payload["XmlHash"] = ApiTestData.Text("CTeTentativaEmissao XmlHash Update", 80);
        payload["CodigoRetorno"] = ApiTestData.Text("CTeTentativaEmissao CodigoRetorno Update", 10);
        payload["MensagemRetorno"] = ApiTestData.Text("CTeTentativaEmissao MensagemRetorno Update", 80);
        payload["ProtocoloAutorizacao"] = ApiTestData.Text("CTeTentativaEmissao ProtocoloAutorizacao Update", 30);
        payload["EnviadoEmUtc"] = DateTime.UtcNow.AddMinutes(1);
        payload["AutorizadoEmUtc"] = DateTime.UtcNow.AddMinutes(1);
        payload["Status"] = 1;
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