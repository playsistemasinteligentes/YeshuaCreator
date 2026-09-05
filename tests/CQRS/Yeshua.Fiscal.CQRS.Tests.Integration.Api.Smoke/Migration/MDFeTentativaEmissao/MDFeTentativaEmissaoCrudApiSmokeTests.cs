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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration.MDFeTentativaEmissao;

[SmokeTestOrder(17)]
public partial class MDFeTentativaEmissaoCrudApiSmokeTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/MDFeTentativaEmissao/PostMDFeTentativaEmissao";
    private const string ReadEndpoint = "yapi/MDFeTentativaEmissao/ReadMDFeTentativaEmissao";
    private const string UpdateEndpoint = "yapi/MDFeTentativaEmissao/PutMDFeTentativaEmissao";
    private const string DeleteEndpoint = "yapi/MDFeTentativaEmissao/DeleteMDFeTentativaEmissao";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSmokeTestContext.RegisterCreatedId("MDFeTentativaEmissao", createdId);

        var initialDeletePayload = BuildDeletePayload(createPayload, createdId);
        CustomizeDeletePayload(initialDeletePayload);
        ApiSmokeTestContext.RegisterDeletePayload("MDFeTentativaEmissao", initialDeletePayload);

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
        ApiSmokeTestContext.RegisterDeletePayload("MDFeTentativaEmissao", deletePayload);
    }

    public async Task DeleteAsync()
    {
        if (!ApiSmokeTestContext.TryGetDeletePayload("MDFeTentativaEmissao", out var deletePayload))
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
            ["MDFeSolicitacaoFiscalId"] = ApiSmokeTestContext.GetRequiredCreatedId("MDFeSolicitacaoFiscal", "MDFeSolicitacaoFiscalId"),
            ["ChaveAcesso"] = ApiTestData.Text("MDFeTentativaEmissao ChaveAcesso", 44),
            ["Numero"] = 1,
            ["Serie"] = 1,
            ["Tentativa"] = 1,
            ["XmlAssinadoStorageKey"] = ApiTestData.Text("MDFeTentativaEmissao XmlAssinadoStorageKey", 80),
            ["XmlProcStorageKey"] = ApiTestData.Text("MDFeTentativaEmissao XmlProcStorageKey", 80),
            ["XmlHash"] = ApiTestData.Text("MDFeTentativaEmissao XmlHash", 80),
            ["CodigoRetorno"] = ApiTestData.Text("MDFeTentativaEmissao CodigoRetorno", 10),
            ["MensagemRetorno"] = ApiTestData.Text("MDFeTentativaEmissao MensagemRetorno", 80),
            ["ProtocoloAutorizacao"] = ApiTestData.Text("MDFeTentativaEmissao ProtocoloAutorizacao", 30),
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
        payload["MDFeSolicitacaoFiscalId"] = ApiSmokeTestContext.GetRequiredCreatedId("MDFeSolicitacaoFiscal", "MDFeSolicitacaoFiscalId");
        payload["ChaveAcesso"] = ApiTestData.Text("MDFeTentativaEmissao ChaveAcesso Update", 44);
        payload["Numero"] = 2;
        payload["Serie"] = 2;
        payload["Tentativa"] = 2;
        payload["XmlAssinadoStorageKey"] = ApiTestData.Text("MDFeTentativaEmissao XmlAssinadoStorageKey Update", 80);
        payload["XmlProcStorageKey"] = ApiTestData.Text("MDFeTentativaEmissao XmlProcStorageKey Update", 80);
        payload["XmlHash"] = ApiTestData.Text("MDFeTentativaEmissao XmlHash Update", 80);
        payload["CodigoRetorno"] = ApiTestData.Text("MDFeTentativaEmissao CodigoRetorno Update", 10);
        payload["MensagemRetorno"] = ApiTestData.Text("MDFeTentativaEmissao MensagemRetorno Update", 80);
        payload["ProtocoloAutorizacao"] = ApiTestData.Text("MDFeTentativaEmissao ProtocoloAutorizacao Update", 30);
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