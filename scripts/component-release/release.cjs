'use strict';

const components = require('./components.json');
const SCHEMA = 'yeshua.release/v1';
const SHA = /^[a-f0-9]{40}$/;

// Unica fonte de selecao: campo explicito no corpo da PR, preenchido pelo autor.
function applications(body) {
  const fields = [...(body || '').matchAll(/^Aplicativos:[ \t]*([^\r\n]*)$/gm)];
  if (!fields.length) return [];
  if (fields.length > 1) throw new Error('Informe apenas um campo Aplicativos: no corpo da PR.');
  const selected = [...new Set(fields[0][1].split(',').map(name => name.trim()).filter(Boolean))];
  for (const component of selected) {
    if (!components.includes(component)) throw new Error(`Aplicativo desconhecido: ${component}`);
  }
  return selected.sort((a, b) => a === 'architecture' ? -1 : b === 'architecture' ? 1 : a.localeCompare(b));
}

function parseVersion(tag, component) {
  const prefix = `${component}/v`;
  if (!tag.startsWith(prefix)) throw new Error(`Tag fora do componente: ${tag}`);
  const version = tag.slice(prefix.length);
  if (!/^\d{2}\.\d{3,}$/.test(version)) throw new Error(`Formato de tag invalido: ${tag}`);
  const [major, release] = version.split('.').map(Number);
  if (!Number.isSafeInteger(release) || version !== formatVersion(major, release)) {
    throw new Error(`Versao nao canonica: ${tag}`);
  }
  return { major, release, version };
}

function formatVersion(major, release) {
  return `${String(major).padStart(2, '0')}.${String(release).padStart(3, '0')}`;
}

function compare(a, b) { return a.major - b.major || a.release - b.release; }

function nextVersion(tags) {
  const latest = tags.length ? tags.reduce((a, b) => compare(a, b) > 0 ? a : b) : { major: 1, release: 0 };
  if (!Number.isSafeInteger(latest.release + 1)) throw new Error('Sequencia de release esgotada.');
  return formatVersion(latest.major, latest.release + 1);
}

async function pullRequest(github, context) {
  const { owner, repo } = context.repo;
  const payload = context.payload;
  const manual = context.eventName === 'workflow_dispatch';
  const number = manual ? Number(payload.inputs?.pr_number) : payload.pull_request?.number;
  if (!Number.isSafeInteger(number) || number < 1) throw new Error('Numero de PR invalido.');
  const { data: pr } = await github.rest.pulls.get({ owner, repo, pull_number: number });
  if (pr.base.repo.full_name !== `${owner}/${repo}` || pr.base.ref !== payload.repository.default_branch) {
    throw new Error('A PR deve ter como destino a branch padrao deste repositorio.');
  }
  const publishing = manual || context.eventName === 'pull_request_target';
  if (publishing && (!pr.merged || pr.state !== 'closed' || !SHA.test(pr.merge_commit_sha))) {
    throw new Error('A release exige PR efetivamente mergeada e SHA valido.');
  }
  if (!manual && publishing && (payload.action !== 'closed' || !payload.pull_request.merged ||
      payload.pull_request.merge_commit_sha !== pr.merge_commit_sha)) {
    throw new Error('Evento de merge inconsistente com a PR.');
  }
  // Evento de merge usa a declaracao do autor naquele momento; dispatch le o corpo atual.
  const scopes = applications(manual ? pr.body : payload.pull_request.body);
  return { number, sha: pr.merge_commit_sha, scopes, repository: `${owner}/${repo}` };
}

