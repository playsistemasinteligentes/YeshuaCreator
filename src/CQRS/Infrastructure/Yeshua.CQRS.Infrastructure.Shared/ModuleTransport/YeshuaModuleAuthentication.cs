using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Shared.ModuleTransport;

public static class YeshuaModuleAuthenticationHeaders
{
    public const string SourceModule = "X-Yeshua-Source-Module";
    public const string MessageId = "X-Yeshua-Message-Id";
    public const string Timestamp = "X-Yeshua-Timestamp";
    public const string Signature = "X-Yeshua-Signature";
}

public sealed record YeshuaModuleAuthenticationSettings(
    string SourceModule,
    string SharedKey,
    int MaxClockSkewSeconds,
    int TechnicalUserId)
{
    public bool CanSign =>
        !string.IsNullOrWhiteSpace(SourceModule) &&
        !string.IsNullOrWhiteSpace(SharedKey);

    public bool CanValidate => !string.IsNullOrWhiteSpace(SharedKey);

    public static YeshuaModuleAuthenticationSettings FromConfiguration(IConfiguration configuration)
    {
        var section = configuration.GetSection("YeshuaModules:Authentication");
        return new YeshuaModuleAuthenticationSettings(
            section["SourceModule"]?.Trim() ?? string.Empty,
            section["SharedKey"] ?? string.Empty,
            Math.Max(1, section.GetValue<int?>("MaxClockSkewSeconds") ?? 300),
            section.GetValue<int?>("TechnicalUserId") ?? 0);
    }
}

public sealed record YeshuaModuleAuthenticationResult(
    bool Succeeded,
    string ErrorCode,
    string SourceModule)
{
    public static YeshuaModuleAuthenticationResult Success(string sourceModule) =>
        new(true, string.Empty, sourceModule);

    public static YeshuaModuleAuthenticationResult Failure(string errorCode) =>
        new(false, errorCode, string.Empty);
}

public interface IYeshuaModuleRequestAuthenticator
{
    int TechnicalUserId { get; }

    YeshuaModuleAuthenticationResult Authenticate(
        string method,
        string pathAndQuery,
        string sourceModule,
        string messageId,
        string timestamp,
        string signature,
        string body);
}

public sealed class YeshuaModuleRequestAuthenticator : IYeshuaModuleRequestAuthenticator
{
    private readonly YeshuaModuleAuthenticationSettings _settings;
    private readonly TimeProvider _timeProvider;

    public YeshuaModuleRequestAuthenticator(
        YeshuaModuleAuthenticationSettings settings,
        TimeProvider timeProvider)
    {
        _settings = settings;
        _timeProvider = timeProvider;
    }

    public int TechnicalUserId => _settings.TechnicalUserId;

    public YeshuaModuleAuthenticationResult Authenticate(
        string method,
        string pathAndQuery,
        string sourceModule,
        string messageId,
        string timestamp,
        string signature,
        string body)
    {
        if (!_settings.CanValidate)
            return YeshuaModuleAuthenticationResult.Failure("ModuleAuthenticationNotConfigured");

        if (string.IsNullOrWhiteSpace(sourceModule) ||
            string.IsNullOrWhiteSpace(messageId) ||
            string.IsNullOrWhiteSpace(timestamp) ||
            string.IsNullOrWhiteSpace(signature))
            return YeshuaModuleAuthenticationResult.Failure("MissingAuthenticationHeaders");

        if (!long.TryParse(timestamp, NumberStyles.None, CultureInfo.InvariantCulture, out var unixTimestamp))
            return YeshuaModuleAuthenticationResult.Failure("InvalidTimestamp");

        var requestTime = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp);
        var elapsed = (_timeProvider.GetUtcNow() - requestTime).Duration();
        if (elapsed > TimeSpan.FromSeconds(_settings.MaxClockSkewSeconds))
            return YeshuaModuleAuthenticationResult.Failure("ExpiredSignature");

        var expected = YeshuaModuleRequestSignature.Create(
            method,
            pathAndQuery,
            sourceModule,
            messageId,
            timestamp,
            body,
            _settings.SharedKey);

        if (!YeshuaModuleRequestSignature.FixedTimeEquals(expected, signature))
            return YeshuaModuleAuthenticationResult.Failure("InvalidSignature");

        return YeshuaModuleAuthenticationResult.Success(sourceModule);
    }
}

public sealed class YeshuaModuleAuthenticationHandler : DelegatingHandler
{
    private readonly YeshuaModuleAuthenticationSettings _settings;
    private readonly TimeProvider _timeProvider;

    public YeshuaModuleAuthenticationHandler(
        YeshuaModuleAuthenticationSettings settings,
        TimeProvider timeProvider)
    {
        _settings = settings;
        _timeProvider = timeProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (!_settings.CanSign)
            throw new InvalidOperationException(
                "YeshuaModules:Authentication:SourceModule e SharedKey devem estar configurados para transportar eventos entre modulos.");

        var messageId = ReadHeader(request, YeshuaModuleAuthenticationHeaders.MessageId);
        if (string.IsNullOrWhiteSpace(messageId))
            throw new InvalidOperationException("O MessageId deve ser informado antes de assinar um evento entre modulos.");

        var body = request.Content is null
            ? string.Empty
            : await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var timestamp = _timeProvider.GetUtcNow()
            .ToUnixTimeSeconds()
            .ToString(CultureInfo.InvariantCulture);
        var pathAndQuery = request.RequestUri?.PathAndQuery ?? "/";
        var signature = YeshuaModuleRequestSignature.Create(
            request.Method.Method,
            pathAndQuery,
            _settings.SourceModule,
            messageId,
            timestamp,
            body,
            _settings.SharedKey);

        SetHeader(request, YeshuaModuleAuthenticationHeaders.SourceModule, _settings.SourceModule);
        SetHeader(request, YeshuaModuleAuthenticationHeaders.Timestamp, timestamp);
        SetHeader(request, YeshuaModuleAuthenticationHeaders.Signature, signature);

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }

    private static string? ReadHeader(HttpRequestMessage request, string name) =>
        request.Headers.TryGetValues(name, out var values) ? values.FirstOrDefault() : null;

    private static void SetHeader(HttpRequestMessage request, string name, string value)
    {
        request.Headers.Remove(name);
        request.Headers.TryAddWithoutValidation(name, value);
    }
}

public static class YeshuaModuleAuthenticationRegistration
{
    public static IServiceCollection AddYeshuaModuleAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton(YeshuaModuleAuthenticationSettings.FromConfiguration(configuration));
        services.AddSingleton(TimeProvider.System);
        services.AddSingleton<IYeshuaModuleRequestAuthenticator, YeshuaModuleRequestAuthenticator>();
        services.AddTransient<YeshuaModuleAuthenticationHandler>();
        return services;
    }
}

internal static class YeshuaModuleRequestSignature
{
    public static string Create(
        string method,
        string pathAndQuery,
        string sourceModule,
        string messageId,
        string timestamp,
        string body,
        string sharedKey)
    {
        var bodyHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(body)));
        var canonical = string.Join(
            '\n',
            method.ToUpperInvariant(),
            pathAndQuery,
            sourceModule,
            timestamp,
            messageId,
            bodyHash);

        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(sharedKey));
        return Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(canonical)));
    }

    public static bool FixedTimeEquals(string expected, string actual)
    {
        try
        {
            return CryptographicOperations.FixedTimeEquals(
                Convert.FromHexString(expected),
                Convert.FromHexString(actual));
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
