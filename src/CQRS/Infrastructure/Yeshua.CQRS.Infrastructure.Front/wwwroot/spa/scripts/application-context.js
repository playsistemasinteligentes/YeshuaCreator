const storageKey = 'yeshua.activeApplication';

let availableApplications = [];
let activeApplication = null;

export async function initializeApplicationContext(forceReload = false) {
    if (availableApplications.length > 0 && !forceReload) {
        applyApplication(activeApplication);
        return activeApplication;
    }

    const catalog = await loadApplicationCatalog();
    const central = catalog.find(item => item.hostingMode === 'SharedHost') || catalog[0] || null;
    environments.authenticationApi = central?.apiBasePath || '/yapi';

    availableApplications = filterAuthorizedApplications(catalog, central);
    const selectedName = localStorage.getItem(storageKey);
    activeApplication = availableApplications.find(item => item.application === selectedName)
        || central
        || availableApplications[0]
        || null;

    applyApplication(activeApplication);
    return activeApplication;
}

export function getAuthenticationApi() {
    return environments.authenticationApi || '/yapi';
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
