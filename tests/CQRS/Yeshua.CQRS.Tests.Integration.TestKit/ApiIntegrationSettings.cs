using System.Globalization;
using System.Text;
using System.Text.Json;

namespace Yeshua.CQRS.Tests.Integration.TestKit;

public sealed class ApiIntegrationSettings
{
    private const string SectionName = "IntegrationApi";
    private const string BaseUrlKey = SectionName + ":BaseUrl";
    private const string LoginKey = SectionName + ":Login";
    private const string PasswordKey = SectionName + ":Password";
    private const string LoginPathKey = SectionName + ":LoginPath";
    private const string TimeoutSecondsKey = SectionName + ":TimeoutSeconds";

    public const string BaseUrlVariable = "INTEGRATIONAPI__BASEURL";
    public const string LoginVariable = "INTEGRATIONAPI__LOGIN";
    public const string PasswordVariable = "INTEGRATIONAPI__PASSWORD";
    public const string LoginPathVariable = "INTEGRATIONAPI__LOGINPATH";
    public const string TimeoutSecondsVariable = "INTEGRATIONAPI__TIMEOUTSECONDS";

    private const string LegacyBaseUrlVariable = "YESHUA_API_BASE_URL";
    private const string LegacyLoginVariable = "YESHUA_API_LOGIN";
    private const string LegacyPasswordVariable = "YESHUA_API_PASSWORD";
    private const string LegacyLoginPathVariable = "YESHUA_API_LOGIN_PATH";
    private const string LegacyTimeoutSecondsVariable = "YESHUA_API_TIMEOUT_SECONDS";

    public static string NotConfiguredMessage
    {
        get
        {
            TryCreate(out _, out var errorMessage);
            return errorMessage ?? BuildNotConfiguredMessage();
        }
    }

    private ApiIntegrationSettings(Uri baseUri, string loginPath, string login, string password, TimeSpan timeout)
    {
        BaseUri = baseUri;
        LoginPath = loginPath;
        Login = login;
        Password = password;
        Timeout = timeout;
    }

    public Uri BaseUri { get; }
    public string LoginPath { get; }
    public string Login { get; }
    public string Password { get; }
    public TimeSpan Timeout { get; }

    public static bool IsConfigured => TryCreate(out _, out _);

    public static ApiIntegrationSettings FromConfiguration()
    {
        if (TryCreate(out var settings, out var errorMessage))
            return settings;

        throw new InvalidOperationException(errorMessage ?? BuildNotConfiguredMessage());
    }

    public static ApiIntegrationSettings FromEnvironment() => FromConfiguration();

