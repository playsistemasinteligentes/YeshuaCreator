using Yeshua.OperationalIntelligence.Api.Contracts;

namespace Yeshua.OperationalIntelligence.Api.Application;

public sealed class QuestionContextBuilder
{
    public QuestionContextResponse Build(
        InvestigationRequest request,
        InvestigationResponse investigation)
    {
        var purpose = NormalizePurpose(request.Purpose);
        var contexts = investigation.Collectors
            .SelectMany(collector => collector.Evidence)
            .Select(evidence => evidence.Data)
            .OfType<SourceContextResponse>()
            .ToArray();

        if (contexts.Length == 0)
        {
            return new QuestionContextResponse(
                Guid.Empty,
                request.Application,
                request.Version ?? string.Empty,
                request.Question,
                purpose,
                BuildAgentInstruction(purpose),
                string.Empty,
                DateTime.UtcNow,
                new QuestionContextSummary(0, 0, 0, 0, 0, 0),
                [],
                investigation.Warnings);
        }

        var build = contexts[0].Build;
        var symbols = contexts
            .SelectMany(context => context.Matches)
            .DistinctBy(symbol => symbol.SymbolId)
            .OrderBy(symbol => symbol.MatchKind)
            .ThenBy(symbol => symbol.QualifiedName)
            .ToArray();
        var references = contexts
            .SelectMany(context => context.References)
            .DistinctBy(ReferenceKey)
            .ToArray();
        var reads = references
            .Where(reference => string.Equals(reference.AccessKind, "READ", StringComparison.OrdinalIgnoreCase))
            .ToArray();
        var writes = references
            .Where(reference => string.Equals(reference.AccessKind, "WRITE", StringComparison.OrdinalIgnoreCase) ||
                                string.Equals(reference.AccessKind, "READ_WRITE", StringComparison.OrdinalIgnoreCase))
            .ToArray();
        var otherReferences = references
            .Except(reads)
            .Except(writes)
            .ToArray();
        var chains = contexts
            .SelectMany(context => context.Chains)
            .DistinctBy(ChainKey)
            .OrderByDescending(chain => chain.IsRoot)
            .ThenByDescending(chain => chain.Depth)
            .ThenBy(chain => chain.Path)
            .ToArray();
        var files = BuildFiles(contexts, symbols, references, chains, purpose);
        var warnings = investigation.Warnings
            .Concat(contexts.SelectMany(context => context.Warnings))
            .Distinct(StringComparer.Ordinal)
            .ToArray();

        return new QuestionContextResponse(
            build.BuildId,
            build.Application,
            build.Version,
            request.Question,
            purpose,
            BuildAgentInstruction(purpose),
            build.SourceSolution,
            build.GeneratedAtUtc,
            new QuestionContextSummary(
                symbols.Length,
                reads.Length,
                writes.Length,
                otherReferences.Length,
                chains.Length,
                files.Length),
            files,
            warnings);
    }

    private static string BuildAgentInstruction(string purpose)
        => "Responda a pergunta usando exclusivamente os arquivos e seus conteudos deste pacote. " +
           "Nao pesquise, leia nem utilize outros arquivos do repositorio. " +
           $"O proposito da consulta e {purpose}. " +
           "Respeite editable, ownership e sourceOfTruth: nunca proponha editar diretamente um GENERATED_REGENERABLE; " +
           "para ele, localize a DSL ou template indicado. Arquivos DSL_SEEDED_CUSTOM_OWNED_BY_DEV pertencem integralmente a IA/dev. " +
           "Cite os arquivos que sustentam cada conclusao. Se as fontes forem insuficientes, declare a evidencia faltante.";

