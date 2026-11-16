'use strict';

const components = require('./components.json');
const { classify } = require('./release.cjs');
const names = {
  'APS.ADM': 'aps-adm', 'APS.Cadastros': 'aps-cadastros', Central: 'central',
  Clinica: 'clinica', AppClinicas: 'clinica', Fiscal: 'fiscal', MDFe: 'fiscal', Memorias: 'memorias',
};

function scopeForPath(path) {
  const identity = path.match(/^release-identities\/([^/]+)\.json$/);
  if (identity && components.includes(identity[1])) return identity[1];
  // A tela pertence ao aplicativo mesmo quando hospedada no Front Central.
  const front = path.match(/\/Custon\/Apps\/([^/]+)\//);
  if (front) return names[front[1]] || 'architecture';
  const project = path.match(/^(?:src\/(?:CQRS\/(?:Application|Domain|Infrastructure)|Studio)|tests\/CQRS)\/Yeshua\.(?:Studio\.)?(APS\.ADM|APS\.Cadastros|Central|Clinica|AppClinicas|Fiscal|MDFe|Memorias)(?:\.|\/)/);
  if (project) return names[project[1]];
  const folder = path.match(/^(?:infra|docs|tests\/(?:Front|Media))\/(APS\.ADM|APS\.Cadastros|Central|Clinica|Fiscal|MDFe|Memorias)(?:\/|$)/);
  if (folder) return names[folder[1]];
  const operationalDoc = path.match(/^docs\/operational\/(clinica|fiscal)\//);
  if (operationalDoc) return operationalDoc[1];
  // Engine, Shared, automacao e caminhos nao mapeados sao arquitetura.
  return 'architecture';
}

function inferLabels(files) {
  if (!files.length) throw new Error('A PR deve conter arquivos para classificar.');
  const labels = new Set();
  for (const file of files) {
    if (typeof file.filename !== 'string' || !file.filename) throw new Error('Arquivo sem caminho.');
    for (const path of [file.filename, file.previous_filename].filter(Boolean)) {
      const scope = scopeForPath(path);
      labels.add(scope === 'architecture' ? scope : `app:${scope}`);
    }
  }
  return [...labels].sort();
}

async function ensureLabels(github, repo) {
  const existing = await github.paginate(github.rest.issues.listLabelsForRepo, { ...repo, per_page: 100 });
  for (const component of components) {
    const name = component === 'architecture' ? component : `app:${component}`;
    if (existing.some(label => label.name === name)) continue;
    try {
      await github.rest.issues.createLabel({ ...repo, name, color: component === 'architecture' ? '5319e7' : '0e8a16',
        description: `Release independente: ${component}` });
    } catch (error) {
      if (error.status !== 422) throw error;
      // Outro run pode ter criado a mesma label; nao ocultar outros erros 422.
      await github.rest.issues.getLabel({ ...repo, name });
    }
  }
}

async function labelPullRequest({ github, context, core }) {
  const repo = context.repo;
  const number = context.payload.pull_request?.number || Number(context.payload.inputs?.pr_number);
  if (!Number.isSafeInteger(number) || number < 1) throw new Error('Numero de PR invalido.');
  const { data: pr } = await github.rest.pulls.get({ ...repo, pull_number: number });
  if (pr.state !== 'open' || pr.base.ref !== context.payload.repository.default_branch ||
      pr.base.repo.full_name !== `${repo.owner}/${repo.repo}`) throw new Error('Classificacao exige PR aberta para a branch padrao.');
  const files = await github.paginate(github.rest.pulls.listFiles, { ...repo, pull_number: number, per_page: 100 });
  if (files.length !== pr.changed_files) throw new Error('Lista de arquivos incompleta; classifique manualmente apos revisao.');
  const inferred = inferLabels(files);
  // Validar labels manuais antes de qualquer escrita. A inferencia so acrescenta.
  classify([...pr.labels, ...inferred.map(name => ({ name }))]);
  const { data: latest } = await github.rest.pulls.get({ ...repo, pull_number: number });
  if (latest.state !== 'open' || latest.head.sha !== pr.head.sha || latest.base.sha !== pr.base.sha) {
    throw new Error('A PR mudou durante a classificacao; reexecute.');
  }
  await ensureLabels(github, repo);
  const missing = inferred.filter(name => !latest.labels.some(label => label.name === name));
  if (missing.length) await github.rest.issues.addLabels({ ...repo, issue_number: number, labels: missing });
  // Validar no mesmo run: eventos labeled causados pelo GITHUB_TOKEN nao disparam CI.
  const { data: labeled } = await github.rest.pulls.get({ ...repo, pull_number: number });
  if (labeled.head.sha !== pr.head.sha || labeled.base.sha !== pr.base.sha || labeled.state !== 'open') {
    throw new Error('A PR mudou durante a gravacao; reexecute.');
  }
  const actual = classify(labeled.labels);
  if (inferred.some(name => !labeled.labels.some(label => label.name === name))) throw new Error('Labels nao persistidas.');
  core.info(`Componentes: ${actual.join(', ')}`);
  await core.summary.addHeading(`Classificacao da PR #${number}`)
    .addRaw(`Inferidas: ${inferred.join(', ')}. Escopos finais: ${actual.join(', ')}. Labels manuais preservadas.`).write();
  return actual;
}

module.exports = { scopeForPath, inferLabels, ensureLabels, labelPullRequest };
