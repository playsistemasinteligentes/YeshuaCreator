using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using System.Security.Cryptography;

internal sealed class ReferenceSqlExporter
{
    public async Task GenerateAsync(
        string solutionPath,
        string outputDirectory,
        string applicationName,
        string version,
        string? commitSha,
        string? projectNameFilter)
    {
        Directory.CreateDirectory(outputDirectory);

        using var workspace = MSBuildWorkspace.Create();
        workspace.WorkspaceFailed += (_, args) =>
            Console.Error.WriteLine($"Workspace: {args.Diagnostic.Kind} - {args.Diagnostic.Message}");

        var solution = solutionPath.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase)
            ? (await workspace.OpenProjectAsync(solutionPath)).Solution
            : await workspace.OpenSolutionAsync(solutionPath);

        var seedProjects = solution.Projects
            .Where(project => MatchesProjectFilter(project.Name, projectNameFilter))
            .OrderBy(project => project.Name)
            .ToArray();

        if (seedProjects.Length == 0)
            throw new InvalidOperationException($"Nenhum projeto corresponde ao filtro '{projectNameFilter}'.");

        var indexedProjects = ExpandProjectReferences(solution, seedProjects);
        var model = new ReferenceIndexModel
        {
            ApplicationId = StableGuid.Create($"application|{applicationName.Trim().ToUpperInvariant()}"),
            BuildId = StableGuid.Create(
                $"build|{applicationName.Trim().ToUpperInvariant()}|{version.Trim()}|{commitSha?.Trim()}"),
            ApplicationName = applicationName.Trim(),
            Version = version.Trim(),
            CommitSha = string.IsNullOrWhiteSpace(commitSha) ? null : commitSha.Trim(),
            SourceSolution = Path.GetFullPath(solutionPath)
        };

        var collector = new ReferenceIndexCollector(
            model,
            solution,
            indexedProjects,
            seedProjects.Select(project => project.Id).ToHashSet(),
            Path.GetDirectoryName(Path.GetFullPath(solutionPath)) ?? Directory.GetCurrentDirectory());

        await collector.CollectAsync();
        await ReferenceSqlWriter.WriteAsync(model, outputDirectory);

        Console.WriteLine($"Projetos indexados: {model.Projects.Count}");
        Console.WriteLine($"Arquivos indexados: {model.Files.Count}");
        Console.WriteLine($"Simbolos indexados: {model.Symbols.Count}");
        Console.WriteLine($"Leituras/escritas de campos: {model.FieldReferences.Count}");
        Console.WriteLine($"Instanciacoes de classes: {model.ClassInstantiations.Count}");
        Console.WriteLine($"Chamadas diretas: {model.FunctionCalls.Count}");
    }

    private static bool MatchesProjectFilter(string projectName, string? projectNameFilter)
    {
        if (string.IsNullOrWhiteSpace(projectNameFilter))
            return true;

        return projectNameFilter
            .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Any(filter => projectName.Contains(filter, StringComparison.OrdinalIgnoreCase));
    }

    private static Project[] ExpandProjectReferences(Solution solution, IEnumerable<Project> seedProjects)
    {
        var selected = new Dictionary<ProjectId, Project>();
        var pending = new Queue<Project>(seedProjects);

        while (pending.TryDequeue(out var project))
        {
            if (!selected.TryAdd(project.Id, project))
                continue;

            foreach (var reference in project.ProjectReferences)
            {
                var referencedProject = solution.GetProject(reference.ProjectId);
                if (referencedProject != null)
                    pending.Enqueue(referencedProject);
            }
        }

        return selected.Values.OrderBy(project => project.Name).ToArray();
    }
}

internal sealed class ReferenceIndexCollector
{
    private readonly ReferenceIndexModel _model;
    private readonly Solution _solution;
    private readonly Project[] _projects;
    private readonly HashSet<ProjectId> _seedProjectIds;
    private readonly string _sourceRoot;
    private readonly Dictionary<ProjectId, ReferenceProjectRow> _projectRows = new();
    private readonly Dictionary<string, ReferenceFileRow> _filesByProjectAndPath =
        new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, List<Project>> _projectsByFile =
        new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, List<Project>> _projectsByAssembly =
        new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<ProjectId, Compilation> _compilations = new();
    private readonly HashSet<ProjectId> _indexedProjectIds;

