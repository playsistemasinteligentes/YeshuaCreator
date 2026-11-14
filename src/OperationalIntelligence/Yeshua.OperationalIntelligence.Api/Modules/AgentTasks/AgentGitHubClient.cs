using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

// Credentials stay in the API process. Neither the SDK input nor its environment receives them.
public sealed class AgentGitHubClient(HttpClient http, IOptions<AgentTaskOptions> options)
{
    private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);
    private AgentGitOptions Settings => options.Value.Git;

    public bool Configured => !string.IsNullOrWhiteSpace(Settings.UserName)
        && !string.IsNullOrWhiteSpace(Settings.Email) && !string.IsNullOrWhiteSpace(Settings.Token);

    public async Task<AgentGitIdentity> AuthenticateAsync(CancellationToken token)
    {
        if (!Configured)
            throw new ArgumentException("Configure usuario, email e token GitHub do agente no cofre privado antes de publicar PRs.");
        using var user = await SendAsync(HttpMethod.Get, "/user", Settings.Token, null, token);
        var login = user.RootElement.GetProperty("login").GetString();
        if (!string.Equals(login, Settings.UserName, StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("O token GitHub nao pertence ao usuario configurado para o agente.");
        using var repository = await SendAsync(HttpMethod.Get, RepositoryPath(), Settings.Token, null, token);
        if (!repository.RootElement.TryGetProperty("permissions", out var permissions)
            || !permissions.TryGetProperty("push", out var push) || push.ValueKind != JsonValueKind.True)
            throw new ArgumentException("O usuario GitHub do agente nao possui escrita no repositorio configurado.");
        return new(Settings.Token, Settings.UserName, Settings.Email);
    }

    public async Task<string> OpenDraftPullRequestAsync(AgentGitIdentity identity, string branch, string title, string body, CancellationToken token)
    {
        var root = RepositoryPath() + "/pulls";
        using var existing = await SendAsync(HttpMethod.Get,
            root + "?state=all&head=" + Uri.EscapeDataString(Settings.Owner + ":" + branch), identity.Token, null, token);
        foreach (var item in existing.RootElement.EnumerateArray())
        {
            if (item.GetProperty("state").GetString() != "open")
                throw new ArgumentException("O PR desta task ja foi fechado. Inicie outra task para uma nova alteracao.");
            return item.GetProperty("html_url").GetString()!;
        }
        using var created = await SendAsync(HttpMethod.Post, root, identity.Token,
            new { title, head = branch, @base = Settings.BaseBranch, body, draft = true, maintainer_can_modify = true }, token);
        return created.RootElement.GetProperty("html_url").GetString()!;
    }

    private string RepositoryPath() => "/repos/" + Uri.EscapeDataString(Settings.Owner) + "/" + Uri.EscapeDataString(Settings.Repository);

    private async Task<JsonDocument> SendAsync(HttpMethod method, string path, string credential, object? body, CancellationToken token)
    {
        using var request = new HttpRequestMessage(method, "https://api.github.com" + path);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", credential);
        request.Headers.UserAgent.ParseAdd("Yeshua-Operational-Agent/1.0");
        request.Headers.Accept.ParseAdd("application/vnd.github+json");
        request.Headers.Add("X-GitHub-Api-Version", "2026-03-10");
        if (body is not null) request.Content = JsonContent.Create(body, options: Json);
        using var response = await http.SendAsync(request, token);
        if (!response.IsSuccessStatusCode)
            throw new ArgumentException($"GitHub recusou a operacao do agente (HTTP {(int)response.StatusCode}). Confira o token e o acesso do usuario ao repositorio.");
        return JsonDocument.Parse(await response.Content.ReadAsStreamAsync(token));
    }
}

// Deliberately not a record: automatic ToString must never include the access token.
public sealed class AgentGitIdentity(string token, string name, string email)
{
    public string Token { get; } = token;
    public string Name { get; } = name;
    public string Email { get; } = email;
}
