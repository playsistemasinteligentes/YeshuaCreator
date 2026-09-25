import { apiFetch } from '../ServicesGlobal/apiFetch.js';
import { showAlert } from '../alerts.js';

window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};
window.yeshuaExtensions.pages['operational-control'] = renderOperationalControl;

async function renderOperationalControl() {
    const host = document.getElementById('custom-page-container');
    if (!host) return;

    document.getElementById('crud-container')?.classList.add('hidden');
    host.classList.remove('hidden');
    host.innerHTML = pageHtml();

    const state = { catalog: null, policy: null };
    const reload = async () => {
        setBusy(true);
        try {
            const [catalogResponse, policyResponse] = await Promise.all([
                apiFetch(`${environments.urlApi}/operational/catalog`),
                apiFetch(`${environments.urlApi}/operational/logging-policy`)
            ]);
            if (!catalogResponse.ok || !policyResponse.ok) {
                throw new Error('Nao foi possivel carregar o controle operacional.');
            }
            state.catalog = await catalogResponse.json();
            state.policy = await policyResponse.json();
            renderState(state);
        } catch (error) {
            showAlert(error.message, 'error');
        } finally {
            setBusy(false);
        }
    };

    document.getElementById('operational-reload').onclick = reload;
    document.getElementById('operational-save').onclick = async () => {
        setBusy(true);
        try {
            const response = await apiFetch(`${environments.urlApi}/operational/logging-policy`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(buildUpdate(state))
            });
            if (!response.ok) throw new Error(await response.text() || 'Nao foi possivel aplicar a configuracao.');
            state.policy = await response.json();
            renderState(state);
            showAlert('Configuracao operacional aplicada.', 'success');
        } catch (error) {
            showAlert(error.message, 'error');
        } finally {
            setBusy(false);
        }
    };
    await reload();
}

function pageHtml() {
    return `<main class="mx-auto max-w-7xl px-4 py-6">
        <div class="mb-5 flex flex-wrap items-center justify-between gap-3">
            <div><p class="text-xs font-semibold uppercase text-gray-500">Operacao</p><h1 class="text-2xl font-bold text-gray-900">Controle operacional</h1><p id="operational-application" class="mt-1 text-sm text-gray-600"></p></div>
            <div class="flex gap-2"><button id="operational-reload" class="border border-gray-300 bg-white px-4 py-2 font-semibold hover:bg-gray-50">Atualizar</button><button id="operational-save" class="bg-green-700 px-4 py-2 font-semibold text-white hover:bg-green-800">Aplicar</button></div>
        </div>
        <div id="operational-loading" class="hidden border-l-4 border-blue-600 bg-blue-50 px-4 py-3 text-sm text-blue-900">Processando...</div>
        <section class="mt-4 border border-gray-200 bg-white p-4"><div class="grid gap-4 md:grid-cols-2">
            <label class="text-sm font-semibold">Nivel padrao<select id="operational-default-level" class="mt-1 w-full border p-2 font-normal"><option value="None">Desligado</option><option value="Error">Erro</option><option value="Warning">Aviso</option><option value="Information">Informacao</option></select></label>
            <label class="text-sm font-semibold">Profundidade padrao<select id="operational-default-depth" class="mt-1 w-full border p-2 font-normal"><option>D0</option><option>D1</option></select></label>
        </div></section>
        <details class="mt-4 border border-gray-200 bg-white p-4">
            <summary class="cursor-pointer font-semibold text-gray-900">Consulta de logs via SSH</summary>
            <p class="mt-2 text-sm text-gray-600">Os comandos consultam os logs da API e do Worker diretamente no servidor, sem alterar a aplicacao.</p>
            <h3 class="mt-4 text-sm font-semibold">Tudo dentro de um periodo</h3>
            <pre id="operational-log-command-period" class="mt-2 overflow-x-auto bg-gray-950 p-3 text-xs text-gray-100"></pre>
            <h3 class="mt-4 text-sm font-semibold">Um identificador dentro do periodo</h3>
            <pre id="operational-log-command-id" class="mt-2 overflow-x-auto bg-gray-950 p-3 text-xs text-gray-100"></pre>
            <p class="mt-2 text-xs text-gray-500">Substitua usuario@servidor, datas e CORRELATION_OU_ID. A busca usa os nomes de servico do Docker Compose.</p>
        </details>
        <section class="mt-4"><h2 class="mb-2 text-lg font-bold">Componentes</h2><div id="operational-components" class="divide-y border bg-white"></div></section>
        <section class="mt-5"><div class="mb-2 flex flex-wrap items-center justify-between gap-3"><div><h2 class="text-lg font-bold">Rastreamento de dominio</h2><p class="text-sm text-gray-600">Selecione somente as entidades e campos que precisam ser acompanhados.</p></div><input id="operational-entity-search" type="search" placeholder="Buscar entidade" class="w-full border px-3 py-2 md:w-72" /></div><div id="operational-entities" class="divide-y border bg-white"></div></section>
    </main>`;
}

