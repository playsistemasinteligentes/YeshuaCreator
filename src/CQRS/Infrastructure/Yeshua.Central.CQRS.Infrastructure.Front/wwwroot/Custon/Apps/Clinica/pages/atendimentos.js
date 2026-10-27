import { apiFetch } from '/spa/scripts/ServicesGlobal/apiFetch.js?v=20260919-parametros01';
import { SessionRecorder } from '/spa/scripts/components/recording/session-recorder.js?v=20261027-clinica01';

const assets='/Custon/Apps/Clinica/pages',version='20261027-clinica01';
const fields=['prontuario','queixaPrincipal','registroDocumental','objetivosCurtoPrazo','objetivosLongoPrazo','exerciciosTarefasSugeridas','encaminhamentoOutrosProfissionais','frequenciaSugeridaSessooes','informacoesRelevantesFuturasConsultas'];
const escape=value=>String(value??'').replace(/[&<>"']/g,c=>({'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;',"'":'&#39;'}[c]));
const normalize=value=>Array.isArray(value)?value.map(normalize):value&&typeof value==='object'?Object.fromEntries(Object.entries(value).map(([k,v])=>[k[0].toLowerCase()+k.slice(1),normalize(v)])):value;
const day=value=>new Intl.DateTimeFormat('sv-SE',{timeZone:'America/Sao_Paulo'}).format(value||new Date());
const date=value=>value?new Date(value).toLocaleDateString('pt-BR',{timeZone:'America/Sao_Paulo'}):'';
const time=value=>value?new Date(value).toLocaleTimeString('pt-BR',{hour:'2-digit',minute:'2-digit',timeZone:'America/Sao_Paulo'}):'';
let active;

export async function renderClinicaAtendimentos(){
    if(active?.hasWork()){active.feedback('Conclua o envio do áudio e salve o registro antes de reabrir o painel.',true);return;}
    active?.dispose();
    if(!document.getElementById('crud-container')){
        const response=await fetch('/spa/views/dashboard.html');document.getElementById('app').innerHTML=await response.text();
        const menu=await import('/spa/scripts/menu.js?v=20260926-userarea01'),crud=await import('/spa/scripts/crud.js?v=20260926-userarea01'),apps=await import('/spa/scripts/application-context.js'),user=await import('/spa/scripts/user-area.js');
        apps.bindApplicationSelector();user.bindUserArea();crud.buildCrud();menu.buildMenu();await menu.loadDataMenu();
    }
    let host=document.getElementById('custom-page-container');
    if(!host){host=document.createElement('div');host.id='custom-page-container';document.getElementById('crud-container').parentElement.append(host);}
    const response=await fetch(`${assets}/atendimentos.html?v=${version}`);if(!response.ok)throw new Error('Não foi possível abrir o painel.');
    host.innerHTML=await response.text();host.classList.remove('hidden');document.getElementById('crud-container').style.display='none';
    if(!document.getElementById('cli-styles')){const css=document.createElement('link');css.id='cli-styles';css.rel='stylesheet';css.href=`${assets}/atendimentos.css?v=${version}`;document.head.append(css);}
    active=new ClinicPanel(host);await active.initialize();
}

class ClinicPanel{
    constructor(host){
        this.host=host;this.controller=new AbortController();this.mode='preparar';this.dirty=false;this.edits=0;this.current=null;this.data=null;this.savePromise=null;this.busy=false;
        this.apiBase=environments.urlApi.replace(/\/$/,'');
        const encoded=localStorage.getItem('token').split('.')[1].replace(/-/g,'+').replace(/_/g,'/'),p=JSON.parse(atob(encoded));
        this.actor=[p.tenantId||p.tenantID||p.TenantID,p.userId||p.id||p.sub||p.nameid||p['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier']].join(':');
        if(!this.actor||this.actor===':')throw new Error('Não foi possível identificar o usuário. Entre novamente.');
        this.observer=new MutationObserver(()=>{if(!host.isConnected||!host.firstElementChild||host.classList.contains('hidden'))this.dispose();});
        this.observer.observe(host,{childList:true,attributes:true,attributeFilter:['class']});this.observer.observe(host.parentElement,{childList:true});
        window.addEventListener('beforeunload',e=>{if(this.hasWork()){e.preventDefault();e.returnValue='';}},{signal:this.controller.signal});
        window.addEventListener('focus',()=>this.refreshResults().catch(()=>{}),{signal:this.controller.signal});this.bind();
    }
    el(id){return this.host.querySelector('#cli-'+id);}
    text(id,value){this.el(id).textContent=value;}
    show(id,visible){this.el(id).hidden=!visible;}
    hasWork(){return this.dirty||Boolean(this.recorder?.active||this.recorder?.pending);}
    feedback(message,error=false){if(this.disposed)return;this.text('feedback',message);this.el('feedback').dataset.error=String(error);}
    async run(action){if(this.busy)return;this.busy=true;this.controls();try{await action();}catch(e){this.feedback(e.message,true);}finally{this.busy=false;this.controls();}}
    async request(name,body){return this.post('/Clinica/Atendimentos'+name+'UseCase',body);}
    async post(path,body){
        if(environments.urlApi.replace(/\/$/,'')!==this.apiBase)throw new Error('O aplicativo ativo mudou. Volte ao Clínica para continuar.');
        const response=await apiFetch(this.apiBase+path,{method:'POST',headers:{'Content-Type':'application/json'},body:JSON.stringify(body)}),payload=normalize(await response.json().catch(()=>({})));
        if(!response.ok||payload.statusCode>=400){const e=new Error(payload.message||payload.mensagem||'Não foi possível concluir esta ação.');e.status=response.status;throw e;}
        return payload.data??payload;
    }
    bind(){
        const on=(id,fn)=>this.el(id).addEventListener('click',()=>this.run(fn),{signal:this.controller.signal});
        on('atualizar',async()=>{if(this.hasWork())throw new Error('Salve o registro e conclua o áudio antes de atualizar.');await this.load(this.current?.id||0);});
        on('discreto',async()=>{const enabled=this.el('discreto').closest('.cli-panel').classList.toggle('cli-discreet');this.text('discreto',enabled?'Mostrar dados':'Ocultar dados');});
        this.el('data').addEventListener('change',()=>this.run(async()=>{await this.leaveCurrent();await this.load(0);}),{signal:this.controller.signal});
        this.host.querySelectorAll('[data-mode]').forEach(b=>b.addEventListener('click',()=>this.setMode(b.dataset.mode),{signal:this.controller.signal}));
        this.host.querySelectorAll('[data-support]').forEach(button=>button.addEventListener('click',()=>{this.show('plano-anterior',button.dataset.support==='plano');this.show('historico',button.dataset.support==='historico');this.host.querySelectorAll('[data-support]').forEach(b=>b.setAttribute('aria-selected',String(b===button)));},{signal:this.controller.signal}));
        this.host.querySelectorAll('[data-field]').forEach(input=>input.addEventListener('input',()=>{this.dirty=true;this.edits++;this.text('save-status','Alterações por salvar');clearTimeout(this.saveTimer);if(!this.isFinal())this.saveTimer=setTimeout(()=>this.save().catch(e=>this.feedback(e.message,true)),1800);},{signal:this.controller.signal}));
        on('novo',async()=>{await this.leaveCurrent();this.openSchedule();});on('proxima',async()=>{await this.leaveCurrent();this.openSchedule(this.current?.pacienteId);});on('dialog-fechar',async()=>this.el('agendar-dialog').close());
        this.el('agendar-form').addEventListener('submit',e=>{e.preventDefault();this.run(()=>this.schedule());},{signal:this.controller.signal});
        on('iniciar',()=>this.transition('IniciarAtendimento','atender'));
        on('encerrar',async()=>{this.requireAudioDone();await this.save();await this.transition('EncerrarAtendimento','fechar');});
        on('cancelar',()=>this.transition('CancelarAtendimento','preparar'));on('falta',()=>this.transition('RegistrarFalta','preparar'));on('salvar',()=>this.save());on('finalizar',()=>this.finalize());
        on('corrigir',async()=>{this.correcting=true;this.el('revisado').checked=false;this.setMode('fechar');this.feedback('Descreva o motivo e revise a correção. A versão anterior será preservada.');});
        on('gravar',async()=>{if(this.el('finalidade').value==='consulta'&&!this.el('consent').checked)throw new Error('Confirme a autorização do paciente antes de gravar a conversa.');await this.recorder.start({finalidade:this.el('finalidade').value,autorizado:this.el('consent').checked});});
        on('pausar',async()=>this.recorder.state==='paused'?this.recorder.resume():this.recorder.pause());on('parar',async()=>{await this.recorder.stop();await this.refreshResults();});
        on('reenviar',async()=>{await this.recorder.flush();await this.refreshResults();});
        on('baixar',async()=>{const blob=await this.recorder.downloadPending(),url=URL.createObjectURL(blob),a=document.createElement('a');a.href=url;a.download=`audio-atendimento-${this.current.id}.webm`;a.click();setTimeout(()=>URL.revokeObjectURL(url),1000);});
        this.el('finalidade').addEventListener('change',()=>this.show('consent-label',this.el('finalidade').value==='consulta'),{signal:this.controller.signal});
        this.el('audios').addEventListener('click',e=>{const b=e.target.closest('[data-adopt],[data-retry]');if(b)this.run(()=>b.dataset.adopt?this.adopt(Number(b.dataset.adopt)):this.retry(Number(b.dataset.retry),Number(b.dataset.step)));},{signal:this.controller.signal});
    }
    async initialize(){this.el('data').value=day();await this.load(0);this.poll=setInterval(()=>this.refreshResults().catch(()=>{}),7000);}
    async load(id){
        const data=await this.request('ConsultarAtendimentos',{data:this.el('data').value,sessaoId:id});if(this.disposed)return;
        this.data=data;this.current=data.atual[0]||null;this.correcting=false;this.dirty=false;this.edits=0;this.incorporarSagaId=0;
        this.text('profissional',data.profissionalNome+' · Agenda e continuidade do cuidado');this.renderAgenda();this.renderPatient();this.show('vazio',!this.current);this.show('consulta',Boolean(this.current));
        if(this.current){fields.forEach(f=>this.el(f).value=this.current[f]||'');this.el('revisado').checked=false;this.el('motivo').value='';this.renderHistory();this.renderAudios();await this.setupRecorder();this.setMode(this.isFinal()||this.current.atendimentoEncerradoEm?'fechar':this.current.atendimentoIniciadoEm?'atender':'preparar');}this.controls();
    }
    renderAgenda(){
        const list=this.data.agenda.filter(x=>day(new Date(x.dataInicio))===this.el('data').value),pending=this.data.agenda.filter(x=>x.pendente);
        this.text('contagem',`${list.length} consulta${list.length===1?'':'s'} · horário de São Paulo`);
        const item=s=>`<button class="cli-agenda-item" data-id="${s.id}" aria-current="${this.current?.id===s.id}"><span class="cli-agenda-time">${escape(date(s.dataInicio))} · ${escape(time(s.dataInicio))}</span><strong>${escape(s.paciente)}</strong><small>${escape(this.visitName(s))} · ${s.statusProntuario===3?'Registro concluído':'Registro pendente'}</small></button>`;
        this.el('agenda-lista').innerHTML=list.length?list.map(item).join(''):'<p class="cli-muted">Nenhuma consulta neste dia.</p>';this.el('pendencias').innerHTML=pending.length?pending.map(item).join(''):'<p class="cli-muted">Nenhum registro pendente.</p>';
        this.host.querySelectorAll('.cli-agenda-item').forEach(b=>b.onclick=()=>this.run(async()=>{await this.leaveCurrent();await this.load(Number(b.dataset.id));}));
    }
    visitName(s){return s.statusProntuario===1?'Não compareceu':s.statusAgendamento===3?'Cancelada':s.statusAgendamento===2?'Atendimento encerrado':s.atendimentoIniciadoEm?'Em atendimento':'Agendada';}
    renderPatient(){
        const s=this.current;if(!s)return;this.text('paciente',s.paciente);this.text('horario',`${date(s.dataInicio)} · ${time(s.dataInicio)} — ${time(s.dataFim)}`);
        let age='';if(s.dataNascimento){const born=new Date(s.dataNascimento),today=new Date();let years=today.getFullYear()-born.getFullYear();if(today.getMonth()<born.getMonth()||(today.getMonth()===born.getMonth()&&today.getDate()<born.getDate()))years--;age=years+' anos · ';}
        this.text('paciente-info',age+`Consulta #${s.id} · Versão ${s.versao}`);this.text('status',this.visitName(s));this.text('registro-status',s.registroFinalizadoEm?'Registro revisado':s.statusProntuario===3?'Registro legado concluído':s.statusProntuario===1?'Não compareceu':s.statusAgendamento===3?'Sem atendimento':'Registro em aberto');
        this.text('finalizado-em',s.registroFinalizadoEm?`Última revisão em ${date(s.registroFinalizadoEm)} às ${time(s.registroFinalizadoEm)}. Versões anteriores preservadas.`:s.statusProntuario===3?'Registro anterior a este painel. Não há identificação de revisão humana nesta versão.':'');
    }
    renderHistory(){
        const history=this.data.historico,previous=history.find(s=>Boolean(s.registroFinalizadoEm)),legacy=history.find(s=>s.statusProntuario===3),source=previous||legacy;
        this.el('retomada').innerHTML=source?`<span class="cli-source">Consulta de ${escape(date(source.dataInicio))}${previous?' · registro revisado':' · registro legado'}</span><h3>Retomar hoje</h3><p class="cli-retomar-text">${escape(source.informacoesRelevantesFuturasConsultas||'Nenhum lembrete registrado para este encontro.')}</p><h3>Evolução anterior</h3><p class="cli-retomar-text">${escape(source.prontuario||'Sem registro anterior.')}</p>`:'<p>Primeiro atendimento registrado com este profissional. Prepare o acolhimento e os objetivos deste encontro.</p>';
        this.el('plano-anterior').innerHTML=source?`<span class="cli-source">Origem: consulta #${source.id} · ${escape(date(source.dataInicio))}${previous?' · revisado':' · legado'}</span>`+[['Curto prazo','objetivosCurtoPrazo'],['Longo prazo','objetivosLongoPrazo'],['Tarefas combinadas','exerciciosTarefasSugeridas'],['Encaminhamentos','encaminhamentoOutrosProfissionais'],['Frequência','frequenciaSugeridaSessooes']].map(([title,key])=>`<div><h3>${title}</h3><p>${escape(source[key]||'Não registrado.')}</p></div>`).join(''):'<p class="cli-muted">Ainda não há plano de uma consulta concluída.</p>';
        this.el('historico').innerHTML=history.length?history.map(s=>`<details class="cli-history-entry"><summary>${escape(date(s.dataInicio))} · ${s.registroFinalizadoEm?'Revisado':s.statusProntuario===3?'Legado concluído':'Registro pendente'}</summary><h3>Prontuário</h3><p>${escape(s.prontuario||'Não registrado.')}</p><h3>Plano / tarefas</h3><p>${escape(s.objetivosCurtoPrazo)}\n${escape(s.exerciciosTarefasSugeridas)}</p><h3>Retomar</h3><p>${escape(s.informacoesRelevantesFuturasConsultas)}</p></details>`).join(''):'<p class="cli-muted">Nenhuma consulta anterior.</p>';
    }
    setMode(mode){
        if(!this.current)return;this.mode=mode;this.host.querySelectorAll('[data-mode]').forEach(b=>b.setAttribute('aria-selected',String(b.dataset.mode===mode)));
        this.show('preparar',mode==='preparar');this.show('gravacao',mode==='atender'||Boolean(this.recorder?.active||this.recorder?.pending));this.show('editor',mode!=='preparar');this.show('ia',mode!=='preparar');this.show('finalizacao',mode==='fechar');
        this.el('plano-details').open=mode==='fechar';this.el('registroDocumental').closest('details').open=mode==='fechar';this.text('editor-titulo',mode==='fechar'?'Revisar e concluir':'Durante a consulta');this.controls();
    }
    isFinal(){return Boolean(this.current?.registroFinalizadoEm||this.current?.statusProntuario===3);}
    controls(){
        const s=this.current;if(!s)return;const started=Boolean(s.atendimentoIniciadoEm)||s.statusAgendamento===2,ended=Boolean(s.atendimentoEncerradoEm)||s.statusAgendamento===2,final=this.isFinal(),capturing=Boolean(this.recorder?.active),pending=Boolean(this.recorder?.pending),editable=(started&&!final)||this.correcting;
        for(const id of ['iniciar','cancelar','falta'])this.el(id).disabled=this.busy||started||final||![0,1].includes(s.statusAgendamento);
        this.host.querySelectorAll('[data-field]').forEach(input=>input.disabled=!editable||this.busy);this.el('salvar').disabled=this.busy||!editable||this.correcting;this.el('encerrar').disabled=this.busy||!started||ended||final||capturing||pending;this.el('gravar').disabled=this.busy||!started||ended||final||capturing||pending;
        this.el('finalidade').disabled=capturing||pending;this.el('consent').disabled=capturing||pending;this.el('finalizar').disabled=this.busy||(!ended&&!this.correcting)||capturing||pending||(final&&!this.correcting);this.text('finalizar',this.correcting?'Salvar correção revisada':'Finalizar registro');this.show('corrigir',final&&!this.correcting);this.show('correcao-box',this.correcting);
        this.show('pausar',['recording','paused'].includes(this.recorder?.state));this.show('parar',['recording','paused'].includes(this.recorder?.state));this.show('reenviar',pending&&!capturing);this.show('baixar',pending&&!capturing);this.text('pausar',this.recorder?.state==='paused'?'Retomar gravação':'Pausar');
    }
    requireAudioDone(){if(this.recorder?.active||this.recorder?.pending)throw new Error('Pare a gravação e confirme o envio do áudio antes de encerrar ou finalizar.');}
    async leaveCurrent(){this.requireAudioDone();if(this.correcting&&this.dirty)throw new Error('Conclua a correção antes de trocar de consulta.');await this.save();}
    recordPayload(){const result={sessaoId:this.current.id,versao:this.current.versao,revisado:this.el('revisado').checked,motivo:this.el('motivo').value,incorporarSagaId:this.incorporarSagaId||0};fields.forEach(f=>result[f]=this.el(f).value);return result;}
    async save(){
        clearTimeout(this.saveTimer);if(this.savePromise)await this.savePromise;if(!this.dirty||this.correcting||!this.current)return;const edit=this.edits,payload=this.recordPayload();this.text('save-status','Salvando…');
        this.savePromise=(async()=>{try{const result=await this.request('SalvarRegistro',payload);this.current.versao=result.versao;this.incorporarSagaId=0;this.dirty=this.edits!==edit;this.text('save-status',this.dirty?'Alterações por salvar':'Salvo às '+new Date().toLocaleTimeString('pt-BR',{hour:'2-digit',minute:'2-digit'}));this.renderPatient();}catch(e){this.text('save-status','Falha ao salvar · texto mantido nesta tela');throw e;}finally{this.savePromise=null;}})();
        await this.savePromise;if(this.dirty)this.saveTimer=setTimeout(()=>this.save().catch(e=>this.feedback(e.message,true)),1800);
    }
    async transition(command,next){await this.save();const result=await this.request(command,{sessaoId:this.current.id,versao:this.current.versao});this.current.versao=result.versao;await this.load(this.current.id);this.setMode(next);this.feedback(command==='EncerrarAtendimento'?'Atendimento encerrado. Revise e finalize o registro quando estiver pronto.':'Atendimento atualizado.');}
    async finalize(){this.requireAudioDone();if(!this.el('revisado').checked)throw new Error('Confirme a revisão do registro antes de finalizar.');await this.save();const result=await this.request(this.correcting?'CorrigirRegistro':'FinalizarRegistro',this.recordPayload());this.dirty=false;this.current.versao=result.versao;await this.load(this.current.id);this.setMode('fechar');this.feedback('Registro revisado e salvo. A versão foi preservada no histórico de revisões.');}
    openSchedule(patient=0){
        this.el('agendar-paciente').innerHTML=this.data.pacientes.map(p=>`<option value="${p.id}">${escape(p.nome)}</option>`).join('');if(patient)this.el('agendar-paciente').value=patient;
        const start=new Date();start.setDate(start.getDate()+7);start.setMinutes(0,0,0);const value=d=>new Date(d.getTime()-d.getTimezoneOffset()*60000).toISOString().slice(0,16);this.el('agendar-inicio').value=value(start);this.el('agendar-fim').value=value(new Date(start.getTime()+50*60000));this.text('agendar-erro','');this.el('agendar-dialog').showModal();
    }
    async schedule(){try{const start=new Date(this.el('agendar-inicio').value),end=new Date(this.el('agendar-fim').value),result=await this.request('AgendarAtendimento',{pacienteId:Number(this.el('agendar-paciente').value),dataInicio:start.toISOString(),dataFim:end.toISOString()});this.el('agendar-dialog').close();this.el('data').value=day(start);await this.load(result.sessaoId);this.feedback('Consulta agendada. Histórico e plano anterior já estão disponíveis.');}catch(e){this.text('agendar-erro',e.message);throw e;}}
    async setupRecorder(){
        this.recorder?.dispose();const sessionId=this.current.id;this.recorder=new SessionRecorder({actor:this.actor,sessionId,
            startSession:async options=>{const result=await this.post('/FileUpload/InfraStarSessionUploadUseCase',{entityType:'Sesoes',entityId:String(sessionId),...options});return result.uploadToken;},
            sendChunk:async(token,blob,index,final)=>{
                if(environments.urlApi.replace(/\/$/,'')!==this.apiBase)throw new Error('Volte ao Clínica para enviar o áudio.');
                const form=new FormData();form.append('fileStream',blob,`chunk_${index}.webm`);form.append('chunkIndex',String(index));form.append('isFinalChunk',String(final));form.append('token',token);form.append('fileName',`chunk_${index}.webm`);form.append('contentType','audio/webm');
                const response=await apiFetch(this.apiBase+'/FileUpload/InfraSendFileUseCase2',{method:'POST',body:form}),body=normalize(await response.json().catch(()=>({})));if(!response.ok)throw new Error(body.message||'Não foi possível enviar esta parte.');return body.data??body;
            },changed:status=>{
                if(this.disposed||this.current?.id!==sessionId)return;this.text('tempo',`${String(Math.floor(status.elapsed/60)).padStart(2,'0')}:${String(status.elapsed%60).padStart(2,'0')}`);
                this.text('captura-status',({idle:'Microfone desligado',starting:'Abrindo microfone…',recording:'● Gravando',paused:'Gravação pausada',stopping:'Concluindo captura…',uploading:'Enviando áudio…',completed:'Áudio recebido · processando',error:'Envio precisa de atenção'})[status.state]||status.state);
                if(status.error)this.feedback(status.error,true);if(status.state==='completed'){this.feedback('Áudio enviado. A transcrição e o resumo serão apresentados abaixo.');this.show('recuperar',false);this.refreshResults().catch(()=>{});}this.controls();
            }});
        const recoverable=await this.recorder.recoverable();this.show('recuperar',true);this.el('recuperar').innerHTML=recoverable.map(x=>`<p class="cli-alert">Existe áudio pendente desta consulta (${escape(date(x.created))}). <button data-recover="${escape(x.id)}">Recuperar e enviar</button></p>`).join('');
        this.el('recuperar').querySelectorAll('[data-recover]').forEach(b=>b.onclick=()=>this.run(()=>this.recorder.recover(b.dataset.recover)));if(recoverable.length)this.recorder.pending=recoverable[0];
    }
    async refreshResults(){
        if(this.disposed||!this.current||this.refreshing||this.busy)return;this.refreshing=true;
        try{const data=await this.request('ConsultarAtendimentos',{data:this.el('data').value,sessaoId:this.current.id});if(this.disposed)return;this.data.agenda=data.agenda;this.data.audios=data.audios;this.renderAgenda();this.renderAudios();if(data.atual[0].versao!==this.current.versao&&!this.savePromise)this.feedback('Este atendimento mudou em outra tela. Salve uma cópia do seu texto e atualize antes de continuar.',true);}finally{this.refreshing=false;}
    }
    renderAudios(){
        const audios=this.data.audios;this.el('audios').innerHTML=audios.length?audios.map(a=>`<article class="cli-audio-item"><div class="cli-row cli-between"><strong>Áudio #${a.sagaId} · ${escape(a.status)}</strong><span class="cli-source">${escape(date(a.data))} · ${escape(time(a.data))}</span></div>${a.transcricao?`<details><summary>Ver transcrição</summary><pre>${escape(a.transcricao)}</pre></details>`:'<p class="cli-muted">Aguardando transcrição…</p>'}${a.prontuario?`<details><summary>Revisar sugestão de resumo</summary><h3>Prontuário</h3><pre>${escape(a.prontuario)}</pre><h3>Queixa principal</h3><pre>${escape(a.queixaPrincipal)}</pre><h3>Registro documental</h3><pre>${escape(a.registroDocumental)}</pre></details><button data-adopt="${a.sagaId}" ${this.isFinal()?'disabled':''}>Acrescentar ao rascunho</button>`:''}${a.stepFalhouId?`<p class="cli-alert">O processamento falhou. Seu registro manual permanece disponível.</p><button data-retry="${a.sagaId}" data-step="${a.stepFalhouId}">Tentar processamento novamente</button>`:''}</article>`).join(''):'<p class="cli-muted">Nenhum áudio enviado. Você pode registrar e concluir esta consulta manualmente.</p>';
    }
    async adopt(id){
        if(this.isFinal())throw new Error('O registro está concluído.');await this.save();const audio=this.data.audios.find(a=>a.sagaId===id);if(!audio?.prontuario)throw new Error('Resumo ainda não disponível.');
        if((this.current.sugestoesIncorporadas||'').includes(`saga:${id};`))throw new Error('Esta sugestão já foi incorporada.');
        for(const key of ['prontuario','queixaPrincipal','registroDocumental']){const input=this.el(key),addition=audio[key];if(addition&&((input.value?input.value+'\n\n':'')+addition).length>input.maxLength)throw new Error('O resumo excede o espaço disponível. Copie apenas os trechos desejados.');}
        for(const key of ['prontuario','queixaPrincipal','registroDocumental'])if(audio[key])this.el(key).value+=(this.el(key).value?'\n\n':'')+audio[key];
        this.incorporarSagaId=id;this.dirty=true;this.edits++;await this.save();this.current.sugestoesIncorporadas+=`\nsaga:${id};`;this.feedback('Sugestão acrescentada ao rascunho. Revise antes de finalizar.');
    }
    async retry(sagaId,stepId){await this.post('/Saga/OperacaoRetrySagaStepUseCase',{sagaId,sagaStepId:stepId});this.feedback('Nova tentativa solicitada.');await this.refreshResults();}
    dispose(){if(this.disposed)return;this.disposed=true;clearInterval(this.poll);clearTimeout(this.saveTimer);this.recorder?.dispose();this.controller.abort();this.observer.disconnect();this.el('agendar-dialog')?.close();}
}
