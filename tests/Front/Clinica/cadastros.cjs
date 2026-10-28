const fs=require('node:fs'),path=require('node:path'),http=require('node:http'),assert=require('node:assert/strict');
const {chromium}=require('playwright');
const root=path.resolve(__dirname,'../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const source=fs.readFileSync(path.resolve(__dirname,'../../../src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Api/Migration/EndPoints.cs'),'utf8');
const entities=['Clinica','Especialidade','Profissional','DisponibilidadeAgenda','GrupoServico','Servico','Paciente','Sesoes','RevisaoRegistroSessao','MovimentacaoFinanceira','PlanoConta','MovimentoFinanceiro'];
function fields(text){return [...text.matchAll(/new \{ id = "([^"]+)", label = "([^"]+)", type = "([^"]+)"([^\n]*)/g)].map(([,id,label,type,rest])=>({id,label,type,isFk:rest.includes('isFk = true'),required:rest.includes('required = true'),editable:!rest.includes('editable = false'),maxLength:Number(rest.match(/maxLength = (\d+)/)?.[1]||0),displaygroup:rest.match(/displaygroup = "([^"]+)"/)?.[1]||'Geral',endPontGetMetadata:rest.match(/endPontGetMetadata = "([^"]*)"/)?.[1]||'',options:[...rest.matchAll(/value = (\d+), display = "([^"]*)"/g)].map(([,value,display])=>({value:Number(value),display}))}));}
function metadata(entity){
 const start=source.indexOf('app.MapGet("/yapi/getMetaData'+entity+'",');assert(start>=0,entity);
 const block=source.slice(start,source.indexOf('return Results.Ok(metadatacrud);',start));
 return{entityName:entity,entityDescription:entity,capabilities:{create:true,update:true,delete:true},formFields:fields(block.slice(block.indexOf('formFields ='),block.indexOf('endpoints ='))),relationTabs:[],customTabs:[],search:[{id:'Standard',endpoint:block.match(/endpoint = "([^"]+)"/)[1],resultFields:fields(block.slice(block.indexOf('resultFields ='),block.indexOf('filterFields ='))),filterFields:fields(block.slice(block.indexOf('filterFields ='),block.indexOf('quickSearches ='))),quickSearches:[]}],endpoints:{create:`/${entity}/Post${entity}`,read:`/${entity}/Read${entity}`,update:`/${entity}/Put${entity}`,delete:`/${entity}/Delete${entity}`}};
}
const server=http.createServer((req,res)=>{
 const pathname=new URL(req.url,'http://localhost').pathname;
 if(pathname==='/spa/test-cadastros'){
  res.setHeader('Content-Type','text/html; charset=utf-8');res.end(`<!doctype html><meta name="viewport" content="width=device-width,initial-scale=1"><style>.hidden{display:none!important}.fixed{position:fixed}.inset-0{inset:0}.flex{display:flex}.yeshua-shell-header{top:0;left:0;right:0;height:100px}.yeshua-brand-mark{width:32px;height:32px}body{margin:0;padding-top:110px}</style><div id="alertContainer"></div><div id="app"></div><div id="modals-container"></div><script>window.environments={urlApi:'/apps/clinica/yapi'};</script><script src="/Custon/extensions.js"></script><script type="module">import{initFkModal}from'/spa/scripts/components/fk-modal.js';import{handleRouting}from'/spa/scripts/router.js';import{loadDataCrud}from'/spa/scripts/crud.js';await initFkModal();await handleRouting('#dashboard');window.openEntity=async name=>{document.getElementById('custom-page-container')?.classList.add('hidden');await loadDataCrud('/apps/clinica/yapi/getMetaData'+name,'crud');};window.ready=true;</script>`);return;
 }
 const file=path.resolve(root,'.'+pathname);if(!file.startsWith(root+path.sep)||!fs.existsSync(file)||!fs.statSync(file).isFile()){res.writeHead(404);res.end();return;}
 res.setHeader('Content-Type',file.endsWith('.js')?'text/javascript; charset=utf-8':file.endsWith('.json')?'application/json':file.endsWith('.css')?'text/css; charset=utf-8':'text/html; charset=utf-8');res.end(fs.readFileSync(file));
});
(async()=>{
 await new Promise(resolve=>server.listen(0,'127.0.0.1',resolve));let browser;
 try{
  browser=await chromium.launch({channel:'msedge',headless:true});const context=await browser.newContext({viewport:{width:1360,height:1000}});
  const token='test.'+Buffer.from(JSON.stringify({tenantId:7,nameid:'13',userCatalogs:'Clinica',exp:2000000000})).toString('base64url')+'.test';
  await context.addInitScript(token=>{localStorage.setItem('token',token);localStorage.setItem('tokenExp','2000000000000');localStorage.setItem('yeshua.activeApplication','Clinica');},token);
  const page=await context.newPage(),errors=[],calls=[];page.setDefaultTimeout(15000);page.on('pageerror',e=>errors.push(e.message));
  await page.route('**/apps/clinica/yapi/**',async route=>{
   const req=route.request(),url=new URL(req.url()),body=req.method()==='POST'||req.method()==='PUT'?req.postDataJSON():null;calls.push({path:url.pathname,method:req.method(),body});let status=200,data;
   if(url.pathname.endsWith('/getMenu'))data=[];
   else if(url.pathname.includes('/getMetaData'))data=metadata(url.pathname.split('/getMetaData')[1]);
   else if(url.pathname.includes('ConsultarAtendimentos'))data={profissionalId:3,profissionalNome:'Profissional fictício',agenda:[],pacientes:[],atual:[],historico:[],audios:[]};
   else if(url.pathname.endsWith('/PostPaciente')&&body.telefone==='123'){status=400;data={statusCode:400,messageList:['Telefone de contato inválido.','Confira o DDD. <img src=x onerror="window.invalidMessage=true">']};}
   else if(url.pathname.endsWith('/PostPaciente'))data={statusCode:200,data:{id:77,nome:body.nome,telefone:body.telefone}};
   else if(req.method()==='PUT')data={statusCode:200,data:{id:body.id}};
   else if(url.pathname.includes('ReadEspecialidade'))data={data:{items:[{id:4,descricao:'Especialidade fictícia'}],page:1,pageSize:5}};
   else data={data:{items:[],page:1,pageSize:5}};
   await route.fulfill({status,contentType:'application/json',body:JSON.stringify(data)});
  });
  await page.goto(`http://127.0.0.1:${server.address().port}/spa/test-cadastros`);await page.waitForFunction(()=>window.ready);
  assert(await page.locator('.cli-panel').isVisible(),'Clinic opens the attendance dashboard through the normal router');
  assert.equal(await page.locator('#crud-container').evaluate(e=>e.style.display),'none');
  for(const entity of entities){
   const meta=metadata(entity);assert(meta.search[0].filterFields.length<=2,entity);assert(meta.search[0].resultFields.length<=5,entity);
   await page.evaluate(entity=>window.openEntity(entity),entity);
   assert.equal(await page.locator('#filtros-simples input,#filtros-simples select').count(),meta.search[0].filterFields.length,entity);
   assert.equal(await page.locator('#btn-action-audio').count(),0,'No recording button in unrelated registrations');
   if(['Sesoes','RevisaoRegistroSessao'].includes(entity)){assert(await page.locator('#btn-save').isHidden());assert(await page.locator('#form-container').isHidden());}
  }
  await page.evaluate(()=>window.openEntity('Paciente'));const before=calls.length;
  await page.locator('#btn-save').click();assert.equal(calls.length,before,'Required fields prevent incomplete requests');
  await page.locator('#insert-nome').fill('Paciente fictício');await page.locator('#insert-telefone').fill('123');await page.locator('#btn-save').click();await page.locator('#alertContainer').filter({hasText:'Confira o DDD.'}).waitFor();
  assert.equal(await page.locator('#insert-nome').inputValue(),'Paciente fictício');assert.equal(await page.locator('#alertContainer img').count(),0);assert.equal(await page.evaluate(()=>Boolean(window.invalidMessage)),false);
  assert.equal(await page.locator('#insert-datanascimento').getAttribute('type'),'date');
  await page.locator('#insert-telefone').fill('11999990000');await page.locator('#btn-save').click();await page.getByText('Registro inserido com sucesso!',{exact:true}).waitFor();
  await page.locator('#insert-nome').fill('Paciente atualizado fictício');await page.locator('#btn-save').click();await page.getByText('Registro atualizado com sucesso!',{exact:true}).waitFor();assert.equal(calls.at(-1).body.id,77);
  await page.setViewportSize({width:390,height:844});assert.equal(await page.locator('#insert-nome').inputValue(),'Paciente atualizado fictício');assert.equal(await page.locator('#insert-telefone').inputValue(),'11999990000');
  await page.setViewportSize({width:1360,height:1000});await page.evaluate(()=>window.openEntity('Profissional'));await page.locator('#search-nome').fill('Profissional procurado');
  await page.locator('#insert-especialidadeid').locator('..').getByRole('button').click();await page.locator('#modal-pesquisa-fk').waitFor({state:'visible'});await page.locator('#modal-pesquisa-fk').getByRole('button',{name:'Selecionar',exact:true}).first().click();
  assert.equal(await page.locator('#insert-especialidadeid').getAttribute('data-id'),'4');assert.equal(await page.locator('#search-nome').inputValue(),'Profissional procurado');
  await page.locator('#btn-search').click();await page.waitForFunction(()=>window.yeshuaFront.crud.state.fullUrl.endsWith('/Profissional/ReadProfissionalGeral'));assert(calls.at(-1).path.endsWith('/Profissional/ReadProfissionalGeral'));assert.equal(calls.at(-1).body.nome,'Profissional procurado');
  await page.locator('#insert-especialidadeid').fill('Outro texto');assert.equal(await page.locator('#insert-especialidadeid').getAttribute('data-id'),'');
  assert.equal(errors.length,0,errors.join('\n'));await context.close();console.log(JSON.stringify({passed:true,registrations:entities.length,defaultAttendance:true,compactSearch:true,requiredValidation:true,realErrors:true,safeMessages:true,patientUpdateIdentity:true,resizePreservesDraft:true,lookupIsolation:true,jsErrors:0}));
 }finally{if(browser)await browser.close();await new Promise(resolve=>server.close(resolve));}
})().catch(error=>{console.error(error.stack||error.message);process.exitCode=1;});
