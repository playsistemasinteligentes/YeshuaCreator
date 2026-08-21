internal sealed record SourceArtifactClassification(
    string ArtifactKind,
    string SourceRole,
    string Ownership,
    bool Editable,
    string SourceOfTruth);

internal static class SourceArtifactClassifier
{
    public static SourceArtifactClassification Classify(
        string path,
        string content,
        string systemType)
    {
        var normalized = path.Replace('\\', '/');
        var marker = ParseMarker(content);
        if (marker.Count > 0)
        {
            var artifact = Get(marker, "artifact", "APPLICATION_SOURCE");
            return new SourceArtifactClassification(
                artifact,
                Get(marker, "role", InferRole(normalized, content, artifact)),
                Get(marker, "ownership", "IA_DEV"),
                bool.TryParse(Get(marker, "editable", "true"), out var editable) && editable,
                Get(marker, "sourceOfTruth", "THIS_FILE"));
        }

        if (!string.Equals(systemType, "Yeshua", StringComparison.OrdinalIgnoreCase))
        {
            return new SourceArtifactClassification(
                "LEGACY_SOURCE",
                InferRole(normalized, content, "LEGACY_SOURCE"),
                "IA_DEV",
                true,
                "THIS_FILE");
        }

        if (normalized.Contains("/Migrations/", StringComparison.OrdinalIgnoreCase) &&
            content.Contains("MigrationBase", StringComparison.Ordinal))
        {
            return new SourceArtifactClassification(
                "DSL_SPECIFICATION",
                "DSL_SPECIFICATION",
                "IA_DEV",
                true,
                "THIS_FILE");
        }

        if (normalized.Contains("/Custon/", StringComparison.OrdinalIgnoreCase))
        {
            return new SourceArtifactClassification(
                "DSL_SEEDED_CUSTOM_OWNED_BY_DEV",
                InferRole(normalized, content, "DSL_SEEDED_CUSTOM_OWNED_BY_DEV"),
                "IA_DEV",
                true,
                "THIS_FILE");
        }

        if (normalized.Contains("/Migration/", StringComparison.OrdinalIgnoreCase) ||
            content.Contains("//Dominio.Schemas.CQRS.SourceCode", StringComparison.Ordinal))
        {
            return new SourceArtifactClassification(
                "GENERATED_REGENERABLE",
                InferRole(normalized, content, "GENERATED_REGENERABLE"),
                "ENGINE",
                false,
                "DSL_OR_ENGINE_TEMPLATE");
        }

        return new SourceArtifactClassification(
            "YESHUA_STATIC_SOURCE",
            InferRole(normalized, content, "YESHUA_STATIC_SOURCE"),
            "IA_DEV",
            true,
            "THIS_FILE");
    }

    private static string InferRole(string path, string content, string artifact)
    {
        if (artifact == "DSL_SPECIFICATION") return "DSL_SPECIFICATION";
        if (Path.GetExtension(path).ToLowerInvariant() is ".js" or ".mjs" or ".cjs" or ".ts" or ".tsx" or ".jsx" or
            ".html" or ".htm" or ".cshtml" or ".razor" or ".vue") return "FRONTEND_SOURCE";
        if (path.Contains("/Tests/", StringComparison.OrdinalIgnoreCase) ||
            path.Contains("/tests/", StringComparison.OrdinalIgnoreCase)) return "TEST";
        if (Path.GetFileName(path).StartsWith('I') && content.Contains("interface ", StringComparison.Ordinal)) return "CONTRACT";
        if (content.Contains(" abstract class ", StringComparison.Ordinal) ||
            Path.GetFileNameWithoutExtension(path).EndsWith("Base", StringComparison.OrdinalIgnoreCase)) return "BASE_CLASS";
        if (path.Contains("/RepositoryRead/", StringComparison.OrdinalIgnoreCase) ||
            path.Contains("/RepositoryWrite/", StringComparison.OrdinalIgnoreCase) ||
            path.Contains("/ConcreteQuery", StringComparison.OrdinalIgnoreCase)) return "DATA_BEHAVIOR";
        if (path.Contains("/Receivers/", StringComparison.OrdinalIgnoreCase) ||
            path.Contains("/UseCases/", StringComparison.OrdinalIgnoreCase)) return "USE_CASE";
        if (path.Contains("/Domain/", StringComparison.OrdinalIgnoreCase) ||
            path.Contains("/Entitys/", StringComparison.OrdinalIgnoreCase)) return "BUSINESS_RULE";
        if (path.Contains("/Api/", StringComparison.OrdinalIgnoreCase) ||
            path.Contains(".Infrastructure.Api/", StringComparison.OrdinalIgnoreCase) ||
            path.Contains("/Worker/", StringComparison.OrdinalIgnoreCase) ||
            path.Contains(".Infrastructure.Worker/", StringComparison.OrdinalIgnoreCase) ||
            path.EndsWith("Program.cs", StringComparison.OrdinalIgnoreCase) ||
            path.Contains("EndPoints", StringComparison.OrdinalIgnoreCase) ||
            path.Contains("DependencyInjection", StringComparison.OrdinalIgnoreCase) ||
            path.Contains("DependencInjection", StringComparison.OrdinalIgnoreCase)) return "ARCHITECTURE_BORDER";
        if (path.Contains("Integration", StringComparison.OrdinalIgnoreCase)) return "INTEGRATION";
        return "APPLICATION_SOURCE";
    }

    private static Dictionary<string, string> ParseMarker(string content)
    {
        var start = content.IndexOf("// <yeshua>", StringComparison.OrdinalIgnoreCase);
        var end = content.IndexOf("// </yeshua>", StringComparison.OrdinalIgnoreCase);
        if (start < 0 || end <= start)
            return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        return content[start..end]
            .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Trim().TrimStart('/').Trim())
            .Select(line => line.Split(':', 2, StringSplitOptions.TrimEntries))
            .Where(parts => parts.Length == 2)
            .ToDictionary(parts => parts[0], parts => parts[1], StringComparer.OrdinalIgnoreCase);
    }

    private static string Get(IReadOnlyDictionary<string, string> marker, string key, string fallback)
        => marker.TryGetValue(key, out var value) && !string.IsNullOrWhiteSpace(value) ? value : fallback;
}
