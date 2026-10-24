using System.Text.Json;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public sealed record CodexAccountInfo(string Type, string? Email, string? PlanType);
public sealed record CodexLoginInfo(string LoginId, string VerificationUrl, string UserCode, DateTimeOffset WaitingUntilUtc);
public sealed record CodexRateWindow(double UsedPercent, int? WindowDurationMins, long? ResetsAt);
public sealed record CodexRateLimit(string LimitId, CodexRateWindow? Primary, CodexRateWindow? Secondary);
public sealed record CodexAccountStatus(Guid SessionId, string State, bool QueuePaused, CodexAccountInfo? Account,
    CodexLoginInfo? Login, IReadOnlyList<CodexRateLimit> Limits, string Instruction);
public sealed record CodexAuthCommand(string RequestId, string Action, Guid ExpectedSessionId, bool Confirm, string? LoginId = null);
public sealed record CodexAuthReceipt(string RequestId, string Action, bool Duplicate, CodexAccountStatus Status);

public interface ICodexAccountClient : IAsyncDisposable
{
    Task<JsonElement> CallAsync(string method, object? parameters, CancellationToken cancellationToken);
    Task<bool> WaitForLoginAsync(string loginId, CancellationToken cancellationToken);
}

public interface ICodexAccountClientFactory
{
    Task<ICodexAccountClient> CreateAsync(CancellationToken cancellationToken);
}
