const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const http = require('node:http');
const { chromium } = require('playwright');

const root = path.resolve(__dirname, '../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const artifacts = path.resolve(__dirname, '../../../artifacts/financeiro');
const message = 'Você não possui um período de uso ativo para este aplicativo. Acesse a Central para contratar ou renovar o acesso.';
const token = 'test.' + Buffer.from(JSON.stringify({ exp: Math.floor(Date.now() / 1000) + 1800 })).toString('base64') + '.test';

(async () => {
    let browser;
    // Only peripheral bindings are stubbed. The router, menu, API error parser and shell are real.
    const stubs = {
        '/spa/scripts/crud.js': 'export function buildCrud(){} export function loadDataCrud(){}',
        '/spa/scripts/user-area.js': 'export function bindUserArea(){}',
        '/spa/scripts/release-footer.js': 'export function preloadInstalledVersion(){}',
        '/spa/scripts/application-context.js': `export async function initializeApplicationContext(){window.environments={urlApi:'/apps/clinica/yapi'};window.yeshuaActiveApplication={application:'Clinica',title:'Clínica'};}export function bindApplicationSelector(){const s=document.getElementById('application-selector');s.innerHTML='<option>Clínica</option>';s.classList.remove('hidden');}export function getAuthenticationApi(){return '/apps/central/yapi';}`
    };
    const server = http.createServer((req, res) => {
        const name = new URL(req.url, 'http://localhost').pathname;
        res.setHeader('Cache-Control', 'no-store');
        if (name === '/spa/') {
            res.setHeader('Content-Type', 'text/html; charset=utf-8');
            res.end(`<!doctype html><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="/spa/styles/yeshua-ui.css"><style>.hidden{display:none!important}body{margin:0;background:var(--y-canvas);font-family:Arial,sans-serif;color:#18372e}#app{padding:150px 16px 20px}#module-load-error{max-width:768px;margin:24px auto;background:white;padding:20px;border:1px solid #ddd;border-radius:6px}h2{font-size:18px;margin:0}p{font-size:14px;line-height:1.6}button{font:inherit;border:1px solid #ddd;padding:10px 14px;border-radius:4px;cursor:pointer}[data-action="retry"]{color:white}[data-action="central"]{background:white}@media(max-width:600px){#app{padding-top:160px}#module-load-error button{margin-bottom:8px}}</style><div id="app"></div><script type="module">import {handleRouting} from '/spa/scripts/router.js';window.yeshuaExtensions={dashboard:async()=>{window.dashboardCalls=(window.dashboardCalls||0)+1;await fetch('/appointments-probe');}};window.renderDashboard=()=>handleRouting('#dashboard');await window.renderDashboard();window.ready=true;</script>`);
            return;
        }
        if (stubs[name]) { res.setHeader('Content-Type', 'text/javascript'); res.end(stubs[name]); return; }
        const file = path.resolve(root, '.' + name);
        if (!file.startsWith(root + path.sep) || !fs.existsSync(file) || !fs.statSync(file).isFile()) { res.writeHead(404).end(); return; }
        res.setHeader('Content-Type', (file.endsWith('.js') ? 'text/javascript' : file.endsWith('.css') ? 'text/css' : 'text/html') + '; charset=utf-8');
        res.end(fs.readFileSync(file));
    });
    await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
    const origin = `http://127.0.0.1:${server.address().port}`;
    try {
        browser = await chromium.launch({ channel: 'msedge', headless: true });
        fs.mkdirSync(artifacts, { recursive: true });
        for (const viewport of [{ width: 1366, height: 900 }, { width: 375, height: 812 }]) {
            const context = await browser.newContext({ viewport });
            await context.addInitScript(t => { if (!sessionStorage.getItem('access-test-seeded')) { localStorage.setItem('token', t); localStorage.setItem('tokenExp', String(Date.now() + 1800000)); sessionStorage.setItem('access-test-seeded', '1'); } }, token);
            const page = await context.newPage(), errors = [];
            page.on('pageerror', error => errors.push(error.message));
            let status = 403, body = { code: 'USAGE_PERIOD_REQUIRED', message }, appointments = 0;
            await page.route('**/apps/clinica/yapi/getMenu', route => route.fulfill({ status, json: body }));
            await page.route('**/appointments-probe', route => { appointments++; return route.fulfill({ json: [] }); });
            // Capture navigation targets without executing a real purchase/login.
            await page.route('**/spa/?app=Central', route => route.fulfill({ contentType: 'text/html', body: '<p>Central destination</p>' }));
            const open = async () => { await page.goto(origin + '/spa/?app=Clinica#dashboard'); await page.waitForFunction(() => window.ready); };
            await open();
            await page.getByRole('heading', { name: 'Período de acesso necessário', exact: true }).waitFor();
            assert.equal(await page.locator('#module-load-error p').textContent(), message);
            assert.equal(await page.locator('#module-load-error').count(), 1);
            assert.equal(appointments, 0, 'Denied entry must not load appointments');
            assert.equal(await page.evaluate(() => window.dashboardCalls || 0), 0);
            assert.equal(await page.evaluate(() => document.documentElement.scrollWidth > innerWidth), false);
            await page.screenshot({ path: path.join(artifacts, `access-period-${viewport.width}.png`), fullPage: true });
            await page.getByRole('button', { name: 'Ir para créditos e contratações', exact: true }).click();
            await page.waitForURL('**/spa/?app=Central#central-financeiro');
            assert.equal(await page.evaluate(() => localStorage.getItem('token')), token, 'Keep identity when opening the Central');

            body = {}; await open();
            await page.getByRole('heading', { name: 'Acesso não autorizado', exact: true }).waitFor();
            assert.equal(await page.getByRole('button', { name: 'Ir para créditos e contratações', exact: true }).count(), 0);
            await page.getByRole('button', { name: 'Voltar à Central', exact: true }).click();
            await page.waitForURL('**/spa/?app=Central#dashboard');

            status = 401; await open();
            await page.getByRole('heading', { name: 'Sua sessão expirou', exact: true }).waitFor();
            await page.getByRole('button', { name: 'Entrar novamente', exact: true }).click();
            await page.waitForURL('**/spa/?app=Central#login');
            assert.equal(await page.evaluate(() => localStorage.getItem('token')), null);
            await page.evaluate(t => localStorage.setItem('token', t), token);

            status = 503; await open();
            await page.getByRole('heading', { name: 'Não foi possível abrir este aplicativo', exact: true }).waitFor();
            await page.getByRole('button', { name: 'Tentar novamente', exact: true }).waitFor();
            assert.equal(appointments, 0);
            // Recover on the same page without retaining the denial panel.
            status = 200; body = [];
            await page.evaluate(() => window.renderDashboard());
            assert.equal(await page.locator('#module-load-error').count(), 0);
            assert.equal(appointments, 1, 'Licensed entry renders the dashboard exactly once');
            assert.deepEqual(errors, []);
            await context.close();
        }
        console.log('Module access passed on desktop/mobile: period guidance and destination, permission, expired session, outage, no denied dashboard and successful recovery.');
    } finally { await browser?.close(); await new Promise(resolve => server.close(resolve)); }
})().catch(error => { console.error(error); process.exitCode = 1; });
