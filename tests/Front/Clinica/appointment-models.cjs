const assert=require('node:assert/strict'),fs=require('node:fs'),path=require('node:path'),http=require('node:http');
const {chromium}=require('playwright');
const root=path.resolve(__dirname,'../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const services=[{id:10,nome:'Psicoterapia',modeloConsulta:1,versaoModeloConsulta:1},{id:20,nome:'Acompanhamento breve',modeloConsulta:2,versaoModeloConsulta:1}];
const token=tenant=>'test.'+Buffer.from(JSON.stringify({tenantId:tenant,nameid:'13',exp:2000000000})).toString('base64url')+'.test';
const session=()=>({id:42,pacienteId:7,paciente:'Paciente fictício',dataInicio:new Date().toISOString(),dataFim:new Date(Date.now()+3000000).toISOString(),versao:0,statusAgendamento:1,statusProntuario:2,atendimentoIniciadoEm:new Date().toISOString(),atendimentoEncerradoEm:'',registroFinalizadoEm:'',servicoId:20,servicoNome:services[1].nome,modeloConsulta:2,versaoModeloConsulta:1,prontuario:'Texto humano anterior',queixaPrincipal:'',registroDocumental:'',objetivosCurtoPrazo:'',objetivosLongoPrazo:'',exerciciosTarefasSugeridas:'',encaminhamentoOutrosProfissionais:'',frequenciaSugeridaSessooes:'',informacoesRelevantesFuturasConsultas:'Combinados',sugestoesIncorporadas:''});

(async()=>{
 const server=http.createServer((req,res)=>{
  const pathname=new URL(req.url,'http://localhost').pathname;
  if(pathname==='/test'){
   res.setHeader('Content-Type','text/html; charset=utf-8');res.end('<!doctype html><meta name="viewport" content="width=device-width,initial-scale=1"><style>body{margin:0}.hidden{display:none!important}</style><div id="app"><div id="crud-container"></div></div><script>window.environments={urlApi:"/apps/clinica/yapi"};</script><script type="module">import {renderClinicaAtendimentos} from "/Custon/Apps/Clinica/pages/atendimentos.js";await renderClinicaAtendimentos();window.ready=true;</script>');return;
  }
  const file=path.resolve(root,'.'+pathname);
  if(!file.startsWith(root+path.sep)||!fs.existsSync(file)||!fs.statSync(file).isFile()){res.writeHead(404);res.end();return;}
  res.setHeader('Content-Type',file.endsWith('.js')?'text/javascript; charset=utf-8':file.endsWith('.css')?'text/css; charset=utf-8':'text/html; charset=utf-8');res.end(fs.readFileSync(file));
 });
 await new Promise(resolve=>server.listen(0,'127.0.0.1',resolve));let browser;
 try{
  browser=await chromium.launch({channel:'msedge',headless:true,args:['--use-fake-ui-for-media-stream','--use-fake-device-for-media-stream']});
  const cases=[];
  async function fixture({habitual=services[0],catalog=services,current=session()}={}){
   const context=await browser.newContext({viewport:{width:1440,height:1000},permissions:['microphone']});await context.addInitScript(t=>localStorage.setItem('token',t),token(7));
   const page=await context.newPage(),calls=[],errors=[],writes=[],uploads=[];
   page.setDefaultTimeout(15000);page.on('pageerror',e=>errors.push(e.message));
   await page.route('**/apps/clinica/yapi/**',async route=>{
    const req=route.request(),url=req.url();calls.push(url);let data;
    if(url.includes('ConsultarAtendimentos')){const body=req.postDataJSON();data={profissionalId:3,profissionalNome:'Profissional fictício',servicoHabitualId:habitual?.id||0,servicoHabitualNome:habitual?.nome||'',modeloConsultaHabitual:habitual?.modeloConsulta||0,versaoModeloConsultaHabitual:habitual?.versaoModeloConsulta||0,agenda:[current],pacientes:[{id:7,nome:current.paciente}],atual:body.sessaoId?[current]:[],historico:[],audios:[{sagaId:55,data:new Date().toISOString(),status:'Concluído',prontuario:'Sugestão de evolução',queixaPrincipal:'Sugestão de queixa',registroDocumental:'Sugestão documental'}]};}
    else if(url.includes('ConsultarServicosAgendamento'))data={servicos:catalog};
    else if(url.includes('DefinirServicoHabitual')){const id=req.postDataJSON().servicoId;habitual=catalog.find(s=>s.id===id)||null;data=habitual||{id:0,nome:'',modeloConsulta:0,versaoModeloConsulta:0};}
    else if(url.includes('AgendarAtendimento')){const body=req.postDataJSON();writes.push(body);current={...session(),id:43,atendimentoIniciadoEm:'',prontuario:'',informacoesRelevantesFuturasConsultas:'',...body};current.servicoNome=catalog.find(s=>s.id===body.servicoId).nome;data={sessaoId:43,versao:0};}
    else if(url.includes('SalvarRegistro')){const body=req.postDataJSON();writes.push(body);Object.assign(current,body,{versao:current.versao+1});data={sessaoId:current.id,versao:current.versao};}
    else if(url.includes('EncerrarAtendimento')){current.atendimentoEncerradoEm=new Date().toISOString();current.statusAgendamento=2;current.versao++;data={sessaoId:current.id,versao:current.versao};}
    else if(url.includes('FinalizarRegistro')){const body=req.postDataJSON();writes.push(body);current.registroFinalizadoEm=new Date().toISOString();current.statusProntuario=3;current.versao++;data={sessaoId:current.id,versao:current.versao};}
    else if(url.includes('StarSessionUpload'))data={uploadToken:'fixture-upload'};
    else if(url.includes('SendFileUseCase2')){const bytes=req.postDataBuffer().toString('latin1'),final=/name="isFinalChunk"\r\n\r\ntrue/.test(bytes);uploads.push({final,bytes:bytes.length});data={success:true,isFinalized:final,sagaId:final?56:0};}
    else throw new Error('Unexpected API '+new URL(url).pathname);
    await route.fulfill({status:200,contentType:'application/json',body:JSON.stringify(data)});
   });
   await page.goto(`http://127.0.0.1:${server.address().port}/test`);await page.waitForFunction(()=>window.ready);
   return{page,context,calls,errors,writes,uploads,current,options:()=>calls.filter(x=>x.includes('ConsultarServicosAgendamento')).length};
  }
  let f=await fixture();let before=f.calls.length;
  for(let i=0;i<3;i++){await f.page.locator('#cli-novo').click();await f.page.locator('#cli-agendar-dialog').waitFor();assert((await f.page.locator('#cli-agendar-servico-resumo').textContent()).includes('Psicoterapia'));await f.page.locator('#cli-dialog-fechar').click();}
  assert.equal(f.calls.length,before,'Opening with a default must not call any API');
  await f.page.locator('#cli-novo').click();await f.page.locator('#cli-agendar-servico-alterar').click();assert.equal(f.options(),1);await f.page.locator('#cli-agendar-servico').selectOption('20');await f.page.locator('#cli-agendar-servico-habitual').click();
  await f.page.getByText('Serviço habitual definido para sua agenda.',{exact:true}).waitFor();await f.page.locator('#cli-dialog-fechar').click();before=f.calls.length;await f.page.locator('#cli-novo').click();await f.page.locator('#cli-agendar-dialog').waitFor();assert.equal(f.calls.length,before);assert((await f.page.locator('#cli-agendar-servico-resumo').textContent()).includes('Registro simplificado'));
  await f.page.locator('#cli-agendar-servico-alterar').click();assert.equal(f.options(),1,'Options must be reused');
  await f.page.locator('#cli-agendar-servico-limpar').click();await f.page.locator('#cli-dialog-fechar').click();await f.page.locator('#cli-novo').click();await f.page.locator('#cli-agendar-dialog').waitFor();assert(await f.page.locator('#cli-agendar-confirmar').isDisabled());assert.equal(f.options(),1);
  await f.page.locator('#cli-agendar-servico').selectOption('20');await f.page.locator('#cli-agendar-confirmar').click();await f.page.waitForFunction(()=>document.querySelector('#cli-paciente')?.textContent==='Paciente fictício');
  assert.equal(f.writes[0].servicoId,20);assert.equal(f.writes[0].modeloConsulta,2);assert.equal(f.writes[0].versaoModeloConsulta,1);
  await f.page.waitForFunction(()=>!document.querySelector('#cli-iniciar').disabled);await f.page.evaluate(t=>localStorage.setItem('token',t),token(9));before=f.calls.length;await f.page.locator('#cli-novo').click();await f.page.getByText('O usuário ou a clínica mudou. Reabra o painel para continuar.',{exact:true}).waitFor();assert(await f.page.locator('#cli-agendar-dialog').isHidden());assert.equal(f.calls.length,before);assert.equal(f.errors.length,0);await f.context.close();cases.push('habitual: zero reads; options reused; snapshot sent; actor isolation');

  f=await fixture({habitual:null,catalog:[services[0]]});await f.page.locator('#cli-novo').click();await f.page.locator('#cli-agendar-dialog').waitFor();assert.equal(f.options(),1);assert(await f.page.locator('#cli-agendar-servico-lista').isHidden());assert(!(await f.page.locator('#cli-agendar-confirmar').isDisabled()));await f.page.locator('#cli-dialog-fechar').click();await f.page.locator('#cli-novo').click();await f.page.locator('#cli-agendar-dialog').waitFor();assert.equal(f.options(),1);await f.context.close();cases.push('single service: automatic selection, one options read');
  f=await fixture({habitual:null});await f.page.locator('#cli-novo').click();await f.page.locator('#cli-agendar-dialog').waitFor();assert(await f.page.locator('#cli-agendar-confirmar').isDisabled());assert(await f.page.locator('#cli-agendar-servico-lista').isVisible());await f.context.close();cases.push('multiple without habitual: explicit service choice');
  f=await fixture({habitual:null,catalog:[]});await f.page.locator('#cli-novo').click();await f.page.locator('#cli-agendar-dialog').waitFor();assert((await f.page.locator('#cli-agendar-servico-resumo').textContent()).includes('Cadastre um serviço'));assert(await f.page.locator('#cli-agendar-confirmar').isDisabled());await f.context.close();cases.push('empty catalog: guided and no invalid confirmation');

  f=await fixture();await f.page.locator('#cli-agenda-lista [data-id="42"]').click();await f.page.locator('#cli-prontuario').waitFor();assert(await f.page.locator('#cli-modelo-completo').isHidden());assert(await f.page.locator('#cli-plano-details').isHidden());assert.equal(await f.page.locator('[data-field]:visible').count(),2);assert((await f.page.locator('#cli-modelo').textContent()).includes('Registro simplificado'));
  await f.page.locator('#cli-prontuario').fill('Anotação humana preservada.');await f.page.locator('#cli-salvar').click();await f.page.getByText(/^Salvo às/).waitFor();await f.page.locator('#cli-prontuario').evaluate(e=>{window.originalEditor=e;e.focus();e.setSelectionRange(2,8);});
  await f.page.locator('#cli-atualizar').dispatchEvent('click');await f.page.getByText('Agenda e processamento consultados. Suas anotações foram preservadas.',{exact:true}).waitFor();assert.deepEqual(await f.page.locator('#cli-prontuario').evaluate(e=>[e===window.originalEditor,e.selectionStart,e.selectionEnd]),[true,2,8]);assert.equal(await f.page.locator('#cli-prontuario').inputValue(),'Anotação humana preservada.');
  await f.page.locator('[data-adopt="55"]').click();await f.page.getByText('Sugestão acrescentada ao rascunho. Revise antes de finalizar.',{exact:true}).waitFor();assert((await f.page.locator('#cli-prontuario').inputValue()).includes('Sugestão documental'));assert.equal(f.writes.at(-1).registroDocumental,'');assert.equal(f.writes.at(-1).queixaPrincipal,'');
  await f.page.locator('#cli-finalidade').selectOption('relato');await f.page.locator('#cli-gravar').click();await f.page.getByText('● Gravando',{exact:true}).waitFor();before=f.calls.filter(x=>x.includes('ConsultarAtendimentos')).length;
  await f.page.waitForTimeout(11000);assert(f.uploads.some(x=>!x.final),'Must stream while recording');await f.page.locator('#cli-pausar').click();await f.page.locator('#cli-pausar').click();await f.page.locator('#cli-parar').click();await f.page.getByText('Áudio recebido · processando',{exact:true}).waitFor();assert(f.uploads.at(-1).final);assert.equal(f.calls.filter(x=>x.includes('ConsultarAtendimentos')).length,before,'Capture must not refresh projections');
  await f.page.locator('#cli-encerrar').click();await f.page.locator('#cli-revisado').waitFor();await f.page.locator('#cli-finalizar').click();await f.page.getByText('Confirme a revisão do registro antes de finalizar.',{exact:true}).waitFor();assert.equal(f.calls.filter(x=>x.includes('FinalizarRegistro')).length,0);await f.page.locator('#cli-revisado').check();await f.page.locator('#cli-finalizar').click();await f.page.getByText('Registro revisado',{exact:true}).waitFor();
  await f.page.setViewportSize({width:390,height:844});await f.page.locator('#cli-proxima').click();assert(await f.page.evaluate(()=>document.documentElement.scrollWidth<=innerWidth+1));
  fs.mkdirSync(path.join(__dirname,'artifacts'),{recursive:true});await f.page.screenshot({path:path.join(__dirname,'artifacts/appointment-models-mobile.png'),fullPage:true});assert.equal(f.errors.length,0,f.errors.join('\n'));await f.context.close();cases.push('simple model: snapshot, two fields, human review, AI adoption, recording, stable refresh, mobile');
  f=await fixture({current:{...session(),modeloConsulta:1,servicoId:10,servicoNome:services[0].nome}});await f.page.locator('#cli-agenda-lista [data-id="42"]').click();assert(!(await f.page.locator('#cli-modelo-completo').evaluate(e=>e.hidden)));assert(!(await f.page.locator('#cli-plano-details').evaluate(e=>e.hidden)));await f.context.close();cases.push('complete psychology form remains available');
  console.log(JSON.stringify({passed:true,cases}));
 }finally{if(browser)await browser.close();await new Promise(resolve=>server.close(resolve));}
})().catch(e=>{console.error(e.stack||e.message);process.exitCode=1;});
