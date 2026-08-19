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
