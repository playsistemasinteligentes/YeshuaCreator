export async function handleRouting(hash) {
    const token = localStorage.getItem('token');
    const app = document.getElementById('app');

    const publicRoutes = ['#login', '#register', '#forgot'];
    const route = hash || '#login';

    // Redireciona se não estiver autenticado e tentar acessar rota protegida
    if (!token && !publicRoutes.includes(route)) {
        location.hash = '#login';
        return;
    }

    // Carrega a view correspondente
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
        document.getElementById('btn-login')?.addEventListener('click', async () => {
            const email = document.getElementById('email').value;
            const password = document.getElementById('password').value;

            try {
                const res = await fetch(`${environments.urlApi}/Login`, {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ email, password }),
                });

                const data = await res.json();
                if (res.ok && data.token) {
                    localStorage.setItem('token', data.token);
                    location.hash = '#dashboard';
                } else {
                    alert('Login inválido');
                }
            } catch {
                alert('Erro de conexão');
            }
        });
    }

    if (route === '#dashboard') {
        document.getElementById('btn-logout')?.addEventListener('click', () => {
            localStorage.removeItem('token');
            location.hash = '#login';
        });
    }

    // Aqui você pode adicionar attachEvents para outras páginas também
}
