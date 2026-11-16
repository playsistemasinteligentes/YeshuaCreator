'use strict';

const { test } = require('node:test');
const assert = require('node:assert/strict');
const { audit, provisionLabels, scopeLabels } = require('../../scripts/component-release/readiness.cjs');
const repo = { owner: 'owner', repo: 'repo' };

function fixture() {
  const labels = [{ name: 'architecture', color: 'ffffff' }];
  const writes = [];
  const github = { paginate: (method, args) => method(args), rest: {
    issues: {
      listLabelsForRepo: async () => labels,
      createLabel: async args => { labels.push({ name: args.name }); writes.push(args); },
      getLabel: async ({ name }) => ({ data: labels.find(l => l.name === name) }),
    },
    git: { listMatchingRefs: async () => [] },
    actions: {
      listRepoWorkflows: async () => ['component-release.yml', 'release-validation.yml'].map(file =>
        ({ path: `.github/workflows/${file}`, state: 'active' })),
      getGithubActionsPermissionsRepository: async () => ({ data: { enabled: true, allowed_actions: 'all' } }),
    },
    repos: {
      get: async () => ({ data: { default_branch: 'main' } }),
      getBranch: async () => ({ data: { protected: false } }),
      getRepoRulesets: async () => [],
    },
  } };
  return { github, labels, writes };
}

test('provisionamento cria apenas labels ausentes e e idempotente', async () => {
  const f = fixture();
  assert.equal((await provisionLabels(f.github, repo)).length, 6);
  assert.deepEqual(await provisionLabels(f.github, repo), []);
  assert.equal(f.writes.length, 6);
  assert.equal(f.labels[0].color, 'ffffff');
  assert.deepEqual(new Set(f.labels.map(l => l.name)), new Set(scopeLabels));
});

test('colisao de label so e tolerada depois de confirmar a existencia', async () => {
  const f = fixture();
  f.github.rest.issues.createLabel = async ({ name }) => {
    f.labels.push({ name }); throw Object.assign(new Error('exists'), { status: 422 });
  };
  assert.deepEqual(await provisionLabels(f.github, repo), []);
  f.labels.splice(1);
  f.github.rest.issues.getLabel = async () => { throw Object.assign(new Error('missing'), { status: 404 }); };
  await assert.rejects(provisionLabels(f.github, repo), /missing/);
});

test('403 de escrita de label e bloqueio real, nunca sucesso silencioso', async () => {
  const f = fixture();
  f.github.rest.issues.createLabel = async () => { throw Object.assign(new Error('forbidden'), { status: 403 }); };
  await assert.rejects(provisionLabels(f.github, repo), /forbidden/);
});

test('auditoria detecta desativacao, labels faltantes e falta de protecao sem escrever', async () => {
  const f = fixture();
  const result = await audit(f.github, repo, 'false');
  assert.equal(result.ready, false);
  for (const name of ['activation', 'labels', 'branch-protection', 'tag-rulesets']) {
    assert.equal(result.checks.find(c => c.name === name).status, 'fail');
  }
  assert.equal(f.writes.length, 0);
  const enabled = await audit(f.github, repo, 'true');
  assert.equal(enabled.checks.find(c => c.name === 'activation').status, 'pass');
  assert.equal((await audit(f.github, repo, 'TRUE')).checks[0].status, 'fail');
});

test('auditoria nao transforma permissao desconhecida ou ruleset parcial em pronto', async () => {
  const f = fixture();
  f.github.rest.actions.getGithubActionsPermissionsRepository = async () => {
    throw Object.assign(new Error('unauthorized'), { status: 401 });
  };
  f.github.rest.repos.getBranch = async () => ({ data: { protected: true } });
  f.github.rest.repos.getBranchProtection = async () => {
    throw Object.assign(new Error('forbidden'), { status: 403 });
  };
  f.github.rest.repos.getRepoRulesets = async () => [{ id: 1, name: 'tags', target: 'tag', enforcement: 'active' }];
  const result = await audit(f.github, repo, 'true');
  assert.equal(result.ready, false);
  assert.ok(result.checks.some(c => c.name === 'branch-protection' && c.status === 'unknown'));
  assert.equal(result.checks.find(c => c.name === 'actions-permissions').status, 'unknown');
  assert.equal(result.checks.find(c => c.name === 'tag-rulesets').status, 'unknown');
});

test('falhas tecnicas de auditoria nao sao ocultadas como configuracao ausente', async () => {
  const f = fixture();
  f.github.rest.issues.listLabelsForRepo = async () => { throw Object.assign(new Error('outage'), { status: 503 }); };
  await assert.rejects(audit(f.github, repo, 'true'), /outage/);
});
