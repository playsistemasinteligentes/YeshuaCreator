const cssId = 'aps-planejamento-transporte-css';
const hostId = 'custom-page-container';

const endpoints = {
    buscarContexto: '/APSADM/PlanejamentoTransporteBuscarContextoPlanejamentoTransporteUseCase',
    listarLentes: '/APSADM/PlanejamentoTransporteListarLentesPlanejamentoTransporteUseCase',
    abrirNoLente: '/APSADM/PlanejamentoTransporteAbrirNoLentePlanejamentoTransporteUseCase',
    revalidarSelecao: '/APSADM/PlanejamentoTransporteRevalidarSelecaoPlanejamentoTransporteUseCase',
    criarCarga: '/APSADM/PlanejamentoTransporteCriarCargaDaSelecaoPlanejamentoTransporteUseCase',
    gerarOpcoes: '/APSADM/PlanejamentoTransporteGerarGruposDecisaoPlanejamentoTransporteUseCase',
    gerarCenarios: '/APSADM/PlanejamentoTransporteGerarCenariosPlanejamentoTransporteUseCase'
};

const state = {
    contextoId: '',
    lenses: [],
    roots: [],
    selected: new Map(),
    loadedNodes: new Map(),
    activeLensId: 'estado-municipio',
    dataMode: 'api'
};

export async function renderPlanejamentoTransporte() {
    injectCss();
    const host = await prepareHost();
    const html = await fetch('/Custon/pages/planejamento-transporte.html').then(r => r.text());
    host.innerHTML = html;
    host.classList.remove('hidden');

    bindEvents();
    setDefaultDates();
    await loadContext();
}

async function prepareHost() {
    const crudContainer = document.getElementById('crud-container');
    if (crudContainer) crudContainer.style.display = 'none';

    let host = document.getElementById(hostId);
    if (!host) {
        host = document.createElement('div');
        host.id = hostId;
        host.className = 'hidden';
        const dashboard = document.querySelector('#crud-container')?.parentElement || document.getElementById('app') || document.body;
        dashboard.appendChild(host);
    }

    return host;
}

function injectCss() {
    if (document.getElementById(cssId)) return;

    const link = document.createElement('link');
    link.id = cssId;
    link.rel = 'stylesheet';
    link.href = '/Custon/pages/planejamento-transporte.css';
    document.head.appendChild(link);
}

function bindEvents() {
    document.getElementById('aps-load-context')?.addEventListener('click', loadContext);
    document.getElementById('aps-create-load')?.addEventListener('click', createLoadFromSelection);
    document.getElementById('aps-clear-selection')?.addEventListener('click', clearSelection);
    document.getElementById('aps-generate-options')?.addEventListener('click', generateOptions);
    document.getElementById('aps-generate-scenarios')?.addEventListener('click', generateScenarios);

    document.getElementById('aps-lens-select')?.addEventListener('change', async event => {
        state.activeLensId = event.target.value;
        state.roots = [];
        state.loadedNodes.clear();
        await loadLensRoot();
    });
}

function setDefaultDates() {
    const today = new Date();
    const tomorrow = new Date(today);
    tomorrow.setDate(today.getDate() + 1);

    setValue('aps-date-from', formatDate(today));
    setValue('aps-date-to', formatDate(tomorrow));
}

async function loadContext() {
    const payload = {
        embarqueDe: getValue('aps-date-from'),
        embarqueAte: getValue('aps-date-to'),
        plantaId: '',
        limitePedidos: Number(getValue('aps-limit') || 500)
    };

    setTreeLoading('Carregando contexto...');
    feedback('');

    try {
        const result = await postUseCase(endpoints.buscarContexto, payload);
        state.contextoId = readField(result, 'contextoId', 'ContextoId') || '';
        state.lenses = normalizeArray(readField(result, 'lentes', 'Lentes'));
        state.roots = [];
        state.loadedNodes.clear();
        state.selected.clear();

        renderLenses();
        await loadLensRoot();
        renderSelection();

        const quantidadePedidos = Number(readField(result, 'quantidadePedidos', 'QuantidadePedidos') || 0);
        const quantidadeCargas = Number(readField(result, 'quantidadeCargas', 'QuantidadeCargas') || 0);
        setText('aps-context-status', `${quantidadePedidos} pedidos | ${quantidadeCargas} cargas`);
        setText('aps-data-mode', state.dataMode);
    } catch (error) {
        state.roots = [];
        renderTree();
        setText('aps-context-status', 'erro');
        feedback(error.message || 'Nao foi possivel carregar o contexto.');
    }
}

