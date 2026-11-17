const assert = require('node:assert/strict');
const fs = require('node:fs');
const http = require('node:http');
const path = require('node:path');
const { chromium } = require('playwright');

const root = path.resolve(__dirname, '../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const shell = fs.readFileSync(path.join(root, 'spa/views/dashboard.html'), 'utf8');
const applications = JSON.parse(fs.readFileSync(path.join(root, 'applications.json'), 'utf8').replace(/^\uFEFF/, ''));
const screens = [
    ['APS.ADM', 'planejamento-transporte', 'Planejamento de transporte', 'APS.ADM/pages/planejamento-transporte.html'],
    ['Central', 'application-catalog', 'Aplicativos', 'Central/pages/application-catalog.html'],
    ['Clinica', 'clinica-atendimentos', 'Atendimentos', 'Clinica/pages/atendimentos.html'],
    ['Fiscal', 'contingencia-fiscal', 'Contingência fiscal', 'Fiscal/pages/contingencia-fiscal.html'],
    ['Memorias', 'memorias-estudio', 'Estúdio Memórias', 'Memorias/pages/estudio.html']
];
const jwt = (tenant=2, user=7) => 'header.'+Buffer.from(JSON.stringify({tenantId:tenant,nameid:String(user),email:'SECRET_EMAIL',exp:2000000000})).toString('base64url')+'.signature';

async function main() {
    const server = http.createServer((req,res) => {
        const pathname = new URL(req.url,'http://localhost').pathname;
        if (pathname === '/help-test') {
            res.setHeader('Content-Type','text/html; charset=utf-8');
            res.end(`<!doctype html><html><head><meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="/spa/styles/yeshua-ui.css"><link rel="stylesheet" href="/spa/styles/help-panel.css"><style>body{margin:0}.hidden{display:none!important}.flex{display:flex}.gap-4{gap:16px}.yeshua-shell-header{position:fixed;top:0;left:0;right:0;z-index:50}#alertContainer{position:fixed;top:110px;right:10px;z-index:9999}</style><script src="/spa/environments.js"></script></head><body><div id="alertContainer"></div><div id="app">${shell}<section id="custom-page-container"></section></div><script type="module">import {bindUserArea} from '/spa/scripts/user-area.js';bindUserArea();window.testReady=true;</script></body></html>`);return;
        }
        const file = path.resolve(root,'.'+pathname);
        if (!file.startsWith(root+path.sep) || !fs.existsSync(file) || !fs.statSync(file).isFile()) {res.writeHead(404);res.end();return;}
        res.setHeader('Content-Type',file.endsWith('.js')?'text/javascript; charset=utf-8':file.endsWith('.css')?'text/css; charset=utf-8':'text/html; charset=utf-8');res.end(fs.readFileSync(file));
    });
    await new Promise(resolve=>server.listen(0,'127.0.0.1',resolve));
    let browser;
    try {
        browser = await chromium.launch({channel:'msedge',headless:true});
        const context = await browser.newContext({viewport:{width:1440,height:1000}});
        await context.addInitScript(token => {
            localStorage.setItem('token',token);localStorage.setItem('SECRET_PRIVATE_KEY','SECRET_STORAGE');
            window.copiedPrompts=[];
            Object.defineProperty(navigator,'clipboard',{configurable:true,value:{writeText:async text=>window.copiedPrompts.push(text)}});
        },jwt());
        const page = await context.newPage(), errors=[];let apiCalls=0;
        page.on('pageerror',e=>errors.push(e.message));page.on('request',r=>{if(r.url().includes('/apps/'))apiCalls++;});
        await page.goto(`http://127.0.0.1:${server.address().port}/help-test?token=SECRET_QUERY#dashboard`);await page.waitForFunction(()=>window.testReady);
        await page.evaluate(apps=>{const selector=document.getElementById('application-selector');selector.classList.remove('hidden');for(const app of apps){const option=document.createElement('option');option.value=app.application;option.textContent=app.title;selector.append(option);}},applications);
        for(const [application,key,title,relative] of screens) {
            const markup=fs.readFileSync(path.join(root,'Custon/Apps',relative),'utf8');
            await page.evaluate(({app,markup})=>{window.yeshuaActiveApplication=app;const host=document.getElementById('custom-page-container');host.classList.remove('hidden');host.innerHTML=markup;document.getElementById('application-selector').value=app.application;}, {app:applications.find(x=>x.application===application),markup});
            await page.getByRole('button',{name:'Abrir ajuda',exact:true}).click();
            await page.getByRole('tab',{name:'Ajuda com IA',exact:true}).click();
            await page.getByRole('button',{name:'Copiar prompt',exact:true}).click();
            const text=await page.evaluate(()=>window.copiedPrompts.at(-1));
            assert(text.includes(`(${application})`));assert(text.includes(`Tela: ${title}`));assert(text.includes(`Identificador da tela: ${key}`));assert(text.includes('TenantID: 2'));assert(!text.includes('SECRET_'));
            assert(text.includes('https://playsis.com.br/operational/'));assert(text.includes('https://playsis.com.br/operational/mcp'));
            await page.getByRole('button',{name:'Fechar ajuda',exact:true}).click();
        }
        assert.equal(apiCalls,0,'Copy must not contact APIs or operational intelligence');
        assert.equal(errors.length,0,errors.join('\n'));
        console.log(JSON.stringify({passed:true,applications:screens.length,promptMetadata:true,noPrivateFormValues:true,jsErrors:0}));
    } finally {if(browser)await browser.close();await new Promise(resolve=>server.close(resolve));}
}
main().catch(e=>{console.error(e.stack||e.message);process.exitCode=1;});
