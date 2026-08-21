using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

internal sealed class ReverseEngineeringManifest
{
    public string System { get; init; } = string.Empty;
    public string SystemType { get; init; } = string.Empty;
    public string Version { get; init; } = string.Empty;
    public string? CommitSha { get; init; }
    public string Solution { get; set; } = string.Empty;
    public List<ReverseEngineeringProject> Projects { get; init; } = [];
    public List<ReverseEngineeringRepository> Repositories { get; init; } = [];

    public string ManifestHashSha256 { get; private set; } = string.Empty;

    public static async Task<ReverseEngineeringManifest> LoadAsync(
        string manifestPath,
        CancellationToken cancellationToken = default)
    {
        var fullManifestPath = Path.GetFullPath(manifestPath);
        var json = await File.ReadAllTextAsync(fullManifestPath, cancellationToken);
        var manifest = JsonSerializer.Deserialize<ReverseEngineeringManifest>(json, JsonOptions)
            ?? throw new InvalidOperationException("O manifesto de engenharia reversa esta vazio.");
        manifest.NormalizeAndValidate(Path.GetDirectoryName(fullManifestPath)!);
        manifest.ManifestHashSha256 = Convert.ToHexString(
            SHA256.HashData(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(manifest, JsonOptions))));
        return manifest;
    }

    private void NormalizeAndValidate(string manifestDirectory)
    {
        if (string.IsNullOrWhiteSpace(System))
            throw new InvalidOperationException("O manifesto deve informar 'system'.");
        if (!string.Equals(SystemType, "Yeshua", StringComparison.OrdinalIgnoreCase) &&
            !string.Equals(SystemType, "Legacy", StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("'systemType' deve ser 'Yeshua' ou 'Legacy'.");
        if (string.IsNullOrWhiteSpace(Version))
            throw new InvalidOperationException("O manifesto deve informar 'version'.");
        if (string.IsNullOrWhiteSpace(Solution))
            throw new InvalidOperationException("O manifesto deve informar 'solution'.");
        if (Projects.Count == 0)
            throw new InvalidOperationException("O manifesto deve informar pelo menos um projeto.");

        Solution = ResolvePath(manifestDirectory, Solution);
        if (!File.Exists(Solution))
            throw new FileNotFoundException("A solucao informada nao foi encontrada.", Solution);

        foreach (var project in Projects)
        {
            project.ProjectFile = ResolvePath(manifestDirectory, project.ProjectFile);
            project.SourceDirectory = ResolvePath(manifestDirectory, project.SourceDirectory);
            if (!File.Exists(project.ProjectFile))
                throw new FileNotFoundException("O projeto informado nao foi encontrado.", project.ProjectFile);
            if (!Directory.Exists(project.SourceDirectory))
                throw new DirectoryNotFoundException(
                    $"O diretorio de fontes nao foi encontrado: {project.SourceDirectory}");
            if (!project.ProjectFile.StartsWith(
                    project.SourceDirectory + Path.DirectorySeparatorChar,
                    StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(
                    Path.GetDirectoryName(project.ProjectFile),
                    project.SourceDirectory,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"O projeto '{project.ProjectFile}' nao pertence ao diretorio '{project.SourceDirectory}'.");
            }
        }

        foreach (var repository in Repositories)
        {
            repository.Root = ResolvePath(manifestDirectory, repository.Root);
            if (!Directory.Exists(Path.Combine(repository.Root, ".git")))
                throw new InvalidOperationException(
                    $"O repositorio Git nao foi encontrado em '{repository.Root}'.");
        }
    }

    private static string ResolvePath(string root, string path)
        => Path.GetFullPath(Path.IsPathRooted(path) ? path : Path.Combine(root, path));

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };
}

internal sealed class ReverseEngineeringProject
{
    public string Name { get; init; } = string.Empty;
    public string ProjectFile { get; set; } = string.Empty;
    public string SourceDirectory { get; set; } = string.Empty;
}

internal sealed class ReverseEngineeringRepository
{
    public string Root { get; set; } = string.Empty;
}
