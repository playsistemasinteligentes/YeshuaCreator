'use strict';
// Ensaio opcional com navegador; node:test cobre dados e o host publicado sem Playwright.
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const http = require('node:http');
const { chromium } = require('playwright');
const { assertReleaseDetails } = require('./release-footer.assertions.cjs');
const { identity } = require('../../../scripts/component-release/release.cjs');
const root = path.resolve(__dirname, '../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const dashboard = fs.readFileSync(path.join(root, 'spa/views/dashboard.html'), 'utf8');
const footer = dashboard.slice(dashboard.indexOf('<footer id="component-release-footer"'));
(async () => {
  let server, browser;
  let pr = 35, unavailable = false, development = false;
  const requests = [];
  try {
    server = http.createServer((req, res) => {
      const pathname = new URL(req.url, 'http://localhost').pathname;
      if (pathname === '/') {
        res.setHeader('Content-Type', 'text/html; charset=utf-8');
        res.end(`<!doctype html><html lang="pt-BR"><head><meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="/spa/styles/release-footer.css"></head><body>${footer}<script type="module">import {bindReleaseFooter} from '/spa/scripts/release-footer.js';bindReleaseFooter();bindReleaseFooter();</script></body></html>`);
        return;
      }
      if (pathname.startsWith('/spa/release-identities/')) {
        requests.push(pathname);
        if (unavailable) { res.writeHead(503).end(); return; }
        res.setHeader('Content-Type', 'application/json');
        const component = pathname.split('/').at(-1).replace('.json', '');
        if (development && component === 'fiscal') { res.writeHead(404).end(); return; }
        const value = development && component === 'central' ? { schema: 'yeshua.release/v2', component, state: 'development' } : identity(component, '01.006', pr);
        if (!development && component === 'fiscal') value.sha = 'a'.repeat(40);
        res.end(JSON.stringify(value));
        return;
      }
      const file = path.resolve(root, '.' + pathname);
      if (!file.startsWith(root + path.sep) || !fs.existsSync(file)) { res.writeHead(404).end(); return; }
      res.setHeader('Content-Type', file.endsWith('.js') ? 'text/javascript' : 'text/css');
      res.end(fs.readFileSync(file));
    });
    await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
    browser = await chromium.launch({ headless: true });
    const page = await browser.newPage({ viewport: { width: 360, height: 800 } });
    const external = [], errors = [];
    page.on('request', request => { if (!request.url().startsWith('http://127.0.0.1:')) external.push(request.url()); });
    page.on('pageerror', error => errors.push(error.message));
    await page.goto(`http://127.0.0.1:${server.address().port}/`);
    await page.getByText('Fiscal v01.006-PR35', { exact: true }).waitFor();
    assert.equal(requests.length, 7);
    await assertReleaseDetails(page, 'central', 35);
    await assertReleaseDetails(page, 'fiscal', 35, 'a'.repeat(40));
    pr = 36;
    await page.getByRole('button', { name: 'Atualizar versões' }).click();
    await page.getByText('Fiscal v01.006-PR36', { exact: true }).waitFor();
    await assertReleaseDetails(page, 'central', 36);
    development = true;
    await page.getByRole('button', { name: 'Atualizar versões' }).click();
    await page.getByText('Central · Desenvolvimento', { exact: true }).waitFor();
    await page.getByText('Fiscal · Versão desconhecida', { exact: true }).waitFor();
    await page.locator('[data-component=central] summary').click();
    await page.getByText('Ambiente de desenvolvimento, sem release instalável declarada.', { exact: true }).waitFor();
    await page.locator('[data-component=fiscal] summary').click();
    await page.getByText('Arquivo de identidade local ausente.', { exact: true }).waitFor();
    unavailable = true;
    await page.getByRole('button', { name: 'Atualizar versões' }).click();
    await page.getByText('Leitura local parcial.', { exact: true }).waitFor();
    assert.equal(await page.getByText('Fiscal v01.006-PR36', { exact: true }).count(), 0);
    assert.deepEqual(external, []); assert.deepEqual(errors, []);
    assert.ok(await page.evaluate(() => document.documentElement.scrollWidth <= innerWidth));
    console.log('Rodape local: detalhes PR35/PR36, SHA opcional, teclado, mobile, desenvolvimento, desconhecido e falha OK.');
  } finally {
    if (browser) await browser.close();
    if (server) await new Promise(resolve => server.close(resolve));
  }
})().catch(error => { console.error(error); process.exitCode = 1; });