async function readTags(github, repo, component) {
  const refs = await github.paginate(github.rest.git.listMatchingRefs, {
    ...repo, ref: `tags/${component}/v`, per_page: 100,
  });
  const tags = [];
  for (const ref of refs) {
    const tag = ref.ref.replace(/^refs\/tags\//, '');
    const version = parseVersion(tag, component);
    let sha = ref.object.sha;
    let receipt = null;
    if (ref.object.type === 'tag') {
      const { data: annotated } = await github.rest.git.getTag({ ...repo, tag_sha: sha });
      if (annotated.object.type !== 'commit') throw new Error(`Tag deve apontar diretamente para commit: ${tag}`);
      sha = annotated.object.sha;
      try { receipt = JSON.parse(annotated.message); } catch { /* Tag historica sem recibo. */ }
      if (receipt?.schema !== SCHEMA) receipt = null;
      if (receipt && (receipt.tag !== tag || receipt.sha !== sha || receipt.component !== component ||
          receipt.version !== version.version || receipt.repository !== `${repo.owner}/${repo.repo}` ||
          !Number.isSafeInteger(receipt.pr) || !Array.isArray(receipt.components))) {
        throw new Error(`Recibo inconsistente: ${tag}`);
      }
    } else if (ref.object.type !== 'commit') throw new Error(`Objeto de tag invalido: ${tag}`);
    if (!SHA.test(sha)) throw new Error(`Commit invalido: ${tag}`);
    tags.push({ tag, sha, receipt, ...version });
  }
  return tags;
}

function existingRelease(tags, pr, component) {
  const existing = tags.filter(t => t.receipt?.pr === pr.number);
  if (existing.length > 1) throw new Error(`Releases duplicadas para PR #${pr.number}: ${component}`);
  const found = existing[0];
  if (found && (found.sha !== pr.sha || JSON.stringify(found.receipt.components) !== JSON.stringify(pr.scopes))) {
    throw new Error(`SHA ou lista de aplicativos alterados para PR #${pr.number}.`);
  }
  return found?.receipt;
}

async function architectureAt(github, repo, sha, tags) {
  for (const tag of [...tags].sort((a, b) => compare(b, a))) {
    const { data } = await github.rest.repos.compareCommitsWithBasehead({
      ...repo, basehead: `${tag.sha}...${sha}`,
    });
    if (data.status === 'ahead' || data.status === 'identical') {
      return { tag: tag.tag, version: tag.version, sha: tag.sha };
    }
  }
  return null;
}

async function publish({ github, context, core, dryRun = false }) {
  const pr = await pullRequest(github, context);
  const repo = context.repo;
  const receipts = [];
  for (const component of pr.scopes) {
    let completed = false;
    for (let attempt = 0; attempt < 10; attempt++) {
      const tags = await readTags(github, repo, component);
      const existing = existingRelease(tags, pr, component);
      if (existing) {
        receipts.push(existing);
        core.info(`Ja publicada: ${existing.tag} -> ${existing.sha}`);
        completed = true;
        break;
      }
      const version = nextVersion(tags);
      const tag = `${component}/v${version}`;
      const plannedArchitecture = dryRun && receipts.find(r => r.component === 'architecture');
      const architecture = component === 'architecture' ? null : plannedArchitecture ?
        { tag: plannedArchitecture.tag, version: plannedArchitecture.version, sha: plannedArchitecture.sha } :
        await architectureAt(github, repo, pr.sha, await readTags(github, repo, 'architecture'));
      const receipt = {
        schema: SCHEMA, repository: pr.repository, pr: pr.number, sha: pr.sha,
        components: pr.scopes, component, version, tag, architecture,
      };
      if (dryRun) {
        receipts.push(receipt);
        completed = true;
        break;
      }
      const { data: object } = await github.rest.git.createTag({
        ...repo, tag, message: JSON.stringify(receipt, null, 2), object: pr.sha, type: 'commit',
      });
      try {
        // Create-only e a operacao atomica: nunca atualizar/forcar uma ref.
        await github.rest.git.createRef({ ...repo, ref: `refs/tags/${tag}`, sha: object.sha });
      } catch (error) {
        // Uma resposta perdida tambem pode ter criado a ref. Releitura confirma
        // idempotencia ou disputa; 403/regras de protecao nunca sao ignorados.
        if (![409, 422, 500, 502, 503, 504].includes(error.status)) throw error;
        const after = await readTags(github, repo, component);
        if (!after.some(t => t.tag === tag)) throw error;
        continue;
      }
      core.info(`Publicada: ${tag} -> ${pr.sha}`);
      receipts.push(receipt);
      completed = true;
      break;
    }
    if (!completed) throw new Error(`Disputa persistente de numeracao: ${component}. Reexecute o workflow.`);
  }
  await core.summary.addHeading(`${dryRun ? 'Simulacao (sem escrita)' : 'Release'} da PR #${pr.number}`)
    .addCodeBlock(JSON.stringify(receipts, null, 2), 'json').write();
  return receipts;
}

module.exports = { SCHEMA, applications, parseVersion, nextVersion, pullRequest, readTags, architectureAt, publish };