function renderLenses() {
    const select = document.getElementById('aps-lens-select');
    if (!select) return;

    select.innerHTML = '';
    for (const lens of state.lenses) {
        const option = document.createElement('option');
        option.value = readField(lens, 'lenteId', 'LenteId') || '';
        option.textContent = readField(lens, 'descricao', 'Descricao') || option.value;
        select.appendChild(option);
    }

    if (!state.lenses.some(lens => readField(lens, 'lenteId', 'LenteId') === state.activeLensId)) {
        state.activeLensId = readField(state.lenses[0] || {}, 'lenteId', 'LenteId') || 'estado-municipio';
    }

    select.value = state.activeLensId;
}

async function loadLensRoot() {
    if (!state.contextoId) return;

    setTreeLoading('Carregando agrupamentos...');
    const result = await openLens('', 0);
    state.roots = normalizeArray(readField(result, 'nos', 'Nos')).map(normalizeNode);
    renderTree();
}

async function openLens(noId, nivel) {
    return postUseCase(endpoints.abrirNoLente, {
        contextoId: state.contextoId,
        lenteId: state.activeLensId,
        noId,
        nivel
    });
}

function renderTree() {
    const tree = document.getElementById('aps-lens-tree');
    if (!tree) return;

    tree.innerHTML = '';

    if (state.roots.length === 0) {
        tree.innerHTML = '<p class="aps-feedback">Nenhum agrupamento encontrado para o contexto.</p>';
        return;
    }

    state.roots.forEach(node => tree.appendChild(renderGroupNode(node)));
}

function setTreeLoading(message) {
    const tree = document.getElementById('aps-lens-tree');
    if (tree) tree.innerHTML = `<p class="aps-feedback">${escapeHtml(message)}</p>`;
}

function renderGroupNode(node) {
    const wrapper = document.createElement('div');
    wrapper.className = 'aps-tree-node';

    const row = document.createElement('button');
    row.type = 'button';
    row.className = 'aps-tree-row';
    row.innerHTML = `
        <span class="aps-node-icon">${node.loaded ? '-' : '+'}</span>
        <span>
            <strong>${escapeHtml(node.descricao)}</strong>
            <small>${node.quantidadePedidos} pedidos | ${formatNumber(node.peso)} kg | ${formatNumber(node.volume)} m3</small>
        </span>
        <small>N${node.nivel + 1}</small>
    `;

    const children = document.createElement('div');
    children.className = 'aps-tree-children';

    if (node.loaded) {
        node.children.forEach(child => children.appendChild(renderGroupNode(child)));
        node.orders.forEach(order => children.appendChild(renderOrderRow(order)));
    }

    row.addEventListener('click', async () => {
        wrapper.classList.toggle('open');

        if (!node.loaded) {
            await loadNode(node, children, row);
        }
    });

    wrapper.appendChild(row);
    wrapper.appendChild(children);
    return wrapper;
}

async function loadNode(node, children, row) {
    const icon = row.querySelector('.aps-node-icon');
    if (icon) icon.textContent = '...';
    children.innerHTML = '<p class="aps-feedback">Carregando...</p>';

    try {
        const result = await openLens(node.noId, node.nivel + 1);
        const childNodes = normalizeArray(readField(result, 'nos', 'Nos')).map(normalizeNode);
        const pedidos = normalizeArray(readField(result, 'pedidos', 'Pedidos')).map(normalizeOrder);

        node.loaded = true;
        node.children = childNodes;
        node.orders = pedidos;
        state.loadedNodes.set(node.noId, node);

        children.innerHTML = '';
        childNodes.forEach(child => children.appendChild(renderGroupNode(child)));
        pedidos.forEach(order => children.appendChild(renderOrderRow(order)));

        if (childNodes.length === 0 && pedidos.length === 0) {
            children.innerHTML = '<p class="aps-feedback">Sem pedidos neste agrupamento.</p>';
        }

        if (icon) icon.textContent = '-';
    } catch (error) {
        children.innerHTML = `<p class="aps-feedback">${escapeHtml(error.message || 'Falha ao abrir agrupamento.')}</p>`;
        if (icon) icon.textContent = '+';
    }
}

