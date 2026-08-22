namespace Yeshua.OperationalIntelligence.Api.Modules.OperationalControl;

public sealed record OperationalLoggingPolicy(
    string Application,
    string Environment,
    string Revision,
    string DefaultLevel,
    string DefaultDepth,
    IReadOnlyList<DiagnosticTarget> Targets,
    DateTimeOffset UpdatedAtUtc,
    string Source);

public sealed record DiagnosticTarget(
    string? Component,
    string? Operation,
    string? Entity,
    string? RecordId,
    string Level,
    string Depth,
    DateTimeOffset? ExpiresAtUtc);

public sealed record OperationalLoggingPolicyUpdate(
    string DefaultLevel,
    string DefaultDepth,
    IReadOnlyList<DiagnosticTarget>? Targets);

public sealed class OperationalControlOptions
{
    public const string SectionName = "OperationalControl";

    public Dictionary<string, Dictionary<string, OperationalLoggingPolicyConfiguration>> Applications { get; init; } = [];
}

public sealed class OperationalLoggingPolicyConfiguration
{
    public string DefaultLevel { get; init; } = "Information";
    public string DefaultDepth { get; init; } = "D0";
    public List<DiagnosticTarget> Targets { get; init; } = [];
}
