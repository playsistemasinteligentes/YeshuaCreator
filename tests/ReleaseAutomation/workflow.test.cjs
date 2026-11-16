'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const { readFileSync } = require('node:fs');
const read = name => readFileSync(require('node:path').resolve(__dirname, '../../.github/workflows', name), 'utf8');
test('publicacao manual exige build isolado, SHA exato, barreira v2 e nenhum merge automatico', () => {
  const w = read('component-release.yml');
  assert.doesNotMatch(w, /pull_request_target|RELEASE_TAGGING_ENABLED|secrets\.|git push|git merge|\bdeploy:/);
  assert.match(w, /needs: \[resolve, validate\]/);
  assert.match(w, /RELEASE_TAGGING_V2_ENABLED == 'true'/);
  assert.match(w, /expectedSha: process.env.VALIDATED_SHA/);
  assert.match(w, /dotnet build YeshuaCreator.sln/);
  assert.match(w, /dotnet publish/);
  assert.match(w, /RUN_RELEASE_UI_TESTS: '1'/);
  assert.match(w, /playwright@1\.65\.1/);
  assert.match(read('release-validation.yml'), /RUN_RELEASE_UI_TESTS: '1'/);
  const build = w.split('\n  validate:\n')[1].split('\n  publish:\n')[0];
  assert.match(build, /contents: read/); assert.doesNotMatch(build, /: write/);
  assert.match(build, /ref: \$\{\{ needs.resolve.outputs.sha \}\}/);
  assert.match(w, /dry_run:[\s\S]*default: true/);
  assert.match(w, /inputs.dry_run == false/);
  assert.match(w, /group: component-release-\$\{\{ inputs.pr_number \}\}/);
});
test('jobs privilegiados executam somente workflow confiavel sem credenciais persistentes', () => {
  const w = read('component-release.yml');
  for (const job of ['prepare', 'resolve', 'publish']) {
    const text = w.split(`\n  ${job}:\n`)[1].split(/\n  [a-z]+:\n/)[0];
    assert.match(text, /ref: \$\{\{ github.workflow_sha \}\}/);
    assert.match(text, /persist-credentials: false/);
  }
  for (const name of ['component-release.yml', 'release-validation.yml', 'release-classification.yml']) {
    for (const m of read(name).matchAll(/uses: ([^\s]+)/g)) assert.match(m[1], /^[\w-]+\/[\w-]+@[a-f0-9]{40}$/);
  }
});
test('CI e classificacao preservam limites de permissao', () => {
  assert.doesNotMatch(read('release-validation.yml'), /: write/);
  const w = read('release-classification.yml');
  assert.match(w, /issues: write/); assert.match(w, /ref: \$\{\{ github.workflow_sha \}\}/);
  assert.doesNotMatch(w, /contents: write|pull-requests: write|secrets\./);
});
