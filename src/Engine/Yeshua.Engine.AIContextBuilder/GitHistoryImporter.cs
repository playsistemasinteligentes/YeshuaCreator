using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;

internal sealed class GitHistoryImporter
{
    public async Task<int> ImportAsync(
        ReverseEngineeringManifest manifest,
        string connectionString,
        CancellationToken cancellationToken = default)
    {
        var imported = 0;
        foreach (var repository in manifest.Repositories)
        {
            var history = await ReadConfirmedHistoryAsync(manifest, repository.Root, cancellationToken);
            imported += await PublishAsync(manifest, repository.Root, history, connectionString, cancellationToken);
        }

        return imported;
    }

    private static async Task<IReadOnlyList<GitCommit>> ReadConfirmedHistoryAsync(
        ReverseEngineeringManifest manifest,
        string repositoryRoot,
        CancellationToken cancellationToken)
    {
        var arguments = new List<string>
        {
            "-C", repositoryRoot, "log", "HEAD", "--date=iso-strict",
            "--format=--YESHUA-COMMIT--%x09%H%x09%P%x09%an%x09%ae%x09%cI%x09%s",
            "--name-status", "--no-renames", "--"
        };
        arguments.AddRange(manifest.Projects
            .Select(project => Path.GetRelativePath(repositoryRoot, project.SourceDirectory).Replace('\\', '/'))
            .Where(path => !path.StartsWith("..", StringComparison.Ordinal))
            .Distinct(StringComparer.OrdinalIgnoreCase));

        var output = await RunGitAsync(arguments, cancellationToken);
        var commits = new List<GitCommit>();
        GitCommit? current = null;
        foreach (var rawLine in output.Split('\n'))
        {
            var line = rawLine.TrimEnd('\r');
            if (line.StartsWith("--YESHUA-COMMIT--\t", StringComparison.Ordinal))
            {
                var parts = line.Split('\t', 7);
                if (parts.Length < 7)
                    continue;
                current = new GitCommit(
                    parts[1],
                    parts[2],
                    parts[3],
                    parts[4],
                    DateTimeOffset.Parse(parts[5], CultureInfo.InvariantCulture),
                    parts[6],
                    []);
                commits.Add(current);
                continue;
            }

            if (current == null || string.IsNullOrWhiteSpace(line))
                continue;
            var change = line.Split('\t', 2);
            if (change.Length == 2)
                current.Changes.Add(new GitFileChange(change[0], change[1].Replace('\\', '/')));
        }

        return commits;
    }

