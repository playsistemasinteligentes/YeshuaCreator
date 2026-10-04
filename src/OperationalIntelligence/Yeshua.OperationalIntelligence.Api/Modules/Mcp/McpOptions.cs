namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public sealed class McpOptions
{
    public const string SectionName = "Mcp";

    public bool Enabled { get; init; } = true;
    public string LokiBaseUrl { get; init; } = "http://localhost:3100";
    public string TempoBaseUrl { get; init; } = "http://localhost:3200";
    public string PrometheusBaseUrl { get; init; } = "http://localhost:9090";
    public int DefaultLimit { get; init; } = 100;
    public int MaxLimit { get; init; } = 1000;
    public int TimeoutSeconds { get; init; } = 10;
    public int MaxTimeRangeHours { get; init; } = 24;
    public McpDatabaseQueryOptions DatabaseQuery { get; init; } = new();
}

public sealed class McpDatabaseQueryOptions
{
    public bool Enabled { get; init; } = true;
    public int MaxRows { get; init; } = 200;
    public int CommandTimeoutSeconds { get; init; } = 10;
    public int MaxSqlLength { get; init; } = 10_000;
    public Dictionary<string, string> Connections { get; init; } =
        new(StringComparer.OrdinalIgnoreCase);
}
