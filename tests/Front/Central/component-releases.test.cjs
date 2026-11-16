'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const { identity } = require('../../../scripts/component-release/release.cjs');
const source = fs.readFileSync(require('node:path').resolve(__dirname, '../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/spa/scripts/component-releases.js'), 'utf8');
const modulePromise = import(`data:text/javascript;base64,${Buffer.from(source).toString('base64')}`);
test('registro visual corresponde ao registro da automacao', async () => {
  assert.deepEqual(Object.keys((await modulePromise).components), require('../../../scripts/component-release/components.json'));
});
test('Central le somente arquivos locais, funciona sem GitHub/token e distingue PRs da mesma base', async () => {
  const { createReleaseClient } = await modulePromise;
  for (const pr of [35, 36]) {
    const requests = [];
    const client = createReleaseClient(async (url, options) => {
      requests.push(url); assert.ok(url.startsWith('/spa/release-identities/')); assert.equal(options.credentials, 'omit');
      return { ok: true, status: 200, json: async () => identity(url.split('/').at(-1).replace('.json', ''), '01.006', pr) };
    });
    const result = await client.local(); assert.equal(result.rows.find(r => r.component === 'fiscal').release.version, `01.006-PR${pr}`);
    assert.equal(requests.length, 7);
  }
  assert.doesNotMatch(source, /api\.github|matching-refs|Authorization|localStorage/);
});
test('ausencia, erro e identidade corrupta nao viram release verificada', async () => {
  const { createReleaseClient } = await modulePromise;
  for (const [status, value, expected] of [[404, null, 'missing'], [503, null, 'error'], [200, { ...identity('fiscal', '01.006', 35), pr: 36 }, 'error']]) {
    const data = await createReleaseClient(async () => ({ status, ok: status === 200, json: async () => value })).local();
    const row = data.rows.find(r => r.component === 'fiscal');
    if (expected === 'missing') assert.equal(row.release, null);
    else { assert.ok(row.error); assert.equal(row.release, undefined); }
  }
});
