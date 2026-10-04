using System.Text;
using System.Text.RegularExpressions;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public sealed class DatabaseReadOnlySqlGuard
{
    private static readonly Regex ForbiddenTokenRegex = new(
        @"\b(insert|update|delete|merge|drop|alter|create|truncate|exec|execute|grant|revoke|deny|backup|restore|dbcc|use|set|declare|openrowset|opendatasource|bulk|into)\b|xp_|sp_",
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

    public (bool IsValid, string Sql, string? Error) Validate(string? sql, int maxSqlLength)
    {
        if (string.IsNullOrWhiteSpace(sql))
            return (false, string.Empty, "query is required.");

        if (sql.Length > maxSqlLength)
            return (false, string.Empty, $"query cannot exceed {maxSqlLength} characters.");

        var trimmed = sql.Trim();
        if (trimmed.EndsWith(';'))
            trimmed = trimmed[..^1].TrimEnd();

        if (trimmed.Contains(';', StringComparison.Ordinal))
            return (false, string.Empty, "Only one SQL statement is allowed.");

        var inspected = StripCommentsAndStringLiterals(trimmed);
        if (inspected is null)
            return (false, string.Empty, "SQL comments or string literals are not closed.");

        var leading = inspected.TrimStart();
        if (!StartsWithReadOnlyCommand(leading))
            return (false, string.Empty, "Only SELECT or WITH queries are allowed.");

        if (ForbiddenTokenRegex.IsMatch(leading))
            return (false, string.Empty, "The query contains a forbidden SQL token for read-only MCP access.");

        return (true, trimmed, null);
    }

    private static bool StartsWithReadOnlyCommand(string sql) =>
        sql.StartsWith("select ", StringComparison.OrdinalIgnoreCase) ||
        sql.Equals("select", StringComparison.OrdinalIgnoreCase) ||
        sql.StartsWith("with ", StringComparison.OrdinalIgnoreCase) ||
        sql.Equals("with", StringComparison.OrdinalIgnoreCase);

    private static string? StripCommentsAndStringLiterals(string sql)
    {
        var output = new StringBuilder(sql.Length);
        for (var index = 0; index < sql.Length; index++)
        {
            var current = sql[index];
            var next = index + 1 < sql.Length ? sql[index + 1] : '\0';

            if (current == '-' && next == '-')
            {
                index += 2;
                while (index < sql.Length && sql[index] is not '\r' and not '\n')
                    index++;
                output.Append(' ');
                continue;
            }

            if (current == '/' && next == '*')
            {
                index += 2;
                var closed = false;
                while (index < sql.Length)
                {
                    if (sql[index] == '*' &&
                        index + 1 < sql.Length &&
                        sql[index + 1] == '/')
                    {
                        closed = true;
                        index++;
                        break;
                    }

                    index++;
                }

                if (!closed)
                    return null;

                output.Append(' ');
                continue;
            }

            if (current == '\'')
            {
                output.Append(' ');
                index++;
                var closed = false;
                while (index < sql.Length)
                {
                    if (sql[index] == '\'')
                    {
                        if (index + 1 < sql.Length && sql[index + 1] == '\'')
                        {
                            index++;
                            continue;
                        }

                        closed = true;
                        break;
                    }

                    index++;
                }

                if (!closed)
                    return null;

                continue;
            }

            output.Append(current);
        }

        return output.ToString();
    }
}