function renderState(state) {
    const { catalog, policy } = state;
    document.getElementById('operational-application').textContent = `${catalog.application} / ${policy.environment}`;
    document.getElementById('operational-default-level').value = policy.defaultLevel || 'Information';
    document.getElementById('operational-default-depth').value = policy.defaultDepth || 'D0';
    renderLogCommands(catalog.application);
    document.getElementById('operational-components').innerHTML = catalog.components.map(component => `
        <label class="flex cursor-pointer items-start gap-3 p-3 hover:bg-gray-50"><input class="operational-component mt-1 h-4 w-4" type="checkbox" data-component="${html(component.id)}" ${isEnabled(policy.targets, component.id) ? 'checked' : ''} /><span><strong class="block text-sm">${html(component.title)}</strong><span class="text-sm text-gray-600">${html(component.description)}</span></span></label>`).join('');
    renderEntities(state);
    document.getElementById('operational-entity-search').oninput = event => {
        const value = String(event.target.value || '').trim().toLowerCase();
        document.querySelectorAll('.operational-entity').forEach(element => {
            element.classList.toggle('hidden', value && !element.dataset.search.includes(value));
        });
    };
}

function renderLogCommands(application) {
    const app = String(application || 'aplicativo')
        .normalize('NFD')
        .replace(/[\u0300-\u036f]/g, '')
        .replace(/[^a-zA-Z0-9]+/g, '-')
        .replace(/^-|-$/g, '')
        .toLowerCase();
    const prefix = `ssh usuario@servidor 'for service in ${app}-api ${app}-worker; do container=$(docker ps -q --filter "label=com.docker.compose.service=$service" | head -n 1); if [ -n "$container" ]; then echo "===== $service ====="; docker logs --since "2026-09-20T00:00:00-03:00" --until "2026-09-21T00:00:00-03:00" "$container" 2>&1; fi; done`;
    document.getElementById('operational-log-command-period').textContent = `${prefix}'`;
    document.getElementById('operational-log-command-id').textContent = `${prefix} | grep -F "CORRELATION_OU_ID"'`;
}

function renderEntities(state) {
    document.getElementById('operational-entities').innerHTML = state.catalog.entities.map(entity => `
        <details class="operational-entity p-3" data-search="${html(`${entity.name} ${entity.title}`.toLowerCase())}"><summary class="flex cursor-pointer list-none items-center gap-3"><input class="operational-entity-toggle h-4 w-4" type="checkbox" data-entity="${html(entity.name)}" ${isEnabled(state.policy.targets, 'DomainTracker', entity.name) ? 'checked' : ''} onclick="event.stopPropagation()" /><strong class="text-sm">${html(entity.title)}</strong><span class="text-xs text-gray-400">${html(entity.name)}</span></summary><div class="mt-3 grid gap-x-6 pl-7 sm:grid-cols-2 lg:grid-cols-3">${entity.fields.map(field => `<label class="flex items-center gap-2 py-1 text-sm"><input class="operational-field h-4 w-4" type="checkbox" data-entity="${html(entity.name)}" data-field="${html(field.name)}" ${isEnabled(state.policy.targets, 'DomainTracker', entity.name, field.name) ? 'checked' : ''} />${html(field.title)} <span class="text-xs text-gray-400">${html(field.name)}</span></label>`).join('')}</div></details>`).join('');
}

function buildUpdate(state) {
    const managed = new Set(state.catalog.components.map(component => component.id));
    const targets = (state.policy.targets || []).filter(target => !managed.has(target.component));
    const defaultLevel = document.getElementById('operational-default-level').value;
    const defaultDepth = document.getElementById('operational-default-depth').value;
    document.querySelectorAll('.operational-component').forEach(input => targets.push({ component: input.dataset.component, level: input.checked ? defaultLevel : 'None', depth: defaultDepth }));
    document.querySelectorAll('.operational-entity-toggle:checked').forEach(input => targets.push({ component: 'DomainTracker', entity: input.dataset.entity, level: defaultLevel, depth: defaultDepth }));
    document.querySelectorAll('.operational-field:checked').forEach(input => targets.push({ component: 'DomainTracker', entity: input.dataset.entity, field: input.dataset.field, level: defaultLevel, depth: defaultDepth }));
    return { defaultLevel, defaultDepth, targets };
}

function isEnabled(targets, component, entity = '', field = '') {
    return (targets || []).some(target => target.component === component && (!entity || target.entity === entity) && (!field || target.field === field) && target.level !== 'None');
}

function setBusy(value) {
    document.getElementById('operational-loading')?.classList.toggle('hidden', !value);
    ['operational-reload', 'operational-save'].forEach(id => { const button = document.getElementById(id); if (button) button.disabled = value; });
}

function html(value) {
    const node = document.createElement('span');
    node.textContent = String(value || '');
    return node.innerHTML;
}
