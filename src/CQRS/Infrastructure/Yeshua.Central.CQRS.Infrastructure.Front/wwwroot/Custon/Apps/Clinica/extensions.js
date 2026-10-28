window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};
window.yeshuaExtensions.pages['clinica-atendimentos'] = async () => {
    const page = await import('/Custon/Apps/Clinica/pages/atendimentos.js?v=20261028-cadastros01');
    await page.renderClinicaAtendimentos();
};
window.yeshuaExtensions.dashboard = window.yeshuaExtensions.pages['clinica-atendimentos'];

window.yeshuaExtensions.crud = window.yeshuaExtensions.crud || {};
window.yeshuaExtensions.crud.replaceActions = ({ metadata, actionsContainer }) => {
    document.getElementById('btn-action-audio')?.remove();
    document.getElementById('cli-open-atendimentos')?.remove();
    if (!['Sesoes','RevisaoRegistroSessao'].includes(metadata?.entityName)) return true;
    const button = document.createElement('button');
    button.id = 'cli-open-atendimentos'; button.textContent = 'Abrir Atendimentos para editar ou gravar';
    button.className = 'px-4 py-2 rounded ml-2 bg-green-700 text-white';
    button.onclick = () => window.yeshuaExtensions.pages['clinica-atendimentos']();
    document.getElementById('resultados-container').prepend(button);
    return true;
};
window.yeshuaExtensions.crud.afterLoadCrud = ({metadata}) => {
    document.getElementById('area-pesquisa')?.classList.remove('hidden');
    const advanced=document.getElementById('btn-toggle-avancado');if(advanced)advanced.hidden=true;
    const readOnly=['Sesoes','RevisaoRegistroSessao'].includes(metadata.entityName);
    if(readOnly)metadata.capabilities={create:false,update:false,delete:false};
    const form=document.getElementById('form-container');
    if(form)form.style.display=readOnly?'none':'';
    if(readOnly){document.getElementById('btn-new').style.display='none';document.getElementById('btn-save').style.display='none';}
};
window.yeshuaExtensions.crud.afterRenderForm = ({metadata}) => {
    if(metadata.entityName==='Servico'){
        const model=document.getElementById('insert-modeloconsulta');if(model)model.value='1';
    }
    if(metadata.entityName==='Paciente'){
        const birth=document.getElementById('insert-datanascimento');
        if(birth){birth.type='date';birth.max=new Date(Date.now()-new Date().getTimezoneOffset()*60000).toISOString().slice(0,10);}
    }
    for(const field of metadata.formFields || []){
        if(field.id.includes('telefone')){const input=document.getElementById('insert-'+field.id);if(input)input.type='tel';}
    }
};
window.yeshuaExtensions.crud.afterFillForm = ({metadata}) => {
    if(metadata.entityName==='Servico'){
        const model=document.getElementById('insert-modeloconsulta');if(model&&!model.value)model.value='1';
    }
};
