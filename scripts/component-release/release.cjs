'use strict';

const components = require('./components.json');
const SCHEMA = 'yeshua.release/v2';
const SHA = /^[a-f0-9]{40}$/;
const identityPath = component => `release-identities/${component}.json`;

function classify(labels) {
  const selected = new Set();
  for (const { name } of labels) {
    if (name === 'architecture') selected.add(name);
    else if (name.startsWith('app:')) {
      const component = name.slice(4);
      if (component === 'architecture' || !components.includes(component)) throw new Error(`Label de aplicativo desconhecida: ${name}`);
      selected.add(component);
    }
  }
  if (!selected.size) throw new Error('Classifique a PR com architecture e/ou app:<componente>.');
  return [...selected].sort((a, b) => components.indexOf(a) - components.indexOf(b));
}
function baseVersion(value) {
  if (!/^\d{2}\.\d{3,}$/.test(value) || String(Number(value.split('.')[1])).padStart(3, '0') !== value.split('.')[1]) {
    throw new Error(`Versao-base invalida: ${value}`);
  }
  return value;
}
function identity(component, base, pr) {
  if (!components.includes(component) || !Number.isSafeInteger(pr) || pr < 1) throw new Error('Identidade invalida.');
  const version = `${baseVersion(base)}-PR${pr}`;
  return { schema: SCHEMA, component, baseVersion: base, pr, version, tag: `${component}/v${version}` };
}
function validateIdentity(value, component, pr) {
  const expected = identity(component, value.baseVersion, pr ?? value.pr);
  if (Object.keys(value).length !== Object.keys(expected).length || Object.keys(expected).some(key => value[key] !== expected[key])) throw new Error(`Identidade local inconsistente: ${component}`);
  return value;
}
function parseVersion(tag, component) {
  const match = tag.match(/^([^/]+)\/v(\d{2}\.\d{3,})-PR([1-9]\d*)$/);
  if (!match || match[1] !== component) throw new Error(`Formato de tag invalido (v2): ${tag}`);
  return identity(component, match[2], Number(match[3]));
}
async function pullRequest(github, context) {
  if (context.eventName !== 'workflow_dispatch') throw new Error('Release exige dispatch explicito; merge nao publica release.');
  const number = Number(context.payload.inputs?.pr_number);
  if (!Number.isSafeInteger(number) || number < 1) throw new Error('Numero de PR invalido.');
  const { data: pr } = await github.rest.pulls.get({ ...context.repo, pull_number: number });
  const repository = `${context.repo.owner}/${context.repo.repo}`;
  if (pr.base.repo.full_name !== repository || pr.head.repo?.full_name !== repository ||
      pr.base.ref !== context.payload.repository.default_branch || pr.head.ref === pr.base.ref || !SHA.test(pr.head.sha)) {
    throw new Error('Exige branch de PR deste repositorio para a branch padrao; forks nao recebem escrita.');
  }
  const files = await github.paginate(github.rest.pulls.listFiles, { ...context.repo, pull_number: number, per_page: 100 });
  if (!files.length || files.length !== pr.changed_files) throw new Error('Lista de arquivos incompleta.');
  const { inferLabels } = require('./classification.cjs');
  const inferred = classify(inferLabels(files).map(name => ({ name })));
  const scopes = classify(pr.labels);
  if (inferred.some(scope => !scopes.includes(scope))) throw new Error('Labels nao cobrem os componentes inferidos pelos caminhos.');
  return { ...pr, number, sha: pr.head.sha, scopes, repository };
}
async function readIdentity(github, repo, sha, component) {
  const { data } = await github.rest.repos.getContent({ ...repo, ref: sha, path: identityPath(component) });
  if (data.type !== 'file' || data.encoding !== 'base64') throw new Error('Identidade deve ser arquivo local.');
  return JSON.parse(Buffer.from(data.content, 'base64').toString('utf8'));
}
async function plan({ github, context, expectedSha }) {
  const pr = await pullRequest(github, context);
  if (expectedSha && pr.sha !== expectedSha) throw new Error('Head mudou apos validacao; validar novamente.');
  const receipts = [];
  for (const component of pr.scopes) {
    const local = validateIdentity(await readIdentity(github, context.repo, pr.sha, component), component, pr.number);
    receipts.push({ ...local, repository: pr.repository, sha: pr.sha, components: pr.scopes });
  }
  return { pr, receipts };
}
async function prepare({ github, context, core }) {
  const pr = await pullRequest(github, context);
  if (pr.state !== 'open') throw new Error('Preparacao exige PR aberta.');
  const versions = JSON.parse(context.payload.inputs.versions || '{}');
  if (JSON.stringify(Object.keys(versions).sort()) !== JSON.stringify([...pr.scopes].sort())) {
    throw new Error('Informe versao-base explicita para todos e somente os componentes classificados.');
  }
  const identities = pr.scopes.map(component => identity(component, versions[component], pr.number));
  // Nunca alterar identidade de uma release existente, nem silenciosamente trocar sua base.
  const refs = await github.paginate(github.rest.git.listMatchingRefs, { ...context.repo, ref: 'tags/', per_page: 100 });
  if (refs.some(ref => ref.ref.endsWith(`-PR${pr.number}`))) throw new Error('PR ja possui release; abra outra PR.');
  const tree = identities.map(value => ({ path: identityPath(value.component), mode: '100644', type: 'blob', content: JSON.stringify(value, null, 2) + '\n' }));
  const { data: parent } = await github.rest.git.getCommit({ ...context.repo, commit_sha: pr.sha });
  const { data: createdTree } = await github.rest.git.createTree({ ...context.repo, base_tree: parent.tree.sha, tree });
  if (createdTree.sha === parent.tree.sha) { core.info('Identidades ja preparadas.'); return pr.sha; }
  const { data: commit } = await github.rest.git.createCommit({ ...context.repo,
    message: `Prepare release identities for PR #${pr.number}`, tree: createdTree.sha, parents: [pr.sha] });
  const latest = await pullRequest(github, context);
  if (latest.sha !== pr.sha || JSON.stringify(latest.scopes) !== JSON.stringify(pr.scopes) || latest.state !== 'open') {
    throw new Error('PR mudou durante preparacao; nenhum ref atualizado.');
  }
  // Commit de um unico pai + fast-forward: push concorrente cria divergencia e falha, sem perda de trabalho.
  await github.rest.git.updateRef({ ...context.repo, ref: `heads/${pr.head.ref}`, sha: commit.sha, force: false });
  core.info(`Identidades gravadas na PR: ${commit.sha}. Revisar e validar esse commit antes de publicar.`);
  return commit.sha;
}
async function approved(github, repo, pr) {
  if (pr.draft) throw new Error('PR em rascunho nao pode publicar.');
  const reviews = await github.paginate(github.rest.pulls.listReviews, { ...repo, pull_number: pr.number, per_page: 100 });
  const latest = new Map();
  for (const review of reviews) if (['APPROVED', 'CHANGES_REQUESTED', 'DISMISSED'].includes(review.state)) latest.set(review.user.login, review);
  const relevant = [...latest.values()].filter(r => r.user.login !== pr.user.login &&
    ['OWNER', 'MEMBER', 'COLLABORATOR'].includes(r.author_association));
  if (relevant.some(r => r.state === 'CHANGES_REQUESTED') || !relevant.some(r => r.state === 'APPROVED' && r.commit_id === pr.sha)) {
    throw new Error('Exige revisao aprovada por colaborador no head exato, sem solicitacao de alteracao pendente.');
  }
}
async function publish({ github, context, core, dryRun = false, expectedSha }) {
  const { pr, receipts } = await plan({ github, context, expectedSha });
  if (!dryRun) {
    if (!SHA.test(expectedSha || '')) throw new Error('Publicacao exige SHA validado pelo job de build.');
    await approved(github, context.repo, pr);
  }
  // Validar todo o conjunto antes da primeira escrita; criacao de refs continua create-only.
  for (const receipt of receipts) {
    let ref;
    try { ({ data: ref } = await github.rest.git.getRef({ ...context.repo, ref: `tags/${receipt.tag}` })); }
    catch (error) { if (error.status !== 404) throw error; }
    if (ref) {
      if (ref.object.type !== 'tag') throw new Error('Tag existente sem recibo v2.');
      const { data: annotation } = await github.rest.git.getTag({ ...context.repo, tag_sha: ref.object.sha });
      if (annotation.object.type !== 'commit' || annotation.object.sha !== receipt.sha || annotation.message !== JSON.stringify(receipt, null, 2)) {
        throw new Error(`Colisao imutavel: ${receipt.tag}`);
      }
      receipt.existing = true;
    }
  }
  for (const item of receipts) {
    const { existing, ...receipt } = item;
    if (dryRun || existing) continue;
    const { data: object } = await github.rest.git.createTag({ ...context.repo, tag: receipt.tag,
      message: JSON.stringify(receipt, null, 2), object: receipt.sha, type: 'commit' });
    // Falha ou resposta perdida interrompe. Reexecutar reconcilia o recibo, nunca renumera.
    await github.rest.git.createRef({ ...context.repo, ref: `refs/tags/${receipt.tag}`, sha: object.sha });
  }
  const result = receipts.map(({ existing, ...receipt }) => receipt);
  await core.summary.addHeading(`${dryRun ? 'Simulacao' : 'Release'} da PR #${pr.number}`)
    .addCodeBlock(JSON.stringify(result, null, 2), 'json').write();
  return result;
}
module.exports = { SCHEMA, classify, baseVersion, identity, identityPath, validateIdentity, parseVersion, pullRequest, readIdentity, plan, prepare, publish };
