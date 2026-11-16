import test from 'node:test';
import assert from 'node:assert/strict';
import { readFile } from 'node:fs/promises';
const base=new URL('../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/Custon/Apps/Clinica/pages/',import.meta.url);
const helper=await readFile(new URL('calendario-consultas.js',base),'utf8');
const panelSource=(await readFile(new URL('atendimentos.js',base),'utf8')).replace(/^import .*;\r?\n/gm,'');
// Exercise the actual panel methods with transport and DOM test doubles, without a browser or HTTP.
const {ClinicPanel,localSaoPaulo,instanteSaoPaulo}=await import('data:text/javascript;base64,'+Buffer.from(helper+'\n'+panelSource+'\nexport { ClinicPanel };').toString('base64'));
const preview={planoId:'a'.repeat(32),confirmado:false,ocorrencias:[
    {ordem:0,sessaoId:0,dataInicio:'2030-02-04T10:00',dataFim:'2030-02-04T10:50',agendar:true,conflito:false},
    {ordem:1,sessaoId:0,dataInicio:'2030-02-11T10:00',dataFim:'2030-02-11T10:50',agendar:true,conflito:true}
]};
function fixture(){
    const nodes=new Map();
    function el(id){if(!nodes.has(id))nodes.set(id,{value:'',checked:false,hidden:true,textContent:'',innerHTML:'',disabled:false,setAttribute(name,value){this[name]=value;},reportValidity:()=>true,close(){this.closed=true;},showModal(){this.open=true;}});return nodes.get(id);}
    const panel=Object.create(ClinicPanel.prototype);panel.el=el;panel.host={querySelectorAll:()=>[]};panel.controller=new AbortController();
    panel.renderPatients=()=>{};panel.toggleNewPatient=()=>{};panel.renderScheduleService=()=>{};panel.load=async id=>{panel.loaded=id;};panel.feedback=message=>{panel.message=message;};
    panel.scheduledService={id:5,nome:'Consulta',modeloConsulta:1,versaoModeloConsulta:1};
    panel.current=null;panel.data={pacientes:[{id:42,nome:'Paciente'}]};
    el('paciente-cadastro').hidden=true;el('agendar-paciente').value='42';el('agendar-inicio').value='2030-02-04T10:00';el('agendar-fim').value='2030-02-04T10:50';el('agendar-final').value='2030-02-18';el('agendar-recorrencia').value='7';
    const calls=[];panel.request=async(name,body)=>{calls.push({name,body:structuredClone(body)});return structuredClone(preview);};
    const decisions=preview.ocorrencias.map(x=>({...x}));
    const rows=decisions.map(x=>({hidden:false,dataset:{ocorrencia:String(x.ordem)},querySelector:selector=>selector==='[data-agendar]'?{get checked(){return x.agendar;}}:{get value(){return selector==='[data-inicio]'?x.dataInicio:x.dataFim;}}}));
    el('recorrencia-itens').querySelectorAll=()=>rows;
    return {panel,el,calls,decisions,rows};
}

