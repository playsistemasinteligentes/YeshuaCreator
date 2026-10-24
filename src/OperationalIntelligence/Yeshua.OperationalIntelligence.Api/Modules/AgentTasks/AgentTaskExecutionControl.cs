namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

// One local worker owns the execution. Recovery never starts or replays work.
public sealed class AgentTaskExecutionControl
{
    private readonly object _gate = new();
    private Execution? _active;
    private bool _dispatchReserved;
    private bool _authenticationPaused;
    private bool _authenticationRequired;

    public void SetAuthenticationReady(bool ready)
    {
        lock (_gate) _authenticationRequired = !ready;
    }

    public IDisposable? TryReserveDispatch()
    {
        lock (_gate)
        {
            if (_authenticationRequired || _authenticationPaused || _dispatchReserved || _active is not null) return null;
            _dispatchReserved = true;
            return new Reservation(this, authentication: false);
        }
    }

    public IDisposable PauseForAuthentication()
    {
        lock (_gate)
        {
            if (_dispatchReserved || _active is not null || _authenticationPaused)
                throw new ArgumentException("Aguarde a execucao atual terminar antes de alterar a autenticacao do Codex.");
            _authenticationPaused = true;
            _authenticationRequired = true;
            return new Reservation(this, authentication: true);
        }
    }

    public AgentActiveExecution? Read()
    {
        lock (_gate)
            return _active is null ? null
                : new(_active.Item.TaskId, _active.Item.RequestId, _active.RestartRequested);
    }

    public Execution Begin(AgentTaskWorkItem item, CancellationToken stoppingToken)
    {
        lock (_gate)
        {
            if (_active is not null || _authenticationPaused || _authenticationRequired)
                throw new InvalidOperationException("An agent execution is already active.");
            return _active = new Execution(this, item, stoppingToken);
        }
    }

    private sealed class Reservation(AgentTaskExecutionControl owner, bool authentication) : IDisposable
    {
        private bool _disposed;
        public void Dispose()
        {
            lock (owner._gate)
            {
                if (_disposed) return;
                _disposed = true;
                if (authentication) owner._authenticationPaused = false;
                else owner._dispatchReserved = false;
            }
        }
    }

    public async Task<AgentRestartReceipt> RequestRestartAsync(RestartAgentCommand command)
    {
        Task cancel;
        lock (_gate)
        {
            if (_active is null || _active.Item.TaskId != command.TaskId ||
                !string.Equals(_active.Item.RequestId, command.RequestId, StringComparison.Ordinal))
                return new(command.TaskId, command.RequestId, "NotRunning",
                    "Esta ordem nao esta em execucao neste agente. Nada foi reiniciado. Consulte o estado atual.");
            if (_active.RestartRequested)
                return new(command.TaskId, command.RequestId, "AlreadyRequested",
                    "A interrupcao desta ordem ja foi solicitada. Consulte yeshua_task_read; nao reenvie a ordem.");
            _active.RestartRequested = true;
            cancel = _active.Cancellation.CancelAsync();
        }
        await cancel;
        return new(command.TaskId, command.RequestId, "RestartRequested",
            "Interrupcao solicitada somente para esta execucao. Aguarde Interrupted em yeshua_task_read. Confira o workspace antes de enviar uma nova ordem. Nenhum trabalho foi repetido e nenhum container foi reiniciado.");
    }

    private bool Finish(Execution execution)
    {
        lock (_gate)
        {
            if (ReferenceEquals(_active, execution))
                _active = null;
            return execution.RestartRequested;
        }
    }

    public sealed class Execution : IDisposable
    {
        private readonly AgentTaskExecutionControl _owner;
        internal AgentTaskWorkItem Item { get; }
        internal CancellationTokenSource Cancellation { get; }
        internal bool RestartRequested { get; set; }
        public CancellationToken Token => Cancellation.Token;

        internal Execution(AgentTaskExecutionControl owner, AgentTaskWorkItem item, CancellationToken stoppingToken)
        {
            _owner = owner;
            Item = item;
            Cancellation = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
        }

        public bool Finish() => _owner.Finish(this);

        public void Dispose()
        {
            Finish();
            Cancellation.Dispose();
        }
    }
}
