using System.Collections.Frozen;
using System.Text.Json;
using System.Text.Json.Nodes;
using Json.Schema;

namespace Central.BusinessMcp;

// No fetching, code generation or client-supplied servers. Feed this adapter only
// versioned OpenAPI from an approved application's existing Swagger pipeline.
public sealed class TrustedBusinessCatalog
{
    internal sealed record Entry(BusinessOperation Contract, Uri Target, string Grant, string Scope, JsonSchema Validator);
    private readonly FrozenDictionary<(string, string), Entry> entries;

    public sealed record Source(string Application, Uri BaseAddress, JsonElement OpenApi,
        IReadOnlyList<BusinessExposure> Exposures);

    public TrustedBusinessCatalog(IEnumerable<Source> sources)
    {
        var result = new Dictionary<(string, string), Entry>();
        foreach (var source in sources)
        {
            if (string.IsNullOrWhiteSpace(source.Application) || !source.BaseAddress.IsAbsoluteUri
                || source.BaseAddress.Scheme != "https" || source.BaseAddress.AbsolutePath != "/"
                || source.BaseAddress.Query != "" || source.BaseAddress.Fragment != "" || source.BaseAddress.UserInfo != "")
                throw new ArgumentException("Invalid trusted application origin.");
            var doc = source.OpenApi;
            if (doc.GetProperty("openapi").GetString() is not ("3.0.1" or "3.0.2" or "3.0.3"))
                throw new ArgumentException("Only the existing OpenAPI 3.0 JSON contract is supported in this increment.");
            foreach (var exposure in source.Exposures)
            {
                if (string.IsNullOrWhiteSpace(exposure.Grant) || string.IsNullOrWhiteSpace(exposure.OperationId)
                    || !exposure.Scope.StartsWith("business:operation:", StringComparison.Ordinal))
                    throw new ArgumentException("An explicit business grant and delegated scope are required.");
                var matches = doc.GetProperty("paths").EnumerateObject()
                    .SelectMany(path => path.Value.EnumerateObject().Select(method => (path, method)))
                    .Where(item => item.method.Value.ValueKind == JsonValueKind.Object
                        && item.method.Value.TryGetProperty("operationId", out var id) && id.GetString() == exposure.OperationId).ToArray();
                if (matches.Length != 1) throw new ArgumentException("Missing or ambiguous stable operation ID.");
                var (path, method) = matches[0];
                var operation = method.Value;
                // JSON body Commands only. Headers, cookies, query, path parameters,
                // uploads, callbacks and internal/anonymous operations need separate review.
                if (method.Name != "post" || !path.Name.StartsWith("/yapi/", StringComparison.Ordinal)
                    || path.Name.Contains('\\') || path.Name.Contains('%') || path.Name.Contains('?')
                    || path.Name.Contains('#') || path.Name.Contains('{') || path.Name.Split('/').Any(p => p is "." or "..")
                    || path.Name.Contains("/operational/", StringComparison.OrdinalIgnoreCase)
                    || HasItems(path.Value, "parameters") || HasItems(operation, "parameters")
                    || operation.TryGetProperty("callbacks", out _) || Flag(operation, "x-yeshua-internal")
                    || Flag(operation, "x-yeshua-administrative")
                    || !operation.TryGetProperty("security", out var security) || security.GetArrayLength() == 0
                    || security.EnumerateArray().Any(s => !s.EnumerateObject().Any()))
                    throw new ArgumentException("Operation is not eligible for delegated business access.");
                var description = operation.TryGetProperty("description", out var d) ? d.GetString() : null;
                if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("An operation description is required.");
                var input = Schema(doc, operation.GetProperty("requestBody").GetProperty("content")
                    .GetProperty("application/json").GetProperty("schema"), true);
                var output = Schema(doc, operation.GetProperty("responses").GetProperty("200").GetProperty("content")
                    .GetProperty("application/json").GetProperty("schema"), false);
                var contract = new BusinessOperation(source.Application, exposure.OperationId, description, input, output);
                result.Add((source.Application, exposure.OperationId), new(contract, new Uri(source.BaseAddress, path.Name),
                    exposure.Grant, exposure.Scope, JsonSchema.FromText(input.GetRawText())));
            }
        }
        entries = result.ToFrozenDictionary();
    }
    internal IEnumerable<Entry> Entries => entries.Values;
    internal Entry? Find(string app, string operation) => entries.GetValueOrDefault((app, operation));
    private static bool Flag(JsonElement element, string key) => element.TryGetProperty(key, out var value) && value.ValueKind == JsonValueKind.True;
    private static bool HasItems(JsonElement element, string key) => element.TryGetProperty(key, out var value) && value.GetArrayLength() != 0;

