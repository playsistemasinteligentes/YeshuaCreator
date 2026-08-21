using Dapper;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Configuration;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Database;
using System.IO.Compression;
using System.Text;

namespace Yeshua.OperationalIntelligence.Api.Repositories;

public sealed class SourceContextRepository : ISourceContextRepository
{
    private readonly OperationalIntelligenceDatabase _database;
    private readonly OperationalIntelligenceOptions _options;

    public SourceContextRepository(
        OperationalIntelligenceDatabase database,
        IOptions<OperationalIntelligenceOptions> options)
    {
        _database = database;
        _options = options.Value;
    }

    public async Task<IReadOnlyList<ApplicationSummary>> GetApplicationsAsync(
        CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT a.ApplicationId, a.Name, COUNT(b.BuildId) AS BuildCount
            FROM OI_Applications a
            LEFT JOIN OI_Builds b ON b.ApplicationId = a.ApplicationId
            GROUP BY a.ApplicationId, a.Name
            ORDER BY a.Name;
            """;

        await using var connection = await _database.OpenConnectionAsync(cancellationToken);
        var rows = await connection.QueryAsync<ApplicationSummary>(Command(sql, cancellationToken));
        return rows.AsList();
    }

    public async Task<IReadOnlyList<BuildSummary>> GetBuildsAsync(
        string application,
        CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT b.BuildId, a.Name AS Application, b.Version, b.CommitSha,
                   b.SourceSolution, b.GeneratedAtUtc
            FROM OI_Builds b
            JOIN OI_Applications a ON a.ApplicationId = b.ApplicationId
            WHERE a.Name = @Application
            ORDER BY b.GeneratedAtUtc DESC;
            """;

        await using var connection = await _database.OpenConnectionAsync(cancellationToken);
        var rows = await connection.QueryAsync<BuildSummary>(
            Command(sql, new { Application = application }, cancellationToken));
        return rows.AsList();
    }

    public async Task<SourceContextResponse> SearchFieldAsync(
        FieldSearchRequest request,
        CancellationToken cancellationToken)
    {
        var build = await ResolveBuildAsync(request.Application, request.Version, cancellationToken);
        var maxDepth = NormalizeMaxDepth(request.MaxDepth);
        var maxResults = NormalizeMaxResults(request.MaxResults);

        await using var connection = await _database.OpenConnectionAsync(cancellationToken);
        using var result = await connection.QueryMultipleAsync(Command(
            FieldSql,
            new
            {
                build.BuildId,
                FieldSearch = request.Field,
                request.IncludeSameName,
                MaxDepth = maxDepth,
                MaxResults = maxResults
            },
            cancellationToken));

        var matches = (await result.ReadAsync<SymbolMatch>()).AsList();
        var references = (await result.ReadAsync<ReferenceEvidence>()).AsList();
        var chains = (await result.ReadAsync<FunctionChain>()).AsList();
        var files = (await result.ReadAsync<SourceFileCandidate>()).AsList();
        return Response(build, matches, references, chains, files);
    }

    public async Task<SourceContextResponse> SearchClassAsync(
        ClassSearchRequest request,
        CancellationToken cancellationToken)
    {
        var build = await ResolveBuildAsync(request.Application, request.Version, cancellationToken);
        var maxDepth = NormalizeMaxDepth(request.MaxDepth);
        var maxResults = NormalizeMaxResults(request.MaxResults);

        await using var connection = await _database.OpenConnectionAsync(cancellationToken);
        using var result = await connection.QueryMultipleAsync(Command(
            ClassSql,
            new
            {
                build.BuildId,
                ClassSearch = request.Class,
                request.IncludeSameName,
                MaxDepth = maxDepth,
                MaxResults = maxResults
            },
            cancellationToken));

        var matches = (await result.ReadAsync<SymbolMatch>()).AsList();
        var references = (await result.ReadAsync<ReferenceEvidence>()).AsList();
        var chains = (await result.ReadAsync<FunctionChain>()).AsList();
        var files = (await result.ReadAsync<SourceFileCandidate>()).AsList();
        return Response(build, matches, references, chains, files);
    }

