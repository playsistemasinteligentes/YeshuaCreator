// <operational-spec>
// standard: OPERATIONAL_SUPPORT_ADOPTION_STANDARD
// gates: G1,G2,G3,G4,G5,G6,G7
// depths: D0,D1,D2
// severities: notApplicable
// dataClassification: SafeMetadata
// identities: Application,Environment,Version
// technicalOutcomes: Success,Failure
// businessOutcomes: notApplicable
// evidence: OperationalGateReport
// </operational-spec>

using System.Text.Json.Serialization;

namespace Yeshua.OperationalIntelligence.PostBuild;

public sealed class PostBuildManifest
{
    public string Application { get; init; } = string.Empty;
    public string Environment { get; init; } = "Production";
    public string BaseUrlSettingsFile { get; init; } = string.Empty;
    public string SmokeProject { get; init; } = string.Empty;
    public string ApiIdentityPath { get; init; } = "yapi/operational/identity";
    public string ApiLivenessPath { get; init; } = "yapi/health/live";
    public string ApiReadinessPath { get; init; } = "yapi/health/ready";
    public string WorkerLivenessPath { get; init; } = "yworker/health/live";
    public string WorkerReadinessPath { get; init; } = "yworker/health/ready";
    public IReadOnlyList<string> GateEvidenceFiles { get; init; } = [];
}

public sealed record PostBuildCheckResult(
    string Name,
    string Status,
    bool Required,
    long DurationMs,
    string Evidence,
    string[]? Gates = null);

public sealed record OperationalGateEvidence(
    string Gate,
    string Name,
    string Status,
    string Evidence,
    bool Required = true);

public sealed class OperationalGateEvidenceFile
{
    public IReadOnlyList<OperationalGateEvidence> Evidence { get; init; } = [];
}

public sealed record OperationalGateResult(
    string Gate,
    string Status,
    IReadOnlyList<string> Evidence,
    IReadOnlyList<string> Gaps);

public sealed class PostBuildHealthReport
{
    public required OperationalSpecificationClassification Specification { get; init; }
    public string Application { get; init; } = string.Empty;
    public string Environment { get; init; } = string.Empty;
    public string ExpectedCommit { get; init; } = string.Empty;
    public string? ObservedCommit { get; set; }
    public bool RequiresAllGates { get; set; }
    public bool Approved { get; set; }
    public DateTimeOffset StartedAtUtc { get; init; }
    public DateTimeOffset FinishedAtUtc { get; set; }
    public List<PostBuildCheckResult> Checks { get; } = [];
    public List<OperationalGateResult> Gates { get; } = [];
}

public static class OperationalGateEvaluator
{
    private static readonly string[] AllGates = ["G1", "G2", "G3", "G4", "G5", "G6", "G7"];

    public static IReadOnlyList<OperationalGateResult> Evaluate(
        IReadOnlyList<PostBuildCheckResult> checks)
    {
        return AllGates.Select(gate => EvaluateGate(gate, checks)).ToArray();
    }

    private static OperationalGateResult EvaluateGate(
        string gate,
        IReadOnlyList<PostBuildCheckResult> checks)
    {
        var related = checks
            .Where(check => ResolveGates(check).Contains(gate, StringComparer.OrdinalIgnoreCase))
            .ToArray();
        if (related.Length == 0)
        {
            return new OperationalGateResult(
                gate,
                "Missing",
                [],
                [$"No evidence was supplied for {gate}."]);
        }

        var failed = related
            .Where(check => check.Required && !string.Equals(check.Status, "Passed", StringComparison.OrdinalIgnoreCase))
            .ToArray();
        return new OperationalGateResult(
            gate,
            failed.Length == 0 ? "Passed" : "Failed",
            related.Select(check => $"{check.Name}: {check.Evidence}").ToArray(),
            failed.Select(check => $"{check.Name} status is {check.Status}.").ToArray());
    }

    private static IReadOnlyList<string> ResolveGates(PostBuildCheckResult check)
    {
        if (check.Gates is { Length: > 0 })
            return check.Gates;

        return check.Name switch
        {
            "BuildIntegrity" or "VersionIntegrity" => ["G2"],
            "ApiLiveness" or "ApiReadiness" or "WorkerLiveness" or
                "WorkerReadiness" or "DependencyHealth" => ["G4"],
            "CrudSmoke" or "PostBuildRunner" => ["G7"],
            _ => []
        };
    }
}

public sealed record OperationalSpecificationClassification(
    string Standard,
    string[] Gates,
    string[] Depths,
    string[] Severities,
    string[] DataClassification,
    string[] Identities,
    string[] TechnicalOutcomes,
    string[] BusinessOutcomes,
    string Evidence)
{
    public static OperationalSpecificationClassification PostBuild { get; } = new(
        "OPERATIONAL_SUPPORT_ADOPTION_STANDARD",
        ["G1", "G2", "G3", "G4", "G5", "G6", "G7"],
        ["D0", "D1", "D2"],
        ["notApplicable"],
        ["SafeMetadata"],
        ["Application", "Environment", "Version"],
        ["Success", "Failure"],
        ["notApplicable"],
        "OperationalGateReport");
}

public sealed class SmokeExecutionResult
{
    public required PostBuildCheckResult Check { get; init; }
    public required string LogPath { get; init; }
}

[JsonSourceGenerationOptions(WriteIndented = true, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(PostBuildManifest))]
[JsonSerializable(typeof(PostBuildHealthReport))]
[JsonSerializable(typeof(OperationalGateEvidenceFile))]
[JsonSerializable(typeof(OperationalSpecificationClassification))]
internal partial class PostBuildJsonContext : JsonSerializerContext;
