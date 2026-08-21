using Microsoft.Data.SqlClient;
using System.Data;
using System.IO.Compression;
using System.Text;

internal sealed class ReferenceSqlPublisher
{
    public async Task PublishAsync(
        ReferenceIndexModel model,
        string connectionString,
        CancellationToken cancellationToken = default)
    {
        await EnsureDatabaseAsync(connectionString, cancellationToken);

        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);
        await ExecuteAsync(connection, null, ReferenceSqlWriter.Schema, cancellationToken);

        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(cancellationToken);
        try
        {
            await ExecuteAsync(
                connection,
                transaction,
                """
                IF EXISTS (SELECT 1 FROM OI_Applications WHERE ApplicationId = @ApplicationId)
                    UPDATE OI_Applications SET Name = @Name, SystemType = @SystemType
                    WHERE ApplicationId = @ApplicationId;
                ELSE
                    INSERT INTO OI_Applications (ApplicationId, Name, SystemType)
                    VALUES (@ApplicationId, @Name, @SystemType);

                DELETE FROM OI_FunctionCalls WHERE BuildId = @BuildId;
                IF OBJECT_ID(N'OI_TextReferences', N'U') IS NOT NULL
                    DELETE FROM OI_TextReferences WHERE BuildId = @BuildId;
                DELETE FROM OI_ClassInstantiations WHERE BuildId = @BuildId;
                DELETE FROM OI_FieldReferences WHERE BuildId = @BuildId;
                DELETE FROM OI_Declarations WHERE BuildId = @BuildId;
                DELETE FROM OI_Symbols WHERE BuildId = @BuildId;
                DELETE FROM OI_Files WHERE BuildId = @BuildId;
                DELETE FROM OI_Projects WHERE BuildId = @BuildId;
                DELETE FROM OI_Builds WHERE BuildId = @BuildId;

                INSERT INTO OI_Builds
                    (BuildId, ApplicationId, Version, CommitSha, SourceSolution, GeneratedAtUtc, ManifestHashSha256)
                VALUES
                    (@BuildId, @ApplicationId, @Version, @CommitSha, @SourceSolution, @GeneratedAtUtc, @ManifestHashSha256);
                """,
                cancellationToken,
                new SqlParameter("@ApplicationId", model.ApplicationId),
                new SqlParameter("@BuildId", model.BuildId),
                new SqlParameter("@Name", model.ApplicationName),
                new SqlParameter("@SystemType", model.SystemType),
                new SqlParameter("@Version", model.Version),
                new SqlParameter("@CommitSha", (object?)model.CommitSha ?? DBNull.Value),
                new SqlParameter("@SourceSolution", model.SourceSolution),
                new SqlParameter("@GeneratedAtUtc", model.GeneratedAtUtc.UtcDateTime),
                new SqlParameter("@ManifestHashSha256", model.ManifestHashSha256));

            await PublishSourceContentsAsync(connection, transaction, model.SourceContents.Values, cancellationToken);
            await BulkCopyAsync(connection, transaction, Projects(model), "OI_Projects", cancellationToken);
            await BulkCopyAsync(connection, transaction, Files(model), "OI_Files", cancellationToken);
            await BulkCopyAsync(connection, transaction, Symbols(model), "OI_Symbols", cancellationToken);
            await BulkCopyAsync(connection, transaction, Declarations(model), "OI_Declarations", cancellationToken);
            await BulkCopyAsync(connection, transaction, FieldReferences(model), "OI_FieldReferences", cancellationToken);
            await BulkCopyAsync(connection, transaction, ClassInstantiations(model), "OI_ClassInstantiations", cancellationToken);
            await BulkCopyAsync(connection, transaction, FunctionCalls(model), "OI_FunctionCalls", cancellationToken);
            await BulkCopyAsync(connection, transaction, TextReferences(model), "OI_TextReferences", cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    private static async Task EnsureDatabaseAsync(string connectionString, CancellationToken cancellationToken)
    {
        var target = new SqlConnectionStringBuilder(connectionString);
        var database = target.InitialCatalog;
        if (string.IsNullOrWhiteSpace(database))
            throw new InvalidOperationException("A connection string deve informar o database operacional.");

        target.InitialCatalog = "master";
        await using var connection = new SqlConnection(target.ConnectionString);
        await connection.OpenAsync(cancellationToken);
        var escaped = database.Replace("]", "]]", StringComparison.Ordinal);
        await ExecuteAsync(
            connection,
            null,
            $"IF DB_ID(@Database) IS NULL EXEC(N'CREATE DATABASE [{escaped}]');",
            cancellationToken,
            new SqlParameter("@Database", database));
    }

    private static async Task PublishSourceContentsAsync(
        SqlConnection connection,
        SqlTransaction transaction,
        IEnumerable<ReferenceSourceContentRow> contents,
        CancellationToken cancellationToken)
    {
        var table = Table(
            [Col("HashSha256", typeof(string)), Col("Compression", typeof(string)), Col("Content", typeof(byte[])),
             Col("OriginalByteLength", typeof(int)), Col("StoredByteLength", typeof(int))],
            contents.Select(item =>
            {
                var compressed = Compress(item.Content);
                return new object?[] { item.HashSha256, "GZIP", compressed, item.ByteLength, compressed.Length };
            }));
        if (table.Rows.Count == 0)
            return;

        await ExecuteAsync(connection, transaction, """
            CREATE TABLE #OI_SourceContentsStage
            (
                HashSha256 CHAR(64) NOT NULL,
                Compression NVARCHAR(20) NOT NULL,
                Content VARBINARY(MAX) NOT NULL,
                OriginalByteLength INT NOT NULL,
                StoredByteLength INT NOT NULL
            );
            """, cancellationToken);
        await BulkCopyAsync(connection, transaction, table, "#OI_SourceContentsStage", cancellationToken);
        await ExecuteAsync(connection, transaction, """
            INSERT INTO OI_SourceContents
                (HashSha256, Compression, Content, OriginalByteLength, StoredByteLength, CreatedAtUtc)
            SELECT s.HashSha256, s.Compression, s.Content, s.OriginalByteLength,
                   s.StoredByteLength, SYSUTCDATETIME()
            FROM #OI_SourceContentsStage s
            WHERE NOT EXISTS
            (
                SELECT 1 FROM OI_SourceContents currentContent
                WHERE currentContent.HashSha256 = s.HashSha256
            );
            """, cancellationToken);
    }

    private static byte[] Compress(string content)
    {
        using var output = new MemoryStream();
        using (var gzip = new GZipStream(output, CompressionLevel.SmallestSize, true))
        using (var writer = new StreamWriter(gzip, new UTF8Encoding(false)))
            writer.Write(content);
        return output.ToArray();
    }

    private static async Task BulkCopyAsync(
        SqlConnection connection,
        SqlTransaction transaction,
        DataTable table,
        string destination,
        CancellationToken cancellationToken)
    {
        if (table.Rows.Count == 0)
            return;

        using var bulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.CheckConstraints, transaction)
        {
            DestinationTableName = destination,
            BatchSize = 1000,
            BulkCopyTimeout = 300
        };
        foreach (DataColumn column in table.Columns)
            bulk.ColumnMappings.Add(column.ColumnName, column.ColumnName);
        await bulk.WriteToServerAsync(table, cancellationToken);
    }

    private static async Task ExecuteAsync(
        SqlConnection connection,
        SqlTransaction? transaction,
        string sql,
        CancellationToken cancellationToken,
        params SqlParameter[] parameters)
    {
        await using var command = new SqlCommand(sql, connection, transaction) { CommandTimeout = 300 };
        if (parameters.Length > 0)
            command.Parameters.AddRange(parameters);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    private static DataTable Projects(ReferenceIndexModel model)
        => Table(
            [Col("ProjectId", typeof(Guid)), Col("BuildId", typeof(Guid)), Col("Name", typeof(string)),
             Col("AssemblyName", typeof(string)), Col("ProjectPath", typeof(string)), Col("SourceDirectory", typeof(string)),
             Col("IsSeedProject", typeof(bool))],
            model.Projects.Values.Select(x => new object?[] { x.ProjectId, x.BuildId, x.Name, x.AssemblyName, x.ProjectPath, x.SourceDirectory, x.IsSeedProject }));

    private static DataTable Files(ReferenceIndexModel model)
        => Table(
            [Col("FileId", typeof(Guid)), Col("BuildId", typeof(Guid)), Col("ProjectId", typeof(Guid)),
             Col("RelativePath", typeof(string)), Col("HashSha256", typeof(string)), Col("ArtifactKind", typeof(string)),
             Col("SourceRole", typeof(string)), Col("Ownership", typeof(string)), Col("Editable", typeof(bool)),
             Col("SourceOfTruth", typeof(string))],
            model.Files.Values.Select(x => new object?[] { x.FileId, x.BuildId, x.ProjectId, x.RelativePath, x.HashSha256, x.ArtifactKind, x.SourceRole, x.Ownership, x.Editable, x.SourceOfTruth }));

    private static DataTable Symbols(ReferenceIndexModel model)
        => Table(
            [Col("SymbolId", typeof(Guid)), Col("BuildId", typeof(Guid)), Col("ProjectId", typeof(Guid)),
             Col("ContainingSymbolId", typeof(Guid)), Col("Kind", typeof(string)), Col("Name", typeof(string)),
             Col("QualifiedName", typeof(string)), Col("SymbolKey", typeof(string))],
            model.Symbols.Values.Select(x => new object?[] { x.SymbolId, x.BuildId, x.ProjectId, x.ContainingSymbolId, x.Kind, x.Name, x.QualifiedName, x.SymbolKey }));

    private static DataTable Declarations(ReferenceIndexModel model)
        => Table(
            [Col("DeclarationId", typeof(Guid)), Col("BuildId", typeof(Guid)), Col("SymbolId", typeof(Guid)),
             Col("FileId", typeof(Guid)), Col("StartLine", typeof(int)), Col("StartColumn", typeof(int)),
             Col("EndLine", typeof(int)), Col("EndColumn", typeof(int))],
            model.Declarations.Values.Select(x => new object?[] { x.DeclarationId, x.BuildId, x.SymbolId, x.FileId, x.StartLine, x.StartColumn, x.EndLine, x.EndColumn }));

    private static DataTable FieldReferences(ReferenceIndexModel model)
        => Table(
            [Col("FieldReferenceId", typeof(Guid)), Col("BuildId", typeof(Guid)), Col("FieldSymbolId", typeof(Guid)),
             Col("ContainingFunctionId", typeof(Guid)), Col("FileId", typeof(Guid)), Col("AccessKind", typeof(string)),
             Col("Line", typeof(int)), Col("ColumnNumber", typeof(int)), Col("ResolutionKind", typeof(string))],
            model.FieldReferences.Values.Select(x => new object?[] { x.FieldReferenceId, x.BuildId, x.FieldSymbolId, x.ContainingFunctionId, x.FileId, x.AccessKind, x.Line, x.Column, x.ResolutionKind }));

    private static DataTable ClassInstantiations(ReferenceIndexModel model)
        => Table(
            [Col("InstantiationId", typeof(Guid)), Col("BuildId", typeof(Guid)), Col("ClassSymbolId", typeof(Guid)),
             Col("ConstructorSymbolId", typeof(Guid)), Col("ContainingFunctionId", typeof(Guid)), Col("FileId", typeof(Guid)),
             Col("Line", typeof(int)), Col("ColumnNumber", typeof(int)), Col("ResolutionKind", typeof(string))],
            model.ClassInstantiations.Values.Select(x => new object?[] { x.InstantiationId, x.BuildId, x.ClassSymbolId, x.ConstructorSymbolId, x.ContainingFunctionId, x.FileId, x.Line, x.Column, x.ResolutionKind }));

    private static DataTable FunctionCalls(ReferenceIndexModel model)
        => Table(
            [Col("FunctionCallId", typeof(Guid)), Col("BuildId", typeof(Guid)), Col("CallerFunctionId", typeof(Guid)),
             Col("CalledFunctionId", typeof(Guid)), Col("FileId", typeof(Guid)), Col("Line", typeof(int)),
             Col("ColumnNumber", typeof(int)), Col("ResolutionKind", typeof(string))],
            model.FunctionCalls.Values.Select(x => new object?[] { x.FunctionCallId, x.BuildId, x.CallerFunctionId, x.CalledFunctionId, x.FileId, x.Line, x.Column, x.ResolutionKind }));

    private static DataTable TextReferences(ReferenceIndexModel model)
        => Table(
            [Col("TextReferenceId", typeof(Guid)), Col("BuildId", typeof(Guid)), Col("FileId", typeof(Guid)),
             Col("Token", typeof(string)), Col("ReferenceKind", typeof(string)), Col("Line", typeof(int)),
             Col("ColumnNumber", typeof(int)), Col("ContextSnippet", typeof(string))],
            model.TextReferences.Values.Select(x => new object?[] { x.TextReferenceId, x.BuildId, x.FileId, x.Token, x.ReferenceKind, x.Line, x.Column, x.ContextSnippet }));

    private static (string Name, Type Type) Col(string name, Type type) => (name, type);

    private static DataTable Table(
        IReadOnlyList<(string Name, Type Type)> columns,
        IEnumerable<object?[]> rows)
    {
        var table = new DataTable();
        foreach (var column in columns)
            table.Columns.Add(column.Name, column.Type);
        foreach (var values in rows)
            table.Rows.Add(values.Select(value => value ?? DBNull.Value).ToArray());
        return table;
    }
}
