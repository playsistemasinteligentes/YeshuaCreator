const assert=require('node:assert/strict'),fs=require('node:fs'),http=require('node:http'),path=require('node:path');
const {chromium}=require('playwright');
const root=path.resolve(__dirname,'../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
let browser,server;
(async()=>{
 server=http.createServer((req,res)=>{
  const pathname=new URL(req.url,'http://localhost').pathname;
  if(pathname==='/help-test'){
   res.setHeader('Content-Type','text/html; charset=utf-8');
   res.end(`<!doctype html><html><head><meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="/spa/styles/yeshua-ui.css"><link rel="stylesheet" href="/spa/styles/help-panel.css"><style>.hidden{display:none!important}</style></head><body><div id="alertContainer"></div><button id="help-prompt-copy">Ajuda</button><script>window.environments={authenticationApi:'/yapi'};window.yeshuaActiveApplication={application:'Memorias',title:'Memórias'};</script><script type="module">import {bindHelpPrompt} from '/spa/scripts/help-prompt.js';bindHelpPrompt();window.ready=true;</script></body></html>`);return;
  }
  const file=path.resolve(root,'.'+pathname);
  if(!file.startsWith(root+path.sep)||!fs.existsSync(file)){res.writeHead(404).end();return;}
  res.setHeader('Content-Type',file.endsWith('.js')?'text/javascript':file.endsWith('.css')?'text/css':'text/html');res.end(fs.readFileSync(file));
 });
 await new Promise(r=>server.listen(0,'127.0.0.1',r));
 browser=await chromium.launch({channel:'msedge',headless:true});
 const page=await browser.newPage(),errors=[],requests=[],ids=[];
 page.on('pageerror',e=>errors.push(e.message));
 const token='fixture.'+Buffer.from(JSON.stringify({tenantId:2,nameid:'7'})).toString('base64url')+'.fixture';
 await page.addInitScript(t=>localStorage.setItem('token',t),token);
 // A real non-trustworthy origin: localhost HTTP is secure and would conceal this regression.
 await page.route('http://help-http.test/**',async route=>{
  const req=route.request(),url=new URL(req.url());
  if(url.pathname.startsWith('/yapi/')){
   requests.push(url.pathname);
   if(url.pathname==='/yapi/version')return route.fulfill({json:{version:'1.0.4'}});
   const body=req.postDataJSON();
   if(url.pathname.includes('PrepararChamado')){ids.push(body.chamadoId);return route.fulfill({json:{chamadoId:body.chamadoId,aberto:false}});}
   if(url.pathname.includes('AbrirChamado'))return route.fulfill({json:{chamadoId:body.chamadoId,aberto:true}});
   throw new Error('Unexpected API '+url.pathname);
  }
  const response=await fetch(`http://127.0.0.1:${server.address().port}${url.pathname}${url.search}`);
  await route.fulfill({status:response.status,contentType:response.headers.get('content-type'),body:Buffer.from(await response.arrayBuffer())});
 });
 await page.goto('http://help-http.test/help-test?secret=DO_NOT_COPY#dashboard');await page.waitForFunction(()=>window.ready);
 const capabilities=await page.evaluate(()=>({secure:isSecureContext,uuid:typeof crypto.randomUUID,random:typeof crypto.getRandomValues,media:typeof navigator.mediaDevices,clipboard:typeof navigator.clipboard}));
 assert.equal(capabilities.secure,false);assert.equal(capabilities.uuid,'undefined');assert.equal(capabilities.random,'function');
 await page.getByRole('button',{name:'Ajuda',exact:true}).click();
 await page.locator('dialog[open]').waitFor({timeout:5000});
 assert.equal(await page.locator('dialog').count(),1);
 assert(await page.getByRole('button',{name:'Gravar relato',exact:true}).isDisabled());
 const secureLink=page.getByRole('link',{name:'Abrir em HTTPS para gravar',exact:true});
 assert.equal(await secureLink.getAttribute('href'),'https://help-http.test/help-test#dashboard');
 assert.equal(await secureLink.getAttribute('target'),'_blank');
 assert.equal(new URL(page.url()).protocol,'http:','Help must not redirect the site');
 await page.getByRole('tab',{name:'Sobre',exact:true}).click();await page.getByText('Versão 1.0.4',{exact:true}).waitFor();
 await page.getByRole('tab',{name:'Ajuda com IA',exact:true}).click();
 await page.evaluate(()=>{
  const original=document.execCommand.bind(document);
  document.execCommand=command=>{
   const active=document.activeElement;
   window.copyFallback={insideDialog:Boolean(active.closest('dialog[open]')),text:active.value};
   return original(command);
  };
 });
 await page.getByRole('button',{name:'Copiar prompt',exact:true}).click();
 const fallback=await page.evaluate(()=>window.copyFallback);
 assert.equal(fallback.insideDialog,true,'Clipboard fallback must focus an element inside the active modal');
 assert.equal(fallback.text,await page.locator('#support-prompt').inputValue());
 await page.evaluate(()=>document.execCommand=()=>false);
 await page.getByRole('button',{name:'Copiar prompt',exact:true}).click();
 assert((await page.locator('#support-copy-status').textContent()).includes('Selecione o texto'));
 assert(!(await page.locator('#support-prompt').inputValue()).includes('DO_NOT_COPY'));
 await page.getByRole('tab',{name:'Chamado',exact:true}).click();
 for(let n=0;n<2;n++){
  await page.locator('#support-subject').fill('Ajuda por HTTP');await page.locator('#support-description').fill('Relato digitado, sem microfone.');
  await page.getByRole('button',{name:'Enviar chamado',exact:true}).click();await page.getByText(/Chamado .* aberto\./).waitFor();
  if(n===0)await page.getByRole('button',{name:'Novo chamado',exact:true}).click();
 }
 assert.equal(ids.length,2);assert.notEqual(ids[0],ids[1]);
 ids.forEach(id=>assert.match(id,/^[a-f0-9]{12}4[a-f0-9]{3}[89ab][a-f0-9]{15}$/));
 assert(!requests.some(p=>p.includes('FileUpload')),'HTTP must not start an unusable audio upload');
 assert.deepEqual(errors,[]);
 await page.screenshot({path:path.resolve(__dirname,'../../../artifacts/help-support/help-http.png')});
 console.log(JSON.stringify({passed:true,realInsecureOrigin:true,capabilities,textTickets:true,manualCopy:true,version:true,recordingExplained:true,noRedirect:true}));
})().catch(e=>{console.error(e.stack);process.exitCode=1;}).finally(async()=>{await browser?.close();if(server){server.closeAllConnections();await new Promise(r=>server.close(r));}});
