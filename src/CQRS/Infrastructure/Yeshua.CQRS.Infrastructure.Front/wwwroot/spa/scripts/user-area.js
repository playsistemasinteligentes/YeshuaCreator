export function bindUserArea() {
    const toggle = document.getElementById('user-menu-toggle');
    const panel = document.getElementById('user-menu-panel');
    if (!toggle || !panel) return;

    renderIdentity();
    if (toggle.dataset.bound === 'true') return;

    toggle.dataset.bound = 'true';
    toggle.addEventListener('click', event => {
        event.stopPropagation();
        setPanelOpen(panel.classList.contains('hidden'));
    });

    panel.addEventListener('click', event => event.stopPropagation());
    document.addEventListener('click', closePanel);
    document.addEventListener('keydown', event => {
        if (event.key === 'Escape') closePanel();
    });

    document.getElementById('user-operational-control')?.addEventListener('click', async () => {
        closePanel();
        await openOperationalControl();
    });
}

function setPanelOpen(open) {
    const toggle = document.getElementById('user-menu-toggle');
    const panel = document.getElementById('user-menu-panel');
    if (!toggle || !panel) return;

    panel.classList.toggle('hidden', !open);
    toggle.setAttribute('aria-expanded', open ? 'true' : 'false');
}

function closePanel() {
    setPanelOpen(false);
}

function renderIdentity() {
    const identity = readTokenIdentity();
    const name = document.getElementById('user-menu-name');
    const email = document.getElementById('user-menu-email');

    if (name) name.textContent = identity.name || 'Minha conta';
    if (email) {
        email.textContent = identity.email || '';
        email.classList.toggle('hidden', !identity.email);
    }
}

function readTokenIdentity() {
    try {
        const token = localStorage.getItem('token');
        const segment = token?.split('.')[1];
        if (!segment) return {};

        const normalized = segment.replace(/-/g, '+').replace(/_/g, '/');
        const padded = normalized.padEnd(Math.ceil(normalized.length / 4) * 4, '=');
        const payload = JSON.parse(atob(padded));

        return {
            name: firstValue(payload, [
                'name',
                'unique_name',
                'given_name',
                'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
            ]),
            email: firstValue(payload, [
                'email',
                'preferred_username',
                'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'
            ])
        };
    } catch {
        return {};
    }
}

function firstValue(source, keys) {
    for (const key of keys) {
        if (source?.[key]) return String(source[key]);
    }
    return '';
}

async function openOperationalControl() {
    ensureCustomPageHost();
    const handler = window.yeshuaExtensions?.pages?.['operational-control'];
    if (typeof handler !== 'function') return;

    await handler({
        item: {
            description: 'Controle operacional',
            endpoint: '#operational-control',
            type: 'customPage',
            page: 'operational-control'
        }
    });
}

function ensureCustomPageHost() {
    let host = document.getElementById('custom-page-container');
    if (host) return host;

    host = document.createElement('section');
    host.id = 'custom-page-container';
    document.getElementById('app')?.appendChild(host);
    return host;
}
