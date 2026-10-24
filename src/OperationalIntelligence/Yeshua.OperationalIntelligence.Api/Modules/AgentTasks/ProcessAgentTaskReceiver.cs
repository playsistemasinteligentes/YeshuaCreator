using Microsoft.Extensions.Options;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public sealed class ProcessAgentTaskReceiver(
    IAgentTaskRepository repository, IAgentTaskExecutor executor, IOptions<AgentTaskOptions> options,
    AgentTaskExecutionControl control)
{
    public async Task ExecuteAsync(AgentTaskWorkItem item, CancellationToken cancellationToken)
    {
        using var execution = control.Begin(item, cancellationToken);
        using var deadline = CancellationTokenSource.CreateLinkedTokenSource(execution.Token);
        deadline.CancelAfter(TimeSpan.FromSeconds(options.Value.MaxTurnSeconds));
        string status;
        string response;
        try
        {
            if (item.Mode == "workspace-write" && !options.Value.AllowWorkspaceWrite)
                throw new ArgumentException("Escrita no workspace foi desativada antes da execucao.");
            var result = await executor.ExecuteAsync(item,
                (progress, token) => repository.ProgressAsync(item, progress, token), deadline.Token);
            deadline.Token.ThrowIfCancellationRequested();
            status = result.Success ? "Completed" : "Failed";
            response = result.Response;
        }
        catch (OperationCanceledException)
        {
            status = cancellationToken.IsCancellationRequested ? "Interrupted" : "Failed";
            response = cancellationToken.IsCancellationRequested
                ? "O servidor interrompeu a execucao. Confira o workspace antes de enviar outra ordem."
                : "A tarefa excedeu o tempo permitido. Confira o workspace antes de enviar outra ordem.";
        }
        catch (ArgumentException exception)
        {
            status = "Failed";
            response = exception.Message;
        }
        catch
        {
            status = "Failed";
            response = "O agente nao concluiu a tarefa. Confira a disponibilidade do Codex, autenticacao e workspace no servidor. O pedido nao sera repetido automaticamente.";
        }
        if (execution.Finish())
        {
            status = "Interrupted";
            response = "O operador interrompeu esta execucao para recuperar o agente. Confira o workspace antes de enviar outra ordem. O pedido nao foi repetido automaticamente.";
        }
        response = response[..Math.Min(response.Length, options.Value.MaxResponseChars)];
        using var saveDeadline = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        await repository.CompleteAsync(item, status, response, saveDeadline.Token);
    }
}
