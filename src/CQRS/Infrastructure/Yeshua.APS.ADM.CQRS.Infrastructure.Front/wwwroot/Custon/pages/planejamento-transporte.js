const cssId = 'aps-planejamento-transporte-css';
const hostId = 'custom-page-container';

const endpoints = {
    buscarContexto: '/yapi/APSADM/PlanejamentoTransporteBuscarContextoPlanejamentoTransporteUseCase',
    listarLentes: '/yapi/APSADM/PlanejamentoTransporteListarLentesPlanejamentoTransporteUseCase',
    abrirNoLente: '/yapi/APSADM/PlanejamentoTransporteAbrirNoLentePlanejamentoTransporteUseCase',
    revalidarSelecao: '/yapi/APSADM/PlanejamentoTransporteRevalidarSelecaoPlanejamentoTransporteUseCase',
    criarCarga: '/yapi/APSADM/PlanejamentoTransporteCriarCargaDaSelecaoPlanejamentoTransporteUseCase',
    gerarOpcoes: '/yapi/APSADM/PlanejamentoTransporteGerarGruposDecisaoPlanejamentoTransporteUseCase',
    gerarCenarios: '/yapi/APSADM/PlanejamentoTransporteGerarCenariosPlanejamentoTransporteUseCase'
};

const lensDefinitions = {
    'estado-municipio': ['estado', 'municipio'],
    'estado-municipio-regiao-bairro': ['estado', 'municipio', 'regiao', 'bairro'],
    'rota-municipio': ['rotaId', 'municipio']
};

