using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace Yeshua.CQRS.Tests.Integration.TestKit;

public abstract class ApiIntegrationTestBase
{
    protected static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true
    };

    protected static async Task<HttpClient> CreateAuthenticatedClientAsync()
    {
        var settings = ApiIntegrationSettings.FromConfiguration();
        var client = new HttpClient
        {
            BaseAddress = settings.BaseUri,
            Timeout = settings.Timeout
        };

        try
        {
            await AuthenticateAsync(client, settings);
            return client;
        }
        catch
        {
            client.Dispose();
            throw;
        }
    }

    private static async Task AuthenticateAsync(HttpClient client, ApiIntegrationSettings settings)
    {
        using var response = await client.PostAsJsonAsync(
            settings.LoginPath,
            new { login = settings.Login, password = settings.Password },
            JsonOptions);

        var content = await response.Content.ReadAsStringAsync();
        Assert.True(
            response.IsSuccessStatusCode,
            $"Login failed at {settings.LoginPath}. Status: {(int)response.StatusCode}. Body: {content}");

        using var document = JsonDocument.Parse(content);
        var token = ApiJson.GetString(document.RootElement, "token");

        Assert.False(string.IsNullOrWhiteSpace(token), $"Login response did not contain a token. Body: {content}");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}
