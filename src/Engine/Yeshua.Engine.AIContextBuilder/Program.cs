using Microsoft.Build.Locator;
using System.Diagnostics;

var instances = MSBuildLocator.QueryVisualStudioInstances().ToArray();
if (instances.Length > 0)
    MSBuildLocator.RegisterInstance(instances[0]);
else
    MSBuildLocator.RegisterDefaults();

var solutionPath = @"C:\Users\AngeloRicardoFontana\source\repos\YeshuaCreator\YeshuaCreator.sln";
var outputPath = @"C:\temp\source";
var builder = new AiContextBuilder();
var sw = Stopwatch.StartNew();

if (args.Length == 0)
{
    args = SelectCommandInteractively();
    if (args.Length == 0)
        return;
}

if (args.Contains("--reverse-engineering", StringComparer.OrdinalIgnoreCase))
{
    var manifestPath = GetArg(args, "--manifest")
        ?? SelectManifestInteractively(GetArg(args, "--manifests-dir"));
    var connectionString = GetArg(args, "--connection")
        ?? Environment.GetEnvironmentVariable("ConnectionStrings__OperationalIntelligence")
        ?? "Server=69.164.247.138,1433;Database=Context_CLINICA;User Id=sa;Password=123qwe!@#QWE;TrustServerCertificate=True;";

    var manifest = await ReverseEngineeringManifest.LoadAsync(manifestPath);
    Console.WriteLine($"Engenharia reversa: {manifest.System} ({manifest.SystemType})");
    Console.WriteLine($"Versao: {manifest.Version}");
    Console.WriteLine($"Projetos selecionados: {manifest.Projects.Count}");

    var exporter = new ReferenceSqlExporter();
    var model = await exporter.CollectAsync(manifest);
    Console.WriteLine($"Arquivos coletados: {model.Files.Count}");
    Console.WriteLine($"Simbolos coletados: {model.Symbols.Count}");
    Console.WriteLine($"Referencias de campo coletadas: {model.FieldReferences.Count}");
    Console.WriteLine($"Referencias textuais coletadas: {model.TextReferences.Count}");
    await new ReferenceSqlPublisher().PublishAsync(model, connectionString);
    var importedCommits = await new GitHistoryImporter().ImportAsync(manifest, connectionString);

    sw.Stop();
    Console.WriteLine($"Build publicado: {model.BuildId}");
    Console.WriteLine($"Arquivos publicados: {model.Files.Count}");
    Console.WriteLine($"Conteudos unicos publicados: {model.SourceContents.Count}");
    Console.WriteLine($"Novos commits Git importados: {importedCommits}");
    Console.WriteLine($"Engenharia reversa finalizada em {sw.ElapsedMilliseconds} ms.");
    return;
}

if (args.Contains("--reference-sql", StringComparer.OrdinalIgnoreCase))
{
    var referenceSolutionPath = GetArg(args, "--solution") ?? solutionPath;
    var referenceOutputPath = GetArg(args, "--output") ?? @"C:\temp\reference-index";
    var referenceProjectFilter = GetArg(args, "--project");
    var applicationName = GetArg(args, "--application") ?? referenceProjectFilter ?? "source-application";
    var version = GetArg(args, "--version") ?? "working-tree";
    var commitSha = GetArg(args, "--commit");

    Console.WriteLine($"Gerando indice SQL de referencias: {referenceSolutionPath}");
    Console.WriteLine($"Aplicacao: {applicationName}");
    Console.WriteLine($"Versao: {version}");
    Console.WriteLine($"Projetos de entrada: {referenceProjectFilter ?? "todos"}");
    Console.WriteLine($"Saida: {referenceOutputPath}");

    await builder.GenerateReferenceSql(
        referenceSolutionPath,
        referenceOutputPath,
        applicationName,
        version,
        commitSha,
        referenceProjectFilter);

    sw.Stop();
    Console.WriteLine($"Indice SQL finalizado em {sw.ElapsedMilliseconds} ms.");
    return;
}

var sourceDirectory = GetArg(args, "--source-dir");
if (!string.IsNullOrWhiteSpace(sourceDirectory))
{
    var sourceOutputPath = GetArg(args, "--output") ?? @"C:\temp\operational-inventory";
    var sourceProjectName = GetArg(args, "--project") ?? "legacy-source";

    Console.WriteLine($"Gerando inventario sintatico de: {sourceDirectory}");
    Console.WriteLine($"Saida: {sourceOutputPath}");
    await builder.GenerateSourceInventory(sourceDirectory, sourceOutputPath, sourceProjectName);
    sw.Stop();
    Console.WriteLine($"Inventario sintatico finalizado em {sw.ElapsedMilliseconds} ms.");
    return;
}

if (args.Contains("--inventory", StringComparer.OrdinalIgnoreCase))
{
    var inventorySolutionPath = GetArg(args, "--solution") ?? solutionPath;
    var inventoryOutputPath = GetArg(args, "--output") ?? @"C:\temp\operational-inventory";
    var inventoryProjectFilter = GetArg(args, "--project");

    Console.WriteLine($"Gerando inventario tecnico de: {inventorySolutionPath}");
    Console.WriteLine($"Saida: {inventoryOutputPath}");
    Console.WriteLine($"Projeto: {inventoryProjectFilter ?? "todos"}");
    await builder.GenerateInventory(
        inventorySolutionPath,
        inventoryOutputPath,
        inventoryProjectFilter);
    sw.Stop();
    Console.WriteLine($"Inventario finalizado em {sw.ElapsedMilliseconds} ms.");
    return;
}

