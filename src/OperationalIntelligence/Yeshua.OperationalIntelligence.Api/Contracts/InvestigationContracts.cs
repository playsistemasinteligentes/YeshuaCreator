namespace Yeshua.OperationalIntelligence.Api.Contracts;

public sealed class InvestigationRequest
{
    public string Application { get; init; } = string.Empty;
    public string? Version { get; init; }
    public string? Question { get; init; }
    public string? Purpose { get; init; }
    public string? Field { get; init; }
    public string? Class { get; init; }
    public string? Function { get; init; }
    public string? File { get; init; }
    public int? Line { get; init; }
    public int? MaxDepth { get; init; }
    public int? MaxResults { get; init; }
    public IReadOnlyList<string>? Sources { get; init; }
}

public sealed record ContextEvidence(
    string Source,
    string EvidenceType,
    string Description,
    string Application,
    string Version,
    DateTimeOffset CollectedAtUtc,
    double Confidence,
    object Data);

public sealed record CollectorResult(
    string Collector,
    IReadOnlyList<ContextEvidence> Evidence,
    IReadOnlyList<string> Warnings,
    TimeSpan Duration);

public sealed record InvestigationResponse(
    string Application,
    string? RequestedVersion,
    DateTimeOffset StartedAtUtc,
    TimeSpan Duration,
    IReadOnlyList<CollectorResult> Collectors,
    IReadOnlyList<ContextEvidence> Evidence,
    IReadOnlyList<string> Warnings);
