const assert=require('node:assert/strict'),fs=require('node:fs'),path=require('node:path'),http=require('node:http');
const {chromium}=require('playwright');
const root=path.resolve(__dirname,'../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const token=tenant=>'test.'+Buffer.from(JSON.stringify({tenantId:tenant,nameid:13,exp:2000000000})).toString('base64url')+'.test';
(async()=>{
 const server=http.createServer((req,res)=>{
  const pathname=new URL(req.url,'http://localhost').pathname;
  if(pathname==='/test'){res.setHeader('Content-Type','text/html; charset=utf-8');res.end('<!doctype html><meta name="viewport" content="width=device-width,initial-scale=1"><style>body{margin:0}.hidden{display:none!important}</style><div id="app"><div id="crud-container"></div></div><script>window.environments={urlApi:"/apps/clinica/yapi"}</script><script type="module">import {renderClinicaAtendimentos} from "/Custon/Apps/Clinica/pages/atendimentos.js";await renderClinicaAtendimentos();window.ready=true;</script>');return;}
  const file=path.resolve(root,'.'+pathname);if(!file.startsWith(root+path.sep)||!fs.existsSync(file)||!fs.statSync(file).isFile()){res.writeHead(404).end();return;}
  res.setHeader('Content-Type',file.endsWith('.js')?'text/javascript; charset=utf-8':file.endsWith('.css')?'text/css; charset=utf-8':'text/html; charset=utf-8');res.end(fs.readFileSync(file));
 });
 await new Promise(r=>server.listen(0,'127.0.0.1',r));let browser;
 try{
  browser=await chromium.launch({channel:'msedge',headless:true});const cases=[];
  async function fixture({denied=false,existing=false}={}){
   let step=1,done=false;const calls=[],errors=[],records={clinicas:[],profissionais:[],servicos:[]};
   if(existing)Object.assign(records,{clinicas:[{id:3,nome:'Clínica existente',endereco:'Endereço fictício',telefone:'0000000000',tipoEstrutura:2}],profissionais:[{id:4,nome:'Profissional existente',telefone:'0000000000',vinculado:false}],servicos:[{id:5,nome:'Serviço existente',valor:0,modeloConsulta:2}]});
   const context=await browser.newContext({viewport:{width:390,height:844}});await context.addInitScript(t=>localStorage.setItem('token',t),token(7));
   const page=await context.newPage();page.setDefaultTimeout(15000);page.on('pageerror',e=>errors.push(e.message));
   await page.route('**/apps/clinica/yapi/**',async route=>{
    const req=route.request(),url=req.url(),body=req.postDataJSON();calls.push({url,body});let data;
    if(url.includes('ConsultarAtendimentos'))data={configuracaoNecessaria:!done,configuracaoMotivo:'Vamos preparar sua agenda.',profissionalId:done?4:0,profissionalNome:done?'Profissional configurado':'',agenda:[],pacientes:[],atual:[],historico:[],audios:[]};
    else if(url.includes('AbrirConfiguracaoClinica')){if(denied){await route.fulfill({status:403,contentType:'application/json',body:JSON.stringify({message:'Sem permissão'})});return;}data={sagaId:11,sagaStepId:step+20,etapa:step,concluida:done,...records};}
    else if(url.includes('Confirmar')){assert.equal(body.sagaId,11);assert.equal(body.sagaStepId,step+20);if(step===1&&!body.clinicaId)records.clinicas=[{id:3,...body}];if(step===2&&!body.profissionalId)records.profissionais=[{id:4,...body,vinculado:true}];if(step===3)done=true;else step++;data={accepted:true};}
    else throw new Error('Unexpected API '+url);
    await route.fulfill({status:200,contentType:'application/json',body:JSON.stringify(data)});
   });
   await page.goto(`http://127.0.0.1:${server.address().port}/test`);await page.waitForFunction(()=>window.ready);
   return{context,page,calls,errors,records};
  }
  let f=await fixture();assert(await f.page.locator('#cli-configuracao').isVisible());assert(await f.page.locator('#cli-layout').isHidden());assert.equal(f.calls.length,2);
  await f.page.locator('[name="nome"]').fill('Clínica fictícia');await f.page.locator('[name="endereco"]').fill('Endereço de teste');await f.page.locator('[name="telefone"]').fill('0000000000');await f.page.locator('[name="estrutura"]').selectOption('2');
  await f.page.locator('#cli-atualizar').click();assert.equal(await f.page.locator('[name="nome"]').inputValue(),'Clínica fictícia');
  await f.page.getByRole('button',{name:'Confirmar e continuar',exact:true}).click();await f.page.getByRole('heading',{name:'Seu profissional',exact:true}).waitFor();await f.page.reload();await f.page.waitForFunction(()=>window.ready);await f.page.getByRole('heading',{name:'Seu profissional',exact:true}).waitFor();
  assert.equal(f.calls.filter(x=>x.url.includes('ConfirmarEstabelecimento')).length,1);
  await f.page.locator('[name="nome"]').fill('Profissional fictício');await f.page.locator('[name="telefone"]').fill('0000000000');await f.page.getByRole('button',{name:'Confirmar e continuar',exact:true}).click();await f.page.getByRole('heading',{name:'Serviço e modelo',exact:true}).waitFor();
  await f.page.locator('[name="nome"]').fill('Consulta fictícia');await f.page.locator('[name="modelo"]').selectOption('2');assert((await f.page.locator('[data-config-model]').textContent()).includes('Dois campos'));
  assert(await f.page.evaluate(()=>document.documentElement.scrollWidth<=innerWidth+1));fs.mkdirSync(path.join(__dirname,'artifacts'),{recursive:true});await f.page.screenshot({path:path.join(__dirname,'artifacts/initial-setup-mobile.png'),fullPage:true});
  await f.page.getByRole('button',{name:'Concluir e abrir minha agenda',exact:true}).click();await f.page.getByText('Configuração concluída. Sua agenda está pronta para receber consultas.',{exact:true}).waitFor();assert(await f.page.locator('#cli-layout').isVisible());assert(await f.page.locator('#cli-configuracao').isHidden());assert.equal(f.errors.length,0);await f.context.close();cases.push('automatic setup, three persisted phases, resume after reload, stable refresh, mobile, opens agenda');
  f=await fixture({existing:true});assert(await f.page.locator('[data-config-new]').isHidden());await f.page.getByRole('button',{name:'Confirmar e continuar',exact:true}).click();await f.page.getByRole('heading',{name:'Seu profissional',exact:true}).waitFor();assert.equal(await f.page.locator('[name="cadastro"]').inputValue(),'4');await f.page.getByRole('button',{name:'Confirmar e continuar',exact:true}).click();await f.page.getByRole('heading',{name:'Serviço e modelo',exact:true}).waitFor();assert(await f.page.locator('[name="modelo"]').isDisabled());assert.equal(await f.page.locator('[name="modelo"]').inputValue(),'2');await f.page.getByRole('button',{name:'Concluir e abrir minha agenda',exact:true}).click();await f.page.locator('#cli-layout').waitFor();assert.equal(f.calls.find(x=>x.url.includes('ConfirmarServico')).body.servicoId,5);await f.context.close();cases.push('reuse existing registrations without duplicates; service model preserved');
  f=await fixture({denied:true});await f.page.getByText('Seu acesso ao Clínica está ativo. A configuração precisa ser feita por um administrador autorizado.',{exact:true}).waitFor();assert.equal(f.errors.length,0);assert(await f.page.locator('#cli-layout').isHidden());await f.context.close();cases.push('unauthorized configuration gives actionable guidance without crashing application');
  f=await fixture();await f.page.evaluate(t=>localStorage.setItem('token',t),token(8));let before=f.calls.length;await f.page.locator('#cli-atualizar').click();await f.page.getByText('O usuário ou a clínica mudou. Reabra o painel para continuar.',{exact:true}).waitFor();assert.equal(f.calls.length,before);await f.context.close();cases.push('tenant switch cannot submit cached setup');
  console.log(JSON.stringify({passed:true,cases}));
 }finally{if(browser)await browser.close();await new Promise(r=>server.close(r));}
})().catch(e=>{console.error(e.stack||e.message);process.exitCode=1;});
