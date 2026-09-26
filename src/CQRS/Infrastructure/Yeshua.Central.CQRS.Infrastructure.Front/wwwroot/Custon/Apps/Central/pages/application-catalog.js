const hostId = 'custom-page-container';
const cssId = 'central-application-catalog-css';

export async function renderApplicationCatalog() {
    ensureCss();
    const host = ensureHost();
    const crud = document.getElementById('crud-container');
    crud?.classList.add('hidden');

    host.innerHTML = await fetch('/Custon/Apps/Central/pages/application-catalog.html')
        .then(response => response.text());
    host.classList.remove('hidden');

    const applications = await fetch('/applications.json', { cache: 'no-store' })
        .then(response => response.json());
    const grantedCatalogs = readTokenCatalogs();
    const list = document.getElementById('application-catalog-list');

    applications
        .filter(application => String(application.application).toUpperCase() !== 'CENTRAL')
        .forEach(application => list.appendChild(createApplicationItem(application, grantedCatalogs)));
}

function ensureHost() {
    let host = document.getElementById(hostId);
    if (host) return host;

    host = document.createElement('section');
    host.id = hostId;
    const app = document.getElementById('app');
    (app || document.body).appendChild(host);
    return host;
}

function createApplicationItem(application, grantedCatalogs) {
    const enabled = grantedCatalogs.has(String(application.application).toUpperCase());
    const item = document.createElement('article');
    item.className = 'application-catalog-item';
    item.innerHTML = `
        <h2>${escapeHtml(application.title || application.application)}</h2>
        <p>${enabled ? 'Disponivel para sua organizacao.' : 'Disponivel no catalogo.'}</p>
    `;

    const button = document.createElement('button');
    button.type = 'button';
    button.textContent = enabled ? 'Entrar' : 'Adicionar';
    button.addEventListener('click', () => {
        if (enabled) {
            enterApplication(application);
            return;
        }

        activateApplication(button, application);
    });
    item.appendChild(button);
    return item;
}

function enterApplication(application) {
    localStorage.setItem('yeshua.activeApplication', application.application);
    location.reload();
}

async function activateApplication(button, application) {
    button.disabled = true;
    button.textContent = 'Adicionando...';
    const token = localStorage.getItem('token');

    try {
        const response = await fetch(`${environments.authenticationApi}/Central/CatalogoAdicionarAplicativoAoTenantUseCase`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                Authorization: `Bearer ${token}`
            },
            body: JSON.stringify({ aplicativo: application.application })
        });
        if (!response.ok) throw new Error(`Falha ao adicionar ${application.title || application.application}.`);

        document.getElementById('application-catalog-status').textContent =
            'Aplicativo adicionado. Entre novamente para atualizar suas permissoes.';
        button.textContent = 'Adicionado';
    } catch (error) {
        document.getElementById('application-catalog-status').textContent = error.message;
        button.disabled = false;
        button.textContent = 'Tentar novamente';
    }
}

function readTokenCatalogs() {
    const catalogs = new Set();
    const token = localStorage.getItem('token');
    if (!token) return catalogs;

    try {
        const value = token.split('.')[1].replace(/-/g, '+').replace(/_/g, '/');
        const padded = value.padEnd(Math.ceil(value.length / 4) * 4, '=');
        const payload = JSON.parse(atob(padded));
        String(payload.userCatalogs || '')
            .split(',')
            .map(catalog => catalog.trim().toUpperCase())
            .filter(Boolean)
            .forEach(catalog => catalogs.add(catalog));
    } catch {
        return catalogs;
    }

    return catalogs;
}

function ensureCss() {
    if (document.getElementById(cssId)) return;
    const link = document.createElement('link');
    link.id = cssId;
    link.rel = 'stylesheet';
    link.href = '/Custon/Apps/Central/pages/application-catalog.css?v=20260924-central01';
    document.head.appendChild(link);
}

function escapeHtml(value) {
    const element = document.createElement('div');
    element.textContent = value;
    return element.innerHTML;
}
