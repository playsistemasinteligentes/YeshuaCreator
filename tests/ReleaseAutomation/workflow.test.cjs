'use strict';

const { test } = require('node:test');
const assert = require('node:assert/strict');
const { readFileSync } = require('node:fs');
const { resolve } = require('node:path');
const read = name => readFileSync(resolve(__dirname, '../../.github/workflows', name), 'utf8');

test('publicacao exige testes, ativacao explicita e somente permissoes de tags/leitura de PR', () => {
  const workflow = read('component-release.yml');
  assert.match(workflow, /^permissions: \{\}$/m);
  const publish = workflow.split('\n  publish:\n')[1];
  assert.match(publish, /needs: validate/);
  assert.match(publish, /if: vars\.RELEASE_TAGGING_ENABLED == 'true'/);
  assert.match(publish, /permissions:\n      contents: write\n      pull-requests: read\n/);
  assert.match(workflow.split('\n  publish:\n')[0], /node --test tests\/ReleaseAutomation\/\*\.test\.cjs/);
  assert.doesNotMatch(workflow, /issues: write|pull-requests: write|actions: write|secrets\./);
});

test('codigo privilegiado usa SHA do workflow, checkout sem credenciais e fila por PR', () => {
  const workflow = read('component-release.yml');
  assert.match(workflow, /pull_request_target:\n    types: \[closed\]/);
  assert.match(workflow, /pull_request\.merged == true/);
  assert.match(workflow, /group: component-release-\$\{\{ github\.event\.pull_request\.number \|\| inputs\.pr_number \}\}/);
  assert.match(workflow, /cancel-in-progress: false/);
  assert.equal((workflow.match(/ref: \$\{\{ github\.workflow_sha \}\}/g) || []).length, 2);
  assert.equal((workflow.match(/persist-credentials: false/g) || []).length, 2);
  assert.doesNotMatch(workflow, /pull_request\.head|github\.head_ref|\bdeploy\s*:|git push|git merge/);
});

test('CI valida mudanca de labels e actions sao fixadas por SHA completo', () => {
  const validation = read('release-validation.yml');
  assert.match(validation, /labeled, unlabeled/);
  assert.match(validation, /permissions:\n  contents: read/);
  assert.doesNotMatch(validation, /: write/);
  for (const name of ['component-release.yml', 'release-validation.yml']) {
    for (const match of read(name).matchAll(/uses: ([^\s]+)/g)) {
      assert.match(match[1], /^[\w-]+\/[\w-]+@[a-f0-9]{40}$/);
    }
  }
});
