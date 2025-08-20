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
                container.className = 'relative group';

                const button = document.createElement('button');
                button.className = 'flex justify-between w-full px-4 py-2 hover:bg-gray-100 text-gray-700';
                button.innerHTML = `
                    ${item.description}
                    <svg class="w-4 h-4 ml-2 transform transition-transform group-hover:rotate-180" 
                        fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" 
                        d="M19 9l-7 7-7-7" />
                    </svg>
                `;

                const submenuList = document.createElement('div');
                submenuList.className = 'hidden md:absolute md:mt-2 md:bg-white md:shadow-lg md:rounded-md md:w-48';

                item.children.forEach(child => {
                    const link = createMenuLink(child.description);
                    link.addEventListener('click', (e) => {
                        e.preventDefault();
                        closeMenu();
                        loadDataCrud(`${environments.urlApi}${child.endpoint}`, child.type);
                    });
                    submenuList.appendChild(link);
                });

                button.addEventListener('click', () => {
                    submenuList.classList.toggle('hidden');
                });

                container.appendChild(button);
                container.appendChild(submenuList);
                menuList.appendChild(container);

            } else {
                // Item normal
                const link = createMenuLink(item.description);
                link.addEventListener('click', (e) => {
                    e.preventDefault();
                    closeMenu();
                    loadDataCrud(`${environments.urlApi}${item.endpoint}`, item.type);
                });
                menuList.appendChild(link);
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

function handleLogout(e) {
    e.preventDefault();
    localStorage.removeItem('token');
    location.hash = '#login';
}