const state = {
    contextoId: '',
    lenses: [],
    pedidos: [],
    selected: new Map(),
    activeLensId: 'estado-municipio',
    dataMode: 'simulacao'
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

    document.getElementById('aps-lens-select')?.addEventListener('change', event => {
        state.activeLensId = event.target.value;
        renderTree();
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

    const result = await postUseCase(endpoints.buscarContexto, payload, mockContext);
    const lenses = await postUseCase(endpoints.listarLentes, { contextoId: result.contextoId || '' }, mockLenses);

    state.contextoId = result.contextoId || `local-${Date.now()}`;
    state.lenses = normalizeArray(lenses.lentes || result.lentes || mockLenses().lentes);
    state.pedidos = normalizeArray(result.pedidos || mockPedidos());

    renderLenses();
    renderTree();
    renderSelection();
    setText('aps-context-status', `${state.pedidos.length} pedidos`);
    setText('aps-data-mode', state.dataMode);
}

function renderLenses() {
    const select = document.getElementById('aps-lens-select');
    if (!select) return;

    select.innerHTML = '';
    for (const lens of state.lenses) {
        const option = document.createElement('option');
        option.value = lens.lenteId;
        option.textContent = lens.descricao;
        select.appendChild(option);
    }

    if (!state.lenses.some(l => l.lenteId === state.activeLensId)) {
        state.activeLensId = state.lenses[0]?.lenteId || 'estado-municipio';
    }

    select.value = state.activeLensId;
}

function renderTree() {
    const tree = document.getElementById('aps-lens-tree');
    if (!tree) return;

    const levels = lensDefinitions[state.activeLensId] || lensDefinitions['estado-municipio'];
    const nodes = buildNodes(state.pedidos, levels, 0, '');
    tree.innerHTML = '';
    nodes.forEach(node => tree.appendChild(renderGroupNode(node)));
}

function buildNodes(pedidos, levels, level, parentKey) {
    if (level >= levels.length) {
        return pedidos.map(order => ({ type: 'order', key: order.pedidoId, order }));
    }

    const field = levels[level];
    const groups = new Map();

    for (const order of pedidos) {
        const value = order[field] || 'Sem classificacao';
        if (!groups.has(value)) groups.set(value, []);
        groups.get(value).push(order);
    }

    return Array.from(groups.entries())
        .sort(([a], [b]) => String(a).localeCompare(String(b)))
        .map(([value, groupPedidos]) => ({
            type: 'group',
            key: `${parentKey}/${field}:${value}`,
            label: value,
            level,
            count: groupPedidos.length,
            weight: sum(groupPedidos, 'peso'),
            volume: sum(groupPedidos, 'volume'),
            children: buildNodes(groupPedidos, levels, level + 1, `${parentKey}/${field}:${value}`)
        }));
}

function renderGroupNode(node) {
    const wrapper = document.createElement('div');
    wrapper.className = 'aps-tree-node';

    const row = document.createElement('button');
    row.type = 'button';
    row.className = 'aps-tree-row';
    row.innerHTML = `
        <span>${node.children?.length ? '+' : '-'}</span>
        <span>
            <strong>${escapeHtml(node.label)}</strong>
            <small>${node.count} pedidos | ${formatNumber(node.weight)} kg | ${formatNumber(node.volume)} m3</small>
        </span>
        <small>N${node.level + 1}</small>
    `;

    const children = document.createElement('div');
    children.className = 'aps-tree-children';
    node.children.forEach(child => {
        children.appendChild(child.type === 'group' ? renderGroupNode(child) : renderOrderRow(child.order));
    });

    row.addEventListener('click', () => wrapper.classList.toggle('open'));
    wrapper.appendChild(row);
    wrapper.appendChild(children);
    return wrapper;
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
        container.innerHTML = '<p class="aps-feedback">Selecione grupos e pedidos pela lente ativa.</p>';
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

    const validation = await postUseCase(endpoints.revalidarSelecao, { contextoId: state.contextoId, pedidos }, () => ({ valida: true, mensagem: 'Selecao validada em simulacao.' }));
    if (validation.valida === false) {
        feedback(validation.mensagem || 'Selecao invalida.');
        return;
    }

    const result = await postUseCase(endpoints.criarCarga, { contextoId: state.contextoId, pedidos, tipoVeiculoId: '', observacao: '' }, () => ({ criada: true, cargaId: 'SIM-0001', mensagem: 'Carga simulada criada.' }));
    feedback(result.mensagem || `Carga ${result.cargaId || ''} criada.`);
}

async function generateOptions() {
    const result = await postUseCase(endpoints.gerarOpcoes, { contextoId: state.contextoId, objetivo: 'equilibrar-custo-cubagem', pedidos: selectedRefs() }, () => ({ opcoes: mockOptions() }));
    feedback(`${normalizeArray(result.opcoes).length} opcoes de decisao disponiveis.`);
}

async function generateScenarios() {
    const result = await postUseCase(endpoints.gerarCenarios, { contextoId: state.contextoId, objetivo: 'menor-custo-com-entrega' }, () => ({ cenarios: mockScenarios() }));
    feedback(`${normalizeArray(result.cenarios).length} cenarios completos disponiveis.`);
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

async function postUseCase(endpoint, body, fallbackFactory) {
    try {
        const token = localStorage.getItem('token');
        const response = await fetch(`${environments.urlApi}${endpoint}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                Authorization: `Bearer ${token}`
            },
            body: JSON.stringify(body)
        });

        if (!response.ok) throw new Error(`HTTP ${response.status}`);

        const raw = await response.json();
        state.dataMode = 'api';
        return raw.data || raw.Data || raw;
    } catch (error) {
        state.dataMode = 'simulacao';
        return fallbackFactory();
    }
}

function mockContext() {
    return {
        contextoId: 'ctx-simulado',
        geradoEm: new Date().toISOString(),
        quantidadePedidos: mockPedidos().length,
        quantidadeCargas: 2,
        lentes: mockLenses().lentes,
        pedidos: mockPedidos()
    };
}

function mockLenses() {
    return {
        lentes: [
            { lenteId: 'estado-municipio', descricao: 'Estado > municipio > pedido', niveis: 'estado,municipio,pedido', expansaoRemota: false },
            { lenteId: 'estado-municipio-regiao-bairro', descricao: 'Estado > municipio > regiao > bairro > pedido', niveis: 'estado,municipio,regiao,bairro,pedido', expansaoRemota: false },
            { lenteId: 'rota-municipio', descricao: 'Rota > municipio > pedido', niveis: 'rota,municipio,pedido', expansaoRemota: false }
        ]
    };
}

function mockPedidos() {
    return [
        pedido('ORD-1001', 'Papel Minas', 'MG', 'Contagem', 'Metropolitana', 'Industrial', 'Rota MG Central', 4200, 18.4, 'OK'),
        pedido('ORD-1002', 'Caixas Betim', 'MG', 'Betim', 'Metropolitana', 'Centro', 'Rota MG Central', 2700, 11.2, 'OK'),
        pedido('ORD-1003', 'Embalagens Vale', 'MG', 'Ipatinga', 'Vale do Aco', 'Distrito', 'Rota Vale do Aco', 3100, 12.9, 'Janela curta'),
        pedido('ORD-1004', 'Atacado Campinas', 'SP', 'Campinas', 'Interior', 'Jardim Londres', 'Rota SP Interior', 5200, 23.1, 'OK'),
        pedido('ORD-1005', 'Distribuidora Osasco', 'SP', 'Osasco', 'Grande SP', 'Presidente Altino', 'Rota SP Capital', 2400, 9.8, 'Cliente sensivel'),
        pedido('ORD-1006', 'Nordeste Food', 'BA', 'Feira de Santana', 'Centro Norte', 'Tomba', 'Rota Nordeste 1', 6100, 26.5, 'OK'),
        pedido('ORD-1007', 'Salvador Pack', 'BA', 'Salvador', 'Metropolitana', 'Piraja', 'Rota Nordeste 1', 3300, 13.6, 'OK'),
        pedido('ORD-1008', 'Recife Farma', 'PE', 'Recife', 'Metropolitana', 'Boa Viagem', 'Rota Nordeste 2', 1900, 7.4, 'Financeiro')
    ];
}

function pedido(pedidoId, clienteNome, estado, municipio, regiao, bairro, rotaId, peso, volume, alertasResumo) {
    return {
        pedidoId,
        clienteNome,
        estado,
        municipio,
        regiao,
        bairro,
        rotaId,
        peso,
        volume,
        embarqueAlvo: new Date().toISOString(),
        versaoPlanejamento: `${pedidoId}-v1`,
        alertasResumo
    };
}

function mockOptions() {
    return [
        { opcaoId: 'OP-1', grupoDecisaoId: 'GD-1', peso: 6900, volume: 29.6, custoEstimado: 4300, aderenciaCubagem: 88, riscoResumo: 'baixo', pedidosResumo: 'ORD-1001, ORD-1002' },
        { opcaoId: 'OP-2', grupoDecisaoId: 'GD-1', peso: 7300, volume: 31.3, custoEstimado: 4100, aderenciaCubagem: 91, riscoResumo: 'medio', pedidosResumo: 'ORD-1002, ORD-1003' }
    ];
}

function mockScenarios() {
    return [
        { cenarioId: 'CE-1', descricao: 'Menor custo', objetivo: 'custo', quantidadeCargas: 4, quantidadePedidosNaoAtendidos: 1, custoTotal: 12800, alertasResumo: '1 pedido em risco' },
        { cenarioId: 'CE-2', descricao: 'Maior aderencia de entrega', objetivo: 'entrega', quantidadeCargas: 5, quantidadePedidosNaoAtendidos: 0, custoTotal: 13900, alertasResumo: 'custo maior' }
    ];
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
