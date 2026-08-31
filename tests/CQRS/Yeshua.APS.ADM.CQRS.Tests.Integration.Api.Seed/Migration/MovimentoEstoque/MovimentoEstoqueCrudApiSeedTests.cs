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

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.MovimentoEstoque;

[SeedTestOrder(178)]
public partial class MovimentoEstoqueCrudApiSeedTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "yapi/MovimentoEstoque/PostMovimentoEstoque";
    private const string ReadEndpoint = "yapi/MovimentoEstoque/ReadMovimentoEstoque";
    private const string UpdateEndpoint = "yapi/MovimentoEstoque/PutMovimentoEstoque";

    public async Task ExecuteAsync()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");
        ApiSeedTestContext.RegisterCreatedId("MovimentoEstoque", createdId);

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
            ["ProdutoId"] = ApiTestData.Text("MovimentoEstoque ProdutoId", 30),
            ["OrderId"] = ApiSeedTestContext.GetRequiredCreatedId("Order", "OrderId"),
            ["Tipo"] = ApiSeedTestContext.GetRequiredCreatedId("TipoMovimentoEstoque", "Tipo"),
            ["TurnoId"] = ApiSeedTestContext.GetRequiredCreatedId("Turno", "TurnoId"),
            ["TurmaId"] = ApiSeedTestContext.GetRequiredCreatedId("Turma", "TurmaId"),
            ["Quantidade"] = 10.5m,
            ["MOV_PESO_UNITARIO"] = 10.5m,
            ["DataHoraCriacao"] = DateTime.UtcNow,
            ["DataHoraEmissao"] = DateTime.UtcNow,
            ["DiaTurma"] = ApiTestData.Text("MovimentoEstoque DiaTurma", 8),
            ["Lote"] = ApiTestData.Text("MovimentoEstoque Lote", 80),
            ["SubLote"] = ApiTestData.Text("MovimentoEstoque SubLote", 30),
            ["MaquinaId"] = ApiTestData.Text("MovimentoEstoque MaquinaId", 30),
            ["USE_ID"] = 1,
            ["Observacao"] = ApiTestData.Text("MovimentoEstoque Observacao", 80),
            ["OcorrenciaId"] = ApiSeedTestContext.GetRequiredCreatedId("Ocorrencia", "OcorrenciaId"),
            ["Armazem"] = ApiTestData.Text("MovimentoEstoque Armazem", 30),
            ["Endereco"] = ApiTestData.Text("MovimentoEstoque Endereco", 30),
            ["Estorno"] = ApiTestData.Text("MovimentoEstoque Estorno", 1),
            ["SequenciaTransformacao"] = 1,
            ["SequenciaRepeticao"] = 1,
            ["ObsOpParcial"] = ApiTestData.Text("MovimentoEstoque ObsOpParcial", 80),
            ["OcoIdOpParcial"] = ApiTestData.Text("MovimentoEstoque OcoIdOpParcial", 30),
            ["MOV_ID_INTEGRACAO"] = ApiTestData.Text("MovimentoEstoque MOV_ID_INTEGRACAO", 80),
            ["MOV_ID_INTEGRACAO_ERP"] = ApiTestData.Text("MovimentoEstoque MOV_ID_INTEGRACAO_ERP", 80),
            ["CAR_ID"] = ApiTestData.Text("MovimentoEstoque CAR_ID", 30),
            ["MOV_ID_DESTINO"] = 1,
            ["PRO_ID_DESTINO"] = ApiTestData.Text("MovimentoEstoque PRO_ID_DESTINO", 30),
            ["MOV_LOTE_DESTINO"] = ApiTestData.Text("MovimentoEstoque MOV_LOTE_DESTINO", 80),
            ["MOV_SUB_LOTE_DESTINO"] = ApiTestData.Text("MovimentoEstoque MOV_SUB_LOTE_DESTINO", 30),
            ["MOV_ID_ORIGEM"] = 1,
            ["PRO_ID_ORIGEM"] = ApiTestData.Text("MovimentoEstoque PRO_ID_ORIGEM", 30),
            ["MOV_LOTE_ORIGEM"] = ApiTestData.Text("MovimentoEstoque MOV_LOTE_ORIGEM", 80),
            ["MOV_SUB_LOTE_ORIGEM"] = ApiTestData.Text("MovimentoEstoque MOV_SUB_LOTE_ORIGEM", 30),
            ["MOV_TYPE"] = 1,
            ["MOV_DOC"] = ApiTestData.Text("MovimentoEstoque MOV_DOC", 80),
            ["MOV_APROVEITAMENTO"] = ApiTestData.Text("MovimentoEstoque MOV_APROVEITAMENTO", 1),
            ["MOV_RETIDO"] = ApiTestData.Text("MovimentoEstoque MOV_RETIDO", 1),
            ["MOV_VINCOS_ONDULADEIRA"] = ApiTestData.Text("MovimentoEstoque MOV_VINCOS_ONDULADEIRA", 80),
            ["BOL_ID"] = ApiTestData.Text("MovimentoEstoque BOL_ID", 30),
            ["ORD_ID_ORIGEM"] = ApiTestData.Text("MovimentoEstoque ORD_ID_ORIGEM", 60),
            ["COR_SEQUENCIA"] = 1,
            ["VER_ID"] = 1,
            ["MOV_TIPO_CUSTO"] = ApiTestData.Text("MovimentoEstoque MOV_TIPO_CUSTO", 1),
            ["MOV_GRUPO_CONTABIL"] = ApiTestData.Text("MovimentoEstoque MOV_GRUPO_CONTABIL", 60),
            ["FOR_ID"] = ApiTestData.Text("MovimentoEstoque FOR_ID", 30),
            ["CLI_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Cliente", "CLI_ID"),
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
        payload["ProdutoId"] = ApiTestData.Text("MovimentoEstoque ProdutoId Update", 30);
        payload["OrderId"] = ApiSeedTestContext.GetRequiredCreatedId("Order", "OrderId");
        payload["Tipo"] = ApiSeedTestContext.GetRequiredCreatedId("TipoMovimentoEstoque", "Tipo");
        payload["TurnoId"] = ApiSeedTestContext.GetRequiredCreatedId("Turno", "TurnoId");
        payload["TurmaId"] = ApiSeedTestContext.GetRequiredCreatedId("Turma", "TurmaId");
        payload["Quantidade"] = 20.5m;
        payload["MOV_PESO_UNITARIO"] = 20.5m;
        payload["DataHoraCriacao"] = DateTime.UtcNow.AddMinutes(1);
        payload["DataHoraEmissao"] = DateTime.UtcNow.AddMinutes(1);
        payload["DiaTurma"] = ApiTestData.Text("MovimentoEstoque DiaTurma Update", 8);
        payload["Lote"] = ApiTestData.Text("MovimentoEstoque Lote Update", 80);
        payload["SubLote"] = ApiTestData.Text("MovimentoEstoque SubLote Update", 30);
        payload["MaquinaId"] = ApiTestData.Text("MovimentoEstoque MaquinaId Update", 30);
        payload["USE_ID"] = 2;
        payload["Observacao"] = ApiTestData.Text("MovimentoEstoque Observacao Update", 80);
        payload["OcorrenciaId"] = ApiSeedTestContext.GetRequiredCreatedId("Ocorrencia", "OcorrenciaId");
        payload["Armazem"] = ApiTestData.Text("MovimentoEstoque Armazem Update", 30);
        payload["Endereco"] = ApiTestData.Text("MovimentoEstoque Endereco Update", 30);
        payload["Estorno"] = ApiTestData.Text("MovimentoEstoque Estorno Update", 1);
        payload["SequenciaTransformacao"] = 2;
        payload["SequenciaRepeticao"] = 2;
        payload["ObsOpParcial"] = ApiTestData.Text("MovimentoEstoque ObsOpParcial Update", 80);
        payload["OcoIdOpParcial"] = ApiTestData.Text("MovimentoEstoque OcoIdOpParcial Update", 30);
        payload["MOV_ID_INTEGRACAO"] = ApiTestData.Text("MovimentoEstoque MOV_ID_INTEGRACAO Update", 80);
        payload["MOV_ID_INTEGRACAO_ERP"] = ApiTestData.Text("MovimentoEstoque MOV_ID_INTEGRACAO_ERP Update", 80);
        payload["CAR_ID"] = ApiTestData.Text("MovimentoEstoque CAR_ID Update", 30);
        payload["MOV_ID_DESTINO"] = 2;
        payload["PRO_ID_DESTINO"] = ApiTestData.Text("MovimentoEstoque PRO_ID_DESTINO Update", 30);
        payload["MOV_LOTE_DESTINO"] = ApiTestData.Text("MovimentoEstoque MOV_LOTE_DESTINO Update", 80);
        payload["MOV_SUB_LOTE_DESTINO"] = ApiTestData.Text("MovimentoEstoque MOV_SUB_LOTE_DESTINO Update", 30);
        payload["MOV_ID_ORIGEM"] = 2;
        payload["PRO_ID_ORIGEM"] = ApiTestData.Text("MovimentoEstoque PRO_ID_ORIGEM Update", 30);
        payload["MOV_LOTE_ORIGEM"] = ApiTestData.Text("MovimentoEstoque MOV_LOTE_ORIGEM Update", 80);
        payload["MOV_SUB_LOTE_ORIGEM"] = ApiTestData.Text("MovimentoEstoque MOV_SUB_LOTE_ORIGEM Update", 30);
        payload["MOV_TYPE"] = 2;
        payload["MOV_DOC"] = ApiTestData.Text("MovimentoEstoque MOV_DOC Update", 80);
        payload["MOV_APROVEITAMENTO"] = ApiTestData.Text("MovimentoEstoque MOV_APROVEITAMENTO Update", 1);
        payload["MOV_RETIDO"] = ApiTestData.Text("MovimentoEstoque MOV_RETIDO Update", 1);
        payload["MOV_VINCOS_ONDULADEIRA"] = ApiTestData.Text("MovimentoEstoque MOV_VINCOS_ONDULADEIRA Update", 80);
        payload["BOL_ID"] = ApiTestData.Text("MovimentoEstoque BOL_ID Update", 30);
        payload["ORD_ID_ORIGEM"] = ApiTestData.Text("MovimentoEstoque ORD_ID_ORIGEM Update", 60);
        payload["COR_SEQUENCIA"] = 2;
        payload["VER_ID"] = 2;
        payload["MOV_TIPO_CUSTO"] = ApiTestData.Text("MovimentoEstoque MOV_TIPO_CUSTO Update", 1);
        payload["MOV_GRUPO_CONTABIL"] = ApiTestData.Text("MovimentoEstoque MOV_GRUPO_CONTABIL Update", 60);
        payload["FOR_ID"] = ApiTestData.Text("MovimentoEstoque FOR_ID Update", 30);
        payload["CLI_ID"] = ApiSeedTestContext.GetRequiredCreatedId("Cliente", "CLI_ID");
        return payload;
    }

    partial void CustomizeCreatePayload(JsonObject payload);
    partial void CustomizeReadPayload(JsonObject payload);
    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);
    partial void CustomizeUpdatePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration