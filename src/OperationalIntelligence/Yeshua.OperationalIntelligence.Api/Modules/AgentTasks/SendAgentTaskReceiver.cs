using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public sealed class SendAgentTaskReceiver(IAgentTaskRepository repository, IOptions<AgentTaskOptions> options)
{
    public Task<AgentTaskReceipt> ExecuteAsync(SendAgentTaskCommand command, CancellationToken cancellationToken)
    {
        var settings = options.Value;
        if (!settings.Enabled)
            throw new ArgumentException("Execucao de tarefas desativada no servidor.");
        if (string.IsNullOrWhiteSpace(command.RequestId) || command.RequestId.Length > 100 ||
            command.RequestId != command.RequestId.Trim())
            throw new ArgumentException("requestId e obrigatorio e deve ter ate 100 caracteres. Reutilize-o em repeticoes.");
        if (string.IsNullOrWhiteSpace(command.Message) || command.Message.Length > settings.MaxMessageChars)
            throw new ArgumentException($"message e obrigatorio e deve ter ate {settings.MaxMessageChars} caracteres.");
        if (command.TaskId == Guid.Empty)
            throw new ArgumentException("taskId deve identificar uma tarefa existente ou ser omitido para criar uma.");
        if (command.Mode is not ("observe" or "workspace-write"))
            throw new ArgumentException("mode deve ser observe ou workspace-write.");
        if (command.Mode == "workspace-write" && !settings.AllowWorkspaceWrite)
            throw new ArgumentException("O servidor permite somente diagnostico. Escrita no workspace nao esta habilitada.");
        if (command.Title?.Length > 160)
            throw new ArgumentException("title deve ter ate 160 caracteres.");
        return repository.AcceptAsync(command, settings.MaxPendingMessages, cancellationToken);
    }
}