function renderOrderRow(order) {
    const row = document.createElement('label');
    row.className = 'aps-order-row';

    const checkbox = document.createElement('input');
    checkbox.type = 'checkbox';
    checkbox.checked = state.selected.has(order.pedidoId);
    checkbox.addEventListener('change', () => toggleOrder(order, checkbox.checked));

    const info = document.createElement('span');
    info.innerHTML = `
        <strong>${escapeHtml(order.pedidoId)} - ${escapeHtml(order.clienteNome)}</strong>
        <small>${escapeHtml(order.municipio)} / ${escapeHtml(order.estado)} | ${formatNumber(order.peso)} kg | ${formatNumber(order.volume)} m3</small>
    `;

    const alert = document.createElement('small');
    alert.textContent = order.alertasResumo || '';

    row.appendChild(checkbox);
    row.appendChild(info);
    row.appendChild(alert);
    return row;
}

function toggleOrder(order, selected) {
    if (selected) {
        state.selected.set(order.pedidoId, order);
    } else {
        state.selected.delete(order.pedidoId);
    }

    renderSelection();
}

function renderSelection() {
    const orders = Array.from(state.selected.values());
    const container = document.getElementById('aps-selected-orders');
    if (!container) return;

    container.innerHTML = '';

    if (orders.length === 0) {
        container.innerHTML = '<p class="aps-feedback">Abra uma lente e selecione pedidos para montar a carga.</p>';
    } else {
        orders.forEach(order => container.appendChild(renderSelectedOrder(order)));
    }

    setText('aps-selection-count', `${orders.length} pedidos`);
    setText('aps-summary-orders', String(orders.length));
    setText('aps-summary-weight', formatNumber(sum(orders, 'peso')));
    setText('aps-summary-volume', formatNumber(sum(orders, 'volume')));
}

function renderSelectedOrder(order) {
    const row = document.createElement('div');
    row.className = 'aps-selected-row';

    const remove = document.createElement('button');
    remove.type = 'button';
    remove.textContent = 'x';
    remove.addEventListener('click', () => {
        state.selected.delete(order.pedidoId);
        renderTree();
        renderSelection();
    });

    const info = document.createElement('span');
    info.innerHTML = `
        <strong>${escapeHtml(order.pedidoId)} - ${escapeHtml(order.clienteNome)}</strong>
        <small>${escapeHtml(order.rotaId)} | ${escapeHtml(order.municipio)} / ${escapeHtml(order.estado)}</small>
    `;

    const metrics = document.createElement('small');
    metrics.textContent = `${formatNumber(order.peso)} kg`;

    row.appendChild(remove);
    row.appendChild(info);
    row.appendChild(metrics);
    return row;
}

async function createLoadFromSelection() {
    const pedidos = selectedRefs();
    if (pedidos.length === 0) {
        feedback('Selecione pelo menos um pedido para criar carga.');
        return;
    }

    try {
        feedback('Validando selecao...');
        const validation = await postUseCase(endpoints.revalidarSelecao, { contextoId: state.contextoId, pedidos });
        if (readField(validation, 'valida', 'Valida') === false) {
            const invalidOrders = normalizeArray(readField(validation, 'pedidosInvalidos', 'PedidosInvalidos', 'conflitos', 'Conflitos'));
            const firstReason = invalidOrders.length > 0 ? readField(invalidOrders[0], 'alertasResumo', 'AlertasResumo', 'mensagem', 'Mensagem') : '';
            const message = readField(validation, 'mensagem', 'Mensagem') || 'Selecao invalida.';
            feedback(firstReason ? `${message} ${firstReason}` : message);
            return;
        }

        feedback('Criando carga...');
        const result = await postUseCase(endpoints.criarCarga, {
            contextoId: state.contextoId,
            pedidos,
            tipoVeiculoId: '',
            observacao: 'Criada pela tela de planejamento de transporte.'
        });

        const criada = readField(result, 'criada', 'Criada');
        feedback(readField(result, 'mensagem', 'Mensagem') || (criada ? 'Carga criada.' : 'Carga nao criada.'));

        if (criada !== false) {
            state.selected.clear();
            await loadContext();
        }
    } catch (error) {
        feedback(error.message || 'Nao foi possivel criar a carga.');
    }
}

async function generateOptions() {
    try {
        const result = await postUseCase(endpoints.gerarOpcoes, {
            contextoId: state.contextoId,
            objetivo: 'equilibrar-custo-cubagem',
            pedidos: selectedRefs()
        });
        feedback(`${normalizeArray(readField(result, 'opcoes', 'Opcoes')).length} opcoes de decisao disponiveis.`);
    } catch (error) {
        feedback(error.message || 'Ainda nao foi possivel gerar grupos de decisao.');
    }
}

