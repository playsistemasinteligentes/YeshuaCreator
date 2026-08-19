namespace Yeshua.OperationalIntelligence.Api.Configuration;

public sealed class OperationalIntelligenceOptions
{
    public const string SectionName = "OperationalIntelligence";

    public bool EnsureDatabase { get; init; } = true;
    public bool RunMigrations { get; init; } = true;
    public int CommandTimeoutSeconds { get; init; } = 60;
    public int DefaultMaxDepth { get; init; } = 12;
    public int MaximumMaxDepth { get; init; } = 100;
    public int DefaultMaxResults { get; init; } = 500;
    public int MaximumMaxResults { get; init; } = 5000;
    public int CollectorTimeoutSeconds { get; init; } = 30;
}
