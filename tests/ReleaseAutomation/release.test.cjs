'use strict';

const { test } = require('node:test');
const assert = require('node:assert/strict');
const { SCHEMA, classify, parseVersion, nextVersion, publish } = require('../../scripts/component-release/release.cjs');
const { buildManifest } = require('../../scripts/component-release/build-manifest.cjs');

const sha = n => n.toString(16).padStart(40, '0');
const repo = { owner: 'owner', repo: 'repo' };
function context(number = 1, labels = ['app:clinica'], commit = sha(10)) {
  const pr = {
    number, labels: labels.map(name => ({ name })), merged: true, state: 'closed',
    merge_commit_sha: commit, base: { ref: 'main', repo: { full_name: 'owner/repo' } },
  };
  return { repo, eventName: 'pull_request_target', payload: {
    action: 'closed', repository: { default_branch: 'main' }, pull_request: pr,
  } };
}

function fake(...contexts) {
  const refs = new Map();
  const objects = new Map();
  const prs = new Map(contexts.map(c => [c.payload.pull_request.number, c.payload.pull_request]));
  let counter = 1000;
  const state = { refs, objects, writes: [], fail: null, loseResponse: false, forbidden: false };
  const git = {
    listMatchingRefs: async ({ ref }) => [...refs.entries()]
      .filter(([name]) => name.startsWith(`refs/${ref}`))
      .map(([ref, object]) => ({ ref, object })),
    getTag: async ({ tag_sha }) => ({ data: objects.get(tag_sha) }),
    createTag: async input => {
      if (state.forbidden) throw Object.assign(new Error('Forbidden'), { status: 403 });
      const id = sha(counter++);
      objects.set(id, { message: input.message, object: { type: input.type, sha: input.object } });
      return { data: { sha: id } };
    },
    createRef: async ({ ref, sha: id }) => {
      if (state.fail && ref.includes(state.fail)) throw Object.assign(new Error('Falha simulada'), { status: 503 });
      if (refs.has(ref)) throw Object.assign(new Error('Reference already exists'), { status: 422 });
      refs.set(ref, { type: 'tag', sha: id });
      state.writes.push(ref);
      if (state.loseResponse) {
        state.loseResponse = false;
        throw Object.assign(new Error('Resposta perdida'), { status: 502 });
      }
      return {};
    },
  };
  const github = {
    paginate: (method, params) => method(params),
    rest: { git, pulls: { get: async ({ pull_number }) => ({ data: prs.get(pull_number) }) },
      repos: { compareCommitsWithBasehead: async ({ basehead }) => {
        const [base, head] = basehead.split('...');
        return { data: { status: base === head ? 'identical' : base < head ? 'ahead' : 'behind' } };
      } },
    },
  };
  const core = { info() {}, summary: {
    addHeading() { return this; }, addCodeBlock() { return this; }, async write() {},
  } };
  state.run = context => publish({ github, context, core });
  state.seed = (tag, commit, receipt) => {
    const id = sha(counter++);
    if (receipt) objects.set(id, { message: JSON.stringify(receipt), object: { type: 'commit', sha: commit } });
    refs.set(`refs/tags/${tag}`, { type: receipt ? 'tag' : 'commit', sha: receipt ? id : commit });
  };
  return state;
}

test('labels: arquitetura, misto, varios apps, duplicadas e labels comuns', () => {
  assert.deepEqual(classify(['app:fiscal', 'bug', 'architecture', 'app:clinica', 'app:fiscal'].map(name => ({ name }))),
    ['architecture', 'clinica', 'fiscal']);
  for (const labels of [[], ['bug'], ['app:unknown'], ['app:architecture'], ['app:Clinica'], ['app:']]) {
    assert.throws(() => classify(labels.map(name => ({ name }))));
  }
});

test('sequencias numericas independentes e largura minima, sem rollover de major', () => {
  assert.equal(nextVersion([]), '01.001');
  const versions = ['01.009', '01.999', '02.003'].map(v => parseVersion(`fiscal/v${v}`, 'fiscal'));
  assert.equal(nextVersion(versions), '02.004');
  assert.equal(nextVersion([parseVersion('clinica/v01.999', 'clinica')]), '01.1000');
  for (const tag of ['clinica/v1.001', 'clinica/v01.01', 'clinica/v01.0001', 'clinica/v01.001-beta']) {
    assert.throws(() => parseVersion(tag, 'clinica'));
  }
});

