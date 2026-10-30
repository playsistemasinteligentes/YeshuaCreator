using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Client;
using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Endpoints;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;
using Yeshua.OperationalIntelligence.Api.Repositories;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class SourceExplorationTests
{
    [TestMethod]
    public async Task DiscoveryPreservesTheExactBuildAndPagesWithoutReadingWholeRepository()
    {
        var repository = new IndexedRepository();
        var search = new SourceSearch(repository);
        var apps = await search.SearchAsync(new(), default);
        Assert.AreEqual("Memorias", apps.Applications.Single().Name);
        var builds = await search.SearchAsync(apps.Next.Single().Arguments, default);
        Assert.AreEqual(repository.Build.BuildId, builds.Builds.Single().BuildId);
        var dsl = await search.SearchAsync(builds.Next.Single().Arguments with { MaxResults = 1, MaxFiles = 1, MaxLines = 2 }, default);
        Assert.AreEqual(repository.Build.BuildId, repository.Discovery!.BuildId);
        Assert.AreEqual("dsl", repository.Discovery.Kind);
        Assert.AreEqual(repository.Build.BuildId, repository.ContentBuild);
        Assert.AreEqual(1, repository.ContentFiles.Count);
        Assert.IsTrue(dsl.Warnings.Any(warning => warning.Contains("DSL original")));
        var page = dsl.Next.Single(next => next.Arguments.Offset == 1).Arguments;
        Assert.AreEqual(repository.Build.BuildId, page.BuildId);
        Assert.AreEqual(repository.Build.Version, page.Version);
        Assert.AreEqual("Memorias", page.Application);
        Assert.AreEqual("dsl", page.Kind);
        var following = await search.SearchAsync(page, default);
        Assert.AreEqual("src/Studio/Migrations/M000002.cs", following.SourceFiles.Single().File);
        Assert.IsTrue(following.Next.All(next => next.Arguments.BuildId == repository.Build.BuildId));
    }

    [TestMethod]
    public async Task FunctionReadStartsAtTheDeclarationAndContinuesWithoutChangingSnapshot()
    {
        var repository = new IndexedRepository();
        var search = new SourceSearch(repository);
        var request = new SourceExplorationRequest { Application = "Memorias", Kind = "function", Query = "Publicar", IncludeContent = true, MaxLines = 2 };
        var first = await search.SearchAsync(request, default);
        Assert.AreEqual(0, repository.Function!.MaxDepth);
        Assert.AreEqual(3, first.Snippets.Single().StartLine);
        Assert.AreEqual(4, first.Snippets.Single().EndLine);
        Assert.IsFalse(first.Snippets.Single().Complete);
        Assert.IsFalse(first.Snippets.Single().Content.Contains("irrelevante"));
        var continuation = first.Next.Single(next => next.Arguments.Line == 5).Arguments;
        Assert.AreEqual(repository.Build.BuildId, continuation.BuildId);
        var second = await search.SearchAsync(continuation, default);
        Assert.AreEqual(5, second.Snippets.Single().StartLine);
        Assert.AreEqual(6, second.Snippets.Single().EndLine);
        Assert.IsTrue(second.Snippets.Single().Complete);
        var deepen = first.Next.Single(next => next.Arguments.MaxDepth == 1).Arguments;
        await search.SearchAsync(deepen, default);
        Assert.AreEqual(repository.Build.BuildId, repository.Function!.BuildId);
    }

    [TestMethod]
    public async Task ExcerptAndContinuationPreserveBlankLinesAndOriginalLineNumbers()
    {
        var repository = new IndexedRepository { CustomContent = "\r\n\r\nvoid Publicar()\r\n{\r\n}\r\n" };
        var search = new SourceSearch(repository);
        var first = await search.SearchAsync(new()
        {
            Kind = "file", Application = "Memorias", File = "src/Receivers/PublicarHandler.cs",
            Line = 1, EndLine = 5, MaxLines = 3, IncludeContent = true
        }, default);
        var firstSnippet = first.Snippets.Single();
        Assert.AreEqual("\n\nvoid Publicar()", firstSnippet.Content);
        Assert.AreEqual(1, firstSnippet.StartLine);
        Assert.AreEqual(3, firstSnippet.EndLine);
        Assert.IsFalse(firstSnippet.Complete);
        var second = await search.SearchAsync(first.Next.Single(next => next.Arguments.Line == 4).Arguments, default);
        var secondSnippet = second.Snippets.Single();
        Assert.AreEqual(4, secondSnippet.StartLine);
        Assert.AreEqual(5, secondSnippet.EndLine);
        Assert.IsTrue(secondSnippet.Complete);
        Assert.AreEqual("\n\nvoid Publicar()\n{\n}", firstSnippet.Content + "\n" + secondSnippet.Content);
        Assert.AreEqual(first.Build!.BuildId, second.Build!.BuildId);
    }

    [TestMethod]
    public async Task SharedContentBudgetAppliesAcrossFilesAndTextCandidatesAreNotFacts()
    {
        var repository = new IndexedRepository { LongLines = true };
        var result = await new SourceSearch(repository).SearchAsync(new()
        {
            Kind = "action", Application = "Memorias", Query = "publicar", IncludeContent = true,
            MaxContentChars = 100, MaxFiles = 2
        }, default);
        Assert.IsTrue(result.Snippets.Sum(snippet => snippet.Content.Length) <= 100);
        Assert.IsTrue(result.Warnings.Any(warning => warning.Contains("não comprovam vínculo semântico")));
        Assert.IsTrue(result.Warnings.Any(warning => warning.Contains("Orçamento")));
        Assert.AreEqual("publicar", repository.Discovery!.Query);
    }

    [TestMethod]
    public async Task GetPostAndOfficialMcpClientReturnTheSameEvidenceAndRejectMalformedFilters()
    {
        var repository = new IndexedRepository();
        var builder = WebApplication.CreateSlimBuilder();
        builder.Logging.ClearProviders();
        builder.WebHost.UseUrls("http://127.0.0.1:0");
        builder.Services.AddYeshuaMcp();
        builder.Services.RemoveAll<IMcpTool>();
        builder.Services.AddScoped<IMcpTool, SourceSearchTool>();
        builder.Services.AddSingleton<ISourceContextRepository>(repository);
        await using var app = builder.Build();
        app.MapMcpEndpoints();
        app.MapSourceSearchEndpoints();
        await app.StartAsync();
        using var http = new HttpClient { BaseAddress = new Uri(app.Urls.Single()) };
        var request = new { application = "Memorias", kind = "function", query = "Publicar", includeContent = true, maxLines = 2 };
        using var get = await http.GetAsync("/api/source-context/search?application=Memorias&kind=function&query=Publicar&includeContent=true&maxLines=2");
        using var post = await http.PostAsJsonAsync("/api/source-context/search", request);
        var getText = await get.Content.ReadAsStringAsync();
        Assert.AreEqual(HttpStatusCode.OK, get.StatusCode, getText);
        Assert.IsTrue(get.Headers.CacheControl!.NoStore);
        Assert.AreEqual(getText, await post.Content.ReadAsStringAsync());
        await using var mcp = await McpClient.CreateAsync(new HttpClientTransport(new HttpClientTransportOptions
        {
            Endpoint = new Uri(http.BaseAddress, "/mcp"), TransportMode = HttpTransportMode.StreamableHttp
        }));
        var tool = (await mcp.ListToolsAsync()).Single();
        Assert.AreEqual("yeshua_source_search", tool.Name);
        Assert.AreEqual(true, tool.ProtocolTool.Annotations!.ReadOnlyHint);
        var mcpResult = await mcp.CallToolAsync("yeshua_source_search", new Dictionary<string, object?>
        {
            ["application"] = "Memorias", ["kind"] = "function", ["query"] = "Publicar", ["includeContent"] = true, ["maxLines"] = 2
        });
        Assert.IsFalse(mcpResult.IsError ?? false);
        using var expected = JsonDocument.Parse(getText);
        // MCP's generic registry can include null properties; compare the complete typed evidence.
        var fromMcp = mcpResult.StructuredContent!.Value.Deserialize<SourceExplorationResponse>(new JsonSerializerOptions(JsonSerializerDefaults.Web));
        Assert.AreEqual(getText, JsonSerializer.Serialize(fromMcp, new JsonSerializerOptions(JsonSerializerDefaults.Web) { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull }));
        using var catalog = await http.GetAsync("/api/source-context/search");
        Assert.AreEqual(HttpStatusCode.OK, catalog.StatusCode);
        using var catalogJson = JsonDocument.Parse(await catalog.Content.ReadAsStringAsync());
        Assert.AreEqual("Memorias", catalogJson.RootElement.GetProperty("applications")[0].GetProperty("name").GetString());
        var mcpCatalog = await mcp.CallToolAsync("yeshua_source_search");
        Assert.IsFalse(mcpCatalog.IsError ?? false);
        Assert.AreEqual("applications", mcpCatalog.StructuredContent!.Value.GetProperty("kind").GetString());
        var callsBefore = repository.Calls;
        foreach (var query in new[] { "maxDepth=99", "maxDepth=no", "kind=unknown", "kind=function", "line=1", "maxResults=1&maxResults=2", "url=https://elsewhere", "buildId=bad", "includeContent=wrong", "direction=wrong" })
        {
            using var invalid = await http.GetAsync("/api/source-context/search?" + query);
            Assert.AreEqual(HttpStatusCode.BadRequest, invalid.StatusCode, query);
        }
        using var invalidPost = await http.PostAsync("/api/source-context/search", new StringContent("{\"kind\":null}", Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.BadRequest, invalidPost.StatusCode);
        Assert.AreEqual(true, (await mcp.CallToolAsync("yeshua_source_search", new Dictionary<string, object?> { ["unexpected"] = true })).IsError);
        Assert.AreEqual(true, (await mcp.CallToolAsync("yeshua_task_send", new Dictionary<string, object?> { ["message"] = "não executar" })).IsError);
        Assert.AreEqual(callsBefore, repository.Calls);
        using var missing = await http.GetAsync("/api/source-context/search?application=Missing&kind=dsl");
        Assert.AreEqual(HttpStatusCode.NotFound, missing.StatusCode);
    }

    [TestMethod]
    public async Task ReadWithoutContentDoesNotLoadSourceBodies()
    {
        var repository = new IndexedRepository();
        await new SourceSearch(repository).SearchAsync(new() { Kind = "screen", Application = "Memorias", Query = "cadastro" }, default);
        Assert.IsNull(repository.ContentBuild);
    }

    private sealed class IndexedRepository : ISourceContextRepository
    {
        public BuildSummary Build { get; } = new(Guid.Parse("11111111-1111-1111-1111-111111111111"), "Memorias", "commit-a", "a", "Yeshua.sln", new DateTime(2026, 10, 30, 0, 0, 0, DateTimeKind.Utc));
        public SourceDiscoveryRequest? Discovery;
        public FunctionSearchRequest? Function;
        public Guid? ContentBuild;
        public IReadOnlyList<string> ContentFiles = [];
        public bool LongLines;
        public string? CustomContent;
        public int Calls;
        private const string CodeFile = "src/Receivers/PublicarHandler.cs";
        public Task<IReadOnlyList<ApplicationSummary>> GetApplicationsAsync(CancellationToken token)
        { Calls++; return Task.FromResult<IReadOnlyList<ApplicationSummary>>([new(Guid.Empty, "Memorias", 1)]); }
        public Task<IReadOnlyList<BuildSummary>> GetBuildsAsync(string application, CancellationToken token)
        { Calls++; return Task.FromResult<IReadOnlyList<BuildSummary>>([Build]); }
        public Task<SourceContextResponse> DiscoverFilesAsync(SourceDiscoveryRequest request, CancellationToken token)
        {
            Calls++; Discovery = request;
            if (request.Application == "Missing") throw new KeyNotFoundException("No indexed build was found.");
            string[] files = request.File is not null ? [request.File] : ["src/Studio/Migrations/M000001.cs", "src/Studio/Migrations/M000002.cs"];
            var selected = files.Skip(request.Offset).Take(request.MaxResults ?? 10).ToArray();
            return Task.FromResult(new SourceContextResponse(Build, [], [], [], selected.Select(Candidate).ToArray(), [])
            {
                NextOffset = request.Offset + selected.Length < files.Length ? request.Offset + selected.Length : null
            });
        }
        public Task<SourceContextResponse> SearchFunctionAsync(FunctionSearchRequest request, CancellationToken token)
        {
            Calls++; Function = request;
            return Task.FromResult(new SourceContextResponse(Build,
                [new(Guid.Empty, "EXACT_SYMBOL", "METHOD", "Publicar", CodeFile, 3, 6)], [], [], [Candidate(CodeFile)], []));
        }
        private static SourceFileCandidate Candidate(string file) => new() { File = file, ArtifactKind = "DSL_SPECIFICATION" };
        public Task<IReadOnlyList<SourceFileContent>> GetSourceContentsAsync(Guid build, IReadOnlyList<string> files, CancellationToken token)
        {
            ContentBuild = build; ContentFiles = files;
            return Task.FromResult<IReadOnlyList<SourceFileContent>>(files.Select(file => new SourceFileContent(file,
                "DSL_SPECIFICATION", "USE_CASE", "IA_DEV", true, "THIS_FILE",
                CustomContent ?? (LongLines ? new string('a', 90) + "\n" + new string('b', 90) : "// irrelevante\nclass C\nvoid Publicar()\n{\nEnviar();\n}\n// outra função"))).ToArray());
        }
        public Task<SourceContextResponse> SearchFieldAsync(FieldSearchRequest request, CancellationToken token) => throw new NotSupportedException();
        public Task<SourceContextResponse> SearchClassAsync(ClassSearchRequest request, CancellationToken token) => throw new NotSupportedException();
        public Task<SourceContextResponse> SearchFilesAsync(FileSearchRequest request, CancellationToken token) => throw new NotSupportedException();
        public Task<IReadOnlyList<SourceFileHistory>> GetFileHistoryAsync(Guid build, IReadOnlyList<string> files, CancellationToken token) => throw new NotSupportedException();
    }
}
