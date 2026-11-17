import { getAuthenticationApi } from './application-context.js';

// A mesma Promise (inclusive em falha) atende todas as remontagens da SPA.
let installedVersion;
function loadInstalledVersion() {
    return installedVersion ??= fetch(`${getAuthenticationApi()}/version`, { cache: 'no-store' })
        .then(async response => {
            if (!response.ok) throw new Error('Versão indisponível');
            const data = await response.json();
            if (!/^\d+\.\d+\.\d+$/.test(data.version)) throw new Error('Versão inválida');
            return `Versão ${data.version}`;
        })
        .catch(() => 'Versão indisponível');
}

export async function bindReleaseFooter() {
    const footer = document.getElementById('release-footer');
    if (!footer || footer.dataset.bound) return;
    footer.dataset.bound = 'true';
    footer.textContent = await loadInstalledVersion();
}
