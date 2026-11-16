'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const { SCHEMA, classify, identity, parseVersion, prepare, plan, publish } = require('../../scripts/component-release/release.cjs');
const sha = n => n.toString(16).padStart(40, '0');
function fixture(numbers = [35]) {
  const repo = { owner: 'owner', repo: 'repo' };
  const prs = new Map(numbers.map(n => [n, { number: n, state: 'open', draft: false, user: { login: 'author' }, changed_files: 1,
    labels: [{ name: 'app:fiscal' }], head: { sha: sha(n), ref: `pr-${n}`, repo: { full_name: 'owner/repo' } },
    base: { ref: 'main', repo: { full_name: 'owner/repo' } } }]));
  const locals = new Map(numbers.map(n => [sha(n), { fiscal: identity('fiscal', '01.006', n) }]));
  const refs = new Map(), objects = new Map();
  let counter = 100;
  const state = { prs, locals, refs, objects, writes: [], reviews: null, fail: null, race: false, forbidden: false, loseResponse: false };
  const git = {
    listMatchingRefs: async () => [...refs].map(([ref, object]) => ({ ref, object })),
    getRef: async ({ ref }) => {
      if (!refs.has(`refs/${ref}`)) throw Object.assign(new Error('Not found'), { status: 404 });
      return { data: { object: refs.get(`refs/${ref}`) } };
    },
    getTag: async ({ tag_sha }) => ({ data: objects.get(tag_sha) }),
    createTag: async input => {
      if (state.forbidden) throw Object.assign(new Error('Forbidden'), { status: 403 });
      const id = sha(counter++); objects.set(id, { message: input.message, object: { type: input.type, sha: input.object } });
      return { data: { sha: id } };
    },
    createRef: async ({ ref, sha: id }) => {
      if (ref.includes(state.fail || 'never-match')) throw new Error('Falha simulada');
      if (refs.has(ref)) throw Object.assign(new Error('Already exists'), { status: 422 });
      refs.set(ref, { type: 'tag', sha: id }); state.writes.push(ref);
      if (state.loseResponse) { state.loseResponse = false; throw new Error('Resposta perdida'); }
      return {};
    },
    getCommit: async () => ({ data: { tree: { sha: sha(1) } } }),
    createTree: async input => { state.tree = input; return { data: { sha: state.unchanged ? sha(1) : sha(2) } }; },
    createCommit: async input => {
      state.commit = input;
      if (state.race) prs.get(35).head.sha = sha(99);
      return { data: { sha: sha(3) } };
    },
    updateRef: async input => { state.writes.push(input); return {}; },
  };
  const github = { paginate: (method, params) => method(params), rest: { git, pulls: {
    get: async ({ pull_number }) => ({ data: structuredClone(prs.get(pull_number)) }),
    listFiles: async ({ pull_number }) => state.files || [{ filename: 'src/Studio/Yeshua.Studio.Fiscal/X.cs' }],
    listReviews: async ({ pull_number }) => state.reviews || [{ state: 'APPROVED', user: { login: 'reviewer' },
      author_association: 'COLLABORATOR', commit_id: prs.get(pull_number).head.sha }],
  }, repos: { getContent: async ({ ref, path }) => {
    const value = locals.get(ref)?.[path.split('/').at(-1).replace('.json', '')];
    if (!value) throw Object.assign(new Error('Identidade ausente'), { status: 404 });
    return { data: { type: 'file', encoding: 'base64', content: Buffer.from(JSON.stringify(value)).toString('base64') } };
  } } } };
  const core = { info() {}, summary: { addHeading() { return this; }, addCodeBlock() { return this; }, async write() {} } };
  state.context = n => ({ repo, eventName: 'workflow_dispatch', payload: { repository: { default_branch: 'main' },
    inputs: { pr_number: String(n), versions: '{"fiscal":"01.006"}' } } });
  state.run = (n = 35, options = {}) => publish({ github, context: state.context(n), core, expectedSha: sha(n), ...options });
  state.prepare = () => prepare({ github, context: state.context(35), core });
  state.plan = () => plan({ github, context: state.context(35) });
  state.github = github;
  return state;
}
test('identidade canonica inclui PR, sem ordenar PR nem calcular proxima base', () => {
  assert.equal(parseVersion('fiscal/v01.006-PR35', 'fiscal').version, '01.006-PR35');
  for (const tag of ['fiscal/v01.006', 'fiscal/v1.006-PR35', 'fiscal/v01.0006-PR35', 'fiscal/v01.006-PR0']) assert.throws(() => parseVersion(tag, 'fiscal'));
  assert.deepEqual(classify([{ name: 'architecture' }, { name: 'app:fiscal' }]), ['architecture', 'fiscal']);
  assert.throws(() => classify([{ name: 'app:unknown' }]));
});
test('duas PRs paralelas mesma base publicam commits independentes sem substituicao', async () => {
  const s = fixture([35, 36]);
  const results = (await Promise.all([s.run(36), s.run(35)])).flat();
  assert.deepEqual(results.map(r => r.tag), ['fiscal/v01.006-PR36', 'fiscal/v01.006-PR35']);
  assert.deepEqual(results.map(r => r.sha), [sha(36), sha(35)]);
  assert.ok(results.every(r => r.schema === SCHEMA));
  assert.equal(s.refs.size, 2);
  assert.deepEqual(await s.run(35), [results[1]]);
  assert.equal(s.writes.length, 2);
});
test('preparacao grava somente identidades no pai exato, sem force, sem SHA circular', async () => {
  const s = fixture(); await s.prepare();
  assert.deepEqual(s.commit.parents, [sha(35)]);
  assert.equal(s.tree.tree[0].path, 'release-identities/fiscal.json');
  assert.deepEqual(JSON.parse(s.tree.tree[0].content), identity('fiscal', '01.006', 35));
  assert.deepEqual(s.writes, [{ owner: 'owner', repo: 'repo', ref: 'heads/pr-35', sha: sha(3), force: false }]);
});
test('push concorrente interrompe preparacao antes de atualizar branch', async () => {
  const s = fixture(); s.race = true;
  await assert.rejects(s.prepare(), /PR mudou/); assert.equal(s.writes.length, 0);
});
test('PR publicada nao pode ser re-preparada', async () => {
  const s = fixture(); await s.run();
  await assert.rejects(s.prepare(), /ja possui release/);
});
test('labels validam caminhos, multicomponente inclui todos os arquivos locais', async () => {
  const s = fixture(); s.files = [{ filename: 'src/Studio/Yeshua.Studio.Central/X.cs' }];
  await assert.rejects(s.run(), /Labels nao cobrem/);
  s.prs.get(35).labels.push({ name: 'app:central' });
  s.locals.get(sha(35)).central = identity('central', '02.003', 35);
  const r = await s.run(); assert.equal(r.length, 2);
  assert.deepEqual(r.map(x => x.tag), ['central/v02.003-PR35', 'fiscal/v01.006-PR35']);
});
test('qualquer identidade ausente ou incoerente bloqueia todo o conjunto antes de escrever', async () => {
  for (const mutate of [s => delete s.locals.get(sha(35)).fiscal,
    s => { s.locals.get(sha(35)).fiscal.pr = 36; },
    s => { s.locals.get(sha(35)).fiscal = { schema: SCHEMA, component: 'fiscal', state: 'development' }; },
    s => { s.locals.get(sha(35)).fiscal.tag = 'fiscal/v01.006-PR36'; },
    s => { s.prs.get(35).labels.push({ name: 'architecture' }); }]) {
    const s = fixture(); mutate(s); await assert.rejects(s.run()); assert.equal(s.writes.length, 0);
  }
});
test('head mudou, fork, evento de merge, draft e revisao insuficiente bloqueiam publicacao', async () => {
  for (const mutate of [s => { s.prs.get(35).head.sha = sha(99); },
    s => { s.prs.get(35).head.repo.full_name = 'fork/repo'; },
    s => { s.prs.get(35).draft = true; }, s => { s.reviews = []; },
    s => { s.reviews = [{ user: { login: 'r' }, state: 'APPROVED', author_association: 'COLLABORATOR', commit_id: sha(1) }]; }]) {
    const s = fixture(); mutate(s); await assert.rejects(s.run()); assert.equal(s.writes.length, 0);
  }
  const s = fixture();
  const ctx = s.context(35); ctx.eventName = 'pull_request_target';
  await assert.rejects(publish({ github: s.github, context: ctx }), /dispatch/);
  await assert.rejects(s.run(35, { expectedSha: undefined }), /SHA validado/);
});
test('merge e squash nao mudam commit de origem; release independe do merge SHA', async () => {
  const s = fixture(); Object.assign(s.prs.get(35), { state: 'closed', merged: true, merge_commit_sha: sha(777) });
  assert.equal((await s.run())[0].sha, sha(35));
});
test('tag imutavel, resposta perdida e falha parcial permitem retomada exata', async () => {
  const s = fixture(); s.loseResponse = true;
  await assert.rejects(s.run(), /Resposta perdida/);
  const r = await s.run(); assert.equal(s.writes.length, 1);
  s.locals.set(sha(99), { fiscal: identity('fiscal', '01.006', 35) }); s.prs.get(35).head.sha = sha(99);
  await assert.rejects(s.run(35, { expectedSha: sha(99) }), /Colisao imutavel/);
  assert.equal(r[0].sha, sha(35));
  const m = fixture(); m.prs.get(35).labels.push({ name: 'architecture' });
  m.locals.get(sha(35)).architecture = identity('architecture', '01.001', 35); m.fail = 'fiscal/';
  await assert.rejects(m.run(), /Falha simulada/); assert.equal(m.refs.size, 1);
  m.fail = null; assert.equal((await m.run()).length, 2); assert.equal(m.writes.length, 2);
});
test('dry run nao escreve e 403 nunca e ignorado', async () => {
  const s = fixture(); await s.run(35, { dryRun: true }); assert.equal(s.objects.size, 0);
  s.forbidden = true; await assert.rejects(s.run(), /Forbidden/); assert.equal(s.refs.size, 0);
});

test('preparacao identica nao cria commit; lista parcial e falha de fast-forward nao sao ocultadas', async () => {
  const same = fixture(); same.unchanged = true;
  assert.equal(await same.prepare(), sha(35)); assert.equal(same.commit, undefined); assert.equal(same.writes.length, 0);
  const partial = fixture(); partial.prs.get(35).changed_files = 2;
  await assert.rejects(partial.prepare(), /Lista de arquivos incompleta/); assert.equal(partial.writes.length, 0);
  const raced = fixture();
  raced.github.rest.git.updateRef = async ({ force }) => {
    assert.equal(force, false); throw Object.assign(new Error('Not a fast forward'), { status: 422 });
  };
  await assert.rejects(raced.prepare(), /Not a fast forward/); assert.equal(raced.writes.length, 0);
});
