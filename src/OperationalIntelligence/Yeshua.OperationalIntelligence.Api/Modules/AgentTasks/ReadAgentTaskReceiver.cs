namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public sealed class ReadAgentTaskReceiver(IAgentTaskRepository repository, AgentTaskExecutionControl control)
{
    public async Task<AgentTaskReadResult> ExecuteAsync(ReadAgentTaskQuery query, CancellationToken cancellationToken)
    {
        if (query.TaskId == Guid.Empty)
            throw new ArgumentException("taskId deve ser valido.");
        if (query.Limit is < 1 or > 20)
            throw new ArgumentException("limit deve estar entre 1 e 20.");
        var result = await repository.ReadAsync(query, cancellationToken);
        return result with
        {
            Tasks = result.Tasks.Select((task, index) => task with
            {
                SelectionNumber = query.TaskId.HasValue ? null : index + 1
            }).ToArray(),
            ActiveExecution = control.Read(),
            Instruction = query.TaskId.HasValue
                ? "Leia estado, progresso e resposta. Selecione esta taskId apenas nesta conversa. Selecionar nao envia ordem. Para continuar use esta taskId e um novo requestId. Consulte andamento sem reenviar. Failed ou Interrupted exigem nova ordem explicita; nao repetir automaticamente."
                : "Apresente SelectionNumber, titulo e estado na ordem retornada e guarde a correspondencia numero -> taskId desta lista na conversa. O numero vale somente para esta lista, nao e uma identidade permanente. Ao ouvir 'task 3', consulte a taskId correspondente sem refazer a lista ou enviar ordem. Se perdeu a correspondencia ou houver ambiguidade, liste novamente e peca a escolha. Nao existe task selecionada globalmente no servidor."
        };
    }
}
