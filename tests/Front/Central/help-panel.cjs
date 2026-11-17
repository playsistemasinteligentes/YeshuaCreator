const assert = require('node:assert/strict');
const fs = require('node:fs');
const http = require('node:http');
const path = require('node:path');
const { chromium } = require('playwright');
const root = path.resolve(__dirname, '../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const artifact = path.resolve(__dirname, '../../../artifacts/help-support');
const shell = fs.readFileSync(path.join(root, 'spa/views/dashboard.html'), 'utf8');
const jwt = tenant => 'header.' + Buffer.from(JSON.stringify({ tenantId: tenant, nameid: '7' })).toString('base64url') + '.signature';
let server, browser;
(async () => {
    server = http.createServer((req, res) => {
        const pathname = new URL(req.url, 'http://localhost').pathname;
        if (pathname === '/help-test') {
            res.setHeader('Content-Type', 'text/html; charset=utf-8');
            res.end(`<!doctype html><html><head><meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="/spa/styles/yeshua-ui.css"><link rel="stylesheet" href="/spa/styles/help-panel.css"><style>body{margin:0}.hidden{display:none!important}</style><script>window.environments={authenticationApi:'/yapi'};</script></head><body>${shell}<section id="custom-page-container" data-help-screen="memorias-estudio" data-help-title="Estúdio Memórias"><div>Texto de trabalho preservado</div></section><script type="module">import {bindUserArea} from '/spa/scripts/user-area.js'; bindUserArea(); window.testReady=true;</script></body></html>`); return;
        }
        const file = path.resolve(root, '.' + pathname);
        if (!file.startsWith(root + path.sep) || !fs.existsSync(file) || !fs.statSync(file).isFile()) { res.writeHead(404).end(); return; }
        res.setHeader('Content-Type', file.endsWith('.js') ? 'text/javascript; charset=utf-8' : file.endsWith('.css') ? 'text/css; charset=utf-8' : 'text/html; charset=utf-8');
        res.end(fs.readFileSync(file));
    });
    await new Promise(r => server.listen(0, '127.0.0.1', r));
    browser = await chromium.launch({ channel: 'msedge', headless: true });
    const context = await browser.newContext({ viewport: { width: 1440, height: 1000 } });
    await context.addInitScript(token => {
        localStorage.setItem('token', token);
        window.yeshuaActiveApplication = { application: 'Memorias', title: 'Memórias' };
        window.yeshuaHelpModule = { application: 'Memorias', name: 'Álbuns' };
        window.copies = [];
        Object.defineProperty(navigator, 'clipboard', { configurable: true, value: { writeText: async t => window.copies.push(t) } });
        Object.defineProperty(navigator, 'mediaDevices', { configurable: true, value: { getUserMedia: async () => ({ getTracks: () => [{ stop() {} }] }) } });
        window.MediaRecorder = class {
            static isTypeSupported() { return true; }
            constructor() { this.state = 'inactive'; }
            start() { this.state = 'recording'; }
            stop() { this.state = 'inactive'; queueMicrotask(() => { this.ondataavailable({ data: new Blob(['test-audio'], { type: 'audio/webm' }) }); this.onstop(); }); }
        };
    }, jwt(2));
    const page = await context.newPage(), errors = [], requests = [], tickets = new Map();
    let opened = 0, upload = 0, reads = 0, failSubmit = false, transcriptionFailure = false;
    page.on('pageerror', error => errors.push(error.message));
    await page.route('**/yapi/**', async route => {
        const req = route.request(), endpoint = new URL(req.url()).pathname;
        requests.push(endpoint);
        const reply = data => route.fulfill({ json: data });
        if (endpoint === '/yapi/version') return reply({ version: '1.0.3+fixture-commit' });
        if (endpoint.includes('PrepararChamado')) {
            const body = req.postDataJSON(); tickets.set(body.chamadoId, body);
            return reply({ chamadoId: body.chamadoId, aberto: false });
        }
        if (endpoint.includes('AbrirChamado')) {
            if (failSubmit) { failSubmit = false; return route.abort('failed'); }
            const body = req.postDataJSON(); opened++; tickets.set(body.chamadoId, { ...tickets.get(body.chamadoId), ...body });
            return reply({ chamadoId: body.chamadoId, aberto: true });
        }
        if (endpoint.includes('StarSessionUpload')) return reply({ uploadToken: 'fixture-upload-token' });
        if (endpoint.includes('SendFileUseCase2')) { upload++; assert(req.postData().includes('test-audio')); return reply({ success: true, isFinalized: true, sagaId: 71 }); }
        if (endpoint.includes('ConsultarChamado')) {
            reads++; const id = req.postDataJSON().chamadoId;
            return reply({ chamadoId: id, aberto: false, transcricaoStatus: transcriptionFailure ? 'failed' : reads === 1 ? 'pending' : 'completed',
                transcricao: 'Relato falado convertido em texto.', erroTranscricao: 'Falha de transcrição. Você pode digitar.', sagaId: 71 });
        }
        throw new Error('Unexpected API: ' + endpoint);
    });
    await page.goto(`http://127.0.0.1:${server.address().port}/help-test?secret=PRIVATE#dashboard`);
    await page.waitForFunction(() => window.testReady);
    assert.equal(await page.locator('#release-footer').count(), 0);
    await page.getByRole('button', { name: 'Abrir ajuda', exact: true }).click();
    await page.getByRole('tab', { name: 'Sobre', exact: true }).click();
    await assert.doesNotReject(() => page.getByText('Versão 1.0.3', { exact: true }).waitFor());
    await page.getByRole('tab', { name: 'Ajuda com IA', exact: true }).click();
    await page.getByRole('button', { name: 'Copiar prompt', exact: true }).click();
    const prompt = await page.evaluate(() => window.copies[0]);
    assert(prompt.includes('Memorias')); assert(prompt.includes('Módulo: Álbuns')); assert(!prompt.includes('PRIVATE'));
    assert.equal(requests.filter(x => x !== '/yapi/version').length, 0, 'Opening help/copy must not create a ticket');
    await page.getByRole('tab', { name: 'Chamado', exact: true }).click();
    await page.locator('#support-subject').fill('Dúvida sobre o álbum');
    await page.locator('#support-description').fill('Texto digitado.');
    await page.getByRole('button', { name: 'Gravar relato', exact: true }).click();
    await page.getByRole('button', { name: 'Parar gravação', exact: true }).waitFor();
    await page.getByRole('button', { name: 'Fechar ajuda', exact: true }).click();
    assert(await page.locator('dialog').evaluate(x => x.open), 'Do not lose an active recording');
    await page.getByRole('button', { name: 'Parar gravação', exact: true }).click();
    await page.waitForFunction(() => document.getElementById('support-description').value.includes('Relato falado'));
    assert.equal(upload, 1); assert.equal(opened, 0, 'Transcription must not submit a ticket');
    assert.equal(await page.locator('#support-description').inputValue(), 'Texto digitado.\n\nRelato falado convertido em texto.');
    await page.locator('#support-description').fill('Texto revisto pelo usuário.');
    failSubmit = true;
    await page.getByRole('button', { name: 'Enviar chamado', exact: true }).click();
    await page.getByText('Não foi possível concluir.', { exact: false }).waitFor();
    assert.equal(await page.locator('#support-description').inputValue(), 'Texto revisto pelo usuário.');
    await page.getByRole('button', { name: 'Enviar chamado', exact: true }).click();
    await page.getByText(/Chamado .* aberto\./).waitFor();
    assert.equal(opened, 1); assert.equal(tickets.size, 1);
    const ticket = [...tickets.values()][0];
    assert.equal(ticket.aplicativo, 'Memorias'); assert.equal(ticket.modulo, 'Álbuns'); assert.equal(ticket.tela, 'memorias-estudio');
    assert.equal(ticket.descricao, 'Texto revisto pelo usuário.'); assert(!JSON.stringify(ticket).includes('PRIVATE'));
    for (const width of [1440, 390, 320]) {
        await page.setViewportSize({ width, height: 844 });
        await page.screenshot({ path: path.join(artifact, `help-${width}.png`) });
        assert(await page.locator('dialog').evaluate(x => x.scrollWidth <= x.clientWidth + 1), `overflow at ${width}`);
    }
    await page.setViewportSize({ width: 1440, height: 1000 });
    await page.getByRole('button', { name: 'Novo chamado', exact: true }).click();
    transcriptionFailure = true;
    await page.getByRole('button', { name: 'Gravar relato', exact: true }).click();
    await page.getByRole('button', { name: 'Parar gravação', exact: true }).click();
    await page.getByText('Falha de transcrição. Você pode digitar.', { exact: true }).waitFor();
    assert.equal(await page.locator('#support-description').getAttribute('readonly'), null);
    await page.getByRole('button', { name: 'Fechar ajuda', exact: true }).click();
    await page.getByRole('button', { name: 'Abrir ajuda', exact: true }).click();
    assert.equal(requests.filter(x => x === '/yapi/version').length, 1);
    await page.keyboard.press('Escape');
    assert.deepEqual(errors, []);
    console.log(JSON.stringify({ passed: true, textTicket: true, audioToReviewedText: true, preservesRetry: true,
        noAutomaticSubmit: true, versionInHelpOnly: true, widths: [1440, 390, 320], jsErrors: 0 }));
})().catch(error => { console.error(error.stack); process.exitCode = 1; })
    .finally(async () => { await browser?.close(); if (server) { server.closeAllConnections(); await new Promise(r => server.close(r)); } });