    private static QuestionContextFile[] BuildFiles(
        IReadOnlyList<SourceContextResponse> contexts,
        IReadOnlyList<SymbolMatch> symbols,
        IReadOnlyList<ReferenceEvidence> references,
        IReadOnlyList<FunctionChain> chains,
        string purpose)
    {
        var candidates = contexts
            .SelectMany(context => context.SourceFiles)
            .GroupBy(candidate => candidate.File, StringComparer.OrdinalIgnoreCase);

        return candidates
            .Where(group => IncludeForPurpose(group.First(), purpose))
            .Select(group =>
            {
                var metadata = group.First();
                var reasons = group.Select(candidate => candidate.Reason)
                    .Distinct(StringComparer.Ordinal)
                    .OrderBy(reason => reason)
                    .ToArray();
                var lines = symbols
                    .Where(symbol => SameFile(symbol.File, group.Key) && symbol.StartLine.HasValue)
                    .Select(symbol => symbol.StartLine!.Value)
                    .Concat(references
                        .Where(reference => SameFile(reference.File, group.Key))
                        .Select(reference => reference.Line))
                    .Concat(chains
                        .Where(chain => SameFile(chain.ReferenceFile, group.Key) && chain.ReferenceLine.HasValue)
                        .Select(chain => chain.ReferenceLine!.Value))
                    .Distinct()
                    .OrderBy(line => line)
                    .ToArray();

                return new QuestionContextFile(
                    group.Key,
                    Score(reasons, metadata, purpose),
                    reasons,
                    lines,
                    metadata.ArtifactKind,
                    metadata.SourceRole,
                    metadata.Ownership,
                    metadata.Editable,
                    metadata.SourceOfTruth);
            })
            .OrderByDescending(file => file.Score)
            .ThenBy(file => file.File)
            .ToArray();
    }

    private static int Score(IReadOnlyList<string> reasons, SourceFileCandidate file, string purpose)
    {
        var score = 0;
        if (reasons.Any(reason => reason.EndsWith("REFERENCE", StringComparison.Ordinal))) score += 100;
        if (reasons.Any(reason => reason.EndsWith("INSTANTIATION", StringComparison.Ordinal))) score += 90;
        if (reasons.Any(reason => reason.EndsWith("DECLARATION", StringComparison.Ordinal))) score += 70;
        if (reasons.Any(reason => reason.Contains("CALL_CHAIN", StringComparison.Ordinal))) score += 40;
        if (reasons.Contains("CALLER_CHAIN", StringComparer.Ordinal)) score += 40;
        if (purpose == "CHANGE_IMPLEMENTATION" && file.ArtifactKind == "DSL_SPECIFICATION") score += 80;
        if (purpose == "CHANGE_IMPLEMENTATION" && file.Editable) score += 30;
        if (purpose == "BUSINESS_RULE" && file.SourceRole == "BUSINESS_RULE") score += 80;
        if (purpose == "BUSINESS_RULE" && file.SourceRole == "USE_CASE") score += 60;
        return score + reasons.Count;
    }

    private static bool IncludeForPurpose(SourceFileCandidate file, string purpose)
        => purpose switch
        {
            "BUSINESS_RULE" => file.SourceRole is not ("CONTRACT" or "BASE_CLASS" or "ARCHITECTURE_BORDER" or "TEST"),
            "ARCHITECTURE" => file.SourceRole is "CONTRACT" or "BASE_CLASS" or "ARCHITECTURE_BORDER" or "APPLICATION_SOURCE",
            "CHANGE_IMPLEMENTATION" => file.SourceRole != "TEST",
            _ => true
        };

    private static string NormalizePurpose(string? purpose)
        => purpose?.Trim().Replace('-', '_').Replace(' ', '_').ToUpperInvariant() switch
        {
            "BUSINESSRULE" or "BUSINESS_RULE" => "BUSINESS_RULE",
            "CHANGE" or "CHANGEIMPLEMENTATION" or "CHANGE_IMPLEMENTATION" => "CHANGE_IMPLEMENTATION",
            "BUG" or "BUGDIAGNOSIS" or "BUG_DIAGNOSIS" => "BUG_DIAGNOSIS",
            "ARCHITECTURE" => "ARCHITECTURE",
            _ => "FULL"
        };

    private static bool SameFile(string? left, string right)
        => left != null && string.Equals(left, right, StringComparison.OrdinalIgnoreCase);

    private static string ReferenceKey(ReferenceEvidence reference)
        => $"{reference.Kind}|{reference.Symbol}|{reference.AccessKind}|{reference.ContainingFunction}|" +
           $"{reference.File}|{reference.Line}|{reference.Column}";

    private static string ChainKey(FunctionChain chain)
        => $"{chain.Direction}|{chain.Path}|{chain.ReferenceFile}|{chain.ReferenceLine}";
}
