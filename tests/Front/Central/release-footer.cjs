'use strict';
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const http = require('node:http');
const { chromium } = require('playwright');
const root = path.resolve(__dirname, '../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const dashboard = fs.readFileSync(path.join(root, 'spa/views/dashboard.html'), 'utf8');
const footer = dashboard.slice(dashboard.indexOf('<footer id="component-release-footer"'));
const sha = n => n.toString(16).padStart(40, '0');
const webRepo = 'playsistemasinteligentes/YeshuaCreator';

(async () => {
    let browser, server;
    try {
        server = http.createServer((req, res) => {
            const pathname = new URL(req.url, 'http://localhost').pathname;
            if (pathname === '/') {
                res.setHeader('Content-Type', 'text/html; charset=utf-8');
                res.end(`<!doctype html><html lang="pt-BR"><head><meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="/spa/styles/release-footer.css"></head><body style="margin:0;font-family:Arial,sans-serif"><main style="padding:24px"><h1>Central Yeshua</h1><p>Aplicativos</p></main>${footer}<script type="module">import {bindReleaseFooter} from '/spa/scripts/release-footer.js';bindReleaseFooter();bindReleaseFooter();</script></body></html>`);
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
        const errors = [], requests = [];
        page.on('pageerror', error => errors.push(error.message));
        await page.addInitScript(() => localStorage.setItem('token', 'SECRET_CENTRAL_TOKEN'));
        let revision = 1, unavailable = false;
        await page.route(`https://api.github.com/repos/${webRepo}/**`, async route => {
            requests.push(route.request());
            assert.equal(route.request().headers().authorization, undefined);
            assert.equal(route.request().headers().cookie, undefined);
            if (unavailable) { await route.fulfill({ status: 403, json: { message: 'rate limited' } }); return; }
            const data = [];
            for (const [component, n] of [['architecture', 1], ['clinica', 2], ['fiscal', 4], ...(revision > 1 ? [['clinica', 3]] : [])]) {
                const version = component === 'clinica' && n === 3 ? '01.002' : '01.001';
                const tag = `${component}/v${version}`;
                data.push({ ref: `refs/tags/${tag}`, object: { type: 'tag', sha: sha(n + 100) }, annotation: {
                    sha: sha(n + 100), tag, object: { type: 'commit', sha: sha(n) }, message: JSON.stringify({
                        schema: 'yeshua.release/v1', repository: webRepo, component, components: [component],
                        pr: n + 20, sha: sha(n), version, tag, architecture: null
                    })
                } });
            }
            const url = route.request().url();
            await route.fulfill({ status: 200, json: url.endsWith('/git/matching-refs/tags/')
                ? data.map(({ annotation, ...ref }) => ref) : data.find(x => x.object.sha === url.split('/').at(-1)).annotation });
        });
        await page.goto(`http://127.0.0.1:${server.address().port}/`);
        await page.getByText('Clínica · 01.001', { exact: true }).waitFor();
        assert.equal(await page.locator('.yeshua-release-component').count(), 7);
        assert.equal(requests.length, 4, 'binding repetido nao duplica leitura');
        assert.ok((await page.locator('#component-release-footer').innerText()).includes('Versões implantadas e em desenvolvimento não verificadas'));
        await page.getByText('Clínica · 01.001', { exact: true }).click();
        await page.getByText('Histórico: 1 de 1 releases.').waitFor();
        assert.equal(await page.getByRole('link', { name: 'PR #22', exact: true }).getAttribute('href'), `https://github.com/${webRepo}/pull/22`);
        assert.equal(await page.getByRole('link', { name: 'clinica/v01.001', exact: true }).getAttribute('href'), `https://github.com/${webRepo}/tree/clinica%2Fv01.001`);
        await page.screenshot({ path: '/tmp/yeshua-release-footer-desktop.png', fullPage: true });
        revision = 2;
        await page.getByRole('button', { name: 'Atualizar versões', exact: true }).click();
        await page.getByText('Clínica · 01.002', { exact: true }).waitFor();
        assert.equal(await page.getByText('Fiscal · 01.001', { exact: true }).count(), 1);
        await page.setViewportSize({ width: 360, height: 800 });
        const summary = page.getByText('Clínica · 01.002', { exact: true });
        await summary.focus(); await page.keyboard.press('Enter');
        await page.getByText('Histórico: 2 de 2 releases.').waitFor();
        assert.equal(await page.getByRole('link', { name: 'PR #23', exact: true }).count(), 1);
        assert.equal(await page.getByRole('link', { name: 'PR #22', exact: true }).count(), 1);
        assert.equal(await page.evaluate(() => document.documentElement.scrollWidth <= innerWidth), true, 'sem overflow mobile');
        await page.screenshot({ path: '/tmp/yeshua-release-footer-mobile.png', fullPage: true });
        unavailable = true;
        await page.getByRole('button', { name: 'Atualizar versões', exact: true }).click();
        await page.getByRole('status').filter({ hasText: 'limitada pelo GitHub' }).waitFor();
        assert.equal(await page.locator('.yeshua-release-component').count(), 0, 'falha nao preserva versoes antigas como atuais');
        unavailable = false;
        await page.getByRole('button', { name: 'Atualizar versões', exact: true }).click();
        await page.getByText('Clínica · 01.002', { exact: true }).waitFor();
        assert.deepEqual(errors, []);
        console.log(JSON.stringify({ passed: true, components: 7, independentRefresh: true, historyLinks: true,
            keyboard: true, mobileOverflow: false, unavailableAndRecovery: true, credentialsSent: false, jsErrors: errors.length }));
    } finally {
        if (browser) await browser.close();
        if (server) await new Promise(resolve => server.close(resolve));
    }
})().catch(error => { console.error(error.stack || error.message); process.exitCode = 1; });
