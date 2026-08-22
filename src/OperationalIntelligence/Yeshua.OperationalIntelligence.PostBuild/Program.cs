// <operational-spec>
// standard: OPERATIONAL_SUPPORT_ADOPTION_STANDARD
// gates: G2,G7
// depths: D0
// severities: notApplicable
// modes: Live
// dataClassification: SafeMetadata,OperationalData
// identities: Application,Environment,Version
// technicalOutcomes: Success,Failure
// businessOutcomes: notApplicable
// evidence: PostBuildHealthReport
// </operational-spec>

using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Yeshua.OperationalIntelligence.PostBuild;

return await RunAsync(args);

static async Task<int> RunAsync(string[] args)
{
    var options = ParseArguments(args);
    if (!options.TryGetValue("manifest", out var manifestArgument) || string.IsNullOrWhiteSpace(manifestArgument))
    {
        Console.Error.WriteLine("Uso: --manifest <arquivo> --commit <sha> [--output <diretorio>] [--skip-smoke]");
        return 2;
    }

    var expectedCommit = options.GetValueOrDefault("commit") ??
        Environment.GetEnvironmentVariable("YESHUA_COMMIT_SHA");
    if (string.IsNullOrWhiteSpace(expectedCommit))
    {
        Console.Error.WriteLine("Informe --commit ou a variavel YESHUA_COMMIT_SHA.");
        return 2;
    }

    var repositoryRoot = FindRepositoryRoot(Directory.GetCurrentDirectory());
    var manifestPath = ResolvePath(repositoryRoot, manifestArgument);
    var manifest = LoadManifest(manifestPath);
    var outputDirectory = ResolvePath(
        repositoryRoot,
        options.GetValueOrDefault("output") ?? Path.Combine("artifacts", "post-build", manifest.Application));
    Directory.CreateDirectory(outputDirectory);

    var report = new PostBuildHealthReport
    {
        Application = manifest.Application,
        Environment = manifest.Environment,
        ExpectedCommit = expectedCommit,
        StartedAtUtc = DateTimeOffset.UtcNow,
        Specification = OperationalSpecificationClassification.PostBuild
    };

    try
    {
        var baseUrl = LoadBaseUrl(repositoryRoot, manifest.BaseUrlSettingsFile);
        using var httpClient = new HttpClient
        {
            BaseAddress = baseUrl,
            Timeout = TimeSpan.FromSeconds(30)
        };

        var identity = await CheckIdentityAsync(httpClient, manifest.ApiIdentityPath, expectedCommit);
        report.Checks.Add(identity.BuildCheck);
        report.Checks.Add(identity.VersionCheck);
        report.ObservedCommit = identity.ObservedCommit;

        report.Checks.Add(await CheckHttpAsync(httpClient, "ApiLiveness", manifest.ApiLivenessPath, "Healthy", expectedCommit));
        report.Checks.Add(await CheckHttpAsync(httpClient, "ApiReadiness", manifest.ApiReadinessPath, "Ready", expectedCommit));
        report.Checks.Add(await CheckHttpAsync(httpClient, "WorkerLiveness", manifest.WorkerLivenessPath, "Healthy", expectedCommit));
        report.Checks.Add(await CheckHttpAsync(httpClient, "WorkerReadiness", manifest.WorkerReadinessPath, "Ready", expectedCommit));

        if (options.ContainsKey("skip-smoke"))
        {
            report.Checks.Add(new PostBuildCheckResult(
                "CrudSmoke",
                "Skipped",
                true,
                0,
                "Execucao desabilitada por --skip-smoke."));
            report.Checks.Add(new PostBuildCheckResult(
                "DependencyHealth",
                "Skipped",
                true,
                0,
                "Sem a suite CRUD, a cobertura atual de API, autenticacao e SQL nao foi comprovada."));
        }
        else
        {
            var smoke = await RunSmokeAsync(repositoryRoot, outputDirectory, manifest.SmokeProject, baseUrl);
            report.Checks.Add(smoke.Check);
            report.Checks.Add(new PostBuildCheckResult(
                "DependencyHealth",
                smoke.Check.Status,
                true,
                smoke.Check.DurationMs,
                "Cobertura atual da Clinica: API, autenticacao e SQL exercitados pela suite CRUD. Redis e RabbitMQ ainda nao possuem prova neste gate."));
        }
    }
    catch (Exception ex)
    {
        report.Checks.Add(new PostBuildCheckResult(
            "PostBuildRunner",
            "Failed",
            true,
            0,
            ex.Message));
    }

    report.FinishedAtUtc = DateTimeOffset.UtcNow;
    report.Approved = report.Checks.All(check => !check.Required || check.Status == "Passed");

    var reportPath = Path.Combine(
        outputDirectory,
        $"PostBuildHealthReport-{DateTimeOffset.UtcNow:yyyyMMdd-HHmmss}.json");
    await File.WriteAllTextAsync(
        reportPath,
        JsonSerializer.Serialize(report, PostBuildJsonContext.Default.PostBuildHealthReport),
        Encoding.UTF8);

    Console.WriteLine($"Aplicacao: {report.Application}");
    Console.WriteLine($"Commit esperado: {report.ExpectedCommit}");
    Console.WriteLine($"Resultado: {(report.Approved ? "APROVADO" : "REPROVADO")}");
    Console.WriteLine($"Relatorio: {reportPath}");

    return report.Approved ? 0 : 1;
}