test('São Paulo conversion is independent of the browser/device timezone',()=>{
    const before=process.env.TZ;
    try{for(const tz of ['UTC','Asia/Tokyo','America/Los_Angeles']){
        process.env.TZ=tz;
        assert.equal(instanteSaoPaulo('2030-02-04T10:00'),'2030-02-04T13:00:00.000Z');
        assert.equal(localSaoPaulo('2030-02-04T13:00:00Z'),'2030-02-04T10:00');
    }}finally{if(before===undefined)delete process.env.TZ;else process.env.TZ=before;}
});
test('historical DST uses timezone rules and rejects nonexistent local time',()=>{
    assert.equal(instanteSaoPaulo('2018-10-29T10:00'),'2018-10-29T13:00:00.000Z');
    assert.equal(instanteSaoPaulo('2018-11-12T10:00'),'2018-11-12T12:00:00.000Z');
    assert.throws(()=>instanteSaoPaulo('2018-11-04T00:30'),/inválido/);
});
test('requesting recurrence opens a per-occurrence preview and does not confirm automatically',async()=>{
    const {panel,el,calls}=fixture();await panel.schedule();
    assert.equal(calls.length,1);assert.equal(calls[0].name,'PreverRecorrenciaConsultas');
    assert.equal(calls[0].body.dataInicio,'2030-02-04T10:00');assert.equal(calls[0].body.intervaloDias,7);
    assert.equal(el('recorrencia-previa').hidden,false);assert.match(el('recorrencia-itens').innerHTML,/Conflito de horário/);
    assert.equal(el('recorrencia-revisado').checked,false);assert.equal(el('agendar-dialog').closed,undefined);
});
test('confirmation requires explicit human review',async()=>{
    const {panel,calls,decisions}=fixture();panel.recurrencePreview=structuredClone(preview);decisions[1].agendar=false;
    await assert.rejects(panel.confirmRecurrence(),/Revise/);assert.equal(calls.length,0);
});
test('human confirmation sends changed dates and skipped occurrences',async()=>{
    const {panel,el,calls,decisions}=fixture();panel.recurrencePreview=structuredClone(preview);el('recorrencia-revisado').checked=true;
    decisions[1].agendar=false;decisions[0].dataInicio='2030-02-05T10:00';decisions[0].dataFim='2030-02-05T10:50';
    panel.request=async(name,body)=>{calls.push({name,body});return {...preview,confirmado:true,ocorrencias:[{...body.ocorrencias[0],sessaoId:123}]};};
    await panel.confirmRecurrence();assert.equal(calls[0].name,'ConfirmarRecorrenciaConsultas');assert.equal(calls[0].body.revisado,true);
    assert.equal(calls[0].body.ocorrencias[1].agendar,false);assert.equal(calls[0].body.ocorrencias[0].dataInicio,'2030-02-05T10:00');
    assert.equal(panel.loaded,123);assert.equal(el('agendar-dialog').closed,true);
});
test('ambiguous network failure preserves preview and retries the same confirmation',async()=>{
    const {panel,el,calls,decisions}=fixture();panel.recurrencePreview=structuredClone(preview);decisions[1].agendar=false;el('recorrencia-revisado').checked=true;
    panel.request=async(name,body)=>{calls.push({name,body});throw new Error('offline');};
    await assert.rejects(panel.confirmRecurrence(),/offline/);await assert.rejects(panel.confirmRecurrence(),/offline/);
    assert.deepEqual(calls[0],calls[1]);assert.equal(el('agendar-dialog').closed,undefined);assert.equal(panel.recurrencePreview.planoId,preview.planoId);
});
test('ambiguous network outcome prevents changing the confirmation payload on retry',async()=>{
    const {panel,el,decisions}=fixture();panel.recurrencePreview=structuredClone(preview);decisions[1].dataInicio='2030-02-12T10:00';decisions[1].dataFim='2030-02-12T10:50';el('recorrencia-revisado').checked=true;
    panel.request=async()=>{throw new Error('offline');};await assert.rejects(panel.confirmRecurrence(),/offline/);
    decisions[0].agendar=false;await assert.rejects(panel.confirmRecurrence(),/mesmas escolhas/);
});
test('server conflict keeps editable preview so the operator can resolve the occurrence',async()=>{
    const {panel,el,decisions}=fixture();panel.recurrencePreview=structuredClone(preview);decisions[1].dataInicio='2030-02-12T10:00';decisions[1].dataFim='2030-02-12T10:50';el('recorrencia-revisado').checked=true;
    panel.request=async()=>{throw Object.assign(new Error('Conflito na ocorrência 2'),{status:409});};
    await assert.rejects(panel.confirmRecurrence(),/ocorrência 2/);assert.equal(panel.recurrenceConfirmation,null);assert(panel.recurrencePreview);
    assert.equal(panel.recurrenceTab,'todas');assert.equal(el('recorrencia-revisado').checked,false);
    decisions[1].agendar=false;el('recorrencia-revisado').checked=true;panel.request=async()=>({...preview,confirmado:true,ocorrencias:[]});await panel.confirmRecurrence();assert.equal(el('agendar-dialog').closed,true);
});
test('changing preview inputs invalidates the plan and human review',()=>{
    const {panel,el}=fixture();panel.recurrencePreview=structuredClone(preview);el('recorrencia-revisado').checked=true;
    panel.invalidateRecurrence();assert.equal(panel.recurrencePreview,null);assert.equal(el('recorrencia-revisado').checked,false);assert.equal(el('recorrencia-previa').hidden,true);
});
test('single-occurrence editing goes through preview and preserves its session identity',async()=>{
    const {panel,calls,el}=fixture();panel.editingSchedule={id:21};el('agendar-escopo').value='uma';el('agendar-recorrencia').value='0';
    await panel.schedule();assert.equal(calls[0].name,'PreverRecorrenciaConsultas');assert.equal(calls[0].body.sessaoId,21);assert.equal(calls[0].body.serieFutura,false);
});
test('future-series editing declares the chosen anchor explicitly',async()=>{
    const {panel,calls,el}=fixture();panel.editingSchedule={id:21};el('agendar-escopo').value='futuras';el('agendar-recorrencia').value='14';
    await panel.schedule();assert.equal(calls[0].body.sessaoId,21);assert.equal(calls[0].body.serieFutura,true);assert.equal(calls[0].body.intervaloDias,14);
});
test('ordinary scheduling still uses the existing command, with São Paulo time',async()=>{
    const {panel,calls,el}=fixture();el('agendar-recorrencia').value='0';panel.request=async(name,body)=>{calls.push({name,body});return {sessaoId:123};};
    await panel.schedule();assert.equal(calls[0].name,'AgendarAtendimento');assert.equal(calls[0].body.dataInicio,'2030-02-04T13:00:00.000Z');assert.equal(panel.loaded,123);
});
test('changing inputs while the preview request is in flight discards the stale response',async()=>{
    const {panel,el}=fixture();let resolve;panel.request=()=>new Promise(r=>{resolve=r;});
    const pending=panel.schedule();el('agendar-inicio').value='2030-02-05T10:00';panel.invalidateRecurrence();resolve(structuredClone(preview));
    await assert.rejects(pending,/mudou durante a prévia/);assert.equal(panel.recurrencePreview,null);assert.equal(el('recorrencia-previa').hidden,true);
});