test('merge de aplicativo cria apenas sua release no SHA exato, nunca HEAD', async () => {
  const ctx = context();
  const state = fake(ctx);
  state.seed('fiscal/v01.045', sha(3));
  state.seed('clinica/v01.003', sha(4));
  const [receipt] = await state.run(ctx);
  assert.equal(receipt.tag, 'clinica/v01.004');
  assert.equal(receipt.sha, ctx.payload.pull_request.merge_commit_sha);
  assert.equal(receipt.architecture, null);
  assert.deepEqual(state.writes, ['refs/tags/clinica/v01.004']);
});

test('merge de arquitetura nao incrementa aplicativos', async () => {
  const ctx = context(1, ['architecture']);
  const state = fake(ctx);
  state.seed('clinica/v01.005', sha(2));
  assert.equal((await state.run(ctx))[0].tag, 'architecture/v01.001');
  assert.deepEqual(state.writes, ['refs/tags/architecture/v01.001']);
});

test('merge misto e multiapp registra a arquitetura publicada no mesmo SHA', async () => {
  const ctx = context(1, ['app:fiscal', 'app:clinica', 'architecture']);
  const state = fake(ctx);
  const receipts = await state.run(ctx);
  assert.deepEqual(receipts.map(x => x.tag), ['architecture/v01.001', 'clinica/v01.001', 'fiscal/v01.001']);
  for (const app of receipts.slice(1)) {
    assert.deepEqual(app.architecture, { tag: 'architecture/v01.001', version: '01.001', sha: sha(10) });
    assert.deepEqual(app.components, ['architecture', 'clinica', 'fiscal']);
    assert.equal(app.pr, 1);
    assert.equal(app.repository, 'owner/repo');
  }
});

test('arquitetura utilizada deve ser ancestral do merge, nao uma tag posterior', async () => {
  const ctx = context();
  const state = fake(ctx);
  state.seed('architecture/v01.001', sha(2));
  state.seed('architecture/v01.002', sha(20));
  assert.equal((await state.run(ctx))[0].architecture.tag, 'architecture/v01.001');
});

test('reexecucao apos outros merges preserva numero e referencia da arquitetura', async () => {
  const ctx = context();
  const state = fake(ctx);
  const first = await state.run(ctx);
  state.seed('architecture/v01.001', sha(2));
  state.seed('clinica/v01.002', sha(20));
  assert.deepEqual(await state.run(ctx), first);
  assert.equal(state.writes.length, 1);
});

test('falha parcial retoma sem duplicar componente ja publicado', async () => {
  const ctx = context(1, ['architecture', 'app:clinica', 'app:fiscal']);
  const state = fake(ctx);
  state.fail = 'clinica/';
  await assert.rejects(state.run(ctx), /Falha simulada/);
  assert.deepEqual(state.writes, ['refs/tags/architecture/v01.001']);
  state.fail = null;
  const result = await state.run(ctx);
  assert.equal(result.length, 3);
  assert.equal(new Set(state.writes).size, 3);
  assert.equal(state.writes.length, 3);
});

test('merges concorrentes disputam a mesma ref e recebem numeros diferentes', async () => {
  const a = context(1), b = context(2, ['app:clinica'], sha(11));
  const state = fake(a, b);
  const result = await Promise.all([state.run(a), state.run(b)]);
  assert.deepEqual(result.flat().map(x => x.tag).sort(), ['clinica/v01.001', 'clinica/v01.002']);
  assert.equal(state.writes.length, 2);
  assert.deepEqual(new Set(result.flat().map(x => x.sha)), new Set([sha(10), sha(11)]));
});

test('execucoes concorrentes da mesma PR sao idempotentes', async () => {
  const ctx = context();
  const state = fake(ctx);
  const result = await Promise.all([state.run(ctx), state.run(ctx)]);
  assert.deepEqual(result[0], result[1]);
  assert.equal(state.writes.length, 1);
});

test('rajada de dez merges nao perde PRs nem repete numeros', async () => {
  const contexts = Array.from({ length: 10 }, (_, i) => context(i + 1, ['app:clinica'], sha(i + 10)));
  const state = fake(...contexts);
  const results = (await Promise.all(contexts.map(c => state.run(c)))).flat();
  assert.equal(new Set(results.map(r => r.pr)).size, 10);
  assert.equal(new Set(results.map(r => r.tag)).size, 10);
  assert.equal(state.writes.length, 10);
});

