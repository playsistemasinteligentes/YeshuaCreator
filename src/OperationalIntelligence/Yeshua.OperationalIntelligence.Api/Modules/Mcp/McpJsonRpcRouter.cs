using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public sealed class McpJsonRpcRouter
{
    private const string LegacyProtocolVersion = "2025-06-18";
    private const string CurrentProtocolVersion = "2026-07-28";
    private readonly McpToolRegistry _registry;
    private readonly McpOptions _options;
    private readonly ILogger<McpJsonRpcRouter> _logger;

    public McpJsonRpcRouter(
        McpToolRegistry registry,
        IOptions<McpOptions> options,
        ILogger<McpJsonRpcRouter> logger)
    {
        _registry = registry;
        _options = options.Value;
        _logger = logger;
    }

    public async Task<IResult> HandleAsync(
        JsonElement request,
        CancellationToken cancellationToken)
    {
        if (!_options.Enabled)
            return Results.NotFound();

        if (request.ValueKind != JsonValueKind.Object)
            return Results.Json(Error(null, -32600, "Invalid JSON-RPC request."));

        var id = ReadId(request);
        if (!request.TryGetProperty("method", out var methodElement) ||
            methodElement.ValueKind != JsonValueKind.String)
        {
            return Results.Json(Error(id, -32600, "JSON-RPC method is required."));
        }

        var method = methodElement.GetString()!;
        if (id is null && method.StartsWith("notifications/", StringComparison.OrdinalIgnoreCase))
            return Results.NoContent();

        try
        {
            return method switch
            {
                "initialize" => Results.Json(Success(id, InitializeResult())),
                "server/discover" => Results.Json(Success(id, DiscoverResult())),
                "ping" => Results.Json(Success(id, new { })),
                "tools/list" => Results.Json(Success(id, new { tools = _registry.List() })),
                "tools/call" => Results.Json(Success(
                    id,
                    await CallToolAsync(request, cancellationToken))),
                _ => Results.Json(Error(id, -32601, $"Method '{method}' was not found."))
            };
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "MCP request failed for method {Method}", method);
            return Results.Json(Error(id, -32603, exception.Message));
        }
    }

    private async Task<object> CallToolAsync(
        JsonElement request,
        CancellationToken cancellationToken)
    {
        if (!request.TryGetProperty("params", out var parameters) ||
            parameters.ValueKind != JsonValueKind.Object ||
            !parameters.TryGetProperty("name", out var nameElement) ||
            nameElement.ValueKind != JsonValueKind.String)
        {
            return ToolError("tools/call requires params.name.");
        }

        var name = nameElement.GetString()!;
        if (!_registry.TryGet(name, out var tool))
            return ToolError($"Tool '{name}' was not found.");

        var arguments = parameters.TryGetProperty("arguments", out var args) &&
                        args.ValueKind == JsonValueKind.Object
            ? args
            : EmptyJsonObject.Value;

        var result = await tool.CallAsync(arguments, cancellationToken);
        return new
        {
            content = result.Content.Select(item => new
            {
                type = item.Type,
                text = item.Text
            }),
            structuredContent = result.StructuredContent,
            isError = result.IsError
        };
    }

    private object InitializeResult() => new
    {
        protocolVersion = LegacyProtocolVersion,
        capabilities = Capabilities(),
        serverInfo = ServerInfo()
    };

    private object DiscoverResult() => new
    {
        protocolVersion = CurrentProtocolVersion,
        supportedProtocolVersions = new[] { CurrentProtocolVersion, LegacyProtocolVersion },
        capabilities = Capabilities(),
        serverInfo = ServerInfo()
    };

    private static object Capabilities() => new
    {
        tools = new
        {
            listChanged = false
        }
    };

    private static object ServerInfo() => new
    {
        name = "yeshua-operational-intelligence",
        version = "0.1.0"
    };

    private static object ToolError(string message) => new
    {
        content = new[]
        {
            new
            {
                type = "text",
                text = message
            }
        },
        isError = true
    };

    private static object Success(object? id, object result) => new
    {
        jsonrpc = "2.0",
        id,
        result
    };

    private static object Error(
        object? id,
        int code,
        string message,
        object? data = null)
    {
        var error = new Dictionary<string, object?>
        {
            ["code"] = code,
            ["message"] = message
        };
        if (data is not null)
            error["data"] = data;

        return new
        {
            jsonrpc = "2.0",
            id,
            error
        };
    }

    private static object? ReadId(JsonElement request)
    {
        if (!request.TryGetProperty("id", out var id))
            return null;

        return id.ValueKind switch
        {
            JsonValueKind.String => id.GetString(),
            JsonValueKind.Number when id.TryGetInt64(out var value) => value,
            JsonValueKind.Number => id.GetDouble(),
            JsonValueKind.Null => null,
            _ => id.GetRawText()
        };
    }

    private static class EmptyJsonObject
    {
        private static readonly JsonDocument Document = JsonDocument.Parse("{}");
        public static JsonElement Value => Document.RootElement;
    }
}
