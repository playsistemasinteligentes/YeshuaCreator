using System.Text.Json;
using System.Text.Json.Nodes;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

// Static contracts, built once. Dynamic telemetry/SQL values deliberately remain JSON.
public static class McpOutputSchemas
{
    private static readonly IReadOnlyDictionary<string, JsonElement> Schemas = Build();
    private static readonly JsonElement Empty = JsonSerializer.SerializeToElement(new { type = "object" });

    public static JsonElement For(string name) => Schemas.TryGetValue(name.Replace('.', '_'), out var schema) ? schema : Empty;

    private static IReadOnlyDictionary<string, JsonElement> Build()
    {
        var text = Type("string");
        var integer = Type("integer");
        var number = Type("number");
        var boolean = Type("boolean");
        var strings = Array(text);
        var json = new JsonObject();
        var build = Object(("buildId", text), ("application", text), ("version", text),
            ("commitSha", Nullable(text)), ("sourceSolution", text), ("generatedAtUtc", text));
        var file = Object(("file", text), ("reason", text), ("artifactKind", text),
            ("sourceRole", text), ("ownership", text), ("editable", boolean), ("sourceOfTruth", text));
        var match = Object(("symbolId", text), ("matchKind", text), ("symbolKind", text),
            ("qualifiedName", text), ("file", Nullable(text)), ("startLine", Nullable(integer)), ("endLine", Nullable(integer)));
        var reference = Object(("kind", text), ("symbol", text), ("accessKind", Nullable(text)),
            ("containingFunction", Nullable(text)), ("file", text), ("line", integer), ("column", integer));
        var chain = Object(("direction", text), ("depth", integer), ("path", text),
            ("referenceFile", Nullable(text)), ("referenceLine", Nullable(integer)), ("isRoot", boolean));
        var evidence = Object(("source", text), ("evidenceType", text), ("description", text),
            ("application", text), ("version", text), ("collectedAtUtc", text), ("confidence", number), ("data", json));
        var questionContext = Object(("buildId", text), ("application", text), ("version", text),
            ("question", Nullable(text)), ("purpose", text), ("agentInstruction", text), ("sourceSolution", text),
            ("generatedAtUtc", text), ("summary", Object(("symbolCount", integer), ("readReferenceCount", integer),
                ("writeReferenceCount", integer), ("otherReferenceCount", integer), ("callChainCount", integer), ("sourceFileCount", integer))),
            ("sourceFiles", Array(Object(("file", text), ("score", integer), ("reasons", strings), ("relevantLines", Array(integer)),
                ("artifactKind", text), ("sourceRole", text), ("ownership", text), ("editable", boolean), ("sourceOfTruth", text)))),
            ("warnings", strings));
        var signal = Object(("kind", text), ("symbol", text), ("file", Nullable(text)),
            ("line", Nullable(integer)), ("evidence", text), ("confidence", number));
        var logSource = Object(("extractedSignals", Array(signal)), ("context", Nullable(questionContext)),
            ("sourceContents", Array(Object(("file", text), ("score", integer), ("reasons", strings),
                ("relevantLines", Array(integer)), ("artifactKind", text), ("sourceRole", text),
                ("ownership", text), ("editable", boolean), ("sourceOfTruth", text), ("content", text), ("truncated", boolean)))),
            ("evidence", Array(evidence)), ("warnings", strings));
        var telemetry = Object(("source", text), ("query", text), ("fromUtc", Nullable(text)),
            ("toUtc", Nullable(text)), ("httpStatusCode", Nullable(integer)), ("data", json), ("warnings", strings));
        var logs = new JsonObject
        {
            ["type"] = "object",
            ["anyOf"] = new JsonArray(telemetry.DeepClone(), Object(("telemetry", telemetry),
                ("knowledgeReferences", Nullable(logSource)), ("warnings", strings)))
        };
        var accountStatus = Object(("sessionId", text), ("state", text), ("queuePaused", boolean),
            ("account", Nullable(Object(("type", text), ("email", Nullable(text)), ("planType", Nullable(text))))),
            ("login", Nullable(Object(("loginId", text), ("verificationUrl", text), ("userCode", text), ("waitingUntilUtc", text)))),
            ("limits", Array(Object(("limitId", text), ("primary", Nullable(Window())), ("secondary", Nullable(Window()))))),
            ("instruction", text));
        var health = Object(("mcp", text), ("loki", text), ("tempo", text), ("prometheus", text));
        // Partial backend health fixtures/implementations remain compatible.
        health["required"] = new JsonArray("mcp");
        var searchArguments = JsonSerializer.SerializeToNode(McpToolSchemas.SourceSearch())!;
        foreach (var name in new[] { "application", "version", "buildId", "query", "file", "line", "endLine" })
            searchArguments["properties"]![name] = Nullable(searchArguments["properties"]![name]!);
        var schemas = new Dictionary<string, JsonNode>(StringComparer.Ordinal)
        {
            ["yeshua_health"] = health,
            ["yeshua_explorer"] = Object(("guide", text)),
            ["yeshua_app_explore"] = Object(("scope", text), ("retrievedAtUtc", text), ("catalogUrl", text),
                ("applications", Array(Object(("application", text), ("title", text), ("entryUrl", text),
                    ("loginUrl", text), ("registerUrl", text), ("recoveryUrl", text), ("screens", strings)))),
                ("sources", Array(Object(("url", text), ("content", text)))), ("notice", text)),
            ["yeshua_source_search"] = Object(("kind", text), ("build", Nullable(build)),
                ("applications", Array(Object(("applicationId", text), ("name", text), ("buildCount", integer)))),
                ("builds", Array(build)), ("matches", Array(match)), ("references", Array(reference)),
                ("chains", Array(chain)), ("sourceFiles", Array(file)),
                ("snippets", Array(Object(("file", text), ("startLine", integer), ("endLine", integer),
                    ("totalLines", integer), ("content", text), ("complete", boolean)))),
                ("next", Array(Object(("reason", text), ("arguments", searchArguments), ("url", text)))), ("warnings", strings)),
            ["yeshua_logs_query"] = logs,
            ["yeshua_errors_query"] = logs,
            ["yeshua_traces_query"] = telemetry,
            ["yeshua_metrics_query"] = telemetry,
            ["yeshua_logs_source_context"] = logSource,
            ["yeshua_database_select"] = Object(("connection", text), ("executedAtUtc", text),
                ("elapsedMilliseconds", integer), ("rowCount", integer), ("truncated", boolean),
                ("columns", Array(Object(("name", text), ("dataType", text)))),
                ("rows", Array(new JsonObject { ["type"] = "object", ["additionalProperties"] = true })), ("warnings", strings)),
            ["yeshua_task_send"] = Object(("taskId", text), ("requestId", text), ("status", text),
                ("acceptedAtUtc", text), ("duplicate", boolean)),
            ["yeshua_task_read"] = Object(("tasks", Array(Object(("selectionNumber", Nullable(integer)),
                    ("taskId", text), ("title", text), ("status", text), ("createdAtUtc", text), ("updatedAtUtc", text)))),
                ("messages", Array(Object(("requestId", text), ("status", text), ("message", text), ("mode", text),
                    ("response", Nullable(text)), ("progress", Nullable(text)), ("createdAtUtc", text), ("updatedAtUtc", text)))),
                ("instruction", text), ("activeExecution", Nullable(Object(("taskId", text), ("requestId", text), ("restartRequested", boolean))))),
            ["yeshua_agent_restart"] = Object(("taskId", text), ("requestId", text), ("status", text), ("instruction", text)),
            ["yeshua_codex_status"] = accountStatus,
            ["yeshua_codex_auth"] = Object(("requestId", text), ("action", text), ("duplicate", boolean), ("status", accountStatus))
        };
        return schemas.ToDictionary(pair => pair.Key, pair => JsonSerializer.SerializeToElement(pair.Value), StringComparer.Ordinal);
    }

    private static JsonObject Window() => Object(("usedPercent", Type("number")),
        ("windowDurationMins", Nullable(Type("integer"))), ("resetsAt", Nullable(Type("integer"))));
    private static JsonObject Type(string type) => new() { ["type"] = type };
    private static JsonObject Array(JsonNode item) => new() { ["type"] = "array", ["items"] = item.DeepClone() };
    private static JsonObject Nullable(JsonNode item) => new() { ["anyOf"] = new JsonArray(item.DeepClone(), Type("null")) };
    private static JsonObject Object(params (string Name, JsonNode Schema)[] fields) => new()
    {
        ["type"] = "object",
        ["properties"] = new JsonObject(fields.Select(field => KeyValuePair.Create<string, JsonNode?>(field.Name, field.Schema.DeepClone()))),
        ["required"] = new JsonArray(fields.Select(field => (JsonNode?)JsonValue.Create(field.Name)).ToArray()),
        ["additionalProperties"] = false
    };
}
