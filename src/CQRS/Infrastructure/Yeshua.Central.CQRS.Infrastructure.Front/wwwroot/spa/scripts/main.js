import { handleRouting } from './router.js?v=20261028-help02';
import { initFkModal } from './components/fk-modal.js';
import { initializeApplicationContext } from './application-context.js';
import './pages/operational-control.js?v=20261004-logs-panel01';

window.addEventListener('DOMContentLoaded', async () => {
    const hasApplicationEntry = new URLSearchParams(location.search).has('app');
    if (hasApplicationEntry && Number(localStorage.getItem('tokenExp')) <= Date.now()) {
        localStorage.removeItem('token');
        localStorage.removeItem('tokenExp');
    }

    await initializeApplicationContext();
    await initFkModal(); // carrega o modal uma �nica vez
    if (hasApplicationEntry && localStorage.getItem('token')
        && (!location.hash || location.hash === '#login')) {
        const url = new URL(location.href);
        url.hash = 'dashboard';
        history.replaceState(null, '', url);
    }

    handleRouting(location.hash);
});

window.addEventListener('hashchange', () => {
    handleRouting(location.hash);
});
