import { Codex } from '@openai/codex-sdk';
import { pathToFileURL } from 'node:url';

export async function executeTask(input, codex, emit) {
  if (!input || typeof input.message !== 'string' || !input.message.trim() ||
      !['observe', 'workspace-write'].includes(input.mode) || typeof input.workspacePath !== 'string') {
    throw new Error('Invalid task protocol input.');
  }
  if (input.isContinuation && !input.threadId) throw new Error('Original task conversation is unavailable.');
  const options = {
    workingDirectory: input.workspacePath,
    sandboxMode: input.mode === 'workspace-write' ? 'workspace-write' : 'read-only',
    approvalPolicy: 'never',
    networkAccessEnabled: false,
    skipGitRepoCheck: false,
  };
  const thread = input.threadId
    ? codex.resumeThread(input.threadId, options)
    : codex.startThread(options);
  const { events } = await thread.runStreamed(input.message);
  let response = '';
  let completed = false;
  let confirmedThread = false;
  let currentThreadId = input.threadId;
  let lastProgress = 0;
  const limit = Math.min(Math.max(input.maxResponseChars ?? 64000, 1), 256000);
  for await (const event of events) {
    if (event.type === 'thread.started') {
      if (!event.thread_id || (currentThreadId && currentThreadId !== event.thread_id)) {
        throw new Error('Codex conversation context is unavailable.');
      }
      currentThreadId = event.thread_id;
      confirmedThread = true;
      emit({ type: 'progress', threadId: event.thread_id, description: 'Conversa do Codex iniciada.' });
    } else if (event.type === 'item.completed' && event.item.type === 'agent_message') {
      response = event.item.text.slice(0, limit);
    } else if (event.type === 'turn.completed') {
      completed = true;
    } else if (event.type === 'turn.failed' || event.type === 'error') {
      throw new Error('Codex did not complete the turn.');
    } else if (event.type === 'item.started' && Date.now() - lastProgress > 1000) {
      lastProgress = Date.now();
      emit({ type: 'progress', description: 'Codex trabalhando na tarefa.' });
    }
  }
  if (!completed || !confirmedThread) throw new Error('Incomplete Codex turn or unconfirmed conversation.');
  const result = { type: 'result', success: true, response: response || 'Tarefa concluida sem resposta textual.' };
  emit(result);
  return result;
}

export function codexConfiguration(input, environment = process.env) {
  const config = input.chatGptAuthentication
    ? { forced_login_method: 'chatgpt', cli_auth_credentials_store: 'file' } : {};
  if (environment.OPERATIONAL_INTELLIGENCE_MCP_URL) {
    config.mcp_servers = {
      yeshua_operational: {
        url: environment.OPERATIONAL_INTELLIGENCE_MCP_URL,
        enabled_tools: [
          'yeshua_health', 'yeshua_database_select', 'yeshua_errors_query', 'yeshua_logs_query',
          'yeshua_logs_source_context', 'yeshua_traces_query', 'yeshua_metrics_query', 'yeshua_source_search',
        ],
      },
    };
  }
  return config;
}

if (process.argv[1] && import.meta.url === pathToFileURL(process.argv[1]).href) {
  try {
    let raw = '';
    for await (const chunk of process.stdin) {
      raw += chunk;
      if (raw.length > 400000) throw new Error('Task input too large.');
    }
    const input = JSON.parse(raw);
    const codex = new Codex({
      config: codexConfiguration(input),
      ...(process.env.CODEX_BINARY_PATH ? { codexPathOverride: process.env.CODEX_BINARY_PATH } : {}),
    });
    await executeTask(input, codex, event => process.stdout.write(`${JSON.stringify(event)}\n`));
  } catch {
    process.stdout.write(`${JSON.stringify({ type: 'result', success: false, response: 'Falha no Codex. Confira autenticacao, contexto da conversa e limites da conta no servidor. Nenhuma repeticao automatica foi iniciada.' })}\n`);
    process.exitCode = 1;
  }
}
