'use strict';
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const http = require('node:http');
const { chromium } = require('playwright');
const root = path.resolve(__dirname, '../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const dashboard = fs.readFileSync(path.join(root, 'spa/views/dashboard.html'), 'utf8');
const footer = dashboard.slice(dashboard.indexOf('<footer id="release-footer"'));

(async () => {
    let browser, server;
    try {
        server = http.createServer((req, res) => {
            const pathname = new URL(req.url, 'http://localhost').pathname;
            if (pathname === '/') {
                res.setHeader('Content-Type', 'text/html; charset=utf-8');
                res.end(`<!doctype html><html lang="pt-BR"><head><meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="/spa/styles/release-footer.css"></head><body><main><h1>Central</h1></main>${footer}<script>var environments = {authenticationApi: '/central/yapi', urlApi: '/fiscal/yapi'};</script><script type="module">import {bindReleaseFooter} from '/spa/scripts/release-footer.js';window.bindFooter=bindReleaseFooter;bindReleaseFooter();bindReleaseFooter();</script></body></html>`);
                return;
            }
            const file = path.resolve(root, '.' + pathname);
            if (!file.startsWith(root + path.sep) || !fs.existsSync(file)) { res.writeHead(404).end(); return; }
            res.setHeader('Content-Type', file.endsWith('.js') ? 'text/javascript' : 'text/css');
            res.end(fs.readFileSync(file));
        });
        await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
        browser = await chromium.launch({ headless: true });
        const page = await browser.newPage({ viewport: { width: 1366, height: 900 } });
        const errors = [], calls = [], external = [];
        page.on('pageerror', error => errors.push(error.message));
        let version = '1.0.7', mode = 'success';
        await page.route('**/*', async route => {
            const request = route.request();
            const url = new URL(request.url());
            if (url.hostname !== '127.0.0.1') { external.push(url.href); await route.abort(); return; }
            if (!url.pathname.endsWith('/version')) { await route.continue(); return; }
            calls.push(request);
            assert.equal(url.pathname, '/central/yapi/version', 'consulta Central mesmo com Fiscal selecionado');
            assert.equal(request.headers().authorization, undefined);
            if (mode === 'network') { await route.abort(); return; }
            await route.fulfill({ status: mode === 'failure' ? 503 : 200, json: { version } });
        });
        await page.addInitScript(() => {
            const originalFetch = window.fetch;
            window.versionFetchOptions = [];
            window.fetch = (url, options) => {
                if (String(url).endsWith('/version')) window.versionFetchOptions.push(options);
                return originalFetch(url, options);
            };
        });
        const base = `http://127.0.0.1:${server.address().port}/`;
        await page.goto(base);
        await page.getByRole('status').filter({ hasText: 'Versão 1.0.7' }).waitFor();
        assert.equal(calls.length, 1, 'binds simultaneos usam uma chamada');
        assert.deepEqual(await page.evaluate(() => window.versionFetchOptions), [{cache: 'no-store'}]);
        const remount = async () => page.evaluate(async html => {
            document.getElementById('release-footer').remove();
            document.body.insertAdjacentHTML('beforeend', html);
            await Promise.all([window.bindFooter(), window.bindFooter()]);
        }, footer);
        version = '1.0.8';
        await remount();
        assert.equal(await page.getByRole('status').innerText(), 'Versão 1.0.7');
        assert.equal(calls.length, 1, 'remontagem nao consulta nova release');
        await page.setViewportSize({ width: 360, height: 800 });
        assert.equal(await page.evaluate(() => document.documentElement.scrollWidth <= innerWidth), true);
        await page.screenshot({ path: '/tmp/yeshua-global-version-mobile.png', fullPage: true });
        await page.reload();
        await page.getByRole('status').filter({ hasText: 'Versão 1.0.8' }).waitFor();
        assert.equal(calls.length, 2, 'reload completo consulta a instalacao corrente');
        for (const failure of ['failure', 'network', 'invalid']) {
            mode = failure; if (failure === 'invalid') version = 'central/v01.001';
            const before = calls.length;
            await page.reload();
            await page.getByRole('status').filter({ hasText: 'Versão indisponível' }).waitFor();
            await remount();
            assert.equal(await page.getByRole('status').innerText(), 'Versão indisponível');
            assert.equal(calls.length, before + 1, 'falha tambem e cacheada sem retry');
        }
        assert.deepEqual(external, []); assert.deepEqual(errors, []);
        console.log(JSON.stringify({ passed: true, oncePerLoad: true, remount: true, installationVersion: true,
            centralApiWithOtherApp: true, httpAndNetworkFailure: true, invalidVersion: true, githubRequests: 0, jsErrors: 0 }));
    } finally {
        if (browser) await browser.close();
        if (server) await new Promise(resolve => server.close(resolve));
    }
})().catch(error => { console.error(error.stack || error.message); process.exitCode = 1; });
