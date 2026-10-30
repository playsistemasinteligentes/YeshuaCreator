namespace Yeshua.OperationalIntelligence.Api.Configuration;

public sealed class OperationalIntelligenceOptions
{
    public const string SectionName = "OperationalIntelligence";

    public string PublicBaseUrl { get; init; } = "https://playsis.com.br/operational/";

    public bool EnsureDatabase { get; init; } = true;
    public bool RunMigrations { get; init; } = true;
    public int CommandTimeoutSeconds { get; init; } = 60;
    public int DefaultMaxDepth { get; init; } = 12;
    public int MaximumMaxDepth { get; init; } = 100;
    public int DefaultMaxResults { get; init; } = 500;
    public int MaximumMaxResults { get; init; } = 5000;
    public int CollectorTimeoutSeconds { get; init; } = 30;

    public static bool IsValidPublicBaseUrl(string value) =>
        Uri.TryCreate(value, UriKind.Absolute, out var uri) &&
        uri.Scheme is "http" or "https" && uri.UserInfo.Length == 0 &&
        uri.Query.Length == 0 && uri.Fragment.Length == 0;
}
