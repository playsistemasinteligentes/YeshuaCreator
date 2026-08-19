using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

internal static class OperationalGraphAnalyzer
{
    public static async Task AnalyzeProjectAsync(
        Project project,
        OperationalInventoryProject inventory,
        IReadOnlyDictionary<string, string> projectNamesByFile)
    {
        foreach (var document in project.Documents)
        {
            var root = await document.GetSyntaxRootAsync();
            var semanticModel = await document.GetSemanticModelAsync();

            if (root == null || semanticModel == null)
                continue;

            AnalyzeCalls(project.Name, inventory, projectNamesByFile, semanticModel, root);
            AnalyzeObjectCreations(project.Name, inventory, projectNamesByFile, semanticModel, root);
            AnalyzeWrites(project.Name, inventory, projectNamesByFile, semanticModel, root);
            AnalyzeTypeUses(project.Name, inventory, projectNamesByFile, semanticModel, root);
            AnalyzeTypeHierarchy(project.Name, inventory, projectNamesByFile, semanticModel, root);
        }
    }

    private static void AnalyzeCalls(
        string projectName,
        OperationalInventoryProject inventory,
        IReadOnlyDictionary<string, string> projectNamesByFile,
        SemanticModel semanticModel,
        SyntaxNode root)
    {
        foreach (var invocation in root.DescendantNodes().OfType<InvocationExpressionSyntax>())
        {
            var caller = semanticModel.GetEnclosingSymbol(invocation.SpanStart);
            var target = ResolveMethod(semanticModel.GetSymbolInfo(invocation), out var confidence);

            AddRelation(
                projectName,
                inventory,
                projectNamesByFile,
                caller,
                "CALLS",
                target,
                invocation,
                confidence,
                target == null ? "unresolved_dynamic" : null);
        }
    }

    private static void AnalyzeObjectCreations(
        string projectName,
        OperationalInventoryProject inventory,
        IReadOnlyDictionary<string, string> projectNamesByFile,
        SemanticModel semanticModel,
        SyntaxNode root)
    {
        foreach (var creation in root.DescendantNodes().OfType<ObjectCreationExpressionSyntax>())
        {
            var caller = semanticModel.GetEnclosingSymbol(creation.SpanStart);
            var constructor = ResolveMethod(semanticModel.GetSymbolInfo(creation), out var confidence);
            var createdType = constructor?.ContainingType ?? semanticModel.GetTypeInfo(creation).Type;

            AddRelation(
                projectName,
                inventory,
                projectNamesByFile,
                caller,
                "CREATES",
                createdType,
                creation,
                confidence,
                createdType == null ? "unresolved_dynamic" : null);
        }
    }

    private static void AnalyzeWrites(
        string projectName,
        OperationalInventoryProject inventory,
        IReadOnlyDictionary<string, string> projectNamesByFile,
        SemanticModel semanticModel,
        SyntaxNode root)
    {
        foreach (var assignment in root.DescendantNodes().OfType<AssignmentExpressionSyntax>())
        {
            var writer = semanticModel.GetEnclosingSymbol(assignment.SpanStart);
            var target = ResolveSymbol(semanticModel.GetSymbolInfo(assignment.Left), out var confidence);

            AddRelation(
                projectName,
                inventory,
                projectNamesByFile,
                writer,
                "WRITES",
                target,
                assignment.Left,
                confidence,
                target == null ? "unresolved_dynamic" : null);
        }
    }

    private static void AnalyzeTypeUses(
        string projectName,
        OperationalInventoryProject inventory,
        IReadOnlyDictionary<string, string> projectNamesByFile,
        SemanticModel semanticModel,
        SyntaxNode root)
    {
        foreach (var parameter in root.DescendantNodes().OfType<ParameterSyntax>())
        {
            var parameterSymbol = semanticModel.GetDeclaredSymbol(parameter) as IParameterSymbol;
            AddRelation(
                projectName,
                inventory,
                projectNamesByFile,
                parameterSymbol?.ContainingSymbol,
                "USES_TYPE",
                parameterSymbol?.Type,
                parameter,
                1.0,
                null);
        }

        foreach (var field in root.DescendantNodes().OfType<FieldDeclarationSyntax>())
        {
            var variable = field.Declaration.Variables.FirstOrDefault();
            var fieldSymbol = variable == null ? null : semanticModel.GetDeclaredSymbol(variable) as IFieldSymbol;

            AddRelation(
                projectName,
                inventory,
                projectNamesByFile,
                fieldSymbol?.ContainingType,
                "USES_TYPE",
                fieldSymbol?.Type,
                field.Declaration.Type,
                1.0,
                null);
        }
    }

