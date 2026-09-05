using System.Text.Json.Nodes;
using Xunit;

namespace Yeshua.CQRS.Tests.Integration.Api.TestKit;

public static class ApiResponseAssertions
{
    public static async Task<JsonObject> ReadSuccessStateAsync(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        Assert.True(
            response.IsSuccessStatusCode,
            $"Expected HTTP success, got {(int)response.StatusCode}. Body: {content}");

        var node = JsonNode.Parse(content) as JsonObject;
        Assert.NotNull(node);

        var statusCode = ApiJson.GetInt32(node, "statusCode");
        if (statusCode.HasValue)
            Assert.InRange(statusCode.Value, 200, 299);

        return node!;
    }

    public static void AssertNodeHasValue(JsonNode? node, string name)
    {
        Assert.NotNull(node);
        Assert.False(
            node is JsonValue value && value.TryGetValue<string>(out var text) && string.IsNullOrWhiteSpace(text),
            $"{name} should not be empty.");
    }

    public static void AssertSameJsonValue(JsonNode expected, JsonNode actual, string name)
    {
        Assert.True(ApiJson.JsonValueEquals(expected, actual), $"{name} did not match. Expected {expected}; actual {actual}.");
    }

    public static void AssertReadContainsId(JsonObject readState, JsonNode id)
    {
        AssertReadContainsId(readState, id, "id");
    }

    public static void AssertReadContainsId(JsonObject readState, JsonNode id, string idPropertyName)
    {
        var items = GetReadItems(readState);

        var found = items.Any(item =>
        {
            var itemId = ApiJson.GetProperty(item, idPropertyName);
            return ApiJson.JsonValueEquals(id, itemId);
        });

        Assert.True(found, $"Read response did not contain {idPropertyName} {id}.");
    }

    public static void AssertReadReturnedItems(JsonObject readState)
    {
        _ = GetReadItems(readState);
    }

    private static JsonArray GetReadItems(JsonObject readState)
    {
        var data = ApiJson.GetRequiredProperty(readState, "data");
        var items = ApiJson.GetProperty(data, "items") as JsonArray;
        Assert.NotNull(items);
        return items!;
    }
}