async function generateScenarios() {
    try {
        const result = await postUseCase(endpoints.gerarCenarios, {
            contextoId: state.contextoId,
            objetivo: 'menor-custo-com-entrega'
        });
        feedback(`${normalizeArray(readField(result, 'cenarios', 'Cenarios')).length} cenarios completos disponiveis.`);
    } catch (error) {
        feedback(error.message || 'Ainda nao foi possivel gerar cenarios prontos.');
    }
}

function clearSelection() {
    state.selected.clear();
    renderTree();
    renderSelection();
    feedback('Selecao limpa.');
}

function selectedRefs() {
    return Array.from(state.selected.values()).map(order => ({
        pedidoId: order.pedidoId,
        versaoPlanejamento: order.versaoPlanejamento || ''
    }));
}

async function postUseCase(endpoint, body) {
    const token = localStorage.getItem('token');
    const response = await fetch(buildApiUrl(endpoint), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        },
        body: JSON.stringify(body)
    });

    const text = await response.text();
    if (!response.ok) {
        throw new Error(text || `HTTP ${response.status}`);
    }

    const raw = text ? JSON.parse(text) : {};
    state.dataMode = 'api';
    setText('aps-data-mode', state.dataMode);
    return raw.data || raw.Data || raw;
}

function buildApiUrl(endpoint) {
    const apiBase = String(environments.urlApi || '').replace(/\/$/, '');
    const path = String(endpoint || '').startsWith('/') ? String(endpoint || '') : `/${endpoint || ''}`;

    if (apiBase && path.toLowerCase().startsWith(`${apiBase.toLowerCase()}/`)) {
        return path;
    }

    return `${apiBase}${path}`;
}

function normalizeNode(node) {
    return {
        noId: readField(node, 'noId', 'NoId') || '',
        parentNoId: readField(node, 'parentNoId', 'ParentNoId') || '',
        descricao: readField(node, 'descricao', 'Descricao') || 'Sem classificacao',
        nivel: Number(readField(node, 'nivel', 'Nivel') || 0),
        quantidadePedidos: Number(readField(node, 'quantidadePedidos', 'QuantidadePedidos') || 0),
        peso: Number(readField(node, 'peso', 'Peso') || 0),
        volume: Number(readField(node, 'volume', 'Volume') || 0),
        temFilhos: readField(node, 'temFilhos', 'TemFilhos') === true,
        loaded: false,
        children: [],
        orders: []
    };
}

function normalizeOrder(order) {
    return {
        pedidoId: readField(order, 'pedidoId', 'PedidoId', 'pedidoid') || '',
        clienteNome: readField(order, 'clienteNome', 'ClienteNome', 'clientenome') || '',
        estado: readField(order, 'estado', 'Estado') || '',
        municipio: readField(order, 'municipio', 'Municipio') || '',
        regiao: readField(order, 'regiao', 'Regiao') || '',
        bairro: readField(order, 'bairro', 'Bairro') || '',
        rotaId: readField(order, 'rotaId', 'RotaId', 'rotaid') || '',
        peso: Number(readField(order, 'peso', 'Peso') || 0),
        volume: Number(readField(order, 'volume', 'Volume') || 0),
        embarqueAlvo: readField(order, 'embarqueAlvo', 'EmbarqueAlvo') || '',
        versaoPlanejamento: readField(order, 'versaoPlanejamento', 'VersaoPlanejamento', 'versaoplanejamento') || '',
        alertasResumo: readField(order, 'alertasResumo', 'AlertasResumo', 'alertasresumo') || ''
    };
}

function readField(object, ...names) {
    if (!object) return undefined;

    for (const name of names) {
        if (Object.prototype.hasOwnProperty.call(object, name)) {
            return object[name];
        }
    }

    return undefined;
}

function sum(items, field) {
    return items.reduce((total, item) => total + Number(item[field] || 0), 0);
}

function normalizeArray(value) {
    return Array.isArray(value) ? value : [];
}

function getValue(id) {
    return document.getElementById(id)?.value || '';
}

function setValue(id, value) {
    const element = document.getElementById(id);
    if (element) element.value = value;
}

function setText(id, value) {
    const element = document.getElementById(id);
    if (element) element.textContent = value;
}

function feedback(message) {
    setText('aps-feedback', message);
}

function formatDate(date) {
    return date.toISOString().slice(0, 10);
}

function formatNumber(value) {
    return Number(value || 0).toLocaleString('pt-BR', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
    });
}

function escapeHtml(value) {
    return String(value || '')
        .replaceAll('&', '&amp;')
        .replaceAll('<', '&lt;')
        .replaceAll('>', '&gt;')
        .replaceAll('"', '&quot;')
        .replaceAll("'", '&#039;');
}
