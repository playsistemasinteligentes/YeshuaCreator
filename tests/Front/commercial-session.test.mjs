import test from 'node:test';
import assert from 'node:assert/strict';
import { pathToFileURL } from 'node:url';
import path from 'node:path';

const moduleUrl = pathToFileURL(path.resolve('src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/spa/scripts/ServicesGlobal/apiFetch.js')).href;
const token = (seconds, commercial = true) => 'header.' + Buffer.from(JSON.stringify({
    exp: Math.floor(Date.now() / 1000) + seconds, ...(commercial ? { usageRights: '[{"Resource":"example.access","Until":9999999999,"GrantedUnits":0}]' } : {})
})).toString('base64url') + '.signature';
function storage(initial) {
    const values = new Map([['token', initial]]);
    return { getItem: key => values.get(key) ?? null, setItem: (key, value) => values.set(key, String(value)), removeItem: key => values.delete(key) };
}

test('commercial renewal is shared by concurrent requests and preserves the application scope', async () => {
    globalThis.localStorage = storage(token(60)); globalThis.environments = { authenticationApi: '/central', urlApi: '/clinic' };
    const calls = [], renewed = token(1800), scoped = token(1800);
    globalThis.fetch = async url => {
        calls.push(url);
        if (url.includes('AtualizarAcesso')) return new Response(JSON.stringify({ token: renewed }), { status: 200 });
        if (url.endsWith('/getMenu')) return new Response('[]', { status: 200, headers: { 'X-Yeshua-Application-Token': scoped } });
        return new Response('{}', { status: 200 });
    };
    const { apiFetch } = await import(moduleUrl + '?concurrent');
    await Promise.all(Array.from({ length: 20 }, () => apiFetch('/clinic/business')));
    assert.equal(calls.filter(url => url.includes('AtualizarAcesso')).length, 1);
    assert.equal(calls.filter(url => url.endsWith('/getMenu')).length, 1);
    assert.equal(calls.filter(url => url.endsWith('/business')).length, 20);
    assert.equal(localStorage.getItem('token'), scoped);
    assert(Number(localStorage.getItem('tokenExp')) > Date.now());
});

test('a short remaining entitlement does not trigger central renewal on every operation', async () => {
    globalThis.localStorage = storage(token(60)); globalThis.environments = { authenticationApi: '/central', urlApi: '/central' };
    let renewals = 0;
    globalThis.fetch = async url => {
        if (url.includes('AtualizarAcesso')) { renewals++; return new Response(JSON.stringify({ token: token(60) })); }
        return new Response('{}');
    };
    const { apiFetch } = await import(moduleUrl + '?short-entitlement');
    for (let index = 0; index < 20; index++) await apiFetch('/central/business');
    assert.equal(renewals, 1);
});

test('temporary renewal failure preserves the still valid token without repeated requests', async () => {
    const original = token(60);
    globalThis.localStorage = storage(original); globalThis.environments = { authenticationApi: '/central', urlApi: '/central' };
    let renewals = 0, operations = 0;
    globalThis.fetch = async url => {
        if (url.includes('AtualizarAcesso')) { renewals++; return new Response('{}', { status: 503 }); }
        operations++; return new Response('{}');
    };
    const { apiFetch } = await import(moduleUrl + '?unavailable');
    for (let index = 0; index < 10; index++) assert.equal((await apiFetch('/central/business')).status, 200);
    assert.equal(renewals, 1); assert.equal(operations, 10);
    assert.equal(localStorage.getItem('token'), original);
});

test('ordinary requests with a long lived token have no extra financial HTTP calls', async () => {
    globalThis.localStorage = storage(token(1800)); globalThis.environments = { authenticationApi: '/central', urlApi: '/clinic' };
    const calls = []; globalThis.fetch = async url => { calls.push(url); return new Response('{}'); };
    const { apiFetch } = await import(moduleUrl + '?no-financial-io');
    for (let index = 0; index < 100; index++) await apiFetch('/clinic/business');
    assert.equal(calls.length, 100);
    assert(calls.every(url => url === '/clinic/business'));
});
