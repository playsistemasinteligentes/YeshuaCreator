'use strict';
const assert = require('node:assert/strict');
async function assertReleaseDetails(page, component, pr, sha) {
  const name = component === 'central' ? 'Central' : 'Fiscal';
  const item = page.locator(`[data-component="${component}"]`);
  const summary = item.locator('summary');
  await page.getByText(`${name} v01.006-PR${pr}`, { exact: true }).waitFor();
  assert.equal(await item.getAttribute('open'), null, 'detalhes inicialmente recolhidos');
  await summary.focus();
  await page.keyboard.press('Enter');
  await item.locator('dl').waitFor({ state: 'visible' });
  assert.equal(await item.locator('dt').allTextContents().then(labels => labels.join('|')), 'Componente|Versão-base|PR de origem|Tag instalável|SHA / commit');
  const values = await item.locator('dd').allTextContents();
  assert.deepEqual(values, [`${name} (${component})`, '01.006', `PR${pr}`, `${component}/v01.006-PR${pr}`, sha || 'Não disponível na identidade local.']);
  await page.keyboard.press('Enter');
  assert.equal(await item.getAttribute('open'), null, 'teclado recolhe e preserva foco');
  assert.equal(await summary.evaluate(node => node === document.activeElement), true);
}
async function assertPublishedFooter(address, pr) {
  const { chromium } = require('playwright');
  const dashboard = await (await fetch(address + '/spa/views/dashboard.html')).text();
  const start = dashboard.indexOf('<footer id="component-release-footer"');
  assert.ok(start >= 0);
  const footer = dashboard.slice(start, dashboard.indexOf('</footer>', start) + '</footer>'.length);
  const browser = await chromium.launch({ headless: true });
  try {
    const page = await browser.newPage({ viewport: { width: 1280, height: 800 } });
    const external = [], errors = [];
    page.on('pageerror', error => errors.push(error.message));
    await page.route('**/*', async route => {
      if (!route.request().url().startsWith(address + '/')) {
        external.push(route.request().url()); await route.abort(); return;
      }
      await route.continue();
    });
    await page.route(address + '/__release-ui', route => route.fulfill({ contentType: 'text/html; charset=utf-8', body:
      `<!doctype html><html lang="pt-BR"><head><meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="/spa/styles/release-footer.css"></head><body style="margin:0"><main><h1>Central</h1><input aria-label="Campo existente" value="preservado"></main>${footer}<script type="module">import {bindReleaseFooter} from '/spa/scripts/release-footer.js';bindReleaseFooter();bindReleaseFooter();</script></body></html>` }));
    await page.goto(address + '/__release-ui');
    await assertReleaseDetails(page, 'central', pr);
    await assertReleaseDetails(page, 'fiscal', pr);
    assert.equal(await page.locator('.yeshua-release-component').first().getAttribute('data-component'), 'central');
    assert.equal(await page.getByText(`Central v01.006-PR${pr === 35 ? 36 : 35}`, { exact: true }).count(), 0);
    assert.equal(await page.getByText('outras origens incluídas', { exact: false }).count(), 0);
    await page.getByRole('button', { name: 'Atualizar versões' }).click();
    await page.locator('#component-release-footer[aria-busy="false"]').waitFor();
    assert.equal(await page.getByRole('textbox', { name: 'Campo existente' }).inputValue(), 'preservado');
    await page.setViewportSize({ width: 360, height: 800 });
    await assertReleaseDetails(page, 'central', pr);
    await page.locator('[data-component="central"] summary').click();
    assert.ok(await page.evaluate(() => document.documentElement.scrollWidth <= innerWidth), 'sem overflow no mobile, inclusive detalhes');
    await page.screenshot({ path: `/tmp/yeshua-local-release-PR${pr}.png`, fullPage: true });
    assert.deepEqual(external, [], 'nenhuma dependencia de GitHub ou rede externa');
    assert.deepEqual(errors, []);
  } finally { await browser.close(); }
}
module.exports = { assertReleaseDetails, assertPublishedFooter };
