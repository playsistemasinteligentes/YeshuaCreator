// Local browser regression: real panel/assets, synthetic API responses, no database.
const assert=require('node:assert/strict'),fs=require('node:fs'),path=require('node:path'),http=require('node:http');
const {chromium}=require('playwright');
const root=path.resolve(__dirname,'../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const occurrence=(ordem,conflito=false)=>({ordem,sessaoId:0,dataInicio:`2030-02-${String(4+ordem*7).padStart(2,'0')}T10:00`,dataFim:`2030-02-${String(4+ordem*7).padStart(2,'0')}T10:50`,agendar:true,conflito});
(async()=>{
 const server=http.createServer((req,res)=>{
  const pathname=new URL(req.url,'http://localhost').pathname;
  if(pathname==='/test'){
   res.setHeader('Content-Type','text/html; charset=utf-8');res.end('<!doctype html><meta name="viewport" content="width=device-width,initial-scale=1"><div id="app"><div id="crud-container"></div></div><script>window.environments={urlApi:"/apps/clinica/yapi"};</script><script type="module">import {renderClinicaAtendimentos} from "/Custon/Apps/Clinica/pages/atendimentos.js";await renderClinicaAtendimentos();window.ready=true;</script>');return;
  }
  const file=path.resolve(root,'.'+pathname);
  if(!file.startsWith(root+path.sep)||!fs.existsSync(file)||!fs.statSync(file).isFile()){res.writeHead(404);res.end();return;}
  res.setHeader('Content-Type',file.endsWith('.js')?'text/javascript; charset=utf-8':file.endsWith('.css')?'text/css; charset=utf-8':'text/html; charset=utf-8');res.end(fs.readFileSync(file));
 });
 await new Promise(resolve=>server.listen(0,'127.0.0.1',resolve));let browser;
 try{
  browser=await chromium.launch({headless:true});
  for(const width of [1440,390]){
   const context=await browser.newContext({viewport:{width,height:1000},timezoneId:'Asia/Tokyo'});
   await context.addInitScript(()=>localStorage.setItem('token','test.'+btoa(JSON.stringify({tenantId:7,nameid:'13'}))+'.test'));
   const page=await context.newPage(),errors=[],confirmations=[];let conflicts=false,rejectConfirmation=false;
   page.on('pageerror',e=>errors.push(e.message));
   await page.route('**/apps/clinica/yapi/**',async route=>{
    const request=route.request(),url=request.url();let data,status=200;
    if(url.includes('ConsultarAtendimentos'))data={profissionalId:3,profissionalNome:'Teste',servicoHabitualId:5,servicoHabitualNome:'Consulta',modeloConsultaHabitual:1,versaoModeloConsultaHabitual:1,agenda:[],pacientes:[{id:42,nome:'Paciente fictício'}],atual:[],historico:[],audios:[]};
    else if(url.includes('PreverRecorrenciaConsultas'))data={planoId:'a'.repeat(32),confirmado:false,ocorrencias:[occurrence(0),occurrence(1,conflicts),occurrence(2,conflicts)]};
    else if(url.includes('ConfirmarRecorrenciaConsultas')){
     const body=request.postDataJSON();confirmations.push(body);
     if(rejectConfirmation){status=409;data={statusCode:409,message:'Conflito na ocorrência 1. Altere o horário ou escolha não agendar.'};rejectConfirmation=false;}
     else data={planoId:body.planoId,confirmado:true,ocorrencias:body.ocorrencias};
    }else throw new Error('Unexpected API '+url);
    await route.fulfill({status,contentType:'application/json',body:JSON.stringify(data)});
   });
   await page.goto(`http://127.0.0.1:${server.address().port}/test`);await page.waitForFunction(()=>window.ready);
   async function preview(){
    await page.locator('#cli-novo').click();await page.locator('#cli-agendar-recorrencia').selectOption('7');
    await page.locator('#cli-agendar-inicio').fill('2030-02-04T10:00');await page.locator('#cli-agendar-fim').fill('2030-02-04T10:50');await page.locator('#cli-agendar-final').fill('2030-02-18');
    await page.locator('#cli-agendar-confirmar').click();await page.locator('#cli-recorrencia-previa').waitFor();
   }
   const visible=()=>page.locator('#cli-recorrencia-itens fieldset:visible');
   await preview();assert.equal(await visible().count(),0);
   assert.match(await page.locator('#cli-recorrencia-resumo').textContent(),/Semanal.*04\/02\/2030.*18\/02\/2030.*3 ocorrência/);
   assert.match(await page.locator('#cli-recorrencia-estado').textContent(),/Nenhum conflito/);
   assert(await page.locator('#cli-recorrencia-revisao').isHidden());assert(await page.locator('#cli-recorrencia-confirmar').isEnabled());
   await page.locator('#cli-recorrencia-tab-todas').click();assert.equal(await visible().count(),3);
   await page.locator('#cli-recorrencia-tab-todas').press('ArrowLeft');assert.equal(await visible().count(),0);
   assert.equal(await page.locator('#cli-recorrencia-tab-resumo').getAttribute('aria-selected'),'true');
   await page.locator('#cli-recorrencia-confirmar').click();await page.waitForFunction(()=>!document.querySelector('#cli-agendar-dialog').open);
   assert.deepEqual(confirmations[0],{planoId:'a'.repeat(32),revisado:true,ocorrencias:[0,1,2].map(i=>{const {ordem,dataInicio,dataFim,agendar}=occurrence(i);return {ordem,dataInicio,dataFim,agendar};})});
   conflicts=true;await preview();assert.equal(await visible().count(),2);
   await page.locator('#cli-recorrencia-revisado').check();assert(await page.locator('#cli-recorrencia-confirmar').isDisabled());
   const second=page.locator('[data-ocorrencia="1"]'),third=page.locator('[data-ocorrencia="2"]');
   await second.locator('[data-inicio]').fill('2030-02-12T11:00');await second.locator('[data-fim]').fill('2030-02-12T11:50');
   assert.equal(await page.locator('#cli-recorrencia-revisado').isChecked(),false);
   await third.locator('[data-agendar]').uncheck();await page.locator('#cli-recorrencia-revisado').check();
   assert(await page.locator('#cli-recorrencia-confirmar').isEnabled());
   await page.locator('#cli-recorrencia-tab-todas').click();assert.equal(await visible().count(),3);
   assert.equal(await second.locator('[data-inicio]').inputValue(),'2030-02-12T11:00');
   await page.locator('#cli-recorrencia-tab-resumo').click();assert.equal(await visible().count(),2);
   rejectConfirmation=true;await page.locator('#cli-recorrencia-confirmar').click();await page.locator('#cli-agendar-erro').getByText(/Conflito na ocorrência 1/).waitFor();
   assert.equal(await page.locator('#cli-recorrencia-tab-todas').getAttribute('aria-selected'),'true');assert.equal(await visible().count(),3);
   assert.equal(await page.locator('#cli-recorrencia-revisado').isChecked(),false);
   await page.locator('[data-ocorrencia="0"] [data-agendar]').uncheck();await page.locator('#cli-recorrencia-revisado').check();
   await page.locator('#cli-recorrencia-confirmar').click();await page.waitForFunction(()=>!document.querySelector('#cli-agendar-dialog').open);
   assert.equal(confirmations.at(-1).ocorrencias.length,3);assert.equal(confirmations.at(-1).ocorrencias[0].agendar,false);
   assert.equal(confirmations.at(-1).ocorrencias[1].dataInicio,'2030-02-12T11:00');assert.equal(confirmations.at(-1).ocorrencias[2].agendar,false);
   assert.deepEqual(errors,[]);await context.close();console.log(`PASS recurrence preview at ${width}px (Tokyo device timezone)`);
  }
 }finally{await browser?.close();await new Promise(resolve=>server.close(resolve));}
})().catch(error=>{console.error(error);process.exitCode=1;});