    // Format adapter only: schemas still originate in Swagger. Preserve local refs,
    // recursive types, required, enums, arrays and compositions; never resolve network refs.
    private static JsonElement Schema(JsonElement document, JsonElement schema, bool input)
    {
        var definitions = new JsonObject();
        var pending = new Queue<string>();
        JsonNode Convert(JsonElement value)
        {
            var node = JsonNode.Parse(value.GetRawText())!.AsObject();
            if (node.TryGetPropertyValue("$ref", out var reference))
            {
                var text = reference!.GetValue<string>();
                const string prefix = "#/components/schemas/";
                if (!text.StartsWith(prefix, StringComparison.Ordinal)) throw new ArgumentException("Only local schema references are allowed.");
                pending.Enqueue(text[prefix.Length..]);
                node["$ref"] = "#/$defs/" + text[prefix.Length..];
            }
            if (node.ContainsKey("discriminator") || node.ContainsKey("xml"))
                throw new ArgumentException("This OpenAPI schema requires additional adapter support.");
            foreach (var keyword in new[] { "properties", "additionalProperties", "items", "allOf", "oneOf", "anyOf", "not" })
            {
                if (!node.TryGetPropertyValue(keyword, out var child) || child is null) continue;
                if (keyword == "properties")
                    foreach (var property in child.AsObject().ToArray()) child[property.Key] = Convert(JsonSerializer.SerializeToElement(property.Value));
                else if (child is JsonArray list)
                    for (var i = 0; i < list.Count; i++) list[i] = Convert(JsonSerializer.SerializeToElement(list[i]));
                else if (child is JsonObject) node[keyword] = Convert(JsonSerializer.SerializeToElement(child));
            }
            foreach (var (bound, inclusive) in new[] { ("exclusiveMinimum", "minimum"), ("exclusiveMaximum", "maximum") })
                if (node[bound] is JsonValue flag && flag.TryGetValue<bool>(out var exclusive))
                {
                    node.Remove(bound);
                    if (exclusive)
                    {
                        node[bound] = node[inclusive]?.DeepClone() ?? throw new ArgumentException("Missing exclusive bound.");
                        node.Remove(inclusive);
                    }
                }
            if (node["nullable"]?.GetValue<bool>() == true)
            {
                node.Remove("nullable");
                return new JsonObject { ["anyOf"] = new JsonArray(node, new JsonObject { ["type"] = "null" }) };
            }
            node.Remove("nullable");
            return node;
        }
        var root = Convert(schema).AsObject();
        while (pending.TryDequeue(out var key))
        {
            var decodedKey = key.Replace("~1", "/").Replace("~0", "~");
            if (definitions.ContainsKey(decodedKey)) continue;
            // Reserve before conversion so recursive references terminate.
            definitions[decodedKey] = null;
            definitions[decodedKey] = Convert(document.GetProperty("components").GetProperty("schemas").GetProperty(decodedKey));
        }
        root["$schema"] = "https://json-schema.org/draft/2020-12/schema";
        root["$defs"] = definitions;
        // Fail closed for context-bearing input contracts. Identity comes from OAuth.
        if (input)
        {
            var objectSchema = root["$ref"] is JsonValue rootRef
                ? definitions[rootRef.GetValue<string>()["#/$defs/".Length..].Replace("~1", "/").Replace("~0", "~")]!.AsObject() : root;
            if (objectSchema["type"]?.GetValue<string>() != "object" || objectSchema["properties"] is not JsonObject properties)
                throw new ArgumentException("Only object command inputs are supported.");
            if (properties.Any(p => new[] { "tenantId", "userId", "clientId", "delegationId" }.Contains(p.Key, StringComparer.OrdinalIgnoreCase)))
                throw new ArgumentException("Identity cannot be supplied in business parameters.");
            objectSchema["additionalProperties"] = false;
        }
        return JsonSerializer.SerializeToElement(root);
    }
}