    public ReferenceIndexCollector(
        ReferenceIndexModel model,
        Solution solution,
        Project[] projects,
        HashSet<ProjectId> seedProjectIds,
        string sourceRoot)
    {
        _model = model;
        _solution = solution;
        _projects = projects;
        _seedProjectIds = seedProjectIds;
        _sourceRoot = sourceRoot;
        _indexedProjectIds = projects.Select(project => project.Id).ToHashSet();
    }

    public async Task CollectAsync()
    {
        await RegisterProjectsAndFilesAsync();
        await RegisterSymbolsAsync();

        foreach (var project in _projects)
        {
            foreach (var document in project.Documents.OrderBy(document => document.FilePath))
                await AnalyzeDocumentAsync(project, document);
        }

        AddDispatchRelations();
    }

    private async Task RegisterProjectsAndFilesAsync()
    {
        foreach (var project in _projects)
        {
            var projectIdentity = $"{project.Name}|{project.FilePath}|{project.AssemblyName}";
            var projectRow = new ReferenceProjectRow(
                _model.CreateId("project", projectIdentity),
                _model.BuildId,
                project.Name,
                project.AssemblyName,
                ToRelativePath(project.FilePath),
                _seedProjectIds.Contains(project.Id));

            _projectRows[project.Id] = projectRow;
            _model.Projects[projectRow.ProjectId] = projectRow;

            if (!string.IsNullOrWhiteSpace(project.AssemblyName))
            {
                if (!_projectsByAssembly.TryGetValue(project.AssemblyName, out var assemblyProjects))
                {
                    assemblyProjects = new List<Project>();
                    _projectsByAssembly[project.AssemblyName] = assemblyProjects;
                }

                assemblyProjects.Add(project);
            }

            foreach (var document in project.Documents.OrderBy(document => document.FilePath))
            {
                if (string.IsNullOrWhiteSpace(document.FilePath))
                    continue;

                var fullPath = Path.GetFullPath(document.FilePath);
                var key = GetFileKey(project.Id, fullPath);
                if (_filesByProjectAndPath.ContainsKey(key))
                    continue;

                var relativePath = ToRelativePath(fullPath) ?? fullPath.Replace('\\', '/');
                var hash = await CalculateFileHashAsync(fullPath);
                var fileRow = new ReferenceFileRow(
                    _model.CreateId("file", $"{projectRow.ProjectId:N}|{relativePath}"),
                    _model.BuildId,
                    projectRow.ProjectId,
                    relativePath,
                    hash);

                _filesByProjectAndPath[key] = fileRow;
                _model.Files[fileRow.FileId] = fileRow;

                if (!_projectsByFile.TryGetValue(fullPath, out var fileProjects))
                {
                    fileProjects = new List<Project>();
                    _projectsByFile[fullPath] = fileProjects;
                }

                fileProjects.Add(project);
            }

            var compilation = await project.GetCompilationAsync();
            if (compilation != null)
                _compilations[project.Id] = compilation;
        }
    }

    private Task RegisterSymbolsAsync()
    {
        foreach (var project in _projects)
        {
            if (!_compilations.TryGetValue(project.Id, out var compilation))
                continue;

            foreach (var type in GetAllTypes(compilation.GlobalNamespace))
            {
                EnsureSymbol(type, project);

                foreach (var member in type.GetMembers())
                {
                    switch (member)
                    {
                        case IFieldSymbol field when !field.IsImplicitlyDeclared:
                            EnsureSymbol(field, project);
                            break;
                        case IPropertySymbol property:
                            EnsureSymbol(property, project);
                            EnsureSymbol(property.GetMethod, project);
                            EnsureSymbol(property.SetMethod, project);
                            break;
                        case IMethodSymbol method when IsIndexableMethod(method):
                            EnsureSymbol(method, project);
                            break;
                    }
                }
            }
        }

        return Task.CompletedTask;
    }

