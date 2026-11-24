// Real Chromium + real Presenca page. The HTTP API is an explicit in-memory fixture.
// Every external browser request is blocked; no real channel/account is contacted.
import assert from 'node:assert/strict';
import { createServer } from 'node:http';
import { readFile, mkdir, writeFile } from 'node:fs/promises';
import path from 'node:path';
const { chromium } = await import(process.env.PRESENCA_PLAYWRIGHT_MODULE || 'playwright');
const root = process.cwd();
const evidence = path.resolve(process.env.PRESENCA_BROWSER_EVIDENCE || '/tmp/presenca-browser-evidence');
await mkdir(evidence, { recursive: true });
const front = path.join(root, 'src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const publisher = 'A'.repeat(64), channel = 'B'.repeat(64), pauta = 'C'.repeat(64);
const calls = [], checks = [], errors = [], external = [];
let versions = [], failNextSave = false, savedRetry = null;
const content = (title = 'Notícia de teste') => ({ Manchete: title, Corpo: 'Texto público revisável', AutorPublico: 'Autoria de teste', ClassificacaoPrincipal: 'Notícias', Fontes: [], Tags: [], ClassificacoesSecundarias: [], Materiais: [] });
function version(number, value) { return { Id: `${number}`.padStart(64, '0'), PautaId: pauta, Numero: number, Estado: 'Rascunho', Snapshot: JSON.stringify(value), UserId: 10 }; }
versions = [version(1, content('<img src=x onerror="window.injection=true">'))];
function respond(res, status, value) { res.writeHead(status, { 'Content-Type': 'application/json' }); res.end(JSON.stringify(value)); }
const server = createServer(async (req, res) => {
 try {
  if (req.url === '/') { res.setHeader('Content-Type', 'text/html'); res.end('<div id="app"></div><script>window.environments={urlApi:"/yapi"}</script><script type="module">import {renderRedacao} from "/Custon/Apps/Presenca/pages/redacao.js";await renderRedacao();</script>'); return; }
  if (req.url === '/spa/scripts/ServicesGlobal/apiFetch.js') { res.setHeader('Content-Type', 'text/javascript'); res.end('export const apiFetch=(...args)=>fetch(...args);export const getApiErrorMessage=(payload,status)=>payload.message||`HTTP ${status}`;'); return; }
  if (req.url.startsWith('/Custon/Apps/Presenca/pages/') && /^\/Custon\/Apps\/Presenca\/pages\/redacao\.(html|js)$/.test(req.url)) {
   res.setHeader('Content-Type', req.url.endsWith('.js') ? 'text/javascript' : 'text/html'); res.end(await readFile(path.join(front, req.url))); return;
  }
  if (req.method === 'POST' && req.url.startsWith('/yapi/Presenca/Editorial')) {
   let raw = ''; for await (const chunk of req) raw += chunk;
   const input = JSON.parse(raw), data = JSON.parse(input.Dados), operation = req.url.match(/Editorial(.*)UseCase/)[1];
   calls.push({ operation, input, data }); let output = {};
   if (operation === 'ConsultarIdentidades') output = { Identidades: [{Id:publisher,Nome:'Publicadora de teste'},{Id:'D'.repeat(64),Nome:'Outra identidade'}] };
   else if (operation === 'ConsultarRedacao') output = { Versoes: data.Offset ? [version(99, content('Histórico adicional'))] : versions, Canais: [{Id:channel,Plataforma:'Portal',Destino:'portal-local'}], TemMais: !data.Offset };
   else if (operation === 'CriarPautaManual') { versions = [version(1, data)]; output = { Id:pauta,Versao:1,Estado:'Rascunho' }; }
   else if (operation === 'SalvarRascunho') {
    if (savedRetry?.key === input.Chave) output = savedRetry.output;
    else { output = {Id:pauta,Versao:input.VersaoEsperada+1,Estado:'Rascunho'}; versions.unshift(version(output.Versao, data)); savedRetry = {key:input.Chave,output}; }
    if (failNextSave) { failNextSave = false; respond(res,503,{statusCode:503,message:'Falha transitória de teste'}); return; }
   }
   else if (operation === 'AprovarVersao') { respond(res,409,{statusCode:409,message:'PRESENCA_APPROVER_MUST_DIFFER'}); return; }
   else if (operation === 'ConsultarOperacao') output = {
    Entregas: [{Id:'E'.repeat(64),Estado:'ResultadoIncerto',Tentativas:3,CodigoErro:'PRESENCA_RESULT_UNCERTAIN'}, {Id:'F'.repeat(64),Estado:'FalhaFinal',Tentativas:5,CodigoErro:'PRESENCA_RATE_LIMIT'}],
    SaudeConsultadaEmUtc:'2026-11-24T17:00:00Z',SaudeFilas:[{Fila:'Entrada',Prontas:2},{Fila:'Editorial',EmProcessamento:1},{Fila:'Distribuicao',Agendadas:3,FalhasFinais:1,ResultadosIncertos:1,MaisAntigaSegundos:90}],
    RetornosEducacionais:[{Id:'1'.repeat(64),Estado:'FalhaFinal',Tentativas:5,CodigoErro:'PRESENCA_CALLBACK_UNAVAILABLE'}]
   };
   else if (operation === 'ConsultarAuditoria') output = {AuditoriaJson:JSON.stringify([{Changed:'2026-11-24T10:00:00Z',Operacao:'<script>window.injection=true</script>',UserId:10}])};
   else if (['ReprocessarEntrega','ReconciliarEntrega','ReprocessarStatusEducacional'].includes(operation)) output = {Estado:'Pendente'};
   else throw new Error('Unexpected fixture command '+operation);
   respond(res,200,{statusCode:200,data:{resultado:JSON.stringify(output)}}); return;
  }
  res.writeHead(404); res.end();
 } catch (error) { errors.push(String(error)); respond(res,500,{message:'Fixture failed'}); }
});
await new Promise(resolve=>server.listen(0,'127.0.0.1',resolve));
const origin = `http://127.0.0.1:${server.address().port}`;
let browser;
try {
 browser = await chromium.launch({headless:true});
 const page = await browser.newPage({viewport:{width:1280,height:1000}});
 page.on('pageerror', error=>errors.push(String(error)));
 await page.route('**/*', route=> { if (route.request().url().startsWith(origin+'/')) return route.continue(); external.push(route.request().url()); return route.abort(); });
 await page.goto(origin);
 await page.getByRole('button',{name:'<img src=x onerror="window.injection=true">',exact:false}).waitFor();
 assert.equal(await page.evaluate(()=>Boolean(window.injection)),false); checks.push('Snapshot title is rendered as text, without script execution');
 await page.getByRole('button',{name:'Nova pauta',exact:true}).click();
 await page.locator('[name="Manchete"]').fill('Nova notícia local');
 await page.locator('[name="Corpo"]').fill('Corpo público de teste');
 await page.locator('[name="AutorPublico"]').fill('Autoria pública');
 await page.locator('[name="ClassificacaoPrincipal"]').fill('Produto');
 await page.getByRole('button',{name:'Salvar nova versão',exact:true}).click();
 await page.getByRole('status').filter({hasText:'Versão 1 salva.'}).waitFor();
 assert.equal(calls.filter(c=>c.operation==='CriarPautaManual').length,1); checks.push('Manual draft submission and refreshed history');
 await page.locator('[name="Corpo"]').fill('Texto da segunda versão'); failNextSave=true;
 await page.getByRole('button',{name:'Salvar nova versão',exact:true}).click();
 await page.getByRole('status').filter({hasText:'Falha transitória'}).waitFor();
 await page.getByRole('button',{name:'Salvar nova versão',exact:true}).click();
 await page.getByRole('status').filter({hasText:'Versão 2 salva.'}).waitFor();
 const saves=calls.filter(c=>c.operation==='SalvarRascunho');assert.equal(saves.length,2);assert.equal(saves[0].input.Chave,saves[1].input.Chave);assert.deepEqual(saves[0].input,saves[1].input);assert.equal(versions.length,2);checks.push('Lost response retry keeps the same idempotency key, input and version');
 await page.getByRole('button',{name:'Aprovar versão',exact:true}).click();
 await page.getByRole('status').filter({hasText:'PRESENCA_APPROVER_MUST_DIFFER'}).waitFor();checks.push('Editorial rejection from API is presented without losing the form');
 await page.getByText('Operação das entregas',{exact:true}).click();
 await page.getByRole('button',{name:'Atualizar entregas',exact:true}).click();
 await page.locator('#presenca-saude tbody tr').first().waitFor();assert.equal(await page.locator('#presenca-saude tbody tr').count(),3);assert.match(await page.locator('#presenca-saude').innerText(),/Registros persistidos desta identidade e ambiente/);checks.push('Scoped queue health displays persisted counts, waiting work and uncertainty separately');
 const uncertain=page.locator('#presenca-entregas fieldset').filter({has:page.locator('legend').filter({hasText:'ResultadoIncerto'})});
 assert.equal(await uncertain.getByRole('button',{name:'Agendar nova tentativa',exact:true}).count(),0);checks.push('Uncertain publication exposes reconciliation only, without blind resend');
 await uncertain.locator('input').nth(0).fill('Entrega conferida no teste');await uncertain.locator('input').nth(1).fill('receipt-test-1');await uncertain.locator('input').nth(2).fill('https://public.example.org/test/');
 await uncertain.getByRole('button').click();await page.getByRole('status').filter({hasText:'Pendente'}).waitFor();
 const reconciled=calls.find(c=>c.operation==='ReconciliarEntrega');assert.equal(reconciled.input.RegistroId,'E'.repeat(64));assert.equal(reconciled.input.VersaoEsperada,3);checks.push('Reconciliation sends the selected delivery and expected attempt count');
 const callback=page.locator('#presenca-entregas fieldset').filter({has:page.locator('legend').filter({hasText:'Retorno à Academia'})});
 await callback.locator('input').fill('Academia disponível no teste');await callback.getByRole('button').click();await page.getByRole('status').filter({hasText:'Retorno reagendado.'}).waitFor();
 const recovered=calls.find(c=>c.operation==='ReprocessarStatusEducacional');assert.equal(recovered.input.RegistroId,'1'.repeat(64));assert.equal(recovered.input.VersaoEsperada,5);assert.equal(recovered.data.Motivo,'Academia disponível no teste');checks.push('Callback recovery sends explicit reason, callback ID and expected attempt');
 await page.getByText('Auditoria editorial',{exact:true}).click();await page.getByRole('button',{name:'Consultar histórico de ações',exact:true}).click();
 await page.locator('#presenca-acoes p').waitFor();assert.equal(await page.evaluate(()=>Boolean(window.injection)),false);checks.push('Audit projection is rendered as text');
 await page.getByRole('button',{name:'Carregar mais versões',exact:true}).click();await page.getByRole('button',{name:'Histórico adicional',exact:false}).waitFor();assert(calls.some(c=>c.operation==='ConsultarRedacao'&&c.data.Offset===2));checks.push('History pagination sends the next offset');
 await page.locator('[name="Manchete"]').fill('Edição ainda não salva');page.once('dialog',dialog=>dialog.dismiss());await page.locator('#presenca-identidade').selectOption('D'.repeat(64));assert.equal(await page.locator('#presenca-identidade').inputValue(),publisher);assert.equal(await page.locator('[name="Manchete"]').inputValue(),'Edição ainda não salva');checks.push('Cancelling identity switch preserves dirty draft and selected publisher');
 assert.deepEqual(errors,[]);assert.deepEqual(external,[]);
 await page.screenshot({path:path.join(evidence,'redacao.png'),fullPage:true});
 await writeFile(path.join(evidence,'browser.json'),JSON.stringify({status:'passed',browser:await browser.version(),checks,api:'in-memory fixture, not SQL/API integration',externalRequests:external,errors},null,2)+'\n');
 console.log(JSON.stringify({status:'passed',checks:checks.length,browser:await browser.version(),externalRequests:external.length}));
} catch(error) {
 await writeFile(path.join(evidence,'browser-failure.json'),JSON.stringify({status:'failed',checks,error:String(error),errors,external},null,2)+'\n');throw error;
} finally {if(browser)await browser.close();await new Promise(resolve=>server.close(resolve));}