    public async Task<SourceContextResponse> SearchFunctionAsync(
        FunctionSearchRequest request,
        CancellationToken cancellationToken)
    {
        var build = await ResolveBuildAsync(request.Application, request.Version, cancellationToken);
        var maxDepth = NormalizeMaxDepth(request.MaxDepth);
        var maxResults = NormalizeMaxResults(request.MaxResults);

        await using var connection = await _database.OpenConnectionAsync(cancellationToken);
        using var result = await connection.QueryMultipleAsync(Command(
            FunctionSql,
            new
            {
                build.BuildId,
                FunctionSearch = request.Function,
                FilePath = request.File,
                request.Line,
                MaxDepth = maxDepth,
                MaxResults = maxResults
            },
            cancellationToken));

        var matches = (await result.ReadAsync<SymbolMatch>()).AsList();
        var references = (await result.ReadAsync<ReferenceEvidence>()).AsList();
        var chains = (await result.ReadAsync<FunctionChain>()).AsList();
        var files = (await result.ReadAsync<SourceFileCandidate>()).AsList();
        return Response(build, matches, references, chains, files);
    }

    public async Task<IReadOnlyList<SourceFileContent>> GetSourceContentsAsync(
        Guid buildId,
        IReadOnlyList<string> files,
        CancellationToken cancellationToken)
    {
        if (files.Count == 0)
            return [];

        const string sql = """
            SELECT f.RelativePath AS [File], f.ArtifactKind, f.SourceRole, f.Ownership,
                   f.Editable, f.SourceOfTruth, c.Compression, c.Content
            FROM OI_Files f
            JOIN OI_SourceContents c ON c.HashSha256 = f.HashSha256
            WHERE f.BuildId = @BuildId AND f.RelativePath IN @Files;
            """;

        await using var connection = await _database.OpenConnectionAsync(cancellationToken);
        var rows = await connection.QueryAsync<SourceContentRow>(
            Command(sql, new { BuildId = buildId, Files = files }, cancellationToken));
        return rows.Select(row => new SourceFileContent(
                row.File,
                row.ArtifactKind,
                row.SourceRole,
                row.Ownership,
                row.Editable,
                row.SourceOfTruth,
                Decompress(row.Content, row.Compression)))
            .ToArray();
    }

    public async Task<IReadOnlyList<SourceFileHistory>> GetFileHistoryAsync(
        Guid buildId,
        IReadOnlyList<string> files,
        CancellationToken cancellationToken)
    {
        if (files.Count == 0)
            return [];

        const string sql = """
            WITH RankedHistory AS
            (
                SELECT COALESCE(c.NewPath, c.OldPath) AS [File], gc.CommitSha,
                       gc.CommittedAtUtc, gc.AuthorName, gc.Message, c.ChangeType,
                       ROW_NUMBER() OVER
                       (
                           PARTITION BY COALESCE(c.NewPath, c.OldPath)
                           ORDER BY gc.CommittedAtUtc DESC
                       ) AS RowNumber
                FROM OI_Builds b
                JOIN OI_GitRepositories r ON r.ApplicationId = b.ApplicationId
                JOIN OI_GitCommits gc ON gc.RepositoryId = r.RepositoryId
                JOIN OI_GitFileChanges c ON c.CommitId = gc.CommitId
                WHERE b.BuildId = @BuildId
                  AND COALESCE(c.NewPath, c.OldPath) IN @Files
            )
            SELECT [File], CommitSha, CommittedAtUtc, AuthorName, Message, ChangeType
            FROM RankedHistory
            WHERE RowNumber <= 5
            ORDER BY [File], CommittedAtUtc DESC;
            """;

        await using var connection = await _database.OpenConnectionAsync(cancellationToken);
        var rows = await connection.QueryAsync<SourceFileHistory>(
            Command(sql, new { BuildId = buildId, Files = files }, cancellationToken));
        return rows.AsList();
    }

    private static string Decompress(byte[] content, string compression)
    {
        if (!string.Equals(compression, "GZIP", StringComparison.OrdinalIgnoreCase))
            return Encoding.UTF8.GetString(content);

        using var input = new MemoryStream(content);
        using var gzip = new GZipStream(input, CompressionMode.Decompress);
        using var reader = new StreamReader(gzip, Encoding.UTF8);
        return reader.ReadToEnd();
    }

