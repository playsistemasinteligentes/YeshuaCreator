namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public sealed class AgentTaskOptions
{
    public const string SectionName = "AgentTasks";
    public bool Enabled { get; init; }
    public bool AllowWorkspaceWrite { get; init; }
    public bool ChatGptAuthentication { get; init; }
    public string CodexHomePath { get; init; } = "/home/agent/.codex";
    public string CodexExecutable { get; init; } = "codex";
    public int AccountRpcTimeoutSeconds { get; init; } = 30;
    public int LoginTimeoutSeconds { get; init; } = 600;
    public string WorkspacePath { get; init; } = "/workspace/YeshuaCreator";
    public string NodeExecutable { get; init; } = "node";
    public string RuntimeScript { get; init; } = "/app/agent/codex-task.mjs";
    public int MaxMessageChars { get; init; } = 16000;
    public int MaxResponseChars { get; init; } = 64000;
    public int MaxPendingMessages { get; init; } = 100;
    public int MaxTurnSeconds { get; init; } = 1800;
    public int PollSeconds { get; init; } = 2;
}
