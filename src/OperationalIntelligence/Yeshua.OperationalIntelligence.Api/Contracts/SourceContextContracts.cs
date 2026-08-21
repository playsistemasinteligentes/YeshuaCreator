namespace Yeshua.OperationalIntelligence.Api.Contracts;

public sealed record ApplicationSummary(Guid ApplicationId, string Name, int BuildCount);

public sealed record BuildSummary(
    Guid BuildId,
    string Application,
    string Version,
    string? CommitSha,
    string SourceSolution,
    DateTime GeneratedAtUtc);

public abstract class SourceSearchRequest
{
    public string Application { get; init; } = string.Empty;
    public string? Version { get; init; }
    public int? MaxDepth { get; init; }
    public int? MaxResults { get; init; }
}

public sealed class FieldSearchRequest : SourceSearchRequest
{
    public string Field { get; init; } = string.Empty;
    public bool IncludeSameName { get; init; } = true;
}

public sealed class ClassSearchRequest : SourceSearchRequest
{
    public string Class { get; init; } = string.Empty;
    public bool IncludeSameName { get; init; } = true;
}

public sealed class FunctionSearchRequest : SourceSearchRequest
{
    public string Function { get; init; } = string.Empty;
    public string? File { get; init; }
    public int? Line { get; init; }
}

public sealed record SymbolMatch(
    Guid SymbolId,
    string MatchKind,
    string SymbolKind,
    string QualifiedName,
    string? File,
    int? StartLine,
    int? EndLine);

public sealed record ReferenceEvidence(
    string Kind,
    string Symbol,
    string? AccessKind,
    string? ContainingFunction,
    string File,
    int Line,
    int Column);

public sealed record FunctionChain(
    string Direction,
    int Depth,
    string Path,
    string? ReferenceFile,
    int? ReferenceLine,
    bool IsRoot);

public sealed class SourceFileCandidate
{
    public string File { get; init; } = string.Empty;
    public string Reason { get; init; } = string.Empty;
    public string ArtifactKind { get; init; } = "UNKNOWN";
    public string SourceRole { get; init; } = "APPLICATION_SOURCE";
    public string Ownership { get; init; } = "UNKNOWN";
    public bool Editable { get; init; } = true;
    public string SourceOfTruth { get; init; } = "THIS_FILE";
}

public sealed record SourceFileContent(
    string File,
    string ArtifactKind,
    string SourceRole,
    string Ownership,
    bool Editable,
    string SourceOfTruth,
    string Content);

public sealed record SourceFileHistory(
    string File,
    string CommitSha,
    DateTime CommittedAtUtc,
    string? AuthorName,
    string? Message,
    string ChangeType);

public sealed record SourceContextResponse(
    BuildSummary Build,
    IReadOnlyList<SymbolMatch> Matches,
    IReadOnlyList<ReferenceEvidence> References,
    IReadOnlyList<FunctionChain> Chains,
    IReadOnlyList<SourceFileCandidate> SourceFiles,
    IReadOnlyList<string> Warnings);
