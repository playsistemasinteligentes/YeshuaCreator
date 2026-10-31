#!/usr/bin/env node
// Native MCP acceptance against the deployed server. Never executes agent mutations.
import { mkdir, writeFile } from 'node:fs/promises';
import { resolve, join } from 'node:path';
import { pathToFileURL } from 'node:url';
import { createHash } from 'node:crypto';

export function validate(schema, value, path = '$') {
  if (schema.anyOf && !schema.anyOf.some(option => { try { validate(option, value, path); return true; } catch { return false; } }))
    throw new Error(`${path}: none of the declared shapes match`);
  const types = { object: value !== null && typeof value === 'object' && !Array.isArray(value), array: Array.isArray(value),
    string: typeof value === 'string', integer: Number.isInteger(value), number: typeof value === 'number',
    boolean: typeof value === 'boolean', null: value === null };
  if (schema.type && !types[schema.type]) throw new Error(`${path}: expected ${schema.type}`);
  if (schema.enum && !schema.enum.includes(value)) throw new Error(`${path}: invalid enum`);
  if (typeof value === 'number' && ((schema.minimum !== undefined && value < schema.minimum) ||
      (schema.maximum !== undefined && value > schema.maximum))) throw new Error(`${path}: out of range`);
  if (types.object) {
    for (const key of schema.required ?? []) if (!(key in value)) throw new Error(`${path}.${key}: missing`);
    for (const [key, item] of Object.entries(value)) {
      if (schema.properties?.[key]) validate(schema.properties[key], item, `${path}.${key}`);
      else if (schema.additionalProperties === false) throw new Error(`${path}.${key}: unknown`);
    }
  }
  if (types.array && schema.items) value.forEach((item, index) => validate(schema.items, item, `${path}[${index}]`));
}

export class McpClient {
  constructor(url) {
    const parsed = new URL(url);
    if (parsed.username || parsed.password || parsed.search || parsed.hash ||
        (parsed.protocol !== 'https:' && !(parsed.protocol === 'http:' && ['127.0.0.1', 'localhost'].includes(parsed.hostname))))
      throw new Error('MCP URL must be HTTPS or loopback HTTP, without credentials/query/fragment');
    this.url = url; this.sequence = 0; this.calls = []; this.tools = []; this.protocol = '2025-06-18';
  }
  async rpc(method, params = {}, notify = false) {
    const payload = { jsonrpc: '2.0', method, params, ...(!notify ? { id: ++this.sequence } : {}) };
    const started = performance.now();
    const response = await fetch(this.url, { method: 'POST', redirect: 'error', signal: AbortSignal.timeout(45000),
      headers: { 'Content-Type': 'application/json', Accept: 'application/json, text/event-stream',
        'MCP-Protocol-Version': this.protocol, ...(this.session ? { 'Mcp-Session-Id': this.session } : {}) }, body: JSON.stringify(payload) });
    this.session = response.headers.get('mcp-session-id') ?? this.session;
    const raw = await response.text();
    const call = { method, tool: params.name, durationMs: Math.round(performance.now() - started), httpStatus: response.status,
      bytes: Buffer.byteLength(raw), sha256: createHash('sha256').update(raw).digest('hex') };
    this.calls.push(call);
    if (!response.ok) throw new Error(`MCP ${method}: HTTP ${response.status}`);
    if (notify) return null;
    const text = raw.trimStart().startsWith('{') ? raw : raw.split('\n').filter(line => line.startsWith('data:')).at(-1)?.slice(5).trim();
    if (!text) throw new Error('MCP response has no JSON message');
    const message = JSON.parse(text);
    if (message.error) throw new Error(`MCP ${method}: protocol error ${message.error.code}`);
    if (message.id !== payload.id) throw new Error('MCP response id mismatch');
    return message.result;
  }
  async connect() {
    const initialized = await this.rpc('initialize', { protocolVersion: this.protocol, capabilities: {},
      clientInfo: { name: 'Yeshua-MCP-Acceptance', version: '1' } });
    this.protocol = initialized.protocolVersion; this.instructions = initialized.instructions;
    await this.rpc('notifications/initialized', {}, true);
    this.tools = (await this.rpc('tools/list')).tools;
    return this;
  }
  async call(name, args = {}, expectError = false) {
    const tool = this.tools.find(tool => tool.name === name);
    if (tool) validate(tool.inputSchema, args);
    const result = await this.rpc('tools/call', { name, arguments: args });
    if (Boolean(result.isError) !== expectError) throw new Error(`${name}: unexpected tool outcome`);
    if (!result.isError) {
      if (!tool) throw new Error(`${name}: not in discovered catalog`);
      validate(tool.outputSchema, result.structuredContent);
    }
    return result;
  }
}