static Dictionary<string, string?> ParseArguments(string[] args)
{
    var options = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
    for (var index = 0; index < args.Length; index++)
    {
        var argument = args[index];
        if (!argument.StartsWith("--", StringComparison.Ordinal))
            continue;

        var name = argument[2..];
        string? value = null;
        if (index + 1 < args.Length && !args[index + 1].StartsWith("--", StringComparison.Ordinal))
            value = args[++index];

        options[name] = value;
    }

    return options;
}

static string FindRepositoryRoot(string startDirectory)
{
    var directory = new DirectoryInfo(startDirectory);
    while (directory is not null)
    {
        if (File.Exists(Path.Combine(directory.FullName, "YeshuaCreator.sln")))
            return directory.FullName;

        directory = directory.Parent;
    }

    throw new DirectoryNotFoundException("YeshuaCreator.sln nao foi encontrada a partir do diretorio atual.");
}

static string ResolvePath(string repositoryRoot, string path)
{
    return Path.GetFullPath(Path.IsPathRooted(path) ? path : Path.Combine(repositoryRoot, path));
}

static PostBuildManifest LoadManifest(string manifestPath)
{
    if (!File.Exists(manifestPath))
        throw new FileNotFoundException("Manifesto pos-build nao encontrado.", manifestPath);

    return JsonSerializer.Deserialize(
            File.ReadAllText(manifestPath, Encoding.UTF8),
            PostBuildJsonContext.Default.PostBuildManifest) ??
        throw new InvalidDataException("Manifesto pos-build invalido.");
}

static Uri LoadBaseUrl(string repositoryRoot, string settingsPath)
{
    var path = ResolvePath(repositoryRoot, settingsPath);
    using var document = JsonDocument.Parse(File.ReadAllText(path, Encoding.UTF8));
    var baseUrl = document.RootElement
        .GetProperty("TestSettings")
        .GetProperty("BaseUrl")
        .GetString();

    var environmentBaseUrl = Environment.GetEnvironmentVariable("TESTSETTINGS__BASEURL");
    if (!string.IsNullOrWhiteSpace(environmentBaseUrl))
        baseUrl = environmentBaseUrl;

    return Uri.TryCreate(baseUrl, UriKind.Absolute, out var uri)
        ? uri
        : throw new InvalidDataException("TestSettings:BaseUrl deve conter uma URL absoluta.");
}

static async Task<(
    PostBuildCheckResult BuildCheck,
    PostBuildCheckResult VersionCheck,
    string? ObservedCommit)> CheckIdentityAsync(
    HttpClient client,
    string path,
    string expectedCommit)
{
    var stopwatch = Stopwatch.StartNew();
    try
    {
        using var response = await client.GetAsync(path);
        var body = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();

        using var document = JsonDocument.Parse(body);
        var root = document.RootElement;
        var application = GetString(root, "application");
        var version = GetString(root, "version");
        var observedCommit = GetString(root, "commitSha");
        var buildPassed = !string.IsNullOrWhiteSpace(application) &&
            !string.IsNullOrWhiteSpace(version) &&
            !string.IsNullOrWhiteSpace(observedCommit);
        var versionPassed = string.Equals(observedCommit, expectedCommit, StringComparison.OrdinalIgnoreCase);

        return (
            new PostBuildCheckResult(
                "BuildIntegrity",
                buildPassed ? "Passed" : "Failed",
                true,
                stopwatch.ElapsedMilliseconds,
                $"application={application}; version={version}; commit={observedCommit}"),
            new PostBuildCheckResult(
                "VersionIntegrity",
                versionPassed ? "Passed" : "Failed",
                true,
                stopwatch.ElapsedMilliseconds,
                $"expected={expectedCommit}; observed={observedCommit}"),
            observedCommit);
    }
    catch (Exception ex)
    {
        return (
            new PostBuildCheckResult(
                "BuildIntegrity",
                "Failed",
                true,
                stopwatch.ElapsedMilliseconds,
                ex.Message),
            new PostBuildCheckResult(
                "VersionIntegrity",
                "Failed",
                true,
                stopwatch.ElapsedMilliseconds,
                "A identidade do build nao pode ser lida."),
            null);
    }
}

