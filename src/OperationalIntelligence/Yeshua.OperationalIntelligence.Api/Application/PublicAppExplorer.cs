using System.Text.Json;
using System.Text.Json.Serialization;

namespace Yeshua.OperationalIntelligence.Api.Application;

// Only files already served anonymously by the Front. No API, Git, SQL or user data.
public sealed class PublicAppExplorer(HttpClient http)
{
    private const int MaximumSourceCharacters = 128_000;
    private static readonly Dictionary<string, string[]> Screens = new(StringComparer.Ordinal)
    {
        ["login"] = ["spa/views/login.html", "spa/scripts/router.js"],
        ["register"] = ["spa/views/register.html", "spa/scripts/viewsScripts/register.js"],
        ["forgot"] = ["spa/views/forgot.html", "spa/scripts/viewsScripts/forgot.js"],
        ["memorias-estudio"] = ["Custon/Apps/Memorias/pages/estudio.html", "Custon/Apps/Memorias/pages/estudio.js"]
    };

    public async Task<PublicAppExploration> Explore(PublicAppExploreRequest request, CancellationToken cancellationToken)
    {
        if (request.Application?.Length > 60 || request.Screen?.Length > 60)
            throw new ArgumentException("application e screen aceitam até 60 caracteres.");
        var application = request.Application?.Trim();
        var screen = request.Screen?.Trim();
        if (!string.IsNullOrEmpty(screen) && (string.IsNullOrEmpty(application) || !Screens.ContainsKey(screen)))
            throw new ArgumentException("Para consultar screen, informe application e uma tela anunciada no catálogo.");

        var origin = http.BaseAddress ?? throw new InvalidOperationException("Public site URL missing.");
        if (origin.Scheme != "https" || origin.AbsolutePath != "/" || origin.UserInfo.Length > 0 ||
            origin.Query.Length > 0 || origin.Fragment.Length > 0)
            throw new InvalidOperationException("Public site must be an HTTPS origin.");
        var catalogUrl = new Uri(origin, "applications.json");
        using var catalog = JsonDocument.Parse(await Read("applications.json", cancellationToken));
        var apps = new List<PublicAppInfo>();
        foreach (var item in catalog.RootElement.EnumerateArray())
        {
            var name = item.GetProperty("application").GetString()!;
            if (!string.IsNullOrEmpty(application) && !name.Equals(application, StringComparison.OrdinalIgnoreCase))
                continue;
            apps.Add(new(name, item.GetProperty("title").GetString() ?? name,
                new Uri(origin, "spa/?app=" + Uri.EscapeDataString(name) + "#dashboard").AbsoluteUri,
                new Uri(origin, "spa/index.html#login").AbsoluteUri,
                new Uri(origin, "spa/index.html#register").AbsoluteUri,
                new Uri(origin, "spa/index.html#forgot").AbsoluteUri,
                name.Equals("Memorias", StringComparison.OrdinalIgnoreCase)
                    ? ["login", "register", "forgot", "memorias-estudio"] : ["login", "register", "forgot"]));
        }
        var sources = new List<PublicUiSource>();
        if (!string.IsNullOrEmpty(screen))
        {
            if (apps.Count != 1 || !apps[0].Screens.Contains(screen))
                throw new ArgumentException("Aplicativo ou tela não disponível nesta descoberta pública.");
            foreach (var path in Screens[screen])
                sources.Add(new(new Uri(origin, path).AbsoluteUri, await Read(path, cancellationToken)));
        }
        return new("public-ui", DateTimeOffset.UtcNow, catalogUrl.AbsoluteUri, apps.ToArray(),
            sources.ToArray(),
            "Leitura atual do catálogo e de arquivos públicos da interface. O catálogo não comprova acesso da sua conta. HTML mostra campos e ações; JavaScript mostra comportamento e validações do cliente, não todas as regras do servidor. Nenhum cadastro é enviado. Oriente o usuário a preencher dados e senha somente no site; não solicite esses valores no chat.");
    }

    private async Task<string> Read(string path, CancellationToken cancellationToken)
    {
        using var deadline = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        deadline.CancelAfter(TimeSpan.FromSeconds(10));
        cancellationToken = deadline.Token;
        using var response = await http.GetAsync(path, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        response.EnsureSuccessStatusCode();
        if (response.Content.Headers.ContentLength > MaximumSourceCharacters)
            throw new HttpRequestException("Public source exceeds limit.");
        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var reader = new StreamReader(stream);
        var buffer = new char[MaximumSourceCharacters + 1];
        var count = await reader.ReadBlockAsync(buffer.AsMemory(), cancellationToken);
        if (count > MaximumSourceCharacters) throw new HttpRequestException("Public source exceeds limit.");
        return new string(buffer, 0, count);
    }
}

[JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
public sealed record PublicAppExploreRequest(string? Application = null, string? Screen = null);
public sealed record PublicAppInfo(string Application, string Title, string EntryUrl, string LoginUrl,
    string RegisterUrl, string RecoveryUrl, string[] Screens);
public sealed record PublicUiSource(string Url, string Content);
public sealed record PublicAppExploration(string Scope, DateTimeOffset RetrievedAtUtc, string CatalogUrl,
    PublicAppInfo[] Applications, PublicUiSource[] Sources, string Notice);

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(PublicAppExploreRequest))]
[JsonSerializable(typeof(PublicAppExploration))]
internal partial class PublicAppExplorerJson : JsonSerializerContext;
