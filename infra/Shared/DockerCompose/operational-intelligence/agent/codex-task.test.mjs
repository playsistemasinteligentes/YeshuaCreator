import test from 'node:test';
import assert from 'node:assert/strict';
import { executeTask, codexConfiguration } from './codex-task.mjs';

const input = { message: 'Confira a arquitetura.', mode: 'observe', workspacePath: '/workspace/project', maxResponseChars: 100 };

function runtime(events) {
  const calls = [];
  const thread = { async runStreamed(message) {
    calls.push({ message });
    return { events: (async function* () { yield* events; })() };
  } };
  return {
    calls,
    startThread(options) { calls.push({ start: options }); return thread; },
    resumeThread(threadId, options) { calls.push({ resume: threadId, options }); return thread; },
  };
}

test('creates read-only conversation and emits bounded answer without command payloads', async () => {
  const codex = runtime([
    { type: 'thread.started', thread_id: 'thread-1' },
    { type: 'item.started', item: { type: 'command_execution', command: 'sensitive-command' } },
    { type: 'item.completed', item: { type: 'agent_message', text: 'a'.repeat(200) } },
    { type: 'turn.completed' },
  ]);
  const emitted = [];
  const result = await executeTask(input, codex, event => emitted.push(event));
  assert.equal(codex.calls[0].start.sandboxMode, 'read-only');
  assert.equal(codex.calls[0].start.approvalPolicy, 'never');
  assert.equal(codex.calls[0].start.networkAccessEnabled, false);
  assert.equal(codex.calls[0].start.skipGitRepoCheck, false);
  assert.equal(result.response.length, 100);
  assert.equal(emitted[0].threadId, 'thread-1');
  assert.equal(JSON.stringify(emitted).includes('sensitive-command'), false);
});

test('continues the exact thread using the requested bounded workspace mode', async () => {
  const codex = runtime([
    { type: 'thread.started', thread_id: 'thread-existing' },
    { type: 'item.completed', item: { type: 'agent_message', text: 'Pronto.' } },
    { type: 'turn.completed' },
  ]);
  await executeTask({ ...input, mode: 'workspace-write', threadId: 'thread-existing' }, codex, () => {});
  assert.equal(codex.calls[0].resume, 'thread-existing');
  assert.equal(codex.calls[0].options.sandboxMode, 'workspace-write');
  assert.equal(codex.calls.length, 2);
});

test('continuation without the original conversation is blocked before starting any thread', async () => {
  const codex = runtime([]);
  await assert.rejects(executeTask({ ...input, isContinuation: true }, codex, () => {}), /Original task/);
  assert.deepEqual(codex.calls, []);
});

test('a resumed conversation must be confirmed before returning success', async () => {
  const codex = runtime([{ type: 'turn.completed' }]);
  await assert.rejects(executeTask({ ...input, threadId: 'original' }, codex, () => {}), /unconfirmed/);
  assert.equal(codex.calls.some(call => call.start), false);
});

test('ChatGPT authentication is forced and the agent cannot invoke its own authentication tools', () => {
  const config = codexConfiguration({ chatGptAuthentication: true }, { OPERATIONAL_INTELLIGENCE_MCP_URL: 'http://127.0.0.1:5729/mcp' });
  assert.equal(config.forced_login_method, 'chatgpt');
  assert.equal(config.cli_auth_credentials_store, 'file');
  assert.equal(config.mcp_servers.yeshua_operational.enabled_tools.some(name => /codex_auth|codex_status|task_send|restart/.test(name)), false);
});

test('failure never retries or replaces a missing conversation', async () => {
  const codex = runtime([{ type: 'turn.failed', error: { message: 'secret detail' } }]);
  const emitted = [];
  await assert.rejects(executeTask({ ...input, threadId: 'gone' }, codex, event => emitted.push(event)), /did not complete/);
  assert.equal(codex.calls.length, 2);
  assert.equal(JSON.stringify(emitted).includes('secret detail'), false);
});

test('rejects unrestricted sandbox requests and incomplete turns', async () => {
  await assert.rejects(executeTask({ ...input, mode: 'full-access' }, runtime([]), () => {}), /Invalid/);
  await assert.rejects(executeTask(input, runtime([]), () => {}), /Incomplete/);
});

test('a resumed task cannot silently switch to another conversation', async () => {
  const codex = runtime([{ type: 'thread.started', thread_id: 'unexpected-new-thread' }]);
  const emitted = [];
  await assert.rejects(executeTask({ ...input, threadId: 'expected-thread' }, codex, event => emitted.push(event)), /context is unavailable/);
  assert.deepEqual(emitted, []);
});

test('even a new task cannot replace its first confirmed conversation', async () => {
  const codex = runtime([
    { type: 'thread.started', thread_id: 'original' },
    { type: 'thread.started', thread_id: 'replacement' },
  ]);
  await assert.rejects(executeTask(input, codex, () => {}), /context is unavailable/);
});
