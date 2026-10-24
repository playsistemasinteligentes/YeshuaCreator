using System.Collections.Concurrent;
using System.Text.Json;
using Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

namespace Yeshua.OperationalIntelligence.Api.Tests;

internal sealed class CodexAccountTestFactory : ICodexAccountClientFactory
{
    public const string Secret = "fixture-private-token-never-publish";
    public CodexAccountInfo? Account { get; set; } = new("chatgpt", "account-a@example.test", "plus");
    public ConcurrentQueue<string> Calls { get; } = new();
    public Client? Latest { get; private set; }
    public bool FailLogout { get; set; }
    public string VerificationUrl { get; set; } = "https://auth.openai.com/codex/device";
    public bool CompleteImmediately { get; set; }

    public Task<ICodexAccountClient> CreateAsync(CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        Latest = new Client(this);
        return Task.FromResult<ICodexAccountClient>(Latest);
    }

    public void CompleteLogin(string email = "account-b@example.test")
    {
        Account = new("chatgpt", email, "pro");
        Latest!.Completion.TrySetResult(true);
    }

    internal sealed class Client(CodexAccountTestFactory owner) : ICodexAccountClient
    {
        public string LoginId { get; } = Guid.NewGuid().ToString();
        public TaskCompletionSource<bool> Completion { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public bool Disposed { get; private set; }
        public Task<JsonElement> CallAsync(string method, object? parameters, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            owner.Calls.Enqueue(method);
            object result;
            switch (method)
            {
                case "account/read":
                    result = new { account = owner.Account is null ? null : new
                    {
                        type = owner.Account.Type, email = owner.Account.Email, planType = owner.Account.PlanType,
                        accessToken = Secret, refreshToken = Secret
                    } };
                    break;
                case "account/rateLimits/read":
                    result = new { rateLimitsByLimitId = new { codex = new
                    {
                        primary = new { usedPercent = 25, windowDurationMins = 300, resetsAt = 1800000000L },
                        secondary = (object?)null, accessToken = Secret
                    } }, secret = Secret };
                    break;
                case "account/logout":
                    if (owner.FailLogout) throw new InvalidOperationException(Secret);
                    owner.Account = null;
                    result = new { };
                    break;
                case "account/login/start":
                    Assert.AreEqual("chatgptDeviceCode", JsonSerializer.SerializeToElement(parameters).GetProperty("type").GetString());
                    if (owner.CompleteImmediately)
                    {
                        owner.Account = new("chatgpt", "account-b@example.test", "pro");
                        Completion.TrySetResult(true);
                    }
                    result = new { loginId = LoginId, verificationUrl = owner.VerificationUrl, userCode = "TEST-1234", token = Secret };
                    break;
                case "account/login/cancel":
                    Completion.TrySetResult(false);
                    result = new { };
                    break;
                default: throw new InvalidOperationException("Unexpected fixture method.");
            }
            return Task.FromResult(JsonSerializer.SerializeToElement(result));
        }
        public Task<bool> WaitForLoginAsync(string loginId, CancellationToken token) => Completion.Task.WaitAsync(token);
        public ValueTask DisposeAsync() { Disposed = true; Completion.TrySetResult(false); return ValueTask.CompletedTask; }
    }
}
