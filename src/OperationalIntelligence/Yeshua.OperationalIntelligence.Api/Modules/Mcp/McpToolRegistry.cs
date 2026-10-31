using System.Text.Json;
using ModelContextProtocol.Protocol;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public sealed class McpToolRegistry
{
    private readonly Dictionary<string, IMcpTool> _tools;
    private readonly McpAccessPolicy _access;
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public McpToolRegistry(IEnumerable<IMcpTool> tools, McpAccessPolicy access)
    {
        _access = access;
        _tools = tools.ToDictionary(
            tool => NormalizeName(tool.Name),
            StringComparer.OrdinalIgnoreCase);
    }

    public IList<Tool> List() =>
        _tools.Values
            .Where(tool => tool.IsPublic || _access.HasPrivateAccess)
            .OrderBy(tool => tool.Name, StringComparer.OrdinalIgnoreCase)
            .Select(tool => new Tool
            {
                Name = NormalizeName(tool.Name),
                Title = NormalizeName(tool.Name).Replace('_', ' '),
                Description = tool.Description,
                InputSchema = JsonSerializer.SerializeToElement(tool.InputSchema, JsonOptions),
                OutputSchema = McpOutputSchemas.For(tool.Name),
                Annotations = new ToolAnnotations
                {
                    ReadOnlyHint = tool.IsReadOnly,
                    DestructiveHint = !tool.IsReadOnly,
                    IdempotentHint = true,
                    OpenWorldHint = tool.IsOpenWorld
                }
            })
            .ToArray();

    public async Task<CallToolResult> CallAsync(
        string name, JsonElement arguments, CancellationToken cancellationToken)
    {
        if (!_tools.TryGetValue(NormalizeName(name), out var tool) ||
            (!tool.IsPublic && !_access.HasPrivateAccess))
            return Error("Ferramenta indisponivel nesta conexao. Use o MCP privado pelo tunel autorizado.");

        try
        {
            var result = await tool.CallAsync(arguments, cancellationToken);
            var structured = result.StructuredContent is null
                ? JsonSerializer.SerializeToElement(new Dictionary<string, string>())
                : JsonSerializer.SerializeToElement(result.StructuredContent, JsonOptions);
            return new CallToolResult
            {
                Content = result.Content.Select(item => (ContentBlock)new TextContentBlock { Text = item.Text }).ToArray(),
                StructuredContent = structured,
                IsError = result.IsError
            };
        }
        catch (ArgumentException exception)
        {
            return Error(exception.Message);
        }
        catch (KeyNotFoundException exception)
        {
            return Error(exception.Message);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch
        {
            return Error("Nao foi possivel concluir a ferramenta. Consulte a saude do servico e tente novamente.");
        }
    }

    private static string NormalizeName(string name) => name.Replace('.', '_');

    private static CallToolResult Error(string message) => new()
    {
        IsError = true,
        Content = [new TextContentBlock { Text = message }]
    };
}
