using System.Text.Json.Nodes;

namespace Yeshua.CQRS.Tests.Integration.Api.TestKit;

public static class ApiTestData
{
    public static string Suffix() => Guid.NewGuid().ToString("N")[..12];

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
