import test from 'node:test';
import assert from 'node:assert/strict';
import { createServer } from 'node:http';
import { McpClient, validate } from './validate-mcp.mjs';

test('MCP transport negotiates, decodes SSE and validates the actual response', async () => {
  const received = [];
  let brokenOutput = false;
  const tool = { name: 'probe', inputSchema: { type: 'object', properties: { value: { type: 'integer' } }, required: ['value'], additionalProperties: false },
    outputSchema: { type: 'object', properties: { echoed: { type: 'integer' } }, required: ['echoed'], additionalProperties: false } };
  const server = createServer(async (request, response) => {
    let raw = ''; for await (const chunk of request) raw += chunk;
    const message = JSON.parse(raw); received.push(message);
    if (message.method === 'notifications/initialized') { response.writeHead(202).end(); return; }
    const result = message.method === 'initialize' ? { protocolVersion: '2025-06-18', capabilities: {}, serverInfo: { name: 'test', version: '1' } }
      : message.method === 'tools/list' ? { tools: [tool] }
      : { content: [], structuredContent: brokenOutput ? {} : { echoed: message.params.arguments.value } };
    response.writeHead(200, { 'Content-Type': 'text/event-stream' });
    response.end(`event: message\ndata: ${JSON.stringify({ jsonrpc: '2.0', id: message.id, result })}\n\n`);
  });
  await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
  try {
    const client = await new McpClient(`http://127.0.0.1:${server.address().port}/mcp`).connect();
    assert.equal((await client.call('probe', { value: 7 })).structuredContent.echoed, 7);
    await assert.rejects(client.call('probe', { value: 'wrong' }), /expected integer/);
    assert.equal(received.filter(item => item.method === 'tools/call').length, 1);
    brokenOutput = true;
    await assert.rejects(client.call('probe', { value: 7 }), /missing/);
  } finally { await new Promise(resolve => server.close(resolve)); }
});

test('schema validation rejects incomplete, extra, wrong enum and oversized values', () => {
  const schema = { type: 'object', properties: { kind: { type: 'string', enum: ['file'] },
    count: { type: 'integer', minimum: 0, maximum: 3 }, values: { type: 'array', items: { anyOf: [{ type: 'string' }, { type: 'null' }] } } },
    required: ['kind', 'count', 'values'], additionalProperties: false };
  validate(schema, { kind: 'file', count: 0, values: ['ok', null] });
  for (const value of [{ kind: 'file' }, { kind: 'other', count: 0, values: [] }, { kind: 'file', count: 4, values: [] },
    { kind: 'file', count: 0, values: [1] }, { kind: 'file', count: 0, values: [], secret: 'x' }])
    assert.throws(() => validate(schema, value));
});

test('transport refuses credentials and non-loopback plain HTTP', () => {
  for (const url of ['http://remote.example/mcp', 'https://user:password@example.com/mcp', 'https://example.com/mcp?token=x'])
    assert.throws(() => new McpClient(url));
});
