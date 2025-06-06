import { loadMenu } from './scripts/menu.js';

export async function handleRouting(hash) {
    const token = localStorage.getItem('token');
    const app = document.getElementById('app');
    const publicRoutes = ['#login', '#register', '#forgot'];
    const route = hash || '#login';

    // Redireciona para login se tentar acessar rota protegida sem token
    if (!token && !publicRoutes.includes(route)) {
        location.hash = '#login';
        return;
    }

    // Carrega a view HTML da rota
    try {
        const res = await fetch(`views/${route.replace('#', '')}.html`);
        if (!res.ok) throw new Error('Página não encontrada.');

        const html = await res.text();
        app.innerHTML = html;

        attachEvents(route);
    } catch (err) {
        console.error('Erro ao carregar view:', err);
        app.innerHTML = `<p class="text-red-500 text-center mt-10">Erro ao carregar página.</p>`;
    }
}

function attachEvents(route) {
    if (route === '#login') {
        const form = document.getElementById('login-form');

        if (form) {
            form.addEventListener('submit', async (e) => {
                e.preventDefault(); // evita reload

                const login = document.getElementById('email').value.trim();
                const password = document.getElementById('password').value;

                if (!login || !password) {
                    //alert('Por favor, preencha email e senha');
                    //return;
                }

                try {
                    const res = await fetch(`${environments.urlApi}/Login`, {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify({ login, password }),
                    });

                    const data = await res.json();

                    if (res.ok && data.token) {
                        localStorage.setItem('token', data.token);
                        location.hash = '#dashboard';
                    } else {
                        alert(data.message || 'Login inválido');
                    }
                } catch (err) {
                    //console.error('Erro de conexão:', err);
                    Alert(environments.urlApi);
                }
            });
        }
    }

    if (route === '#dashboard') {
        loadMenu();
        // Você pode adicionar outros eventos do dashboard aqui
    }

    if (route === '#register') {
        // Eventos para a tela de cadastro, se quiser
    }

    if (route === '#forgot') {
        // Eventos para recuperação de senha
    }
}
