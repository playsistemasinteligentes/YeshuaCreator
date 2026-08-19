using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Reflection;
using Yeshua.OperationalIntelligence.Api.Configuration;

namespace Yeshua.OperationalIntelligence.Api.Database;

public sealed class OperationalIntelligenceDatabase
{
    private readonly string _connectionString;
    private readonly OperationalIntelligenceOptions _options;
    private readonly ILogger<OperationalIntelligenceDatabase> _logger;

    public OperationalIntelligenceDatabase(
        IConfiguration configuration,
        IOptions<OperationalIntelligenceOptions> options,
        ILogger<OperationalIntelligenceDatabase> logger)
    {
        _connectionString = configuration.GetConnectionString("OperationalIntelligence")
            ?? throw new InvalidOperationException(
                "Connection string 'OperationalIntelligence' was not configured.");
        _options = options.Value;
        _logger = logger;
    }

    public int CommandTimeoutSeconds => Math.Max(1, _options.CommandTimeoutSeconds);

    public async Task<SqlConnection> OpenConnectionAsync(CancellationToken cancellationToken = default)
    {
        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);
        return connection;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        if (_options.EnsureDatabase)
            await EnsureDatabaseAsync(cancellationToken);

        if (_options.RunMigrations)
            await RunMigrationsAsync(cancellationToken);
    }

    private async Task EnsureDatabaseAsync(CancellationToken cancellationToken)
    {
        var target = new SqlConnectionStringBuilder(_connectionString);
        var databaseName = target.InitialCatalog;
        if (string.IsNullOrWhiteSpace(databaseName))
            throw new InvalidOperationException(
                "The OperationalIntelligence connection string must declare a database.");

        var administrator = new SqlConnectionStringBuilder(_connectionString)
        {
            InitialCatalog = "master"
        };

        await using var connection = new SqlConnection(administrator.ConnectionString);
        await connection.OpenAsync(cancellationToken);

        var escapedDatabaseName = databaseName.Replace("]", "]]", StringComparison.Ordinal);
        var sql = $"""
            IF DB_ID(@DatabaseName) IS NULL
                EXEC(N'CREATE DATABASE [{escapedDatabaseName}]');
            """;

        await using var command = new SqlCommand(sql, connection)
        {
            CommandTimeout = CommandTimeoutSeconds
        };
        command.Parameters.AddWithValue("@DatabaseName", databaseName);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    private async Task RunMigrationsAsync(CancellationToken cancellationToken)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await ExecuteAsync(
            connection,
            """
            IF OBJECT_ID(N'OI_SchemaMigrations', N'U') IS NULL
            BEGIN
                CREATE TABLE OI_SchemaMigrations
                (
                    MigrationId NVARCHAR(300) NOT NULL PRIMARY KEY,
                    AppliedAtUtc DATETIME2(7) NOT NULL
                );
            END;
            """,
            cancellationToken);

        var assembly = Assembly.GetExecutingAssembly();
        var migrations = assembly.GetManifestResourceNames()
            .Where(name => name.Contains(".Database.Migrations.", StringComparison.Ordinal) &&
                           name.EndsWith(".sql", StringComparison.OrdinalIgnoreCase))
            .OrderBy(name => name, StringComparer.Ordinal)
            .ToArray();

        foreach (var migration in migrations)
        {
            if (await IsAppliedAsync(connection, migration, cancellationToken))
                continue;

            await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(cancellationToken);
            try
            {
                var sql = await ReadResourceAsync(assembly, migration, cancellationToken);
                await ExecuteAsync(connection, sql, cancellationToken, transaction);
                await ExecuteAsync(
                    connection,
                    "INSERT INTO OI_SchemaMigrations (MigrationId, AppliedAtUtc) VALUES (@MigrationId, SYSUTCDATETIME());",
                    cancellationToken,
                    transaction,
                    new SqlParameter("@MigrationId", migration));
                await transaction.CommitAsync(cancellationToken);
                _logger.LogInformation("Applied operational intelligence migration {Migration}", migration);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }

    private async Task<bool> IsAppliedAsync(
        SqlConnection connection,
        string migration,
        CancellationToken cancellationToken)
    {
        await using var command = new SqlCommand(
            "SELECT COUNT(1) FROM OI_SchemaMigrations WHERE MigrationId = @MigrationId;",
            connection)
        {
            CommandTimeout = CommandTimeoutSeconds
        };
        command.Parameters.AddWithValue("@MigrationId", migration);
        return Convert.ToInt32(await command.ExecuteScalarAsync(cancellationToken)) > 0;
    }

    private async Task ExecuteAsync(
        SqlConnection connection,
        string sql,
        CancellationToken cancellationToken,
        SqlTransaction? transaction = null,
        params SqlParameter[] parameters)
    {
        await using var command = new SqlCommand(sql, connection, transaction)
        {
            CommandTimeout = CommandTimeoutSeconds
        };
        if (parameters.Length > 0)
            command.Parameters.AddRange(parameters);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    private static async Task<string> ReadResourceAsync(
        Assembly assembly,
        string resourceName,
        CancellationToken cancellationToken)
    {
        await using var stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException($"Migration resource '{resourceName}' was not found.");
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync(cancellationToken);
    }
}
