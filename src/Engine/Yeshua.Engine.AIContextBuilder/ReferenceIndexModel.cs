using System.Security.Cryptography;
using System.Text;

internal sealed class ReferenceIndexModel
{
    public required Guid ApplicationId { get; init; }
    public required Guid BuildId { get; init; }
    public required string ApplicationName { get; init; }
    public required string Version { get; init; }
    public string? CommitSha { get; init; }
    public required string SourceSolution { get; init; }
    public DateTimeOffset GeneratedAtUtc { get; init; } = DateTimeOffset.UtcNow;

    public Dictionary<Guid, ReferenceProjectRow> Projects { get; } = new();
    public Dictionary<Guid, ReferenceFileRow> Files { get; } = new();
    public Dictionary<Guid, ReferenceSymbolRow> Symbols { get; } = new();
    public Dictionary<Guid, ReferenceDeclarationRow> Declarations { get; } = new();
    public Dictionary<Guid, FieldReferenceRow> FieldReferences { get; } = new();
    public Dictionary<Guid, ClassInstantiationRow> ClassInstantiations { get; } = new();
    public Dictionary<Guid, FunctionCallRow> FunctionCalls { get; } = new();

    public Guid CreateId(string category, string identity)
        => StableGuid.Create($"{BuildId:N}|{category}|{identity}");
}

internal static class StableGuid
{
    public static Guid Create(string value)
    {
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(value));
        var bytes = hash[..16];

        // Mark the value as a name-based UUID while retaining deterministic bytes.
        bytes[6] = (byte)((bytes[6] & 0x0F) | 0x50);
        bytes[8] = (byte)((bytes[8] & 0x3F) | 0x80);
        return new Guid(bytes);
    }
}

internal sealed record ReferenceProjectRow(
    Guid ProjectId,
    Guid BuildId,
    string Name,
    string? AssemblyName,
    string? ProjectPath,
    bool IsSeedProject);

internal sealed record ReferenceFileRow(
    Guid FileId,
    Guid BuildId,
    Guid ProjectId,
    string RelativePath,
    string HashSha256);

internal sealed record ReferenceSymbolRow(
    Guid SymbolId,
    Guid BuildId,
    Guid ProjectId,
    Guid? ContainingSymbolId,
    string Kind,
    string Name,
    string QualifiedName,
    string SymbolKey);

internal sealed record ReferenceDeclarationRow(
    Guid DeclarationId,
    Guid BuildId,
    Guid SymbolId,
    Guid FileId,
    int StartLine,
    int StartColumn,
    int EndLine,
    int EndColumn);

internal sealed record FieldReferenceRow(
    Guid FieldReferenceId,
    Guid BuildId,
    Guid FieldSymbolId,
    Guid? ContainingFunctionId,
    Guid FileId,
    string AccessKind,
    int Line,
    int Column,
    string ResolutionKind);

internal sealed record ClassInstantiationRow(
    Guid InstantiationId,
    Guid BuildId,
    Guid ClassSymbolId,
    Guid? ConstructorSymbolId,
    Guid? ContainingFunctionId,
    Guid FileId,
    int Line,
    int Column,
    string ResolutionKind);

internal sealed record FunctionCallRow(
    Guid FunctionCallId,
    Guid BuildId,
    Guid CallerFunctionId,
    Guid CalledFunctionId,
    Guid? FileId,
    int? Line,
    int? Column,
    string ResolutionKind);
