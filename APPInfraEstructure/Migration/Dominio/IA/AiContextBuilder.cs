using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System.Text;

public class AiContextBuilder
{
    private static bool _msbuildRegistered = false;

    private void EnsureMSBuildRegistered()
    {
        if (!_msbuildRegistered)
        {
            MSBuildLocator.RegisterDefaults();
            _msbuildRegistered = true;
        }
    }

    public async Task GenerateForReceiver(
        string solutionPath,
        string receiverName,
        string outputDirectory)
    {
        EnsureMSBuildRegistered();

        Directory.CreateDirectory(outputDirectory);

        using var workspace = MSBuildWorkspace.Create();
        var solution = await workspace.OpenSolutionAsync(solutionPath);

        var type = await FindTypeInSolution(solution, receiverName);

        if (type == null)
            throw new Exception($"Receiver {receiverName} não encontrado.");

        var content = await BuildReceiverContext(type);

        var fileName = $"{type.ContainingNamespace}.{type.Name}.context.txt";
        var fullPath = Path.Combine(outputDirectory, fileName);

        File.WriteAllText(fullPath, content);
    }

    public async Task GenerateForAllReceivers(
        string solutionPath,
        string outputDirectory)
    {
        EnsureMSBuildRegistered();

        Directory.CreateDirectory(outputDirectory);

        using var workspace = MSBuildWorkspace.Create();
        var solution = await workspace.OpenSolutionAsync(solutionPath);

        foreach (var project in solution.Projects)
        {
            var compilation = await project.GetCompilationAsync();

            foreach (var type in GetAllTypes(compilation.GlobalNamespace))
            {
                if (type.Name.EndsWith("Receiver"))
                {
                    var content = await BuildReceiverContext(type);

                    var fileName =
                        $"{type.ContainingNamespace}.{type.Name}.context.txt";

                    var fullPath = Path.Combine(outputDirectory, fileName);

                    File.WriteAllText(fullPath, content);
                }
            }
        }
    }

    private async Task<string> BuildReceiverContext(INamedTypeSymbol type)
    {
        var builder = new StringBuilder();

        builder.AppendLine($"# Receiver: {type.ToDisplayString()}");
        builder.AppendLine();

        await AppendTypeCode(builder, type);

        var constructor = type.InstanceConstructors.FirstOrDefault();

        if (constructor != null)
        {
            builder.AppendLine();
            builder.AppendLine("## Dependencies");

            foreach (var parameter in constructor.Parameters)
            {
                builder.AppendLine();
                builder.AppendLine($"### {parameter.Type.ToDisplayString()}");
                await AppendTypeCode(builder, parameter.Type);
            }
        }

        return builder.ToString();
    }

    private async Task AppendTypeCode(StringBuilder builder, ITypeSymbol type)
    {
        var syntaxRef = type.DeclaringSyntaxReferences.FirstOrDefault();
        if (syntaxRef == null)
            return;

        var syntax = await syntaxRef.GetSyntaxAsync();
        var filePath = syntax.SyntaxTree.FilePath;

        if (!File.Exists(filePath))
            return;

        var code = File.ReadAllText(filePath);

        builder.AppendLine($"// File: {filePath}");
        builder.AppendLine("```csharp");
        builder.AppendLine(code);
        builder.AppendLine("```");
    }

    private async Task<INamedTypeSymbol?> FindTypeInSolution(
        Solution solution,
        string typeName)
    {
        foreach (var project in solution.Projects)
        {
            var compilation = await project.GetCompilationAsync();

            var type = FindType(compilation.GlobalNamespace, typeName);

            if (type != null)
                return type;
        }

        return null;
    }

    private IEnumerable<INamedTypeSymbol> GetAllTypes(INamespaceSymbol ns)
    {
        foreach (var member in ns.GetMembers())
        {
            if (member is INamespaceSymbol nestedNs)
            {
                foreach (var nested in GetAllTypes(nestedNs))
                    yield return nested;
            }
            else if (member is INamedTypeSymbol type)
            {
                yield return type;
            }
        }
    }

    private INamedTypeSymbol? FindType(
        INamespaceSymbol ns,
        string name)
    {
        foreach (var type in GetAllTypes(ns))
        {
            if (type.Name == name)
                return type;
        }

        return null;
    }
}
