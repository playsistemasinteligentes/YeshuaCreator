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
    document.getElementById('operational-save').onclick = () =>
        persistPolicy(state, buildUpdate(state), 'Configuracao operacional aplicada.');
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
            <label class="text-sm font-semibold">Gravidade minima capturada
                <select id="operational-default-level" class="mt-1 w-full border p-2 font-normal">
                    <option value="None">Desligado</option>
                    <option value="Information">Informacao - sucessos, avisos, erros e criticos</option>
                    <option value="Warning">Aviso - avisos, erros e criticos</option>
                    <option value="Error">Erro - erros e criticos</option>
                    <option value="Critical">Critico - somente criticos</option>
                </select>
                <span class="mt-1 block text-xs font-normal text-gray-600">Qual e a menor gravidade que deve entrar na evidencia operacional.</span>
            </label>
            <label class="text-sm font-semibold">Profundidade da evidencia
                <select id="operational-default-depth" class="mt-1 w-full border p-2 font-normal">
                    <option value="D0">D0 - essencial: identidade, resultado e erro resumido</option>
                    <option value="D1">D1 - narrativa: etapas, duracoes e dependencias</option>
                </select>
                <span class="mt-1 block text-xs font-normal text-gray-600">Quanto contexto a captura deve guardar para explicar a operacao.</span>
            </label>
        </div></section>
        <section class="mt-4 border border-gray-200 bg-white p-4">
            <div class="mb-4"><h2 class="text-lg font-bold text-gray-900">Diagnostico direcionado D2</h2><p class="text-sm text-gray-600">Captura profunda, temporaria, limitada e auditada para um alvo especifico.</p></div>
            <div class="grid gap-3 md:grid-cols-2 lg:grid-cols-4">
                <label class="text-sm font-semibold">Componente<input id="operational-d2-component" list="operational-d2-components" class="mt-1 w-full border p-2 font-normal" placeholder="Command" /><datalist id="operational-d2-components"></datalist></label>
                <label class="text-sm font-semibold">Operacao<input id="operational-d2-operation" class="mt-1 w-full border p-2 font-normal" placeholder="Nome do command ou operacao" /></label>
                <label class="text-sm font-semibold">OperationId<input id="operational-d2-operation-id" class="mt-1 w-full border p-2 font-normal" placeholder="Fluxo especifico, quando conhecido" /></label>
                <label class="text-sm font-semibold">Registro<input id="operational-d2-record-id" class="mt-1 w-full border p-2 font-normal" placeholder="Identificador de negocio" /></label>
                <label class="text-sm font-semibold">Entidade<input id="operational-d2-entity" list="operational-d2-entities" class="mt-1 w-full border p-2 font-normal" placeholder="Entidade opcional" /><datalist id="operational-d2-entities"></datalist></label>
                <label class="text-sm font-semibold">Campo alvo<input id="operational-d2-field" class="mt-1 w-full border p-2 font-normal" placeholder="Campo opcional" /></label>
                <label class="text-sm font-semibold">Duracao em minutos<input id="operational-d2-duration" type="number" min="1" max="1440" value="30" class="mt-1 w-full border p-2 font-normal" /></label>
                <label class="text-sm font-semibold">Limite de capturas<input id="operational-d2-limit" type="number" min="1" max="1000000" value="500" class="mt-1 w-full border p-2 font-normal" /></label>
                <label class="text-sm font-semibold">Solicitante<input id="operational-d2-requested-by" class="mt-1 w-full border p-2 font-normal" /></label>
                <label class="text-sm font-semibold">Aprovador<input id="operational-d2-approved-by" class="mt-1 w-full border p-2 font-normal" /></label>
                <label class="text-sm font-semibold md:col-span-2">Campos autorizados<input id="operational-d2-authorized-fields" class="mt-1 w-full border p-2 font-normal" placeholder="ExceptionMessage, StackTrace, Value" /><span class="mt-1 block text-xs font-normal text-gray-600">Somente estes campos restritos poderao entrar na evidencia D2.</span></label>
                <label class="text-sm font-semibold md:col-span-2 lg:col-span-4">Justificativa<textarea id="operational-d2-justification" rows="2" class="mt-1 w-full border p-2 font-normal"></textarea></label>
            </div>
            <div class="mt-3 flex justify-end"><button id="operational-d2-activate" class="bg-green-700 px-4 py-2 font-semibold text-white hover:bg-green-800">Ativar sessao D2</button></div>
            <div class="mt-5"><h3 class="mb-2 text-sm font-bold text-gray-900">Sessoes ativas</h3><div id="operational-d2-active" class="divide-y border border-gray-200"></div></div>
        </section>
        <section class="mt-4 border border-gray-200 bg-white p-4">
            <div class="mb-3 flex flex-wrap items-center justify-between gap-3">
                <div><h2 class="text-lg font-bold text-gray-900">Logs e telemetria</h2><p class="text-sm text-gray-600">Acessos operacionais para consultar a aplicacao selecionada.</p></div>
                <span id="operational-log-scope" class="border border-gray-200 bg-gray-50 px-3 py-1 text-xs font-semibold text-gray-600"></span>
            </div>
            <div id="operational-log-access" class="grid gap-3 md:grid-cols-2 lg:grid-cols-4"></div>
            <div class="mt-4 grid gap-4 lg:grid-cols-2">
                <div class="border border-gray-200 bg-gray-50 p-3">
                    <h3 class="text-sm font-semibold text-gray-900">Filtro Loki sugerido</h3>
                    <pre id="operational-logql-query" class="mt-2 overflow-x-auto bg-gray-950 p-3 text-xs text-gray-100"></pre>
                </div>
                <details class="border border-gray-200 bg-gray-50 p-3">
                    <summary class="cursor-pointer text-sm font-semibold text-gray-900">Consulta via SSH</summary>
                    <h3 class="mt-4 text-sm font-semibold">Tudo dentro de um periodo</h3>
                    <pre id="operational-log-command-period" class="mt-2 overflow-x-auto bg-gray-950 p-3 text-xs text-gray-100"></pre>
                    <h3 class="mt-4 text-sm font-semibold">Um identificador dentro do periodo</h3>
                    <pre id="operational-log-command-id" class="mt-2 overflow-x-auto bg-gray-950 p-3 text-xs text-gray-100"></pre>
                </details>
            </div>
        </section>
        <section class="mt-4"><h2 class="mb-2 text-lg font-bold">Componentes</h2><div id="operational-components" class="divide-y border bg-white"></div></section>
        <section class="mt-5"><div class="mb-2 flex flex-wrap items-center justify-between gap-3"><div><h2 class="text-lg font-bold">Rastreamento de dominio</h2><p class="text-sm text-gray-600">Selecione somente as entidades e campos que precisam ser acompanhados.</p></div><input id="operational-entity-search" type="search" placeholder="Buscar entidade" class="w-full border px-3 py-2 md:w-72" /></div><label class="mb-2 flex cursor-pointer items-center gap-3 border bg-white p-3 hover:bg-gray-50"><input id="operational-domain-all" class="h-4 w-4" type="checkbox" /><span><strong class="block text-sm">Todos</strong><span class="text-sm text-gray-600">Todas as entidades e todos os campos.</span></span></label><div id="operational-entities" class="divide-y border bg-white"></div></section>
    </main>`;
}

function renderState(state) {
    const { catalog, policy } = state;
    document.getElementById('operational-application').textContent = `${catalog.application} / ${policy.environment}`;
    document.getElementById('operational-default-level').value = policy.defaultLevel || 'Information';
    document.getElementById('operational-default-depth').value = policy.defaultDepth || 'D0';
    renderDiagnosticControl(state);
    renderLogAccess(catalog.application, policy.environment);
    document.getElementById('operational-components').innerHTML = catalog.components.filter(component => component.id !== 'DomainTracker').map(component => `
        <label class="flex cursor-pointer items-start gap-3 p-3 hover:bg-gray-50"><input class="operational-component mt-1 h-4 w-4" type="checkbox" data-component="${html(component.id)}" ${isEnabled(policy.targets, component.id) ? 'checked' : ''} /><span><strong class="block text-sm">${html(component.title)}</strong><span class="text-sm text-gray-600">${html(component.description)}</span></span></label>`).join('');
    renderEntities(state);
    const domainAll = document.getElementById('operational-domain-all');
    domainAll.checked = isExactEnabled(policy.targets, 'DomainTracker');
    domainAll.onchange = () => applyDomainAllState(domainAll.checked);
    applyDomainAllState(domainAll.checked);
    document.getElementById('operational-entity-search').oninput = event => {
        const value = String(event.target.value || '').trim().toLowerCase();
        document.querySelectorAll('.operational-entity').forEach(element => {
            element.classList.toggle('hidden', value && !element.dataset.search.includes(value));
        });
    };
}

function renderLogAccess(application, environment) {
    const app = String(application || 'aplicativo')
        .normalize('NFD')
        .replace(/[\u0300-\u036f]/g, '')
        .replace(/[^a-zA-Z0-9]+/g, '-')
        .replace(/^-|-$/g, '')
        .toLowerCase();
    const title = String(application || 'Aplicacao');
    const env = String(environment || 'Production');
    const logql = `{service_name=~".*${escapeLogQuery(app)}.*"} |~ "(?i)(error|exception|failed|failure|falhou|erro)"`;
    const telemetryBase = '/telemetry/';
    const exploreLogs = buildGrafanaExploreUrl('Loki', logql);
    const exploreTraces = buildGrafanaExploreUrl('Tempo', `{ resource.service.name =~ ".*${escapeLogQuery(app)}.*" }`);
    const exploreMetrics = `${telemetryBase}explore?orgId=1`;

    document.getElementById('operational-log-scope').textContent = `${title} / ${env}`;
    document.getElementById('operational-logql-query').textContent = logql;
    document.getElementById('operational-log-access').innerHTML = [
        accessCard('Grafana', 'Painel geral de observabilidade.', telemetryBase, 'Abrir'),
        accessCard('Logs da aplicacao', 'Explore Loki com filtro do aplicativo.', exploreLogs, 'Ver logs'),
        accessCard('Traces', 'Explore Tempo para chamadas e spans.', exploreTraces, 'Ver traces'),
        accessCard('Metricas', 'Explore Prometheus e paineis tecnicos.', exploreMetrics, 'Ver metricas')
    ].join('');

    const prefix = `ssh usuario@servidor 'for service in ${app}-api ${app}-worker; do container=$(docker ps -q --filter "label=com.docker.compose.service=$service" | head -n 1); if [ -n "$container" ]; then echo "===== $service ====="; docker logs --since "2026-09-20T00:00:00-03:00" --until "2026-09-21T00:00:00-03:00" "$container" 2>&1; fi; done`;
    document.getElementById('operational-log-command-period').textContent = `${prefix}'`;
    document.getElementById('operational-log-command-id').textContent = `${prefix} | grep -F "CORRELATION_OU_ID"'`;
}

