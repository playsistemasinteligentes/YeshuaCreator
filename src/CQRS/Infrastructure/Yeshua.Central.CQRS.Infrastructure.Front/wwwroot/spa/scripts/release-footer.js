import { getAuthenticationApi } from './application-context.js';

// A mesma Promise (inclusive em falha) atende todas as remontagens da SPA.
let installedVersion;
export function loadInstalledVersion() {
    return installedVersion ??= fetch(`${getAuthenticationApi()}/version`, { cache: 'no-store' })
        .then(async response => {
            if (!response.ok) throw new Error('Versão indisponível');
            const data = await response.json();
            const version = typeof data.version === 'string' ? data.version.split('+')[0] : '';
            if (!/^\d+\.\d+\.\d+$/.test(version)) throw new Error('Versão inválida');
            return version;
        })
        .catch(() => null);
}

export function preloadInstalledVersion() { void loadInstalledVersion(); }
