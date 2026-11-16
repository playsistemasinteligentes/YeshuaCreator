'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const { audit } = require('../../scripts/component-release/audit.cjs');

test('auditoria publica simula PR mergeada e explicita configuracao inacessivel', async () => {
  const paths = [];
  const sha = 'a'.repeat(40);
  const result = await audit(26, async path => {
    paths.push(path);
    if (path === '') return { default_branch: 'main' };
    if (path === 'pulls/26') return { number: 26, merged: true, state: 'closed', merge_commit_sha: sha,
      labels: [{ name: 'architecture' }], base: { ref: 'main', repo: { full_name: 'playsistemasinteligentes/YeshuaCreator' } } };
    if (path.startsWith('git/matching-refs/')) return [];
    if (path.startsWith('labels?')) return [{ name: 'architecture' }];
    if (path === 'rulesets') return [];
    throw Object.assign(new Error('Unauthorized'), { status: 401 });
  });
  assert.equal(result.dryRun, true);
  assert.equal(result.receipts[0].tag, 'architecture/v01.001');
  assert.equal(result.receipts[0].sha, sha);
  assert.equal(result.configuration['actions/variables/RELEASE_TAGGING_ENABLED'].unavailable, true);
  assert.equal(result.configuration['actions/permissions'].status, 401);
  assert.deepEqual(result.labels, ['architecture']);
  assert.ok(paths.includes('git/matching-refs/tags/architecture/v?per_page=100&page=1'));
  assert.ok(!paths.some(p => /git\/(tags|refs)$/.test(p)));
});

test('auditoria rejeita numero invalido e erro de leitura de tags sem fingir homologacao', async () => {
  await assert.rejects(audit(0, () => assert.fail('nao deveria consultar')), /numero/);
  await assert.rejects(audit(26, async () => { throw new Error('API indisponivel'); }), /API indisponivel/);
});
