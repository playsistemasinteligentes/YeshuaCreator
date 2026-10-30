namespace Yeshua.OperationalIntelligence.Api.Endpoints;

internal static class PublicReadQuery
{
    // Browser attribution is not an argument to the underlying tool.
    public static bool IsAttribution(string key) => key is
        "utm_source" or "utm_medium" or "utm_campaign" or "utm_term" or "utm_content" or "utm_id";
}
