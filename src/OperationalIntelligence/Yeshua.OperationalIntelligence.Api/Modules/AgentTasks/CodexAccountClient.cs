using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public sealed class CodexAccountClientFactory(IOptions<AgentTaskOptions> options) : ICodexAccountClientFactory
{
    public async Task<ICodexAccountClient> CreateAsync(CancellationToken cancellationToken)
    {
        var settings = options.Value;
        Directory.CreateDirectory(settings.CodexHomePath);
        var start = new ProcessStartInfo(settings.CodexExecutable)
        {
            UseShellExecute = false, CreateNoWindow = true,
            RedirectStandardInput = true, RedirectStandardOutput = true, RedirectStandardError = true,
            WorkingDirectory = settings.CodexHomePath
        };
        CodexProcessEnvironment.Apply(start, settings);
        start.ArgumentList.Add("-c");
        start.ArgumentList.Add("forced_login_method=\"chatgpt\"");
        start.ArgumentList.Add("-c");
        start.ArgumentList.Add("cli_auth_credentials_store=\"file\"");
        start.ArgumentList.Add("app-server");
        return await CodexAccountClient.StartAsync(start, TimeSpan.FromSeconds(settings.AccountRpcTimeoutSeconds), cancellationToken);
    }
}

// Private stdio only. No raw RPC result, stderr or OAuth error is published to MCP.
public sealed class CodexAccountClient : ICodexAccountClient
{
    private readonly Process _process;
    private readonly TimeSpan _timeout;
    private readonly CancellationTokenSource _stop = new();
    private readonly SemaphoreSlim _write = new(1);
    private readonly ConcurrentDictionary<long, TaskCompletionSource<JsonElement>> _requests = new();
    private readonly ConcurrentDictionary<string, TaskCompletionSource<bool>> _logins = new(StringComparer.Ordinal);
    private readonly Task _pump;
    private readonly Task _stderr;
    private long _nextId;
    private int _closed;

    private CodexAccountClient(Process process, TimeSpan timeout)
    {
        _process = process;
        _timeout = timeout;
        _pump = PumpAsync();
        _stderr = DrainErrorsAsync();
    }

    public static async Task<CodexAccountClient> StartAsync(ProcessStartInfo start, TimeSpan timeout, CancellationToken token)
    {
        var process = new Process { StartInfo = start };
        try
        {
            if (!process.Start()) throw new InvalidOperationException("Codex account process unavailable.");
        }
        catch { process.Dispose(); throw; }
        var client = new CodexAccountClient(process, timeout);
        try
        {
            await client.CallAsync("initialize", new
            {
                clientInfo = new { name = "yeshua_operational_intelligence", title = "Yeshua Operational Intelligence", version = "1.0.0" }
            }, token);
            await client.WriteAsync(new { method = "initialized", @params = new { } }, token);
            return client;
        }
        catch { await client.DisposeAsync(); throw; }
    }

    public async Task<JsonElement> CallAsync(string method, object? parameters, CancellationToken cancellationToken)
    {
        if (Volatile.Read(ref _closed) != 0) throw new InvalidOperationException("Codex account connection unavailable.");
        if (method is not ("initialize" or "account/read" or "account/rateLimits/read" or
            "account/login/start" or "account/login/cancel" or "account/logout"))
            throw new ArgumentException("Operacao de conta nao permitida.");
        var id = Interlocked.Increment(ref _nextId);
        var completion = new TaskCompletionSource<JsonElement>(TaskCreationOptions.RunContinuationsAsynchronously);
        _requests[id] = completion;
        using var deadline = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _stop.Token);
        deadline.CancelAfter(_timeout);
        try
        {
            await WriteAsync(new { id, method, @params = parameters }, deadline.Token);
            return await completion.Task.WaitAsync(deadline.Token);
        }
        finally { _requests.TryRemove(id, out _); }
    }

    public Task<bool> WaitForLoginAsync(string loginId, CancellationToken token)
    {
        var completion = _logins.GetOrAdd(loginId, _ => new(TaskCreationOptions.RunContinuationsAsynchronously));
        if (Volatile.Read(ref _closed) != 0) completion.TrySetResult(false);
        return completion.Task.WaitAsync(token);
    }

    private async Task WriteAsync(object message, CancellationToken token)
    {
        await _write.WaitAsync(token);
        try
        {
            await _process.StandardInput.WriteLineAsync(JsonSerializer.Serialize(message).AsMemory(), token);
            await _process.StandardInput.FlushAsync(token);
        }
        finally { _write.Release(); }
    }

    private async Task PumpAsync()
    {
        try
        {
            while (await _process.StandardOutput.ReadLineAsync(_stop.Token) is { } line)
            {
                if (line.Length > 256000) throw new InvalidOperationException("Account protocol bounds exceeded.");
                using var document = JsonDocument.Parse(line);
                var root = document.RootElement;
                if (root.TryGetProperty("id", out var id) && id.TryGetInt64(out var number) &&
                    _requests.TryGetValue(number, out var completion))
                {
                    if (root.TryGetProperty("result", out var result)) completion.TrySetResult(result.Clone());
                    else completion.TrySetException(new InvalidOperationException("Codex account request failed."));
                }
                else if (root.TryGetProperty("method", out var method) && method.GetString() == "account/login/completed")
                {
                    var values = root.GetProperty("params");
                    var loginId = values.GetProperty("loginId").GetString();
                    if (loginId is not null && loginId.Length <= 100)
                        _logins.GetOrAdd(loginId, _ => new(TaskCreationOptions.RunContinuationsAsynchronously))
                            .TrySetResult(values.GetProperty("success").GetBoolean());
                }
            }
        }
        catch { }
        finally
        {
            Interlocked.Exchange(ref _closed, 1);
            foreach (var request in _requests.Values)
                request.TrySetException(new InvalidOperationException("Codex account connection unavailable."));
            foreach (var login in _logins.Values) login.TrySetResult(false);
        }
    }

    private async Task DrainErrorsAsync()
    {
        var buffer = new char[1024];
        try { while (await _process.StandardError.ReadAsync(buffer.AsMemory(), _stop.Token) > 0) { } }
        catch { }
    }

    public async ValueTask DisposeAsync()
    {
        await _stop.CancelAsync();
        try
        {
            if (!_process.HasExited) _process.Kill(entireProcessTree: true);
            using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await _process.WaitForExitAsync(deadline.Token);
            await Task.WhenAll(_pump, _stderr).WaitAsync(deadline.Token);
        }
        finally { _process.Dispose(); _stop.Dispose(); }
    }
}
