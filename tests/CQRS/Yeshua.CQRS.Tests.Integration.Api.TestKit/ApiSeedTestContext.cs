using System.Collections.Concurrent;
using System.Text.Json.Nodes;

namespace Yeshua.CQRS.Tests.Integration.Api.TestKit;

public static class ApiSeedTestContext
{
    private static readonly ConcurrentDictionary<string, JsonNode> CreatedIds = new(StringComparer.OrdinalIgnoreCase);

    public static void Clear()
    {
        CreatedIds.Clear();
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
            $"Seed test dependency '{entityName}' was not created before FK '{columnName}'. Check FK order or customize the payload.");
    }
}