test('summary is default and tabs preserve the same complete editable decisions',async()=>{
    const {panel,el,rows,decisions}=fixture();await panel.schedule();
    assert.equal(panel.recurrenceTab,'resumo');assert.equal(rows[0].hidden,true);assert.equal(rows[1].hidden,false);
    assert.match(el('recorrencia-resumo').textContent,/Semanal.*04\/02\/2030.*11\/02\/2030.*2 ocorrência/);
    assert.match(el('recorrencia-estado').textContent,/1 ocorrência.*pendente/);
    assert.equal(el('recorrencia-confirmar').disabled,true);
    panel.selectRecurrenceTab('todas');assert(rows.every(x=>!x.hidden));
    assert.equal(el('recorrencia-tab-todas')['aria-selected'],'true');
    decisions[0].dataInicio='2030-02-05T10:00';decisions[0].dataFim='2030-02-05T10:50';decisions[1].agendar=false;
    panel.selectRecurrenceTab('resumo');assert.equal(rows[0].hidden,true);assert.equal(rows[1].hidden,false);
    assert.equal(panel.recurrenceState().choices[0].dataInicio,'2030-02-05T10:00');
    panel.selectRecurrenceTab('todas');assert.equal(panel.recurrenceState().choices.length,2);
});
test('no conflicts allows one explicit confirmation and sends every hidden date unchanged',async()=>{
    const {panel,el,calls,rows,decisions}=fixture();const clean=structuredClone(preview);clean.ocorrencias[1].conflito=false;
    panel.request=async(name,body)=>{calls.push({name,body});return name==='PreverRecorrenciaConsultas'?clean:{...clean,confirmado:true};};
    await panel.schedule();assert(rows.every(x=>x.hidden));assert.equal(el('recorrencia-revisao').hidden,true);
    assert.match(el('recorrencia-estado').textContent,/Nenhum conflito/);assert.equal(el('recorrencia-confirmar').disabled,false);
    await panel.confirmRecurrence();assert.equal(calls.length,2);assert.equal(calls[1].body.revisado,true);
    assert.deepEqual(calls[1].body.ocorrencias,decisions.map(({ordem,dataInicio,dataFim,agendar})=>({ordem,dataInicio,dataFim,agendar})));
});
test('unchanged conflict blocks confirmation even when review is checked',async()=>{
    const {panel,el,calls}=fixture();await panel.schedule();el('recorrencia-revisado').checked=true;panel.updateRecurrence();
    assert.equal(el('recorrencia-confirmar').disabled,true);
    await assert.rejects(panel.confirmRecurrence(),/conflitos pendentes/);assert.equal(calls.length,1);
});
test('rescheduling or skipping resolves each conflict, with review still required',async()=>{
    const {panel,el,decisions}=fixture();await panel.schedule();
    decisions[1].dataInicio='2030-02-12T11:00';decisions[1].dataFim='2030-02-12T11:50';panel.updateRecurrence();
    assert.equal(panel.recurrenceState().pending.size,0);assert.equal(el('recorrencia-confirmar').disabled,true);
    el('recorrencia-revisado').checked=true;panel.updateRecurrence();assert.equal(el('recorrencia-confirmar').disabled,false);
    decisions[1].dataInicio=preview.ocorrencias[1].dataInicio;decisions[1].dataFim=preview.ocorrencias[1].dataFim;decisions[1].agendar=false;
    panel.updateRecurrence();assert.equal(panel.recurrenceState().pending.size,0);
});
test('invalid intervals and overlaps between chosen dates remain pending and visible',async()=>{
    const {panel,decisions,rows}=fixture();await panel.schedule();
    decisions[1].dataInicio='2030-02-04T10:30';decisions[1].dataFim='2030-02-04T11:20';panel.updateRecurrence();
    assert.equal(panel.recurrenceState().pending.size,2);assert(rows.every(x=>!x.hidden));
    decisions[1].dataInicio='2030-02-04T10:50';panel.updateRecurrence();assert.equal(panel.recurrenceState().pending.size,0);
    decisions[1].dataFim=decisions[1].dataInicio;panel.updateRecurrence();assert.equal(panel.recurrenceState().pending.size,1);
    decisions[1].dataInicio='';panel.updateRecurrence();assert.equal(panel.recurrenceState().pending.size,1);
});
test('shortening a series keeps cancellations visible and requires review',async()=>{
    const {panel,el,decisions,rows}=fixture();const shortened=structuredClone(preview);shortened.ocorrencias[1].conflito=false;shortened.ocorrencias[1].agendar=false;shortened.ocorrencias[1].sessaoId=21;decisions[1].agendar=false;
    panel.request=async()=>shortened;await panel.schedule();
    assert.equal(rows[0].hidden,true);assert.equal(rows[1].hidden,false);assert.equal(el('recorrencia-revisao').hidden,false);
    assert.match(el('recorrencia-estado').textContent,/canceladas/);assert.equal(el('recorrencia-confirmar').disabled,true);
    el('recorrencia-revisado').checked=true;panel.updateRecurrence();assert.equal(el('recorrencia-confirmar').disabled,false);
});
test('quinzenal summary and a new preview restore the default tab',async()=>{
    const {panel,el}=fixture();el('agendar-recorrencia').value='14';await panel.schedule();
    assert.match(el('recorrencia-resumo').textContent,/Quinzenal/);panel.selectRecurrenceTab('todas');
    await panel.schedule();assert.equal(panel.recurrenceTab,'resumo');assert.equal(el('recorrencia-revisado').checked,false);
});
