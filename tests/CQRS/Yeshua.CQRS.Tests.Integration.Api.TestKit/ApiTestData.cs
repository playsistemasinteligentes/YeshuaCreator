using System.Text.Json.Nodes;

namespace Yeshua.CQRS.Tests.Integration.Api.TestKit;

public static class ApiTestData
{
    private const string KeyAlphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string Suffix() => Guid.NewGuid().ToString("N")[..12];

    public static int IntKey() => Random.Shared.Next(1_000_000, int.MaxValue);

    public static long LongKey() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() * 100_000L + Random.Shared.Next(1, 100_000);

    public static string KeyText(int maxLength = 12)
    {
        var length = Math.Clamp(maxLength, 1, 12);
        var chars = new char[length];
        for (var index = 0; index < chars.Length; index++)
            chars[index] = KeyAlphabet[Random.Shared.Next(KeyAlphabet.Length)];

        return new string(chars);
    }

    public static string Text(string prefix, int maxLength = 80)
    {
        var value = $"{prefix} {Suffix()}";
        return value.Length <= maxLength ? value : value[..maxLength];
    }

    public static JsonObject Pagination(int page = 1, int pageSize = 20, bool pageWithCount = true) => new()
    {
        ["page"] = page,
        ["pageSize"] = pageSize,
        ["pageWhithCount"] = pageWithCount
    };
}
