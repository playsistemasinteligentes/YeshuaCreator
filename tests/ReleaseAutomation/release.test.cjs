'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const { readFileSync } = require('node:fs');
const { readVersion, increment, publish } = require('../../scripts/global-release/release.cjs');
const initialProps = readFileSync('Directory.Build.props', 'utf8');
const sha = n => n.toString(16).padStart(40, '0');
const fault = status => Object.assign(new Error(`HTTP ${status}`), { status });

// Git DAG + fast-forward rules in memory; never writes .git or remote refs.
function fixture() {
  let seq = 100;
  const state = { head: sha(1), commits: new Map(), trees: new Map(), tags: new Map(), updates: 0, conflicts: 0 };
  state.commits.set(state.head, { sha: state.head, xml: initialProps, parent: null, message: 'merge', tree: { sha: state.head } });
  state.trees.set(state.head, initialProps);
  function ancestor(base, tip) {
    while (tip) { if (base === tip) return true; tip = state.commits.get(tip)?.parent; }
    return false;
  }
  function history(tip) {
    const result = [];
    while (tip) { const c = state.commits.get(tip); result.push({ sha: tip, commit: { message: c.message } }); tip = c.parent; }
    return result;
  }
  const github = {
    paginate: async (method, args) => method(args),
    rest: {
      pulls: { get: async ({ pull_number }) => ({ data: { number: pull_number, merged: true, state: 'closed',
        base: { ref: 'main', repo: { full_name: 'owner/repo' } }, merge_commit_sha: sha(1) } }) },
      repos: {
        getContent: async ({ ref }) => ({ data: { type: 'file', encoding: 'base64', content: Buffer.from(state.commits.get(ref).xml).toString('base64') } }),
        compareCommitsWithBasehead: async ({ basehead }) => {
          const [base, tip] = basehead.split('...');
          return { data: { status: base === tip ? 'identical' : ancestor(base, tip) ? 'ahead' : 'diverged' } };
        },
        listCommits: async ({ sha: tip }) => history(tip),
      },
      git: {
        getRef: async ({ ref }) => {
          if (ref === 'heads/main') return { data: { object: { type: 'commit', sha: state.head } } };
          if (!state.tags.has(ref.slice(5))) throw fault(404);
          return { data: { object: { type: 'commit', sha: state.tags.get(ref.slice(5)) } } };
        },
        getCommit: async ({ commit_sha }) => ({ data: state.commits.get(commit_sha) }),
        createTree: async ({ base_tree, tree }) => {
          assert.equal(state.trees.has(base_tree), true);
          assert.equal(tree.length, 1); assert.equal(tree[0].path, 'Directory.Build.props');
          const id = sha(seq++); state.trees.set(id, tree[0].content); return { data: { sha: id } };
        },
        createCommit: async ({ tree, parents, message }) => {
          assert.equal(parents.length, 1);
          const id = sha(seq++);
          state.commits.set(id, { sha: id, xml: state.trees.get(tree), parent: parents[0], message, tree: { sha: tree } });
          return { data: { sha: id } };
        },
        updateRef: async ({ sha: id, force, ref }) => {
          assert.equal(force, false); assert.equal(ref, 'heads/main');
          if (state.denied) throw fault(403);
          if (!ancestor(state.head, id)) { state.conflicts++; throw fault(422); }
          state.head = id; state.updates++;
          if (state.loseUpdateResponse) { state.loseUpdateResponse = false; throw fault(502); }
        },
        createRef: async ({ ref, sha: id }) => {
          if (state.failTag) throw fault(403);
          const tag = ref.slice('refs/tags/'.length);
          if (state.tags.has(tag)) throw fault(422);
          assert.equal(readVersion(state.commits.get(id).xml), tag);
          assert.equal(ancestor(id, state.head), true, 'tag only after main accepted version commit');
          state.tags.set(tag, id);
          if (state.loseTagResponse) { state.loseTagResponse = false; throw fault(502); }
        },
      },
    },
  };
  const run = (n = 1, options = {}) => publish({ github, core: { info() {} }, context: {
    repo: { owner: 'owner', repo: 'repo' }, eventName: 'pull_request_target',
    payload: { action: 'closed', pull_request: { number: n, merged: true, merge_commit_sha: sha(1) } },
    ...options.context,
  }, dryRun: options.dryRun });
  return { state, run, github };
}

