namespace Yeshua.OperationalIntelligence.Api.Endpoints;

internal static class PublicReadQuery
{
    // Browser attribution is not an argument to the underlying tool.
    public static bool IsAttribution(string key) => key is
        "utm_source" or "utm_medium" or "utm_campaign" or "utm_term" or "utm_content" or "utm_id";

    public static string Format(IQueryCollection query)
    {
        var values = query["format"];
        if (values.Count == 0) return "text";
        var value = values.ToString().Trim().ToLowerInvariant();
        if (values.Count != 1 || value is not ("text" or "json"))
            throw new ArgumentException("format aceita text ou json, com um único valor.");
        return value;
    }

    // The structured payload is identical; only the HTTP presentation changes.
    public static IResult Reply(string json, string format, int statusCode = 200) =>
        Results.Text(json, format == "json" ? "application/json; charset=utf-8" : "text/plain; charset=utf-8", statusCode: statusCode);

    public static IResult Error(string message, string format, int statusCode = 400) =>
        Reply("{\"error\":" + System.Text.Json.JsonSerializer.Serialize(message) + "}", format, statusCode);
}
