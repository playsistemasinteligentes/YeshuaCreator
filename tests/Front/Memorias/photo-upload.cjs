const assert = require('node:assert/strict');
const fs = require('node:fs');
const http = require('node:http');
const path = require('node:path');
const { chromium } = require('playwright');

const front = path.resolve(__dirname, '../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const png = Buffer.from('iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+aDaYAAAAASUVORK5CYII=', 'base64');
const fixture = `<!doctype html><html lang="pt-BR"><head><meta name="viewport" content="width=device-width,initial-scale=1">
<script src="https://cdn.tailwindcss.com"></script><link rel="stylesheet" href="/styles.css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css">
<style>body{font-family:Arial,sans-serif;margin:0;padding:16px}main{max-width:960px;margin:auto}</style></head>
<body><main><h1>Album</h1><div id="form-group"></div></main>
<script>const environments={urlApi:'/apps/memorias/yapi'};localStorage.setItem('token','test-token');
window.crudState={currentRecord:null};window.payload={metadata:{entityName:'Album'},crudState,
formGroup:document.getElementById('form-group'),openCrudEntity:(entity,filters)=>window.opened={entity,filters}};</script>
<script src="/extensions.js"></script><script>yeshuaExtensions.crud.afterRenderForm(payload)</script></body></html>`;

async function main() {
    const server = http.createServer((req, res) => {
        const files = {
            '/extensions.js': [path.join(front, 'Custon/Apps/Memorias/extensions.js'), 'text/javascript'],
            '/styles.css': [path.join(front, 'spa/styles/yeshua-ui.css'), 'text/css']
        };
        if (files[req.url]) {
            res.setHeader('Content-Type', files[req.url][1]);
            res.end(fs.readFileSync(files[req.url][0]));
        } else {
            res.setHeader('Content-Type', 'text/html');
            res.end(fixture);
        }
    });
    await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
    let browser;
    try {
        browser = await chromium.launch({ channel: 'msedge', headless: true });
        for (const viewport of [{ width: 1366, height: 900 }, { width: 375, height: 812 }]) {
            const page = await browser.newPage({ viewport });
            const calls = [];
            const errors = [];
            let sessions = 0;
            let sends = 0;
            let failSecond = true;
            page.on('pageerror', error => errors.push(error.message));
            await page.route('**/apps/memorias/yapi/**', async route => {
                const request = route.request();
                assert.equal(request.headers().authorization, 'Bearer test-token');
                calls.push({ url: request.url(), body: request.postData() });
                if (request.url().endsWith('InfraStarSessionUploadUseCase')) {
                    assert.deepEqual(request.postDataJSON(), { entityType: 'Album', entityId: '5' });
                    await route.fulfill({ json: { uploadToken: `session-${++sessions}` } });
                } else {
                    assert.match(request.headers()['content-type'], /^multipart\/form-data; boundary=/);
                    assert.match(request.postData(), /name="FileStream"; filename=/);
                    ++sends;
                    if (sends === 2 && failSecond) {
                        await route.fulfill({ status: 400, json: { message: 'Falha de teste.' } });
                    } else {
                        await route.fulfill({ json: { success: true, chunkIndex: 0, isFinalized: true } });
                    }
                }
            });
            await page.goto(`http://127.0.0.1:${server.address().port}/`);
            const send = page.getByRole('button', { name: 'Adicionar fotos' });
            assert.equal(await send.isDisabled(), true);
            assert.equal(await page.getByLabel('Selecionar fotos').isDisabled(), true);
            await page.evaluate(() => {
                crudState.currentRecord = { id: 5 };
                yeshuaExtensions.crud.afterFillForm(payload);
            });
            await page.getByLabel('Selecionar fotos').setInputFiles([
                { name: 'foto-001.png', mimeType: 'image/png', buffer: png },
                { name: 'uma-foto-com-nome-muito-longo-para-conferir-o-layout-em-celulares.png', mimeType: 'image/png', buffer: png }
            ]);
            await page.waitForFunction(() => [...document.querySelectorAll('figure img')].every(image => image.complete && image.naturalWidth > 0));
            assert.equal(await send.isEnabled(), true);
            await send.click();
            await page.getByRole('status').filter({ hasText: 'Falha de teste.' }).waitFor();
            assert.equal(sessions, 2);
            failSecond = false;
            await send.click();
            await page.getByRole('status').filter({ hasText: '2 foto(s) adicionada(s) ao album.' }).waitFor();
            assert.equal(sessions, 2);
            assert.equal(sends, 3);
            assert.equal(await send.isDisabled(), true);
            const count = calls.length;
            await page.waitForTimeout(1500);
            assert.equal(calls.length, count, 'A tela nao deve gerar polling automatico.');
            assert.deepEqual(errors, []);
            const overflow = await page.evaluate(() => document.documentElement.scrollWidth > innerWidth);
            assert.equal(overflow, false, 'Conteudo excedeu a largura da tela.');
            fs.mkdirSync(path.join(__dirname, 'artifacts'), { recursive: true });
            await page.screenshot({ path: path.join(__dirname, `artifacts/upload-${viewport.width}.png`), fullPage: true });
            await page.getByRole('button', { name: 'Consultar fotos' }).click();
            assert.deepEqual(await page.evaluate(() => window.opened), { entity: 'AlbumFoto', filters: { albumid: 5 } });
            await page.close();
            console.log(`Upload UI passed: ${viewport.width}x${viewport.height}`);
        }
    } finally {
        await browser?.close();
        await new Promise(resolve => server.close(resolve));
    }
}

main().catch(error => { console.error(error); process.exitCode = 1; });
