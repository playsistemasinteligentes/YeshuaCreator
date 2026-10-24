using System.Diagnostics;
using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.Mcp;

public sealed class McpTunnelOptions
{
    public string Id { get; init; } = "";
    public string ApiKey { get; init; } = "";
    public string Executable { get; init; } = "tunnel-client";
}

public sealed class McpTunnelWorker(
    IOptions<McpTunnelOptions> options, IOptions<McpOptions> mcpOptions,
    ILogger<McpTunnelWorker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (string.IsNullOrWhiteSpace(options.Value.Id))
            return;
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await RunClientAsync(stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                return;
            }
            catch
            {
                logger.LogWarning("Private MCP tunnel client unavailable. Check its configuration and account permissions.");
            }
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                return;
            }
        }
    }

    private async Task RunClientAsync(CancellationToken cancellationToken)
    {
        var settings = options.Value;
        var start = new ProcessStartInfo(settings.Executable)
        {
            UseShellExecute = false, CreateNoWindow = true,
            RedirectStandardOutput = true, RedirectStandardError = true
        };
        foreach (var argument in new[]
        {
            "run", "--control-plane.tunnel-id", settings.Id,
            "--control-plane.api-key", "env:CONTROL_PLANE_API_KEY",
            "--mcp.server-url", $"http://127.0.0.1:{mcpOptions.Value.PrivatePort}/mcp",
            "--mcp.startup-wait-timeout", "30s", "--health.listen-addr", "127.0.0.1:5730"
        })
            start.ArgumentList.Add(argument);
        start.Environment.Clear();
        foreach (var name in new[] { "PATH", "HOME", "SYSTEMROOT", "WINDIR", "USERPROFILE", "TEMP", "TMP", "LANG" })
        {
            var value = Environment.GetEnvironmentVariable(name);
            if (value is not null) start.Environment[name] = value;
        }
        start.Environment["CONTROL_PLANE_API_KEY"] = settings.ApiKey;
        using var process = new Process { StartInfo = start };
        if (!process.Start()) throw new InvalidOperationException("Tunnel client did not start.");
        try
        {
            var output = DrainAsync(process.StandardOutput, cancellationToken);
            var error = DrainAsync(process.StandardError, cancellationToken);
            await process.WaitForExitAsync(cancellationToken);
            await Task.WhenAll(output, error);
            if (!cancellationToken.IsCancellationRequested)
                logger.LogWarning("Private MCP tunnel client stopped. It will be restarted.");
        }
        finally
        {
            if (!process.HasExited)
            {
                process.Kill(entireProcessTree: true);
                using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                await process.WaitForExitAsync(deadline.Token);
            }
        }
    }

    private static async Task DrainAsync(StreamReader reader, CancellationToken cancellationToken)
    {
        var buffer = new char[1024];
        while (await reader.ReadAsync(buffer.AsMemory(), cancellationToken) > 0) { }
    }
}
