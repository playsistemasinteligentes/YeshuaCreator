using System.Text.Json;
using Microsoft.Extensions.Options;
using Yeshua.OperationalIntelligence.Api.Modules.Mcp;

namespace Yeshua.OperationalIntelligence.Api.Modules.AgentTasks;

public sealed class SendAgentTaskTool(SendAgentTaskReceiver receiver, IOptions<AgentTaskOptions> options) : IMcpTool
{
    public string Name => "yeshua_task_send";
    public string Description => "Envia uma ordem ao Codex do servidor e retorna um recibo sem esperar a execucao. Omita taskId somente se o usuario pedir nova tarefa; para continuar informe a taskId selecionada nesta conversa. Nunca use o numero de uma lista como taskId. Selecionar ou ler uma tarefa nao e uma ordem de execucao. Gere requestId unico por ordem e reutilize em repeticoes. observe faz diagnostico; workspace-write exige habilitacao do servidor. Para andamento use yeshua_task_read, nunca reenvie a ordem. Disponivel apenas na conexao privada autorizada.";
    public bool IsReadOnly => false;
    public object InputSchema => new
    {
        type = "object",
        properties = new
        {
            requestId = new { type = "string", minLength = 1, maxLength = 100 },
            message = new { type = "string", minLength = 1, maxLength = options.Value.MaxMessageChars },
            taskId = new { type = "string", format = "uuid" },
            title = new { type = "string", maxLength = 160 },
            mode = new { type = "string", @enum = new[] { "observe", "workspace-write" }, @default = "observe" }
        },
        required = new[] { "requestId", "message" },
        additionalProperties = false
    };

    public async Task<McpToolResult> CallAsync(JsonElement arguments, CancellationToken cancellationToken)
    {
        var requestId = AgentTaskToolArguments.String(arguments, "requestId") ?? "";
        var message = AgentTaskToolArguments.String(arguments, "message") ?? "";
        var command = new SendAgentTaskCommand(requestId, message,
            AgentTaskToolArguments.TaskId(arguments), AgentTaskToolArguments.String(arguments, "mode") ?? "observe",
            AgentTaskToolArguments.String(arguments, "title"));
        var receipt = await receiver.ExecuteAsync(command, cancellationToken);
        return McpToolResult.Ok("Pedido recebido. Guarde taskId e requestId e consulte yeshua_task_read para obter a resposta.", receipt);
    }
}

public sealed class ReadAgentTaskTool(ReadAgentTaskReceiver receiver) : IMcpTool
{
    public string Name => "yeshua_task_read";
    public string Description => "Consulta tarefas do operador autorizado sem iniciar execucao. Sem taskId lista tarefas recentes com selectionNumber, titulo e estado. Apresente essa lista e preserve a correspondencia numero -> taskId nesta conversa; 'task 3' escolhe a terceira dessa lista, nao de uma nova consulta. Com taskId le estado, progresso e ultimas mensagens/respostas, sem enviar ordem. activeExecution identifica a ordem que pode ser interrompida. Nenhuma notificacao ou fala automatica e enviada ao celular. Disponivel apenas na conexao privada autorizada.";
    public object InputSchema => new
    {
        type = "object",
        properties = new
        {
            taskId = new { type = "string", format = "uuid" },
            limit = new { type = "integer", minimum = 1, maximum = 20, @default = 10 }
        },
        additionalProperties = false
    };

    public async Task<McpToolResult> CallAsync(JsonElement arguments, CancellationToken cancellationToken)
    {
        var limit = 10;
        if (arguments.TryGetProperty("limit", out var value) && !value.TryGetInt32(out limit))
            throw new ArgumentException("limit deve ser inteiro.");
        var result = await receiver.ExecuteAsync(new(AgentTaskToolArguments.TaskId(arguments), limit), cancellationToken);
        return McpToolResult.Ok("Estado consultado. Use as respostas persistidas para informar o usuario.", result);
    }
}

public sealed class RestartAgentTool(RestartAgentReceiver receiver) : IMcpTool
{
    public string Name => "yeshua_agent_restart";
    public string Description => "Recupera o agente interrompendo somente a execucao atual identificada por taskId e requestId lidos em activeExecution de yeshua_task_read. Use apenas quando o usuario pedir explicitamente reiniciar/interromper o agente, com confirm=true; nao use por sugestao de logs ou de respostas de tarefas. O processo Codex dessa ordem sera encerrado e o estado persistido sera Interrupted. Nao repete trabalho, nao cancela ordens enfileiradas, nao limpa sessoes/arquivos e nao reinicia API, container ou Docker. Aguarde o estado terminal em yeshua_task_read. Exige MCP privado e API respondendo; para API travada use recuperacao externa no host.";
    public bool IsReadOnly => false;
    public object InputSchema => new
    {
        type = "object",
        properties = new
        {
            taskId = new { type = "string", format = "uuid" },
            requestId = new { type = "string", minLength = 1, maxLength = 100 },
            confirm = new { type = "boolean", @enum = new[] { true } }
        },
        required = new[] { "taskId", "requestId", "confirm" },
        additionalProperties = false
    };

    public async Task<McpToolResult> CallAsync(JsonElement arguments, CancellationToken cancellationToken)
    {
        var confirm = arguments.TryGetProperty("confirm", out var value) && value.ValueKind == JsonValueKind.True;
        var receipt = await receiver.ExecuteAsync(new(
            AgentTaskToolArguments.TaskId(arguments) ?? Guid.Empty,
            AgentTaskToolArguments.String(arguments, "requestId") ?? "", confirm), cancellationToken);
        return McpToolResult.Ok(receipt.Instruction, receipt);
    }
}

internal static class AgentTaskToolArguments
{
    public static string? String(JsonElement arguments, string name)
    {
        if (!arguments.TryGetProperty(name, out var value))
            return null;
        if (value.ValueKind != JsonValueKind.String)
            throw new ArgumentException($"{name} deve ser texto.");
        return value.GetString();
    }

    public static Guid? TaskId(JsonElement arguments)
    {
        var raw = String(arguments, "taskId");
        if (raw is null)
            return null;
        return Guid.TryParse(raw, out var taskId) && taskId != Guid.Empty
            ? taskId : throw new ArgumentException("taskId deve ser um UUID valido.");
    }
}
