namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public static class McpToolSchemas
{
    public static object Empty() => new
    {
        type = "object",
        properties = new Dictionary<string, object>(),
        additionalProperties = false
    };

    public static object LogsQuery() => new
    {
        type = "object",
        properties = new Dictionary<string, object>
        {
            ["application"] = String("Application/service name used to narrow the query."),
            ["version"] = String("Optional indexed build version used when knowledge references are requested."),
            ["environment"] = String("Deployment environment name used to narrow the query."),
            ["fromUtc"] = DateTime("Range start in UTC."),
            ["toUtc"] = DateTime("Range end in UTC."),
            ["query"] = String("Raw LogQL query. When omitted, a safe default query is built from application/environment/text."),
            ["text"] = String("Optional text filter for default LogQL generation."),
            ["limit"] = Integer("Maximum number of log entries."),
            ["includeKnowledgeReferences"] = Boolean("When true, returns related knowledge references inferred from the returned logs."),
            ["includeSourceContent"] = Boolean("When knowledge references are enabled, returns source contents. Defaults to true."),
            ["knowledgeMaxSignals"] = Integer("Maximum extracted source clues to inspect."),
            ["knowledgeMaxFiles"] = Integer("Maximum ranked source files to return."),
            ["knowledgeMaxContentChars"] = Integer("Maximum characters returned per source file.")
        },
        required = new[] { "fromUtc", "toUtc" },
        additionalProperties = false
    };

    public static object ErrorsQuery() => new
    {
        type = "object",
        properties = new Dictionary<string, object>
        {
            ["application"] = String("Application/service name used to narrow the query."),
            ["version"] = String("Optional indexed build version used when knowledge references are requested."),
            ["environment"] = String("Deployment environment name used to narrow the query."),
            ["fromUtc"] = DateTime("Range start in UTC."),
            ["toUtc"] = DateTime("Range end in UTC."),
            ["text"] = String("Optional text filter in addition to error/failure terms."),
            ["limit"] = Integer("Maximum number of error log entries."),
            ["includeKnowledgeReferences"] = Boolean("When true, returns related knowledge references inferred from the returned error logs."),
            ["includeSourceContent"] = Boolean("When knowledge references are enabled, returns source contents. Defaults to true."),
            ["knowledgeMaxSignals"] = Integer("Maximum extracted source clues to inspect."),
            ["knowledgeMaxFiles"] = Integer("Maximum ranked source files to return."),
            ["knowledgeMaxContentChars"] = Integer("Maximum characters returned per source file.")
        },
        required = new[] { "fromUtc", "toUtc" },
        additionalProperties = false
    };

    public static object LogSourceContext() => new
    {
        type = "object",
        properties = new Dictionary<string, object>
        {
            ["application"] = String("Indexed application name."),
            ["version"] = String("Optional indexed build version."),
            ["log"] = String("One raw log entry, exception, stack trace, or JSON log object."),
            ["logs"] = ArrayOfStrings("Raw log entries, exceptions, stack traces, or JSON log objects."),
            ["includeContent"] = Boolean("Whether source file contents should be returned. Defaults to true."),
            ["maxSignals"] = Integer("Maximum extracted source clues to inspect."),
            ["maxFiles"] = Integer("Maximum ranked source files to return."),
            ["maxContentChars"] = Integer("Maximum characters returned per source file."),
            ["maxDepth"] = Integer("Maximum call/reference depth."),
            ["maxResults"] = Integer("Maximum number of source index results per extracted clue.")
        },
        required = new[] { "application" },
        additionalProperties = false
    };

    public static object TracesQuery() => new
    {
        type = "object",
        properties = new Dictionary<string, object>
        {
            ["traceId"] = String("TraceId for direct lookup in Tempo."),
            ["query"] = String("TraceQL query for Tempo search."),
            ["fromUtc"] = DateTime("Range start in UTC for search."),
            ["toUtc"] = DateTime("Range end in UTC for search."),
            ["limit"] = Integer("Maximum number of traces.")
        },
        additionalProperties = false
    };

    public static object MetricsQuery() => new
    {
        type = "object",
        properties = new Dictionary<string, object>
        {
            ["query"] = String("PromQL query."),
            ["fromUtc"] = DateTime("Range start in UTC."),
            ["toUtc"] = DateTime("Range end in UTC."),
            ["step"] = String("Prometheus step, for example 60s."),
            ["limit"] = Integer("Maximum number of returned series/items when post-processing applies.")
        },
        required = new[] { "query", "fromUtc", "toUtc" },
        additionalProperties = false
    };

    public static object SourceSearch() => new
    {
        type = "object",
        properties = new Dictionary<string, object>
        {
            ["application"] = String("Indexed application name."),
            ["version"] = String("Optional indexed build version."),
            ["kind"] = Enum("Search kind.", "field", "class", "function"),
            ["query"] = String("Symbol, field, class, or function name."),
            ["file"] = String("Optional source file filter for function search."),
            ["line"] = Integer("Optional line filter for function search."),
            ["maxDepth"] = Integer("Maximum call/reference depth."),
            ["maxResults"] = Integer("Maximum number of results.")
        },
        required = new[] { "application", "kind", "query" },
        additionalProperties = false
    };

    public static object DatabaseSelect() => new
    {
        type = "object",
        properties = new Dictionary<string, object>
        {
            ["connection"] = String("Configured database alias. The MCP client cannot send connection strings."),
            ["query"] = String("Single read-only SQL query. Only SELECT or WITH queries are accepted."),
            ["parameters"] = Object("Optional scalar SQL parameters. Use names without or with @."),
            ["maxRows"] = Integer("Maximum rows to return. The server clamps this to the configured limit."),
            ["timeoutSeconds"] = Integer("Command timeout. The server clamps this to the configured limit.")
        },
        required = new[] { "connection", "query" },
        additionalProperties = false
    };

    private static object String(string description) => new
    {
        type = "string",
        description
    };

    private static object DateTime(string description) => new
    {
        type = "string",
        format = "date-time",
        description
    };

    private static object Integer(string description) => new
    {
        type = "integer",
        minimum = 1,
        description
    };

    private static object Boolean(string description) => new
    {
        type = "boolean",
        description
    };

    private static object ArrayOfStrings(string description) => new
    {
        type = "array",
        description,
        items = new
        {
            type = "string"
        }
    };

    private static object Object(string description) => new
    {
        type = "object",
        description,
        additionalProperties = true
    };

    private static object Enum(string description, params string[] values) => new
    {
        type = "string",
        description,
        @enum = values
    };
}
