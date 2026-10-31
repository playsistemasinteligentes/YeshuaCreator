using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Clients;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;
using Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

namespace Yeshua.OperationalIntelligence.Api.Tests;

[TestClass]
public sealed class McpOutputContractTests
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    [TestMethod]
    public async Task ActualPublicInterfaceAndTelemetryResultsMatchAdvertisedContracts()
    {
        using var http = new HttpClient(new EvidenceHttp()) { BaseAddress = new Uri("https://test.example/") };
        var arguments = new McpToolArgumentReader(Options.Create(new McpOptions()));
        var resolver = new LogKnowledgeReferenceResolver(new EmptySourceRepository(), new QuestionContextBuilder(), new LogSourceEvidenceExtractor());
        var enricher = new LogKnowledgeReferenceEnricher(resolver, arguments);
        IMcpTool[] tools = [new ExplorerTool(new ExplorerDocument()), new PublicAppExploreTool(new PublicAppExplorer(http)),
            new HealthTool(new LokiClient(http), new TempoClient(http), new PrometheusClient(http)),
            new LogsQueryTool(new LokiClient(http), arguments, enricher), new ErrorsQueryTool(new LokiClient(http), arguments, enricher),
            new TracesQueryTool(new TempoClient(http), arguments), new MetricsQueryTool(new PrometheusClient(http), arguments),
            new LogSourceContextTool(resolver, arguments), new SourceSearchTool(new SourceSearch(new EmptySourceRepository()))];
        foreach (var tool in tools)
        {
            var input = tool.Name switch
            {
                "yeshua_app_explore" => """{"application":"Memorias","screen":"register"}""",
                "yeshua.traces.query" => """{"traceId":"00000000000000000000000000000000"}""",
                "yeshua.metrics.query" => """{"query":"vector(1)","fromUtc":"2026-10-31T10:00:00Z","toUtc":"2026-10-31T10:01:00Z"}""",
                "yeshua.logs.query" or "yeshua.errors.query" => """{"fromUtc":"2026-10-31T10:00:00Z","toUtc":"2026-10-31T10:01:00Z"}""",
                "yeshua.logs.source_context" => """{"application":"Memorias","log":"synthetic marker"}""",
                _ => "{}"
            };
            var request = JsonSerializer.Deserialize<JsonElement>(input);
            Validate(JsonSerializer.SerializeToElement(tool.InputSchema, JsonOptions), request);
            var result = await tool.CallAsync(request, default);
            Assert.IsFalse(result.IsError, tool.Name);
            Validate(McpOutputSchemas.For(tool.Name), JsonSerializer.SerializeToElement(result.StructuredContent, JsonOptions));
        }
        var enriched = await tools.Single(tool => tool.Name == "yeshua.logs.query").CallAsync(
            JsonSerializer.Deserialize<JsonElement>("""{"application":"Memorias","includeKnowledgeReferences":true}"""), default);
        Validate(McpOutputSchemas.For("yeshua_logs_query"), JsonSerializer.SerializeToElement(enriched.StructuredContent, JsonOptions));
        var syntheticArguments = JsonSerializer.Deserialize<JsonElement>("""{"application":"Memorias","log":"at Example.Handler.Execute() in src/Handler.cs:line 3","includeContent":false,"maxDepth":0}""");
        Validate(JsonSerializer.SerializeToElement(McpToolSchemas.LogSourceContext(), JsonOptions), syntheticArguments);
        var syntheticStack = await tools.Single(tool => tool.Name == "yeshua.logs.source_context").CallAsync(syntheticArguments, default);
        Validate(McpOutputSchemas.For("yeshua_logs_source_context"), JsonSerializer.SerializeToElement(syntheticStack.StructuredContent, JsonOptions));
        foreach (var input in new[] { new SourceExplorationRequest(), new() { Kind = "builds", Application = "Memorias" },
                     new() { Kind = "file", Application = "Memorias", File = "src/test.cs", IncludeContent = true } })
        {
            var response = await new SourceSearch(new EmptySourceRepository()).SearchAsync(input, default);
            Validate(McpOutputSchemas.For("yeshua_source_search"), JsonSerializer.SerializeToElement(response, JsonOptions));
            foreach (var next in response.Next)
                Validate(JsonSerializer.SerializeToElement(McpToolSchemas.SourceSearch(), JsonOptions),
                    JsonSerializer.SerializeToElement(next.Arguments, JsonOptions));
        }
    }

    [TestMethod]
    public void SqlAndAgentTypedResultsMatchSchemasAndMissingEvidenceIsRejected()
    {
        var id = Guid.NewGuid();
        var now = DateTimeOffset.UtcNow;
        var status = new CodexAccountStatus(id, "Ready", false, new("chatgpt", null, null), null, [], "ready");
        (string Name, object Result)[] cases =
        [
            ("yeshua_database_select", new DatabaseSelectResult("test", now, 1, 1, false, [new("probe", "int")],
                [new Dictionary<string, object?> { ["probe"] = 1 }], [])),
            ("yeshua_task_send", new AgentTaskReceipt(id, "request", "Queued", now, false)),
            ("yeshua_task_read", new AgentTaskReadResult([new() { TaskId = id }], [new()], "read", null)),
            ("yeshua_agent_restart", new AgentRestartReceipt(id, "request", "NotRunning", "read")),
            ("yeshua_codex_status", status),
            ("yeshua_codex_auth", new CodexAuthReceipt("request", "cancel", false, status))
        ];
        foreach (var sample in cases)
            Validate(McpOutputSchemas.For(sample.Name), JsonSerializer.SerializeToElement(sample.Result, JsonOptions));
        Assert.ThrowsException<AssertFailedException>(() => Validate(McpOutputSchemas.For("yeshua_source_search"),
            JsonSerializer.Deserialize<JsonElement>("""{"kind":"applications"}""")));
        Assert.ThrowsException<AssertFailedException>(() => Validate(McpOutputSchemas.For("yeshua_database_select"),
            JsonSerializer.Deserialize<JsonElement>("""{"connection":"test","rowCount":"not-a-number"}""")));
    }

    // Covers the JSON Schema features in our static contracts; no schema generation/reflection.
    internal static void Validate(JsonElement schema, JsonElement value, string path = "$")
    {
        if (schema.TryGetProperty("anyOf", out var alternatives))
        {
            var matched = alternatives.EnumerateArray().Any(option =>
            {
                try { Validate(option, value, path); return true; }
                catch (AssertFailedException) { return false; }
            });
            Assert.IsTrue(matched, path + " does not match any allowed shape");
        }
        if (schema.TryGetProperty("type", out var type))
        {
            var valid = type.GetString() switch
            {
                "object" => value.ValueKind == JsonValueKind.Object,
                "array" => value.ValueKind == JsonValueKind.Array,
                "string" => value.ValueKind == JsonValueKind.String,
                "integer" => value.ValueKind == JsonValueKind.Number && value.TryGetInt64(out _),
                "number" => value.ValueKind == JsonValueKind.Number,
                "boolean" => value.ValueKind is JsonValueKind.True or JsonValueKind.False,
                "null" => value.ValueKind == JsonValueKind.Null,
                _ => false
            };
            Assert.IsTrue(valid, path + " expected " + type.GetString());
        }
        if (schema.TryGetProperty("enum", out var allowed))
            Assert.IsTrue(allowed.EnumerateArray().Any(item => item.GetRawText() == value.GetRawText()), path + " invalid enum");
        if (value.ValueKind == JsonValueKind.Number)
        {
            if (schema.TryGetProperty("minimum", out var minimum)) Assert.IsTrue(value.GetDouble() >= minimum.GetDouble(), path);
            if (schema.TryGetProperty("maximum", out var maximum)) Assert.IsTrue(value.GetDouble() <= maximum.GetDouble(), path);
        }
        if (value.ValueKind == JsonValueKind.Object)
        {
            if (schema.TryGetProperty("required", out var required))
                foreach (var field in required.EnumerateArray()) Assert.IsTrue(value.TryGetProperty(field.GetString()!, out _), path + "." + field.GetString());
            if (schema.TryGetProperty("properties", out var properties))
                foreach (var field in value.EnumerateObject())
                {
                    if (properties.TryGetProperty(field.Name, out var child)) Validate(child, field.Value, path + "." + field.Name);
                    else if (schema.TryGetProperty("additionalProperties", out var extra) && extra.ValueKind == JsonValueKind.False)
                        Assert.Fail(path + " unknown property " + field.Name);
                }
        }
        if (value.ValueKind == JsonValueKind.Array && schema.TryGetProperty("items", out var items))
        {
            var index = 0;
            foreach (var item in value.EnumerateArray()) Validate(items, item, path + "[" + index++ + "]");
        }
    }

    private sealed class EvidenceHttp : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            var body = request.RequestUri!.AbsolutePath switch
            {
                "/applications.json" => """[{"application":"Memorias","title":"Memorias"}]""",
                "/spa/views/register.html" => "<form><input id='nome' required></form>",
                "/spa/scripts/viewsScripts/register.js" => "function register() {}",
                _ => """{"status":"success","data":{"result":[]}}"""
            };
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(body, Encoding.UTF8, "application/json") });
        }
    }

    private sealed class EmptySourceRepository : Repositories.ISourceContextRepository
    {
        private static readonly BuildSummary Build = new(Guid.NewGuid(), "Memorias", "test", null, "Test.sln", DateTime.UtcNow);
        private static SourceContextResponse Context() => new(Build, [], [], [], [new() { File = "src/test.cs" }], []);
        public Task<IReadOnlyList<ApplicationSummary>> GetApplicationsAsync(CancellationToken token) => Task.FromResult<IReadOnlyList<ApplicationSummary>>([new(Guid.NewGuid(), "Memorias", 1)]);
        public Task<IReadOnlyList<BuildSummary>> GetBuildsAsync(string app, CancellationToken token) => Task.FromResult<IReadOnlyList<BuildSummary>>([Build]);
        public Task<SourceContextResponse> DiscoverFilesAsync(SourceDiscoveryRequest request, CancellationToken token) => Task.FromResult(Context());
        public Task<SourceContextResponse> SearchFieldAsync(FieldSearchRequest request, CancellationToken token) => Task.FromResult(Context());
        public Task<SourceContextResponse> SearchClassAsync(ClassSearchRequest request, CancellationToken token) => Task.FromResult(Context());
        public Task<SourceContextResponse> SearchFunctionAsync(FunctionSearchRequest request, CancellationToken token) => Task.FromResult(Context());
        public Task<SourceContextResponse> SearchFilesAsync(FileSearchRequest request, CancellationToken token) => Task.FromResult(Context());
        public Task<IReadOnlyList<SourceFileContent>> GetSourceContentsAsync(Guid id, IReadOnlyList<string> files, CancellationToken token) =>
            Task.FromResult<IReadOnlyList<SourceFileContent>>([new("src/test.cs", "APPLICATION_SOURCE", "USE_CASE", "IA_DEV", true, "THIS_FILE", "class Example {}")]);
        public Task<IReadOnlyList<SourceFileHistory>> GetFileHistoryAsync(Guid id, IReadOnlyList<string> files, CancellationToken token) => Task.FromResult<IReadOnlyList<SourceFileHistory>>([]);
    }
}
