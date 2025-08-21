import { loadDataCrud } from './crud.js';

export function buildMenu() {
    const btnToggleMenu = document.getElementById('btn-toggle-menu');
    const menu = document.getElementById('menu');

    btnToggleMenu?.addEventListener('click', () => {
        menu.classList.toggle('hidden');
    });
}

export async function loadDataMenu() {
    try {
        const token = localStorage.getItem('token');
        const response = await fetch(`${environments.urlApi}/getMenu`, {
            headers: { Authorization: `Bearer ${token}` }
        });

        if (!response.ok) throw new Error('Token inválido ou expirado');

        const menuItems = await response.json();
        const menuList = document.getElementById('menu');
        if (!menuList) return;

        // Limpa menu
        menuList.innerHTML = '';

        // Botão logout
        const logoutLink = createMenuLink('Logout');
        logoutLink.id = 'logout';
        logoutLink.addEventListener('click', handleLogout);
        menuList.appendChild(logoutLink);

        menuItems.forEach(item => {
            if (item.children && item.children.length > 0) {
                // Submenu
                const container = document.createElement('div');
                container.className = 'relative';

                const button = document.createElement('button');
                button.className = 'menu-toggle flex justify-between w-full px-4 py-2 hover:bg-gray-100 text-gray-700';
                button.innerHTML = `
                    ${item.description}
                    <svg class="w-4 h-4 ml-2 transform transition-transform" 
                        fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" 
                        d="M19 9l-7 7-7-7" />
                    </svg>
                `;

                const submenuList = document.createElement('div');
                submenuList.className = 'submenu hidden md:absolute md:mt-2 md:bg-white md:shadow-lg md:rounded-md md:w-48';

                item.children.forEach(child => {
                    const link = createMenuLink(child.description);
                    link.addEventListener('click', (e) => {
                        e.preventDefault();
                        closeMenu();          // fecha menu no mobile
                        closeAllSubmenus();   // fecha submenu no desktop
                        loadDataCrud(`${environments.urlApi}${child.endpoint}`, child.type);
                    });
                    submenuList.appendChild(link);
                });

                button.addEventListener('click', (e) => {
                    e.stopPropagation(); // não deixa o clique subir para o document
                    const isOpen = !submenuList.classList.contains('hidden');

                    // fecha todos os outros submenus
                    closeAllSubmenus();

                    if (!isOpen) {
                        submenuList.classList.remove('hidden');
                        button.querySelector('svg').classList.add('rotate-180');
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
                    loadDataCrud(`${environments.urlApi}${item.endpoint}`, item.type);
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

function createMenuLink(text, extraClasses = '') {
    const link = document.createElement('a');
    link.href = '#';
    link.textContent = text;
    link.className = `block px-4 py-2 hover:bg-gray-200 ${extraClasses}`;
    return link;
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
    document.querySelectorAll('#menu .submenu').forEach(s => s.classList.add('hidden'));
    document.querySelectorAll('#menu .menu-toggle svg').forEach(i => i.classList.remove('rotate-180'));
}

function handleLogout(e) {
    e.preventDefault();
    localStorage.removeItem('token');
    location.hash = '#login';
}