test('resposta perdida depois da criacao da ref e reconciliada', async () => {
  const ctx = context();
  const state = fake(ctx);
  state.loseResponse = true;
  assert.equal((await state.run(ctx))[0].tag, 'clinica/v01.001');
  assert.equal(state.writes.length, 1);
});

test('403 de permissao interrompe sem publicar tags', async () => {
  const ctx = context();
  const state = fake(ctx);
  state.forbidden = true;
  await assert.rejects(state.run(ctx), /Forbidden/);
  assert.equal(state.writes.length, 0);
});

test('PR sem merge, branch incorreta, SHA divergente e escopo invalido falham antes de escrever', async () => {
  const mutations = [
    c => { c.payload.pull_request.merged = false; },
    c => { c.payload.pull_request.base.ref = 'develop'; },
    c => { c.payload.pull_request.base.repo.full_name = 'other/repo'; },
    c => { c.payload.pull_request.merge_commit_sha = 'invalid'; },
    c => { c.payload.pull_request.labels = [{ name: 'bug' }]; },
    c => { c.payload.pull_request.labels = [{ name: 'app:unknown' }]; },
    c => { c.payload.action = 'opened'; },
  ];
  for (const mutate of mutations) {
    const ctx = context(); mutate(ctx);
    const state = fake(ctx);
    await assert.rejects(state.run(ctx));
    assert.equal(state.writes.length, 0);
  }
  const ctx = context(), state = fake(ctx);
  const snapshot = structuredClone(ctx);
  snapshot.payload.pull_request.merge_commit_sha = sha(99);
  await assert.rejects(state.run(snapshot), /inconsistente/);
});

test('dispatch recupera PR mergeada e recusa alterar escopo de release existente', async () => {
  const ctx = context();
  const state = fake(ctx);
  const manual = { ...ctx, eventName: 'workflow_dispatch', payload: {
    repository: ctx.payload.repository, inputs: { pr_number: '1' },
  } };
  const first = await state.run(manual);
  assert.deepEqual(await state.run(manual), first);
  ctx.payload.pull_request.labels = [{ name: 'app:fiscal' }];
  await assert.rejects(state.run(manual), /classificacao alterados/);
  assert.equal(state.writes.length, 1);
});

test('recibo inconsistente e tags malformadas nao sao silenciosamente ignorados', async () => {
  const ctx = context(), state = fake(ctx);
  state.seed('clinica/v01.001', sha(3), { schema: SCHEMA, tag: 'clinica/v01.001', sha: sha(4) });
  await assert.rejects(state.run(ctx), /Recibo inconsistente/);
  state.refs.clear();
  state.seed('clinica/vbad', sha(3));
  await assert.rejects(state.run(ctx), /Formato de tag invalido/);
  assert.equal(state.writes.length, 0);
});

test('tags duplicadas por PR exigem intervencao, sem nova publicacao', async () => {
  const ctx = context(), state = fake(ctx);
  const [receipt] = await state.run(ctx);
  state.seed('clinica/v01.002', sha(10), { ...receipt, tag: 'clinica/v01.002', version: '01.002' });
  await assert.rejects(state.run(ctx), /duplicadas/);
  assert.equal(state.writes.length, 1);
});

test('manifesto de build registra recibo e exige checkout/tag/arquitetura consistentes', async () => {
  const ctx = context(1, ['architecture', 'app:clinica']), state = fake(ctx);
  const [, receipt] = await state.run(ctx);
  const git = args => {
    if (args[0] === 'cat-file') return `object ${receipt.sha}\ntype commit\n\n${JSON.stringify(receipt)}`;
    if (args[0] === 'merge-base') return '';
    return sha(10);
  };
  assert.deepEqual(buildManifest(receipt.tag, git), receipt);
  assert.throws(() => buildManifest(receipt.tag, args => args.includes('HEAD') ? sha(99) : git(args)), /checkout/);
  assert.throws(() => buildManifest(receipt.tag, args => args.some(a => a.includes('architecture/')) ? sha(99) : git(args)), /arquitetura/);
  assert.throws(() => buildManifest('app:unknown/v01.001', git), /desconhecido/);
});