    private async Task AnalyzeDocumentAsync(Project project, Document document)
    {
        if (string.IsNullOrWhiteSpace(document.FilePath))
            return;

        var root = await document.GetSyntaxRootAsync();
        var semanticModel = await document.GetSemanticModelAsync();
        if (root == null || semanticModel == null)
            return;

        AnalyzeFunctionCalls(project, semanticModel, root);
        AnalyzeClassInstantiations(project, semanticModel, root);
        AnalyzeFieldReferences(project, semanticModel, root);
    }

    private void AnalyzeFunctionCalls(Project project, SemanticModel semanticModel, SyntaxNode root)
    {
        foreach (var invocation in root.DescendantNodes().OfType<InvocationExpressionSyntax>())
        {
            var caller = GetContainingFunction(semanticModel, invocation.SpanStart);
            var called = ResolveMethod(semanticModel.GetSymbolInfo(invocation));
            AddFunctionCall(project, caller, called, invocation, "STATIC_CALL");
        }

        foreach (var initializer in root.DescendantNodes().OfType<ConstructorInitializerSyntax>())
        {
            var caller = GetContainingFunction(semanticModel, initializer.SpanStart);
            var called = ResolveMethod(semanticModel.GetSymbolInfo(initializer));
            AddFunctionCall(project, caller, called, initializer, "CONSTRUCTOR_CALL");
        }
    }

    private void AnalyzeClassInstantiations(Project project, SemanticModel semanticModel, SyntaxNode root)
    {
        var creations = root.DescendantNodes()
            .Where(node => node is ObjectCreationExpressionSyntax or ImplicitObjectCreationExpressionSyntax);

        foreach (var creation in creations)
        {
            var constructor = ResolveMethod(semanticModel.GetSymbolInfo(creation));
            var createdType = constructor?.ContainingType ?? semanticModel.GetTypeInfo(creation).Type as INamedTypeSymbol;
            if (createdType is not { TypeKind: TypeKind.Class })
                continue;

            var classId = EnsureSymbol(createdType, project);
            if (classId == null)
                continue;

            var constructorId = EnsureSymbol(constructor, project);
            var containingFunction = GetContainingFunction(semanticModel, creation.SpanStart);
            var containingFunctionId = EnsureSymbol(containingFunction, project);
            var location = GetEvidence(project, creation);
            if (location == null)
                continue;

            var identity = $"{classId:N}|{constructorId:N}|{containingFunctionId:N}|{location.Value.FileId:N}|{creation.SpanStart}";
            var row = new ClassInstantiationRow(
                _model.CreateId("class-instantiation", identity),
                _model.BuildId,
                classId.Value,
                constructorId,
                containingFunctionId,
                location.Value.FileId,
                location.Value.Line,
                location.Value.Column,
                "DIRECT_NEW");

            _model.ClassInstantiations.TryAdd(row.InstantiationId, row);
            AddFunctionCall(project, containingFunction, constructor, creation, "CONSTRUCTOR_CALL");
        }
    }

    private void AnalyzeFieldReferences(Project project, SemanticModel semanticModel, SyntaxNode root)
    {
        foreach (var reference in GetPotentialFieldReferences(root))
        {
            if (IsInsideNameOf(reference))
                continue;

            var symbol = ResolveSymbol(semanticModel.GetSymbolInfo(reference));
            if (symbol is not IFieldSymbol and not IPropertySymbol)
                continue;

            var fieldId = EnsureSymbol(symbol, project);
            if (fieldId == null)
                continue;

            var containingFunction = GetContainingFunction(semanticModel, reference.SpanStart);
            var containingFunctionId = EnsureSymbol(containingFunction, project);
            var accessKind = ClassifyFieldAccess(reference);
            var location = GetEvidence(project, reference);
            if (location == null)
                continue;

            var identity = $"{fieldId:N}|{containingFunctionId:N}|{accessKind}|{location.Value.FileId:N}|{reference.SpanStart}";
            var row = new FieldReferenceRow(
                _model.CreateId("field-reference", identity),
                _model.BuildId,
                fieldId.Value,
                containingFunctionId,
                location.Value.FileId,
                accessKind,
                location.Value.Line,
                location.Value.Column,
                "ROSLYN_SYMBOL");

            _model.FieldReferences.TryAdd(row.FieldReferenceId, row);
            AddPropertyAccessorCalls(project, containingFunction, symbol as IPropertySymbol, accessKind, reference);
        }
    }

