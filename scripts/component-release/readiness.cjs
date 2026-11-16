'use strict';

const components = require('./components.json');
const { readTags } = require('./release.cjs');
const scopeLabels = components.map(c => c === 'architecture' ? c : `app:${c}`);

async function provisionLabels(github, repo) {
  const labels = await github.paginate(github.rest.issues.listLabelsForRepo, { ...repo, per_page: 100 });
  const names = new Set(labels.map(l => l.name));
  const created = [];
  for (const name of scopeLabels) {
    if (names.has(name)) continue;
    try {
      await github.rest.issues.createLabel({ ...repo, name, color: name === 'architecture' ? '5319e7' : '0e8a16',
        description: 'Escopo de release independente do YeshuaCreator' });
      created.push(name);
    } catch (error) {
      if (error.status !== 422) throw error;
      // Somente tolerar uma label realmente criada por outra execucao.
      const { data } = await github.rest.issues.getLabel({ ...repo, name });
      if (data.name !== name) throw error;
    }
  }
  return created;
}

async function audit(github, repo, enabled) {
  const checks = [];
  async function inspect(name, action) {
    try { await action(); }
    catch (error) {
      if (![401, 403, 404].includes(error.status)) throw error;
      checks.push({ name, status: 'unknown', detail: `HTTP ${error.status}; exige verificacao do operador.` });
    }
  }
  checks.push({ name: 'activation', status: enabled === 'true' ? 'pass' : 'fail',
    detail: `RELEASE_TAGGING_ENABLED=${enabled === 'true' ? 'true' : 'nao habilitado'}` });
  await inspect('labels', async () => {
    const labels = await github.paginate(github.rest.issues.listLabelsForRepo, { ...repo, per_page: 100 });
    const missing = scopeLabels.filter(n => !labels.some(l => l.name === n));
    checks.push({ name: 'labels', status: missing.length ? 'fail' : 'pass', detail: { missing } });
  });
  await inspect('workflows', async () => {
    const workflows = await github.paginate(github.rest.actions.listRepoWorkflows, { ...repo, per_page: 100 });
    const missing = ['component-release.yml', 'release-validation.yml'].filter(file =>
      !workflows.some(w => w.path === `.github/workflows/${file}` && w.state === 'active'));
    checks.push({ name: 'workflows', status: missing.length ? 'fail' : 'pass', detail: { missing } });
  });
  await inspect('tags', async () => {
    const inventory = {};
    for (const component of components) inventory[component] = (await readTags(github, repo, component)).map(t => t.tag);
    checks.push({ name: 'tags', status: 'pass', detail: inventory });
  });
  await inspect('branch-protection', async () => {
    const { data: repository } = await github.rest.repos.get(repo);
    const branch = repository.default_branch;
    const { data } = await github.rest.repos.getBranch({ ...repo, branch });
    checks.push({ name: 'branch-protection', status: data.protected ? 'pass' : 'fail', detail: { branch, protected: data.protected } });
    if (!data.protected) return;
    const { data: protection } = await github.rest.repos.getBranchProtection({ ...repo, branch });
    const required = protection.required_status_checks;
    const contexts = [...(required?.contexts ?? []), ...(required?.checks ?? []).map(c => c.context)];
    checks.push({ name: 'required-check', status: contexts.includes('release-tests') ? 'pass' : 'unknown',
      detail: 'Exigir release-tests e revisao de PR. Se a protecao vier de ruleset, conferir suas regras efetivas.' });
  });
  await inspect('tag-rulesets', async () => {
    const rules = await github.paginate(github.rest.repos.getRepoRulesets, { ...repo, includes_parents: true, per_page: 100 });
    const tags = rules.filter(r => r.target === 'tag' && r.enforcement === 'active');
    checks.push({ name: 'tag-rulesets', status: tags.length ? 'unknown' : 'fail',
      detail: { rulesets: tags.map(r => ({ id: r.id, name: r.name })),
        instruction: 'Confirmar cobertura de todos os componentes e bloqueio de update/delete sem bloquear criacao pelo Actions.' } });
  });
  await inspect('actions-permissions', async () => {
    const { data } = await github.rest.actions.getGithubActionsPermissionsRepository(repo);
    checks.push({ name: 'actions-permissions', status: data.enabled ? 'pass' : 'fail',
      detail: { enabled: data.enabled, allowed_actions: data.allowed_actions } });
  });
  return { checks, ready: checks.every(c => c.status === 'pass'),
    manualChecks: ['Confirmar permissoes efetivas de contents:write no job publish sem ampliar o token global.',
      'Confirmar cobertura, bypasses e regras efetivas de branch/tags; nenhuma escrita de teste e feita.',
      'Homologar primeira publicacao e reexecucao idempotente; nao reescrever tags.'] };
}

module.exports = { scopeLabels, provisionLabels, audit };
