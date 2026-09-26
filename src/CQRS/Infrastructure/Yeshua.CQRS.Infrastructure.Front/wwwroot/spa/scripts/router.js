import { loadDataMenu, buildMenu, showModuleLoadError } from './menu.js?v=20260926-userarea01';
import { buildCrud } from './crud.js?v=20260926-userarea01';
import { buildRegister } from './viewsScripts/register.js?v=20260926-auth-central01';
import { buildForgot } from './viewsScripts/forgot.js?v=20260926-auth-central01';
import {
    bindApplicationSelector,
    getAuthenticationApi,
    initializeApplicationContext
} from './application-context.js';
import { bindUserArea } from './user-area.js';


export async function handleRouting(hash) {

    const token = localStorage.getItem('token');
    const app = document.getElementById('app');

    const publicRoutes = ['#login', '#register', '#forgot'];
    const route = hash || '#login';

    // Login, cadastro e recuperacao pertencem ao host compartilhado Central.
    await initializeApplicationContext();

    if (!token && !publicRoutes.includes(route)) {
        location.hash = '#login';
        return;
    }

    if (await tryHandleCustomPage(route)) {
        return;
    }

    let pageRendered = false;
    try {
        const res = await fetch(`views/${route.replace('#', '')}.html`);
        if (!res.ok) throw new Error('Página não encontrada...');

        const html = await res.text();
        app.innerHTML = html;
        pageRendered = true;

        await attachEvents(route);
    } catch (err) {
        console.error('Falha ao carregar rota.', err);
        if (pageRendered && route === '#dashboard') {
            showModuleLoadError(err);
            return;
        }

        app.innerHTML = `
            <main class="mx-auto mt-16 max-w-lg px-4">
                <section class="border border-red-200 bg-white p-6 shadow-sm">
                    <h1 class="text-lg font-semibold text-gray-900">Não foi possível carregar esta página</h1>
                    <p class="mt-2 text-sm text-gray-600">A navegação continua disponível. Tente novamente.</p>
                    <button type="button" id="retry-route" class="mt-4 bg-blue-600 px-4 py-2 text-white hover:bg-blue-700" title="Tentar novamente">
                        <i class="fa-solid fa-rotate-right mr-2"></i>Tentar novamente
                    </button>
                </section>
            </main>`;
        document.getElementById('retry-route')?.addEventListener('click', () => location.reload());
    }
}

async function attachEvents(route) {
    if (route === '#login') {
        const form = document.getElementById('login-form');
        form?.addEventListener('submit', async (e) => {
            e.preventDefault();
            const login = document.getElementById('email')?.value;
            const password = document.getElementById('password')?.value;

            try {
                const res = await fetch(`${getAuthenticationApi()}/Login`, {
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
        await initializeApplicationContext(true);
        bindApplicationSelector();
        bindUserArea();
        buildCrud();
        buildMenu();
        await loadDataMenu();
        if (typeof window.yeshuaExtensions?.dashboard === 'function') {
            await window.yeshuaExtensions.dashboard();
        }
    }

    if (route === '#register') {
        buildRegister();
    }

    if (route === '#forgot') {
        buildForgot();
    }


}

async function tryHandleCustomPage(route) {
    if (window.yeshuaAppExtensionReady) {
        await window.yeshuaAppExtensionReady;
    }

    const routeName = String(route || '').replace('#', '');
    const handler = window.yeshuaExtensions?.pages?.[routeName];
    if (typeof handler !== 'function') return false;

    await handler({ route });
    return true;
}