    private void AddPropertyAccessorCalls(
        Project project,
        IMethodSymbol? caller,
        IPropertySymbol? property,
        string accessKind,
        SyntaxNode evidence)
    {
        if (caller == null || property == null)
            return;

        if (accessKind is "READ" or "READ_WRITE")
            AddFunctionCall(project, caller, property.GetMethod, evidence, "PROPERTY_GET");

        if (accessKind is "WRITE" or "READ_WRITE")
            AddFunctionCall(project, caller, property.SetMethod, evidence, "PROPERTY_SET");
    }

    private void AddDispatchRelations()
    {
        foreach (var project in _projects)
        {
            if (!_compilations.TryGetValue(project.Id, out var compilation))
                continue;

            foreach (var type in GetAllTypes(compilation.GlobalNamespace)
                         .Where(type => type.TypeKind == TypeKind.Class && !type.IsAbstract))
            {
                foreach (var method in type.GetMembers().OfType<IMethodSymbol>())
                {
                    if (method.OverriddenMethod != null)
                        AddDispatchCall(project, method.OverriddenMethod, method, "OVERRIDE_DISPATCH");
                }

                foreach (var @interface in type.AllInterfaces)
                {
                    foreach (var member in @interface.GetMembers())
                    {
                        var implementation = type.FindImplementationForInterfaceMember(member);
                        switch (member, implementation)
                        {
                            case (IMethodSymbol interfaceMethod, IMethodSymbol implementationMethod):
                                AddDispatchCall(project, interfaceMethod, implementationMethod, "INTERFACE_DISPATCH");
                                break;
                            case (IPropertySymbol interfaceProperty, IPropertySymbol implementationProperty):
                                AddDispatchCall(
                                    project,
                                    interfaceProperty.GetMethod,
                                    implementationProperty.GetMethod,
                                    "INTERFACE_DISPATCH");
                                AddDispatchCall(
                                    project,
                                    interfaceProperty.SetMethod,
                                    implementationProperty.SetMethod,
                                    "INTERFACE_DISPATCH");
                                break;
                        }
                    }
                }
            }
        }
    }

    private void AddDispatchCall(
        Project fallbackProject,
        IMethodSymbol? from,
        IMethodSymbol? to,
        string resolutionKind)
    {
        var callerId = EnsureSymbol(from, fallbackProject);
        var calledId = EnsureSymbol(to, fallbackProject);
        if (callerId == null || calledId == null || callerId == calledId)
            return;

        var evidenceLocation = to?.Locations.FirstOrDefault(location => location.IsInSource);
        Guid? fileId = null;
        int? line = null;
        int? column = null;

        if (evidenceLocation != null)
        {
            var targetProject = ResolveProject(to!, fallbackProject);
            var path = evidenceLocation.GetLineSpan().Path;
            if (targetProject != null && TryGetFile(targetProject, path, out var file))
            {
                var span = evidenceLocation.GetLineSpan();
                fileId = file.FileId;
                line = span.StartLinePosition.Line + 1;
                column = span.StartLinePosition.Character + 1;
            }
        }

        AddFunctionCall(callerId.Value, calledId.Value, fileId, line, column, resolutionKind);
    }

    private void AddFunctionCall(
        Project project,
        IMethodSymbol? caller,
        IMethodSymbol? called,
        SyntaxNode evidence,
        string resolutionKind)
    {
        var callerId = EnsureSymbol(caller, project);
        var calledId = EnsureSymbol(called, project);
        var location = GetEvidence(project, evidence);
        if (callerId == null || calledId == null || location == null)
            return;

        AddFunctionCall(
            callerId.Value,
            calledId.Value,
            location.Value.FileId,
            location.Value.Line,
            location.Value.Column,
            resolutionKind);
    }