    private static async Task<int> PublishAsync(
        ReverseEngineeringManifest manifest,
        string repositoryRoot,
        IReadOnlyList<GitCommit> commits,
        string connectionString,
        CancellationToken cancellationToken)
    {
        if (commits.Count == 0)
            return 0;

        var applicationId = StableGuid.Create($"application|{manifest.System.Trim().ToUpperInvariant()}");
        var repositoryId = StableGuid.Create($"git-repository|{applicationId:N}|{repositoryRoot.ToUpperInvariant()}");
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(cancellationToken);
        try
        {
            await ExecuteAsync(connection, transaction, """
                IF NOT EXISTS (SELECT 1 FROM OI_GitRepositories WHERE RepositoryId = @RepositoryId)
                    INSERT INTO OI_GitRepositories
                        (RepositoryId, ApplicationId, RootPath, UpdatedAtUtc)
                    VALUES
                        (@RepositoryId, @ApplicationId, @RootPath, SYSUTCDATETIME());
                ELSE
                    UPDATE OI_GitRepositories SET UpdatedAtUtc = SYSUTCDATETIME()
                    WHERE RepositoryId = @RepositoryId;
                """, cancellationToken,
                new SqlParameter("@RepositoryId", repositoryId),
                new SqlParameter("@ApplicationId", applicationId),
                new SqlParameter("@RootPath", repositoryRoot));

            var imported = 0;
            foreach (var commit in commits)
            {
                var exists = Convert.ToInt32(await ScalarAsync(
                    connection,
                    transaction,
                    "SELECT COUNT(1) FROM OI_GitCommits WHERE RepositoryId = @RepositoryId AND CommitSha = @CommitSha;",
                    cancellationToken,
                    new SqlParameter("@RepositoryId", repositoryId),
                    new SqlParameter("@CommitSha", commit.Sha))) > 0;
                if (exists)
                    continue;

                var commitId = StableGuid.Create($"git-commit|{repositoryId:N}|{commit.Sha}");
                await ExecuteAsync(connection, transaction, """
                    INSERT INTO OI_GitCommits
                        (CommitId, RepositoryId, CommitSha, ParentShas, AuthorName, AuthorEmail, CommittedAtUtc, Message)
                    VALUES
                        (@CommitId, @RepositoryId, @CommitSha, @ParentShas, @AuthorName, @AuthorEmail, @CommittedAtUtc, @Message);
                    """, cancellationToken,
                    new SqlParameter("@CommitId", commitId),
                    new SqlParameter("@RepositoryId", repositoryId),
                    new SqlParameter("@CommitSha", commit.Sha),
                    new SqlParameter("@ParentShas", Db(commit.ParentShas)),
                    new SqlParameter("@AuthorName", Db(commit.AuthorName)),
                    new SqlParameter("@AuthorEmail", Db(commit.AuthorEmail)),
                    new SqlParameter("@CommittedAtUtc", commit.CommittedAtUtc.UtcDateTime),
                    new SqlParameter("@Message", Db(commit.Message)));

                for (var index = 0; index < commit.Changes.Count; index++)
                {
                    var change = commit.Changes[index];
                    var changeId = StableGuid.Create($"git-change|{commitId:N}|{index}|{change.Path}");
                    var isDelete = change.ChangeType.StartsWith('D');
                    await ExecuteAsync(connection, transaction, """
                        INSERT INTO OI_GitFileChanges
                            (ChangeId, CommitId, ChangeType, OldPath, NewPath)
                        VALUES
                            (@ChangeId, @CommitId, @ChangeType, @OldPath, @NewPath);
                        """, cancellationToken,
                        new SqlParameter("@ChangeId", changeId),
                        new SqlParameter("@CommitId", commitId),
                        new SqlParameter("@ChangeType", change.ChangeType),
                        new SqlParameter("@OldPath", isDelete ? change.Path : DBNull.Value),
                        new SqlParameter("@NewPath", isDelete ? DBNull.Value : change.Path));
                }

                imported++;
            }

            await ExecuteAsync(connection, transaction, """
                UPDATE OI_GitRepositories
                SET LastImportedCommitSha = @LastCommitSha, UpdatedAtUtc = SYSUTCDATETIME()
                WHERE RepositoryId = @RepositoryId;
                """, cancellationToken,
                new SqlParameter("@LastCommitSha", commits[0].Sha),
                new SqlParameter("@RepositoryId", repositoryId));
            await transaction.CommitAsync(cancellationToken);
            return imported;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    private static async Task<string> RunGitAsync(
        IReadOnlyList<string> arguments,
        CancellationToken cancellationToken)
    {
        var startInfo = new ProcessStartInfo("git")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        foreach (var argument in arguments)
            startInfo.ArgumentList.Add(argument);

        using var process = Process.Start(startInfo)
            ?? throw new InvalidOperationException("Nao foi possivel iniciar o Git.");
        var outputTask = process.StandardOutput.ReadToEndAsync(cancellationToken);
        var errorTask = process.StandardError.ReadToEndAsync(cancellationToken);
        await process.WaitForExitAsync(cancellationToken);
        var output = await outputTask;
        var error = await errorTask;
        if (process.ExitCode != 0)
            throw new InvalidOperationException($"Falha ao importar historico Git: {error}");
        return output;
    }

    private static object Db(string? value) => string.IsNullOrWhiteSpace(value) ? DBNull.Value : value;

    private static async Task ExecuteAsync(
        SqlConnection connection,
        SqlTransaction transaction,
        string sql,
        CancellationToken cancellationToken,
        params SqlParameter[] parameters)
    {
        await using var command = new SqlCommand(sql, connection, transaction) { CommandTimeout = 300 };
        command.Parameters.AddRange(parameters);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    private static async Task<object?> ScalarAsync(
        SqlConnection connection,
        SqlTransaction transaction,
        string sql,
        CancellationToken cancellationToken,
        params SqlParameter[] parameters)
    {
        await using var command = new SqlCommand(sql, connection, transaction) { CommandTimeout = 300 };
        command.Parameters.AddRange(parameters);
        return await command.ExecuteScalarAsync(cancellationToken);
    }

    private sealed record GitCommit(
        string Sha,
        string ParentShas,
        string AuthorName,
        string AuthorEmail,
        DateTimeOffset CommittedAtUtc,
        string Message,
        List<GitFileChange> Changes);

    private sealed record GitFileChange(string ChangeType, string Path);
}
