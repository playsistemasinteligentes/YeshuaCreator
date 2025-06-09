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

        // Limpa o menu
        menuList.innerHTML = '';

        // Adiciona botão de logout
        const logoutLink = createMenuLink('Logout', 'text-red-600 hover:bg-red-100');
        logoutLink.id = 'logout';
        logoutLink.addEventListener('click', handleLogout);
        menuList.appendChild(logoutLink);

        // Adiciona os itens dinâmicos
        menuItems.forEach(item => {
            const link = createMenuLink(item.description);
            link.addEventListener('click', (e) => {
                e.preventDefault();
                closeMenu();
                loadDataCrud(`${environments.urlApi}${item.endpoint}`, item.type);
            });
            menuList.appendChild(link);
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






