window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.menu = window.yeshuaExtensions.menu || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};

window.yeshuaExtensions.menu.extend = function extendApsAdmMenu(menuItems) {
    const items = Array.isArray(menuItems) ? menuItems : [];
    const apsAdm = items.find(item => item?.id === 'APSADM') || items[0];
    if (!apsAdm) return items;

    apsAdm.children = Array.isArray(apsAdm.children) ? apsAdm.children : [];

    const exists = apsAdm.children.some(child => child?.page === 'planejamento-transporte');
    if (!exists) {
        apsAdm.children.unshift({
            description: 'Planejamento Transporte',
            type: 'customPage',
            page: 'planejamento-transporte'
        });
    }

    return items;
};

window.yeshuaExtensions.pages['planejamento-transporte'] = async function openPlanejamentoTransporte() {
    const page = await import('/Custon/pages/planejamento-transporte.js');
    await page.renderPlanejamentoTransporte();
};

function apsNormalizeName(value) {
    return String(value || '').toLowerCase();
}

function apsGetFormValue(fieldId) {
    const input = document.getElementById(`insert-${fieldId}`);
    if (!input) return '';

    return input.dataset?.id || input.value || '';
}

function apsCreateOpenButton(label, entityName, filterField, getValue, payload) {
    const button = document.createElement('button');
    button.type = 'button';
    button.textContent = label;
    button.className = 'px-3 py-2 border rounded text-sm text-gray-700 hover:bg-gray-100 disabled:opacity-40';

    button.onclick = async () => {
        const value = getValue();
        const filters = value ? { [filterField]: value } : {};

        await payload.openCrudEntity(entityName, filters);
    };

    return button;
}

function apsRenderRoteiroActions(payload) {
    if (apsNormalizeName(payload.metadata?.entityDescription) !== 'roteiro') return;

    const formGroup = payload.formGroup || document.getElementById('form-group');
    if (!formGroup || document.getElementById('aps-adm-roteiro-actions')) return;

    const panel = document.createElement('div');
    panel.id = 'aps-adm-roteiro-actions';
    panel.className = 'mt-4 border rounded bg-gray-50 p-3';

    const header = document.createElement('div');
    header.className = 'text-sm font-semibold text-gray-700 mb-3';
    header.textContent = 'APS Roteiro';

    const actions = document.createElement('div');
    actions.className = 'flex flex-wrap gap-2';

    actions.appendChild(apsCreateOpenButton('Produto', 'Produto', 'id', () => apsGetFormValue('produtoid'), payload));
    actions.appendChild(apsCreateOpenButton('Maquina', 'Maquina', 'id', () => apsGetFormValue('maquinaid'), payload));
    actions.appendChild(apsCreateOpenButton('Grupo', 'GrupoMaquina', 'id', () => apsGetFormValue('grupomaquinaid'), payload));
    actions.appendChild(apsCreateOpenButton('Template', 'TemplateDeTestes', 'id', () => apsGetFormValue('templatedetestesid'), payload));

    panel.appendChild(header);
    panel.appendChild(actions);
    formGroup.appendChild(panel);
}

window.yeshuaExtensions.crud = {
    ...(window.yeshuaExtensions.crud || {}),
    afterRenderForm: apsRenderRoteiroActions,
    afterFillForm: apsRenderRoteiroActions
};
