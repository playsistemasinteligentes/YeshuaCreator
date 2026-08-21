using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.RegularExpressions;

internal static partial class TextReferenceIndexer
{
    private static readonly HashSet<string> SupportedExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".cs", ".js", ".mjs", ".cjs", ".ts", ".tsx", ".jsx",
        ".html", ".htm", ".cshtml", ".razor", ".vue", ".sql"
    };

    private static readonly HashSet<string> ExcludedDirectories = new(StringComparer.OrdinalIgnoreCase)
    {
        "bin", "obj", ".git", ".vs", "node_modules", "dist", "build", "coverage"
    };

    public static bool IsSupportedFile(string path)
        => SupportedExtensions.Contains(Path.GetExtension(path)) &&
           !Path.GetFileName(path).Contains(".min.", StringComparison.OrdinalIgnoreCase) &&
           !HasExcludedDirectory(path);

    public static IEnumerable<string> EnumerateSupportedFiles(string root)
    {
        var pending = new Stack<string>();
        pending.Push(root);
        while (pending.TryPop(out var directory))
        {
            IEnumerable<string> directories;
            IEnumerable<string> files;
            try
            {
                directories = Directory.EnumerateDirectories(directory).ToArray();
                files = Directory.EnumerateFiles(directory).ToArray();
            }
            catch (UnauthorizedAccessException)
            {
                continue;
            }

            foreach (var child in directories)
            {
                if (!ExcludedDirectories.Contains(Path.GetFileName(child)))
                    pending.Push(child);
            }
            foreach (var file in files.Where(IsSupportedFile))
                yield return file;
        }
    }

    public static IEnumerable<TextReferenceCandidate> Extract(string path, string content)
        => string.Equals(Path.GetExtension(path), ".cs", StringComparison.OrdinalIgnoreCase)
            ? ExtractCSharpStrings(content)
            : ExtractTextTokens(path, content);

    private static IEnumerable<TextReferenceCandidate> ExtractCSharpStrings(string content)
    {
        var tree = CSharpSyntaxTree.ParseText(content);
        var root = tree.GetRoot();
        foreach (var literal in root.DescendantNodes().OfType<LiteralExpressionSyntax>())
        {
            if (literal.RawKind != (int)SyntaxKind.StringLiteralExpression)
                continue;

            foreach (var candidate in ExtractTokens(
                         literal.Token.ValueText,
                         tree.GetLineSpan(literal.Span).StartLinePosition.Line + 1,
                         tree.GetLineSpan(literal.Span).StartLinePosition.Character + 1,
                         GetLine(content, tree.GetLineSpan(literal.Span).StartLinePosition.Line),
                         "CSHARP_STRING"))
                yield return candidate;
        }

        foreach (var text in root.DescendantNodes().OfType<InterpolatedStringTextSyntax>())
        {
            var position = tree.GetLineSpan(text.Span).StartLinePosition;
            foreach (var candidate in ExtractTokens(
                         text.TextToken.ValueText,
                         position.Line + 1,
                         position.Character + 1,
                         GetLine(content, position.Line),
                         "CSHARP_INTERPOLATED_TEXT"))
                yield return candidate;
        }
    }

    private static IEnumerable<TextReferenceCandidate> ExtractTextTokens(string path, string content)
    {
        var kind = Path.GetExtension(path).ToLowerInvariant() switch
        {
            ".js" or ".mjs" or ".cjs" or ".jsx" => "JAVASCRIPT_TOKEN",
            ".ts" or ".tsx" => "TYPESCRIPT_TOKEN",
            ".html" or ".htm" or ".cshtml" or ".razor" or ".vue" => "MARKUP_TOKEN",
            ".sql" => "SQL_TOKEN",
            _ => "TEXT_TOKEN"
        };

        var lines = content.Split('\n');
        for (var index = 0; index < lines.Length; index++)
        {
            var line = lines[index].TrimEnd('\r');
            foreach (Match match in IdentifierRegex().Matches(line))
            {
                if (match.Length is < 2 or > 200)
                    continue;
                yield return new TextReferenceCandidate(
                    match.Value,
                    kind,
                    index + 1,
                    match.Index + 1,
                    TrimSnippet(line));
            }
        }
    }

    private static IEnumerable<TextReferenceCandidate> ExtractTokens(
        string value,
        int line,
        int baseColumn,
        string context,
        string kind)
    {
        foreach (Match match in IdentifierRegex().Matches(value))
        {
            if (match.Length is < 2 or > 200)
                continue;
            yield return new TextReferenceCandidate(
                match.Value,
                kind,
                line,
                baseColumn + match.Index,
                TrimSnippet(context));
        }
    }

    private static bool HasExcludedDirectory(string path)
        => path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
            .Any(part => ExcludedDirectories.Contains(part));

    private static string GetLine(string content, int zeroBasedLine)
    {
        var lines = content.Split('\n');
        return zeroBasedLine >= 0 && zeroBasedLine < lines.Length
            ? lines[zeroBasedLine].TrimEnd('\r')
            : string.Empty;
    }

    private static string TrimSnippet(string value)
    {
        var trimmed = value.Trim();
        return trimmed.Length <= 500 ? trimmed : trimmed[..500];
    }

    [GeneratedRegex("[A-Za-z_$][A-Za-z0-9_$-]*", RegexOptions.CultureInvariant)]
    private static partial Regex IdentifierRegex();
}

internal sealed record TextReferenceCandidate(
    string Token,
    string ReferenceKind,
    int Line,
    int Column,
    string ContextSnippet);
