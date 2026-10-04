namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public sealed class McpToolRegistry
{
    private readonly Dictionary<string, IMcpTool> _tools;

    public McpToolRegistry(IEnumerable<IMcpTool> tools)
    {
        _tools = tools.ToDictionary(
            tool => tool.Name,
            StringComparer.OrdinalIgnoreCase);
    }

    public IReadOnlyList<McpToolDescriptor> List() =>
        _tools.Values
            .OrderBy(tool => tool.Name, StringComparer.OrdinalIgnoreCase)
            .Select(tool => new McpToolDescriptor(
                tool.Name,
                tool.Description,
                tool.InputSchema))
            .ToArray();

    public bool TryGet(string name, out IMcpTool tool) =>
        _tools.TryGetValue(name, out tool!);
}
