using System.Net.Http.Headers;
using System.Text.Json;

namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke.Custon.Saga;

public sealed class GroqConnectionTests
{
    [GroqLiveFact]
    [Trait("Category", "External")]
    public async Task Configured_key_authenticates_and_exposes_the_transcription_model()
    {
        var apiKey = Environment.GetEnvironmentVariable("CLINICA_GROQ_API_KEY")!;
        var model = Environment.GetEnvironmentVariable("CLINICA_GROQ_MODEL")
            ?? "whisper-large-v3-turbo";
        var baseUrl = Environment.GetEnvironmentVariable("CLINICA_GROQ_BASE_URL")
            ?? "https://api.groq.com/openai/v1";

        Assert.True(Uri.TryCreate(baseUrl, UriKind.Absolute, out var endpoint)
            && endpoint.Scheme == Uri.UriSchemeHttps
            && string.IsNullOrEmpty(endpoint.UserInfo)
            && string.IsNullOrEmpty(endpoint.Query)
            && string.IsNullOrEmpty(endpoint.Fragment),
            "CLINICA_GROQ_BASE_URL deve ser uma URL HTTPS sem credenciais, query string ou fragmento.");

        using var client = new HttpClient
        {
            BaseAddress = new Uri(endpoint.AbsoluteUri.TrimEnd('/') + "/"),
            Timeout = TimeSpan.FromSeconds(30)
        };
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        using var response = await client.GetAsync("models");
        Assert.True(response.IsSuccessStatusCode,
            $"A API Groq recusou o teste de conexao com HTTP {(int)response.StatusCode} ({response.StatusCode}).");

        await using var responseBody = await response.Content.ReadAsStreamAsync();
        using var document = await JsonDocument.ParseAsync(responseBody);
        var availableModels = document.RootElement.GetProperty("data")
            .EnumerateArray()
            .Select(item => item.GetProperty("id").GetString())
            .Where(id => !string.IsNullOrWhiteSpace(id))
            .ToArray();

        Assert.Contains(model, availableModels);
    }
}

[AttributeUsage(AttributeTargets.Method)]
internal sealed class GroqLiveFactAttribute : FactAttribute
{
    public GroqLiveFactAttribute()
    {
        if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("CLINICA_GROQ_API_KEY")))
            Skip = "Teste externo opcional: configure CLINICA_GROQ_API_KEY para validar a conexao real com a Groq.";
    }
}
