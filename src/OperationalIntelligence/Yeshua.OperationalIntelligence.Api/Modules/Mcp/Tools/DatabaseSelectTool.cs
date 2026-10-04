using System.Data;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class DatabaseSelectTool : IMcpTool
{
    private const int MaximumParameterCount = 50;

    private readonly McpOptions _options;
    private readonly McpToolArgumentReader _arguments;
    private readonly DatabaseReadOnlySqlGuard _guard;

    public DatabaseSelectTool(
        IOptions<McpOptions> options,
        McpToolArgumentReader arguments,
        DatabaseReadOnlySqlGuard guard)
    {
        _options = options.Value;
        _arguments = arguments;
        _guard = guard;
    }

    public string Name => "yeshua.database.select";
    public string Description => "Runs a configured read-only SQL SELECT query against an allowed database alias.";
    public object InputSchema => McpToolSchemas.DatabaseSelect();

    public async Task<McpToolResult> CallAsync(
        JsonElement arguments,
        CancellationToken cancellationToken)
    {
        if (!_options.DatabaseQuery.Enabled)
            return McpToolResult.Error("MCP database query is disabled.");

        var connection = _arguments.RequiredString(arguments, "connection");
        if (!_options.DatabaseQuery.Connections.TryGetValue(connection, out var connectionString) ||
            string.IsNullOrWhiteSpace(connectionString))
        {
            return McpToolResult.Error(
                $"Database connection alias '{connection}' is not configured.",
                new
                {
                    configuredConnections = _options.DatabaseQuery.Connections.Keys
                        .OrderBy(key => key, StringComparer.OrdinalIgnoreCase)
                        .ToArray()
                });
        }

        var validated = _guard.Validate(
            _arguments.String(arguments, "query"),
            _options.DatabaseQuery.MaxSqlLength);
        if (!validated.IsValid)
            return McpToolResult.Error(validated.Error ?? "Invalid SQL query.");

        var maxRows = _arguments.ClampedInteger(
            arguments,
            "maxRows",
            _options.DatabaseQuery.MaxRows,
            1,
            Math.Max(1, _options.DatabaseQuery.MaxRows));
        var timeoutSeconds = _arguments.ClampedInteger(
            arguments,
            "timeoutSeconds",
            _options.DatabaseQuery.CommandTimeoutSeconds,
            1,
            Math.Max(1, _options.DatabaseQuery.CommandTimeoutSeconds));

        try
        {
            var result = await ExecuteAsync(
                connection,
                connectionString,
                validated.Sql,
                ReadParameters(arguments),
                maxRows,
                timeoutSeconds,
                cancellationToken);

            return McpToolResult.Ok("Database SELECT query completed.", result);
        }
        catch (ArgumentException exception)
        {
            return McpToolResult.Error(exception.Message);
        }
        catch (SqlException exception)
        {
            return McpToolResult.Error(
                $"Database SELECT query failed: {exception.Message}");
        }
    }

    private static async Task<DatabaseSelectResult> ExecuteAsync(
        string connectionName,
        string connectionString,
        string sql,
        IReadOnlyDictionary<string, object?> parameters,
        int maxRows,
        int timeoutSeconds,
        CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        await using var connection = new SqlConnection(BuildReadOnlyConnectionString(connectionString));
        await connection.OpenAsync(cancellationToken);

        await using var command = connection.CreateCommand();
        command.CommandType = CommandType.Text;
        command.CommandTimeout = timeoutSeconds;
        command.CommandText = "SET LOCK_TIMEOUT 5000; SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; " + sql;

        foreach (var parameter in parameters)
        {
            var sqlParameter = command.CreateParameter();
            sqlParameter.ParameterName = parameter.Key.StartsWith('@')
                ? parameter.Key
                : "@" + parameter.Key;
            sqlParameter.Value = parameter.Value ?? DBNull.Value;
            command.Parameters.Add(sqlParameter);
        }

        await using var reader = await command.ExecuteReaderAsync(
            CommandBehavior.SingleResult,
            cancellationToken);

        var columns = Enumerable.Range(0, reader.FieldCount)
            .Select(index => new DatabaseSelectColumn(
                reader.GetName(index),
                reader.GetDataTypeName(index)))
            .ToArray();
        var rows = new List<Dictionary<string, object?>>();
        var truncated = false;

        while (await reader.ReadAsync(cancellationToken))
        {
            if (rows.Count >= maxRows)
            {
                truncated = true;
                break;
            }

            var row = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
            for (var index = 0; index < reader.FieldCount; index++)
                row[columns[index].Name] = await reader.IsDBNullAsync(index, cancellationToken)
                    ? null
                    : NormalizeValue(reader.GetValue(index));

            rows.Add(row);
        }

        stopwatch.Stop();
        return new DatabaseSelectResult(
            connectionName,
            DateTimeOffset.UtcNow,
            stopwatch.ElapsedMilliseconds,
            rows.Count,
            truncated,
            columns,
            rows,
            [
                "TECHNICAL_DEBT_CRITICAL: MCP database/source access still needs a formal authorization model before broader exposure."
            ]);
    }

    private static IReadOnlyDictionary<string, object?> ReadParameters(JsonElement arguments)
    {
        if (!arguments.TryGetProperty("parameters", out var parameters) ||
            parameters.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined)
        {
            return new Dictionary<string, object?>();
        }

        if (parameters.ValueKind != JsonValueKind.Object)
            throw new ArgumentException("parameters must be an object.");

        var result = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
        foreach (var property in parameters.EnumerateObject())
        {
            if (result.Count >= MaximumParameterCount)
                throw new ArgumentException($"parameters cannot contain more than {MaximumParameterCount} items.");

            result[property.Name] = ReadParameterValue(property.Value);
        }

        return result;
    }

    private static object? ReadParameterValue(JsonElement value)
    {
        return value.ValueKind switch
        {
            JsonValueKind.Null => null,
            JsonValueKind.String => ReadStringParameter(value.GetString()),
            JsonValueKind.Number when value.TryGetInt32(out var intValue) => intValue,
            JsonValueKind.Number when value.TryGetInt64(out var longValue) => longValue,
            JsonValueKind.Number when value.TryGetDecimal(out var decimalValue) => decimalValue,
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            _ => throw new ArgumentException("parameters can only contain scalar values.")
        };
    }

    private static object? ReadStringParameter(string? value)
    {
        if (value is null)
            return null;

        return DateTimeOffset.TryParse(value, out var dateTime)
            ? dateTime
            : value;
    }

    private static object? NormalizeValue(object value)
    {
        return value switch
        {
            byte[] bytes => Convert.ToBase64String(bytes),
            DateTime dateTime => new DateTimeOffset(DateTime.SpecifyKind(dateTime, DateTimeKind.Utc)),
            DateTimeOffset dateTimeOffset => dateTimeOffset,
            Guid guid => guid,
            _ => value
        };
    }

    private static string BuildReadOnlyConnectionString(string connectionString)
    {
        var builder = new SqlConnectionStringBuilder(connectionString)
        {
            ApplicationIntent = ApplicationIntent.ReadOnly,
            ApplicationName = "Yeshua Operational Intelligence MCP"
        };
        return builder.ConnectionString;
    }
}

public sealed record DatabaseSelectResult(
    string Connection,
    DateTimeOffset ExecutedAtUtc,
    long ElapsedMilliseconds,
    int RowCount,
    bool Truncated,
    IReadOnlyList<DatabaseSelectColumn> Columns,
    IReadOnlyList<IReadOnlyDictionary<string, object?>> Rows,
    IReadOnlyList<string> Warnings);

public sealed record DatabaseSelectColumn(
    string Name,
    string DataType);