test('primeiro merge: um incremento; tag aponta para props correto e commit associado a PR', async () => {
  const { state, run } = fixture(); const r = await run();
  assert.equal(r.version, '1.0.1'); assert.notEqual(r.sha, sha(1));
  assert.equal(state.tags.get('1.0.1'), r.sha); assert.equal(state.head, r.sha);
  assert.equal(state.commits.get(r.sha).xml, initialProps.replace('<Version>1.0.0</Version>', '<Version>1.0.1</Version>'));
  assert.match(state.commits.get(r.sha).message, /Yeshua-Release-PR: 1/);
  assert.equal(state.updates, 1);
});
test('rerun antigo depois de outro merge nao incrementa nem cria segunda tag', async () => {
  const { state, run } = fixture(); const a = await run(1); const b = await run(2);
  assert.deepEqual(await run(1), a); assert.deepEqual(await run(2), b);
  assert.equal(state.updates, 2); assert.equal(state.tags.size, 2);
});
test('falha entre commit e tag recupera somente tag', async () => {
  const { state, run } = fixture(); state.failTag = true;
  await assert.rejects(run(), /403/); const committed = state.head;
  assert.equal(state.updates, 1); assert.equal(state.tags.size, 0);
  state.failTag = false; const r = await run();
  assert.equal(r.sha, committed); assert.equal(state.updates, 1); assert.equal(state.tags.size, 1);
});
test('respostas perdidas apos update e tag sao idempotentes', async () => {
  const { state, run } = fixture(); state.loseUpdateResponse = true; state.loseTagResponse = true;
  const r = await run(); assert.equal(state.updates, 1); assert.equal(state.tags.size, 1);
  assert.deepEqual(await run(), r);
});
test('tres merges concorrentes e reruns concorrentes preservam todos os incrementos', async () => {
  const { state, run } = fixture();
  const results = await Promise.all([run(1), run(2), run(3), run(1)]);
  assert.equal(state.updates, 3); assert.equal(state.tags.size, 3); assert.ok(state.conflicts > 0);
  assert.deepEqual([...state.tags.keys()].sort(), ['1.0.1', '1.0.2', '1.0.3']);
  assert.deepEqual(results[0], results[3]);
  await Promise.all([run(1), run(2), run(3)]);
  assert.equal(state.updates, 3);
});
test('main protegida recusa escrita sem tag e sem contorno', async () => {
  const { state, run } = fixture(); state.denied = true;
  await assert.rejects(run(), /403/); assert.equal(state.head, sha(1)); assert.equal(state.tags.size, 0);
});
test('colisao de tag nunca move tag nem grava props', async () => {
  const { state, run } = fixture(); state.tags.set('1.0.1', sha(99));
  await assert.rejects(run(), /ja existe/); assert.equal(state.updates, 0); assert.equal(state.tags.get('1.0.1'), sha(99));
});
test('dry run sem escrita; dispatch restrito a main e PR incorporada', async () => {
  const { state, run } = fixture();
  const r = await run(1, { dryRun: true }); assert.equal(r.version, '1.0.1');
  assert.equal(state.updates, 0); assert.equal(state.commits.size, 1);
  await assert.rejects(run(1, { context: { eventName: 'workflow_dispatch', ref: 'refs/heads/other', payload: { inputs: { pr_number: '1' } } } }), /main/);
});
test('aprovacao, abertura e fechamento sem merge nao publicam', async () => {
  const { state, run } = fixture();
  for (const context of [ { eventName: 'pull_request_review' }, { payload: { action: 'opened' } }, { payload: { action: 'closed', pull_request: { merged: false } } } ]) {
    await assert.rejects(run(1, { context }), /merge efetivo/);
  }
  assert.equal(state.updates, 0);
});
test('formato unico .NET, patch e limite de assembly', () => {
  assert.equal(increment('<Version>1.2.9</Version>').version, '1.2.10');
  for (const x of ['01.001', 'v1.0.0', 'central/v1.0.0', '01.0.0', '1.0.65535']) assert.throws(() => readVersion(`<Version>${x}</Version>`));
  assert.throws(() => increment('<Version>1.0.65534</Version>'));
  assert.throws(() => readVersion('<Version>1.0.0</Version><Version>2.0.0</Version>'));
});
