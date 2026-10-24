using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public sealed class RestartAgentReceiver(AgentTaskExecutionControl control, IOptions<AgentTaskOptions> options)
{
    public Task<AgentRestartReceipt> ExecuteAsync(RestartAgentCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (!options.Value.Enabled)
            throw new ArgumentException("O agente esta desabilitado neste servidor.");
        if (!command.Confirm)
            throw new ArgumentException("Reiniciar o agente exige pedido explicito do usuario e confirm=true.");
        if (command.TaskId == Guid.Empty || string.IsNullOrWhiteSpace(command.RequestId) ||
            command.RequestId.Length > 100 || command.RequestId.Trim() != command.RequestId)
            throw new ArgumentException("Informe taskId e requestId da execucao atual consultada em yeshua_task_read.");
        return control.RequestRestartAsync(command);
    }
}