static async Task<PostBuildCheckResult> CheckHttpAsync(
    HttpClient client,
    string name,
    string path,
    string expectedStatus,
    string expectedCommit)
{
    var stopwatch = Stopwatch.StartNew();
    try
    {
        using var response = await client.GetAsync(path);
        var body = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();

        using var document = JsonDocument.Parse(body);
        var status = GetString(document.RootElement, "status");
        var observedCommit = FindString(document.RootElement, "commitSha");
        var passed = string.Equals(status, expectedStatus, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(observedCommit, expectedCommit, StringComparison.OrdinalIgnoreCase);
        return new PostBuildCheckResult(
            name,
            passed ? "Passed" : "Failed",
            true,
            stopwatch.ElapsedMilliseconds,
            $"HTTP {(int)response.StatusCode}; status={status}; commit={observedCommit}");
    }
    catch (Exception ex)
    {
        return new PostBuildCheckResult(
            name,
            "Failed",
            true,
            stopwatch.ElapsedMilliseconds,
            ex.Message);
    }
}

static string? GetString(JsonElement element, string propertyName)
{
    foreach (var property in element.EnumerateObject())
    {
        if (string.Equals(property.Name, propertyName, StringComparison.OrdinalIgnoreCase))
            return property.Value.ValueKind == JsonValueKind.String ? property.Value.GetString() : property.Value.ToString();
    }

    return null;
}

static string? FindString(JsonElement element, string propertyName)
{
    if (element.ValueKind == JsonValueKind.Object)
    {
        foreach (var property in element.EnumerateObject())
        {
            if (string.Equals(property.Name, propertyName, StringComparison.OrdinalIgnoreCase))
                return property.Value.ValueKind == JsonValueKind.String
                    ? property.Value.GetString()
                    : property.Value.ToString();

            var nested = FindString(property.Value, propertyName);
            if (nested is not null)
                return nested;
        }
    }
    else if (element.ValueKind == JsonValueKind.Array)
    {
        foreach (var item in element.EnumerateArray())
        {
            var nested = FindString(item, propertyName);
            if (nested is not null)
                return nested;
        }
    }

    return null;
}

static async Task<SmokeExecutionResult> RunSmokeAsync(
    string repositoryRoot,
    string outputDirectory,
    string smokeProject,
    Uri baseUrl)
{
    var projectPath = ResolvePath(repositoryRoot, smokeProject);
    var logPath = Path.Combine(outputDirectory, "CrudSmoke.log");
    var stopwatch = Stopwatch.StartNew();
    var startInfo = new ProcessStartInfo("dotnet")
    {
        WorkingDirectory = repositoryRoot,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false
    };
    startInfo.ArgumentList.Add("test");
    startInfo.ArgumentList.Add(projectPath);
    startInfo.ArgumentList.Add("--configuration");
    startInfo.ArgumentList.Add("Release");
    startInfo.Environment["TESTSETTINGS__BASEURL"] = baseUrl.ToString();

    using var process = Process.Start(startInfo) ??
        throw new InvalidOperationException("Nao foi possivel iniciar dotnet test.");
    var standardOutput = process.StandardOutput.ReadToEndAsync();
    var standardError = process.StandardError.ReadToEndAsync();
    await process.WaitForExitAsync();

    var output = await standardOutput;
    var error = await standardError;
    await File.WriteAllTextAsync(logPath, output + Environment.NewLine + error, Encoding.UTF8);

    return new SmokeExecutionResult
    {
        LogPath = logPath,
        Check = new PostBuildCheckResult(
            "CrudSmoke",
            process.ExitCode == 0 ? "Passed" : "Failed",
            true,
            stopwatch.ElapsedMilliseconds,
            $"exitCode={process.ExitCode}; log={logPath}")
    };
}
