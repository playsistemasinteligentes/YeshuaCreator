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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Seed.Migration.CTeParticipanteSnapshot;

[SeedTestOrder(8)]
public partial class CTeParticipanteSnapshotCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/CTeParticipanteSnapshot/PostCTeParticipanteSnapshot";
    private const string ReadEndpoint = "yapi/CTeParticipanteSnapshot/ReadCTeParticipanteSnapshot";
    private const string UpdateEndpoint = "yapi/CTeParticipanteSnapshot/PutCTeParticipanteSnapshot";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("CTeParticipanteSnapshot", createdId);

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
            ["Papel"] = ApiTestData.Text("CTeParticipanteSnapshot Papel", 40),
            ["Documento"] = ApiTestData.Text("CTeParticipanteSnapshot Documento", 14),
            ["Nome"] = ApiTestData.Text("CTeParticipanteSnapshot Nome", 80),
            ["InscricaoEstadual"] = ApiTestData.Text("CTeParticipanteSnapshot InscricaoEstadual", 30),
            ["UF"] = ApiTestData.Text("CTeParticipanteSnapshot UF", 2),
            ["MunicipioCodigoIbge"] = ApiTestData.Text("CTeParticipanteSnapshot MunicipioCodigoIbge", 7),
            ["EnderecoJson"] = ApiTestData.Text("CTeParticipanteSnapshot EnderecoJson", 80),
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
        payload["Papel"] = ApiTestData.Text("CTeParticipanteSnapshot Papel Update", 40);
        payload["Documento"] = ApiTestData.Text("CTeParticipanteSnapshot Documento Update", 14);
        payload["Nome"] = ApiTestData.Text("CTeParticipanteSnapshot Nome Update", 80);
        payload["InscricaoEstadual"] = ApiTestData.Text("CTeParticipanteSnapshot InscricaoEstadual Update", 30);
        payload["UF"] = ApiTestData.Text("CTeParticipanteSnapshot UF Update", 2);
        payload["MunicipioCodigoIbge"] = ApiTestData.Text("CTeParticipanteSnapshot MunicipioCodigoIbge Update", 7);
        payload["EnderecoJson"] = ApiTestData.Text("CTeParticipanteSnapshot EnderecoJson Update", 80);
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration