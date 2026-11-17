'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const sourcePath = path.resolve(__dirname, '../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/spa/scripts/component-releases.js');
const source = fs.readFileSync(sourcePath, 'utf8');
const modulePromise = import(`data:text/javascript;base64,${Buffer.from(source).toString('base64')}`);
const sha = n => n.toString(16).padStart(40, '0');
function fixture() {
    const state = { refs: [], annotations: new Map(), requests: [], time: 0, status: 200, failTags: false };
    state.seed = (component, version, number) => {
        const tag = `${component}/v${version}`, id = sha(number + 100), commit = sha(number);
        const ref = { ref: `refs/tags/${tag}`, object: { type: 'tag', sha: id } };
        const receipt = { schema: 'yeshua.release/v1', repository: 'playsistemasinteligentes/YeshuaCreator',
            pr: number, component, components: [component], tag, version, sha: commit, architecture: null };
        state.refs.push(ref);
        state.annotations.set(id, { sha: id, tag, object: { type: 'commit', sha: commit }, message: JSON.stringify(receipt) });
        return { ref, receipt, annotation: state.annotations.get(id) };
    };
    state.fetch = async (url, options) => {
        state.requests.push({ url, options });
        const isRefs = url.endsWith('/git/matching-refs/tags/');
        const status = !isRefs && state.failTags ? 503 : state.status;
        return { ok: status === 200, status, json: async () => structuredClone(isRefs ? state.refs : state.annotations.get(url.split('/').at(-1))) };
    };
    return state;
}
test('registro visual corresponde exatamente ao registro fechado da automacao', async () => {
    const { components } = await modulePromise;
    assert.deepEqual(Object.keys(components), require('../../../scripts/component-release/components.json'));
});
test('ultima versao e numerica, por componente, com links derivados do recibo', async () => {
    const { createReleaseClient } = await modulePromise;
    const state = fixture(); state.seed('clinica', '01.999', 1); state.seed('clinica', '01.1000', 2); state.seed('fiscal', '02.003', 3);
    const client = createReleaseClient(state.fetch, () => state.time);
    const data = await client.latest();
    assert.equal(data.rows.find(r => r.component === 'clinica').release.version, '01.1000');
    const fiscal = data.rows.find(r => r.component === 'fiscal').release;
    assert.equal(fiscal.version, '02.003');
    assert.equal(fiscal.prUrl, 'https://github.com/playsistemasinteligentes/YeshuaCreator/pull/3');
    assert.equal(fiscal.commitUrl, `https://github.com/playsistemasinteligentes/YeshuaCreator/commit/${sha(3)}`);
    assert.equal(data.rows.find(r => r.component === 'architecture').release, null);
    assert.equal(state.requests.length, 3, 'uma leitura de refs e somente as duas anotacoes mais recentes');
    for (const request of state.requests) {
        assert.equal(request.options.credentials, 'omit'); assert.equal(request.options.method, 'GET');
        assert.deepEqual(Object.keys(request.options.headers), ['Accept']);
        assert.equal(request.options.referrerPolicy, 'no-referrer');
    }
});
test('atualizacao apos nova release altera somente seu componente; cache nao consulta em cada navegacao', async () => {
    const { createReleaseClient } = await modulePromise;
    const state = fixture(); state.seed('clinica', '01.001', 1); state.seed('fiscal', '01.001', 2);
    const client = createReleaseClient(state.fetch, () => state.time);
    const before = await client.latest();
    const count = state.requests.length;
    state.seed('clinica', '01.002', 3);
    assert.equal(await client.latest(), before); assert.equal(state.requests.length, count);
    const after = await client.latest(true);
    assert.equal(after.rows.find(r => r.component === 'clinica').release.version, '01.002');
    assert.deepEqual(after.rows.find(r => r.component === 'fiscal'), before.rows.find(r => r.component === 'fiscal'));
    state.time += 300001;
    await client.latest(); assert.equal(state.requests.length, count + 3);
});
test('ausencia de release difere de erro de leitura e falha nao retorna snapshot antigo como atual', async () => {
    const { createReleaseClient } = await modulePromise;
    const state = fixture(); const client = createReleaseClient(state.fetch, () => state.time);
    assert.ok((await client.latest()).rows.every(row => row.release === null && !row.error));
    state.status = 403;
    await assert.rejects(client.latest(true), /limitada/);
    await assert.rejects(client.latest(), /limitada/);
    state.status = 200; state.seed('fiscal', '01.001', 1);
    assert.equal((await client.latest()).rows.find(r => r.component === 'fiscal').release.version, '01.001');
});
test('recibo corrompido, tag leve ou nao canonica bloqueiam componente sem exibir versao anterior', async () => {
    const { createReleaseClient } = await modulePromise;
    for (const mutate of [
        seed => { seed.annotation.message = '{}'; },
        seed => { seed.annotation.object.sha = sha(99); },
        seed => { seed.annotation.tag = 'fiscal/v01.001'; },
        seed => { seed.ref.object.type = 'commit'; },
        seed => { seed.annotation.message = JSON.stringify({ ...seed.receipt, repository: 'evil/repo' }); },
        seed => { seed.annotation.message = JSON.stringify({ ...seed.receipt, pr: 'javascript:alert(1)' }); },
        seed => { seed.ref.ref = 'refs/tags/clinica/v01.0002'; },
    ]) {
        const state = fixture(); state.seed('clinica', '01.001', 1); mutate(state.seed('clinica', '01.002', 2));
        state.seed('fiscal', '01.001', 3);
        const rows = (await createReleaseClient(state.fetch).latest()).rows;
        const row = rows.find(r => r.component === 'clinica');
        assert.ok(row.error); assert.equal(row.release, undefined);
        assert.equal(rows.find(r => r.component === 'fiscal').release.version, '01.001');
    }
});
test('historico e limitado, ordenado e contem tag/PR/commit; leitura de anotacao pode ser repetida apos falha', async () => {
    const { createReleaseClient } = await modulePromise;
    const state = fixture();
    for (let n = 1; n <= 12; n++) state.seed('clinica', `01.${String(n).padStart(3, '0')}`, n);
    const client = createReleaseClient(state.fetch);
    await client.latest();
    const result = await client.history('clinica');
    assert.equal(result.total, 12); assert.equal(result.entries.length, 10);
    assert.equal(result.entries[0].pr, 12); assert.equal(result.entries.at(-1).pr, 3);
    assert.equal(state.requests.length, 11);
    await assert.rejects(client.history('unknown'), /desconhecido/);
    const failing = fixture(); failing.seed('clinica', '01.001', 1); failing.failTags = true;
    const retry = createReleaseClient(failing.fetch);
    assert.ok((await retry.latest()).rows.find(r => r.component === 'clinica').error);
    failing.failTags = false;
    assert.equal((await retry.latest(true)).rows.find(r => r.component === 'clinica').release.version, '01.001');
});
