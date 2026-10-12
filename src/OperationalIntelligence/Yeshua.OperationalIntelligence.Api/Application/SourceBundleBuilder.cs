using System.Text;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Repositories;

namespace Yeshua.OperationalIntelligence.Api.Application;

public sealed class SourceBundleBuilder
{
    private readonly ISourceContextRepository _repository;

    public SourceBundleBuilder(ISourceContextRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> BuildAsync(
        QuestionContextResponse context,
        InvestigationResponse investigation,
        CancellationToken cancellationToken)
    {
        var output = new StringBuilder(RenderHeader(context));
        AppendOperationalEvidence(output, investigation);

        if (context.BuildId == Guid.Empty)
        {
            output.AppendLine();
            output.AppendLine("NO_SOURCE_FILES_FOUND");
            return output.ToString();
        }

        var contents = await _repository.GetSourceContentsAsync(
            context.BuildId,
            context.SourceFiles.Select(file => file.File).ToArray(),
            cancellationToken);
        var byPath = contents.ToDictionary(item => item.File, StringComparer.OrdinalIgnoreCase);
        var history = await _repository.GetFileHistoryAsync(
            context.BuildId,
            context.SourceFiles.Select(file => file.File).ToArray(),
            cancellationToken);
        var historyByPath = history
            .GroupBy(item => item.File, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.ToArray(), StringComparer.OrdinalIgnoreCase);
        foreach (var file in context.SourceFiles)
        {
            output.AppendLine();
            output.AppendLine("================================================================================");
            output.AppendLine($"FILE: {file.File}");
            output.AppendLine($"ARTIFACT: {file.ArtifactKind}");
            output.AppendLine($"ROLE: {file.SourceRole}");
            output.AppendLine($"OWNERSHIP: {file.Ownership}");
            output.AppendLine($"EDITABLE: {file.Editable.ToString().ToLowerInvariant()}");
            output.AppendLine($"SOURCE_OF_TRUTH: {file.SourceOfTruth}");
            output.AppendLine($"REASONS: {string.Join(", ", file.Reasons)}");
            output.AppendLine($"RELEVANT_LINES: {string.Join(", ", file.RelevantLines)}");
            if (historyByPath.TryGetValue(file.File, out var fileHistory))
            {
                output.AppendLine("CONFIRMED_GIT_HISTORY:");
                foreach (var change in fileHistory)
                    output.AppendLine($"- {change.CommitSha} | {change.CommittedAtUtc:O} | {change.ChangeType} | {change.Message}");
            }
            output.AppendLine("--------------------------------------------------------------------------------");
            output.AppendLine(byPath.TryGetValue(file.File, out var source)
                ? source.Content
                : "SOURCE_CONTENT_NOT_FOUND_IN_SNAPSHOT");
        }

        return output.ToString();
    }

    private static void AppendOperationalEvidence(
        StringBuilder output,
        InvestigationResponse investigation)
    {
        var runtime = investigation.Evidence
            .Select(evidence => evidence.Data)
            .OfType<RuntimeInvestigationEvidence>()
            .ToArray();
        if (runtime.Length == 0)
            return;

        AppendSection(output, "RUNTIME FACTS", runtime.SelectMany(item => item.Facts));
        AppendSection(output, "SOURCE INFERENCES", runtime.SelectMany(item => item.Inferences));
        AppendSection(output, "EVIDENCE GAPS", runtime.SelectMany(item => item.Gaps));
    }

    private static void AppendSection(
        StringBuilder output,
        string title,
        IEnumerable<string> entries)
    {
        var values = entries.Distinct(StringComparer.Ordinal).ToArray();
        output.AppendLine();
        output.AppendLine(title + ":");
        if (values.Length == 0)
        {
            output.AppendLine("- none");
            return;
        }

        foreach (var value in values)
            output.AppendLine("- " + value);
    }

    private static string RenderHeader(QuestionContextResponse context)
        => $"""
           YESHUA OPERATIONAL SOURCE CONTEXT
           APPLICATION: {context.Application}
           VERSION: {context.Version}
           PURPOSE: {context.Purpose}
           QUESTION: {context.Question}

           AGENT INSTRUCTION:
           {context.AgentInstruction}

           SOURCE FILE COUNT: {context.SourceFiles.Count}
           GENERATED AT UTC: {context.GeneratedAtUtc:O}
           """;
}