function requireEvidence(condition, message) { if (!condition) throw new Error(message); }

export async function runAcceptance(options) {
  const directory = resolve(options.output ?? 'artifacts/operational-mcp-validation/live');
  await mkdir(directory, { recursive: true });
  const report = { startedAtUtc: new Date().toISOString(), checks: [], coverage: {}, endpoints: {}, status: 'running' };
  const clients = [];
  async function check(name, action) {
    const started = performance.now();
    try { const detail = await action(); report.checks.push({ name, status: 'passed', durationMs: Math.round(performance.now() - started), detail }); }
    catch (error) { report.checks.push({ name, status: 'failed', durationMs: Math.round(performance.now() - started), error: error.message }); }
  }
  const client = new McpClient(options.publicUrl ?? 'https://playsis.com.br/operational/mcp'); clients.push(client);
  await client.connect();
  report.endpoints.public = { protocol: client.protocol, tools: client.tools.map(tool => tool.name) };
  await check('public.catalog', async () => {
    requireEvidence(client.tools.length === 4 && ['yeshua_health', 'yeshua_explorer', 'yeshua_app_explore', 'yeshua_source_search']
      .every(name => client.tools.some(tool => tool.name === name)), 'Public catalog mismatch');
    requireEvidence(client.tools.every(tool => tool.annotations?.readOnlyHint === true), 'Public mutation advertised');
    for (const tool of client.tools) requireEvidence(tool.outputSchema?.properties || tool.outputSchema?.anyOf, 'Undeclared output shape');
  });
  await check('public.health', async () => {
    const data = (await client.call('yeshua_health')).structuredContent;
    requireEvidence(data.mcp === 'healthy', 'MCP unhealthy');
    for (const key of ['loki', 'tempo', 'prometheus']) requireEvidence(data[key] === 'healthy', `${key} unhealthy`);
    return data;
  });
  await check('public.explorer', async () => {
    const result = await client.call('yeshua_explorer');
    requireEvidence(result.structuredContent.guide.includes('yeshua_source_search'), 'Guide lacks indexed search');
    requireEvidence(result.structuredContent.guide.includes('next'), 'Guide lacks navigation');
    requireEvidence(result.content.reduce((sum, item) => sum + (item.text?.length ?? 0), 0) < 200, 'Guide duplicated in text');
  });
  const app = options.application ?? 'Memorias';
  const catalog = (await client.call('yeshua_source_search', { kind: 'applications' })).structuredContent;
  requireEvidence(catalog.applications.some(item => item.name === app), 'Requested application is not indexed');
  const builds = (await client.call('yeshua_source_search', { kind: 'builds', application: app, maxResults: 1 })).structuredContent;
  requireEvidence(builds.builds.length === 1, 'No indexed snapshot');
  const build = builds.builds[0];
  const pinned = { application: app, buildId: build.buildId, version: build.version };
  report.snapshot = build;
  let functionAnchor;
  await check('public.snapshot-navigation', async () => {
    const next = builds.next.find(item => item.arguments.kind === 'dsl');
    requireEvidence(next?.arguments.buildId === build.buildId, 'Continuation lost snapshot');
    const dsl = (await client.call('yeshua_source_search', { ...next.arguments, maxFiles: 1, maxLines: 25, maxContentChars: 6000 })).structuredContent;
    requireEvidence(dsl.build.buildId === build.buildId && dsl.snippets.length > 0, 'DSL source missing');
  });
  for (const [kind, query] of [['screen', 'Selecionar fotos'], ['action', 'Publicar'], ['metadata', undefined],
                              ['field', 'Titulo'], ['class', 'AlbumEntity'], ['function', 'CustomExecute']]) {
    await check(`public.search.${kind}`, async () => {
      const result = (await client.call('yeshua_source_search', { ...pinned, kind, ...(query ? { query } : {}), maxResults: 3 })).structuredContent;
      requireEvidence(result.build.buildId === build.buildId, 'Snapshot drift');
      requireEvidence(result.sourceFiles.length > 0, 'No evidence for this test anchor');
      if (['field', 'class', 'function'].includes(kind)) requireEvidence(result.matches.length > 0, 'No symbol match');
      if (kind === 'function') functionAnchor = result.matches[0];
      const continuation = result.next.find(item => item.arguments.kind === 'file');
      requireEvidence(continuation, 'Missing file continuation');
      const code = (await client.call('yeshua_source_search', { ...continuation.arguments, maxLines: 12, maxContentChars: 3000 })).structuredContent;
      requireEvidence(code.snippets.length > 0 && code.build.buildId === build.buildId, 'No readable source');
      for (const snippet of code.snippets) requireEvidence(snippet.content.split('\n').length === snippet.endLine - snippet.startLine + 1, 'Line coverage mismatch');
      return { files: result.sourceFiles.length, matches: result.matches.length, snippets: code.snippets.length };
    });
  }
  await check('public.function-qualified-stack-name', async () => {
    requireEvidence(functionAnchor, 'No function anchor was discovered');
    const query = functionAnchor.qualifiedName.split('(')[0];
    const result = (await client.call('yeshua_source_search', { ...pinned, kind: 'function', query, maxResults: 2 })).structuredContent;
    requireEvidence(result.matches.some(item => item.qualifiedName.split('(')[0] === query), 'Qualified stack name did not resolve its declaration');
  });
  await check('public.missing-evidence', async () => {
    const result = (await client.call('yeshua_source_search', { ...pinned, kind: 'screen', query: '__yeshua_no_such_feature_999__' })).structuredContent;
    requireEvidence(result.sourceFiles.length === 0 && result.snippets.length === 0, 'Missing feature fabricated evidence');
  });
  for (const screen of ['register', 'login', 'memorias-estudio']) await check(`public.ui.${screen}`, async () => {
    const result = (await client.call('yeshua_app_explore', { application: app, screen })).structuredContent;
    requireEvidence(result.sources.length === 2 && result.sources.every(item => item.content.length > 0), 'Incomplete UI sources');
    if (screen === 'register') for (const field of ['nome', 'cpfCnpj', 'phone', 'email', 'password', 'confirmpassword'])
      requireEvidence(result.sources.some(item => item.content.includes(field)), `Missing registration field ${field}`);
    if (screen === 'memorias-estudio') for (const clue of ['mem-new', 'preparePhotoSelection', 'uploadPhotos'])
      requireEvidence(result.sources.some(item => item.content.includes(clue)), `Missing studio action ${clue}`);
  });
  for (const name of ['yeshua_database_select', 'yeshua_logs_query', 'yeshua_task_send', 'yeshua_codex_auth'])
    await check(`public.denied.${name}`, async () => { await client.call(name, {}, true); });
  report.coverage.agentMutations = 'Fixture tests only; no production task, restart or authentication mutation is executed.';
  if (options.privateUrl) {
    const admin = new McpClient(options.privateUrl); clients.push(admin); await admin.connect();
    report.endpoints.private = { protocol: admin.protocol, tools: admin.tools.map(tool => tool.name) };
    await check('private.catalog', async () => {
      requireEvidence(admin.tools.length === 15, 'Private catalog mismatch');
      requireEvidence(admin.tools.filter(tool => tool.annotations?.readOnlyHint === false).length === 3, 'Mutation annotations mismatch');
      for (const tool of admin.tools) requireEvidence(tool.outputSchema?.properties || tool.outputSchema?.anyOf, `${tool.name}: no output contract`);
    });
    const toUtc = new Date().toISOString(), fromUtc = new Date(Date.now() - 180000).toISOString();
    const filtered = { application: app, fromUtc, toUtc, limit: 2, text: '__yeshua_acceptance_no_personal_data__' };
    for (const name of ['yeshua_logs_query', 'yeshua_errors_query']) await check(`private.${name}`, async () => {
      const data = (await admin.call(name, filtered)).structuredContent;
      requireEvidence(data.httpStatusCode === 200, 'Telemetry backend did not return HTTP 200');
      return { backendStatus: data.httpStatusCode };
    });
    await check('private.traces', async () => {
      const data = (await admin.call('yeshua_traces_query', { query: '{ resource.service.name = "__yeshua_acceptance__" }', fromUtc, toUtc, limit: 1 })).structuredContent;
      requireEvidence(data.httpStatusCode === 200, 'Trace backend failed');
    });
    await check('private.metrics', async () => {
      const data = (await admin.call('yeshua_metrics_query', { query: 'vector(1)', fromUtc, toUtc, step: '60s', limit: 1 })).structuredContent;
      requireEvidence(data.httpStatusCode === 200, 'Metrics backend failed');
    });
    await check('private.log-source-empty', async () => {
      const data = (await admin.call('yeshua_logs_source_context', { application: app, log: 'synthetic marker without source symbols', includeContent: false })).structuredContent;
      requireEvidence(data.extractedSignals.length === 0 && data.warnings.length > 0, 'Empty log invented a source');
    });
    await check('private.log-source-correlated', async () => {
      requireEvidence(functionAnchor, 'No function anchor was discovered');
      const symbol = functionAnchor.qualifiedName.split('(')[0];
      const result = (await admin.call('yeshua_logs_source_context', { application: app, version: build.version,
        log: `Synthetic acceptance: at ${symbol}()`, includeContent: false, maxResults: 2, maxDepth: 0, maxFiles: 1 })).structuredContent;
      requireEvidence(result.evidence.some(item => item.data?.matches?.some(match => match.qualifiedName.split('(')[0] === symbol)),
        'Synthetic stack did not resolve its actual indexed method');
    });
    await check('private.sql', async () => {
      const data = (await admin.call('yeshua_database_select', { connection: options.sqlConnection ?? 'OperationalIntelligence',
        query: 'SELECT @probe AS Probe', parameters: { probe: 1 }, maxRows: 1, timeoutSeconds: 5 })).structuredContent;
      requireEvidence(data.rowCount === 1 && data.rows[0].Probe === 1, 'SQL parameterized probe failed');
      return { rowCount: data.rowCount, probe: data.rows[0].Probe };
    });
    report.coverage.privateQueries = 'Real backends with empty markers, a constant metric and parameterized SELECT of a constant; no personal records saved.';
  } else report.coverage.privateQueries = 'Not run: private URL not supplied.';
  report.calls = clients.flatMap((item, index) => item.calls.map(call => ({ channel: index === 0 ? 'public' : 'private', ...call })));
  report.endedAtUtc = new Date().toISOString();
  report.status = report.checks.some(item => item.status === 'failed') ? 'failed' : 'passed';
  await writeFile(join(directory, 'report.json'), JSON.stringify(report, null, 2));
  await writeFile(join(directory, 'catalog.json'), JSON.stringify(client.tools, null, 2));
  return report;
}

if (process.argv[1] && import.meta.url === pathToFileURL(resolve(process.argv[1])).href) {
  const options = {};
  for (let index = 2; index < process.argv.length; index += 2) {
    const key = { '--public-url': 'publicUrl', '--private-url': 'privateUrl', '--application': 'application',
      '--sql-connection': 'sqlConnection', '--output': 'output' }[process.argv[index]];
    if (!key || !process.argv[index + 1]) throw new Error('Unknown or missing argument');
    options[key] = process.argv[index + 1];
  }
  try {
    const report = await runAcceptance(options);
    console.log(JSON.stringify({ status: report.status, passed: report.checks.filter(item => item.status === 'passed').length,
      failed: report.checks.filter(item => item.status === 'failed').map(item => ({ name: item.name, error: item.error })), output: options.output }));
    if (report.status !== 'passed') process.exitCode = 1;
  } catch (error) { console.error(JSON.stringify({ status: 'failed', stage: 'transport-or-discovery', error: error.message })); process.exitCode = 1; }
}