    private static bool TryCreate(out ApiIntegrationSettings settings, out string? errorMessage)
    {
        settings = null!;
        errorMessage = null;

        Dictionary<string, string> values;
        try
        {
            values = LoadSettings();
            ApplyEnvironmentOverrides(values);
        }
        catch (Exception ex)
        {
            errorMessage = $"Could not read integration API configuration. {ex.Message}";
            return false;
        }

        var baseUrl = GetValue(values, BaseUrlKey) ?? DiscoverBaseUrlFromApiLaunchSettings();
        var login = GetValue(values, LoginKey);
        var password = GetValue(values, PasswordKey);
        var loginPath = GetValue(values, LoginPathKey);
        var timeoutSecondsText = GetValue(values, TimeoutSecondsKey);

        if (string.IsNullOrWhiteSpace(baseUrl) ||
            string.IsNullOrWhiteSpace(login) ||
            string.IsNullOrWhiteSpace(password))
        {
            errorMessage = BuildNotConfiguredMessage();
            return false;
        }

        if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var baseUri))
        {
            errorMessage = $"{BaseUrlKey} must be an absolute URL.";
            return false;
        }

        if (!int.TryParse(timeoutSecondsText, NumberStyles.Integer, CultureInfo.InvariantCulture, out var timeoutSeconds) ||
            timeoutSeconds <= 0)
        {
            timeoutSeconds = 100;
        }

        settings = new ApiIntegrationSettings(
            baseUri,
            string.IsNullOrWhiteSpace(loginPath) ? "/yapi/login" : loginPath,
            login,
            password,
            TimeSpan.FromSeconds(timeoutSeconds));

        return true;
    }

    private static Dictionary<string, string> LoadSettings()
    {
        var values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var environmentName = GetEnvironmentName();

        foreach (var directory in GetConfigurationDirectories())
        {
            LoadJson(Path.Combine(directory, "appsettings.json"), values);
            LoadJson(Path.Combine(directory, $"appsettings.{environmentName}.json"), values);
            LoadJson(Path.Combine(directory, "appsettings.Local.json"), values);
            LoadJson(Path.Combine(directory, $"appsettings.{environmentName}.Local.json"), values);
        }

        return values;
    }

    private static string GetEnvironmentName()
    {
        return Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ??
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ??
            "Development";
    }

    private static IEnumerable<string> GetConfigurationDirectories()
    {
        var directories = new List<string>();
        AddDirectory(directories, AppContext.BaseDirectory);
        AddDirectory(directories, Directory.GetCurrentDirectory());

        var repositoryRoot = FindRepositoryRoot();
        if (repositoryRoot is not null)
        {
            AddDirectory(directories, Path.Combine(repositoryRoot, "src", "CQRS", "Infrastructure", "Yeshua.CQRS.Infrastructure.Api"));
            AddDirectory(directories, Path.Combine(repositoryRoot, "tests", "CQRS", "Yeshua.CQRS.Tests.Integration.Api"));
        }

        return directories;
    }

    private static void AddDirectory(ICollection<string> directories, string directory)
    {
        if (!string.IsNullOrWhiteSpace(directory) &&
            Directory.Exists(directory) &&
            !directories.Contains(directory, StringComparer.OrdinalIgnoreCase))
        {
            directories.Add(directory);
        }
    }

    private static void LoadJson(string filePath, IDictionary<string, string> values)
    {
        if (!File.Exists(filePath))
            return;

        using var document = JsonDocument.Parse(File.ReadAllText(filePath, Encoding.UTF8));
        FlattenJson(document.RootElement, null, values);
    }

    private static void FlattenJson(JsonElement element, string? prefix, IDictionary<string, string> values)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            foreach (var property in element.EnumerateObject())
            {
                var key = string.IsNullOrWhiteSpace(prefix)
                    ? property.Name
                    : $"{prefix}:{property.Name}";

                FlattenJson(property.Value, key, values);
            }

            return;
        }

        if (element.ValueKind == JsonValueKind.Array)
        {
            var index = 0;
            foreach (var item in element.EnumerateArray())
            {
                FlattenJson(item, $"{prefix}:{index.ToString(CultureInfo.InvariantCulture)}", values);
                index++;
            }

            return;
        }

        if (prefix is null || element.ValueKind == JsonValueKind.Null)
            return;

        values[prefix] = element.ValueKind == JsonValueKind.String
            ? element.GetString() ?? string.Empty
            : element.GetRawText();
    }

    private static void ApplyEnvironmentOverrides(IDictionary<string, string> values)
    {
        SetIfEnvironmentExists(values, BaseUrlKey, BaseUrlVariable, "IntegrationApi__BaseUrl", LegacyBaseUrlVariable);
        SetIfEnvironmentExists(values, LoginKey, LoginVariable, "IntegrationApi__Login", LegacyLoginVariable);
        SetIfEnvironmentExists(values, PasswordKey, PasswordVariable, "IntegrationApi__Password", LegacyPasswordVariable);
        SetIfEnvironmentExists(values, LoginPathKey, LoginPathVariable, "IntegrationApi__LoginPath", LegacyLoginPathVariable);
        SetIfEnvironmentExists(values, TimeoutSecondsKey, TimeoutSecondsVariable, "IntegrationApi__TimeoutSeconds", LegacyTimeoutSecondsVariable);
    }

    private static void SetIfEnvironmentExists(
        IDictionary<string, string> values,
        string key,
        params string[] environmentNames)
    {
        foreach (var environmentName in environmentNames)
        {
            var value = Environment.GetEnvironmentVariable(environmentName);
            if (!string.IsNullOrWhiteSpace(value))
            {
                values[key] = value;
                return;
            }
        }
    }

    private static string? GetValue(IReadOnlyDictionary<string, string> values, string key)
    {
        return values.TryGetValue(key, out var value) && !string.IsNullOrWhiteSpace(value)
            ? value
            : null;
    }

    private static string? DiscoverBaseUrlFromApiLaunchSettings()
    {
        var repositoryRoot = FindRepositoryRoot();
        if (repositoryRoot is null)
            return null;

        var launchSettingsPath = Path.Combine(
            repositoryRoot,
            "src",
            "CQRS",
            "Infrastructure",
            "Yeshua.CQRS.Infrastructure.Api",
            "Properties",
            "launchSettings.json");

        if (!File.Exists(launchSettingsPath))
            return null;

        using var document = JsonDocument.Parse(File.ReadAllText(launchSettingsPath, Encoding.UTF8));
        if (!document.RootElement.TryGetProperty("profiles", out var profiles) ||
            profiles.ValueKind != JsonValueKind.Object)
        {
            return null;
        }

        var urls = new List<string>();
        foreach (var profile in profiles.EnumerateObject())
        {
            if (profile.Value.TryGetProperty("applicationUrl", out var applicationUrl) &&
                applicationUrl.ValueKind == JsonValueKind.String)
            {
                urls.AddRange(applicationUrl.GetString()!.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
            }
        }

        return PickUrl(urls);
    }

    private static string? PickUrl(IEnumerable<string> urls)
    {
        var validUris = urls
            .Select(url => Uri.TryCreate(url, UriKind.Absolute, out var uri) ? uri : null)
            .Where(uri => uri is not null)
            .Cast<Uri>()
            .ToList();

        return validUris.FirstOrDefault(uri => uri.Scheme == Uri.UriSchemeHttps)?.ToString() ??
            validUris.FirstOrDefault()?.ToString();
    }

    private static string? FindRepositoryRoot()
    {
        foreach (var startDirectory in new[] { AppContext.BaseDirectory, Directory.GetCurrentDirectory() })
        {
            var directory = new DirectoryInfo(startDirectory);
            while (directory is not null)
            {
                if (File.Exists(Path.Combine(directory.FullName, "YeshuaCreator.sln")))
                    return directory.FullName;

                directory = directory.Parent;
            }
        }

        return null;
    }

    private static string BuildNotConfiguredMessage()
    {
        return $"Integration API tests require {BaseUrlKey}, {LoginKey} and {PasswordKey} in appsettings or {BaseUrlVariable}, {LoginVariable} and {PasswordVariable} in deploy.";
    }
}
