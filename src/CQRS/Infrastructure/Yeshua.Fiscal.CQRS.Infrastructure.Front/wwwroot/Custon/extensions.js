window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.menu = window.yeshuaExtensions.menu || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};

window.yeshuaExtensions.pages['contingencia-fiscal'] = async function openContingenciaFiscal() {
    const page = await import('/Custon/pages/contingencia-fiscal.js?v=20260910-cont20');
    await page.renderContingenciaFiscal();
};

window.yeshuaExtensions.menu.extend = function extendFiscalMenu(menuItems) {
    const items = Array.isArray(menuItems) ? menuItems : [];
    const module = findOrCreateModule(items, 'Contingencia  Fiscal', 'Contingencia Fiscal');
    const group = findOrCreateGroup(module, 'Contingencia Fiscal');

    if (!group.children.some(child => child.page === 'contingencia-fiscal')) {
        group.children.unshift({
            description: 'Nova Contingencia Fiscal',
            endpoint: '#contingencia-fiscal',
            type: 'customPage',
            page: 'contingencia-fiscal',
            scope: 'fiscal.contingencia.tela',
            children: []
        });
    }

    return items;
};

function findOrCreateModule(items, generatedTitle, normalizedTitle) {
    let module = items.find(item =>
        normalizeText(item.description) === normalizeText(generatedTitle)
        || normalizeText(item.description) === normalizeText(normalizedTitle));

    if (!module) {
        module = { description: normalizedTitle, children: [] };
        items.push(module);
    }

    module.children = Array.isArray(module.children) ? module.children : [];
    return module;
}

function findOrCreateGroup(module, title) {
    let group = module.children.find(item => normalizeText(item.description) === normalizeText(title));

    if (!group) {
        group = { description: title, type: 'menuGroup', children: [] };
        module.children.push(group);
    }

    group.children = Array.isArray(group.children) ? group.children : [];
    return group;
}

function normalizeText(value) {
    return String(value || '').replace(/\s+/g, ' ').trim().toLowerCase();
}
