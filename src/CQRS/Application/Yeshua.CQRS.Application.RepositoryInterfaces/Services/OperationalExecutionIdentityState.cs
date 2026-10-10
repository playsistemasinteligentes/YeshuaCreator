using Dominio.Operational;
using System.Threading;

namespace Aplication.Interfaces.Services;

public static class OperationalExecutionHeaders
{
    public const string RootOperationId = "X-Yeshua-Root-Operation-Id";
    public const string OperationId = "X-Yeshua-Operation-Id";
    public const string ExecutionId = "X-Yeshua-Execution-Id";
    public const string CausationId = "X-Yeshua-Causation-Id";
}

public sealed class OperationalExecutionIdentityState
{
    private const int MaximumExternalIdLength = 128;
    private readonly AsyncLocal<Frame?> _current = new();
    private string? _rootOperationId;
    private string? _incomingOperationId;
    private string? _incomingExecutionId;
    private string? _incomingCausationId;

    public OperationalExecutionIdentityState(
        string? rootOperationId = null,
        string? causationId = null,
        string? operationId = null,
        string? executionId = null)
    {
        _rootOperationId = NormalizeExternalId(rootOperationId);
        _incomingOperationId = NormalizeExternalId(operationId);
        _incomingExecutionId = NormalizeExternalId(executionId);
        _incomingCausationId = NormalizeExternalId(causationId);
    }

    public OperationalExecutionIdentity Current
    {
        get
        {
            var frame = _current.Value;
            if (frame is not null)
                return frame.Identity;

            var rootOperationId = GetOrCreateRootOperationId();
            return new OperationalExecutionIdentity(
                rootOperationId,
                _incomingOperationId ?? rootOperationId,
                _incomingExecutionId ?? rootOperationId,
                _incomingCausationId);
        }
    }

    public bool TryGetCurrent(out OperationalExecutionIdentity identity)
    {
        var frame = _current.Value;
        if (frame is null)
        {
            identity = default;
            return false;
        }

        identity = frame.Identity;
        return true;
    }

    public IDisposable Begin(
        string operation,
        string? operationId = null,
        string? causationId = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(operation);

        var previous = _current.Value;
        var identity = new OperationalExecutionIdentity(
            previous?.Identity.RootOperationId ?? GetOrCreateRootOperationId(),
            NormalizeExternalId(operationId) ??
                (previous is null ? _incomingOperationId : null) ??
                CreateId(),
            CreateId(),
            NormalizeExternalId(causationId) ??
                previous?.Identity.ExecutionId ??
                _incomingExecutionId ??
                _incomingCausationId);
        var frame = new Frame(identity, previous);
        _current.Value = frame;
        return new Scope(this, frame);
    }

    public IDisposable BeginFrom(
        OperationalExecutionIdentity parentIdentity,
        string operation,
        bool continueOperation = true)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(operation);

        var previous = _current.Value;
        var parentRoot = NormalizeExternalId(parentIdentity.RootOperationId);
        var parentOperation = NormalizeExternalId(parentIdentity.OperationId);
        var parentExecution = NormalizeExternalId(parentIdentity.ExecutionId);
        var parentCausation = NormalizeExternalId(parentIdentity.CausationId);
        var identity = new OperationalExecutionIdentity(
            parentRoot ?? previous?.Identity.RootOperationId ?? GetOrCreateRootOperationId(),
            continueOperation ? parentOperation ?? CreateId() : CreateId(),
            CreateId(),
            parentExecution ?? parentCausation);
        var frame = new Frame(identity, previous);
        _current.Value = frame;
        return new Scope(this, frame);
    }

    public void Set(string rootOperationId, string? causationId = null)
    {
        var normalizedRoot = NormalizeExternalId(rootOperationId);
        if (normalizedRoot is null)
            throw new ArgumentException("Invalid root operation id.", nameof(rootOperationId));

        Interlocked.Exchange(ref _rootOperationId, normalizedRoot);
        Interlocked.Exchange(ref _incomingOperationId, null);
        Interlocked.Exchange(ref _incomingExecutionId, null);
        Interlocked.Exchange(ref _incomingCausationId, NormalizeExternalId(causationId));
    }

    public static string? NormalizeExternalId(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        var candidate = value.Trim();
        if (candidate.Length > MaximumExternalIdLength)
            return null;

        foreach (var character in candidate)
        {
            if (!char.IsLetterOrDigit(character) &&
                character is not '-' and not '_' and not '.' and not ':')
            {
                return null;
            }
        }

        return candidate;
    }

    private string GetOrCreateRootOperationId()
    {
        var current = Volatile.Read(ref _rootOperationId);
        if (current is not null)
            return current;

        var created = CreateId();
        return Interlocked.CompareExchange(ref _rootOperationId, created, null) ?? created;
    }

    private static string CreateId() => Guid.NewGuid().ToString("N");

    private void End(Frame frame)
    {
        if (ReferenceEquals(_current.Value, frame))
            _current.Value = frame.Previous;
    }

    private sealed record Frame(
        OperationalExecutionIdentity Identity,
        Frame? Previous);

    private sealed class Scope : IDisposable
    {
        private OperationalExecutionIdentityState? _owner;
        private readonly Frame _frame;

        public Scope(OperationalExecutionIdentityState owner, Frame frame)
        {
            _owner = owner;
            _frame = frame;
        }

        public void Dispose()
        {
            Interlocked.Exchange(ref _owner, null)?.End(_frame);
        }
    }
}
