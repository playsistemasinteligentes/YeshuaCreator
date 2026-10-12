using System.Text.Json;

namespace Yeshua.OperationalIntelligence.Api.Contracts;

public sealed record RuntimeEvidenceQuery(
    string Application,
    string? Version,
    string? Environment,
    string? RootOperationId,
    string? OperationId,
    string? OperationalEntityId,
    string? TraceId,
    DateTimeOffset FromUtc,
    DateTimeOffset ToUtc,
    int Limit);

public sealed record RuntimeEvidenceResponse(
    string Provider,
    string Query,
    DateTimeOffset FromUtc,
    DateTimeOffset ToUtc,
    int? HttpStatusCode,
    int RecordCount,
    string? ResolvedVersion,
    string? ResolvedCommitSha,
    JsonElement? Data,
    IReadOnlyList<string> Warnings);

public sealed record RuntimeInvestigationEvidence(
    RuntimeEvidenceResponse Runtime,
    object? KnowledgeReferences,
    IReadOnlyList<string> Facts,
    IReadOnlyList<string> Inferences,
    IReadOnlyList<string> Gaps);