    private void AddFunctionCall(
        Guid callerId,
        Guid calledId,
        Guid? fileId,
        int? line,
        int? column,
        string resolutionKind)
    {
        var identity = $"{callerId:N}|{calledId:N}|{fileId:N}|{line}|{column}|{resolutionKind}";
        var row = new FunctionCallRow(
            _model.CreateId("function-call", identity),
            _model.BuildId,
            callerId,
            calledId,
            fileId,
            line,
            column,
            resolutionKind);

        _model.FunctionCalls.TryAdd(row.FunctionCallId, row);
    }

    private Guid? EnsureSymbol(ISymbol? sourceSymbol, Project fallbackProject)
    {
        if (sourceSymbol == null)
            return null;

        var symbol = NormalizeSymbol(sourceSymbol);
        if (!IsSupportedSymbol(symbol))
            return null;

        var project = ResolveProject(symbol, fallbackProject);
        if (project == null || !_projectRows.TryGetValue(project.Id, out var projectRow))
            return null;

        var sourceLocations = symbol.Locations.Where(location => location.IsInSource).ToArray();
        if (sourceLocations.Length == 0 || !sourceLocations.Any(location => IsIndexedPath(location.GetLineSpan().Path)))
            return null;

        var symbolKey = GetSymbolKey(symbol);
        var symbolId = _model.CreateId("symbol", $"{projectRow.ProjectId:N}|{symbolKey}");
        if (_model.Symbols.ContainsKey(symbolId))
            return symbolId;

        Guid? containingSymbolId = null;
        if (symbol.ContainingType != null && !SymbolEqualityComparer.Default.Equals(symbol, symbol.ContainingType))
            containingSymbolId = EnsureSymbol(symbol.ContainingType, project);

        _model.Symbols[symbolId] = new ReferenceSymbolRow(
            symbolId,
            _model.BuildId,
            projectRow.ProjectId,
            containingSymbolId,
            GetSymbolKind(symbol),
            symbol.Name,
            symbol.ToDisplayString(SymbolDisplayFormat.CSharpErrorMessageFormat),
            symbolKey);

        foreach (var location in sourceLocations)
        {
            if (!TryGetFile(project, location.GetLineSpan().Path, out var file))
                continue;

            var span = location.GetLineSpan();
            var identity = $"{symbolId:N}|{file.FileId:N}|{location.SourceSpan.Start}|{location.SourceSpan.Length}";
            var declaration = new ReferenceDeclarationRow(
                _model.CreateId("declaration", identity),
                _model.BuildId,
                symbolId,
                file.FileId,
                span.StartLinePosition.Line + 1,
                span.StartLinePosition.Character + 1,
                span.EndLinePosition.Line + 1,
                span.EndLinePosition.Character + 1);

            _model.Declarations.TryAdd(declaration.DeclarationId, declaration);
        }

        return symbolId;
    }

    private Project? ResolveProject(ISymbol symbol, Project fallbackProject)
    {
        var assemblyName = symbol.ContainingAssembly?.Name;
        var sourcePaths = symbol.Locations
            .Where(location => location.IsInSource)
            .Select(location => location.GetLineSpan().Path)
            .Where(path => !string.IsNullOrWhiteSpace(path))
            .Select(Path.GetFullPath)
            .ToArray();

        if (!string.IsNullOrWhiteSpace(assemblyName) &&
            _projectsByAssembly.TryGetValue(assemblyName, out var assemblyProjects))
        {
            var exact = assemblyProjects.FirstOrDefault(project =>
                sourcePaths.Any(path => ProjectContainsFile(project, path)));
            if (exact != null)
                return exact;

            if (assemblyProjects.Count == 1)
                return assemblyProjects[0];
        }

        foreach (var path in sourcePaths)
        {
            if (_projectsByFile.TryGetValue(path, out var fileProjects))
                return fileProjects.FirstOrDefault(project => _indexedProjectIds.Contains(project.Id));
        }

        return _indexedProjectIds.Contains(fallbackProject.Id) ? fallbackProject : null;
    }

    private (Guid FileId, int Line, int Column)? GetEvidence(Project project, SyntaxNode evidence)
    {
        var path = evidence.SyntaxTree.FilePath;
        if (!TryGetFile(project, path, out var file))
            return null;

        var span = evidence.GetLocation().GetLineSpan();
        return (file.FileId, span.StartLinePosition.Line + 1, span.StartLinePosition.Character + 1);
    }

