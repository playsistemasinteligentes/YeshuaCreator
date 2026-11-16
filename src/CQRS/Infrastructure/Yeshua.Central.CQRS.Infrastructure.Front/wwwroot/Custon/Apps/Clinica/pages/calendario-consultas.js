const zone='America/Sao_Paulo';
export function localSaoPaulo(instant){
    const parts=Object.fromEntries(new Intl.DateTimeFormat('en-GB',{timeZone:zone,year:'numeric',month:'2-digit',day:'2-digit',hour:'2-digit',minute:'2-digit',hourCycle:'h23'}).formatToParts(new Date(instant)).map(x=>[x.type,x.value]));
    return `${parts.year}-${parts.month}-${parts.day}T${parts.hour}:${parts.minute}`;
}
export function instanteSaoPaulo(local){
    if(!/^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}$/.test(local))throw new Error('Informe data e hora de São Paulo.');
    const target=Date.parse(local+'Z');let instant=target;
    for(let i=0;i<3;i++)instant+=target-Date.parse(localSaoPaulo(instant)+'Z');
    if(localSaoPaulo(instant)!==local)throw new Error('Horário inválido no fuso de São Paulo.');
    return new Date(instant).toISOString();
}
export function escolhasDaPrevia(container){
    return [...container.querySelectorAll('[data-ocorrencia]')].map(row=>({ordem:Number(row.dataset.ocorrencia),
        dataInicio:row.querySelector('[data-inicio]').value,dataFim:row.querySelector('[data-fim]').value,
        agendar:row.querySelector('[data-agendar]').checked}));
}
