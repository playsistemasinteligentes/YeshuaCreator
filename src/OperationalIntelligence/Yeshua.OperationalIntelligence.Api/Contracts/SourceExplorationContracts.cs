using System.Text.Json.Serialization;
using System.Text.Json;

namespace Yeshua.OperationalIntelligence.Api.Contracts;

[JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
public sealed record SourceExplorationRequest
{
    // Setters preserve omitted-property defaults in .NET 8's source-generated JSON reader.
    public string Kind { get; set; } = "applications";
    public string? Application { get; set; }
    public string? Version { get; set; }
    public Guid? BuildId { get; set; }
    public string? Query { get; set; }
    public string? File { get; set; }
    public int? Line { get; set; }
    public int? EndLine { get; set; }
    public int MaxDepth { get; set; }
    public string Direction { get; set; } = "both";
    public int MaxResults { get; set; } = 10;
    public int Offset { get; set; }
    public bool IncludeContent { get; set; }
    public int MaxFiles { get; set; } = 3;
    public int MaxLines { get; set; } = 100;
    public int MaxContentChars { get; set; } = 12000;
}

public sealed record SourceSnippet(string File, int StartLine, int EndLine, int TotalLines,
    string Content, bool Complete);

public sealed record SourceSearchNext(string Reason, SourceExplorationRequest Arguments);

// Same evidence envelope for HTTP GET/POST and MCP. Existing symbol result fields remain at the root.
public sealed record SourceExplorationResponse(string Kind, BuildSummary? Build,
    IReadOnlyList<ApplicationSummary> Applications, IReadOnlyList<BuildSummary> Builds,
    IReadOnlyList<SymbolMatch> Matches, IReadOnlyList<ReferenceEvidence> References,
    IReadOnlyList<FunctionChain> Chains, IReadOnlyList<SourceFileCandidate> SourceFiles,
    IReadOnlyList<SourceSnippet> Snippets, IReadOnlyList<SourceSearchNext> Next,
    IReadOnlyList<string> Warnings);

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(SourceExplorationRequest))]
[JsonSerializable(typeof(SourceExplorationResponse))]
internal partial class SourceExplorationJson : JsonSerializerContext;
