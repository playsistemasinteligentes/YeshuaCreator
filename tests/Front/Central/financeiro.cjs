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
            // Match the SPA body margin reset supplied by Tailwind, without a CDN dependency.
            response.end('<!doctype html><html><head><style>body{margin:0}</style><meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="/spa/styles/yeshua-ui.css"><link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css"></head><body><main id="app"></main><script>window.environments={authenticationApi:"/yapi",urlApi:"/yapi"};</script><script type="module">import {renderFinanceiro} from "/Custon/Apps/Central/pages/financeiro.js"; await renderFinanceiro(); window.fixtureReady=true;</script></body></html>'); return;
        }
        const file = path.resolve(root, '.' + pathname);
        if (!file.startsWith(root + path.sep) || !fs.existsSync(file) || !fs.statSync(file).isFile()) return response.writeHead(404).end();
        response.setHeader('Content-Type', file.endsWith('.js') ? 'text/javascript' : file.endsWith('.css') ? 'text/css' : 'text/html');
        response.end(fs.readFileSync(file));
    });
    await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
    browser = await chromium.launch({ channel: process.env.PLAYWRIGHT_CHANNEL || 'msedge', headless: true });
    const page = await browser.newPage({ viewport: { width: 1365, height: 1000 } });
    const token = 'fixture.' + Buffer.from(JSON.stringify({ tenantId: 77, exp: Math.floor(Date.now() / 1000) + 3600 })).toString('base64url') + '.signature';
    await page.addInitScript(value => localStorage.setItem('token', value), token);
    const state = { saldo: 0, simulacao: true, cobrancaId: '', token: '', direitos: '[]', contratacoes: [], movimentos: [], cobrancas: [], ofertas: [
        { codigo: 'clinica-periodo', titulo: 'Clinica por periodo', aplicativo: 'Clinica', recurso: 'clinica.access', modelo: 'period', precoCreditos: 100, meses: 1, unidades: 0 },
        { codigo: 'transcricao-creditos', titulo: 'Pacote de 10 transcricoes', aplicativo: 'Clinica', recurso: 'clinica.transcription', modelo: 'credits', precoCreditos: 20, meses: 0, unidades: 10 }
    ] };
    const errors = [], requests = []; let failAllocationResponse = true, failAdditionResponse = true;
    const additions = new Set(), allocations = new Set();
    page.on('pageerror', error => errors.push(error.message));
    await page.route('**/yapi/Central/Financeiro*', async route => {
        const endpoint = route.request().url(), input = route.request().postDataJSON(); requests.push({ endpoint, input });
        if (endpoint.includes('AdicionarCreditosCarteira')) {
            if (!additions.has(input.requestId)) {
                additions.add(input.requestId); const before = state.saldo; state.saldo += input.creditos;
                state.movimentos.unshift({ tipo: 'AdicaoCarteira', servico: 'carteira', descricao: 'Adição à carteira', quantidade: input.creditos,
                    saldoAnterior: before, saldoApos: state.saldo, criadoEmUtc: new Date().toISOString() });
            }
            if (failAdditionResponse) { failAdditionResponse = false; return route.abort('failed'); }
        }
        if (endpoint.includes('AlocarCreditosCarteira')) {
            if (!allocations.has(input.requestId)) {
                allocations.add(input.requestId); const before = state.saldo;
                const clinic = input.oferta === 'clinica-periodo', cost = clinic ? 100 : 20;
                state.saldo -= cost;
                state.contratacoes.push({ recurso: clinic ? 'clinica.access' : 'clinica.transcription',
                    validoAteUtc: clinic ? new Date(Date.now() + 86400000).toISOString() : '', unidadesContratadas: clinic ? 0 : 10 });
                state.movimentos.unshift({ tipo: 'AlocacaoCarteira', servico: clinic ? 'clinica.access' : 'clinica.transcription',
                    descricao: clinic ? 'Clínica — 1 mês(es)' : 'Transcrição de áudio — 10 transcrições', quantidade: -cost,
                    saldoAnterior: before, saldoApos: state.saldo, criadoEmUtc: new Date().toISOString() });
            }
            if (failAllocationResponse) { failAllocationResponse = false; return route.abort('failed'); }
            state.token = token;
        }
        return route.fulfill({ json: state });
    });
    await page.goto(`http://127.0.0.1:${server.address().port}/fixture`);
    await page.waitForFunction(() => window.fixtureReady);
    assert.equal(await page.locator('#financeiro-movimentos').textContent(), 'Nenhum registro.');
    await page.locator('#financeiro-creditos').selectOption('500');
    await page.getByRole('heading', { name: 'Carteira de créditos', exact: true }).waitFor();
    const addition = page.getByRole('button', { name: 'Adicionar créditos à carteira', exact: true });
    const allocation = page.getByRole('button', { name: 'Alocar créditos da carteira', exact: true });
    assert.equal(await page.getByRole('button', { name: /cobrança|Confirmar simula/i }).count(), 0);
    const firstForm = await page.locator('#financeiro-recarga').boundingBox(), secondForm = await page.locator('#financeiro-contratar').boundingBox();
    assert(secondForm.y >= firstForm.y + firstForm.height, 'Add to wallet and allocate are separate vertical steps on desktop');
    await addition.click();
    await page.waitForFunction(() => document.getElementById('financeiro-status').dataset.error === 'true');
    await addition.click();
    await page.waitForFunction(() => document.getElementById('financeiro-saldo').textContent === '500');
    assert.equal(additions.size, 1, 'Lost addition response must not duplicate wallet credits');
    await allocation.click();
    await page.waitForFunction(() => document.getElementById('financeiro-status').dataset.error === 'true');
    await allocation.click();
    await page.waitForFunction(() => document.getElementById('financeiro-saldo').textContent === '400');
    assert.equal(allocations.size, 1, 'Lost allocation response must not duplicate consumption');
    assert.equal(requests.filter(request => request.endpoint.includes('AlocarCreditosCarteira')).length, 2);
    const additionRequests = requests.filter(request => request.endpoint.includes('AdicionarCreditosCarteira'));
    assert.equal(additionRequests.length, 2); assert.equal(additionRequests[0].input.requestId, additionRequests[1].input.requestId);
    const allocationRequests = requests.filter(request => request.endpoint.includes('AlocarCreditosCarteira'));
    assert.equal(allocationRequests[0].input.requestId, allocationRequests[1].input.requestId);
    assert.deepEqual(await page.locator('#financeiro-movimentos tbody tr').first().locator('td').allTextContents(),
        [await page.locator('#financeiro-movimentos tbody tr').first().locator('td').first().textContent(), 'Alocação — Clínica — 1 mês(es)', '-100', '400']);
    assert.deepEqual(await page.locator('#financeiro-movimentos th').allTextContents(), ['Data', 'Serviço / movimentação', 'Movimentação', 'Saldo']);
    assert.equal(await page.locator('#financeiro-movimentos tbody tr').last().locator('td').nth(2).textContent(), '+500');
    assert.equal(await page.getByLabel('Crédito: 500 créditos', { exact: true }).count(), 1);
    assert.equal(await page.getByLabel('Débito: 100 créditos', { exact: true }).count(), 1);
    assert(await page.locator('#financeiro-direitos').getByText('Por período', { exact: true }).isVisible());
    await page.locator('#financeiro-oferta').selectOption('transcricao-creditos'); await allocation.click();
    await page.waitForFunction(() => document.getElementById('financeiro-saldo').textContent === '380');
    await page.locator('#financeiro-filtro-servico').selectOption('clinica.access');
    assert.equal(await page.locator('#financeiro-movimentos tbody tr').count(), 1);
    assert.match(await page.locator('#financeiro-movimentos').textContent(), /Clínica/);
    await page.locator('#financeiro-filtro-servico').selectOption('clinica.transcription');
    assert.match(await page.locator('#financeiro-movimentos').textContent(), /10 transcrições/);
    await page.locator('#financeiro-filtro-servico').selectOption('');
    assert.deepEqual(await page.locator('#financeiro-movimentos tbody tr td:nth-child(3)').allTextContents(), ['-20', '-100', '+500'], 'Statement keeps the API order');
    await page.locator('#financeiro-filtro-servico').selectOption('carteira');
    await page.getByRole('button', { name: 'Atualizar', exact: true }).click();
    await page.waitForFunction(() => document.getElementById('financeiro-status').textContent === 'Acesso e saldo atualizados.');
    assert.equal(await page.locator('#financeiro-filtro-servico').inputValue(), 'carteira', 'Refresh preserves the filter');
    assert.deepEqual(await page.locator('#financeiro-movimentos tbody tr td:nth-child(3)').allTextContents(), ['+500']);
    // Legacy entries can lack saldoAnterior, servico and descricao. Display the returned balance as-is.
    state.movimentos.push(
        { quantidade: '1234567890.1234', saldoApos: '1234567890.1234', criadoEmUtc: '2026-11-01T12:00:00Z' },
        { quantidade: '-0.1234', saldoApos: '1234567890', criadoEmUtc: '2026-10-31T12:00:00Z' },
        { quantidade: 0, saldoApos: 0, criadoEmUtc: null, descricao: '<script>historico</script>' }
    );
    await page.locator('#financeiro-filtro-servico').selectOption('');
    await page.getByRole('button', { name: 'Atualizar', exact: true }).click();
    await page.waitForFunction(() => document.querySelectorAll('#financeiro-movimentos tbody tr').length === 6);
    assert.deepEqual(await page.locator('#financeiro-movimentos tbody tr td:nth-child(3)').allTextContents(), ['-20', '-100', '+500', '+1.234.567.890,1234', '-0,1234', '0']);
    assert.deepEqual(await page.locator('#financeiro-movimentos tbody tr td:nth-child(4)').allTextContents(), ['380', '400', '500', '1.234.567.890,1234', '1.234.567.890', '0']);
    assert.equal(await page.locator('#financeiro-movimentos tbody tr').nth(3).locator('td').nth(1).textContent(), 'Adição à carteira');
    assert.equal(await page.locator('#financeiro-movimentos tbody tr').nth(4).locator('td').nth(1).textContent(), 'Alocação — Alocação de créditos');
    assert.equal(await page.locator('#financeiro-movimentos tbody tr').last().locator('td').first().textContent(), '-');
    assert.equal(await page.locator('#financeiro-movimentos script').count(), 0, 'Descriptions remain plain text');
    const contrast = await page.locator('#financeiro-movimentos .financeiro-movimento').evaluateAll(elements => {
        const rgb = color => color.match(/[\d.]+/g).slice(0, 3).map(Number);
        const luminance = channels => channels.map(value => { const s = value / 255; return s <= 0.04045 ? s / 12.92 : ((s + 0.055) / 1.055) ** 2.4; }).reduce((sum, value, index) => sum + value * [0.2126, 0.7152, 0.0722][index], 0);
        return elements.map(element => {
            let background = 'rgb(255, 255, 255)';
            for (let parent = element; parent; parent = parent.parentElement) {
                const color = getComputedStyle(parent).backgroundColor;
                if (color !== 'rgba(0, 0, 0, 0)' && color !== 'transparent') { background = color; break; }
            }
            const foregroundLuminance = luminance(rgb(getComputedStyle(element).color)), backgroundLuminance = luminance(rgb(background));
            return (Math.max(foregroundLuminance, backgroundLuminance) + 0.05) / (Math.min(foregroundLuminance, backgroundLuminance) + 0.05);
        });
    });
    assert(contrast.every(ratio => ratio >= 4.5), `Movement text meets WCAG AA contrast: ${contrast}`);
    assert.equal(await page.locator('#financeiro-clinica').isVisible(), true);
    await page.screenshot({ path: path.join(artifact, 'financeiro-desktop.png'), fullPage: true });
    for (const width of [768, 680, 390, 320]) {
        await page.setViewportSize({ width, height: 844 });
        assert(await page.evaluate(() => document.documentElement.scrollWidth <= innerWidth), `No page overflow at ${width}px`);
        assert(await page.locator('#financeiro-movimentos .financeiro-table-wrap').evaluate(element => element.scrollWidth <= element.clientWidth), `No statement scrolling at ${width}px`);
        for (const cell of await page.locator('#financeiro-movimentos tbody td:nth-child(n+3)').all()) {
            const box = await cell.boundingBox();
            assert(box.x >= 0 && box.x + box.width <= width, `Full movement and balance visible at ${width}px`);
        }
        if (width <= 680) {
            assert.equal(await page.locator('#financeiro-movimentos tbody td').nth(2).evaluate(element => getComputedStyle(element, '::before').content), '"Movimentação"');
            assert.equal(await page.locator('#financeiro-movimentos tbody td').nth(3).evaluate(element => getComputedStyle(element, '::before').content), '"Saldo"');
        }
    }
    await page.screenshot({ path: path.join(artifact, 'financeiro-mobile.png'), fullPage: true });
    assert.deepEqual(errors, []);
    assert(requests.every(request => !/CriarRecarga|ConfirmarPagamento|ContratarUso/.test(request.endpoint)), 'Active UI calls the wallet operations');
    console.log(JSON.stringify({ passed: true, requests: requests.length, additionRetry: true, allocationRetry: true, serviceStatement: true, desktop: true, mobile: true }));
})().catch(error => { console.error(error); process.exitCode = 1; }).finally(async () => { await browser?.close(); server?.close(); });
