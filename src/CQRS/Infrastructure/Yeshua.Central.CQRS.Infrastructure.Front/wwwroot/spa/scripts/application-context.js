const storageKey = 'yeshua.activeApplication';

let availableApplications = [];
let activeApplication = null;
let authenticationSession = null;

export async function initializeApplicationContext(forceReload = false) {
    if (availableApplications.length > 0 && !forceReload) {
        applyApplication(activeApplication);
        return activeApplication;
    }

    const catalog = await loadApplicationCatalog();
    const central = catalog.find(item =>
        String(item.application).toUpperCase() === 'CENTRAL') || catalog[0] || null;
    environments.authenticationApi = central?.apiBasePath || '/yapi';

    availableApplications = filterAuthorizedApplications(catalog, central);
    const requestedName = new URLSearchParams(location.search).get('app')?.trim().toUpperCase();
    const requestedApplication = localStorage.getItem('token')
        ? availableApplications.find(item => String(item.application).toUpperCase() === requestedName)
        : null;
    const selectedName = localStorage.getItem(storageKey);
    activeApplication = requestedApplication
        || availableApplications.find(item => item.application === selectedName)
        || central
        || availableApplications[0]
        || null;

    if (requestedApplication) {
        localStorage.setItem(storageKey, requestedApplication.application);
        const url = new URL(location.href);
        url.searchParams.delete('app');
        history.replaceState(null, '', url);
    }

    applyApplication(activeApplication);
    return activeApplication;
}

export function getAuthenticationApi() {
    return environments.authenticationApi || '/yapi';
}

// Application sessions remain active in localStorage. Central services use the
// existing getMenu session exchange, cached only in memory for that source token.
export async function getAuthenticationToken() {
    const source = localStorage.getItem('token');
    if (!source) throw new Error('Sua sessão expirou. Entre novamente.');
    const claims = sessionClaims(source);
    if (String(claims.tokenOrigin || '').toLowerCase() !== 'application') return source;

    let entry = authenticationSession;
    if (!entry || entry.source !== source || entry.expiresAt <= Date.now()) {
        entry = { source, expiresAt: Infinity, promise: null };
        authenticationSession = entry;
        entry.promise = (async () => {
            const response = await fetch(`${getAuthenticationApi()}/getMenu`, {
                headers: { Authorization: `Bearer ${source}` }, cache: 'no-store'
            }).catch(() => { throw new Error('Não foi possível acessar a Central. Tente novamente.'); });
            if (!response.ok) throw new Error(response.status === 401
                ? 'Sua sessão expirou. Entre novamente.'
                : response.status === 403 ? 'Seu usuário não tem acesso à Central para abrir chamados.'
                : 'Não foi possível preparar a sessão da Central. Tente novamente.');
            const token = response.headers.get('X-Yeshua-Application-Token');
            if (!token) throw new Error('A Central não confirmou sua sessão. Entre novamente.');
            const central = sessionClaims(token);
            const expiresAt = Number(central.exp) * 1000;
            if (central.tokenOrigin !== 'Central' || central.application !== 'Central'
                || !/^[1-9]\d*:[1-9]\d*$/.test(sessionOwner(claims))
                || sessionOwner(central) !== sessionOwner(claims)
                || !Number.isFinite(expiresAt) || expiresAt <= Date.now())
                throw new Error('A Central não confirmou sua sessão. Entre novamente.');
            entry.expiresAt = expiresAt;
            return token;
        })();
    }
    try {
        const token = await entry.promise;
        if (localStorage.getItem('token') !== source)
            throw new Error('Sua sessão mudou. Abra a ajuda novamente.');
        return token;
    } catch (error) {
        if (authenticationSession === entry) authenticationSession = null;
        throw error;
    }
}

function sessionClaims(token) {
    try {
        const claims = JSON.parse(decodeBase64Url(token.split('.')[1]));
        if (!claims || typeof claims !== 'object' || Array.isArray(claims)) throw new Error();
        return claims;
    }
    catch { throw new Error('Sua sessão é inválida. Entre novamente.'); }
}

function sessionOwner(claims) {
    return `${claims.tenantId ?? claims.tenantID ?? claims.TenantID ?? ''}:${claims.userId ?? claims.nameid ?? claims.sub ?? claims['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'] ?? ''}`;
}

export function bindApplicationSelector() {
    const selector = document.getElementById('application-selector');
    if (!selector) return;

    selector.innerHTML = '';
    availableApplications.forEach(application => {
        const option = document.createElement('option');
        option.value = application.application;
        option.textContent = application.title || application.application;
        option.selected = application.application === activeApplication?.application;
        selector.appendChild(option);
    });

    selector.classList.toggle('hidden', availableApplications.length <= 1);
    selector.addEventListener('change', () => {
        localStorage.setItem(storageKey, selector.value);
        const url = new URL(location.href);
        url.hash = 'dashboard';
        history.replaceState(null, '', url);
        location.reload();
    });
}

async function loadApplicationCatalog() {
    try {
        const response = await fetch('/applications.json', { cache: 'no-store' });
        if (!response.ok) return [];
        const catalog = await response.json();
        return Array.isArray(catalog) ? catalog : [];
    } catch {
        return [];
    }
}

function filterAuthorizedApplications(catalog, central) {
    const tokenCatalogs = readTokenCatalogs();
    if (tokenCatalogs.size === 0) {
        return central ? [central] : catalog;
    }

    return catalog.filter(application => {
        if (application === central) return true;
        return tokenCatalogs.has(String(application.application).toUpperCase());
    });
}

function readTokenCatalogs() {
    const catalogs = new Set();
    const token = localStorage.getItem('token');
    if (!token) return catalogs;

    try {
        const payload = JSON.parse(decodeBase64Url(token.split('.')[1]));
        const claim = payload.userCatalogs ?? payload.UserCatalogs ?? '';
        const values = Array.isArray(claim) ? claim : String(claim).split(',');
        values
            .map(value => String(value).trim().toUpperCase())
            .filter(Boolean)
            .forEach(value => catalogs.add(value));
    } catch (error) {
        console.error('Nao foi possivel ler os catalogos do token.', error);
    }

    return catalogs;
}

function decodeBase64Url(value) {
    const normalized = value.replace(/-/g, '+').replace(/_/g, '/');
    const padded = normalized.padEnd(Math.ceil(normalized.length / 4) * 4, '=');
    return decodeURIComponent(atob(padded).split('').map(character =>
        `%${character.charCodeAt(0).toString(16).padStart(2, '0')}`).join(''));
}

function applyApplication(application) {
    environments.urlApi = application?.apiBasePath || '/yapi';
    window.yeshuaActiveApplication = application;

    if (application?.customAssetsPath && typeof window.yeshuaLoadApplicationExtension === 'function') {
        window.yeshuaLoadApplicationExtension(application.customAssetsPath);
    }
}
