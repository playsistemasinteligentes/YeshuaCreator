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
    IReadOnlyList<int> RelevantLines);

public sealed record QuestionContextResponse(
    string Application,
    string Version,
    string? Question,
    string AgentInstruction,
    string SourceSolution,
    DateTime GeneratedAtUtc,
    QuestionContextSummary Summary,
    IReadOnlyList<QuestionContextFile> SourceFiles,
    IReadOnlyList<string> Warnings);
