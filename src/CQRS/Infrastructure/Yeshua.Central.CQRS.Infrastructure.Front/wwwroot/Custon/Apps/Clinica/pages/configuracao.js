const escape=value=>String(value??'').replace(/[&<>"']/g,c=>({'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;',"'":'&#39;'}[c]));
const titles=['Sua clínica','Seu profissional','Serviço e modelo'];

export class ClinicSetup{
    constructor(host,post,finished,signal){this.host=host;this.post=post;this.finished=finished;this.signal=signal;this.dirty=false;this.busy=false;}
    async refresh(){
        if(this.busy)return;
        this.busy=true;
        try{
            const data=await this.post('/Clinica/ConfiguracaoAbrirConfiguracaoClinicaUseCase',{});
            if(this.signal.aborted)return;
            if(data.concluida){this.dirty=false;await this.finished();return;}
            if(this.data?.sagaStepId===data.sagaStepId){this.message('Progresso consultado. Os dados desta etapa foram preservados.');return;}
            this.data=data;this.render();
        }catch(e){
            if(this.signal.aborted)return;
            if(!this.host.firstElementChild)this.host.innerHTML='<div class="cli-card"><h2>Configuração inicial</h2><p data-config-message role="alert"></p><p>Se você faz parte de uma equipe, peça ao administrador da clínica para liberar seu vínculo de profissional.</p></div>';
            this.message(e.status===403?'Seu acesso ao Clínica está ativo. A configuração precisa ser feita por um administrador autorizado.':e.message,true);
        }finally{this.busy=false;}
    }
    message(text,error=false){const el=this.host.querySelector('[data-config-message]');if(el){el.textContent=text;el.dataset.error=String(error);}}
    render(){
        const d=this.data,step=d.etapa;
        this.host.innerHTML=`<section class="cli-card cli-setup" aria-labelledby="cli-setup-title" data-help-title="Configuração inicial da clínica"><span class="cli-eyebrow">VAMOS PREPARAR SUA AGENDA</span><h2 id="cli-setup-title">Configure sua clínica</h2><p>Confirme os dados para começar a atender. Cada etapa fica salva e pode ser retomada depois.</p><ol class="cli-setup-steps">${titles.map((t,i)=>`<li aria-current="${i+1===step?'step':'false'}" data-completed="${i+1<step}">${i+1<step?'✓':i+1} · ${t}</li>`).join('')}</ol><form><h3>${escape(titles[step-1])}</h3><div data-config-fields></div><p data-config-message role="status" aria-live="polite"></p><button type="submit" class="cli-primary">${step===3?'Concluir e abrir minha agenda':'Confirmar e continuar'}</button></form><p class="cli-muted">Nesta versão, a clínica atende Psicologia. Especialidade e grupo de serviços são opcionais e podem ser organizados nos cadastros depois.</p></section>`;
        const form=this.host.querySelector('form');
        form.addEventListener('input',()=>this.dirty=true,{signal:this.signal});
        form.addEventListener('submit',e=>{e.preventDefault();this.submit();},{signal:this.signal});
        this.renderFields();
    }
    renderFields(){
        const d=this.data,step=d.etapa,list=step===1?d.clinicas:step===2?d.profissionais:d.servicos;
        const linked=step===2?list.find(x=>x.vinculado):null;
        const selected=linked?.id||(list.length===1?list[0].id:0);
        const fields=this.host.querySelector('[data-config-fields]');
        fields.innerHTML=`${list.length?`<label>${step===1?'Clínica':step===2?'Profissional vinculado a este acesso':'Serviço habitual'}<select name="cadastro">${list.map(x=>`<option value="${x.id}">${escape(x.nome)}${x.vinculado?' · seu vínculo atual':''}</option>`).join('')}<option value="0">Cadastrar ${step===1?'nova clínica':step===2?'novo profissional':'novo serviço'}</option></select></label>`:'<input type="hidden" name="cadastro" value="0">'}<div data-config-new><label>${step===3?'Nome do serviço':'Nome'}<input name="nome" maxlength="150" required autocomplete="off"></label>${step===1?'<label>Endereço<input name="endereco" maxlength="250" required autocomplete="street-address"></label>':''}${step<3?'<label>Telefone<input name="telefone" type="tel" maxlength="20" required autocomplete="tel"></label>':'<label>Valor por consulta (R$)<input name="valor" type="number" min="0" max="99999999.99" step="0.01" value="0" required></label>'}</div>${step===1?'<label>Como você atende?<select name="estrutura"><option value="1">Individual</option><option value="2">Com equipe</option></select></label><p class="cli-muted">Você poderá cadastrar outros profissionais depois. Seu usuário será vinculado ao profissional confirmado na próxima etapa.</p>':step===2?'<p class="cli-muted">Escolha seu cadastro profissional ou crie um novo. A confirmação vincula somente o seu usuário nesta clínica.</p>':'<label>Modelo da consulta<select name="modelo"><option value="1">Psicologia completa</option><option value="2">Registro simplificado</option></select></label><p data-config-model class="cli-muted"></p>'}`;
        const input=fields.querySelector('[name="cadastro"]');input.value=String(selected);
        const sync=()=>{
            const item=list.find(x=>x.id===Number(input.value)),isNew=!item;
            fields.querySelector('[data-config-new]').hidden=!isNew;
            fields.querySelectorAll('[data-config-new] input').forEach(el=>el.disabled=!isNew);
            if(step===1)fields.querySelector('[name="estrutura"]').value=String(item?.tipoEstrutura||1);
            if(step===3){const model=fields.querySelector('[name="modelo"]');model.disabled=Boolean(item);model.value=String(item?.modeloConsulta||1);}
            this.modelHint();
        };
        input.addEventListener('change',sync,{signal:this.signal});
        fields.querySelector('[name="modelo"]')?.addEventListener('change',()=>this.modelHint(),{signal:this.signal});sync();
    }
    modelHint(){const el=this.host.querySelector('[data-config-model]');if(el)el.textContent=this.host.querySelector('[name="modelo"]').value==='2'?'Dois campos: registro da sessão e próximos passos.':'Evolução, queixa principal, registro documental e plano terapêutico.';}
    async submit(){
        if(this.busy)return;
        const form=this.host.querySelector('form');if(!form.reportValidity())return;
        const value=name=>form.querySelector(`[name="${name}"]`)?.value||'';
        const d=this.data,step=d.etapa,body={sagaId:d.sagaId,sagaStepId:d.sagaStepId,nome:value('nome').trim()};
        if(step===1)Object.assign(body,{clinicaId:Number(value('cadastro')),endereco:value('endereco').trim(),telefone:value('telefone').trim(),tipoEstrutura:Number(value('estrutura'))});
        else if(step===2)Object.assign(body,{profissionalId:Number(value('cadastro')),telefone:value('telefone').trim()});
        else Object.assign(body,{servicoId:Number(value('cadastro')),valor:Number(value('valor')),modeloConsulta:Number(value('modelo'))});
        const button=form.querySelector('[type="submit"]');this.busy=true;button.disabled=true;this.message('Salvando esta etapa…');
        try{
            await this.post('/Clinica/Configuracao'+['ConfirmarEstabelecimentoClinica','ConfirmarProfissionalClinica','ConfirmarServicoClinica'][step-1]+'UseCase',body);
            if(this.signal.aborted)return;
            this.dirty=false;this.busy=false;await this.refresh();
        }catch(e){if(!this.signal.aborted)this.message(e.message,true);}
        finally{this.busy=false;if(button.isConnected)button.disabled=false;}
    }
}
