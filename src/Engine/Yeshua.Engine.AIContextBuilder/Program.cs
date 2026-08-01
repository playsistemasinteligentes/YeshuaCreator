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