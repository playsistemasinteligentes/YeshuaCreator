namespace Yeshua.OperationalIntelligence.Api.Contracts;

public sealed record QuestionContextSummary(
    int SymbolCount,
    int ReadReferenceCount,
    int WriteReferenceCount,
    int OtherReferenceCount,
    int CallChainCount,
    int SourceFileCount);

public sealed record QuestionContextFile(
    string File,
    int Score,
    IReadOnlyList<string> Reasons,
    IReadOnlyList<int> RelevantLines,
    string ArtifactKind,
    string SourceRole,
    string Ownership,
    bool Editable,
    string SourceOfTruth);

public sealed record QuestionContextResponse(
    Guid BuildId,
    string Application,
    string Version,
    string? Question,
    string Purpose,
    string AgentInstruction,
    string SourceSolution,
    DateTime GeneratedAtUtc,
    QuestionContextSummary Summary,
    IReadOnlyList<QuestionContextFile> SourceFiles,
    IReadOnlyList<string> Warnings);
