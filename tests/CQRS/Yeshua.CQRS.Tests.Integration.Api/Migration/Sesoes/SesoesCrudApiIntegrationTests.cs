using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.CQRS.Tests.Integration.Api.Migration.Sesoes;

public partial class SesoesCrudApiIntegrationTests : ApiIntegrationTestBase
{
    private const string CreateEndpoint = "/yapi/Sesoes/PostSesoes";
    private const string ReadEndpoint = "/yapi/Sesoes/ReadSesoes";
    private const string UpdateEndpoint = "/yapi/Sesoes/PutSesoes";
    private const string DeleteEndpoint = "/yapi/Sesoes/DeleteSesoes";

    [IntegrationFact]
    public async Task Crud_should_create_read_update_and_delete_through_api()
    {
        using var client = await CreateAuthenticatedClientAsync();

        var createPayload = BuildCreatePayload();
        CustomizeCreatePayload(createPayload);
        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);
        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);
        var createdId = ApiJson.GetRequiredProperty(createState, "data", "id");
        ApiResponseAssertions.AssertNodeHasValue(createdId, "created id");

        var readPayload = BuildReadByIdPayload(createdId);
        CustomizeReadPayload(readPayload);
        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);
        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);
        ApiResponseAssertions.AssertReadContainsId(readState, createdId);

        var updatePayload = BuildUpdatePayload(createPayload, createdId);
        CustomizeUpdatePayload(updatePayload);
        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);
        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);
        var updatedId = ApiJson.GetRequiredProperty(updateState, "data", "id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, "updated id");

        var deletePayload = BuildDeletePayload(updatePayload, createdId);
        CustomizeDeletePayload(deletePayload);
        using var deleteResponse = await client.SendJsonAsync(HttpMethod.Delete, DeleteEndpoint, deletePayload, JsonOptions);
        var deleteState = await ApiResponseAssertions.ReadSuccessStateAsync(deleteResponse);
        var deletedId = ApiJson.GetRequiredProperty(deleteState, "data", "id");
        ApiResponseAssertions.AssertSameJsonValue(createdId, deletedId, "deleted id");
    }

    private static JsonObject BuildCreatePayload()
    {
        return new JsonObject
        {
            ["PacienteId"] = 1,
            ["DataInicio"] = DateTime.UtcNow,
            ["DataFim"] = DateTime.UtcNow,
            ["StatusAgendamento"] = 0,
            ["StatusProntuario"] = 0,
            ["Prontuario"] = ApiTestData.Text("Sesoes Prontuario", 80),
            ["QueixaPrincipal"] = ApiTestData.Text("Sesoes QueixaPrincipal", 80),
            ["RegistroDocumental"] = ApiTestData.Text("Sesoes RegistroDocumental", 80),
            ["SintomasRelatados"] = ApiTestData.Text("Sesoes SintomasRelatados", 80),
            ["MudancasDesdeUltimaSessaao"] = 1,
            ["ComportamentoObservado"] = ApiTestData.Text("Sesoes ComportamentoObservado", 80),
            ["EstadoEmocionalGeral"] = ApiTestData.Text("Sesoes EstadoEmocionalGeral", 80),
            ["DiscursoPensamentos"] = ApiTestData.Text("Sesoes DiscursoPensamentos", 80),
            ["UsoMedicacao"] = ApiTestData.Text("Sesoes UsoMedicacao", 80),
            ["TecnicasUtilizadas"] = ApiTestData.Text("Sesoes TecnicasUtilizadas", 80),
            ["QuestionamentosReflexoesAbordadas"] = ApiTestData.Text("Sesoes QuestionamentosReflexoesAbordadas", 80),
            ["ExerciciosTarefasSugeridas"] = ApiTestData.Text("Sesoes ExerciciosTarefasSugeridas", 80),
            ["DiagnoosticoHipoteseDiagnoostica"] = ApiTestData.Text("Sesoes DiagnoosticoHipoteseDiagnoostica", 80),
            ["ObjetivosCurtoPrazo"] = ApiTestData.Text("Sesoes ObjetivosCurtoPrazo", 80),
            ["ObjetivosLongoPrazo"] = ApiTestData.Text("Sesoes ObjetivosLongoPrazo", 80),
            ["FrequenciaSugeridaSessooes"] = ApiTestData.Text("Sesoes FrequenciaSugeridaSessooes", 80),
            ["EncaminhamentoOutrosProfissionais"] = ApiTestData.Text("Sesoes EncaminhamentoOutrosProfissionais", 80),
            ["InformacoesRelevantesFuturasConsultas"] = ApiTestData.Text("Sesoes InformacoesRelevantesFuturasConsultas", 80),
            ["FeedbackPacienteSobreProcessoTerapeeutico"] = ApiTestData.Text("Sesoes FeedbackPacienteSobreProcessoTerapeeutico", 80),
            ["ServicoId"] = 1,
            ["MovimentacaoFinanceiraId"] = 1,
            ["ProfissionalId"] = 1,
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
        payload["PacienteId"] = 1;
        payload["DataInicio"] = DateTime.UtcNow.AddMinutes(1);
        payload["DataFim"] = DateTime.UtcNow.AddMinutes(1);
        payload["StatusAgendamento"] = 0;
        payload["StatusProntuario"] = 0;
        payload["Prontuario"] = ApiTestData.Text("Sesoes Prontuario Update", 80);
        payload["QueixaPrincipal"] = ApiTestData.Text("Sesoes QueixaPrincipal Update", 80);
        payload["RegistroDocumental"] = ApiTestData.Text("Sesoes RegistroDocumental Update", 80);
        payload["SintomasRelatados"] = ApiTestData.Text("Sesoes SintomasRelatados Update", 80);
        payload["MudancasDesdeUltimaSessaao"] = 1;
        payload["ComportamentoObservado"] = ApiTestData.Text("Sesoes ComportamentoObservado Update", 80);
        payload["EstadoEmocionalGeral"] = ApiTestData.Text("Sesoes EstadoEmocionalGeral Update", 80);
        payload["DiscursoPensamentos"] = ApiTestData.Text("Sesoes DiscursoPensamentos Update", 80);
        payload["UsoMedicacao"] = ApiTestData.Text("Sesoes UsoMedicacao Update", 80);
        payload["TecnicasUtilizadas"] = ApiTestData.Text("Sesoes TecnicasUtilizadas Update", 80);
        payload["QuestionamentosReflexoesAbordadas"] = ApiTestData.Text("Sesoes QuestionamentosReflexoesAbordadas Update", 80);
        payload["ExerciciosTarefasSugeridas"] = ApiTestData.Text("Sesoes ExerciciosTarefasSugeridas Update", 80);
        payload["DiagnoosticoHipoteseDiagnoostica"] = ApiTestData.Text("Sesoes DiagnoosticoHipoteseDiagnoostica Update", 80);
        payload["ObjetivosCurtoPrazo"] = ApiTestData.Text("Sesoes ObjetivosCurtoPrazo Update", 80);
        payload["ObjetivosLongoPrazo"] = ApiTestData.Text("Sesoes ObjetivosLongoPrazo Update", 80);
        payload["FrequenciaSugeridaSessooes"] = ApiTestData.Text("Sesoes FrequenciaSugeridaSessooes Update", 80);
        payload["EncaminhamentoOutrosProfissionais"] = ApiTestData.Text("Sesoes EncaminhamentoOutrosProfissionais Update", 80);
        payload["InformacoesRelevantesFuturasConsultas"] = ApiTestData.Text("Sesoes InformacoesRelevantesFuturasConsultas Update", 80);
        payload["FeedbackPacienteSobreProcessoTerapeeutico"] = ApiTestData.Text("Sesoes FeedbackPacienteSobreProcessoTerapeeutico Update", 80);
        payload["ServicoId"] = 1;
        payload["MovimentacaoFinanceiraId"] = 1;
        payload["ProfissionalId"] = 1;
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
    partial void CustomizeUpdatePayload(JsonObject payload);
    partial void CustomizeDeletePayload(JsonObject payload);
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiCrudTestMigration