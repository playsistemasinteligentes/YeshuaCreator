'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const { inferLabels, labelPullRequest } = require('../../scripts/component-release/classification.cjs');

const front = 'src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/Custon/Apps/';
const cases = [
  ['release-identities/fiscal.json', 'app:fiscal'],
  ['release-identities/central.json', 'app:central'],
  ['release-identities/architecture.json', 'architecture'],
  ['src/Studio/Yeshua.Studio.AppClinicas/Migrations/M1.cs', 'app:clinica'],
  ['src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Custon/X.cs', 'app:clinica'],
  ['src/CQRS/Application/Yeshua.APS.ADM.CQRS.Application.Command/X.cs', 'app:aps-adm'],
  ['tests/CQRS/Yeshua.APS.Cadastros.CQRS.Tests.Integration.Api.Smoke/X.cs', 'app:aps-cadastros'],
  ['src/CQRS/Domain/Yeshua.MDFe.CQRS.Domain/X.cs', 'app:fiscal'],
  ['src/Studio/Yeshua.Studio.Fiscal/Migrations/M1.cs', 'app:fiscal'],
  ['src/Studio/Yeshua.Studio.Central/Migrations/M1.cs', 'app:central'],
  ['infra/Memorias/DockerCompose/deploy.sh', 'app:memorias'],
  ['docs/operational/clinica/README.md', 'app:clinica'],
  ['tests/Front/Clinica/foo.test.cjs', 'app:clinica'],
  [front + 'Clinica/pages/agenda.js', 'app:clinica'],
  [front + 'APS.ADM/pages/carga.js', 'app:aps-adm'],
  [front + 'Memorias/pages/video.js', 'app:memorias'],
  ['src/Engine/Yeshua.Engine/Templates/X.cs', 'architecture'],
  ['src/CQRS/Domain/Yeshua.CQRS.Domain/X.cs', 'architecture'],
  ['infra/Shared/DockerCompose/docker-compose.yml', 'architecture'],
  ['.github/workflows/component-release.yml', 'architecture'],
  ['unknown/file.txt', 'architecture'],
];
test('classificacao respeita projetos, telas hospedadas na Central e caminhos compartilhados', () => {
  for (const [filename, label] of cases) assert.deepEqual(inferLabels([{ filename }]), [label], filename);
  assert.deepEqual(inferLabels(cases.map(([filename]) => ({ filename }))),
    ['app:aps-adm', 'app:aps-cadastros', 'app:central', 'app:clinica', 'app:fiscal', 'app:memorias', 'architecture']);
});
test('rename considera origem e destino; exclusao continua classificada', () => {
  assert.deepEqual(inferLabels([{ filename: front + 'Clinica/x.js', previous_filename: front + 'Fiscal/x.js' }]),
    ['app:clinica', 'app:fiscal']);
  assert.deepEqual(inferLabels([{ filename: 'infra/Fiscal/old.sh', status: 'removed' }]), ['app:fiscal']);
  assert.throws(() => inferLabels([]));
  assert.throws(() => inferLabels([{}]));
});

function fixture() {
  const pr = { state: 'open', changed_files: 1, labels: [{ name: 'bug' }, { name: 'app:fiscal' }],
    head: { sha: 'head' }, base: { sha: 'base', ref: 'main', repo: { full_name: 'owner/repo' } } };
  const state = { pr, writes: [], reads: 0, incomplete: false, race: false, forbidden: false, labelRace: false };
  const github = { paginate: (method, params) => method(params), rest: {
    pulls: {
      get: async () => {
        state.reads++;
        if (state.race && state.reads === 2) pr.head.sha = 'changed';
        return { data: structuredClone(pr) };
      },
      listFiles: async () => state.incomplete ? [] : [{ filename: front + 'Clinica/pages/agenda.js' }],
    },
    issues: {
      listLabelsForRepo: async () => [{ name: 'architecture' }],
      createLabel: async ({ name }) => {
        if (state.forbidden) throw Object.assign(new Error('Forbidden'), { status: 403 });
        if (state.labelRace) throw Object.assign(new Error('Already exists'), { status: 422 });
        state.writes.push(name);
      },
      getLabel: async () => ({}),
      addLabels: async ({ labels }) => {
        state.writes.push(labels);
        pr.labels.push(...labels.map(name => ({ name })));
      },
    },
  } };
  const context = { repo: { owner: 'owner', repo: 'repo' }, payload: {
    repository: { default_branch: 'main' }, pull_request: { number: 27 },
  } };
  const core = { info() {}, summary: { addHeading() { return this; }, addRaw() { return this; }, async write() {} } };
  state.run = () => labelPullRequest({ github, context, core });
  return state;
}
test('cria labels ausentes, preserva escopo manual e valida sem novo evento labeled', async () => {
  const state = fixture();
  assert.deepEqual(await state.run(), ['clinica', 'fiscal']);
  assert.equal(state.writes.length, 7); // seis labels criadas + uma adicao
  assert.equal(state.reads, 3);
  assert.deepEqual(state.writes.at(-1), ['app:clinica']);
  state.writes.length = 0;
  await state.run();
  assert.ok(state.writes.every(write => typeof write === 'string')); // nenhuma adicao repetida
  assert.ok(state.pr.labels.some(l => l.name === 'bug'));
});
test('lista parcial, PR fechada, destino errado, label invalida e corrida falham antes da escrita', async () => {
  for (const mutate of [s => { s.incomplete = true; }, s => { s.pr.state = 'closed'; },
    s => { s.pr.base.ref = 'other'; }, s => { s.pr.base.repo.full_name = 'other/repo'; },
    s => { s.pr.labels.push({ name: 'app:unknown' }); }, s => { s.race = true; }]) {
    const state = fixture(); mutate(state);
    await assert.rejects(state.run());
    assert.deepEqual(state.writes, []);
  }
});
test('403 de labels nao e ocultado; criacao concorrente 422 e confirmada por GET', async () => {
  const denied = fixture(); denied.forbidden = true;
  await assert.rejects(denied.run(), /Forbidden/);
  assert.deepEqual(denied.writes, []);
  const raced = fixture(); raced.labelRace = true;
  assert.deepEqual(await raced.run(), ['clinica', 'fiscal']);
  assert.deepEqual(raced.writes, [['app:clinica']]);
});
