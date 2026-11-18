const assert = require('node:assert/strict');
const fs = require('node:fs');
const http = require('node:http');
const path = require('node:path');
const { chromium } = require('playwright');
const root = path.resolve(__dirname, '../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const artifact = path.resolve(__dirname, '../../../artifacts/financeiro');
let server, browser;
(async () => {
    fs.mkdirSync(artifact, { recursive: true });
    server = http.createServer((request, response) => {
        const pathname = new URL(request.url, 'http://localhost').pathname;
        if (pathname === '/fixture') {
            response.setHeader('Content-Type', 'text/html; charset=utf-8');
            response.end('<!doctype html><html><head><meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="/spa/styles/yeshua-ui.css"><link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css"></head><body><main id="app"></main><script>window.environments={authenticationApi:"/yapi",urlApi:"/yapi"};</script><script type="module">import {renderFinanceiro} from "/Custon/Apps/Central/pages/financeiro.js"; await renderFinanceiro(); window.fixtureReady=true;</script></body></html>'); return;
        }
        const file = path.resolve(root, '.' + pathname);
        if (!file.startsWith(root + path.sep) || !fs.existsSync(file) || !fs.statSync(file).isFile()) return response.writeHead(404).end();
        response.setHeader('Content-Type', file.endsWith('.js') ? 'text/javascript' : file.endsWith('.css') ? 'text/css' : 'text/html');
        response.end(fs.readFileSync(file));
    });
    await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
    browser = await chromium.launch({ channel: 'msedge', headless: true });
    const page = await browser.newPage({ viewport: { width: 1365, height: 1000 } });
    const token = 'fixture.' + Buffer.from(JSON.stringify({ tenantId: 77, exp: Math.floor(Date.now() / 1000) + 3600 })).toString('base64url') + '.signature';
    await page.addInitScript(value => localStorage.setItem('token', value), token);
    const state = { saldo: 0, simulacao: true, cobrancaId: '', token: '', direitos: '[]', contratacoes: [], movimentos: [], cobrancas: [], ofertas: [
        { codigo: 'clinica-periodo', titulo: 'Clinica por periodo', aplicativo: 'Clinica', recurso: 'clinica.access', modelo: 'period', precoCreditos: 100, meses: 1, unidades: 0 },
        { codigo: 'transcricao-creditos', titulo: 'Pacote de 10 transcricoes', aplicativo: 'Clinica', recurso: 'clinica.transcription', modelo: 'credits', precoCreditos: 20, meses: 0, unidades: 10 }
    ] };
    const errors = [], requests = []; let failPurchaseResponse = true, purchaseId = '';
    page.on('pageerror', error => errors.push(error.message));
    await page.route('**/yapi/Central/Financeiro*', async route => {
        const endpoint = route.request().url(), input = route.request().postDataJSON(); requests.push({ endpoint, input });
        if (endpoint.includes('CriarRecarga')) state.cobrancas = [{ id: 'fixture-charge', creditos: input.creditos, valor: input.creditos, status: 0 }];
        if (endpoint.includes('ConfirmarPagamento')) { state.saldo = 500; state.cobrancas[0].status = 1; }
        if (endpoint.includes('ContratarUso')) {
            if (!purchaseId) {
                purchaseId = input.requestId; state.saldo -= 100;
                state.contratacoes = [{ recurso: 'clinica.access', validoAteUtc: new Date(Date.now() + 86400000).toISOString(), unidadesContratadas: 0 }];
            } else assert.equal(input.requestId, purchaseId, 'Retry must preserve the financial request identity');
            if (failPurchaseResponse) { failPurchaseResponse = false; return route.abort('failed'); }
            state.token = token;
        }
        return route.fulfill({ json: state });
    });
    await page.goto(`http://127.0.0.1:${server.address().port}/fixture`);
    await page.waitForFunction(() => window.fixtureReady);
    await page.locator('#financeiro-creditos').selectOption('500');
    await page.getByRole('button', { name: 'Gerar cobranca de teste' }).count();
    await page.locator('#financeiro-recarga button').click();
    await page.getByRole('button', { name: 'Confirmar simulacao' }).click();
    await page.waitForFunction(() => document.getElementById('financeiro-saldo').textContent === '500');
    await page.locator('#financeiro-contratar button').click();
    await page.waitForFunction(() => document.getElementById('financeiro-status').dataset.error === 'true');
    await page.locator('#financeiro-contratar button').click();
    await page.waitForFunction(() => document.getElementById('financeiro-saldo').textContent === '400');
    assert.equal(requests.filter(request => request.endpoint.includes('ContratarUso')).length, 2);
    assert.equal(await page.locator('#financeiro-clinica').isVisible(), true);
    await page.screenshot({ path: path.join(artifact, 'financeiro-desktop.png'), fullPage: true });
    await page.setViewportSize({ width: 390, height: 844 });
    assert(await page.evaluate(() => document.documentElement.scrollWidth <= innerWidth), 'Mobile must not overflow');
    await page.screenshot({ path: path.join(artifact, 'financeiro-mobile.png'), fullPage: true });
    assert.deepEqual(errors, []);
    console.log(JSON.stringify({ passed: true, requests: requests.length, idempotentRetry: true, desktop: true, mobile: true }));
})().catch(error => { console.error(error); process.exitCode = 1; }).finally(async () => { await browser?.close(); server?.close(); });
