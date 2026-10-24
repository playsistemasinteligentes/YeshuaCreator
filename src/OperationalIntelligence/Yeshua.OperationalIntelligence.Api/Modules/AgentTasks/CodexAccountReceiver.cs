using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public sealed class CodexAccountReceiver(
    ICodexAccountClientFactory clients, AgentTaskExecutionControl control, IOptions<AgentTaskOptions> options) : IAsyncDisposable
{
    private readonly SemaphoreSlim _mutex = new(1);
    private readonly CancellationTokenSource _stop = new();
    private readonly Dictionary<string, CodexAuthCommand> _requests = new(StringComparer.Ordinal);
    private Guid _sessionId = Guid.NewGuid();
    private bool _initialized;
    private bool _ready;
    private bool _requiresExplicitLogin;
    private string _state = "SignedOut";
    private CodexAccountInfo? _account;
    private PendingLogin? _pending;
    private Task? _monitor;
    private DateTimeOffset _probeAfter;
    private string ReauthenticationMarker => Path.Combine(options.Value.CodexHomePath, ".yeshua-reauthentication-required");

    public async Task<bool> CanExecuteAsync(CancellationToken token)
    {
        if (!options.Value.ChatGptAuthentication) return true;
        if (!Volatile.Read(ref _initialized) || (_state == "Unavailable" && DateTimeOffset.UtcNow >= _probeAfter))
            await ReadAsync(false, token);
        return Volatile.Read(ref _ready);
    }

    public async Task<CodexAccountStatus> ReadAsync(bool includeLimits, CancellationToken token)
    {
        await _mutex.WaitAsync(token);
        try
        {
            if (!Enabled) return Snapshot();
            if (_pending is not null) return Snapshot();
            try
            {
                await using var client = await clients.CreateAsync(token);
                var account = CodexAccountProjection.Account(await client.CallAsync("account/read", new { refreshToken = false }, token));
                if (_initialized && account != _account) _sessionId = Guid.NewGuid();
                _account = account;
                _ready = account?.Type == "chatgpt" && !_requiresExplicitLogin && !File.Exists(ReauthenticationMarker);
                _state = _ready ? "Ready" : account is null ? "SignedOut" : "ReauthenticationRequired";
                control.SetAuthenticationReady(_ready);
                _initialized = true;
                IReadOnlyList<CodexRateLimit> limits = [];
                if (includeLimits && _ready)
                {
                    try { limits = CodexAccountProjection.Limits(await client.CallAsync("account/rateLimits/read", null, token)); }
                    catch (OperationCanceledException) when (token.IsCancellationRequested) { throw; }
                    catch { return Snapshot(instruction: "Conta consultada; limites indisponiveis. Valores ausentes nao significam cota zero."); }
                }
                return Snapshot(limits);
            }
            catch (OperationCanceledException) when (token.IsCancellationRequested) { throw; }
            catch
            {
                _ready = false;
                _account = null;
                control.SetAuthenticationReady(false);
                _initialized = true;
                _state = "Unavailable";
                _probeAfter = DateTimeOffset.UtcNow.AddSeconds(30);
                return Snapshot(instruction: "Nao foi possivel consultar o Codex local. A fila permanece pausada; nenhuma ordem ou credencial foi reenviada.");
            }
        }
        finally { _mutex.Release(); }
    }

    public async Task<CodexAuthReceipt> ExecuteAsync(CodexAuthCommand command, CancellationToken token)
    {
        Validate(command);
        await _mutex.WaitAsync(token);
        try
        {
            if (_requests.TryGetValue(command.RequestId, out var previous))
            {
                if (previous != command) throw new ArgumentException("requestId ja foi usado para outra operacao de autenticacao.");
                return new(command.RequestId, command.Action, true, Snapshot());
            }
            if (command.ExpectedSessionId != _sessionId)
                throw new ArgumentException("A autenticacao mudou. Consulte yeshua_codex_status antes de uma nova operacao.");
            if (command.Action == "cancel")
            {
                if (_pending is null || _pending.Info.LoginId != command.LoginId)
                    throw new ArgumentException("Este login nao esta mais pendente. Consulte yeshua_codex_status.");
                Remember(command);
                var pending = _pending;
                _sessionId = Guid.NewGuid();
                try { await pending.Client.CallAsync("account/login/cancel", new { loginId = command.LoginId }, token); }
                finally { await ClosePendingAsync(pending); }
                _state = "SignedOut";
                return new(command.RequestId, command.Action, false, Snapshot());
            }
            if (_pending is not null)
                throw new ArgumentException("Ja existe um login pendente. Consulte-o ou cancele-o explicitamente.");
            var pause = control.PauseForAuthentication();
            ICodexAccountClient? client = null;
            Remember(command);
            _sessionId = Guid.NewGuid();
            _ready = false;
            _requiresExplicitLogin = true;
            _initialized = true;
            _account = null;
            _state = "SignedOut";
            try
            {
                Directory.CreateDirectory(options.Value.CodexHomePath);
                await File.WriteAllTextAsync(ReauthenticationMarker, "Explicit authentication completion required.\n", token);
                client = await clients.CreateAsync(token);
                // A switch explicitly signs out first: a failed login must not silently reuse the old account.
                await client.CallAsync("account/logout", null, token);
                if (command.Action == "login")
                {
                    var result = await client.CallAsync("account/login/start", new { type = "chatgptDeviceCode" }, token);
                    var id = CodexAccountProjection.Text(result, "loginId", 100);
                    var url = CodexAccountProjection.Text(result, "verificationUrl", 200);
                    var code = CodexAccountProjection.Text(result, "userCode", 32);
                    if (!Guid.TryParse(id, out _) || url != "https://auth.openai.com/codex/device" ||
                        code is null || code.Length < 4 || code.Any(c => !(char.IsAsciiLetterOrDigit(c) || c == '-')))
                        throw new InvalidOperationException("Invalid device authorization response.");
                    var pending = new PendingLogin(client, pause,
                        new(id!, url, code, DateTimeOffset.UtcNow.AddSeconds(options.Value.LoginTimeoutSeconds)), _stop.Token);
                    _pending = pending;
                    _state = "LoginPending";
                    _monitor = MonitorAsync(pending);
                    client = null;
                    pause = null;
                }
                return new(command.RequestId, command.Action, false, Snapshot());
            }
            catch (OperationCanceledException) when (token.IsCancellationRequested) { throw; }
            catch
            {
                _state = "Unavailable";
                _probeAfter = DateTimeOffset.UtcNow.AddSeconds(30);
                return new(command.RequestId, command.Action, false,
                    Snapshot(instruction: "Autenticacao nao concluida. Consulte o estado antes de outro pedido; nao houve repeticao automatica."));
            }
            finally
            {
                try { if (client is not null) await client.DisposeAsync(); }
                finally { pause?.Dispose(); }
            }
        }
        finally { _mutex.Release(); }
    }

    private async Task MonitorAsync(PendingLogin pending)
    {
        bool success;
        try
        {
            pending.Stop.CancelAfter(TimeSpan.FromSeconds(options.Value.LoginTimeoutSeconds));
            success = await pending.Client.WaitForLoginAsync(pending.Info.LoginId, pending.Stop.Token);
        }
        catch { success = false; }
        try { await _mutex.WaitAsync(_stop.Token); }
        catch (OperationCanceledException) { return; }
        try
        {
            if (!ReferenceEquals(_pending, pending)) return;
            try
            {
                _account = success ? CodexAccountProjection.Account(
                    await pending.Client.CallAsync("account/read", new { refreshToken = false }, _stop.Token)) : null;
                _ready = success && _account?.Type == "chatgpt";
                if (_ready)
                {
                    File.Delete(ReauthenticationMarker);
                    _requiresExplicitLogin = false;
                }
                _state = _ready ? "Ready" : "SignedOut";
            }
            catch { _ready = false; _account = null; _state = "Unavailable"; }
            control.SetAuthenticationReady(_ready);
            _sessionId = Guid.NewGuid();
            await ClosePendingAsync(pending);
        }
        finally { _mutex.Release(); }
    }

    private async Task ClosePendingAsync(PendingLogin pending)
    {
        _pending = null;
        await pending.Stop.CancelAsync();
        try { await pending.Client.DisposeAsync(); }
        finally { pending.Pause.Dispose(); pending.Stop.Dispose(); }
    }

    private bool Enabled => options.Value.Enabled && options.Value.ChatGptAuthentication;

    private CodexAccountStatus Snapshot(IReadOnlyList<CodexRateLimit>? limits = null, string? instruction = null) =>
        new(_sessionId, Enabled ? _state : "Disabled", Enabled && (!_ready || _pending is not null), _account,
            _pending?.Info, limits ?? [], instruction ?? (!Enabled
                ? "O gerenciamento de login ChatGPT esta desabilitado nesta instancia. Consulte a configuracao do servidor."
                : _pending is not null
                ? "O operador deve abrir a pagina oficial e informar o codigo temporario. Consulte yeshua_codex_status ate Ready. Nao compartilhe o codigo com terceiros."
                : "Conta e limites pertencem a esta instancia administrativa. A task, thread e workspace nao mudam com o login. Continue pelo mesmo taskId com uma nova ordem explicita; nao reenvie trabalho interrompido automaticamente."));

    private void Validate(CodexAuthCommand command)
    {
        if (!Enabled) throw new ArgumentException("Autenticacao ChatGPT do agente esta desabilitada neste servidor.");
        if (!command.Confirm) throw new ArgumentException("Autenticacao exige pedido explicito do operador e confirm=true.");
        if (command.Action is not ("login" or "logout" or "cancel") || command.ExpectedSessionId == Guid.Empty ||
            string.IsNullOrWhiteSpace(command.RequestId) || command.RequestId.Length > 100 || command.RequestId.Trim() != command.RequestId ||
            (command.Action == "cancel" && !Guid.TryParse(command.LoginId, out _)) ||
            (command.Action != "cancel" && command.LoginId is not null))
            throw new ArgumentException("Informe action, requestId e expectedSessionId consultado; cancel tambem exige loginId.");
    }

    private void Remember(CodexAuthCommand command)
    {
        if (_requests.Count == 32) _requests.Remove(_requests.Keys.First());
        _requests.Add(command.RequestId, command);
    }

    public async ValueTask DisposeAsync()
    {
        await _stop.CancelAsync();
        await _mutex.WaitAsync();
        try { if (_pending is not null) await ClosePendingAsync(_pending); }
        finally { _mutex.Release(); }
        if (_monitor is not null) await _monitor;
        _stop.Dispose();
    }

    private sealed class PendingLogin(ICodexAccountClient client, IDisposable pause, CodexLoginInfo info, CancellationToken token)
    {
        public ICodexAccountClient Client { get; } = client;
        public IDisposable Pause { get; } = pause;
        public CodexLoginInfo Info { get; } = info;
        public CancellationTokenSource Stop { get; } = CancellationTokenSource.CreateLinkedTokenSource(token);
    }
}
