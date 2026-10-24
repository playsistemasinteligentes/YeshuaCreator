using Yeshua.OperationalIntelligence.Api.Modules.Mcp;
using Yeshua.OperationalIntelligence.Api.Repositories;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public static class AgentTaskServiceCollectionExtensions
{
    public static IServiceCollection AddAgentTasks(this IServiceCollection services)
    {
        services.AddOptions<AgentTaskOptions>().BindConfiguration(AgentTaskOptions.SectionName)
            .Validate(options => options.PollSeconds > 0 && options.MaxTurnSeconds > 0, "Agent time limits must be positive.")
            .Validate(options => options.MaxMessageChars is > 0 and <= 64000 && options.MaxResponseChars is > 0 and <= 256000,
                "Agent message bounds must be valid.")
            .Validate(options => options.MaxPendingMessages > 0, "Agent pending limit must be positive.")
            .Validate(options => options.AccountRpcTimeoutSeconds is >= 1 and <= 120 && options.LoginTimeoutSeconds is >= 1 and <= 900,
                "Codex authentication time limits must be bounded.")
            .Validate(options => !options.ChatGptAuthentication || Path.IsPathFullyQualified(options.CodexHomePath),
                "Codex authentication requires an absolute shared CODEX_HOME.")
            .ValidateOnStart();
        services.AddScoped<IAgentTaskRepository, AgentTaskRepository>();
        services.AddScoped<IAgentTaskExecutor, CodexTaskExecutor>();
        services.AddSingleton<AgentTaskExecutionControl>();
        services.AddSingleton<ICodexAccountClientFactory, CodexAccountClientFactory>();
        services.AddSingleton<CodexAccountReceiver>();
        services.AddScoped<SendAgentTaskReceiver>();
        services.AddScoped<ReadAgentTaskReceiver>();
        services.AddScoped<ProcessAgentTaskReceiver>();
        services.AddScoped<RestartAgentReceiver>();
        services.AddScoped<IMcpTool, SendAgentTaskTool>();
        services.AddScoped<IMcpTool, ReadAgentTaskTool>();
        services.AddScoped<IMcpTool, RestartAgentTool>();
        services.AddScoped<IMcpTool, CodexStatusTool>();
        services.AddScoped<IMcpTool, CodexAuthTool>();
        services.AddHostedService<AgentTaskWorker>();
        return services;
    }
}
