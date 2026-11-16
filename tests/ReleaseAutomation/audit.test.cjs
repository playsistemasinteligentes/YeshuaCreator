'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const { audit } = require('../../scripts/component-release/audit.cjs');
const { identity } = require('../../scripts/component-release/release.cjs');
test('auditoria GET exige identidade existente sem inventar versao para tags legadas', async () => {
  const paths = [], sha = 'a'.repeat(40), repository = 'playsistemasinteligentes/YeshuaCreator';
  const result = await audit(35, async path => {
    paths.push(path);
    if (!path) return { default_branch: 'main' };
    if (path === 'pulls/35') return { number: 35, state: 'open', changed_files: 1,
      labels: [{ name: 'architecture' }], head: { sha, ref: 'feature', repo: { full_name: repository } },
      base: { ref: 'main', repo: { full_name: repository } } };
    if (path.startsWith('pulls/35/files?')) return [{ filename: 'scripts/x.cjs' }];
    if (path.startsWith('contents/')) return { type: 'file', encoding: 'base64', content: Buffer.from(JSON.stringify(identity('architecture', '01.001', 35))).toString('base64') };
    if (path.startsWith('labels?')) return [{ name: 'architecture' }];
    if (path === 'rulesets') return [];
    throw Object.assign(new Error('Unavailable'), { status: path.startsWith('git/ref/') ? 404 : 401 });
  });
  assert.equal(result.receipts[0].tag, 'architecture/v01.001-PR35');
  assert.equal(result.sourceSha, sha);
  assert.equal(result.configuration['actions/variables/RELEASE_TAGGING_V2_ENABLED'].status, 401);
  assert.ok(paths.some(p => p.startsWith('contents/')));
});
test('auditoria informa indisponibilidade sem fingir sucesso', async () => {
  await assert.rejects(audit(0), /numero/);
  await assert.rejects(audit(35, async () => { throw new Error('Offline'); }), /Offline/);
});
