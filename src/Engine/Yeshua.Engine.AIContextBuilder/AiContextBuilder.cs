using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public class AiContextBuilder
{
    private static bool _msbuildRegistered = false;

    private const int MaxDepth = 6;

    // ✅ CORREÇÃO AQUI
    private readonly Dictionary<INamedTypeSymbol, DomainTypeKind> _graph =
        new(SymbolEqualityComparer.Default);

    private INamedTypeSymbol? _rootType;


    #region PUBLIC API

    public async Task GenerateForReceiver(
        string solutionPath,
        string receiverName,
        string outputDirectory)
    {
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
        Directory.CreateDirectory(outputDirectory);

        using var workspace = MSBuildWorkspace.Create();
        var solution = await workspace.OpenSolutionAsync(solutionPath);

        foreach (var project in solution.Projects)
        {
            var compilation = await project.GetCompilationAsync();

            foreach (var type in GetAllTypes(compilation.GlobalNamespace))
            {
                if (type.Name.EndsWith("Handler"))
                {
                    var content = await BuildContext(type);

                    var fileName =
                        $"{type.Name}__{type.ContainingNamespace}.context.txt";

                    File.WriteAllText(
                        Path.Combine(outputDirectory, fileName),
                        content);
                }
            }
        }
    }

    public async Task GenerateInventory(
        string solutionPath,
        string outputDirectory,
        string? projectNameFilter = null)
    {
        Directory.CreateDirectory(outputDirectory);

        using var workspace = MSBuildWorkspace.Create();
        workspace.WorkspaceFailed += (_, args) =>
            Console.Error.WriteLine($"Workspace: {args.Diagnostic.Kind} - {args.Diagnostic.Message}");

        var projects = solutionPath.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase)
            ? new[] { await workspace.OpenProjectAsync(solutionPath) }
            : (await workspace.OpenSolutionAsync(solutionPath)).Projects.ToArray();

        var selectedProjects = projects
            .Where(project => MatchesProjectFilter(project.Name, projectNameFilter))
            .OrderBy(project => project.Name)
            .ToArray();

        var projectNamesById = projects.ToDictionary(project => project.Id, project => project.Name);
        var projectNamesByFile = projects
            .SelectMany(project => project.Documents
                .Where(document => !string.IsNullOrWhiteSpace(document.FilePath))
                .Select(document => new
                {
                    Path = Path.GetFullPath(document.FilePath!),
                    project.Name
                }))
            .GroupBy(item => item.Path, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.First().Name, StringComparer.OrdinalIgnoreCase);

        var inventory = new OperationalInventory
        {
            SchemaVersion = "1.0",
            GeneratedAtUtc = DateTimeOffset.UtcNow,
            SourceSolution = Path.GetFullPath(solutionPath)
        };

        foreach (var project in selectedProjects)
        {
            var projectInventory = new OperationalInventoryProject
            {
                Name = project.Name,
                AssemblyName = project.AssemblyName,
                Language = project.Language
            };

            foreach (var projectReference in project.ProjectReferences)
            {
                projectInventory.AddEdge(new OperationalInventoryEdge
                {
                    From = project.Name,
                    Relation = "PROJECT_REFERENCES",
                    To = projectNamesById.GetValueOrDefault(projectReference.ProjectId) ?? projectReference.ProjectId.Id.ToString(),
                    Project = project.Name
                });
            }

            foreach (var document in project.Documents.OrderBy(document => document.FilePath))
            {
                if (string.IsNullOrWhiteSpace(document.FilePath))
                    continue;

                projectInventory.Documents.Add(new OperationalInventoryDocument
                {
                    Path = document.FilePath,
                    Name = document.Name,
                    Language = project.Language
                });
            }

            var compilation = await project.GetCompilationAsync();
            if (compilation == null)
            {
                inventory.Projects.Add(projectInventory);
                continue;
            }

            foreach (var type in GetAllTypes(compilation.GlobalNamespace))
            {
                foreach (var location in GetSourceLocations(type))
                {
                    var typeId = AddSymbol(inventory, projectInventory, type, "type", location);
                    projectInventory.AddEdge(new OperationalInventoryEdge
                    {
                        From = project.Name,
                        Relation = "DECLARES",
                        To = typeId,
                        Project = project.Name,
                        File = location.GetLineSpan().Path,
                        Line = location.GetLineSpan().StartLinePosition.Line + 1
                    });
                }

                foreach (var member in type.GetMembers()
                                             .Where(IsInventoryMember)
                                             .Where(member => member.Locations.Any(location => location.IsInSource)))
                {
                    foreach (var location in GetSourceLocations(member))
                    {
                        var memberId = AddSymbol(
                            inventory,
                            projectInventory,
                            member,
                            GetSymbolKind(member),
                            location);

                        projectInventory.AddEdge(new OperationalInventoryEdge
                        {
                            From = GetStableSymbolId(type, project.Name),
                            Relation = "DECLARES",
                            To = memberId,
                            Project = project.Name,
                            File = location.GetLineSpan().Path,
                            Line = location.GetLineSpan().StartLinePosition.Line + 1
                        });
                    }
                }
            }

            await OperationalGraphAnalyzer.AnalyzeProjectAsync(
                project,
                projectInventory,
                projectNamesByFile);

            inventory.Projects.Add(projectInventory);
        }

        var jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var outputPath = Path.Combine(outputDirectory, "operational-inventory.json");
        await File.WriteAllTextAsync(
            outputPath,
            JsonSerializer.Serialize(inventory, jsonOptions));
    }

    public Task GenerateReferenceSql(
        string solutionPath,
        string outputDirectory,
        string applicationName,
        string version,
        string? commitSha = null,
        string? projectNameFilter = null)
    {
        var exporter = new ReferenceSqlExporter();
        return exporter.GenerateAsync(
            solutionPath,
            outputDirectory,
            applicationName,
            version,
            commitSha,
            projectNameFilter);
    }

    private static bool MatchesProjectFilter(string projectName, string? projectNameFilter)
    {
        if (string.IsNullOrWhiteSpace(projectNameFilter))
            return true;

        return projectNameFilter
            .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Any(filter => projectName.Contains(filter, StringComparison.OrdinalIgnoreCase));
    }

    public async Task GenerateSourceInventory(
        string sourceDirectory,
        string outputDirectory,
        string projectName = "legacy-source")
    {
        Directory.CreateDirectory(outputDirectory);

        var inventory = new OperationalInventory
        {
            SchemaVersion = "1.0-syntax",
            GeneratedAtUtc = DateTimeOffset.UtcNow,
            SourceSolution = Path.GetFullPath(sourceDirectory)
        };

        var project = new OperationalInventoryProject
        {
            Name = projectName,
            Language = "C#"
        };

        var sourceFiles = Directory.EnumerateFiles(
                sourceDirectory,
                "*.cs",
                SearchOption.AllDirectories)
            .Where(path => !IsIgnoredSourcePath(path))
            .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
            .ToList();

        foreach (var file in sourceFiles)
        {
            project.Documents.Add(new OperationalInventoryDocument
            {
                Path = file,
                Name = Path.GetFileName(file),
                Language = "C#"
            });

            var source = await File.ReadAllTextAsync(file);
            var tree = CSharpSyntaxTree.ParseText(source, path: file);
            var root = await tree.GetRootAsync();

            foreach (var diagnostic in tree.GetDiagnostics().Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error))
            {
                inventory.Diagnostics.Add($"{file}: {diagnostic.GetMessage()}");
            }

            foreach (var node in root.DescendantNodes().Where(IsInventorySyntaxNode))
            {
                var lineSpan = tree.GetLineSpan(node.Span);
                var qualifiedName = GetSyntaxQualifiedName(node);
                var id = $"{projectName}:{GetSyntaxKind(node)}:{qualifiedName}:{file}:{lineSpan.StartLinePosition.Line + 1}";

                if (!inventory.SymbolIds.Add(id))
                    continue;

                inventory.Symbols.Add(new OperationalInventorySymbol
                {
                    Id = id,
                    Kind = GetSyntaxKind(node),
                    Name = GetSyntaxName(node),
                    QualifiedName = qualifiedName,
                    Project = projectName,
                    File = file,
                    StartLine = lineSpan.StartLinePosition.Line + 1,
                    EndLine = lineSpan.EndLinePosition.Line + 1,
                    Language = "C#"
                });

                var parent = node.Ancestors().FirstOrDefault(IsInventoryTypeNode);
                project.AddEdge(new OperationalInventoryEdge
                {
                    From = parent == null
                        ? projectName
                        : $"{projectName}:type:{GetSyntaxQualifiedName(parent)}:{file}:{tree.GetLineSpan(parent.Span).StartLinePosition.Line + 1}",
                    Relation = "DECLARES",
                    To = id,
                    Project = projectName,
                    File = file,
                    Line = lineSpan.StartLinePosition.Line + 1,
                    Resolution = "resolved_syntax"
                });
            }
        }

        inventory.Projects.Add(project);

        var jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        await File.WriteAllTextAsync(
            Path.Combine(outputDirectory, "operational-inventory.json"),
            JsonSerializer.Serialize(inventory, jsonOptions));
    }

    private static bool IsIgnoredSourcePath(string path)
    {
        return path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
            .Any(part => part.Equals("bin", StringComparison.OrdinalIgnoreCase) ||
                         part.Equals("obj", StringComparison.OrdinalIgnoreCase) ||
                         part.Equals(".git", StringComparison.OrdinalIgnoreCase) ||
                         part.Equals("packages", StringComparison.OrdinalIgnoreCase));
    }

    private static bool IsInventorySyntaxNode(SyntaxNode node)
    {
        return node is BaseTypeDeclarationSyntax or
            MethodDeclarationSyntax or
            PropertyDeclarationSyntax or
            FieldDeclarationSyntax or
            EventDeclarationSyntax;
    }

    private static bool IsInventoryTypeNode(SyntaxNode node)
    {
        return node is BaseTypeDeclarationSyntax;
    }

    private static string GetSyntaxKind(SyntaxNode node)
    {
        return node switch
        {
            BaseTypeDeclarationSyntax => "type",
            MethodDeclarationSyntax => "method",
            PropertyDeclarationSyntax => "property",
            FieldDeclarationSyntax => "field",
            EventDeclarationSyntax => "event",
            _ => "syntax"
        };
    }

    private static string GetSyntaxName(SyntaxNode node)
    {
        return node switch
        {
            BaseTypeDeclarationSyntax type => type.Identifier.ValueText,
            MethodDeclarationSyntax method => method.Identifier.ValueText,
            PropertyDeclarationSyntax property => property.Identifier.ValueText,
            FieldDeclarationSyntax field => string.Join(", ", field.Declaration.Variables.Select(variable => variable.Identifier.ValueText)),
            EventDeclarationSyntax @event => @event.Identifier.ValueText,
            _ => node.GetType().Name
        };
    }

    private static string GetSyntaxQualifiedName(SyntaxNode node)
    {
        var names = node.AncestorsAndSelf()
            .Reverse()
            .Select(current => current switch
            {
                BaseNamespaceDeclarationSyntax @namespace => @namespace.Name.ToString(),
                BaseTypeDeclarationSyntax type => type.Identifier.ValueText,
                MethodDeclarationSyntax method => method.Identifier.ValueText,
                PropertyDeclarationSyntax property => property.Identifier.ValueText,
                FieldDeclarationSyntax field => string.Join(", ", field.Declaration.Variables.Select(variable => variable.Identifier.ValueText)),
                EventDeclarationSyntax @event => @event.Identifier.ValueText,
                _ => null
            })
            .Where(name => !string.IsNullOrWhiteSpace(name));

        return string.Join(".", names!);
    }

    private static string AddSymbol(
        OperationalInventory inventory,
        OperationalInventoryProject project,
        ISymbol symbol,
        string kind,
        Location location)
    {
        var id = GetStableSymbolId(symbol, project.Name, location);

        if (!inventory.SymbolIds.Add(id))
            return id;

        var lineSpan = location.GetLineSpan();
        inventory.Symbols.Add(new OperationalInventorySymbol
        {
            Id = id,
            Kind = kind,
            Name = symbol.Name,
            QualifiedName = symbol.ToDisplayString(),
            Project = project.Name,
            File = lineSpan.Path,
            StartLine = lineSpan.StartLinePosition.Line + 1,
            EndLine = lineSpan.EndLinePosition.Line + 1,
            Language = symbol.Language
        });

        return id;
    }

    private static IEnumerable<Location> GetSourceLocations(ISymbol symbol)
    {
        return symbol.Locations.Where(location => location.IsInSource);
    }

    private static string GetSymbolKind(ISymbol symbol)
    {
        return symbol switch
        {
            IMethodSymbol => "method",
            IPropertySymbol => "property",
            IFieldSymbol => "field",
            IEventSymbol => "event",
            INamedTypeSymbol => "type",
            _ => symbol.Kind.ToString().ToLowerInvariant()
        };
    }

    private static bool IsInventoryMember(ISymbol symbol)
    {
        if (symbol.IsImplicitlyDeclared)
            return false;

        return symbol switch
        {
            IMethodSymbol method => method.MethodKind is
                MethodKind.Ordinary or
                MethodKind.Constructor or
                MethodKind.StaticConstructor or
                MethodKind.UserDefinedOperator or
                MethodKind.Conversion,
            IPropertySymbol => true,
            IFieldSymbol => true,
            IEventSymbol => true,
            INamedTypeSymbol => true,
            _ => false
        };
    }

    private static string GetStableSymbolId(
        ISymbol symbol,
        string projectName,
        Location? location = null)
    {
        var sourceLocation = location ?? symbol.Locations.FirstOrDefault(item => item.IsInSource);
        var line = sourceLocation?.GetLineSpan().StartLinePosition.Line + 1 ?? 0;
        var file = sourceLocation?.GetLineSpan().Path ?? string.Empty;

        return $"{projectName}:{symbol.Kind}:{symbol.ToDisplayString()}:{file}:{line}";
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

public sealed class OperationalInventory
{
    public string SchemaVersion { get; set; } = string.Empty;
    public DateTimeOffset GeneratedAtUtc { get; set; }
    public string SourceSolution { get; set; } = string.Empty;
    public List<OperationalInventoryProject> Projects { get; set; } = new();
    public List<OperationalInventorySymbol> Symbols { get; set; } = new();
    public List<string> Diagnostics { get; set; } = new();

    [JsonIgnore]
    public HashSet<string> SymbolIds { get; } = new(StringComparer.Ordinal);
}

public sealed class OperationalInventoryProject
{
    public string Name { get; set; } = string.Empty;
    public string? AssemblyName { get; set; }
    public string Language { get; set; } = string.Empty;
    public List<OperationalInventoryDocument> Documents { get; set; } = new();
    public List<OperationalInventoryEdge> Edges { get; set; } = new();

    [JsonIgnore]
    public HashSet<string> EdgeIds { get; } = new(StringComparer.Ordinal);

    public void AddEdge(OperationalInventoryEdge edge)
    {
        var key = $"{edge.From}|{edge.Relation}|{edge.To}|{edge.File}|{edge.Line}";
        if (EdgeIds.Add(key))
            Edges.Add(edge);
    }
}

public sealed class OperationalInventoryDocument
{
    public string Path { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
}

public sealed class OperationalInventorySymbol
{
    public string Id { get; set; } = string.Empty;
    public string Kind { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string QualifiedName { get; set; } = string.Empty;
    public string Project { get; set; } = string.Empty;
    public string File { get; set; } = string.Empty;
    public int StartLine { get; set; }
    public int EndLine { get; set; }
    public string Language { get; set; } = string.Empty;
}

public sealed class OperationalInventoryEdge
{
    public string From { get; set; } = string.Empty;
    public string Relation { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public string Project { get; set; } = string.Empty;
    public string File { get; set; } = string.Empty;
    public int Line { get; set; }
    public double Confidence { get; set; } = 1.0;
    public string Resolution { get; set; } = "resolved_static";
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
