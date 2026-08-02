using System.Text.Json;
using System.Text.Json.Nodes;
using Xunit;

namespace Yeshua.CQRS.Tests.Integration.TestKit;

public static class ApiJson
{
    public static string? GetString(JsonElement element, string propertyName)
    {
        if (TryGetProperty(element, propertyName, out var property) && property.ValueKind == JsonValueKind.String)
            return property.GetString();

        return null;
    }

    public static JsonNode? GetProperty(JsonNode? node, string propertyName)
    {
        if (node is not JsonObject obj)
            return null;

        if (obj.TryGetPropertyValue(propertyName, out var exact))
            return exact;

        foreach (var item in obj)
        {
            if (string.Equals(item.Key, propertyName, StringComparison.OrdinalIgnoreCase))
                return item.Value;
        }

        return null;
    }

    public static JsonNode GetRequiredProperty(JsonNode? node, params string[] path)
    {
        JsonNode? current = node;
        foreach (var segment in path)
        {
            current = GetProperty(current, segment);
            Assert.NotNull(current);
        }

        return current!;
    }

    public static int? GetInt32(JsonNode? node, string propertyName)
    {
        var value = GetProperty(node, propertyName);
        return value is null ? null : value.GetValue<int>();
    }

    public static bool JsonValueEquals(JsonNode? left, JsonNode? right)
    {
        if (left is null || right is null)
            return left is null && right is null;

        return string.Equals(left.ToJsonString(), right.ToJsonString(), StringComparison.Ordinal);
    }

    private static bool TryGetProperty(JsonElement element, string propertyName, out JsonElement property)
    {
        if (element.TryGetProperty(propertyName, out property))
            return true;

        foreach (var item in element.EnumerateObject())
        {
            if (string.Equals(item.Name, propertyName, StringComparison.OrdinalIgnoreCase))
            {
                property = item.Value;
                return true;
            }
        }

        return false;
    }
}
