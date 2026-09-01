import { loadDataMenu, buildMenu } from './menu.js';
import { buildCrud } from './crud.js';
import { buildRegister } from './viewsScripts/register.js';
import { buildForgot } from './viewsScripts/forgot.js';


export async function handleRouting(hash) {

    const token = localStorage.getItem('token');
    const app = document.getElementById('app');

    const publicRoutes = ['#login', '#register', '#forgot'];
    const route = hash || '#login';

    if (!token && !publicRoutes.includes(route)) {
        location.hash = '#login';
        return;
    }

    if (await tryHandleCustomPage(route)) {
        return;
    }

    try {
        const res = await fetch(`views/${route.replace('#', '')}.html`);
        if (!res.ok) throw new Error('Página não encontrada...');

        const html = await res.text();
        app.innerHTML = html;

        attachEvents(route);
    } catch (err) {
        app.innerHTML = `<p class="text-red-500 text-center mt-10">Erro ao carregar página</p>`;
    }
}

function attachEvents(route) {
    if (route === '#login') {
        const form = document.getElementById('login-form');
        form?.addEventListener('submit', async (e) => {
            e.preventDefault();
            const login = document.getElementById('email')?.value;
            const password = document.getElementById('password')?.value;

            try {
                const res = await fetch(`${environments.urlApi}/Login`, {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ login, password }),
                });

                const data = await res.json();
                if (res.ok && data.token) {
                    localStorage.setItem('token', data.token);
                    const payload = JSON.parse(atob(data.token.split('.')[1]));
                    localStorage.setItem('tokenExp', payload.exp * 1000);
                    location.hash = '#dashboard';
                } else {
                    alert('Login inválido');
                }
            } catch (err) {
                console.error('Erro:', err);
                alert('Erro de conexão.');
            }
        });
    }

    if (route === '#dashboard') {
        buildCrud();
        buildMenu();
        loadDataMenu();
    }

    if (route === '#register') {
        buildRegister();
    }

    if (route === '#forgot') {
        buildForgot();
    }


}

async function tryHandleCustomPage(route) {
    const routeName = String(route || '').replace('#', '');
    const handler = window.yeshuaExtensions?.pages?.[routeName];
    if (typeof handler !== 'function') return false;

    await handler({ route });
    return true;
}
