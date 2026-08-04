using System.Collections.Concurrent;
using System.Text.Json.Nodes;

namespace Yeshua.CQRS.Tests.Integration.Api.TestKit;

public static class ApiSmokeTestContext
{
    private static readonly ConcurrentDictionary<string, JsonNode> CreatedIds = new(StringComparer.OrdinalIgnoreCase);
    private static readonly ConcurrentDictionary<string, JsonObject> DeletePayloads = new(StringComparer.OrdinalIgnoreCase);

    public static void Clear()
    {
        CreatedIds.Clear();
        DeletePayloads.Clear();
    }

    public static void RegisterCreatedId(string entityName, JsonNode id)
    {
        CreatedIds[entityName] = id.DeepClone();
    }

    public static JsonNode GetRequiredCreatedId(string entityName, string columnName)
    {
        if (CreatedIds.TryGetValue(entityName, out var id))
            return id.DeepClone();

        throw new InvalidOperationException(
            $"Smoke test dependency '{entityName}' was not created before FK '{columnName}'. Check FK order or customize the payload.");
    }

    public static void RegisterDeletePayload(string entityName, JsonObject payload)
    {
        DeletePayloads[entityName] = (JsonObject)payload.DeepClone();
    }

    public static bool TryGetDeletePayload(string entityName, out JsonObject payload)
    {
        if (DeletePayloads.TryGetValue(entityName, out var storedPayload))
        {
            payload = (JsonObject)storedPayload.DeepClone();
            return true;
        }

        payload = null!;
        return false;
    }
}
