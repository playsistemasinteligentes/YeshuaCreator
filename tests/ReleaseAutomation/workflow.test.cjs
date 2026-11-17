'use strict';

const { test } = require('node:test');
const assert = require('node:assert/strict');
const { readFileSync } = require('node:fs');
const { resolve } = require('node:path');

// Somente contrato do workflow manual existente; nao instala gates de CI.
test('versionamento somente por dispatch, sem build, classificacao ou deploy', () => {
  const workflow = readFileSync(resolve(__dirname, '../../.github/workflows/component-release.yml'), 'utf8');
  assert.match(workflow, /workflow_dispatch:/);
  assert.match(workflow, /dry_run:[\s\S]*default: true/);
  assert.match(workflow, /ref: \$\{\{ github\.workflow_sha \}\}/);
  assert.match(workflow, /persist-credentials: false/);
  assert.doesNotMatch(workflow, /pull_request_target:|pull_request:|needs:|node --test|dotnet |pr-readiness|classif|deploy:/);
  for (const match of workflow.matchAll(/uses: ([^\s]+)/g)) {
    assert.match(match[1], /^[\w-]+\/[\w-]+@[a-f0-9]{40}$/);
  }
});
