using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.Migration.Saga.PsychologySessionInsight;

public partial class PsychologySessionInsightSagaApiSmokeTests
{
    partial void Configure(SagaSmokeTestOptions options)
    {
        options.Enabled = Environment.GetEnvironmentVariable("CLINICA_SAGA_SMOKE_ENABLED") == "1";
        if (!options.Enabled) return;
        var sessionId = Environment.GetEnvironmentVariable("CLINICA_SAGA_SMOKE_SESSION_ID");
        var audio = Environment.GetEnvironmentVariable("CLINICA_SAGA_SMOKE_AUDIO");
        Assert.True(int.TryParse(sessionId, out var id) && id > 0, "Configure uma sessao de teste existente.");
        Assert.True(File.Exists(audio), "Configure um arquivo de audio de teste.");
        options.Timeout = TimeSpan.FromMinutes(20);
        options.BuildStartPayload = () => new JsonObject { ["entityType"] = "Sesoes", ["entityId"] = sessionId };
        options.StartSagaAsync = async (client, payload, token) =>
        {
            using var entry = await client.GetAsync("yapi/getMenu", token);
            entry.EnsureSuccessStatusCode();
            if (entry.Headers.TryGetValues("X-Yeshua-Application-Token", out var applicationTokens))
                client.DefaultRequestHeaders.Authorization = new("Bearer", applicationTokens.Single());
            using var start = await client.PostAsJsonAsync("yapi/FileUpload/InfraStarSessionUploadUseCase", payload, JsonOptions, token);
            var state = await ApiResponseAssertions.ReadSuccessStateAsync(start);
            var uploadToken = ApiJson.GetRequiredProperty(state, "uploadToken").GetValue<string>();
            var bytes = await File.ReadAllBytesAsync(audio!, token);
            Assert.True(bytes.Length >= 3, "O audio de homologacao precisa permitir tres chunks.");
            JsonObject? finalized = null;
            async Task<JsonObject?> SendChunk(int index)
            {
                var offset = bytes.Length * index / 3;
                var length = bytes.Length * (index + 1) / 3 - offset;
                using var form = new MultipartFormDataContent();
                form.Add(new StringContent(uploadToken), "token");
                form.Add(new StringContent(index.ToString()), "chunkIndex");
                form.Add(new StringContent(index == 2 ? "true" : "false"), "isFinalChunk");
                form.Add(new StringContent("audio.webm"), "fileName");
                form.Add(new StringContent("audio/webm"), "contentType");
                form.Add(new ByteArrayContent(bytes, offset, length), "fileStream", "audio.webm");
                using var sent = await client.PostAsync("yapi/FileUpload/InfraSendFileUseCase2", form, token);
                sent.EnsureSuccessStatusCode();
                return await sent.Content.ReadFromJsonAsync<JsonObject>(JsonOptions, token);
            }
            for (var index = 0; index < 3; index++) finalized = await SendChunk(index);
            var replay = await SendChunk(2);
            Assert.Equal(ApiJson.GetRequiredProperty(finalized!, "SagaId").ToJsonString(),
                ApiJson.GetRequiredProperty(replay!, "SagaId").ToJsonString());
            return new JsonObject { ["data"] = finalized };
        };
        options.BuildSagaReadPayload = (state, _) =>
            new JsonObject { ["Id"] = ApiJson.GetRequiredProperty(ApiJson.GetRequiredProperty(state, "data"), "SagaId").DeepClone() };
        options.IsExpectedOutcome = (saga, _) =>
            ApiJson.GetRequiredProperty(saga, "Status").GetValue<int>() is 2 or 3;
        options.AssertOutcome = (saga, steps) =>
        {
            Assert.Equal(2, ApiJson.GetRequiredProperty(saga, "Status").GetValue<int>());
            Assert.Equal(sessionId, ApiJson.GetRequiredProperty(saga, "EntityId").GetValue<string>());
            Assert.All(steps.OfType<JsonObject>(), step =>
                Assert.Equal(5, ApiJson.GetRequiredProperty(step, "Status").GetValue<int>()));
        };
        options.OnObservationAsync = async (client, saga, _, token) =>
        {
            if (ApiJson.GetRequiredProperty(saga, "Status").GetValue<int>() != 2) return;
            using var response = await client.PostAsJsonAsync("yapi/Sesoes/ReadSesoes", new
                { Id = id, Paginacao = ApiTestData.Pagination(pageSize: 1) }, JsonOptions, token);
            var state = await ApiResponseAssertions.ReadSuccessStateAsync(response);
            var data = ApiJson.GetRequiredProperty(state, "data");
            var items = (JsonArray)ApiJson.GetRequiredProperty(data, "items");
            var session = Assert.Single(items.OfType<JsonObject>());
            Assert.Equal(3, ApiJson.GetRequiredProperty(session, "StatusProntuario").GetValue<int>());
            Assert.False(string.IsNullOrWhiteSpace(ApiJson.GetRequiredProperty(session, "Prontuario").GetValue<string>()));
            Assert.False(string.IsNullOrWhiteSpace(ApiJson.GetRequiredProperty(session, "RegistroDocumental").GetValue<string>()));
            Assert.NotNull(ApiJson.GetRequiredProperty(session, "QueixaPrincipal").GetValue<string>());
        };
    }
}
