'use strict';

const PROPS = 'Directory.Build.props';
const VERSION = /^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)$/;
function readVersion(xml) {
  const matches = [...xml.matchAll(/<Version>([^<]+)<\/Version>/g)];
  const value = matches[0]?.[1];
  if (matches.length !== 1 || !VERSION.test(value) || value.split('.').some(n => Number(n) > 65534)) {
    throw new Error('Directory.Build.props deve conter uma Version major.minor.patch valida para .NET.');
  }
  return value;
}
function increment(xml) {
  const current = readVersion(xml);
  const [major, minor, patch] = current.split('.').map(Number);
  if (patch === 65534) throw new Error('Patch esgotado para AssemblyVersion; revisar major/minor explicitamente.');
  const version = `${major}.${minor}.${patch + 1}`;
  return { version, xml: xml.replace(`<Version>${current}</Version>`, `<Version>${version}</Version>`) };
}

async function publish({ github, context, core, dryRun = false }) {
  const repo = context.repo;
  const manual = context.eventName === 'workflow_dispatch';
  if (!manual && (context.eventName !== 'pull_request_target' || context.payload.action !== 'closed' ||
      !context.payload.pull_request?.merged)) throw new Error('Somente merge efetivo publica versao.');
  if (manual && context.ref !== 'refs/heads/main') throw new Error('Recuperacao somente na main.');
  const number = manual ? Number(context.payload.inputs?.pr_number) : context.payload.pull_request.number;
  if (!Number.isSafeInteger(number) || number < 1) throw new Error('PR invalida.');
  const { data: pr } = await github.rest.pulls.get({ ...repo, pull_number: number });
  if (!pr.merged || pr.state !== 'closed' || pr.base.ref !== 'main' ||
      pr.base.repo.full_name !== `${repo.owner}/${repo.repo}` || !/^[a-f0-9]{40}$/.test(pr.merge_commit_sha) ||
      (!manual && context.payload.pull_request.merge_commit_sha !== pr.merge_commit_sha)) {
    throw new Error('PR deve estar incorporada na main deste repositorio.');
  }
  // Recibo no proprio commit: sobrevive a falha antes da criacao da tag.
  const marker = `Yeshua-Release-PR: ${number}\nYeshua-Merge-SHA: ${pr.merge_commit_sha}`;
  const head = async () => (await github.rest.git.getRef({ ...repo, ref: 'heads/main' })).data.object.sha;
  const props = async sha => {
    const { data } = await github.rest.repos.getContent({ ...repo, path: PROPS, ref: sha });
    if (data.type !== 'file' || data.encoding !== 'base64') throw new Error('Props nao e arquivo base64.');
    return Buffer.from(data.content, 'base64').toString('utf8');
  };
  const ref = async version => {
    try { return (await github.rest.git.getRef({ ...repo, ref: `tags/${version}` })).data.object; }
    catch (error) { if (error.status === 404) return null; throw error; }
  };
  const tag = async (version, sha) => {
    if (readVersion(await props(sha)) !== version) throw new Error('Tag e props divergentes.');
    const existing = await ref(version);
    if (existing && (existing.type !== 'commit' || existing.sha !== sha)) throw new Error(`Tag ${version} ja pertence a outro commit; nao sera movida.`);
    if (!existing && !dryRun) {
      try { await github.rest.git.createRef({ ...repo, ref: `refs/tags/${version}`, sha }); }
      catch (error) {
        const after = await ref(version);
        if (after?.type !== 'commit' || after.sha !== sha) throw error;
      }
    }
    core.info(`${dryRun ? 'Simulacao' : 'Versao'} ${version} -> ${sha} (PR #${number})`);
    return { version, sha, pr: number, dryRun };
  };

  for (let attempt = 0; attempt < 20; attempt++) {
    const base = await head();
    const { data: ancestry } = await github.rest.repos.compareCommitsWithBasehead({
      ...repo, basehead: `${pr.merge_commit_sha}...${base}`,
    });
    if (!['ahead', 'identical'].includes(ancestry.status)) throw new Error('Merge nao e ancestral da main.');
    // Paginacao completa, sem janela temporal: rerun antigo tambem e idempotente.
    const commits = await github.paginate(github.rest.repos.listCommits, { ...repo, sha: base, path: PROPS, per_page: 100 });
    const existing = commits.filter(c => c.commit.message.endsWith(`\n\n${marker}`));
    if (existing.length > 1) throw new Error(`Recibos duplicados para PR #${number}.`);
    if (existing.length) return tag(readVersion(await props(existing[0].sha)), existing[0].sha);

    const next = increment(await props(base));
    if (await ref(next.version)) {
      if (await head() !== base) continue;
      throw new Error(`Tag ${next.version} ja existe sem recibo desta PR.`);
    }
    if (dryRun) {
      core.info(`Simulacao: PR #${number}, ${next.version}, pai ${base}; nenhuma escrita.`);
      return { version: next.version, parent: base, pr: number, dryRun };
    }
    const { data: parent } = await github.rest.git.getCommit({ ...repo, commit_sha: base });
    const { data: tree } = await github.rest.git.createTree({
      ...repo, base_tree: parent.tree.sha,
      tree: [{ path: PROPS, mode: '100644', type: 'blob', content: next.xml }],
    });
    const { data: commit } = await github.rest.git.createCommit({
      ...repo, message: `chore: versao global ${next.version}\n\n${marker}`, tree: tree.sha, parents: [base],
    });
    try {
      // Fast-forward apenas: dois filhos do mesmo pai nao podem vencer juntos.
      await github.rest.git.updateRef({ ...repo, ref: 'heads/main', sha: commit.sha, force: false });
    } catch (error) {
      // Resposta perdida ou disputa: releitura do historico recupera o recibo.
      // Proibicao de escrita nunca e contornada.
      if (error.status === 403) throw error;
      const after = await head();
      if (after === base) throw error;
      continue;
    }
    return tag(next.version, commit.sha);
  }
  throw new Error('Main mudou repetidamente; reexecute para recuperar sem duplicar.');
}
module.exports = { PROPS, readVersion, increment, publish };
