namespace Yeshua.OperationalIntelligence.Api.Modules.OperationalControl;

public sealed record OperationalLoggingPolicy(
    string Application,
    string Environment,
    string Revision,
    string DefaultLevel,
    string DefaultDepth,
    IReadOnlyList<DiagnosticTarget> Targets,
    DateTimeOffset UpdatedAtUtc,
    string Source)
{
    public IReadOnlyList<DiagnosticPolicyAuditEntry> DiagnosticAudit { get; init; } = [];
}

public sealed record DiagnosticPolicyAuditEntry(
    string DiagnosticSessionId,
    string Action,
    DateTimeOffset OccurredAtUtc,
    string RequestedBy,
    string ApprovedBy,
    string Justification);

public sealed record DiagnosticTarget(
    string? Component,
    string? Operation,
    string? Entity,
    string? RecordId,
    string Level,
    string Depth,
    DateTimeOffset? ExpiresAtUtc)
{
    public string? Field { get; init; }
    public string? OperationId { get; init; }
    public string? DiagnosticSessionId { get; init; }
    public string? RequestedBy { get; init; }
    public string? ApprovedBy { get; init; }
    public string? Justification { get; init; }
    public DateTimeOffset? StartsAtUtc { get; init; }
    public int? MaximumCaptures { get; init; }
    public IReadOnlyList<string>? AuthorizedFields { get; init; }
}

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
