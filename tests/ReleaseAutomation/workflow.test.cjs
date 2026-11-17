'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const { readFileSync, existsSync } = require('node:fs');

test('somente merge ou recuperacao; sem build/test/deploy obrigatorio', () => {
  const workflow = readFileSync('.github/workflows/global-release.yml', 'utf8');
  assert.match(workflow, /pull_request_target:\s+types: \[closed\]\s+branches: \[main\]/);
  assert.match(workflow, /pull_request.merged == true/);
  assert.match(workflow, /dry_run:[\s\S]*default: true/);
  assert.match(workflow, /ref: \$\{\{ github.workflow_sha \}\}/);
  assert.match(workflow, /persist-credentials: false/);
  assert.match(workflow, /group: global-release-\$\{\{ github.event.pull_request.number/);
  assert.doesNotMatch(workflow, /pull_request_review:|needs:|node --test|dotnet |deploy:/);
  assert.equal(existsSync('.github/workflows/component-release.yml'), false);
  for (const match of workflow.matchAll(/uses: ([^\s]+)/g)) assert.match(match[1], /^[\w-]+\/[\w-]+@[a-f0-9]{40}$/);
});
