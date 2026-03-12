using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System.Text;

public class AiContextBuilder
{
    private static bool _msbuildRegistered = false;

    private const int MaxDepth = 6;

    // ✅ CORREÇÃO AQUI
    private readonly Dictionary<INamedTypeSymbol, DomainTypeKind> _graph =
        new(SymbolEqualityComparer.Default);

    private INamedTypeSymbol? _rootType;


    private void EnsureMSBuildRegistered()
    {
        if (!_msbuildRegistered)
        {
            MSBuildLocator.RegisterDefaults();
            _msbuildRegistered = true;
        }
    }

    #region PUBLIC API

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

        var content = await BuildContext(type);

        var fileName =
            $"{type.ContainingNamespace}.{type.Name}.context.txt";

        File.WriteAllText(
            Path.Combine(outputDirectory, fileName),
            content);
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
                    var content = await BuildContext(type);

                    var fileName =
                        $"{type.ContainingNamespace}.{type.Name}.context.txt";

                    File.WriteAllText(
                        Path.Combine(outputDirectory, fileName),
                        content);
                }
            }
        }
    }

    #endregion

    #region DOMAIN GRAPH CORE

    private async Task<string> BuildContext(INamedTypeSymbol root)
    {
        _graph.Clear();
        _rootType = root; // 🔥 guardar root

        await ResolveType(root);

        var builder = new StringBuilder();

        builder.AppendLine("# DOMAIN GRAPH CONTEXT");
        builder.AppendLine($"# Root: {root.ToDisplayString()}");
        builder.AppendLine();

        AppendSection(builder, DomainTypeKind.AggregateRoot);
        AppendSection(builder, DomainTypeKind.Entity);
        AppendSection(builder, DomainTypeKind.ValueObject);
        AppendSection(builder, DomainTypeKind.DTO);
        AppendSection(builder, DomainTypeKind.Repository);
        AppendSection(builder, DomainTypeKind.Factory);
        AppendSection(builder, DomainTypeKind.Service);
        AppendSection(builder, DomainTypeKind.Unknown);

        return builder.ToString();
    }

    private async Task ResolveType(
        INamedTypeSymbol type,
        int depth = 0)
    {
        if (type == null)
            return;

        if (depth > MaxDepth)
            return;

        if (type.SpecialType != SpecialType.None)
            return;

        // 🔥 Ignorar tipos externos (System, etc.)
        if (type.Locations.All(l => !l.IsInSource))
            return;

        if (_graph.ContainsKey(type))
            return;

        var kind = TypeClassifier.Classify(type);
        _graph[type] = kind;

        // 🔹 Propriedades
        foreach (var prop in type.GetMembers().OfType<IPropertySymbol>())
        {
            await ResolveSymbolType(prop.Type, depth);
        }

        // 🔹 Métodos
        foreach (var method in type.GetMembers().OfType<IMethodSymbol>())
        {
            await ResolveSymbolType(method.ReturnType, depth);

            foreach (var param in method.Parameters)
                await ResolveSymbolType(param.Type, depth);
        }

        // 🔹 Base
        if (type.BaseType != null)
            await ResolveType(type.BaseType, depth + 1);

        // 🔹 Interfaces
        foreach (var iface in type.Interfaces)
            await ResolveType(iface, depth + 1);

        // 🔹 Factory heurística
        await TryResolveFactory(type, depth);
    }

    private async Task ResolveSymbolType(ITypeSymbol symbol, int depth)
    {
        if (symbol is not INamedTypeSymbol named)
            return;

        if (named.IsGenericType)
        {
            foreach (var arg in named.TypeArguments)
            {
                if (arg is INamedTypeSymbol argNamed)
                    await ResolveType(argNamed, depth + 1);
            }
        }
        else
        {
            await ResolveType(named, depth + 1);
        }
    }

    private async Task TryResolveFactory(
        INamedTypeSymbol entity,
        int depth)
    {
        var members = entity.ContainingNamespace.GetMembers();

        foreach (var member in members)
        {
            if (member is INamedTypeSymbol type &&
                type.Name.Contains(entity.Name) &&
                type.Name.EndsWith("Factory") &&
                type.Locations.Any(l => l.IsInSource))
            {
                await ResolveType(type, depth + 1);
            }
        }
    }

    #endregion

    #region FORMATTER

    private void AppendSection(
        StringBuilder builder,
        DomainTypeKind kind)
    {
        var types = _graph
            .Where(x => x.Value == kind)
            .Select(x => x.Key)
            .OrderBy(t => t.Name)
            .ToList();

        if (!types.Any())
            return;

        builder.AppendLine($"## {kind}");
        builder.AppendLine();

        foreach (var type in types)
        {
            builder.AppendLine($"### {type.Name}");
            builder.AppendLine();

            // 🔥 Se for o Receiver (root) → código completo
            if (_rootType != null &&
                SymbolEqualityComparer.Default.Equals(type, _rootType))
            {
                AppendFullSource(builder, type);
            }
            else
            {
                AppendLightStructure(builder, type);
            }

            builder.AppendLine();
        }
    }

    private void AppendFullSource(
    StringBuilder builder,
    INamedTypeSymbol type)
    {
        foreach (var location in type.Locations)
        {
            if (!location.IsInSource)
                continue;

            var tree = location.SourceTree;
            if (tree == null)
                continue;

            var source = tree.GetText().ToString();

            builder.AppendLine("```csharp");
            builder.AppendLine(source);
            builder.AppendLine("```");
        }
    }


    private void AppendLightStructure(
        StringBuilder builder,
        INamedTypeSymbol type)
    {
        builder.AppendLine($"namespace {type.ContainingNamespace}");
        builder.AppendLine("{");

        builder.AppendLine($"   public {GetKindKeyword(type)} {type.Name}");
        builder.AppendLine("   {");

        foreach (var prop in type.GetMembers().OfType<IPropertySymbol>())
        {
            builder.AppendLine(
                $"      {prop.Type.Name} {prop.Name};");
        }

        foreach (var method in type.GetMembers()
                                   .OfType<IMethodSymbol>()
                                   .Where(m => m.MethodKind ==
                                               MethodKind.Ordinary))
        {
            builder.AppendLine(
                $"      {method.ReturnType.Name} {method.Name}(...);");
        }

        builder.AppendLine("   }");
        builder.AppendLine("}");
    }

    private string GetKindKeyword(INamedTypeSymbol type)
    {
        return type.TypeKind switch
        {
            TypeKind.Interface => "interface",
            TypeKind.Struct => "struct",
            _ => "class"
        };
    }

    #endregion

    #region SOLUTION HELPERS

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

    #endregion
}

#region CLASSIFIER

public enum DomainTypeKind
{
    AggregateRoot,
    Entity,
    ValueObject,
    DTO,
    Repository,
    Factory,
    Service,
    Unknown
}

public static class TypeClassifier
{
    public static DomainTypeKind Classify(INamedTypeSymbol type)
    {
        var name = type.Name;

        if (name.EndsWith("DTO"))
            return DomainTypeKind.DTO;

        if (name.EndsWith("Repository"))
            return DomainTypeKind.Repository;

        if (name.EndsWith("Factory"))
            return DomainTypeKind.Factory;

        if (name.EndsWith("Service"))
            return DomainTypeKind.Service;

        var hasId = type.GetMembers()
                        .OfType<IPropertySymbol>()
                        .Any(p => p.Name.Equals("Id",
                            StringComparison.OrdinalIgnoreCase));

        if (hasId)
            return DomainTypeKind.Entity;

        if (type.TypeKind == TypeKind.Class)
            return DomainTypeKind.ValueObject;

        return DomainTypeKind.Unknown;
    }
}

#endregion
