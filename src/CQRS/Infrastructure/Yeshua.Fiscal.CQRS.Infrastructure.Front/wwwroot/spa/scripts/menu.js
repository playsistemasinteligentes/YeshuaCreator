import { loadDataCrud } from './crud.js';

export function buildMenu() {
    const btnToggleMenu = document.getElementById('btn-toggle-menu');
    const menu = document.getElementById('menu');

    btnToggleMenu?.addEventListener('click', () => {
        menu.classList.toggle('hidden');
    });

    // Ativa logout também no botão do header
    const logoutHeader = document.getElementById('logout-header');
    if (logoutHeader) {
        logoutHeader.addEventListener('click', handleLogout);
    }
}

export async function loadDataMenu() {
    try {
        const token = localStorage.getItem('token');
        const response = await fetch(`${environments.urlApi}/getMenu`, {
            headers: { Authorization: `Bearer ${token}` }
        });

        if (!response.ok) throw new Error('Token inválido ou expirado');

        const menuItems = extendMenuItems(await response.json());
        const menuList = document.getElementById('menu');
        if (!menuList) return;

        // Limpa menu
        menuList.innerHTML = '';


        menuItems.forEach(item => {
            if (item.children && item.children.length > 0) {
                // Submenu
                const container = document.createElement('div');
                container.className = 'relative';

                const button = document.createElement('button');
                button.className = 'menu-toggle flex justify-between w-full px-4 py-2 text-white hover:bg-blue-700 rounded';

                button.innerHTML = `
                    ${item.description}
                    <svg class="w-4 h-4 ml-2 transform transition-transform" 
                        fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" 
                        d="M19 9l-7 7-7-7" />
                    </svg>
                `;

                const submenuList = document.createElement('div');
                submenuList.className = 'submenu hidden md:absolute md:mt-2 md:bg-blue-600 md:shadow-lg md:rounded-md md:min-w-64';
                applySubmenuPanelStyle(submenuList);

                submenuList.appendChild(createSubmenuSearch(submenuList));

                item.children.forEach(child => {
                    submenuList.appendChild(createSubmenuChild(child));
                });

                button.addEventListener('click', (e) => {
                    e.stopPropagation(); // não deixa o clique subir para o document
                    const isOpen = !submenuList.classList.contains('hidden');

                    // fecha todos os outros submenus
                    closeAllSubmenus();

                    if (!isOpen) {
                        submenuList.classList.remove('hidden');
                        button.querySelector('svg')?.classList.add('rotate-180');
                    }
                });

                container.appendChild(button);
                container.appendChild(submenuList);
                menuList.appendChild(container);

            } else {
                // Item normal
                const link = createMenuLink(item.description);
                link.addEventListener('click', (e) => {
                    e.preventDefault();
                    closeMenu();          // mobile
                    closeAllSubmenus();   // desktop
                    openMenuItem(item);
                });
                menuList.appendChild(link);
            }
        });

        // Fecha submenus se clicar fora do menu
        document.addEventListener('click', (e) => {
            if (!e.target.closest('#menu')) {
                closeAllSubmenus();
            }
        });

    } catch (error) {
        erroRequestResponse(error);
    }
}

async function openMenuItem(item) {
    if (isCustomPage(item)) {
        await openCustomPage(item);
        return;
    }

    closeCustomPage();
    loadDataCrud(`${environments.urlApi}${item.endpoint}`, item.type);
}

function isCustomPage(item) {
    const type = String(item?.type || '').toLowerCase();
    return type === 'custompage' || type === 'custom-page' || type === 'custon';
}

