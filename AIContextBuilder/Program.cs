using System.Diagnostics;

class Program
{
    static async Task Main(string[] args)
    {
        var solutionPath = @"C:\Users\angel\source\repos\playsistemasinteligentes\YeshuaCreator\YeshuaCreator.sln";
        var outputPath = @"C:\temp\source";

        var builder = new AiContextBuilder();

        var sw = Stopwatch.StartNew();
        // Se passar nome do receiver como argumento
        if (args.Length == 1)
        {
            //var receiverName = args[0];
            var receiverName = "InfraSendFileUseCaseReceiver";
            Console.WriteLine($"Gerando contexto para receiver: {receiverName}");

            await builder.GenerateForReceiver(
                solutionPath,
                receiverName,
                outputPath);
        }
        else
        {
            Console.WriteLine("Gerando contexto para TODOS os receivers...");

            await builder.GenerateForAllReceivers(
                solutionPath,
                outputPath);
        }

        sw.Stop();
        Console.WriteLine($"Tempo: {sw.ElapsedMilliseconds} ms");
        Console.WriteLine("Finalizado.");
    }
}