    private static void AnalyzeTypeHierarchy(
        string projectName,
        OperationalInventoryProject inventory,
        IReadOnlyDictionary<string, string> projectNamesByFile,
        SemanticModel semanticModel,
        SyntaxNode root)
    {
        foreach (var declaration in root.DescendantNodes().OfType<BaseTypeDeclarationSyntax>())
        {
            var type = semanticModel.GetDeclaredSymbol(declaration) as INamedTypeSymbol;
            if (type == null)
                continue;

            if (type.BaseType is { SpecialType: SpecialType.None } baseType)
            {
                AddRelation(
                    projectName,
                    inventory,
                    projectNamesByFile,
                    type,
                    "INHERITS",
                    baseType,
                    declaration,
                    1.0,
                    null);
            }

            foreach (var @interface in type.Interfaces)
            {
                AddRelation(
                    projectName,
                    inventory,
                    projectNamesByFile,
                    type,
                    "IMPLEMENTS",
                    @interface,
                    declaration,
                    1.0,
                    null);
            }
        }
    }

    private static void AddRelation(
        string projectName,
        OperationalInventoryProject inventory,
        IReadOnlyDictionary<string, string> projectNamesByFile,
        ISymbol? from,
        string relation,
        ISymbol? to,
        SyntaxNode evidence,
        double confidence,
        string? forcedResolution)
    {
        if (from == null || to == null)
            return;

        from = NormalizeSymbol(from);
        to = NormalizeSymbol(to);

        var lineSpan = evidence.GetLocation().GetLineSpan();
        inventory.AddEdge(new OperationalInventoryEdge
        {
            From = GetSymbolId(from, projectName, projectNamesByFile),
            Relation = relation,
            To = GetSymbolId(to, projectName, projectNamesByFile),
            Project = projectName,
            File = lineSpan.Path,
            Line = lineSpan.StartLinePosition.Line + 1,
            Confidence = confidence,
            Resolution = forcedResolution ?? GetResolution(to, projectNamesByFile)
        });
    }

    private static ISymbol? ResolveSymbol(SymbolInfo symbolInfo, out double confidence)
    {
        if (symbolInfo.Symbol != null)
        {
            confidence = 1.0;
            return symbolInfo.Symbol;
        }

        confidence = 0.5;
        return symbolInfo.CandidateSymbols.FirstOrDefault();
    }

    private static IMethodSymbol? ResolveMethod(SymbolInfo symbolInfo, out double confidence)
    {
        var symbol = ResolveSymbol(symbolInfo, out confidence);
        return symbol as IMethodSymbol;
    }

    private static ISymbol NormalizeSymbol(ISymbol symbol)
    {
        return symbol switch
        {
            IMethodSymbol method => (method.ReducedFrom ?? method).OriginalDefinition,
            INamedTypeSymbol type => type.OriginalDefinition,
            IPropertySymbol property => property.OriginalDefinition,
            IFieldSymbol field => field.OriginalDefinition,
            _ => symbol.OriginalDefinition
        };
    }

    private static string GetSymbolId(
        ISymbol symbol,
        string fallbackProjectName,
        IReadOnlyDictionary<string, string> projectNamesByFile)
    {
        var sourceLocation = symbol.Locations.FirstOrDefault(location => location.IsInSource);
        if (sourceLocation == null)
        {
            var assembly = symbol.ContainingAssembly?.Name ?? "unknown";
            return $"external:{assembly}:{symbol.Kind}:{symbol.ToDisplayString()}";
        }

        var lineSpan = sourceLocation.GetLineSpan();
        var path = string.IsNullOrWhiteSpace(lineSpan.Path)
            ? string.Empty
            : Path.GetFullPath(lineSpan.Path);
        var projectName = projectNamesByFile.GetValueOrDefault(path) ?? fallbackProjectName;

        return $"{projectName}:{symbol.Kind}:{symbol.ToDisplayString()}:{lineSpan.Path}:{lineSpan.StartLinePosition.Line + 1}";
    }

    private static string GetResolution(
        ISymbol symbol,
        IReadOnlyDictionary<string, string> projectNamesByFile)
    {
        var sourceLocation = symbol.Locations.FirstOrDefault(location => location.IsInSource);
        if (sourceLocation == null)
            return "external_metadata";

        var path = sourceLocation.GetLineSpan().Path;
        if (string.IsNullOrWhiteSpace(path))
            return "resolved_static";

        return projectNamesByFile.ContainsKey(Path.GetFullPath(path))
            ? "resolved_static"
            : "source_outside_scope";
    }
}
