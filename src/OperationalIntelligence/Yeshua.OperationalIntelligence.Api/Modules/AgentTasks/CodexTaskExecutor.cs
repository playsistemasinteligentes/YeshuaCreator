using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public sealed class CodexTaskExecutor(IOptions<AgentTaskOptions> options, AgentGitWorkspace git) : IAgentTaskExecutor
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public async Task<AgentTaskExecutionResult> ExecuteAsync(
        AgentTaskWorkItem item, Func<AgentTaskProgress, CancellationToken, Task> progress,
        CancellationToken cancellationToken)
    {
        var settings = options.Value;
        if (item.IsContinuation && string.IsNullOrWhiteSpace(item.ThreadId))
            throw new ArgumentException("A sessao original desta task nao esta disponivel. A continuacao foi bloqueada sem criar outra conversa. O historico e o workspace foram preservados.");
        if (!Directory.Exists(settings.WorkspacePath) || !File.Exists(settings.RuntimeScript))
            throw new ArgumentException("Workspace ou adaptador Codex indisponivel no servidor.");
        var workspace = await git.PrepareAsync(item, cancellationToken);
        var start = new ProcessStartInfo(settings.NodeExecutable)
        {
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            WorkingDirectory = workspace
        };
        start.ArgumentList.Add(settings.RuntimeScript);
        CodexProcessEnvironment.Apply(start, settings);
        var cache = Path.Combine(Path.GetTempPath(), "yeshua-agent", item.TaskId.ToString("N"));
        Directory.CreateDirectory(cache);
        var runtimeDirectory = Path.Combine(cache, "runtime");
        Directory.CreateDirectory(runtimeDirectory);
        if (!OperatingSystem.IsWindows())
            File.SetUnixFileMode(runtimeDirectory, UnixFileMode.UserRead | UnixFileMode.UserWrite | UnixFileMode.UserExecute);
        start.Environment["XDG_RUNTIME_DIR"] = runtimeDirectory;
        start.Environment["DOTNET_CLI_HOME"] = Path.Combine(cache, "dotnet");
        start.Environment["NUGET_PACKAGES"] = Path.Combine(cache, "nuget", "packages");
        start.Environment["NUGET_HTTP_CACHE_PATH"] = Path.Combine(cache, "nuget", "http");
        using var process = new Process { StartInfo = start };
        if (!process.Start())
            throw new InvalidOperationException("Codex runtime did not start.");
        try
        {
            var drainErrors = DrainAsync(process.StandardError, cancellationToken);
            var input = JsonSerializer.Serialize(new
            {
                item.Message, item.ThreadId, item.Mode, item.IsContinuation,
                workspacePath = workspace, settings.MaxResponseChars, settings.ChatGptAuthentication,
                settings.AllowDevelopmentNetwork
            }, JsonOptions);
            await process.StandardInput.WriteLineAsync(input.AsMemory(), cancellationToken);
            process.StandardInput.Close();
            AgentTaskExecutionResult? result = null;
            var currentThreadId = item.ThreadId;
            while (await process.StandardOutput.ReadLineAsync(cancellationToken) is { } line)
            {
                if (line.Length > settings.MaxResponseChars * 6 + 1024)
                    throw new InvalidOperationException("Agent response exceeded protocol bounds.");
                using var document = JsonDocument.Parse(line);
                var root = document.RootElement;
                var type = root.GetProperty("type").GetString();
                if (type == "progress")
                {
                    var threadId = root.TryGetProperty("threadId", out var thread) ? thread.GetString() : null;
                    if (threadId?.Length > 100)
                        throw new InvalidOperationException("Invalid agent thread identifier.");
                    if (threadId is not null && currentThreadId is not null && threadId != currentThreadId)
                        throw new InvalidOperationException("Agent attempted to change the task conversation.");
                    currentThreadId ??= threadId;
                    await progress(new(threadId, root.GetProperty("description").GetString() ?? "Processando."), cancellationToken);
                }
                else if (type == "result")
                    result = new(root.GetProperty("response").GetString() ?? "", root.GetProperty("success").GetBoolean());
            }
            await process.WaitForExitAsync(cancellationToken);
            await drainErrors;
            if (result is null || process.ExitCode != 0)
                return new("O Codex nao concluiu a tarefa. Confira o login e a sessao original. Nao foi criada outra conversa nem repetido o pedido; historico e workspace continuam preservados.", false);
            if (result.Success)
            {
                var publication = await git.PublishAsync(item, workspace, result.Response, cancellationToken);
                if (publication.Length > 0)
                    result = new(publication + "\n\n" + result.Response, true);
            }
            return result;
        }
        finally
        {
            if (!process.HasExited)
            {
                process.Kill(entireProcessTree: true);
                using var stopDeadline = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                await process.WaitForExitAsync(stopDeadline.Token);
            }
        }
    }

    private static async Task DrainAsync(StreamReader reader, CancellationToken cancellationToken)
    {
        var buffer = new char[1024];
        while (await reader.ReadAsync(buffer.AsMemory(), cancellationToken) > 0) { }
    }
}
