import { apiFetch, getApiErrorMessage } from '/spa/scripts/ServicesGlobal/apiFetch.js';
export async function renderRedacao() {
    let host = document.getElementById('custom-page-container');
    if (!host) { host = document.createElement('section'); host.id = 'custom-page-container'; (document.getElementById('app') || document.body).append(host); }
    const template = await fetch('/Custon/Apps/Presenca/pages/redacao.html');
    if (!template.ok) throw new Error('Não foi possível abrir a redação.');
    host.innerHTML = await template.text(); host.classList.remove('hidden');
    document.getElementById('crud-container')?.classList.add('hidden');
    const el = id => host.querySelector(`#presenca-${id}`), form = el('form');
    let selected = null, materials = [], busy = false, pending = null, dirty = false, offset = 0;
    const lines = name => form.elements[name].value.split('\n').map(s => s.trim()).filter(Boolean);
    const status = message => { el('status').textContent = message; };
    const uuid = () => [...crypto.getRandomValues(new Uint8Array(16))].map(n => n.toString(16).padStart(2, '0')).join('');
    async function call(operation, data = {}, read = false, overrides = {}) {
        if (busy) return null;
        const input = { IdentidadeId: el('identidade').value, RegistroId: selected?.PautaId || '', VersaoEsperada: selected?.Numero || 0, Dados: JSON.stringify(data), ...overrides };
        const signature = JSON.stringify({ operation, input });
        if (!read) {
            if (pending && pending.signature !== signature) throw new Error('Há um pedido sem confirmação. Repita a mesma ação ou atualize antes de mudar os dados.');
            pending ||= { signature, key: uuid() };
        }
        input.Chave = read ? '' : pending.key;
        busy = true; host.querySelectorAll('button').forEach(button => button.disabled = true);
        try {
            const response = await apiFetch(`${environments.urlApi}/Presenca/Editorial${operation}UseCase`, { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(input) });
            const payload = await response.json();
            if (!response.ok || Number(payload.statusCode) >= 400) {
                if (response.status < 500) pending = null;
                throw new Error(getApiErrorMessage(payload, response.status));
            }
            if (!read) pending = null;
            return JSON.parse((payload.data ?? payload).resultado);
        } finally { busy = false; host.querySelectorAll('button').forEach(button => button.disabled = false); }
    }
    function showVersion(version) {
        if (dirty && !confirm('Descartar as alterações ainda não salvas?')) return;
        selected = version; dirty = false; el('publicavel').checked = false;
        const content = JSON.parse(version.Snapshot); materials = content.Materiais || [];
        for (const [key, value] of Object.entries(content)) if (form.elements[key]) form.elements[key].value = Array.isArray(value) ? value.join('\n') : value;
        el('materiais').textContent = materials.map(m => m.TextoAlternativo).join(', ') || 'Nenhum';
        el('versao').textContent = `Versão ${version.Numero} · ${version.Estado}`;
    }
    async function refresh(reset = true) {
        if (reset) offset = 0;
        const result = await call('ConsultarRedacao', { Offset: offset }, true); if (!result) return;
        if (reset) el('lista').replaceChildren();
        el('mais').hidden = !result.TemMais; offset += result.Versoes.length;
        for (const version of result.Versoes) {
            const button = document.createElement('button');
            button.type = 'button'; button.className = 'block my-2 underline';
            button.textContent = `${JSON.parse(version.Snapshot).Manchete} · v${version.Numero} · ${version.Estado}`;
            button.onclick = () => showVersion(version); el('lista').append(button);
        }
        el('canais').replaceChildren();
        for (const channel of result.Canais) { const option = document.createElement('option'); option.value = channel.Id; option.textContent = `${channel.Plataforma}: ${channel.Destino}`; el('canais').append(option); }
    }
    const safe = action => async event => { event?.preventDefault(); try { await action(); } catch (error) { status(error.message); } };
    form.oninput = () => { dirty = true; };
    const updateMaterials = () => { el('materiais').textContent = materials.map(m => m.TextoAlternativo).join(', ') || 'Nenhum'; dirty = true; };
    el('material-adicionar').onclick = safe(async () => {
        if (materials.length >= 20) throw new Error('Limite de 20 materiais por versão.');
        const material = { StorageKey: el('material-chave').value, Hash: el('material-hash').value, Tamanho: Number(el('material-tamanho').value), Tipo: el('material-tipo').value, Autor: el('material-autor').value, Licenca: el('material-licenca').value, TextoAlternativo: el('material-alt').value };
        if (!material.StorageKey || !/^[a-f0-9]{64}$/i.test(material.Hash) || !Number.isInteger(material.Tamanho) || material.Tamanho < 1 || !material.Autor.trim() || !material.Licenca.trim() || !material.TextoAlternativo.trim()) throw new Error('Preencha os dados do material armazenado, sua autoria e licença.');
        materials.push(material); updateMaterials();
    });
    el('material-limpar').onclick = () => { materials = []; updateMaterials(); };
    form.onsubmit = safe(async () => {
        const data = Object.fromEntries(['Manchete', 'Corpo', 'AutorPublico', 'ClassificacaoPrincipal'].map(name => [name, form.elements[name].value]));
        Object.assign(data, { Fontes: lines('Fontes'), Tags: lines('Tags'), ClassificacoesSecundarias: lines('ClassificacoesSecundarias'), Materiais: materials });
        const result = await call(selected ? 'SalvarRascunho' : 'CriarPautaManual', data); if (!result) return;
        selected = { PautaId: result.Id, Numero: result.Versao }; dirty = false; status(`Versão ${result.Versao} salva.`); await refresh();
    });
    el('nova').onclick = () => { if (dirty && !confirm('Descartar alterações ainda não salvas?')) return; selected = null; materials = []; dirty = false; form.reset(); el('versao').textContent = 'Nova pauta'; el('materiais').textContent = 'Nenhum'; };
    el('atualizar').onclick = safe(refresh);
    el('mais').onclick = safe(() => refresh(false));
    let activeIdentity = '';
    el('identidade').onchange = safe(async () => {
        if ((dirty || pending) && !confirm('Há alterações ou um pedido sem confirmação. Trocar de identidade descarta a edição local.')) { el('identidade').value = activeIdentity; return; }
        activeIdentity = el('identidade').value; pending = null; selected = null; materials = []; dirty = false; form.reset(); await refresh(); });
    host.querySelectorAll('[data-operation]').forEach(button => { button.onclick = safe(async () => {
        if (!selected || dirty) throw new Error('Salve e selecione uma versão antes de revisar.');
        const result = await call(button.dataset.operation, { Canais: [...el('canais').selectedOptions].map(o => o.value), Publicavel: el('publicavel').checked, Motivo: el('motivo').value, AgendadaParaUtc: button.dataset.operation === 'SolicitarPublicacao' && el('agenda').value ? new Date(el('agenda').value).toISOString() : '' });
        if (!result) return; status(result.Estado); el('publicavel').checked = false; await refresh();
    }); });
    el('operacao').onclick = safe(async () => {
        const result = await call('ConsultarOperacao', {}, true); if (!result) return; el('entregas').replaceChildren();
        for (const delivery of result.Entregas) {
            const row = document.createElement('fieldset'), heading = document.createElement('legend');
            heading.textContent = `${delivery.Estado} · ${delivery.Tentativas} tentativa(s) · ${delivery.CodigoErro || ''}`; row.append(heading);
            if (delivery.UrlPublica && /^https:\/\//.test(delivery.UrlPublica)) { const link = document.createElement('a'); link.href = delivery.UrlPublica; link.rel = 'noopener noreferrer'; link.target = '_blank'; link.textContent = 'Abrir publicação confirmada'; row.append(link); }
            const input = label => { const element = document.createElement('label'), field = document.createElement('input'); element.append(document.createTextNode(label), field); row.append(element); return field; };
            if (delivery.Estado === 'FalhaFinal' || delivery.Estado === 'ResultadoIncerto') {
                const reason = input('Motivo da intervenção '); reason.maxLength = 500;
                const external = delivery.Estado === 'ResultadoIncerto' ? input('Recibo externo confirmado ') : null;
                const url = delivery.Estado === 'ResultadoIncerto' ? input('URL pública confirmada (quando houver) ') : null;
                const button = document.createElement('button'); button.type = 'button';
                button.textContent = external ? 'Confirmar entrega após reconciliação' : 'Agendar nova tentativa';
                button.onclick = safe(async () => {
                    if (!reason.value.trim() || external && !external.value.trim()) throw new Error('Informe o motivo e a evidência da intervenção.');
                    const result = await call(external ? 'ReconciliarEntrega' : 'ReprocessarEntrega', { Motivo: reason.value, ReciboExterno: external?.value || '', UrlPublica: url?.value || '' }, false, { RegistroId: delivery.Id, VersaoEsperada: delivery.Tentativas });
                    if (result) { status(result.Estado); button.disabled = true; }
                }); row.append(button);
            }
            el('entregas').append(row);
        }
    });
    el('auditoria').onclick = safe(async () => {
        const result = await call('ConsultarAuditoria', {}, true); if (!result) return;
        el('acoes').replaceChildren();
        for (const action of JSON.parse(result.AuditoriaJson)) { const p = document.createElement('p'); p.textContent = `${new Date(action.Changed).toLocaleString('pt-BR')} · ${action.Operacao} · autor ${action.UserId}`; el('acoes').append(p); }
    });
    await safe(async () => {
        const result = await call('ConsultarIdentidades', {}, true); if (!result) return;
        for (const identity of result.Identidades) { const option = document.createElement('option'); option.value = identity.Id; option.textContent = identity.Nome; el('identidade').append(option); }
        activeIdentity = el('identidade').value;
        if (result.Identidades.length) await refresh(); else status('Nenhuma identidade disponível. Solicite o vínculo ao responsável.');
    })();
}
