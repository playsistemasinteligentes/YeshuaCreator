namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public static class McpEndpoints
{
    public static void MapMcpEndpoints(this WebApplication app)
    {
        if (app.Configuration.GetValue<bool?>("Mcp:Enabled") != false)
            app.MapMcp("/mcp");
    }
}