async function openCustomPage(item) {
    const pages = window.yeshuaExtensions?.pages || {};
    const pageKey = item.page || item.endpoint || item.description;
    const handler = pages[pageKey] || pages[String(pageKey).replace(/^#/, '')];

    if (typeof handler !== 'function') {
        console.error(`Custom page handler not found: ${pageKey}`);
        return;
    }

    await handler({ item });
}

function closeCustomPage() {
    const customPage = document.getElementById('custom-page-container');
    if (customPage) {
        customPage.classList.add('hidden');
        customPage.innerHTML = '';
    }
}

function extendMenuItems(menuItems) {
    const menuExtension = window.yeshuaExtensions?.menu;
    if (typeof menuExtension?.extend !== 'function') return menuItems;

    try {
        const extended = menuExtension.extend(menuItems);
        return Array.isArray(extended) ? extended : menuItems;
    } catch (error) {
        console.error('Yeshua menu extension failed', error);
        return menuItems;
    }
}

function createMenuLink(text, extraClasses = '', isSubmenu = false) {
    const link = document.createElement('a');
    link.href = '#';
    link.textContent = text;

    if (isSubmenu) {
        // azul para submenu, tanto mobile quanto desktop
        link.className = `block px-4 py-2 text-left text-white hover:bg-blue-700 whitespace-normal break-words ${extraClasses}`;
    } else {
        link.className = `block px-4 py-2 text-left text-white hover:bg-blue-700 rounded whitespace-normal break-words ${extraClasses}`;
    }

    return link;
}

function createSubmenuChild(item) {
    if (item.children && item.children.length > 0) {
        const section = document.createElement('details');
        section.className = 'border-t border-blue-500 first:border-t-0';
        section.dataset.menuGroup = 'true';
        section.dataset.menuSearchText = normalizeSearchText(item.description);

        const summary = document.createElement('summary');
        summary.className = 'flex w-full cursor-pointer list-none items-center justify-between gap-3 px-4 py-2 text-left text-white hover:bg-blue-700';

        const text = document.createElement('span');
        text.className = 'font-semibold whitespace-normal break-words';
        text.textContent = item.description;

        const indicator = document.createElement('span');
        indicator.className = 'text-xs';
        indicator.textContent = '+';
        indicator.dataset.menuGroupIndicator = 'true';

        const children = document.createElement('div');
        children.className = 'bg-blue-700';
        children.dataset.menuGroupContent = 'true';

        item.children.forEach(child => {
            children.appendChild(createSubmenuChildLink(child, 'pl-7 text-sm'));
        });

        summary.addEventListener('click', (e) => {
            e.stopPropagation();
        });

        section.addEventListener('toggle', () => {
            indicator.textContent = section.open ? '-' : '+';
        });

        summary.appendChild(text);
        summary.appendChild(indicator);
        section.appendChild(summary);
        section.appendChild(children);

        return section;
    }

    return createSubmenuChildLink(item);
}

function createSubmenuChildLink(item, extraClasses = '') {
    const link = createMenuLink(item.description, extraClasses, true);
    link.dataset.menuLeaf = 'true';
    link.dataset.menuSearchText = getMenuSearchText(item);

    link.addEventListener('click', (e) => {
        e.preventDefault();
        closeMenu();          // fecha menu no mobile
        closeAllSubmenus();   // fecha submenu no desktop
        openMenuItem(item);
    });

    return link;
}

function createSubmenuSearch(submenuList) {
    const wrapper = document.createElement('div');
    wrapper.className = 'sticky top-0 z-10 bg-blue-600 p-2';

    const input = document.createElement('input');
    input.type = 'search';
    input.placeholder = 'Pesquisar...';
    input.autocomplete = 'off';
    input.className = 'w-full rounded border border-blue-400 bg-white px-3 py-2 text-sm text-gray-900 outline-none focus:ring-2 focus:ring-white';
    input.dataset.menuSearchInput = 'true';

    input.addEventListener('click', (e) => e.stopPropagation());
    input.addEventListener('keydown', (e) => e.stopPropagation());
    input.addEventListener('input', () => {
        filterSubmenu(submenuList, input.value);
    });

    wrapper.appendChild(input);
    return wrapper;
}

function filterSubmenu(submenuList, value) {
    if (!submenuList) return;

    const query = normalizeSearchText(value);
    const hasQuery = query.length > 0;

    submenuList.querySelectorAll('[data-menu-leaf="true"]').forEach(leaf => {
        const visible = !hasQuery || leaf.dataset.menuSearchText.includes(query);
        leaf.classList.toggle('hidden', !visible);
    });

    submenuList.querySelectorAll('[data-menu-group="true"]').forEach(group => {
        const groupMatches = hasQuery && group.dataset.menuSearchText.includes(query);
        const leaves = Array.from(group.querySelectorAll('[data-menu-leaf="true"]'));
        let hasVisibleChild = false;

        leaves.forEach(leaf => {
            const visible = !hasQuery || groupMatches || leaf.dataset.menuSearchText.includes(query);
            leaf.classList.toggle('hidden', !visible);
            hasVisibleChild = hasVisibleChild || visible;
        });

        group.classList.toggle('hidden', hasQuery && !groupMatches && !hasVisibleChild);

        const content = group.querySelector('[data-menu-group-content="true"]');
        const indicator = group.querySelector('[data-menu-group-indicator="true"]');
        if (content && indicator) {
            group.open = hasQuery;
            indicator.textContent = hasQuery ? '-' : '+';
        }
    });
}

function getMenuSearchText(item) {
    const values = [item?.description, item?.endpoint, item?.page, item?.type];

    if (Array.isArray(item?.children)) {
        item.children.forEach(child => values.push(getMenuSearchText(child)));
    }

    return normalizeSearchText(values.filter(Boolean).join(' '));
}

function normalizeSearchText(value) {
    return String(value || '')
        .normalize('NFD')
        .replace(/[\u0300-\u036f]/g, '')
        .toLowerCase();
}

function applySubmenuPanelStyle(submenuList) {
    submenuList.style.maxHeight = 'calc(100vh - 5rem)';
    submenuList.style.overflowY = 'auto';
    submenuList.style.minWidth = '18rem';
    submenuList.style.maxWidth = 'min(30rem, calc(100vw - 2rem))';
    submenuList.style.zIndex = '50';
}



export function toggleMenu() {
    const menu = document.getElementById('menu');
    if (menu) {
        menu.classList.toggle('hidden');
    }
}

export function closeMenu() {
    const menu = document.getElementById('menu');
    if (menu && !menu.classList.contains('hidden')) {
        menu.classList.add('hidden');
    }
}

function closeAllSubmenus() {
    document.querySelectorAll('#menu [data-menu-search-input="true"]').forEach(input => {
        if (input.value) {
            input.value = '';
            filterSubmenu(input.closest('.submenu'), '');
        }
    });
    document.querySelectorAll('#menu .submenu').forEach(s => s.classList.add('hidden'));
    document.querySelectorAll('#menu [data-menu-group="true"]').forEach(s => s.open = false);
    document.querySelectorAll('#menu [data-menu-group-indicator="true"]').forEach(i => i.textContent = '+');
    document.querySelectorAll('#menu .menu-toggle svg').forEach(i => i.classList.remove('rotate-180'));
}

function handleLogout(e) {
    e.preventDefault();
    localStorage.removeItem('token');
    location.hash = '#login';
}
