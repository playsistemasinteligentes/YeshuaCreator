using System.Globalization;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dominio.Commercial;

public sealed record UsageRight(string Resource, long Until, decimal GrantedUnits);

public static class UsageRightClaims
{
    public const string Type = "usageRights";

    public static IReadOnlyList<UsageRight> Read(ClaimsPrincipal principal)
        => Read(principal.FindFirst(Type)?.Value);

    public static IReadOnlyList<UsageRight> Read(string? json)
    {
        if (string.IsNullOrEmpty(json)) return Array.Empty<UsageRight>();
        if (json.Length > 16000) return Array.Empty<UsageRight>();
        try
        {
            var rights = JsonSerializer.Deserialize(json, UsageRightJsonContext.Default.UsageRightArray) ?? [];
            if (rights.Length > 64 || rights.Any(right => string.IsNullOrEmpty(right.Resource) ||
                right.Resource.Length > 100 || right.Until < 0 || right.GrantedUnits < 0)) return [];
            return rights;
        }
        catch (JsonException) { return []; }
    }

    public static string Write(IEnumerable<UsageRight> rights)
    {
        var snapshot = rights.Take(65).ToArray();
        if (snapshot.Length > 64) throw new InvalidOperationException("Limite de direitos por token excedido.");
        return JsonSerializer.Serialize(snapshot, UsageRightJsonContext.Default.UsageRightArray);
    }

    public static bool HasPeriodClaim(ClaimsPrincipal principal, string claimType, DateTimeOffset now)
        => long.TryParse(principal.FindFirst(claimType)?.Value, NumberStyles.None, CultureInfo.InvariantCulture,
            out var until) && until > now.ToUnixTimeSeconds();

    public static void AddTo(List<Claim> claims, IReadOnlyList<UsageRight> rights)
    {
        claims.Add(new Claim(Type, Write(rights)));
        foreach (var right in rights)
            if (right.Until > 0)
                claims.Add(new Claim("usageUntil." + right.Resource, right.Until.ToString(CultureInfo.InvariantCulture)));
    }

    public static DateTime TokenExpiry(ClaimsPrincipal principal, DateTime proposed)
        => long.TryParse(principal.FindFirst("exp")?.Value, NumberStyles.None, CultureInfo.InvariantCulture, out var expires)
            ? new DateTime(Math.Min(proposed.Ticks, DateTimeOffset.FromUnixTimeSeconds(expires).UtcDateTime.Ticks), DateTimeKind.Utc)
            : proposed;
}

[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(UsageRight[]))]
internal partial class UsageRightJsonContext : JsonSerializerContext { }
