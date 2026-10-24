using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public sealed class AgentTaskWorker(
    IServiceScopeFactory scopeFactory, IOptions<AgentTaskOptions> options, ILogger<AgentTaskWorker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!options.Value.Enabled)
            return;
        var recovered = false;
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = scopeFactory.CreateScope();
                var repository = scope.ServiceProvider.GetRequiredService<IAgentTaskRepository>();
                if (!recovered)
                {
                    await repository.RecoverInterruptedAsync(stoppingToken);
                    recovered = true;
                }
                var accountReady = !options.Value.ChatGptAuthentication ||
                    await scope.ServiceProvider.GetRequiredService<CodexAccountReceiver>().CanExecuteAsync(stoppingToken);
                using var dispatch = accountReady
                    ? scope.ServiceProvider.GetRequiredService<AgentTaskExecutionControl>().TryReserveDispatch() : null;
                var item = dispatch is not null ? await repository.ClaimAsync(stoppingToken) : null;
                if (item is not null)
                {
                    await scope.ServiceProvider.GetRequiredService<ProcessAgentTaskReceiver>()
                        .ExecuteAsync(item, stoppingToken);
                    continue;
                }
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                return;
            }
            catch
            {
                recovered = false;
                logger.LogWarning("Agent task worker could not access or update its persistent state.");
            }
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(options.Value.PollSeconds), stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                return;
            }
        }
    }
}
