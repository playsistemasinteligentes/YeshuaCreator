const assert = require('node:assert/strict');
const fs = require('node:fs');
const http = require('node:http');
const path = require('node:path');
const { chromium } = require('playwright');

const front = path.resolve(__dirname, '../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const a = { conexaoId: '11111111111111111111111111111111', canalId: 'channel-a', canalTitulo: 'Canal pessoal', conectado: true };
const b = { conexaoId: '22222222222222222222222222222222', canalId: 'channel-b', canalTitulo: 'Canal da empresa com nome longo para validar a tela no celular', conectado: true };
const fixture = `<!doctype html><html lang="pt-BR"><meta name="viewport" content="width=device-width,initial-scale=1">
<script src="https://cdn.tailwindcss.com"></script><link rel="stylesheet" href="/spa/styles/yeshua-ui.css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css">
<style>body{font:16px Arial,sans-serif;padding:16px;margin:0}main{max-width:960px;margin:auto}</style>
<main><h1>Album</h1><div id="form-group"></div></main>
<script>const environments={urlApi:'/apps/memorias/yapi'};localStorage.setItem('token','test-token');
localStorage.setItem('tokenExp',String(Date.now()+3600000));localStorage.setItem('yeshua.activeApplication','Memorias');
window.payload={metadata:{entityName:'Album'},crudState:{currentRecord:{id:5}},
formGroup:document.getElementById('form-group'),openCrudEntity:(entity,filters)=>window.opened={entity,filters}};</script>
<script src="/Custon/Apps/Memorias/extensions.js"></script><script>yeshuaExtensions.crud.afterFillForm(payload)</script></html>`;

async function main() {
    const server = http.createServer((req, res) => {
        const url = req.url.split('?')[0];
        const files = {
            '/Custon/Apps/Memorias/extensions.js': 'text/javascript',
            '/Custon/Apps/Memorias/youtube-callback.js': 'text/javascript',
            '/Custon/Apps/Memorias/youtube-callback.css': 'text/css',
            '/spa/styles/yeshua-ui.css': 'text/css',
            '/spa/youtube-callback.html': 'text/html'
        };
        res.setHeader('Content-Type', files[url] || 'text/html');
        res.end(files[url] ? fs.readFileSync(path.join(front, url)) : fixture);
    });
    await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
    const base = `http://127.0.0.1:${server.address().port}`;
    let browser;
    try {
        browser = await chromium.launch({ channel: 'msedge', headless: true });
        for (const viewport of [{ width: 1366, height: 900 }, { width: 375, height: 812 }]) {
            const page = await browser.newPage({ viewport });
            const calls = [];
            const errors = [];
            page.on('pageerror', error => errors.push(error.message));
            page.on('dialog', dialog => dialog.accept());
            await page.route('**/apps/memorias/yapi/**', async route => {
                const request = route.request();
                assert.equal(request.headers().authorization, 'Bearer test-token');
                calls.push({ url: request.url(), body: request.postDataJSON() });
                if (request.url().includes('ListarConexoes')) return route.fulfill({ json: { configurado: true, conexoes: [a, b] } });
                if (request.url().includes('Desconectar')) return route.fulfill({ json: { ...b, conectado: false, mensagem: 'Canal desconectado.' } });
                if (request.url().includes('SolicitarPublicacao')) return route.fulfill({ json: { publicacaoAlbumId: 3 } });
                if (request.url().includes('ConcluirConexao')) return route.fulfill({ json: { ...a, configurado: true } });
                if (request.url().includes('Retomar')) return route.fulfill({ json: { agendada: true } });
                return route.fulfill({ status: 400, json: { message: 'YouTube ainda nao configurado no servidor.' } });
            });
            await page.goto(base);
            assert.equal(calls.length, 0, 'Nenhuma consulta passiva na abertura.');
            assert.equal(await page.getByRole('button', { name: 'Publicar album', exact: true }).isDisabled(), true);
            await page.getByRole('button', { name: 'Consultar conexoes' }).click();
            const destination = page.getByLabel('Canal YouTube de destino');
            await page.waitForFunction(() => document.querySelector('select[aria-label="Canal YouTube de destino"]').options.length === 3);
            await destination.selectOption(a.conexaoId);
            await page.getByRole('button', { name: 'Publicar album', exact: true }).click();
            await page.waitForFunction(() => Boolean(window.opened));
            assert.deepEqual(calls.at(-1).body, { albumId: 5, conexaoYouTubeId: a.conexaoId });
            assert.deepEqual(await page.evaluate(() => window.opened), { entity: 'PublicacaoAlbum', filters: { id: 3 } });
            await destination.selectOption(b.conexaoId);
            await page.getByRole('button', { name: 'Desconectar', exact: true }).click();
            await page.getByRole('status').filter({ hasText: 'Canal desconectado.' }).waitFor();
            assert.equal(calls.at(-1).body.conexaoId, b.conexaoId);
            assert.equal(await page.getByRole('button', { name: 'Publicar album', exact: true }).isDisabled(), true);
            await page.getByRole('button', { name: 'Conectar YouTube' }).click();
            await page.getByRole('status').filter({ hasText: 'YouTube ainda nao configurado no servidor.' }).waitFor();
            const count = calls.length;
            await page.waitForTimeout(1200);
            assert.equal(calls.length, count, 'Sem polling automatico.');
            assert.equal(await page.evaluate(() => document.documentElement.scrollWidth > innerWidth), false);
            fs.mkdirSync(path.join(__dirname, 'artifacts'), { recursive: true });
            await page.screenshot({ path: path.join(__dirname, `artifacts/youtube-${viewport.width}.png`), fullPage: true });

            await page.evaluate(id => {
                payload.metadata.entityName = 'PublicacaoAlbum';
                payload.crudState.currentRecord = { id: 3, status: 45, conexaoyoutubeid: id, canalyoutubeid: 'channel-a' };
                yeshuaExtensions.crud.afterFillForm(payload);
            }, a.conexaoId);
            await page.getByRole('button', { name: 'Consultar conexoes' }).click();
            await page.waitForFunction(id => document.querySelector('select[aria-label="Canal YouTube de destino"]').value === id, a.conexaoId);
            assert.equal(await destination.isDisabled(), true, 'Publicacao tem destino fixo.');
            await page.getByRole('button', { name: 'Retomar envio' }).click();
            await page.getByRole('status').filter({ hasText: 'Envio ao YouTube agendado.' }).waitFor();
            assert.deepEqual(calls.at(-1).body, { publicacaoAlbumId: 3, conexaoYouTubeId: a.conexaoId });

            await page.goto(`${base}/spa/youtube-callback.html?code=test-code&state=test-state`);
            await page.getByRole('status').filter({ hasText: 'Canal conectado: Canal pessoal' }).waitFor();
            assert.equal(new URL(page.url()).search, '', 'Codigo removido da barra de enderecos.');
            assert.deepEqual(calls.at(-1).body, { authorizationCode: 'test-code', tokenState: 'test-state' });
            const completed = calls.length;
            await page.goto(`${base}/spa/youtube-callback.html?error=access_denied`);
            await page.getByRole('status').filter({ hasText: 'Autorizacao nao concluida no Google.' }).waitFor();
            assert.equal(calls.length, completed);
            await page.evaluate(() => localStorage.setItem('tokenExp', '1'));
            await page.goto(`${base}/spa/youtube-callback.html?code=expired-code&state=expired-state`);
            await page.getByRole('status').filter({ hasText: 'Entre novamente no Memorias' }).waitFor();
            assert.equal(new URL(page.url()).search, '');
            assert.equal(calls.length, completed, 'Sessao expirada nao envia codigo OAuth.');
            await page.goto(`${base}/spa/youtube-callback.html?code=incomplete`);
            await page.getByRole('status').filter({ hasText: 'Retorno de autorizacao incompleto.' }).waitFor();
            assert.equal(calls.length, completed);
            assert.deepEqual(errors, []);
            await page.close();
            console.log(`YouTube UI passed: ${viewport.width}x${viewport.height}`);
        }
    } finally {
        await browser?.close();
        await new Promise(resolve => server.close(resolve));
    }
}

main().catch(error => { console.error(error); process.exitCode = 1; });