    private bool TryGetFile(Project project, string? path, out ReferenceFileRow file)
    {
        if (!string.IsNullOrWhiteSpace(path))
        {
            var fullPath = Path.GetFullPath(path);
            if (_filesByProjectAndPath.TryGetValue(GetFileKey(project.Id, fullPath), out file!))
                return true;

            if (_projectsByFile.TryGetValue(fullPath, out var projects))
            {
                foreach (var candidateProject in projects)
                {
                    if (_filesByProjectAndPath.TryGetValue(
                            GetFileKey(candidateProject.Id, fullPath),
                            out file!))
                        return true;
                }
            }
        }

        file = null!;
        return false;
    }

    private bool IsIndexedPath(string? path)
        => !string.IsNullOrWhiteSpace(path) && _projectsByFile.ContainsKey(Path.GetFullPath(path));

    private bool ProjectContainsFile(Project project, string path)
        => _filesByProjectAndPath.ContainsKey(GetFileKey(project.Id, path));

    private string? ToRelativePath(string? path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return null;

        var fullPath = Path.GetFullPath(path);
        return Path.GetRelativePath(_sourceRoot, fullPath).Replace('\\', '/');
    }

    private static string GetFileKey(ProjectId projectId, string path)
        => $"{projectId.Id:N}|{Path.GetFullPath(path)}";

    private static async Task<string> CalculateFileHashAsync(string path)
    {
        if (!File.Exists(path))
            return string.Empty;

        await using var stream = File.OpenRead(path);
        var hash = await SHA256.HashDataAsync(stream);
        return Convert.ToHexString(hash);
    }

    private static IEnumerable<INamedTypeSymbol> GetAllTypes(INamespaceSymbol @namespace)
    {
        foreach (var member in @namespace.GetMembers())
        {
            if (member is INamespaceSymbol nestedNamespace)
            {
                foreach (var nestedType in GetAllTypes(nestedNamespace))
                    yield return nestedType;
            }
            else if (member is INamedTypeSymbol type)
            {
                foreach (var nestedType in GetTypeAndNestedTypes(type))
                    yield return nestedType;
            }
        }
    }

    private static IEnumerable<INamedTypeSymbol> GetTypeAndNestedTypes(INamedTypeSymbol type)
    {
        yield return type;
        foreach (var nestedType in type.GetTypeMembers())
        {
            foreach (var item in GetTypeAndNestedTypes(nestedType))
                yield return item;
        }
    }

    private static IEnumerable<SyntaxNode> GetPotentialFieldReferences(SyntaxNode root)
    {
        foreach (var node in root.DescendantNodes())
        {
            switch (node)
            {
                case MemberAccessExpressionSyntax:
                case MemberBindingExpressionSyntax:
                case ElementAccessExpressionSyntax:
                    yield return node;
                    break;
                case IdentifierNameSyntax identifier
                    when identifier.Parent is not MemberAccessExpressionSyntax { Name: var name } || name != identifier:
                    if (identifier.Parent is not MemberBindingExpressionSyntax { Name: var bindingName } ||
                        bindingName != identifier)
                        yield return identifier;
                    break;
            }
        }
    }

    private static string ClassifyFieldAccess(SyntaxNode reference)
    {
        var current = UnwrapParentheses(reference);
        if (current.Parent is AssignmentExpressionSyntax assignment && assignment.Left == current)
        {
            return assignment.Kind() == SyntaxKind.SimpleAssignmentExpression
                ? "WRITE"
                : "READ_WRITE";
        }

        if (current.Parent is PrefixUnaryExpressionSyntax prefix &&
            prefix.IsKind(SyntaxKind.PreIncrementExpression) ||
            current.Parent is PrefixUnaryExpressionSyntax prefixDecrement &&
            prefixDecrement.IsKind(SyntaxKind.PreDecrementExpression) ||
            current.Parent is PostfixUnaryExpressionSyntax postfix &&
            postfix.IsKind(SyntaxKind.PostIncrementExpression) ||
            current.Parent is PostfixUnaryExpressionSyntax postfixDecrement &&
            postfixDecrement.IsKind(SyntaxKind.PostDecrementExpression))
        {
            return "READ_WRITE";
        }

        if (current.Parent is ArgumentSyntax argument && argument.Expression == current)
        {
            return argument.RefKindKeyword.Kind() switch
            {
                SyntaxKind.OutKeyword => "WRITE",
                SyntaxKind.RefKeyword => "READ_WRITE",
                _ => "READ"
            };
        }

        return "READ";
    }

