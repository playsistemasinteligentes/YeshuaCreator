// <operational-spec>
// standard: OPERATIONAL_SUPPORT_ADOPTION_STANDARD
// gates: G2,G7
// depths: D0
// severities: notApplicable
// modes: Live
// dataClassification: SafeMetadata
// identities: Application,Environment,Version
// technicalOutcomes: Success,Failure
// businessOutcomes: notApplicable
// evidence: PostBuildHealthReport
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
}

public sealed record PostBuildCheckResult(
    string Name,
    string Status,
    bool Required,
    long DurationMs,
    string Evidence);

public sealed class PostBuildHealthReport
{
    public required OperationalSpecificationClassification Specification { get; init; }
    public string Application { get; init; } = string.Empty;
    public string Environment { get; init; } = string.Empty;
    public string ExpectedCommit { get; init; } = string.Empty;
    public string? ObservedCommit { get; set; }
    public bool Approved { get; set; }
    public DateTimeOffset StartedAtUtc { get; init; }
    public DateTimeOffset FinishedAtUtc { get; set; }
    public List<PostBuildCheckResult> Checks { get; } = [];
}

public sealed record OperationalSpecificationClassification(
    string Standard,
    string[] Gates,
    string[] Depths,
    string[] Severities,
    string[] Modes,
    string[] DataClassification,
    string[] Identities,
    string[] TechnicalOutcomes,
    string[] BusinessOutcomes,
    string Evidence)
{
    public static OperationalSpecificationClassification PostBuild { get; } = new(
        "OPERATIONAL_SUPPORT_ADOPTION_STANDARD",
        ["G2", "G7"],
        ["D0"],
        ["notApplicable"],
        ["Live"],
        ["SafeMetadata"],
        ["Application", "Environment", "Version"],
        ["Success", "Failure"],
        ["notApplicable"],
        "PostBuildHealthReport");
}

public sealed class SmokeExecutionResult
{
    public required PostBuildCheckResult Check { get; init; }
    public required string LogPath { get; init; }
}

[JsonSourceGenerationOptions(WriteIndented = true, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(PostBuildManifest))]
[JsonSerializable(typeof(PostBuildHealthReport))]
[JsonSerializable(typeof(OperationalSpecificationClassification))]
internal partial class PostBuildJsonContext : JsonSerializerContext;