Console.WriteLine("Digite os nomes separados por vírgula (ou ENTER para gerar todos):");
var input = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(input))
{
    var names = input.Split(',', StringSplitOptions.RemoveEmptyEntries);

    if (names.Length == 1)
    {
        Console.WriteLine($"Gerando contexto para: {names[0].Trim()}");
        await builder.GenerateForReceiver(solutionPath, names[0].Trim(), outputPath);
    }
    else
    {
        Console.WriteLine($"Gerando contexto para {names.Length} classes...");
        //await builder.GenerateForReceivers(solutionPath, names, outputPath);
    }
}
else
{
    Console.WriteLine("Gerando contexto para TODOS...");
    await builder.GenerateForAllReceivers(solutionPath, outputPath);
}

sw.Stop();
Console.WriteLine($"Tempo: {sw.ElapsedMilliseconds} ms");
Console.WriteLine("Finalizado.");

static string? GetArg(string[] args, string name)
{
    for (var index = 0; index < args.Length - 1; index++)
    {
        if (string.Equals(args[index], name, StringComparison.OrdinalIgnoreCase))
            return args[index + 1];
    }

    return null;
}

static string[] SelectCommandInteractively()
{
    Console.WriteLine();
    Console.WriteLine("Yeshua Engine AI Context Builder");
    Console.WriteLine("1. Executar engenharia reversa");
    Console.WriteLine("2. Gerar inventario tecnico da solucao");
    Console.WriteLine("3. Gerar indice SQL de referencias");
    Console.WriteLine("4. Gerar inventario sintatico de um diretorio");
    Console.WriteLine("5. Gerar contexto de receivers");
    Console.WriteLine("0. Sair");

    while (true)
    {
        Console.Write("Escolha uma opcao: ");
        switch (Console.ReadLine()?.Trim())
        {
            case "1":
                return ["--reverse-engineering"];
            case "2":
                return ["--inventory"];
            case "3":
                return ["--reference-sql"];
            case "4":
                Console.Write("Diretorio de fontes: ");
                var sourceDirectory = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(sourceDirectory))
                {
                    Console.WriteLine("O diretorio de fontes e obrigatorio.");
                    continue;
                }
                return ["--source-dir", sourceDirectory];
            case "5":
                return ["--receiver-context"];
            case "0":
                return [];
            default:
                Console.WriteLine("Opcao invalida.");
                break;
        }
    }
}

static string SelectManifestInteractively(string? configuredDirectory)
{
    var manifestDirectory = FindManifestDirectory(configuredDirectory);
    var manifests = Directory
        .EnumerateFiles(manifestDirectory, "*.json", SearchOption.TopDirectoryOnly)
        .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
        .ToArray();

    if (manifests.Length == 0)
        throw new InvalidOperationException($"Nenhum manifesto foi encontrado em '{manifestDirectory}'.");

    Console.WriteLine();
    Console.WriteLine("Manifestos disponiveis:");
    for (var index = 0; index < manifests.Length; index++)
        Console.WriteLine($"{index + 1}. {DescribeManifest(manifests[index])}");

    while (true)
    {
        Console.Write("Escolha o manifesto: ");
        if (int.TryParse(Console.ReadLine(), out var selected) &&
            selected >= 1 &&
            selected <= manifests.Length)
        {
            return manifests[selected - 1];
        }

        Console.WriteLine($"Informe um numero entre 1 e {manifests.Length}.");
    }
}

static string FindManifestDirectory(string? configuredDirectory)
{
    if (!string.IsNullOrWhiteSpace(configuredDirectory))
    {
        var configuredFullPath = Path.GetFullPath(configuredDirectory);
        if (!Directory.Exists(configuredFullPath))
            throw new DirectoryNotFoundException(
                $"O diretorio de manifestos nao foi encontrado: {configuredFullPath}");
        return configuredFullPath;
    }

    foreach (var searchRoot in new[] { Directory.GetCurrentDirectory(), AppContext.BaseDirectory })
    {
        var current = new DirectoryInfo(searchRoot);
        while (current != null)
        {
            var candidates = new[]
            {
                Path.Combine(current.FullName, "Manifests"),
                Path.Combine(
                    current.FullName,
                    "src",
                    "Engine",
                    "Yeshua.Engine.AIContextBuilder",
                    "Manifests")
            };

            var match = candidates.FirstOrDefault(Directory.Exists);
            if (match != null)
                return match;

            current = current.Parent;
        }
    }

    throw new DirectoryNotFoundException(
        "O diretorio Manifests nao foi encontrado. Use --manifests-dir <diretorio>.");
}

static string DescribeManifest(string path)
{
    try
    {
        using var document = System.Text.Json.JsonDocument.Parse(File.ReadAllText(path));
        var root = document.RootElement;
        var system = root.TryGetProperty("system", out var systemProperty)
            ? systemProperty.GetString()
            : null;
        var version = root.TryGetProperty("version", out var versionProperty)
            ? versionProperty.GetString()
            : null;

        return $"{system ?? "Sistema nao informado"} | {version ?? "versao nao informada"} | {Path.GetFileName(path)}";
    }
    catch (System.Text.Json.JsonException)
    {
        return $"JSON invalido | {Path.GetFileName(path)}";
    }
}
