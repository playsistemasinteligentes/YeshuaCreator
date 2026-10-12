using System.Text;
using System.Text.RegularExpressions;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp.Tools;

public static class LogQueryBuilder
{
    public static string Build(
        string? application,
        string? environment,
        string? text,
        bool errorsOnly)
    {
        var labels = new List<string>();
        if (!string.IsNullOrWhiteSpace(application))
            labels.Add($"service_name=~\".*{EscapeLabel(Regex.Escape(application))}.*\"");
        if (!string.IsNullOrWhiteSpace(environment))
            labels.Add($"deployment_environment_name=~\".*{EscapeLabel(Regex.Escape(environment))}.*\"");
        if (labels.Count == 0)
            labels.Add("service_name=~\".+\"");

        var builder = new StringBuilder();
        builder.Append('{');
        builder.Append(string.Join(",", labels));
        builder.Append('}');

        if (errorsOnly)
            builder.Append(" |~ \"(?i)(error|exception|failed|failure|falhou|erro)\"");

        if (!string.IsNullOrWhiteSpace(text))
        {
            builder.Append(" |= ");
            builder.Append('"');
            builder.Append(EscapeLogQl(text));
            builder.Append('"');
        }

        return builder.ToString();
    }

    public static string BuildRuntime(
        string application,
        string? environment,
        string? version,
        string? rootOperationId,
        string? operationId,
        string? operationalEntityId,
        string? traceId)
    {
        var labels = new List<string>
        {
            $"service_name=~\".*{EscapeLabel(Regex.Escape(application))}.*\""
        };

        if (!string.IsNullOrWhiteSpace(environment))
            labels.Add($"deployment_environment_name=~\".*{EscapeLabel(Regex.Escape(environment))}.*\"");
        if (!string.IsNullOrWhiteSpace(version))
            labels.Add($"service_version=\"{EscapeLabel(version)}\"");

        var builder = new StringBuilder();
        builder.Append('{');
        builder.Append(string.Join(",", labels));
        builder.Append('}');

        AppendTextFilter(builder, rootOperationId);
        AppendTextFilter(builder, operationId);
        AppendTextFilter(builder, operationalEntityId);
        AppendTextFilter(builder, traceId);
        return builder.ToString();
    }

    private static void AppendTextFilter(StringBuilder builder, string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return;

        builder.Append(" |= \"");
        builder.Append(EscapeLogQl(value));
        builder.Append('"');
    }

    private static string EscapeLabel(string value) =>
        value.Replace("\\", "\\\\", StringComparison.Ordinal)
            .Replace("\"", "\\\"", StringComparison.Ordinal);

    private static string EscapeLogQl(string value) =>
        value.Replace("\\", "\\\\", StringComparison.Ordinal)
            .Replace("\"", "\\\"", StringComparison.Ordinal);
}