    private async Task<BuildSummary> ResolveBuildAsync(
        string application,
        string? version,
        CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT TOP (1) b.BuildId, a.Name AS Application, b.Version, b.CommitSha,
                   b.SourceSolution, b.GeneratedAtUtc
            FROM OI_Builds b
            JOIN OI_Applications a ON a.ApplicationId = b.ApplicationId
            WHERE a.Name = @Application
              AND (@Version IS NULL OR b.Version = @Version)
            ORDER BY b.GeneratedAtUtc DESC;
            """;

        await using var connection = await _database.OpenConnectionAsync(cancellationToken);
        return await connection.QuerySingleOrDefaultAsync<BuildSummary>(
                   Command(sql, new { Application = application, Version = version }, cancellationToken))
               ?? throw new KeyNotFoundException(
                   $"No indexed build was found for application '{application}' and version '{version ?? "latest"}'.");
    }

    private int NormalizeMaxDepth(int? requested)
        => Math.Clamp(
            requested ?? _options.DefaultMaxDepth,
            0,
            Math.Max(1, _options.MaximumMaxDepth));

    private int NormalizeMaxResults(int? requested)
        => Math.Clamp(
            requested ?? _options.DefaultMaxResults,
            1,
            Math.Max(1, _options.MaximumMaxResults));

    private CommandDefinition Command(string sql, CancellationToken cancellationToken)
        => new(
            sql,
            commandTimeout: _database.CommandTimeoutSeconds,
            cancellationToken: cancellationToken);

    private CommandDefinition Command(string sql, object parameters, CancellationToken cancellationToken)
        => new(
            sql,
            parameters,
            commandTimeout: _database.CommandTimeoutSeconds,
            cancellationToken: cancellationToken);

    private static SourceContextResponse Response(
        BuildSummary build,
        IReadOnlyList<SymbolMatch> matches,
        IReadOnlyList<ReferenceEvidence> references,
        IReadOnlyList<FunctionChain> chains,
        IReadOnlyList<SourceFileCandidate> files)
    {
        var warnings = matches.Count == 0 && references.Count == 0
            ? new[] { "No matching source symbol was found in the selected build." }
            : Array.Empty<string>();
        return new SourceContextResponse(build, matches, references, chains, files, warnings);
    }

    private const string FieldSql = """
        DECLARE @FieldName NVARCHAR(500) = RIGHT(@FieldSearch, CHARINDEX('.', REVERSE(@FieldSearch) + '.') - 1);
        CREATE TABLE #Targets
        (
            SymbolId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
            MatchKind NVARCHAR(30) NOT NULL
        );

        INSERT INTO #Targets
        SELECT SymbolId, N'EXACT_SYMBOL'
        FROM OI_Symbols
        WHERE BuildId = @BuildId
          AND Kind IN (N'FIELD', N'PROPERTY')
          AND QualifiedName = @FieldSearch;

        IF @IncludeSameName = 1
        BEGIN
            INSERT INTO #Targets
            SELECT s.SymbolId, N'SAME_NAME_CANDIDATE'
            FROM OI_Symbols s
            WHERE s.BuildId = @BuildId
              AND s.Kind IN (N'FIELD', N'PROPERTY')
              AND s.Name = @FieldName
              AND NOT EXISTS (SELECT 1 FROM #Targets t WHERE t.SymbolId = s.SymbolId);
        END;

        SELECT TOP (@MaxResults) s.SymbolId, t.MatchKind, s.Kind AS SymbolKind,
               s.QualifiedName, f.RelativePath AS [File], d.StartLine, d.EndLine
        FROM #Targets t
        JOIN OI_Symbols s ON s.SymbolId = t.SymbolId
        LEFT JOIN OI_Declarations d ON d.BuildId = @BuildId AND d.SymbolId = s.SymbolId
        LEFT JOIN OI_Files f ON f.FileId = d.FileId
        ORDER BY t.MatchKind, s.QualifiedName, f.RelativePath, d.StartLine;

        SELECT TOP (@MaxResults) evidence.Kind, evidence.Symbol, evidence.AccessKind,
               evidence.ContainingFunction, evidence.[File], evidence.Line, evidence.[Column]
        FROM
        (
            SELECT N'FIELD_REFERENCE' AS Kind, s.QualifiedName AS Symbol,
                   r.AccessKind, owner.QualifiedName AS ContainingFunction,
                   f.RelativePath AS [File], r.Line, r.ColumnNumber AS [Column]
            FROM #Targets t
            JOIN OI_Symbols s ON s.SymbolId = t.SymbolId
            JOIN OI_FieldReferences r ON r.BuildId = @BuildId AND r.FieldSymbolId = t.SymbolId
            JOIN OI_Files f ON f.FileId = r.FileId
            LEFT JOIN OI_Symbols owner ON owner.SymbolId = r.ContainingFunctionId
            UNION ALL
            SELECT N'TEXT_REFERENCE', tr.Token, tr.ReferenceKind,
                   CAST(NULL AS NVARCHAR(MAX)), f.RelativePath, tr.Line, tr.ColumnNumber
            FROM OI_TextReferences tr
            JOIN OI_Files f ON f.FileId = tr.FileId
            WHERE tr.BuildId = @BuildId AND tr.Token = @FieldName
        ) evidence
        ORDER BY evidence.[File], evidence.Line;

        CREATE TABLE #Chains
        (
            ReferenceId UNIQUEIDENTIFIER NOT NULL,
            FunctionId UNIQUEIDENTIFIER NOT NULL,
            Depth INT NOT NULL,
            FunctionPath NVARCHAR(MAX) NOT NULL,
            VisitedIds VARCHAR(MAX) NOT NULL
        );

        ;WITH CallerChain AS
        (
            SELECT r.FieldReferenceId AS ReferenceId, r.ContainingFunctionId AS FunctionId, 0 AS Depth,
                   CAST(fn.QualifiedName AS NVARCHAR(MAX)) AS FunctionPath,
                   CAST('|' + CONVERT(VARCHAR(36), r.ContainingFunctionId) + '|' AS VARCHAR(MAX)) AS VisitedIds
            FROM OI_FieldReferences r
            JOIN #Targets t ON t.SymbolId = r.FieldSymbolId
            JOIN OI_Symbols fn ON fn.SymbolId = r.ContainingFunctionId
            WHERE r.BuildId = @BuildId AND r.ContainingFunctionId IS NOT NULL

            UNION ALL

            SELECT c.ReferenceId, fc.CallerFunctionId, c.Depth + 1,
                   CAST(caller.QualifiedName + N' -> ' + c.FunctionPath AS NVARCHAR(MAX)),
                   CAST(c.VisitedIds + CONVERT(VARCHAR(36), fc.CallerFunctionId) + '|' AS VARCHAR(MAX))
            FROM CallerChain c
            JOIN OI_FunctionCalls fc ON fc.BuildId = @BuildId AND fc.CalledFunctionId = c.FunctionId
            JOIN OI_Symbols caller ON caller.SymbolId = fc.CallerFunctionId
            WHERE c.Depth < @MaxDepth
              AND CHARINDEX('|' + CONVERT(VARCHAR(36), fc.CallerFunctionId) + '|', c.VisitedIds) = 0
        )
        INSERT INTO #Chains
        SELECT ReferenceId, FunctionId, Depth, FunctionPath, VisitedIds FROM CallerChain
        OPTION (MAXRECURSION 32767);

        SELECT TOP (@MaxResults) N'UPSTREAM' AS Direction, c.Depth, c.FunctionPath AS [Path],
               f.RelativePath AS ReferenceFile, r.Line AS ReferenceLine,
               CONVERT(BIT, CASE WHEN NOT EXISTS
               (
                   SELECT 1 FROM OI_FunctionCalls parent
                   WHERE parent.BuildId = @BuildId AND parent.CalledFunctionId = c.FunctionId
               ) THEN 1 ELSE 0 END) AS IsRoot
        FROM #Chains c
        JOIN OI_FieldReferences r ON r.FieldReferenceId = c.ReferenceId
        JOIN OI_Files f ON f.FileId = r.FileId
        ORDER BY f.RelativePath, r.Line, c.Depth DESC, c.FunctionPath;

        ;WITH RelevantFiles AS
        (
            SELECT d.FileId, N'FIELD_DECLARATION' AS Reason
            FROM #Targets t JOIN OI_Declarations d ON d.SymbolId = t.SymbolId AND d.BuildId = @BuildId
            UNION
            SELECT r.FileId, N'FIELD_REFERENCE'
            FROM #Targets t JOIN OI_FieldReferences r ON r.FieldSymbolId = t.SymbolId AND r.BuildId = @BuildId
            UNION
            SELECT d.FileId, N'CALLER_CHAIN'
            FROM #Chains c JOIN OI_Declarations d ON d.SymbolId = c.FunctionId AND d.BuildId = @BuildId
            UNION
            SELECT tr.FileId, N'TEXT_REFERENCE'
            FROM OI_TextReferences tr
            WHERE tr.BuildId = @BuildId AND tr.Token = @FieldName
        )
        SELECT TOP (@MaxResults) f.RelativePath AS [File], rf.Reason,
               f.ArtifactKind, f.SourceRole, f.Ownership, f.Editable, f.SourceOfTruth
        FROM RelevantFiles rf JOIN OI_Files f ON f.FileId = rf.FileId
        ORDER BY f.RelativePath, rf.Reason;
        """;

    private const string ClassSql = """
        DECLARE @ClassName NVARCHAR(500) = RIGHT(@ClassSearch, CHARINDEX('.', REVERSE(@ClassSearch) + '.') - 1);
        CREATE TABLE #Targets
        (
            SymbolId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
            MatchKind NVARCHAR(30) NOT NULL
        );

        INSERT INTO #Targets
        SELECT SymbolId, N'EXACT_SYMBOL'
        FROM OI_Symbols
        WHERE BuildId = @BuildId AND Kind = N'CLASS' AND QualifiedName = @ClassSearch;

        IF @IncludeSameName = 1
        BEGIN
            INSERT INTO #Targets
            SELECT s.SymbolId, N'SAME_NAME_CANDIDATE'
            FROM OI_Symbols s
            WHERE s.BuildId = @BuildId AND s.Kind = N'CLASS' AND s.Name = @ClassName
              AND NOT EXISTS (SELECT 1 FROM #Targets t WHERE t.SymbolId = s.SymbolId);
        END;

        SELECT TOP (@MaxResults) s.SymbolId, t.MatchKind, s.Kind AS SymbolKind,
               s.QualifiedName, f.RelativePath AS [File], d.StartLine, d.EndLine
        FROM #Targets t
        JOIN OI_Symbols s ON s.SymbolId = t.SymbolId
        LEFT JOIN OI_Declarations d ON d.BuildId = @BuildId AND d.SymbolId = s.SymbolId
        LEFT JOIN OI_Files f ON f.FileId = d.FileId
        ORDER BY t.MatchKind, s.QualifiedName, f.RelativePath, d.StartLine;

        SELECT TOP (@MaxResults) evidence.Kind, evidence.Symbol, evidence.AccessKind,
               evidence.ContainingFunction, evidence.[File], evidence.Line, evidence.[Column]
        FROM
        (
            SELECT N'CLASS_INSTANTIATION' AS Kind, s.QualifiedName AS Symbol,
                   CAST(NULL AS NVARCHAR(50)) AS AccessKind, owner.QualifiedName AS ContainingFunction,
                   f.RelativePath AS [File], i.Line, i.ColumnNumber AS [Column]
            FROM #Targets t
            JOIN OI_Symbols s ON s.SymbolId = t.SymbolId
            JOIN OI_ClassInstantiations i ON i.BuildId = @BuildId AND i.ClassSymbolId = t.SymbolId
            JOIN OI_Files f ON f.FileId = i.FileId
            LEFT JOIN OI_Symbols owner ON owner.SymbolId = i.ContainingFunctionId
            UNION ALL
            SELECT N'TEXT_REFERENCE', tr.Token, tr.ReferenceKind,
                   CAST(NULL AS NVARCHAR(MAX)), f.RelativePath, tr.Line, tr.ColumnNumber
            FROM OI_TextReferences tr
            JOIN OI_Files f ON f.FileId = tr.FileId
            WHERE tr.BuildId = @BuildId AND tr.Token = @ClassName
        ) evidence
        ORDER BY evidence.[File], evidence.Line;

        CREATE TABLE #Chains
        (
            ReferenceId UNIQUEIDENTIFIER NOT NULL,
            FunctionId UNIQUEIDENTIFIER NOT NULL,
            Depth INT NOT NULL,
            FunctionPath NVARCHAR(MAX) NOT NULL,
            VisitedIds VARCHAR(MAX) NOT NULL
        );

        ;WITH CallerChain AS
        (
            SELECT i.InstantiationId AS ReferenceId, i.ContainingFunctionId AS FunctionId, 0 AS Depth,
                   CAST(fn.QualifiedName AS NVARCHAR(MAX)) AS FunctionPath,
                   CAST('|' + CONVERT(VARCHAR(36), i.ContainingFunctionId) + '|' AS VARCHAR(MAX)) AS VisitedIds
            FROM OI_ClassInstantiations i
            JOIN #Targets t ON t.SymbolId = i.ClassSymbolId
            JOIN OI_Symbols fn ON fn.SymbolId = i.ContainingFunctionId
            WHERE i.BuildId = @BuildId AND i.ContainingFunctionId IS NOT NULL

            UNION ALL

            SELECT c.ReferenceId, fc.CallerFunctionId, c.Depth + 1,
                   CAST(caller.QualifiedName + N' -> ' + c.FunctionPath AS NVARCHAR(MAX)),
                   CAST(c.VisitedIds + CONVERT(VARCHAR(36), fc.CallerFunctionId) + '|' AS VARCHAR(MAX))
            FROM CallerChain c
            JOIN OI_FunctionCalls fc ON fc.BuildId = @BuildId AND fc.CalledFunctionId = c.FunctionId
            JOIN OI_Symbols caller ON caller.SymbolId = fc.CallerFunctionId
            WHERE c.Depth < @MaxDepth
              AND CHARINDEX('|' + CONVERT(VARCHAR(36), fc.CallerFunctionId) + '|', c.VisitedIds) = 0
        )
        INSERT INTO #Chains
        SELECT ReferenceId, FunctionId, Depth, FunctionPath, VisitedIds FROM CallerChain
        OPTION (MAXRECURSION 32767);

        SELECT TOP (@MaxResults) N'UPSTREAM' AS Direction, c.Depth, c.FunctionPath AS [Path],
               f.RelativePath AS ReferenceFile, i.Line AS ReferenceLine,
               CONVERT(BIT, CASE WHEN NOT EXISTS
               (
                   SELECT 1 FROM OI_FunctionCalls parent
                   WHERE parent.BuildId = @BuildId AND parent.CalledFunctionId = c.FunctionId
               ) THEN 1 ELSE 0 END) AS IsRoot
        FROM #Chains c
        JOIN OI_ClassInstantiations i ON i.InstantiationId = c.ReferenceId
        JOIN OI_Files f ON f.FileId = i.FileId
        ORDER BY f.RelativePath, i.Line, c.Depth DESC, c.FunctionPath;

        ;WITH RelevantFiles AS
        (
            SELECT d.FileId, N'CLASS_DECLARATION' AS Reason
            FROM #Targets t JOIN OI_Declarations d ON d.SymbolId = t.SymbolId AND d.BuildId = @BuildId
            UNION
            SELECT i.FileId, N'CLASS_INSTANTIATION'
            FROM #Targets t JOIN OI_ClassInstantiations i ON i.ClassSymbolId = t.SymbolId AND i.BuildId = @BuildId
            UNION
            SELECT d.FileId, N'CALLER_CHAIN'
            FROM #Chains c JOIN OI_Declarations d ON d.SymbolId = c.FunctionId AND d.BuildId = @BuildId
            UNION
            SELECT tr.FileId, N'TEXT_REFERENCE'
            FROM OI_TextReferences tr
            WHERE tr.BuildId = @BuildId AND tr.Token = @ClassName
        )
        SELECT TOP (@MaxResults) f.RelativePath AS [File], rf.Reason,
               f.ArtifactKind, f.SourceRole, f.Ownership, f.Editable, f.SourceOfTruth
        FROM RelevantFiles rf JOIN OI_Files f ON f.FileId = rf.FileId
        ORDER BY f.RelativePath, rf.Reason;
        """;

    private const string FunctionSql = """
        DECLARE @FunctionName NVARCHAR(500) = RIGHT(@FunctionSearch, CHARINDEX('.', REVERSE(@FunctionSearch) + '.') - 1);
        CREATE TABLE #Targets
        (
            SymbolId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
            MatchKind NVARCHAR(30) NOT NULL
        );

        INSERT INTO #Targets
        SELECT DISTINCT s.SymbolId,
               CASE WHEN s.QualifiedName = @FunctionSearch THEN N'EXACT_SYMBOL' ELSE N'NAME_MATCH' END
        FROM OI_Symbols s
        LEFT JOIN OI_Declarations d ON d.BuildId = @BuildId AND d.SymbolId = s.SymbolId
        LEFT JOIN OI_Files f ON f.FileId = d.FileId
        WHERE s.BuildId = @BuildId
          AND s.Kind IN (N'METHOD', N'CONSTRUCTOR', N'ACCESSOR', N'LOCAL_FUNCTION', N'LAMBDA')
          AND (s.QualifiedName = @FunctionSearch OR s.Name = @FunctionName)
          AND (@FilePath IS NULL OR REPLACE(f.RelativePath, '\', '/') LIKE N'%' + REPLACE(@FilePath, '\', '/') + N'%')
          AND (@Line IS NULL OR @Line BETWEEN d.StartLine AND d.EndLine);

        SELECT TOP (@MaxResults) s.SymbolId, t.MatchKind, s.Kind AS SymbolKind,
               s.QualifiedName, f.RelativePath AS [File], d.StartLine, d.EndLine
        FROM #Targets t
        JOIN OI_Symbols s ON s.SymbolId = t.SymbolId
        LEFT JOIN OI_Declarations d ON d.BuildId = @BuildId AND d.SymbolId = s.SymbolId
        LEFT JOIN OI_Files f ON f.FileId = d.FileId
        ORDER BY t.MatchKind, s.QualifiedName, f.RelativePath, d.StartLine;

        SELECT TOP (@MaxResults) evidence.Kind, evidence.Symbol, evidence.AccessKind,
               evidence.ContainingFunction, evidence.[File], evidence.Line, evidence.[Column]
        FROM
        (
            SELECT N'FUNCTION_DECLARATION' AS Kind, s.QualifiedName AS Symbol,
                   CAST(NULL AS NVARCHAR(50)) AS AccessKind, s.QualifiedName AS ContainingFunction,
                   f.RelativePath AS [File], d.StartLine AS Line, d.StartColumn AS [Column]
            FROM #Targets t
            JOIN OI_Symbols s ON s.SymbolId = t.SymbolId
            JOIN OI_Declarations d ON d.BuildId = @BuildId AND d.SymbolId = t.SymbolId
            JOIN OI_Files f ON f.FileId = d.FileId
            UNION ALL
            SELECT N'TEXT_REFERENCE', tr.Token, tr.ReferenceKind,
                   CAST(NULL AS NVARCHAR(MAX)), f.RelativePath, tr.Line, tr.ColumnNumber
            FROM OI_TextReferences tr
            JOIN OI_Files f ON f.FileId = tr.FileId
            WHERE tr.BuildId = @BuildId AND tr.Token = @FunctionName
        ) evidence
        ORDER BY evidence.[File], evidence.Line;

        CREATE TABLE #Closure
        (
            Direction NVARCHAR(20) NOT NULL,
            FunctionId UNIQUEIDENTIFIER NOT NULL,
            Depth INT NOT NULL,
            FunctionPath NVARCHAR(MAX) NOT NULL,
            VisitedIds VARCHAR(MAX) NOT NULL
        );

        ;WITH Upstream AS
        (
            SELECT t.SymbolId AS FunctionId, 0 AS Depth,
                   CAST(s.QualifiedName AS NVARCHAR(MAX)) AS FunctionPath,
                   CAST('|' + CONVERT(VARCHAR(36), t.SymbolId) + '|' AS VARCHAR(MAX)) AS VisitedIds
            FROM #Targets t JOIN OI_Symbols s ON s.SymbolId = t.SymbolId
            UNION ALL
            SELECT fc.CallerFunctionId, u.Depth + 1,
                   CAST(caller.QualifiedName + N' -> ' + u.FunctionPath AS NVARCHAR(MAX)),
                   CAST(u.VisitedIds + CONVERT(VARCHAR(36), fc.CallerFunctionId) + '|' AS VARCHAR(MAX))
            FROM Upstream u
            JOIN OI_FunctionCalls fc ON fc.BuildId = @BuildId AND fc.CalledFunctionId = u.FunctionId
            JOIN OI_Symbols caller ON caller.SymbolId = fc.CallerFunctionId
            WHERE u.Depth < @MaxDepth
              AND CHARINDEX('|' + CONVERT(VARCHAR(36), fc.CallerFunctionId) + '|', u.VisitedIds) = 0
        )
        INSERT INTO #Closure
        SELECT N'UPSTREAM', FunctionId, Depth, FunctionPath, VisitedIds FROM Upstream
        OPTION (MAXRECURSION 32767);

        ;WITH Downstream AS
        (
            SELECT t.SymbolId AS FunctionId, 0 AS Depth,
                   CAST(s.QualifiedName AS NVARCHAR(MAX)) AS FunctionPath,
                   CAST('|' + CONVERT(VARCHAR(36), t.SymbolId) + '|' AS VARCHAR(MAX)) AS VisitedIds
            FROM #Targets t JOIN OI_Symbols s ON s.SymbolId = t.SymbolId
            UNION ALL
            SELECT fc.CalledFunctionId, d.Depth + 1,
                   CAST(d.FunctionPath + N' -> ' + called.QualifiedName AS NVARCHAR(MAX)),
                   CAST(d.VisitedIds + CONVERT(VARCHAR(36), fc.CalledFunctionId) + '|' AS VARCHAR(MAX))
            FROM Downstream d
            JOIN OI_FunctionCalls fc ON fc.BuildId = @BuildId AND fc.CallerFunctionId = d.FunctionId
            JOIN OI_Symbols called ON called.SymbolId = fc.CalledFunctionId
            WHERE d.Depth < @MaxDepth
              AND CHARINDEX('|' + CONVERT(VARCHAR(36), fc.CalledFunctionId) + '|', d.VisitedIds) = 0
        )
        INSERT INTO #Closure
        SELECT N'DOWNSTREAM', FunctionId, Depth, FunctionPath, VisitedIds FROM Downstream
        OPTION (MAXRECURSION 32767);

        SELECT TOP (@MaxResults) c.Direction, c.Depth, c.FunctionPath AS [Path],
               CAST(NULL AS NVARCHAR(2000)) AS ReferenceFile,
               CAST(NULL AS INT) AS ReferenceLine,
               CONVERT(BIT, CASE WHEN c.Direction = N'UPSTREAM' AND NOT EXISTS
               (
                   SELECT 1 FROM OI_FunctionCalls parent
                   WHERE parent.BuildId = @BuildId AND parent.CalledFunctionId = c.FunctionId
               ) THEN 1 ELSE 0 END) AS IsRoot
        FROM #Closure c
        ORDER BY c.Direction, c.Depth, c.FunctionPath;

        ;WITH RelevantFiles AS
        (
            SELECT d.FileId,
                   CASE c.Direction WHEN N'UPSTREAM' THEN N'UPSTREAM_CALL_CHAIN' ELSE N'DOWNSTREAM_CALL_CHAIN' END AS Reason
            FROM #Closure c
            JOIN OI_Declarations d ON d.BuildId = @BuildId AND d.SymbolId = c.FunctionId
            UNION
            SELECT tr.FileId, N'TEXT_REFERENCE'
            FROM OI_TextReferences tr
            WHERE tr.BuildId = @BuildId AND tr.Token = @FunctionName
        )
        SELECT TOP (@MaxResults) f.RelativePath AS [File], rf.Reason,
               f.ArtifactKind, f.SourceRole, f.Ownership, f.Editable, f.SourceOfTruth
        FROM RelevantFiles rf
        JOIN OI_Files f ON f.FileId = rf.FileId
        ORDER BY f.RelativePath, Reason;
        """;

    private sealed class SourceContentRow
    {
        public string File { get; init; } = string.Empty;
        public string ArtifactKind { get; init; } = string.Empty;
        public string SourceRole { get; init; } = string.Empty;
        public string Ownership { get; init; } = string.Empty;
        public bool Editable { get; init; }
        public string SourceOfTruth { get; init; } = string.Empty;
        public string Compression { get; init; } = string.Empty;
        public byte[] Content { get; init; } = [];
    }
}