    private static SyntaxNode UnwrapParentheses(SyntaxNode node)
    {
        var current = node;
        while (current.Parent is ParenthesizedExpressionSyntax parenthesized)
            current = parenthesized;
        return current;
    }

    private static bool IsInsideNameOf(SyntaxNode node)
    {
        return node.AncestorsAndSelf()
            .OfType<InvocationExpressionSyntax>()
            .Any(invocation => invocation.Expression is IdentifierNameSyntax identifier &&
                               identifier.Identifier.ValueText == "nameof");
    }

    private static IMethodSymbol? GetContainingFunction(SemanticModel semanticModel, int position)
        => semanticModel.GetEnclosingSymbol(position) as IMethodSymbol;

    private static ISymbol? ResolveSymbol(SymbolInfo symbolInfo)
        => symbolInfo.Symbol ?? symbolInfo.CandidateSymbols.FirstOrDefault();

    private static IMethodSymbol? ResolveMethod(SymbolInfo symbolInfo)
        => ResolveSymbol(symbolInfo) as IMethodSymbol;

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

    private static bool IsSupportedSymbol(ISymbol symbol)
        => symbol is INamedTypeSymbol or IFieldSymbol or IPropertySymbol or IMethodSymbol;

    private static bool IsIndexableMethod(IMethodSymbol method)
    {
        if (!method.Locations.Any(location => location.IsInSource))
            return false;

        return method.MethodKind is
            MethodKind.Ordinary or
            MethodKind.Constructor or
            MethodKind.StaticConstructor or
            MethodKind.Destructor or
            MethodKind.UserDefinedOperator or
            MethodKind.Conversion or
            MethodKind.PropertyGet or
            MethodKind.PropertySet or
            MethodKind.LocalFunction or
            MethodKind.AnonymousFunction;
    }

    private static string GetSymbolKind(ISymbol symbol)
    {
        return symbol switch
        {
            INamedTypeSymbol { TypeKind: TypeKind.Class } => "CLASS",
            INamedTypeSymbol { TypeKind: TypeKind.Interface } => "INTERFACE",
            INamedTypeSymbol { TypeKind: TypeKind.Struct } => "STRUCT",
            INamedTypeSymbol { TypeKind: TypeKind.Enum } => "ENUM",
            INamedTypeSymbol { TypeKind: TypeKind.Delegate } => "DELEGATE",
            IFieldSymbol => "FIELD",
            IPropertySymbol => "PROPERTY",
            IMethodSymbol { MethodKind: MethodKind.Constructor or MethodKind.StaticConstructor } => "CONSTRUCTOR",
            IMethodSymbol { MethodKind: MethodKind.PropertyGet or MethodKind.PropertySet } => "ACCESSOR",
            IMethodSymbol { MethodKind: MethodKind.LocalFunction } => "LOCAL_FUNCTION",
            IMethodSymbol { MethodKind: MethodKind.AnonymousFunction } => "LAMBDA",
            IMethodSymbol => "METHOD",
            _ => symbol.Kind.ToString().ToUpperInvariant()
        };
    }

    private static string GetSymbolKey(ISymbol symbol)
    {
        var assembly = symbol.ContainingAssembly?.Name ?? "source";
        var documentationId = symbol.GetDocumentationCommentId();
        if (!string.IsNullOrWhiteSpace(documentationId))
            return $"{assembly}|{documentationId}";

        var location = symbol.Locations.FirstOrDefault(item => item.IsInSource);
        var locationKey = location == null
            ? "no-source-location"
            : $"{location.GetLineSpan().Path}|{location.SourceSpan.Start}|{location.SourceSpan.Length}";
        return $"{assembly}|{symbol.Kind}|{symbol.ToDisplayString(SymbolDisplayFormat.CSharpErrorMessageFormat)}|{locationKey}";
    }
}