function accessCard(title, description, href, action) {
    return `<a class="block border border-gray-200 bg-white p-3 hover:border-green-700 hover:bg-green-50" href="${html(href)}" target="_blank" rel="noopener noreferrer">
        <strong class="block text-sm text-gray-900">${html(title)}</strong>
        <span class="mt-1 block min-h-10 text-sm text-gray-600">${html(description)}</span>
        <span class="mt-3 inline-flex border border-green-700 px-3 py-1 text-sm font-semibold text-green-800">${html(action)}</span>
    </a>`;
}

function buildGrafanaExploreUrl(datasource, query) {
    const left = encodeURIComponent(JSON.stringify([
        'now-1h',
        'now',
        datasource,
        { expr: query, refId: 'A' }
    ]));
    return `/telemetry/explore?orgId=1&left=${left}`;
}

function escapeLogQuery(value) {
    return String(value || '')
        .replace(/\\/g, '\\\\')
        .replace(/"/g, '\\"');
}

function renderEntities(state) {
    document.getElementById('operational-entities').innerHTML = state.catalog.entities.map(entity => `
        <details class="operational-entity p-3" data-search="${html(`${entity.name} ${entity.title}`.toLowerCase())}"><summary class="flex cursor-pointer list-none items-center gap-3"><input class="operational-entity-toggle h-4 w-4" type="checkbox" data-entity="${html(entity.name)}" ${isEnabled(state.policy.targets, 'DomainTracker', entity.name) ? 'checked' : ''} onclick="event.stopPropagation()" /><strong class="text-sm">${html(entity.title)}</strong><span class="text-xs text-gray-400">${html(entity.name)}</span></summary><div class="mt-3 grid gap-x-6 pl-7 sm:grid-cols-2 lg:grid-cols-3">${entity.fields.map(field => renderOperationalField(entity, field, state.policy.targets)).join('')}</div></details>`).join('');
}

function renderOperationalField(entity, field, targets) {
    const fieldClassification = field.classification || 'Internal';
    const neverCapture = fieldClassification === 'NeverCapture';
    const checked = !neverCapture && isEnabled(targets, 'DomainTracker', entity.name, field.name);
    const classification = neverCapture ? 'Nao capturavel' : fieldClassification;
    return `<label class="flex items-center gap-2 py-1 text-sm ${neverCapture ? 'text-gray-400' : ''}"><input class="operational-field h-4 w-4" type="checkbox" data-entity="${html(entity.name)}" data-field="${html(field.name)}" ${checked ? 'checked' : ''} ${neverCapture ? 'disabled' : ''} />${html(field.title)} <span class="text-xs text-gray-400">${html(field.name)} - ${html(classification)}</span></label>`;
}

function buildUpdate(state) {
    const managed = new Set(state.catalog.components.map(component => component.id));
    const targets = (state.policy.targets || []).filter(target => target.depth === 'D2' || !managed.has(target.component));
    const defaultLevel = document.getElementById('operational-default-level').value;
    const defaultDepth = document.getElementById('operational-default-depth').value;
    document.querySelectorAll('.operational-component').forEach(input => targets.push({ component: input.dataset.component, level: input.checked ? defaultLevel : 'None', depth: defaultDepth }));
    if (document.getElementById('operational-domain-all').checked) {
        targets.push({ component: 'DomainTracker', level: defaultLevel, depth: 'D1' });
    } else {
        document.querySelectorAll('.operational-entity-toggle:checked').forEach(input => targets.push({ component: 'DomainTracker', entity: input.dataset.entity, level: defaultLevel, depth: 'D1' }));
        document.querySelectorAll('.operational-field:checked').forEach(input => targets.push({ component: 'DomainTracker', entity: input.dataset.entity, field: input.dataset.field, level: defaultLevel, depth: 'D1' }));
    }
    return { defaultLevel, defaultDepth, targets };
}

function renderDiagnosticControl(state) {
    document.getElementById('operational-d2-components').innerHTML = state.catalog.components
        .map(component => `<option value="${html(component.id)}">${html(component.title)}</option>`)
        .join('');
    document.getElementById('operational-d2-entities').innerHTML = state.catalog.entities
        .map(entity => `<option value="${html(entity.name)}">${html(entity.title)}</option>`)
        .join('');

    const active = (state.policy.targets || []).filter(target =>
        target.depth === 'D2' && (!target.expiresAtUtc || new Date(target.expiresAtUtc) > new Date()));
    document.getElementById('operational-d2-active').innerHTML = active.length
        ? active.map(target => diagnosticSessionHtml(target)).join('')
        : '<p class="p-3 text-sm text-gray-500">Nenhuma sessao D2 ativa.</p>';

    document.getElementById('operational-d2-activate').onclick = () => activateDiagnosticSession(state);
    document.querySelectorAll('.operational-d2-stop').forEach(button => {
        button.onclick = () => stopDiagnosticSession(state, button.dataset.sessionId);
    });
}

function diagnosticSessionHtml(target) {
    const scope = [target.component, target.operation, target.operationId, target.entity, target.recordId, target.field]
        .filter(Boolean)
        .join(' / ');
    return `<div class="flex flex-wrap items-center justify-between gap-3 p-3"><div><strong class="block text-sm text-gray-900">${html(scope)}</strong><span class="text-xs text-gray-600">Ate ${html(formatDate(target.expiresAtUtc))} · limite ${html(target.maximumCaptures)} · ${html(target.requestedBy)} / ${html(target.approvedBy)}</span><span class="mt-1 block text-xs text-gray-500">${html(target.justification)}</span></div><button class="operational-d2-stop border border-red-700 px-3 py-1 text-sm font-semibold text-red-700 hover:bg-red-50" data-session-id="${html(target.diagnosticSessionId)}">Encerrar</button></div>`;
}

async function activateDiagnosticSession(state) {
    const value = id => String(document.getElementById(id).value || '').trim();
    const component = value('operational-d2-component');
    const operation = value('operational-d2-operation');
    const operationId = value('operational-d2-operation-id');
    const entity = value('operational-d2-entity');
    const recordId = value('operational-d2-record-id');
    const field = value('operational-d2-field');
    const requestedBy = value('operational-d2-requested-by');
    const approvedBy = value('operational-d2-approved-by');
    const justification = value('operational-d2-justification');
    const duration = Number(value('operational-d2-duration'));
    const maximumCaptures = Number(value('operational-d2-limit'));
    const authorizedFields = value('operational-d2-authorized-fields')
        .split(',')
        .map(item => item.trim())
        .filter(Boolean);

    if (![component, operation, operationId, entity, recordId, field].some(Boolean)) {
        showAlert('Informe ao menos um alvo para o diagnostico D2.', 'error');
        return;
    }
    if (!requestedBy || !approvedBy || !justification || !duration || !maximumCaptures || !authorizedFields.length) {
        showAlert('Preencha solicitante, aprovador, justificativa, duracao, limite e campos autorizados.', 'error');
        return;
    }

    const target = {
        component: component || null,
        operation: operation || null,
        operationId: operationId || null,
        entity: entity || null,
        recordId: recordId || null,
        field: field || null,
        level: 'Debug',
        depth: 'D2',
        startsAtUtc: new Date().toISOString(),
        expiresAtUtc: new Date(Date.now() + duration * 60000).toISOString(),
        maximumCaptures,
        requestedBy,
        approvedBy,
        justification,
        authorizedFields
    };
    state.policy.targets = [...(state.policy.targets || []), target];
    await persistPolicy(state, buildUpdate(state), 'Sessao D2 ativada.');
}

async function stopDiagnosticSession(state, sessionId) {
    state.policy.targets = (state.policy.targets || []).filter(target =>
        target.diagnosticSessionId !== sessionId);
    await persistPolicy(state, buildUpdate(state), 'Sessao D2 encerrada.');
}

async function persistPolicy(state, update, successMessage) {
    setBusy(true);
    try {
        const response = await apiFetch(`${environments.urlApi}/operational/logging-policy`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(update)
        });
        if (!response.ok) throw new Error(await response.text() || 'Nao foi possivel aplicar a configuracao.');
        state.policy = await response.json();
        renderState(state);
        showAlert(successMessage, 'success');
    } catch (error) {
        showAlert(error.message, 'error');
    } finally {
        setBusy(false);
    }
}

function formatDate(value) {
    if (!value) return '-';
    return new Date(value).toLocaleString('pt-BR');
}

function applyDomainAllState(enabled) {
    const entities = document.getElementById('operational-entities');
    entities.classList.toggle('opacity-50', enabled);
    entities.querySelectorAll('input').forEach(input => { input.disabled = enabled; });
    document.getElementById('operational-entity-search').disabled = enabled;
}

function isExactEnabled(targets, component) {
    return (targets || []).some(target => target.component === component && !target.operation && !target.entity && !target.recordId && !target.field && target.level !== 'None');
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
