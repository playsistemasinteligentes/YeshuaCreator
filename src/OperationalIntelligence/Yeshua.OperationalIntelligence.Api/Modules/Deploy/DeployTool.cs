using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;

namespace Yeshua.OperationalIntelligence.Api.Modules.Deploy;

public sealed class DeployOptions
{
    // Server configuration only. The SSH account MUST have a forced command.
    public string Destination { get; init; } = "";
    public string IdentityFile { get; init; } = "";
    public string KnownHostsFile { get; init; } = "";
}

public sealed record DeployCommand(string Action, string RequestId, string? Target = null);

public interface IDeployBridge
{
    Task<JsonElement> SendAsync(DeployCommand command, CancellationToken cancellationToken);
}

public sealed class DeployReceiver(IDeployBridge bridge)
{
    public static readonly string[] Targets = ["all", "central", "clinica", "aps-adm", "fiscal", "memorias", "shared"];

    public Task<JsonElement> ExecuteAsync(DeployCommand command, CancellationToken cancellationToken)
    {
        if (!Regex.IsMatch(command.RequestId, "\\A[a-zA-Z0-9_-]{1,80}\\z"))
            throw new ArgumentException("Invalid requestId.");
        if (command.Action == "execute")
        {
            if (!Targets.Contains(command.Target, StringComparer.Ordinal))
                throw new ArgumentException("Execution requires an allowed target. Full deployment uses all.");
        }
        else if (command.Action != "status" || command.Target is not null)
            throw new ArgumentException("Status requires only action and requestId.");
        return bridge.SendAsync(command, cancellationToken);
    }
}

public sealed class SshDeployBridge(IOptions<DeployOptions> options) : IDeployBridge
{
    public async Task<JsonElement> SendAsync(DeployCommand command, CancellationToken cancellationToken)
    {
        var config = options.Value;
        if (!Regex.IsMatch(config.Destination, "\\Ayeshua-deploy@[a-zA-Z0-9][a-zA-Z0-9.-]*\\z") ||
            !Path.IsPathFullyQualified(config.IdentityFile) || !Path.IsPathFullyQualified(config.KnownHostsFile))
            throw new ArgumentException("Host administrator must configure the restricted SSH destination, private key and pinned known_hosts.");
        var start = new ProcessStartInfo("/usr/bin/ssh")
        {
            UseShellExecute = false, RedirectStandardInput = true,
            RedirectStandardOutput = true, RedirectStandardError = true
        };
        foreach (var argument in new[] { "-F", "/dev/null", "-T", "-o", "BatchMode=yes", "-o", "StrictHostKeyChecking=yes",
                     "-o", "GlobalKnownHostsFile=/dev/null", "-o", "IdentitiesOnly=yes", "-o", "IdentityAgent=none", "-o", "ClearAllForwardings=yes",
                     "-o", "ConnectTimeout=5", "-o", "UserKnownHostsFile=" + config.KnownHostsFile,
                     "-i", config.IdentityFile, config.Destination })
            start.ArgumentList.Add(argument);
        start.Environment.Clear();
        start.Environment["PATH"] = "/usr/bin:/bin";
        using var deadline = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        deadline.CancelAfter(TimeSpan.FromSeconds(15));
        using var process = Process.Start(start) ?? throw new IOException("Bridge unavailable.");
        try
        {
            // Bound both streams, including a misconfigured forced command. Never return SSH stderr.
            var output = ReadBoundedAsync(process.StandardOutput, deadline.Token);
            var errors = ReadBoundedAsync(process.StandardError, deadline.Token);
            var payload = new Dictionary<string, object?> { ["action"] = command.Action, ["requestId"] = command.RequestId };
            if (command.Action == "execute")
            {
                payload["target"] = command.Target;
            }
            await process.StandardInput.WriteAsync(JsonSerializer.Serialize(payload).AsMemory(), deadline.Token);
            process.StandardInput.Close();
            await process.WaitForExitAsync(deadline.Token);
            await errors;
            if (process.ExitCode != 0) throw new IOException("Bridge transport unavailable; query status using the same requestId.");
            using var document = JsonDocument.Parse(await output);
            return document.RootElement.Clone();
        }
        finally
        {
            if (!process.HasExited) process.Kill(entireProcessTree: true);
        }
    }

    private static async Task<string> ReadBoundedAsync(StreamReader reader, CancellationToken token)
    {
        var buffer = new char[8193];
        var length = 0;
        while (length < buffer.Length)
        {
            var count = await reader.ReadAsync(buffer.AsMemory(length), token);
            if (count == 0) return new string(buffer, 0, length);
            length += count;
        }
        throw new IOException("Invalid bridge response.");
    }
}

public sealed class DeployTool(DeployReceiver receiver) : IMcpTool
{
    public string Name => "yeshua_deploy";
    public bool IsReadOnly => false;
    public string Description => "Deploy through the existing private administrative MCP connection. Calls only infra/docker/deploy.sh with an allowed target (all for full deployment) using the latest main through the script's Git update flow. releaseTag is rejected; version selection is disabled. requestId prevents duplicate execution; reuse it to read status after connection loss. No extra approval or confirmation. No arbitrary commands, restart, merge or cleanup.";
    public object InputSchema => new
    {
        type = "object", additionalProperties = false, required = new[] { "action", "requestId" },
        properties = new
        {
            action = new { type = "string", @enum = new[] { "execute", "status" } },
            requestId = new { type = "string", pattern = "^[a-zA-Z0-9_-]{1,80}$" },
            target = new { type = "string", @enum = DeployReceiver.Targets }
        }
    };

    public async Task<McpToolResult> CallAsync(JsonElement arguments, CancellationToken cancellationToken)
    {
        if (arguments.TryGetProperty("releaseTag", out _))
            throw new ArgumentException("releaseTag is no longer supported. Omit it; deploy uses the latest main.");
        foreach (var property in arguments.EnumerateObject())
            if (property.Name is not ("action" or "requestId" or "target"))
                throw new ArgumentException("Unsupported deploy argument.");
        string? Read(string name) => arguments.TryGetProperty(name, out var item) && item.ValueKind == JsonValueKind.String
            ? item.GetString() : arguments.TryGetProperty(name, out _) ? throw new ArgumentException("Invalid " + name) : null;
        var action = Read("action") ?? "";
        if (action == "status" && arguments.EnumerateObject().Any(p => p.Name is not ("action" or "requestId")))
            throw new ArgumentException("Status requires only action and requestId.");
        try
        {
            var result = await receiver.ExecuteAsync(new(action, Read("requestId") ?? "", Read("target")), cancellationToken);
            return result.TryGetProperty("status", out var status) && status.GetString() == "Blocked"
                ? McpToolResult.Error("Deploy bridge unavailable. Check host bridge configuration and query the same requestId.", result)
                : McpToolResult.Ok("Deploy receipt. Query status with the same requestId after any connection loss.", result);
        }
        catch (Exception error) when (error is IOException or OperationCanceledException or JsonException or System.ComponentModel.Win32Exception)
        {
            return McpToolResult.Error("Bridge unavailable or response uncertain. Query status with the same requestId; no automatic replay. Check bridge availability and configuration.");
        }
    }
}
